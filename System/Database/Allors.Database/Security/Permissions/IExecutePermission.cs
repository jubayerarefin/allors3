// <copyright file="Permission.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors
{
    using Meta;

    public interface IExecutePermission : IPermission
    {
        IMethodType MethodType { get; }
    }
}
