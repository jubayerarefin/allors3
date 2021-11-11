// <copyright file="MenuItem.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Autotest
{
    using System.Linq;
    using Allors.Workspace.Meta;
    using Angular;
    using Humanizer;
    using Tests;

    public partial class MenuItem
    {
        public string Tag { get; set; }

        public string AssignedTitle { get; set; }

        public string AssignedLink { get; set; }

        public MenuItem[] Children { get; set; }

        public Menu Menu { get; set; }

        public MenuItem Parent { get; set; }

        public Model Model => this.Menu.Model;

        public string PropertyName => this.Title?.Dehumanize();

        public IObjectType ObjectType => this.Tag != null ? (IObjectType)this.Model.MetaPopulation.FindByTag(this.Tag) : null;

        public MetaExtension MetaExtension
        {
            get
            {
                if (this.ObjectType != null)
                {
                    this.Model.MetaExtensionByTag.TryGetValue(this.ObjectType.Tag, out var metaExtension);
                    return metaExtension;
                }

                return null;
            }
        }

        public string Title => this.AssignedTitle ?? this.ObjectType?.PluralName;

        public string Link => this.AssignedLink ?? this.MetaExtension?.List;

        public Directive Component
        {
            get
            {
                var link = this.Link;
                var route = this.Menu.Model.Project.FindRouteForFullPath(link);
                return route?.Component;
            }
        }

        public void BaseLoadMenu(MenuInfo item)
        {
            this.Tag = item.tag;
            this.AssignedTitle = item.title;
            this.AssignedLink = item.link;

            this.Children = item.children
                ?.Select(v =>
                {
                    var child = new MenuItem
                    {
                        Menu = this.Menu,
                        Parent = this,
                    };
                    child.Load(v);
                    return child;
                }).ToArray();
        }
    }
}