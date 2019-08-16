// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FixedAssetAssignmentModel.cs" company="Allors bvba">
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

namespace Allors.Domain.Print.WorkTaskModel
{
    public class FixedAssetAssignmentModel
    {
        public FixedAssetAssignmentModel(WorkEffortFixedAssetAssignment assignment)
        {
            this.Name = assignment.FixedAsset?.Name;
            this.Comment = assignment.FixedAsset?.Comment;

            if (assignment.FixedAsset is SerialisedItem serialisedItem)
            {
                this.CustomerReferenceNumber = serialisedItem.CustomerReferenceNumber;
                this.ItemNumber = serialisedItem.ItemNumber;
                this.SerialNumber = serialisedItem.SerialNumber;
                this.Brand = serialisedItem.PartWhereSerialisedItem?.Brand?.Name;
                this.Model = serialisedItem.PartWhereSerialisedItem?.Model?.Name;
            }
        }

        public string Name { get; }
        public string CustomerReferenceNumber { get; }
        public string SerialNumber { get; }
        public string ItemNumber { get; }
        public string Brand { get; }
        public string Model { get; }
        public string Comment { get; }
    }
}