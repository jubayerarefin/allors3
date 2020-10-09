// <copyright file="Domain.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the Domain type.</summary>

namespace Allors.Workspace.Meta
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed partial class Domain : MetaObjectBase, IDomain
    {
        private IList<Domain> directSuperdomains;
        private IList<Domain> derivedSuperdomains;

        private string name;

        internal Domain(MetaPopulation metaPopulation, Guid id)
            : base(metaPopulation)
        {
            this.Id = id;
            this.IdAsString = this.Id.ToString("D");

            this.directSuperdomains = new List<Domain>();

            this.MetaPopulation.OnDomainCreated(this);
        }

        public Guid Id { get; }

        public string IdAsString { get; }

        public string Name
        {
            get => this.name;

            set
            {
                this.MetaPopulation.AssertUnlocked();
                this.name = value;
                this.MetaPopulation.Stale();
            }
        }

        public IEnumerable<Domain> DirectSuperdomains => this.directSuperdomains;

        public IEnumerable<Domain> Superdomains
        {
            get
            {
                this.MetaPopulation.Derive();
                return this.derivedSuperdomains;
            }
        }

        public override Origin Origin => Origin.Database;

        /// <summary>
        /// Gets the validation name.
        /// </summary>
        public override string ValidationName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Name))
                {
                    return "domain " + this.Name;
                }

                return "unknown domain";
            }
        }

        public void AddDirectSuperdomain(Domain superdomain)
        {
            if (superdomain.Equals(this) || superdomain.Superdomains.Contains(this))
            {
                throw new Exception("Cycle in domain inheritance");
            }

            this.directSuperdomains.Add(superdomain);
            this.MetaPopulation.Stale();
        }

        public override bool Equals(object other) => this.Id.Equals((other as Domain)?.Id);

        public override int GetHashCode() => this.Id.GetHashCode();

        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="obj"/>. Zero This instance is equal to <paramref name="obj"/>. Greater than zero This instance is greater than <paramref name="obj"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="other"/> is not the same type as this instance. </exception>
        public int CompareTo(object other) => this.Id.CompareTo((other as Domain)?.Id);

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                return this.Name;
            }

            return this.IdAsString;
        }

        internal void Bind() => this.directSuperdomains = this.directSuperdomains.ToArray();

        internal void DeriveSuperdomains(HashSet<Domain> sharedDomains)
        {
            sharedDomains.Clear();
            foreach (var directSuperdomain in this.DirectSuperdomains)
            {
                directSuperdomain.DeriveSuperdomains(this, sharedDomains);
            }

            this.derivedSuperdomains = sharedDomains.ToArray();
        }

        /// <summary>
        /// Validates the domain.
        /// </summary>
        /// <param name="validationLog">The validation.</param>
        internal void Validate(ValidationLog validationLog)
        {
            this.ValidateIdentity(validationLog);

            if (string.IsNullOrEmpty(this.Name))
            {
                validationLog.AddError("domain has no name", this, ValidationKind.Required, "Domain.Name");
            }
            else
            {
                if (!char.IsLetter(this.Name[0]))
                {
                    var message = this.ValidationName + " should start with an alfabetical character";
                    validationLog.AddError(message, this, ValidationKind.Format, "Domain.Name");
                }

                for (var i = 1; i < this.Name.Length; i++)
                {
                    if (!char.IsLetter(this.Name[i]) && !char.IsDigit(this.Name[i]))
                    {
                        var message = this.ValidationName + " should only contain alfanumerical characters)";
                        validationLog.AddError(message, this, ValidationKind.Format, "Domain.Name");
                        break;
                    }
                }
            }

            if (this.Id == Guid.Empty)
            {
                validationLog.AddError(this.ValidationName + " has no id", this, ValidationKind.Required, "IMetaObject.Id");
            }
        }

        private void DeriveSuperdomains(Domain subdomain, HashSet<Domain> superdomains)
        {
            if (this.Equals(subdomain))
            {
                // We have a cycle
                return;
            }

            superdomains.Add(this);

            foreach (var directSuperdomain in this.DirectSuperdomains)
            {
                if (!superdomains.Contains(directSuperdomain))
                {
                    directSuperdomain.DeriveSuperdomains(subdomain, superdomains);
                }
            }
        }
    }
}
