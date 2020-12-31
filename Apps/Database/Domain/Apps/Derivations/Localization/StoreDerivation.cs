// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Derivations;
    using Meta;
    using Database.Derivations;

    public class StoreDerivation : DomainDerivation
    {
        public StoreDerivation(M m) : base(m, new Guid("cf3acae4-a895-4a0b-b154-18cfa30691bb")) =>
            this.Patterns = new Pattern[]
            {
                new ChangedPattern(m.Store.InternalOrganisation),
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            var validation = cycle.Validation;

            foreach (var @this in matches.Cast<Store>())
            {
                var internalOrganisations = new Organisations(@this.Strategy.Session).Extent().Where(v => Equals(v.IsInternalOrganisation, true)).ToArray();

                if (!@this.ExistInternalOrganisation && internalOrganisations.Length == 1)
                {
                    @this.InternalOrganisation = internalOrganisations.First();
                }

                if (@this.ExistDefaultCollectionMethod && !@this.CollectionMethods.Contains(@this.DefaultCollectionMethod))
                {
                    @this.AddCollectionMethod(@this.DefaultCollectionMethod);
                }

                if (!@this.ExistDefaultCollectionMethod && @this.CollectionMethods.Count == 1)
                {
                    @this.DefaultCollectionMethod = @this.CollectionMethods.First;
                }

                if (!@this.ExistDefaultCollectionMethod && @this.InternalOrganisation.ExistDefaultCollectionMethod)
                {
                    @this.DefaultCollectionMethod = @this.InternalOrganisation.DefaultCollectionMethod;

                    if (!@this.ExistCollectionMethods || !@this.CollectionMethods.Contains(@this.DefaultCollectionMethod))
                    {
                        @this.AddCollectionMethod(@this.DefaultCollectionMethod);
                    }
                }

                if (!@this.ExistDefaultFacility)
                {
                    @this.DefaultFacility = @this.Strategy.Session.GetSingleton().Settings.DefaultFacility;
                }

                if (@this.InternalOrganisation.InvoiceSequence != new InvoiceSequences(@this.Strategy.Session).RestartOnFiscalYear)
                {
                    if (!@this.ExistSalesInvoiceNumberCounter)
                    {
                        @this.SalesInvoiceNumberCounter = new CounterBuilder(@this.Strategy.Session).Build();
                    }

                    if (!@this.ExistSalesOrderNumberCounter)
                    {
                        @this.SalesOrderNumberCounter = new CounterBuilder(@this.Strategy.Session).Build();
                    }

                    if (!@this.ExistOutgoingShipmentNumberCounter)
                    {
                        @this.OutgoingShipmentNumberCounter = new CounterBuilder(@this.Strategy.Session).Build();
                    }

                    if (!@this.ExistCreditNoteNumberCounter)
                    {
                        @this.CreditNoteNumberCounter = new CounterBuilder(@this.Strategy.Session).Build();
                    }
                }

                validation.AssertExistsAtMostOne(@this, @this.M.Store.FiscalYearsStoreSequenceNumbers, @this.M.Store.SalesInvoiceNumberCounter);
            }
        }
    }
}
