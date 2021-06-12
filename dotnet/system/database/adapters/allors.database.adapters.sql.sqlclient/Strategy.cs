// <copyright file="Strategy.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>
//   Defines the AllorsStrategySql type.
// </summary>

namespace Allors.Database.Adapters.Sql.SqlClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Adapters;
    using Caching;
    using Collections;
    using Meta;

    public class Strategy : IStrategy
    {
        private IObject allorsObject;

        private ICachedObject cachedObject;

        private Dictionary<IRoleType, object> modifiedRoleByRoleType;
        private HashSet<IRoleType> requireFlushRoles;

        private Dictionary<IRoleType, object> originalRoleByRoleType;
        private Dictionary<IAssociationType, object> originalAssociationByAssociationType;

        internal Strategy(Reference reference)
        {
            this.Reference = reference;
            this.ObjectId = reference.ObjectId;
            this.State = this.Transaction.State;
        }

        ITransaction IStrategy.Transaction => this.Reference.Transaction;

        public Transaction Transaction => this.Reference.Transaction;

        public IClass Class
        {
            get
            {
                if (!this.Reference.Exists)
                {
                    throw new Exception("Object that had  " + this.Reference.Class.Name + " with id " + this.ObjectId + " does not exist");
                }

                return this.Reference.Class;
            }
        }

        public long ObjectId { get; }

        public long ObjectVersion => this.Reference.Version;

        public bool IsDeleted => !this.Reference.Exists;

        public bool IsNewInTransaction => this.Reference.IsNew;

        internal Reference Reference { get; }

        internal ICachedObject CachedObject
        {
            get
            {
                if (this.cachedObject != null || this.Reference.IsNew)
                {
                    return this.cachedObject;
                }

                var cache = this.Transaction.Database.Cache;
                this.cachedObject = cache.GetOrCreateCachedObject(this.Reference.Class, this.Reference.ObjectId, this.Reference.Version);
                return this.cachedObject;
            }
        }

        internal ISet<IRoleType> CheckpointRoleTypes
        {
            get
            {
                if (this.originalRoleByRoleType == null)
                {
                    return null;
                }

                ISet<IRoleType> changedRoleTypes = null;

                foreach (var kvp in this.originalRoleByRoleType)
                {
                    var roleType = kvp.Key;
                    var originalRole = kvp.Value;

                    if (!Equals(originalRole, this.GetUnitRoleInternal(roleType)))
                    {
                        changedRoleTypes ??= new HashSet<IRoleType>();
                        changedRoleTypes.Add(roleType);
                    }
                }


                this.originalRoleByRoleType = null;

                return changedRoleTypes;
            }
        }

        public ISet<IAssociationType> CheckpointAssociationTypes
        {
            get
            {
                if (this.originalAssociationByAssociationType == null)
                {
                    return null;
                }

                ISet<IAssociationType> changedAssociationTypes = null;

                foreach (var kvp in this.originalAssociationByAssociationType)
                {
                    var associationType = kvp.Key;
                    var originalAssociation = kvp.Value;

                    //if (!Equals(originalAssociation, this.GetCompositeAssociation(associationType)))
                    //{
                    //    changedAssociationTypes ??= new HashSet<IAssociationType>();
                    //    changedAssociationTypes.Add(associationType);
                    //}
                }

                this.originalAssociationByAssociationType = null;

                return changedAssociationTypes;
            }
        }


        internal Dictionary<IRoleType, object> EnsureModifiedRoleByRoleType => this.modifiedRoleByRoleType ??= new Dictionary<IRoleType, object>();

        private HashSet<IRoleType> EnsureRequireFlushRoles => this.requireFlushRoles ??= new HashSet<IRoleType>();

        private State State { get; }

        public IObject GetObject() => this.allorsObject ??= this.Reference.Transaction.Database.ObjectFactory.Create(this);

        public virtual void Delete()
        {
            this.AssertExist();

            foreach (var roleType in this.Class.DatabaseRoleTypes)
            {
                if (roleType.ObjectType.IsComposite)
                {
                    this.RemoveRole(roleType);
                }
            }

            foreach (var associationType in this.Class.DatabaseAssociationTypes)
            {
                var roleType = associationType.RoleType;

                if (associationType.IsMany)
                {
                    foreach (var association in this.Transaction.GetAssociations(this, associationType))
                    {
                        var associationStrategy = this.Transaction.State.GetOrCreateReferenceForExistingObject(association, this.Transaction).Strategy;
                        if (roleType.IsMany)
                        {
                            associationStrategy.RemoveCompositeRole(roleType, this.GetObject());
                        }
                        else
                        {
                            associationStrategy.RemoveCompositeRole(roleType);
                        }
                    }
                }
                else
                {
                    var association = this.GetCompositeAssociation(associationType);
                    if (association != null)
                    {
                        if (roleType.IsMany)
                        {
                            association.Strategy.RemoveCompositeRole(roleType, this.GetObject());
                        }
                        else
                        {
                            association.Strategy.RemoveCompositeRole(roleType);
                        }
                    }
                }
            }

            this.Transaction.Commands.DeleteObject(this);
            this.Reference.Exists = false;

            this.Transaction.State.ChangeLog.OnDeleted(this);
        }

        public virtual bool ExistRole(IRoleType roleType)
        {
            if (roleType.ObjectType.IsUnit)
            {
                return this.ExistUnitRole(roleType);
            }

            return roleType.IsMany
                ? this.ExistCompositeRoles(roleType)
                : this.ExistCompositeRole(roleType);
        }

        public virtual object GetRole(IRoleType roleType)
        {
            if (roleType.ObjectType.IsUnit)
            {
                return this.GetUnitRole(roleType);
            }

            return roleType.IsMany
                       ? (object)this.GetCompositeRoles(roleType)
                       : this.GetCompositeRole(roleType);
        }

        public virtual void SetRole(IRoleType roleType, object value)
        {
            if (roleType.ObjectType.IsUnit)
            {
                this.SetUnitRole(roleType, value);
            }
            else
            {
                if (roleType.IsMany)
                {
                    this.SetCompositeRoles(roleType, (IEnumerable<IObject>)value);
                }
                else
                {
                    this.SetCompositeRole(roleType, (IObject)value);
                }
            }
        }

        public virtual void RemoveRole(IRoleType roleType)
        {
            if (roleType.ObjectType.IsUnit)
            {
                this.RemoveUnitRole(roleType);
            }
            else
            {
                if (roleType.IsMany)
                {
                    this.RemoveCompositeRoles(roleType);
                }
                else
                {
                    this.RemoveCompositeRole(roleType);
                }
            }
        }

        public virtual bool ExistUnitRole(IRoleType roleType) => this.GetUnitRole(roleType) != null;

        public virtual object GetUnitRole(IRoleType roleType)
        {
            this.AssertExist();
            return this.GetUnitRoleInternal(roleType);
        }

        public virtual void SetUnitRole(IRoleType roleType, object role)
        {
            this.AssertExist();
            roleType.UnitRoleChecks(this);
            role = roleType.Normalize(role);

            this.SetUnitRoleInternal(roleType, role);
        }

        public virtual void RemoveUnitRole(IRoleType roleType) => this.SetUnitRole(roleType, null);

        public virtual bool ExistCompositeRole(IRoleType roleType) => this.GetCompositeRole(roleType) != null;

        public virtual IObject GetCompositeRole(IRoleType roleType)
        {
            this.AssertExist();
            var role = this.GetCompositeRoleInternal(roleType);
            return role == null ? null : this.Transaction.State.GetOrCreateReferenceForExistingObject(role.Value, this.Transaction).Strategy.GetObject();
        }

        public virtual void SetCompositeRole(IRoleType roleType, IObject newRoleObject)
        {
            if (newRoleObject == null)
            {
                this.RemoveCompositeRole(roleType);
            }
            else
            {
                this.AssertExist();
                roleType.CompositeRoleChecks(this, newRoleObject);

                var newRole = (Strategy)newRoleObject.Strategy;

                if (roleType.AssociationType.IsOne)
                {
                    this.SetCompositeRoleOne2One(roleType, newRole);
                }
                else
                {
                    this.SetCompositeRoleMany2One(roleType, newRole);
                }
            }
        }

        public virtual void RemoveCompositeRole(IRoleType roleType)
        {
            this.AssertExist();
            roleType.CompositeRoleChecks(this);

            if (roleType.AssociationType.IsOne)
            {
                this.RemoveCompositeRoleOne2One(roleType);
            }
            else
            {
                this.RemoveCompositeRoleMany2One(roleType);
            }
        }

        public virtual bool ExistCompositeRoles(IRoleType roleType) => this.GetCompositeRoles(roleType).Count != 0;

        public virtual Allors.Database.Extent GetCompositeRoles(IRoleType roleType)
        {
            this.AssertExist();
            return new ExtentRoles(this, roleType);
        }

        public virtual void AddCompositeRole(IRoleType roleType, IObject roleObject)
        {
            this.AssertExist();

            if (roleObject == null)
            {
                return;
            }

            roleType.CompositeRolesChecks(this, roleObject);
            var role = (Strategy)roleObject.Strategy;

            if (roleType.AssociationType.IsOne)
            {
                this.AddCompositeRoleOne2Many(roleType, role);
            }
            else
            {
                this.AddCompositeRoleMany2Many(roleType, role);
            }
        }

        public virtual void RemoveCompositeRole(IRoleType roleType, IObject roleObject)
        {
            this.AssertExist();

            if (roleObject != null)
            {
                roleType.CompositeRolesChecks(this, roleObject);

                var role = (Strategy)roleObject.Strategy;
                if (roleType.AssociationType.IsOne)
                {
                    this.RemoveCompositeRoleOne2Many(roleType, role);
                }
                else
                {
                    this.RemoveCompositeRoleMany2Many(roleType, role);
                }
            }
        }

        public virtual void SetCompositeRoles(IRoleType roleType, IEnumerable<IObject> roleObjects)
        {
            var roleCollection = roleObjects != null ? roleObjects as ICollection<IObject> ?? roleObjects.ToArray() : null;

            if (roleCollection == null || roleCollection.Count == 0)
            {
                this.RemoveCompositeRoles(roleType);
            }
            else
            {
                this.AssertExist();

                // TODO: use CompositeRoles
                var previousRoles = new List<long>(this.GetCompositesRole(roleType));
                var newRoles = new HashSet<long>();

                foreach (var roleObject in roleCollection)
                {
                    if (roleObject != null)
                    {
                        roleType.CompositeRolesChecks(this, roleObject);
                        var role = (Strategy)roleObject.Strategy;

                        if (!previousRoles.Contains(role.ObjectId))
                        {
                            if (roleType.AssociationType.IsOne)
                            {
                                this.AddCompositeRoleOne2Many(roleType, role);
                            }
                            else
                            {
                                this.AddCompositeRoleMany2Many(roleType, role);
                            }
                        }

                        newRoles.Add(role.ObjectId);
                    }
                }

                foreach (var previousRole in previousRoles)
                {
                    if (!newRoles.Contains(previousRole))
                    {
                        var role = this.Transaction.State.GetOrCreateReferenceForExistingObject(previousRole, this.Transaction).Strategy;
                        if (roleType.AssociationType.IsOne)
                        {
                            this.RemoveCompositeRoleOne2Many(roleType, role);
                        }
                        else
                        {
                            this.RemoveCompositeRoleMany2Many(roleType, role);
                        }
                    }
                }
            }
        }

        public virtual void RemoveCompositeRoles(IRoleType roleType)
        {
            this.AssertExist();

            roleType.CompositeRoleChecks(this);

            var previousRoles = this.GetCompositesRole(roleType);

            foreach (var previousRole in previousRoles)
            {
                var role = this.Transaction.State.GetOrCreateReferenceForExistingObject(previousRole, this.Transaction).Strategy;
                if (roleType.AssociationType.IsOne)
                {
                    this.RemoveCompositeRoleOne2Many(roleType, role);
                }
                else
                {
                    this.RemoveCompositeRoleMany2Many(roleType, role);
                }

            }
        }

        public virtual bool ExistAssociation(IAssociationType associationType) => associationType.IsMany ? this.ExistCompositeAssociations(associationType) : this.ExistCompositeAssociation(associationType);

        public virtual object GetAssociation(IAssociationType associationType) => associationType.IsMany ? (object)this.GetCompositeAssociations(associationType) : this.GetCompositeAssociation(associationType);

        public virtual bool ExistCompositeAssociation(IAssociationType associationType) => this.GetCompositeAssociation(associationType) != null;

        public virtual IObject GetCompositeAssociation(IAssociationType associationType)
        {
            this.AssertExist();
            var associationByRole = this.Transaction.State.GetAssociationByRole(associationType);

            if (!associationByRole.TryGetValue(this.Reference, out var association1))
            {
                this.Transaction.State.FlushConditionally(this.ObjectId, associationType);
                association1 = this.Transaction.Commands.GetCompositeAssociation(this.Reference, associationType);
                associationByRole[this.Reference] = association1;
            }

            var association = association1;
            return association?.Strategy.GetObject();
        }

        public virtual bool ExistCompositeAssociations(IAssociationType associationType) => this.GetCompositeAssociations(associationType).Count != 0;

        public virtual Allors.Database.Extent GetCompositeAssociations(IAssociationType associationType)
        {
            this.AssertExist();
            return new ExtentAssociations(this, associationType);
        }

        public override string ToString() => "[" + this.Class + ":" + this.ObjectId + "]";

        internal virtual void Release()
        {
            this.cachedObject = null;
            this.modifiedRoleByRoleType = null;
            this.requireFlushRoles = null;
        }

        protected virtual void AssertExist()
        {
            if (!this.Reference.Exists)
            {
                throw new Exception("Object of class " + this.Class.Name + " with id " + this.ObjectId + " does not exist");
            }
        }

        #region Extent
        internal int ExtentRolesGetCount(IRoleType roleType)
        {
            this.AssertExist();
            return this.TryGetModifiedCompositesRole(roleType, out var compositesRole) ? compositesRole.Count : this.GetNonModifiedCompositeRoles(roleType).Length;
        }

        internal void ExtentRolesCopyTo(IRoleType roleType, Array array, int index)
        {
            Transaction transaction = this.Transaction;
            if (this.TryGetModifiedCompositesRole(roleType, out var compositesRole))
            {
                var i = 0;
                foreach (var objectId in compositesRole.ObjectIds)
                {
                    array.SetValue(transaction.State.GetOrCreateReferenceForExistingObject(objectId, transaction).Strategy.GetObject(), index + i);
                    ++i;
                }

                return;
            }

            var nonModifiedCompositeRoles = this.GetNonModifiedCompositeRoles(roleType);
            for (var i = 0; i < nonModifiedCompositeRoles.Length; i++)
            {
                var objectId = nonModifiedCompositeRoles[i];
                array.SetValue(transaction.State.GetOrCreateReferenceForExistingObject(objectId, transaction).Strategy.GetObject(), index + i);
            }
        }

        internal int ExtentIndexOf(IRoleType roleType, IObject value)
        {
            var i = 0;
            foreach (var oid in this.GetCompositesRole(roleType))
            {
                if (oid.Equals(value.Id))
                {
                    return i;
                }

                ++i;
            }

            return -1;
        }

        internal IObject ExtentGetItem(IRoleType roleType, int index)
        {
            var i = 0;
            foreach (var oid in this.GetCompositesRole(roleType))
            {
                if (i == index)
                {
                    return this.Transaction.State.GetOrCreateReferenceForExistingObject(oid, this.Transaction).Strategy.GetObject();
                }

                ++i;
            }

            return null;
        }

        internal bool ExtentRolesContains(IRoleType roleType, IObject value)
        {
            if (this.TryGetModifiedCompositesRole(roleType, out var compositesRole))
            {
                return compositesRole.Contains(value.Id);
            }

            return Array.IndexOf(this.GetNonModifiedCompositeRoles(roleType), value.Id) >= 0;
        }

        internal virtual long[] ExtentGetCompositeAssociations(IAssociationType associationType)
        {
            this.AssertExist();

            return this.Transaction.GetAssociations(this, associationType);
        }
        #endregion

        #region State
        private object GetUnitRoleInternal(IRoleType roleType)
        {
            object role = null;
            if (this.TryGetModifiedRole(roleType, ref role))
            {
                return role;
            }

            if (this.CachedObject != null && this.CachedObject.TryGetValue(roleType, out role))
            {
                return role;
            }

            if (this.Reference.IsNew)
            {
                return role;
            }

            this.Transaction.Commands.GetUnitRoles(this);
            this.cachedObject.TryGetValue(roleType, out role);
            return role;
        }

        private void SetUnitRoleInternal(IRoleType roleType, object role)
        {
            var previousRole = this.GetUnitRoleInternal(roleType);
            // R = PR
            if (Equals(previousRole, role))
            {
                return;
            }

            this.OnChangedUnitRole(roleType, previousRole);

            // A ----> R
            this.EnsureModifiedRoleByRoleType[roleType] = role;
            this.RequireFlush(roleType);
        }

        private long? GetCompositeRoleInternal(IRoleType roleType)
        {
            object role = null;
            if (this.TryGetModifiedRole(roleType, ref role))
            {
                return (long?)role;
            }

            if (this.CachedObject != null && this.CachedObject.TryGetValue(roleType, out role))
            {
                return (long?)role;
            }

            if (this.Reference.IsNew)
            {
                return (long?)role;
            }

            this.Transaction.Commands.GetCompositeRole(this, roleType);
            this.cachedObject.TryGetValue(roleType, out role);
            return (long?)role;
        }

        private void SetCompositeRoleOne2One(IRoleType roleType, Strategy role)
        {
            /*  [if exist]        [then remove]        set
             *
             *  RA ----- R         RA --x-- R       RA    -- R       RA    -- R
             *                ->                +        -        =       -
             *   A ----- PR         A --x-- PR       A --    PR       A --    PR
             */
            var previousRoleId = this.GetCompositeRoleInternal(roleType);
            var roleId = role.Reference.ObjectId;

            // R = PR
            if (Equals(roleId, previousRoleId))
            {
                return;
            }

            // A --x-- PR
            if (previousRoleId != null)
            {
                var previousRole = this.State.GetOrCreateReferenceForExistingObject(previousRoleId.Value, this.Transaction).Strategy;
                this.RemoveCompositeRoleOne2One(roleType, previousRole);
            }

            var roleAssociation = (Strategy)role.GetCompositeAssociation(roleType.AssociationType)?.Strategy;

            // RA --x-- R
            roleAssociation?.RemoveCompositeRoleOne2One(roleType, role);

            // A <---- R
            var associationByRole = this.State.GetAssociationByRole(roleType.AssociationType);
            associationByRole[role.Reference] = this.Reference;

            // A ----> R
            this.EnsureModifiedRoleByRoleType[roleType] = roleId;
            this.RequireFlush(roleType);
        }

        private void SetCompositeRoleMany2One(IRoleType roleType, Strategy role)
        {
            /*  [if exist]        [then remove]        set
             *
             *  RA ----- R         RA       R       RA    -- R       RA ----- R
             *                ->                +        -        =       -
             *   A ----- PR         A --x-- PR       A --    PR       A --    PR
             */
            var previousRoleId = this.GetCompositeRoleInternal(roleType);
            var roleId = role.Reference.ObjectId;

            // R = PR
            if (Equals(roleId, previousRoleId))
            {
                return;
            }

            // A --x-- PR
            if (previousRoleId != null)
            {
                var previousRole = this.State.GetOrCreateReferenceForExistingObject(previousRoleId.Value, this.Transaction).Strategy;
                this.RemoveCompositeRoleMany2One(roleType, previousRole);
            }

            // A <---- R
            var associationsByRole = this.State.GetAssociationsByRole(roleType.AssociationType);
            if (associationsByRole.TryGetValue(role.Reference, out var associations))
            {
                associationsByRole[role.Reference] = associations.Add(this.Reference.ObjectId);
            }

            this.State.TriggerFlush(roleId, roleType.AssociationType);

            // A ----> R
            this.EnsureModifiedRoleByRoleType[roleType] = roleId;
            this.RequireFlush(roleType);
        }

        private void RemoveCompositeRoleOne2One(IRoleType roleType)
        {
            var roleId = this.GetCompositeRoleInternal(roleType);
            if (roleId == null)
            {
                return;
            }

            var role = this.State.GetOrCreateReferenceForExistingObject(roleId.Value, this.Transaction).Strategy;
            this.RemoveCompositeRoleOne2One(roleType, role);
        }

        private void RemoveCompositeRoleMany2One(IRoleType roleType)
        {
            var roleId = this.GetCompositeRoleInternal(roleType);
            if (roleId == null)
            {
                return;
            }

            var role = this.State.GetOrCreateReferenceForExistingObject(roleId.Value, this.Transaction).Strategy;
            this.RemoveCompositeRoleMany2One(roleType, role);
        }

        internal IEnumerable<long> GetCompositesRole(IRoleType roleType)
        {
            if (this.TryGetModifiedCompositesRole(roleType, out var compositesRole))
            {
                return compositesRole.ObjectIds;
            }

            return this.GetNonModifiedCompositeRoles(roleType);
        }

        private void AddCompositeRoleOne2Many(IRoleType roleType, Strategy role)
        {
            /*  [if exist]        [then remove]        set
            *
            *  RA ----- R         RA       R       RA    -- R       RA ----- R
            *                ->                +        -        =       -
            *   A ----- PR         A --x-- PR       A --    PR       A --    PR
            */
            var previousRoleIds = this.GetCompositesRole(roleType);

            // R in PR 
            if (previousRoleIds.Contains(role.ObjectId))
            {
                return;
            }

            // A --x-- PR
            var previousAssociation = (Strategy)role.GetCompositeAssociation(roleType.AssociationType)?.Strategy;
            previousAssociation?.RemoveCompositeRole(roleType, role.GetObject());

            // A <---- R
            var associationByRole = this.State.GetAssociationByRole(roleType.AssociationType);
            associationByRole[role.Reference] = this.Reference;

            // A ----> R
            var compositesRole = this.GetOrCreateModifiedCompositeRoles(roleType);
            compositesRole.Add(role.ObjectId);
            this.RequireFlush(roleType);
        }

        private void AddCompositeRoleMany2Many(IRoleType roleType, Strategy role)
        {
            /*  [if exist]        [no remove]         set
            *
            *  RA ----- R         RA       R       RA    -- R       RA ----- R
            *                ->                +        -        =       -
            *   A ----- PR         A       PR       A --    PR       A --    PR
            */
            var previousRoleIds = this.GetCompositesRole(roleType);

            // R in PR 
            if (previousRoleIds.Contains(role.ObjectId))
            {
                return;
            }

            // A <---- R
            var associationsByRole = this.State.GetAssociationsByRole(roleType.AssociationType);
            if (associationsByRole.TryGetValue(role.Reference, out var associations))
            {
                associationsByRole[role.Reference] = associations.Add(this.Reference.ObjectId);
            }

            this.State.TriggerFlush(role.ObjectId, roleType.AssociationType);

            // A ----> R
            var compositesRole = this.GetOrCreateModifiedCompositeRoles(roleType);
            compositesRole.Add(role.ObjectId);
            this.RequireFlush(roleType);
        }

        private void RemoveCompositeRoleOne2Many(IRoleType roleType, Strategy role)
        {
            var previousRoleIds = this.GetCompositesRole(roleType);

            // R not in PR 
            if (!previousRoleIds.Contains(role.ObjectId))
            {
                return;
            }

            // A <---- R
            var associationByRole = this.State.GetAssociationByRole(roleType.AssociationType);
            associationByRole[role.Reference] = null;

            // A ----> R
            var compositesRole = this.GetOrCreateModifiedCompositeRoles(roleType);
            compositesRole.Remove(role.ObjectId);
            this.RequireFlush(roleType);
        }

        private void RemoveCompositeRoleMany2Many(IRoleType roleType, Strategy role)
        {
            var previousRoleIds = this.GetCompositesRole(roleType);

            // R not in PR 
            if (!previousRoleIds.Contains(role.ObjectId))
            {
                return;
            }

            // A <---- R
            this.Transaction.RemoveAssociation(this.Reference, role.Reference, roleType.AssociationType);
            this.State.TriggerFlush(role.ObjectId, roleType.AssociationType);

            // A ----> R
            var compositesRole = this.GetOrCreateModifiedCompositeRoles(roleType);
            compositesRole.Remove(role.ObjectId);
            this.RequireFlush(roleType);
        }

        private void RemoveCompositeRoleOne2One(IRoleType roleType, Strategy role)
        {
            var associationByRole = this.State.GetAssociationByRole(roleType.AssociationType);
            associationByRole[role.Reference] = null;

            this.EnsureModifiedRoleByRoleType[roleType] = null;
            this.RequireFlush(roleType);
        }

        private void RemoveCompositeRoleMany2One(IRoleType roleType, Strategy role)
        {
            this.Transaction.RemoveAssociation(this.Reference, role.Reference, roleType.AssociationType);

            this.State.TriggerFlush(role.ObjectId, roleType.AssociationType);

            this.EnsureModifiedRoleByRoleType[roleType] = null;
            this.RequireFlush(roleType);
        }

        private CompositesRole GetOrCreateModifiedCompositeRoles(IRoleType roleType)
        {
            if (this.TryGetModifiedCompositesRole(roleType, out var compositesRole))
            {
                return compositesRole;
            }

            compositesRole = new CompositesRole(this.GetCompositesRole(roleType));
            this.EnsureModifiedRoleByRoleType[roleType] = compositesRole;
            return compositesRole;
        }

        private bool TryGetModifiedRole(IRoleType roleType, ref object role) => this.modifiedRoleByRoleType != null && this.modifiedRoleByRoleType.TryGetValue(roleType, out role);

        private bool TryGetModifiedCompositesRole(IRoleType roleType, out CompositesRole compositesRole)
        {
            object role = null;
            var result = this.modifiedRoleByRoleType != null && this.modifiedRoleByRoleType.TryGetValue(roleType, out role);
            compositesRole = (CompositesRole)role;
            return result;
        }

        private long[] GetNonModifiedCompositeRoles(IRoleType roleType)
        {
            if (this.Reference.IsNew)
            {
                return Array.Empty<long>();
            }

            if (this.CachedObject.TryGetValue(roleType, out var roleOut))
            {
                return (long[])roleOut;
            }

            this.Transaction.Commands.GetCompositesRole(this, roleType);
            this.cachedObject.TryGetValue(roleType, out roleOut);
            return (long[])roleOut;
        }

        #endregion

        #region Flushing
        internal void Flush(Flush flush)
        {
            IRoleType unitRole = null;
            List<IRoleType> unitRoles = null;
            foreach (var flushRole in this.EnsureRequireFlushRoles)
            {
                if (flushRole.ObjectType.IsUnit)
                {
                    if (unitRole == null)
                    {
                        unitRole = flushRole;
                    }
                    else
                    {
                        unitRoles ??= new List<IRoleType> { unitRole };
                        unitRoles.Add(flushRole);
                    }
                }
                else
                {
                    if (flushRole.IsOne)
                    {
                        var role = this.GetCompositeRoleInternal(flushRole);
                        if (role != null)
                        {
                            flush.SetCompositeRole(this.Reference, flushRole, role.Value);
                        }
                        else
                        {
                            flush.ClearCompositeAndCompositesRole(this.Reference, flushRole);
                        }
                    }
                    else
                    {
                        var roles = (CompositesRole)this.modifiedRoleByRoleType[flushRole];
                        roles.Flush(flush, this, flushRole);
                    }
                }
            }

            if (unitRoles != null)
            {
                unitRoles.Sort();
                this.Transaction.Commands.SetUnitRoles(this, unitRoles);
            }
            else if (unitRole != null)
            {
                flush.SetUnitRole(this.Reference, unitRole, this.GetUnitRoleInternal(unitRole));
            }

            this.requireFlushRoles = null;
        }

        private void RequireFlush(IRoleType roleType)
        {
            this.EnsureRequireFlushRoles.Add(roleType);
            this.State.RequireFlush(this);
        }

        #endregion

        #region Changelog
        private void OnChangedUnitRole(IRoleType roleType, object previousRole)
        {
            this.originalRoleByRoleType ??= new Dictionary<IRoleType, object>();
            if (this.originalRoleByRoleType.ContainsKey(roleType))
            {
                return;
            }

            this.originalRoleByRoleType.Add(roleType, previousRole);

            this.State.ChangeLog.OnChangedRoleTypes(this);
        }
        
        #endregion

        #region Prefetch
        internal bool PrefetchTryGetUnitRole(IRoleType roleType)
        {
            if (this.modifiedRoleByRoleType != null && this.modifiedRoleByRoleType.ContainsKey(roleType))
            {
                return true;
            }

            if (this.CachedObject != null && this.CachedObject.Contains(roleType))
            {
                return true;
            }

            return this.Reference.IsNew;
        }

        internal bool PrefetchTryGetCompositeRole(IRoleType roleType, out long? roleId)
        {
            roleId = null;

            object role = null;

            if (this.TryGetModifiedRole(roleType, ref role))
            {
                roleId = (long?)role;
                return true;
            }

            if (this.CachedObject == null || !this.CachedObject.TryGetValue(roleType, out role))
            {
                if (!this.Reference.IsNew)
                {
                    return false;
                }
            }

            roleId = (long?)role;
            return true;
        }

        internal bool PrefetchTryGetCompositesRole(IRoleType roleType, out IEnumerable<long> roleIds)
        {
            roleIds = null;

            if (this.TryGetModifiedCompositesRole(roleType, out var compositesRole))
            {
                roleIds = compositesRole.ObjectIds;
            }

            return false;
        }
        #endregion
    }
}
