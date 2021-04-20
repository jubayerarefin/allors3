// <copyright file="Not.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Data
{
    using System.Collections.Generic;

    public class Not : ICompositePredicate
    {
        public string[] Dependencies { get; set; }

        public Not(IPredicate operand = null) => this.Operand = operand;

        public IPredicate Operand { get; set; }

        bool IPredicate.ShouldTreeShake(IDictionary<string, string> parameters) => this.HasMissingDependencies(parameters) || this.Operand == null || this.Operand.ShouldTreeShake(parameters);

        bool IPredicate.HasMissingArguments(IDictionary<string, string> parameters) => this.Operand != null && this.Operand.HasMissingArguments(parameters);

        void IPredicateContainer.AddPredicate(IPredicate predicate) => this.Operand = predicate;

        void IPredicate.Build(ITransaction transaction, IDictionary<string, string> parameters, Database.ICompositePredicate compositePredicate)
        {
            var not = compositePredicate.AddNot();

            if (this.Operand != null && !this.Operand.ShouldTreeShake(parameters))
            {
                this.Operand?.Build(transaction, parameters, not);
            }
        }

        public void Accept(IVisitor visitor) => visitor.VisitNot(this);
    }
}
