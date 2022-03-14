// <copyright file="WorkRequirementFulfillment.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System.Linq;

    public partial class WorkRequirementFulfillment
    {
        public void AppsDelete(DeletableDelete method)
        {
            if (this.FullfilledBy.RequirementState.IsInProgress)
            {
                this.FullfilledBy.RequirementState = new RequirementStates(this.Strategy.Transaction).Created;
            }
        }
    }
}
