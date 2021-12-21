// <copyright file="OrderShipment.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    public partial class OrderShipment
    {
        public void AppsDelete(DeletableDelete method)
        {
            foreach (var deletable in this.AllVersions)
            {
                deletable.Delete();
            }
        }
    }
}
