// <copyright file="EnumerationExtensions.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

using System.IO;
using System.Linq;
using System.Reflection;

namespace Allors.Domain
{
    public static partial class EnumerationExtensions
    {
        public static void AppsOnBuild(this Enumeration @this, ObjectOnBuild method)
        {
            if (!@this.IsActive.HasValue)
            {
                @this.IsActive = true;
            }
        }
    }
}
