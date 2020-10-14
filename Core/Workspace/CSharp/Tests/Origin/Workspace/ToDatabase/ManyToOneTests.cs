// <copyright file="ObjectTests.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Tests.Workspace.Origin.Workspace.ToDatabase
{
    using System.Linq;
    using Allors.Workspace.Data;
    using Allors.Workspace.Domain;
    using Nito.AsyncEx;
    using Xunit;

    public class Many2OneTests : Test
    {
        [Fact]
        public void GetRole() =>
           AsyncContext.Run(
               async () =>
               {
                   var session = this.Workspace.CreateSession();

                   var result = await session.Load(new[]
                   {
                                new Pull
                                {
                                    Extent = new Extent(this.M.Organisation.ObjectType),
                                },
                   });


                   var organisation = result.GetCollection<Organisation>().First();

               });
    }
}