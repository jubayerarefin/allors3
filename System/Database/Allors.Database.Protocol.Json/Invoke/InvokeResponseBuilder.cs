// <copyright file="InvokeResponseBuilder.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Protocol.Json
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Meta;
    using Allors.Protocol.Json.Api.Invoke;
    using Derivations;
    using Security;

    public class InvokeResponseBuilder
    {
        private readonly ISession session;
        private readonly Func<IDerivationResult> derive;
        private readonly IAccessControlLists accessControlLists;
        private readonly ISet<IClass> allowedClasses;

        public InvokeResponseBuilder(ISession session, Func<IDerivationResult> derive, IAccessControlLists accessControlLists, ISet<IClass> allowedClasses)
        {
            this.session = session;
            this.derive = derive;
            this.accessControlLists = accessControlLists;
            this.allowedClasses = allowedClasses;
        }

        public InvokeResponse Build(InvokeRequest invokeRequest)
        {
            var invocations = invokeRequest.Invocations;
            var isolated = invokeRequest.InvokeOptions?.Isolated ?? false;
            var continueOnError = invokeRequest.InvokeOptions?.ContinueOnError ?? false;

            var invokeResponse = new InvokeResponse();
            if (isolated)
            {
                foreach (var invocation in invocations)
                {
                    var error = this.Invoke(invocation, invokeResponse);
                    if (!error)
                    {
                        var validation = this.derive();
                        if (validation.HasErrors)
                        {
                            error = true;
                            invokeResponse.AddDerivationErrors(validation);
                        }
                    }

                    if (error)
                    {
                        this.session.Rollback();
                        if (!continueOnError)
                        {
                            break;
                        }
                    }
                    else
                    {
                        this.session.Commit();
                    }
                }
            }
            else
            {
                var error = false;
                foreach (var invocation in invocations)
                {
                    error = this.Invoke(invocation, invokeResponse);
                    if (error)
                    {
                        break;
                    }
                }

                if (error)
                {
                    this.session.Rollback();
                }
                else
                {
                    this.session.Commit();
                }
            }

            return invokeResponse;
        }

        private bool Invoke(Invocation invocation, InvokeResponse invokeResponse)
        {
            // TODO: M should be a methodTypeId instead of the methodName
            if (invocation.Method == null || invocation.Id == null || invocation.Version == null)
            {
                throw new ArgumentException();
            }

            var obj = this.session.Instantiate(invocation.Id);
            if (obj == null)
            {
                invokeResponse.AddMissingError(invocation.Id);
                return true;
            }

            if (this.allowedClasses?.Contains(obj.Strategy.Class) != true)
            {
                invokeResponse.AddAccessError(obj);
                return true;
            }

            var composite = (IComposite)obj.Strategy.Class;

            // TODO: Cache and filter for workspace
            var methodTypes = composite.MethodTypes.Where(v => v.WorkspaceNames.Length > 0);
            var methodType = methodTypes.FirstOrDefault(x => x.Id.Equals(Guid.Parse(invocation.Method)));

            if (methodType == null)
            {
                throw new Exception("Method " + invocation.Method + " not found.");
            }

            if (!invocation.Version.Equals(obj.Strategy.ObjectVersion.ToString()))
            {
                invokeResponse.AddVersionError(obj);
                return true;
            }

            var acl = this.accessControlLists[obj];
            if (!acl.CanExecute(methodType))
            {
                invokeResponse.AddAccessError(obj);
                return true;
            }

            var method = obj.GetType().GetMethod(methodType.Name, new Type[] { });

            try
            {
                method.Invoke(obj, null);
            }
            catch (Exception e)
            {
                var innerException = e;
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                invokeResponse.ErrorMessage = innerException.Message;
                return true;
            }

            var validation = this.derive();
            if (validation.HasErrors)
            {
                invokeResponse.AddDerivationErrors(validation);
                return true;
            }

            return false;
        }
    }
}
