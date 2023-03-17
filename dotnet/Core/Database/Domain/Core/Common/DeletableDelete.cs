// <copyright file="DeletableDelete.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    public partial class DeletableDelete
    {
        public override void Execute()
        {
            var deleting = this.Object.Strategy.Transaction.Services.Get<IDeleting>();

            deleting.OnBeginDelete((Deletable)this.Object);

            try
            {
                base.Execute();

                this.Object.Strategy.Delete();
            }
            finally
            {
                deleting.OnEndDelete((Deletable)this.Object);
            }
        }
    }
}
