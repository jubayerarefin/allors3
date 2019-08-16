// -------------------------------------------------------------------------------------------------
// <copyright file="Generate.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Allors.Development.Repository.Tasks
{
    using System.IO;

    using Allors.Development.Repository.Generation;
    using Allors.Workspace.Meta;

    using Autotest;

    public static class Generate
    {
        public static Log Execute(string template, string output, Model model)
        {
            var log = new GenerateLog();

            var templateFileInfo = new FileInfo(template);
            var stringTemplate = new StringTemplate(templateFileInfo);
            var outputDirectoryInfo = new DirectoryInfo(output);

            stringTemplate.Generate(model, outputDirectoryInfo, log);

            return log;
        }
    }
}
