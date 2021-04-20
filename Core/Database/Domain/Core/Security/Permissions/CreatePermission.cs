// <copyright file="Permission.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System.Text;
    using System.Linq;

    using Meta;
    using Database.Security;

    public partial class CreatePermission : ICreatePermission
    {
        IClass IPermission.Class => this.Class;
        public Class Class
        {
            get => (Class)this.Strategy.Transaction.Database.MetaPopulation.FindById(this.ClassPointer);

            set
            {
                if (value == null)
                {
                    this.RemoveClassPointer();
                }
                else
                {
                    this.ClassPointer = value.Id;
                }
            }
        }

        public bool ExistClass => this.Class != null;

        public bool ExistOperandType => true;

        public bool ExistOperation => true;

        public IOperandType OperandType => null;

        public Operations Operation => Operations.Create;

        public void CoreOnPreDerive(ObjectOnPreDerive method)
        {
            var (iteration, changeSet, derivedObjects) = method;

            if (changeSet.IsCreated(this) || changeSet.HasChangedRoles(this))
            {
                foreach (Role role in this.RolesWherePermission)
                {
                    iteration.AddDependency(role, this);
                    iteration.Mark(role);
                }

                this.DatabaseContext().PermissionsCache.Clear();
            }
        }

        public bool InWorkspace(string workspaceName) => this.Class.WorkspaceNames.Contains(workspaceName);
        
        public override string ToString()
        {
            var toString = new StringBuilder();
            if (this.ExistOperation)
            {
                var operation = this.Operation;
                toString.Append(operation);
            }
            else
            {
                toString.Append("[missing operation]");
            }

            toString.Append(" for ");

            toString.Append(this.ExistOperandType ? this.OperandType.GetType().Name + ":" + this.OperandType : "[missing operand]");

            return toString.ToString();
        }
    }
}
