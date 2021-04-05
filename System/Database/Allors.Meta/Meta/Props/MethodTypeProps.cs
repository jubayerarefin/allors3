// <copyright file="MethodClassProps.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the MethodClass type.</summary>

namespace Allors.Database.Meta
{
    public abstract partial class MethodTypeProps : OperandTypeProps
    {
        public ICompositeBase Composite => this.AsMethodType.Composite;

        protected abstract IMethodTypeBase AsMethodType { get; }
    }
}
