// <copyright file="DerivationFactory.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Workspace.Derivations.Default
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta;

    public class Engine
    {
        public IDictionary<Rule, ISet<Class>> ClassesByRule { get; }

        public IDictionary<Class, Rule[]> RulesByClass { get; }

        public Engine(MetaPopulation m, Rule[] rules)
        {
            this.ClassesByRule = new Dictionary<Rule, ISet<Class>>();

            foreach (var rule in rules)
            {
                var ruleClasses = new HashSet<Class>();
                foreach (var pattern in rule.Patterns)
                {
                    var patternClasses = pattern switch
                    {
                        AssociationPattern associationPattern => ((Composite)associationPattern.RoleType.AssociationTypeComposite).Classes,
                        RolePattern { RoleType: RoleDefault roleType } => roleType.ObjectType.IsComposite ? ((Composite)roleType.ObjectType).Classes : Array.Empty<Class>(),
                        RolePattern { RoleType: RoleInterface roleInterface } => ((Interface)roleInterface.ObjectType).Classes,
                        RolePattern { RoleType: RoleClass roleClass } => ((Class)roleClass.ObjectType).Classes,
                        _ => Array.Empty<Class>()
                    };

                    ruleClasses.UnionWith(patternClasses);
                }

                this.ClassesByRule.Add(rule, ruleClasses);
            }

            this.RulesByClass = m.Classes.ToDictionary(v => v, v => rules.Where(w => this.ClassesByRule[w].Contains(v)).ToArray());
        }
    }
}
