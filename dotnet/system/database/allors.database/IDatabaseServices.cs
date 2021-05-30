// <copyright file="IDatabaseServices.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database
{
    using System;
    using Data;

    /// <summary>
    /// The Database state's lifecycle.
    /// </summary>
    public interface IDatabaseServices : IDisposable
    {
        void OnInit(IDatabase database);

        ITransactionServices CreateTransactionServices();

        IPreparedExtents PreparedExtents { get; }

        IPreparedSelects PreparedSelects { get; }
    }
}