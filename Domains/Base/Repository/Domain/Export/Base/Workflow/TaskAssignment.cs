//------------------------------------------------------------------------------------------------- 
// <copyright file="TaskAssignment.cs" company="Allors bvba">
// Copyright 2002-2016 Allors bvba.
// 
// Dual Licensed under
//   a) the Lesser General Public Licence v3 (LGPL)
//   b) the Allors License
// 
// The LGPL License is included in the file lgpl.txt.
// The Allors License is an addendum to your contract.
// 
// Allors Platform is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// For more information visit http://www.allors.com/legal
// </copyright>
// <summary>Defines the Extent type.</summary>
//-------------------------------------------------------------------------------------------------

namespace Allors.Repository
{
    using Attributes;

    #region Allors
    [Id("4092d0b4-c6f4-4b81-b023-66be3f4c90bd")]
    #endregion
    public partial class TaskAssignment : AccessControlledObject, Deletable 
    {
        #region inherited properties
        public Permission[] DeniedPermissions { get; set; }

        public SecurityToken[] SecurityTokens { get; set; }

        #endregion

        #region Allors
        [Id("c32c19f1-3f41-4d11-b19d-b8b2aa360166")]
        [AssociationId("6e08b1d8-f7fa-452d-907a-668bf32702c1")]
        [RoleId("407443f4-5afa-484e-be97-88ef19f00b32")]
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        #endregion
        [Workspace]
        [Required]
        public User User { get; set; }
        
        #region Allors
        [Id("f4e05932-89c0-4f40-b4b2-f241ac42d8a0")]
        [AssociationId("d1f61b05-8f54-47b6-87dd-fd7b66ef0b50")]
        [RoleId("86589718-3284-43e9-8f3e-a0f5faa30357")]
        [Multiplicity(Multiplicity.OneToOne)]
        [Indexed]
        #endregion
        public Notification Notification { get; set; }

        #region Allors
        [Id("8a01f221-480f-4d61-9a12-72e3689a8224")]
        [AssociationId("e5e52776-c946-42b0-99f4-596ffc1c298f")]
        [RoleId("0be6c69a-1d1c-49d0-8247-fa0ff9a8f223")]
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        #endregion
        [Workspace]
        [Required]
        public Task Task { get; set; }

        #region inherited methods
        
        public void OnBuild(){}

        public void OnPostBuild(){}

        public void OnInit()
        {
            throw new System.NotImplementedException();
        }

        public void OnPreDerive(){}

        public void OnDerive(){}

        public void OnPostDerive(){}

        public void Delete(){}
        #endregion
    }
}