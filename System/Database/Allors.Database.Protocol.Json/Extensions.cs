// <copyright file="FromJsonVisitor.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Protocol.Json
{
    using System;
    using Allors.Protocol.Json.Data;
    using Data;
    using Meta;
    using Extent = Data.Extent;
    using Pull = Allors.Protocol.Json.Data.Pull;
    using Select = Data.Select;

    public static class Extensions
    {
        public static IAssociationType FindAssociationType(this IMetaPopulation @this, Guid? id) => id != null ? ((IRelationType)@this.Find(id.Value)).AssociationType : null;

        public static IRoleType FindRoleType(this IMetaPopulation @this, Guid? id) => id != null ? ((IRelationType)@this.Find(id.Value)).RoleType : null;

        public static Data.Pull FromJson(this Pull pull, ITransaction transaction)
        {
            var fromJsonVisitor = new FromJsonVisitor(transaction);
            pull.Accept(fromJsonVisitor);
            return fromJsonVisitor.Pull;
        }

        public static Data.IExtent FromJson(this Allors.Protocol.Json.Data.Extent extent, ITransaction transaction)
        {
            var fromJsonVisitor = new FromJsonVisitor(transaction);
            extent.Accept(fromJsonVisitor);
            return fromJsonVisitor.Extent;
        }

        public static Select FromJson(this Allors.Protocol.Json.Data.Select extent, ITransaction transaction)
        {
            var fromJsonVisitor = new FromJsonVisitor(transaction);
            extent.Accept(fromJsonVisitor);
            return fromJsonVisitor.Select;
        }

        public static Data.Procedure FromJson(this Allors.Protocol.Json.Data.Procedure procedure, ITransaction transaction)
        {
            var fromJsonVisitor = new FromJsonVisitor(transaction);
            procedure.Accept(fromJsonVisitor);
            return fromJsonVisitor.Procedure;
        }


        public static Pull ToJson(this Data.Pull pull)
        {
            var toJsonVisitor = new ToJsonVisitor();
            pull.Accept(toJsonVisitor);
            return toJsonVisitor.Pull;
        }

        public static Allors.Protocol.Json.Data.Extent ToJson(this Data.IExtent extent)
        {
            var toJsonVisitor = new ToJsonVisitor();
            extent.Accept(toJsonVisitor);
            return toJsonVisitor.Extent;
        }

        public static Allors.Protocol.Json.Data.Select ToJson(this Select extent)
        {
            var toJsonVisitor = new ToJsonVisitor();
            extent.Accept(toJsonVisitor);
            return toJsonVisitor.Select;
        }

        public static Allors.Protocol.Json.Data.Procedure ToJson(this Data.Procedure extent)
        {
            var toJsonVisitor = new ToJsonVisitor();
            extent.Accept(toJsonVisitor);
            return toJsonVisitor.Procedure;
        }
    }
}
