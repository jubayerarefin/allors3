// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PurchaseReturn.cs" company="Allors bvba">
//   Copyright 2002-2012 Allors bvba.
// Dual Licensed under
//   a) the General Public Licence v3 (GPL)
//   b) the Allors License
// The GPL License is included in the file gpl.txt.
// The Allors License is an addendum to your contract.
// Allors Applications is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// For more information visit http://www.allors.com/legal
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Allors.Domain
{
    using Allors.Meta;

    public partial class PurchaseReturn
    {
        public static readonly TransitionalConfiguration[] StaticTransitionalConfigurations =
            {
                new TransitionalConfiguration(M.PurchaseReturn, M.PurchaseReturn.ShipmentState),
            };

        public TransitionalConfiguration[] TransitionalConfigurations => StaticTransitionalConfigurations;

        public void AppsOnBuild(ObjectOnBuild method)
        {
            if (!this.ExistShipmentState)
            {
                this.ShipmentState = new ShipmentStates(this.Strategy.Session).Created;
            }
        }

        public void AppsOnDerive(ObjectOnDerive method)
        {
            var derivation = method.Derivation;

            if (!this.ExistShipToAddress && this.ExistShipToParty)
            {
                this.ShipToAddress = this.ShipToParty.ShippingAddress;
            }

            if (!this.ExistShipFromAddress && this.ExistShipFromParty)
            {
                this.ShipFromAddress = this.ShipFromParty.ShippingAddress;
            }

            this.Sync(this.strategy.Session);
        }

        private void Sync(ISession session)
        {
            //session.Prefetch(this.SyncPrefetch, this);

            foreach (ShipmentItem shipmentItem in this.ShipmentItems)
            {
                shipmentItem.Sync(this);
            }
        }
    }
}
