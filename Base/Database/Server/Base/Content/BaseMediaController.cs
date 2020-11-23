// <copyright file="BaseMediaController.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Server.Controllers
{
    using System;
    using System.Linq;
    using Allors;
    using Domain;
    using Services;
    using Database;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;
    using Microsoft.Net.Http.Headers;

    public abstract partial class BaseMediaController : Controller
    {
        protected const int OneYearInSeconds = 60 * 60 * 24 * 356;

        protected BaseMediaController(ISessionService sessionService) => this.Session = sessionService.Session;

        protected ISession Session { get; }

        [Authorize]
        [AllowAnonymous]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("/print/{idString}/{*name}")]
        public virtual ActionResult Print(string idString, string name)
        {
            if (this.Session.Instantiate(idString) is Printable printable)
            {
                if (printable.PrintDocument?.ExistMedia == false)
                {
                    printable.Print();
                    this.Session.Derive();
                    this.Session.Commit();
                }

                var media = printable.PrintDocument?.Media;

                if (media == null)
                {
                    return this.NoContent();
                }


                return this.RedirectToAction(nameof(this.Get), new { idString = media.UniqueId.ToString("N"), revisionString = media.Revision?.ToString("N"), name });
            }

            return this.NotFound("Printable with id " + idString + " not found.");
        }

        [Authorize]
        [AllowAnonymous]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("/media/{idString}/{*name}")]
        public virtual IActionResult RedirectOrNotFound(string idString, string name)
        {
            var m = ((IDatabaseContext) this.Session.Database.Context()).M;

            if (Guid.TryParse(idString, out var id))
            {
                var media = new Medias(this.Session).FindBy(m.Media.UniqueId, id);
                if (media != null)
                {
                    return this.RedirectToAction(nameof(this.Get), new { idString = media.UniqueId.ToString("N"), revisionString = media.Revision?.ToString("N") });
                }
            }

            return this.NotFound("Media with id " + id + " not found.");
        }

        [Authorize]
        [AllowAnonymous]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = OneYearInSeconds)]
        [HttpGet("/media/{idString}/{revisionString}/{*name}")]
        public virtual IActionResult Get(string idString, string revisionString, string name)
        {
            var m = ((IDatabaseContext) this.Session.Database.Context()).M;

            if (Guid.TryParse(idString, out var id))
            {
                var media = new Medias(this.Session).FindBy(m.Media.UniqueId, id);
                if (media != null)
                {
                    if (media.MediaContent?.Data == null)
                    {
                        return this.NoContent();
                    }

                    if (Guid.TryParse(revisionString, out var revision))
                    {
                        if (media.Revision != revision)
                        {
                            return this.RedirectToAction(nameof(this.RedirectOrNotFound), new { idString, name });
                        }
                    }
                    else
                    {
                        return this.RedirectToAction(nameof(this.RedirectOrNotFound), new { idString, name });
                    }

                    // Use Etags
                    this.Request.Headers.TryGetValue(HeaderNames.IfNoneMatch, out var requestEtagValues);
                    if (requestEtagValues != StringValues.Empty)
                    {
                        var etagValueString = requestEtagValues.FirstOrDefault()?.Replace("\"", string.Empty);
                        if (Guid.TryParse(etagValueString, out var etagValue))
                        {
                            if (media.Revision.Equals(etagValue))
                            {
                                this.Response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status304NotModified;
                                this.Response.ContentLength = 0L;
                                return this.Content(string.Empty);
                            }
                        }
                    }

                    this.Response.Headers[HeaderNames.ETag] = $"\"{media.Revision}\"";


                    var data = media.MediaContent.Data;
                    return this.File(data, media.MediaContent.Type, name ?? media.FileName);
                }
            }

            return this.NotFound("Media with id " + id + " not found.");
        }
    }
}
