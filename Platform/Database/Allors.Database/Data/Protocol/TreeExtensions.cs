// <copyright file="TreeExtensions.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Protocol.Data
{
    using System.Collections.Generic;

    public static class TreeExtensions
    {
        public static Allors.Data.Node[] Load(this Node[] treeNodes, ISession session)
        {
            // TODO: Optimize
            var tree = new List<Allors.Data.Node>();

            foreach (var protocolTreeNode in treeNodes)
            {
                var propertyType = protocolTreeNode.PropertyType.Load(session);
                var treeNode = new Allors.Data.Node(propertyType);
                tree.Add(treeNode);
                protocolTreeNode.Load(session, treeNode);
            }

            return tree.ToArray();
        }
    }
}
