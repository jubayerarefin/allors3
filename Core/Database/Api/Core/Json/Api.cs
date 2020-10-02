// <copyright file="PullExtent.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// <summary>Defines the ISessionExtension type.</summary>

namespace Allors.Api.Json
{
    using Domain;
    using Invoke;
    using Protocol.Data;
    using Protocol.Remote.Invoke;
    using Protocol.Remote.Pull;
    using Protocol.Remote.Push;
    using Protocol.Remote.Security;
    using Protocol.Remote.Sync;
    using Pull;
    using Push;
    using Security;
    using Sync;

    public class Api
    {
        public Api(ISession session, string workspaceName)
        {
            this.Session = session;
            this.WorkspaceName = workspaceName;
            this.DatabaseState = session.Database.State();
        }

        public ISession Session { get; }

        public string WorkspaceName { get; }

        public IDatabaseState DatabaseState { get; set; }

        public PullResponse Pull(PullRequest request)
        {
            var response = new PullResponseBuilder(this.Session, this.WorkspaceName);

            if (request.P != null)
            {
                foreach (var p in request.P)
                {
                    var pull = p.Load(this.Session);

                    if (pull.Object != null)
                    {
                        var pullInstantiate = new PullInstantiate(this.Session, pull, response.AccessControlLists);
                        pullInstantiate.Execute(response);
                    }
                    else
                    {
                        var pullExtent = new PullExtent(this.Session, pull, response.AccessControlLists);
                        pullExtent.Execute(response);
                    }
                }
            }

            return response.Build();
        }

        public PushResponse Push(PushRequest pushRequest)
        {
            var user = this.Session.State().User;
            var acls = new WorkspaceAccessControlLists(this.WorkspaceName, user);
            var responseBuilder = new PushResponseBuilder(this.Session, pushRequest, acls);
            return responseBuilder.Build();
        }

        public SyncResponse Sync(SyncRequest syncRequest)
        {
            var acls = new WorkspaceAccessControlLists(this.WorkspaceName, this.Session.State().User);
            var responseBuilder = new SyncResponseBuilder(this.Session, syncRequest, acls);
            return responseBuilder.Build();
        }

        public InvokeResponse Invoke(InvokeRequest invokeRequest)
        {
            var acls = new WorkspaceAccessControlLists(this.WorkspaceName, this.Session.State().User);
            var responseBuilder = new InvokeResponseBuilder(this.Session, invokeRequest, acls);
            return responseBuilder.Build();
        }

        public SecurityResponse Security(SecurityRequest securityRequest)
        {
            var acls = new WorkspaceAccessControlLists(this.WorkspaceName, this.Session.State().User);
            var responseBuilder = new SecurityResponseBuilder(acls, this.Session, securityRequest);
            var response = responseBuilder.Build();
            return response;
        }
    }
}
