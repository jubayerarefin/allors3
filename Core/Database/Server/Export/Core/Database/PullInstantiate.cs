//-------------------------------------------------------------------------------------------------
// <copyright file="PullInstantiate.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the ISessionExtension type.</summary>
//-------------------------------------------------------------------------------------------------

namespace Allors.Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Allors.Data;
    using Allors.Domain;
    using Allors.Meta;
    using Allors.Services;

    public class PullInstantiate
    {
        private readonly ISession session;

        private readonly Pull pull;

        private readonly User user;

        private readonly IFetchService fetchService;

        public PullInstantiate(ISession session, Pull pull, User user, IFetchService fetchService)
        {
            this.session = session;
            this.pull = pull;
            this.user = user;
            this.fetchService = fetchService;
        }

        public void Execute(PullResponseBuilder response)
        {
            var @object = this.session.Instantiate(this.pull.Object);

            var objectType = this.pull.ObjectType as IComposite;
            var @class = @object.Strategy?.Class;

            if (@class != null && objectType != null)
            {
                if (!objectType.IsAssignableFrom(@class))
                {
                    return;
                }
            }

            if (this.pull.Results != null)
            {
                foreach (var result in this.pull.Results)
                {
                    try
                    {
                        var name = result.Name;

                        var fetch = result.Fetch;
                        if ((fetch == null) && result.FetchRef.HasValue)
                        {
                            fetch = this.fetchService.Get(result.FetchRef.Value);
                        }

                        if (fetch != null)
                        {
                            var include = fetch.Include ?? fetch.Step?.End.Include;

                            if (fetch.Step != null)
                            {
                                var aclCache = new AccessControlListFactory(this.user);

                                var propertyType = fetch.Step.End.PropertyType;

                                if (fetch.Step.IsOne)
                                {
                                    name = name ?? propertyType.SingularName;

                                    @object = (IObject)fetch.Step.Get(@object, aclCache);
                                    response.AddObject(name, @object, include);
                                }
                                else
                                {
                                    name = name ?? propertyType.PluralName;

                                    var stepResult = fetch.Step.Get(@object, aclCache);
                                    var objects = stepResult is HashSet<object> set ? set.Cast<IObject>().ToArray() : ((Extent)stepResult)?.ToArray() ?? new IObject[0];

                                    if (result.Skip.HasValue || result.Take.HasValue)
                                    {
                                        var paged = result.Skip.HasValue ? objects.Skip(result.Skip.Value) : objects;
                                        if (result.Take.HasValue)
                                        {
                                            paged = paged.Take(result.Take.Value);
                                        }

                                        paged = paged.ToArray();

                                        response.AddValue(name + "_total", objects.Length);
                                        response.AddCollection(name, paged, include);
                                    }
                                    else
                                    {
                                        response.AddCollection(name, objects, include);
                                    }
                                }
                            }
                            else
                            {
                                name = name ?? this.pull.ObjectType?.Name ?? @object.Strategy.Class.SingularName;
                                response.AddObject(name, @object, include);
                            }
                        }
                        else
                        {
                            name = name ?? this.pull.ObjectType?.Name ?? @object.Strategy.Class.SingularName;
                            response.AddObject(name, @object);
                        }
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Instantiate: {@object?.Strategy.Class}[{@object?.Strategy.ObjectId}], {result}", e);
                    }
                }
            }
            else
            {
                var name = this.pull.ObjectType?.Name ?? @object.Strategy.Class.SingularName;
                response.AddObject(name, @object);
            }
        }
    }
}
