// <copyright file="Route.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All Rights Reserved.
// Licensed under the LGPL v3 license.
// </copyright>

namespace Autotest.Angular
{
    using System.Linq;

    using Newtonsoft.Json.Linq;

    public partial class Route
    {
        public Route(Module module, JToken jToken)
        {
            this.Module = module;
            this.Json = jToken;
        }

        public Module Module { get; }

        public JToken Json { get; }

        public Route Parent { get; set; }

        public string Path { get; set; }

        public string PathMatch { get; set; }

        public Directive Component { get; set; }

        public string RedirectTo { get; set; }

        public string Outlet { get; set; }

        public JToken Data { get; set; }

        public Route[] Children { get; set; }

        public void BaseLoad()
        {
            var jsonRoutes = this.Json["children"];
            this.Children = jsonRoutes != null ? jsonRoutes.Select(v =>
                {
                    var route = new Route(this.Module, v)
                                    {
                                        Parent = this,
                                    };
                    route.BaseLoad();
                    return route;
                }).ToArray() : new Route[0];

            this.Path = this.Json["path"]?.Value<string>();
            this.PathMatch = this.Json["pathMatch"]?.Value<string>();
            this.RedirectTo = this.Json["redirectTo"]?.Value<string>();
            this.Outlet = this.Json["outlet"]?.Value<string>();
            this.Data = this.Json["data"]?.Value<string>();

            var componentId = Angular.Reference.ParseId(this.Json["component"]);
            this.Component = componentId != null ? this.Module.Project.DirectiveById[componentId] : null;
        }
    }
}