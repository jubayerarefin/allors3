
// <copyright file="TreeNodes.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

using Allors.Workspace.Meta;

namespace Allors.Workspace.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class TreeNodes : IEnumerable<TreeNode>
    {
        private readonly IComposite composite;

        private readonly List<TreeNode> items = new List<TreeNode>();

        public TreeNodes(IComposite composite) => this.composite = composite;

        public int Count => this.items.Count;

        public TreeNode this[int i] => this.items[i];

        public void Add(TreeNode treeNode)
        {
            var addedComposite = treeNode.RoleType.AssociationType.ObjectType;

            if (!((Composite)addedComposite).IsAssignableFrom(this.composite) && !this.composite.IsAssignableFrom((Composite)addedComposite))
            {
                throw new ArgumentException(treeNode.RoleType + " is not a valid tree node on " + this.composite + ".");
            }

            this.items.Add(treeNode);
        }

        public IEnumerator<TreeNode> GetEnumerator() => this.items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
