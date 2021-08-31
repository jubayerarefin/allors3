// <copyright file="Workspace.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Workspace.Adapters
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using Meta;
    using Ranges;

    public abstract class Workspace : IWorkspace
    {
        private readonly Dictionary<long, WorkspaceRecord> recordById;

        protected Workspace(DatabaseConnection database, IWorkspaceServices services, IRanges<long> ranges)
        {
            this.DatabaseConnection = database;
            this.Services = services;
            this.Ranges = ranges;

            this.WorkspaceClassByWorkspaceId = new Dictionary<long, IClass>();
            this.WorkspaceIdsByWorkspaceClass = new Dictionary<IClass, ISet<long>>();

            this.recordById = new Dictionary<long, WorkspaceRecord>();
        }

        public DatabaseConnection DatabaseConnection { get; }

        public IConfiguration Configuration => this.DatabaseConnection.Configuration;

        public IWorkspaceServices Services { get; }

        public IRanges<long> Ranges { get; }

        public Dictionary<long, IClass> WorkspaceClassByWorkspaceId { get; }

        public Dictionary<IClass, ISet<long>> WorkspaceIdsByWorkspaceClass { get; }

        public abstract ISession CreateSession();

        public WorkspaceRecord GetRecord(long id)
        {
            this.recordById.TryGetValue(id, out var workspaceObject);
            return workspaceObject;
        }

        public void Push(long id, IClass @class, long version, Dictionary<IRelationType, object> changedRoleByRoleType)
        {
            this.WorkspaceClassByWorkspaceId[id] = @class;
            if (!this.WorkspaceIdsByWorkspaceClass.TryGetValue(@class, out var ids))
            {
                ids = new HashSet<long>();
                this.WorkspaceIdsByWorkspaceClass.Add(@class, ids);
            }

            ids.Add(id);

            var roleByRelationType = changedRoleByRoleType?.ToDictionary(v => v.Key,
                v => v.Value switch
                {
                    Strategy strategy => strategy.Id,
                    ISet<Strategy> strategies => this.Ranges.Load(strategies.Select(v => v.Id)),
                    _ => v.Value,
                });

            if (!this.recordById.TryGetValue(id, out var originalWorkspaceRecord))
            {
                this.recordById[id] = new WorkspaceRecord(@class, id, ++version, roleByRelationType);
            }
            else
            {
                this.recordById[id] = new WorkspaceRecord(originalWorkspaceRecord, roleByRelationType);
            }
        }
    }
}
