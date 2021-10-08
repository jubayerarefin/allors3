// <copyright file="Dependency.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the IObjectType type.</summary>

namespace Allors.Database.Meta
{
    public partial class Dependency : IDependency
    {
        public IComposite ObjectType { get; }

        public IPropertyType PropertyType { get; }

        internal Dependency(IComposite objectType, IPropertyType propertyType)
        {
            this.ObjectType = objectType;
            this.PropertyType = propertyType;
        }
    }
}
