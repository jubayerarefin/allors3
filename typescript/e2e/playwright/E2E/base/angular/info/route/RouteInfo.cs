// <copyright file="Model.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Autotest
{
    public class RouteInfo
    {
        public string Path { get; set; }

        public string PathMatch { get; set; }

        public string Component { get; set; }

        public string RedirectTo { get; set; }

        public RouteInfo[] Children { get; set; }
    }
}
