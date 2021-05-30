// <copyright file="Startup.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Server
{
    using System.Collections.Generic;
    using System.Text;
    using Database.Domain;
    using Services;
    using Security;
    using JSNLog;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;
    using ObjectFactory = Database.ObjectFactory;
    using Database.Adapters;
    using Database.Configuration;
    using Database.Domain.Derivations.Rules.Default;
    using Database.Meta;
    using User = Database.Domain.User;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddSingleton(this.Configuration);

            var workspaceConfig = new WorkspaceConfig(new Dictionary<HostString, string>
            {
                {new HostString("localhost", 5000), "Default"}
            });

            // Allors
            _ = services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            _ = services.AddSingleton<IPolicyService, PolicyService>();
            _ = services.AddSingleton<IDatabaseService, DatabaseService>();
            _ = services.AddSingleton(workspaceConfig);
            // Allors Scoped
            _ = services.AddScoped<ITransactionService, TransactionService>();
            _ = services.AddScoped<IWorkspaceService, WorkspaceService>();

            _ = services.AddCors(options =>
                  options.AddDefaultPolicy(
                      builder => builder
                          .WithOrigins("http://localhost", "http://localhost:4000", "http://localhost:4200", "http://localhost:9876")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials()));

            _ = services.AddDefaultIdentity<IdentityUser>()
                .AddAllorsStores();

            _ = services.AddAuthentication(option => option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.Configuration.GetSection("JwtToken:Key").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    });

            _ = services.AddResponseCaching();
            _ = services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor httpContextAccessor, ILoggerFactory loggerFactory)
        {
            // Allors
            var metaPopulation = new MetaBuilder().Build();
            var engine = new Engine(Rules.Create(metaPopulation));
            var objectFactory = new ObjectFactory(metaPopulation, typeof(User));
            var databaseScope = new DefaultDomainDatabaseServices(engine, httpContextAccessor);
            var databaseBuilder = new DatabaseBuilder(databaseScope, this.Configuration, objectFactory);
            app.ApplicationServices.GetRequiredService<IDatabaseService>().Database = databaseBuilder.Build();

            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }
            else
            {
                _ = app.UseHsts();
            }

            _ = app.UseCors();

            var jsnlogConfiguration = new JsnlogConfiguration
            {
                corsAllowedOriginsRegex = ".*",
                serverSideMessageFormat = env.IsDevelopment() ?
                                            "%requestId | %url | %message" :
                                            "%requestId | %url | %userHostAddress | %userAgent | %message",
            };

            app.UseJSNLog(new LoggingAdapter(loggerFactory), jsnlogConfiguration);

            // app.UseHttpsRedirection();
            _ = app.UseRouting();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();

            _ = app.ConfigureExceptionHandler(env, loggerFactory);

            _ = app.UseResponseCaching();
            _ = app.UseEndpoints(endpoints =>
              {
                  _ = endpoints.MapControllerRoute(
                      name: "default",
                      pattern: "allors/{controller=Home}/{action=Index}/{id?}");
                  _ = endpoints.MapControllers();
              });
        }
    }
}