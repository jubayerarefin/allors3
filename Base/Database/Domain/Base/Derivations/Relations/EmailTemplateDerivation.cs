// <copyright file="EmailTemplateDerivation.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Meta;

    public class EmailTemplateDerivation : DomainDerivation
    {
        public EmailTemplateDerivation(M m) : base(m, new Guid("334F4D84-D343-4FD7-9F74-2FF0617DE747")) =>
            this.Patterns = new Pattern[]
            {
                new CreatedPattern(this.M.EmailTemplate.Class),
            };

        public override void Derive(IDomainDerivationCycle cycle, IEnumerable<IObject> matches)
        {
            foreach (EmailTemplate emailTemplate in matches.Cast<EmailTemplate>())
            {
                if (!emailTemplate.ExistDescription)
                {
                    emailTemplate.Description = "Default";
                }
            }
        }
    }
}
