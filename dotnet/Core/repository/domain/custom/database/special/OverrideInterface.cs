// <copyright file="UnitSample.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Repository
{
    using Attributes;
    using static Workspaces;

    #region Allors
    [Id("45B34E4F-38DE-4E73-BF09-B53572CEF609")]
    #endregion
    public partial interface OverrideInterface : Object
    {
        #region Allors
        [Id("7167203C-1CD9-48BF-98A8-AAA80506E3B8")]
        [Size(256)]
        [Workspace(Default)]
        #endregion
        string OverrideRequiredAndUnique { get; set; }

        #region Allors
        [Id("6CB2E5CC-1EF8-47DA-A1C3-40423F2DAC68")]
        [Size(256)]
        [Workspace(Default)]
        #endregion
        public string OverrideRequired { get; set; }

        #region Allors
        [Id("D4D81CCE-EDC9-4D8F-BB81-9F79007F0F71")]
        [Size(256)]
        [Workspace(Default)]
        #endregion
        public string OverrideUnique { get; set; }
    }
}
