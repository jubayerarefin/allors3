// <copyright file="PullExtent.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the ISessionExtension type.</summary>

namespace Allors.Database.Protocol.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Security;
    using Extent = Extent;

    public class PullExtent
    {
        private readonly ISession session;
        private readonly Pull pull;
        private readonly IAccessControlLists acls;
        private readonly IPreparedExtents preparedExtents;
        private readonly IPreparedFetches preparedFetches;

        public PullExtent(ISession session, Pull pull, IAccessControlLists acls, IPreparedFetches preparedFetches,
            IPreparedExtents preparedExtents)
        {
            this.session = session;
            this.pull = pull;
            this.acls = acls;
            this.preparedExtents = preparedExtents;
            this.preparedFetches = preparedFetches;
        }


        public void Execute(PullResponseBuilder response)
        {
            if (this.pull.Extent == null && !this.pull.ExtentRef.HasValue)
            {
                throw new Exception("Either an Extent or an ExtentRef is required.");
            }

            var extent = this.pull.Extent ?? this.preparedExtents.Get(this.pull.ExtentRef.Value);
            var objects = extent.Build(this.session, this.pull.Parameters).ToArray();

            if (this.pull.Results != null)
            {
                foreach (var result in this.pull.Results)
                {
                    try
                    {
                        var name = result.Name;

                        var fetch = result.Fetch;
                        if (fetch == null && result.FetchRef.HasValue)
                        {
                            fetch = this.preparedFetches.Get(result.FetchRef.Value);
                        }

                        if (fetch != null)
                        {
                            var include = fetch.Include ?? fetch.Step?.End.Include;

                            if (fetch.Step != null)
                            {
                                objects = fetch.Step.IsOne ?
                                              objects.Select(v => fetch.Step.Get(v, this.acls)).Where(v => v != null).Cast<IObject>().Distinct().ToArray() :
                                              objects.SelectMany(v =>
                                              {
                                                  var stepResult = fetch.Step.Get(v, this.acls);
                                                  return stepResult is HashSet<object> set ? set.Cast<IObject>().ToArray() : ((Extent)stepResult)?.ToArray() ?? Array.Empty<IObject>();
                                              }).Distinct().ToArray();

                                var propertyType = fetch.Step.End.PropertyType;
                                name ??= propertyType.PluralName;
                            }

                            name ??= extent.ObjectType.PluralName;

                            if (result.Skip.HasValue || result.Take.HasValue)
                            {
                                var paged = result.Skip.HasValue ? objects.Skip(result.Skip.Value) : objects;
                                if (result.Take.HasValue)
                                {
                                    paged = paged.Take(result.Take.Value);
                                }

                                paged = paged.ToArray();

                                response.AddValue(name + "_total", extent.Build(this.session, this.pull.Parameters).Count.ToString());
                                response.AddCollection(name, paged, include);
                            }
                            else
                            {
                                response.AddCollection(name, objects, include);
                            }
                        }
                        else
                        {
                            name ??= extent.ObjectType.PluralName;
                            response.AddCollection(name, objects);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Extent: {extent.ObjectType}, {result}", e);
                    }
                }
            }
            else
            {
                var name = extent.ObjectType.PluralName;
                response.AddCollection(name, objects);
            }
        }
    }
}
