// <copyright file="PushResponseBuilder.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Protocol.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Protocol.Json;
    using Meta;
    using Allors.Protocol.Json.Api.Push;
    using Derivations;
    using Security;

    public class PushResponseBuilder
    {
        private readonly IUnitConvert unitConvert;
        private readonly ITransaction transaction;
        private readonly Func<IValidation> derive;
        private readonly IMetaPopulation metaPopulation;
        private readonly ISet<IClass> allowedClasses;
        private readonly Func<IClass, IObject> build;

        public PushResponseBuilder(ITransaction transaction, Func<IValidation> derive, IMetaPopulation metaPopulation, IAccessControlLists accessControlLists, ISet<IClass> allowedClasses, Func<IClass, IObject> build, IUnitConvert unitConvert)
        {
            this.transaction = transaction;
            this.derive = derive;
            this.metaPopulation = metaPopulation;
            this.allowedClasses = allowedClasses;
            this.build = build;
            this.unitConvert = unitConvert;
            this.AccessControlLists = accessControlLists;
        }

        public IAccessControlLists AccessControlLists { get; }

        public PushResponse Build(PushRequest pushRequest)
        {
            var pushResponse = new PushResponse();
            Dictionary<long, IObject> objectByNewId = null;
            if (pushRequest.n != null && pushRequest.n.Length > 0)
            {
                objectByNewId = pushRequest.n.ToDictionary(
                    x => x.w,
                    x =>
                        {
                            var cls = (IClass)this.metaPopulation.FindByTag(x.t);
                            if (this.allowedClasses?.Contains(cls) == true)
                            {
                                return this.build(cls);
                            }

                            // TODO: Add access error
                            //pushResponse.AddAccessError(x);

                            return null;
                        });
            }

            if (pushRequest.o != null && pushRequest.o.Length > 0)
            {
                // bulk load all objects
                var objectIds = pushRequest.o.Select(v => v.d).ToArray();
                var objects = this.transaction.Instantiate(objectIds);

                if (objectIds.Length != objects.Length)
                {
                    var existingIds = objects.Select(v => v.Id);
                    var missingIds = objectIds.Where(v => !existingIds.Contains(v));
                    foreach (var missingId in missingIds)
                    {
                        pushResponse.AddMissingError(missingId);
                    }
                }

                if (!pushResponse.HasErrors)
                {
                    foreach (var pushRequestObject in pushRequest.o)
                    {
                        var obj = this.transaction.Instantiate(pushRequestObject.d);

                        if (!pushRequestObject.v.Equals(obj.Strategy.ObjectVersion))
                        {
                            pushResponse.AddVersionError(obj);
                        }
                        else if (this.allowedClasses?.Contains(obj.Strategy.Class) == true)
                        {
                            var pushRequestRoles = pushRequestObject.r;
                            this.PushRequestRoles(pushRequestRoles, obj, pushResponse, objectByNewId);
                        }
                        else
                        {
                            pushResponse.AddAccessError(obj);
                        }
                    }
                }
            }

            if (objectByNewId != null && !pushResponse.HasErrors)
            {
                var countOutstandingRoles = 0;
                int previousCountOutstandingRoles;
                do
                {
                    previousCountOutstandingRoles = countOutstandingRoles;
                    countOutstandingRoles = 0;

                    foreach (var pushRequestNewObject in pushRequest.n.OrderByDescending(v => v.w))
                    {
                        var obj = objectByNewId[pushRequestNewObject.w];
                        var pushRequestRoles = pushRequestNewObject.r;
                        if (pushRequestRoles != null)
                        {
                            countOutstandingRoles += this.PushRequestRoles(pushRequestRoles, obj, pushResponse, objectByNewId, true);
                        }
                    }
                }
                while (countOutstandingRoles != previousCountOutstandingRoles);

                if (countOutstandingRoles > 0)
                {
                    foreach (var pushRequestNewObject in pushRequest.n)
                    {
                        var obj = objectByNewId[pushRequestNewObject.w];
                        var pushRequestRoles = pushRequestNewObject.r;
                        if (pushRequestRoles != null)
                        {
                            this.PushRequestRoles(pushRequestRoles, obj, pushResponse, objectByNewId);
                        }
                    }
                }

                // TODO: Check if this is redundant
                //foreach (var newObject in objectByNewId.Values)
                //{
                //    ((IObject)newObject)?.OnBuild();
                //}

                //foreach (var newObject in objectByNewId.Values)
                //{
                //    ((IObject)newObject)?.OnPostBuild();
                //}
            }

            var validation = this.derive();

            if (validation.HasErrors)
            {
                pushResponse.AddDerivationErrors(validation);
            }

            if (!pushResponse.HasErrors)
            {
                pushResponse.NewObjects = objectByNewId?.Select(kvp => new PushResponseNewObject
                {
                    d = kvp.Value?.Id ?? 0,
                    w = kvp.Key,
                }).ToArray();

                this.transaction.Commit();
            }

            return pushResponse;
        }

        private static void AddMissingRoles(IObject[] actualRoles, long[] requestedRoleIds, PushResponse pushResponse)
        {
            var actualRoleIds = actualRoles.Select(x => x.Id);
            var missingRoleIds = requestedRoleIds.Except(actualRoleIds);
            foreach (var missingRoleId in missingRoleIds)
            {
                pushResponse.AddMissingError(missingRoleId);
            }
        }

        private int PushRequestRoles(IList<PushRequestRole> pushRequestRoles, IObject obj, PushResponse pushResponse, Dictionary<long, IObject> objectByNewId, bool ignore = false)
        {
            var countOutstandingRoles = 0;
            foreach (var pushRequestRole in pushRequestRoles)
            {
                var composite = (IComposite)obj.Strategy.Class;

                // TODO: Cache and filter for workspace
                var roleTypes = composite.DatabaseRoleTypes.Where(v => v.RelationType.WorkspaceNames.Length > 0);
                var acl = this.AccessControlLists[obj];

                var roleType = ((IRelationType)this.metaPopulation.FindByTag(pushRequestRole.t)).RoleType;
                if (roleType != null)
                {
                    if (acl.CanWrite(roleType))
                    {
                        if (roleType.ObjectType.IsUnit)
                        {
                            var unitType = (IUnit)roleType.ObjectType;
                            var role = this.unitConvert.FromJson(unitType.Tag, pushRequestRole.u);
                            obj.Strategy.SetUnitRole(roleType, role);
                        }
                        else
                        {
                            if (roleType.IsOne)
                            {
                                if (!pushRequestRole.c.HasValue)
                                {
                                    obj.Strategy.RemoveCompositeRole(roleType);
                                }
                                else
                                {
                                    var role = this.GetRole(pushRequestRole.c.Value, objectByNewId);
                                    if (role == null)
                                    {
                                        pushResponse.AddMissingError(pushRequestRole.c.Value);
                                    }
                                    else
                                    {
                                        obj.Strategy.SetCompositeRole(roleType, role);
                                    }
                                }
                            }
                            else
                            {
                                // Add
                                if (pushRequestRole.AddCompositesRole != null)
                                {
                                    var roleIds = pushRequestRole.AddCompositesRole;
                                    if (roleIds.Length != 0)
                                    {
                                        var roles = this.GetRoles(roleIds, objectByNewId);
                                        if (roles.Length != roleIds.Length)
                                        {
                                            AddMissingRoles(roles, roleIds, pushResponse);
                                        }
                                        else
                                        {
                                            foreach (var role in roles)
                                            {
                                                obj.Strategy.AddCompositeRole(roleType, role);
                                            }
                                        }
                                    }
                                }

                                // Remove
                                if (pushRequestRole.RemoveCompositesRole != null)
                                {
                                    var roleIds = pushRequestRole.RemoveCompositesRole;
                                    if (roleIds.Length != 0)
                                    {
                                        var roles = this.GetRoles(roleIds, objectByNewId);
                                        if (roles.Length != roleIds.Length)
                                        {
                                            AddMissingRoles(roles, roleIds, pushResponse);
                                        }
                                        else
                                        {
                                            foreach (var role in roles)
                                            {
                                                obj.Strategy.RemoveCompositeRole(roleType, role);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!ignore)
                        {
                            pushResponse.AddAccessError(obj);
                        }
                        else
                        {
                            countOutstandingRoles++;
                        }
                    }
                }
            }

            return countOutstandingRoles;
        }

        private IObject GetRole(long roleId, Dictionary<long, IObject> objectByNewId)
        {
            if (objectByNewId == null || !objectByNewId.TryGetValue(roleId, out var role))
            {
                role = this.transaction.Instantiate(roleId);
            }

            return role;
        }

        private IObject[] GetRoles(long[] roleIds, Dictionary<long, IObject> objectByNewId)
        {
            if (objectByNewId == null)
            {
                return this.transaction.Instantiate(roleIds);
            }

            var roles = new List<IObject>();
            List<long> existingRoleIds = null;
            foreach (var roleId in roleIds)
            {
                if (objectByNewId.TryGetValue(roleId, out var role))
                {
                    roles.Add(role);
                }
                else
                {
                    existingRoleIds ??= new List<long>();
                    existingRoleIds.Add(roleId);
                }
            }

            if (existingRoleIds != null)
            {
                var existingRoles = this.transaction.Instantiate(existingRoleIds);
                roles.AddRange(existingRoles);
            }

            return roles.ToArray();
        }
    }
}
