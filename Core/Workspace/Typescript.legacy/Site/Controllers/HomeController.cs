using Microsoft.Extensions.Configuration;

namespace Web.Controllers
{
    using Allors;
    using Allors.Domain;
    using Allors.Services;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly string autoLoginUserName;

        public HomeController(ISessionService allorsContext, ILogger<HomeController> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.autoLoginUserName = configuration["AutoLoginUserName"];
        }

        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(this.autoLoginUserName))
            {
                this.Response.Cookies.Append("autoLogin", this.autoLoginUserName);
            }
            else
            {
                this.Response.Cookies.Delete("autoLogin");
            }

            return this.View();
        }
    }
}
