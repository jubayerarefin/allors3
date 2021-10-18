// <copyright file="Project.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Autotest.Angular
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Project
    {
        public Dictionary<string, Directive> DirectiveById { get; set; }

        public Directive[] Directives { get; set; }

        public Module[] LocalModules { get; set; }

        public Directive[] LocalRoutedComponents { get; set; }

        public Directive[] LocalEntryComponents { get; set; }

        public Directive[] LocalScopedDirectives { get; set; }

        public Directive[] LocalNonRoutedScopedComponents { get; set; }

        public Directive[] LocalNonRoutedScopedComponentsWithoutSelector { get; set; }

        public Directive[] LocalNonRoutedScopedComponentsWithSelector { get; set; }

        public Module MainModule { get; set; }

        public Model Model { get; set; }

        public Dictionary<string, Module> ModuleById { get; set; }

        public Module[] Modules { get; set; }

        public Dictionary<string, Pipe> PipeById { get; set; }

        public Pipe[] Pipes { get; set; }

        public Provider[] Providers { get; set; }

        public Route FindRouteForFullPath(string fullPath) => this.MainModule.FlattenedRoutes.FirstOrDefault(v => v.FullPaths.Contains(fullPath));

        private void BaseLoad(JObject jsonProject)
        {
            var jsonModules = jsonProject["modules"];
            this.Modules = jsonModules != null ? jsonModules.Select(v => new Module
            {
                Json = v,
                Project = this,
                Reference = new Reference(v),
            }).ToArray() : Array.Empty<Module>();

            var jsonPipes = jsonProject["pipes"];
            this.Pipes = jsonPipes != null ? jsonPipes.Select(v => new Pipe
            {
                Json = v,
                Project = this,
                Reference = new Reference(v),
            }).ToArray() : Array.Empty<Pipe>();

            var jsonDirectives = jsonProject["directives"];
            this.Directives = jsonDirectives != null ? jsonDirectives.Select(v => new Directive
            {
                Json = v,
                Project = this,
                Reference = new Reference(v),
            }).ToArray() : Array.Empty<Directive>();

            var jsonProviders = jsonProject["providers"];
            this.Providers = jsonProviders != null ? jsonProviders.Select(v => new Provider
            {
                Json = v,
                Project = this,
            }).ToArray() : Array.Empty<Provider>();

            this.ModuleById = this.Modules.ToDictionary(v => v.Reference.Id);
            this.PipeById = this.Pipes.ToDictionary(v => v.Reference.Id);
            this.DirectiveById = this.Directives.ToDictionary(v => v.Reference.Id);

            foreach (var module in this.Modules)
            {
                module.BaseLoad();
            }

            foreach (var pipe in this.Pipes)
            {
                pipe.BaseLoad();
            }

            foreach (var directive in this.Directives)
            {
                directive.BaseLoad();
            }

            foreach (var directive in this.Directives)
            {
                directive.BaseLoadTemplate();
            }

            foreach (var provider in this.Providers)
            {
                provider.BaseLoad();
            }

            this.MainModule = this.Modules.First(v => v.BootstrapComponents.Length > 0);

            this.LocalModules = this.Modules.Where(v => v.Reference.IsLocal).ToArray();

            this.LocalRoutedComponents = this.Modules.SelectMany(v => v.RoutedComponents).Distinct().Where(v => v.Reference.IsLocal).ToArray();

            this.LocalEntryComponents = this.Modules.SelectMany(v => v.EntryComponents).Distinct().Where(v => v.Reference.IsLocal).ToArray();

            this.LocalScopedDirectives = this.Directives.Where(v => v.Scope != null && v.Reference.IsLocal).ToArray();

            this.LocalNonRoutedScopedComponents = this.LocalScopedDirectives.Except(this.LocalRoutedComponents).ToArray();

            this.LocalNonRoutedScopedComponentsWithSelector = this.LocalNonRoutedScopedComponents.Where(v => !string.IsNullOrEmpty(v.Selector)).ToArray();

            this.LocalNonRoutedScopedComponentsWithoutSelector = this.LocalNonRoutedScopedComponents.Where(v => string.IsNullOrEmpty(v.Selector)).ToArray();
        }
    }
}
