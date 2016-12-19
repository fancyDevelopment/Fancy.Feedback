using System;
using System.Collections.Generic;
using AutoMapper;
using Fancy.Feedback.Core;
using Fancy.Feedback.Core.Infrastructure;
using Fancy.Feedback.Core.Subdomains.Identity.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Fancy.Feedback.WebApp.Services;
using Fancy.SchemaFormBuilder;
using System.Linq;
using System.Reflection;
using Fancy.ResourceLinker;
using Microsoft.EntityFrameworkCore;
using Fancy.Feedback.WebApp.MappingProfiles;
using Fancy.Feedback.Core.Subdomains.Sessions.MappingProfiles;

namespace Fancy.Feedback.WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultSchemaFormBuilder();
            services.AddResourceLinker();

            services.AddFancyFeedbackCore(Configuration["Data:DefaultConnection:ConnectionString"]);

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DomainDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            // Find all auto mapper profiles and register them
            List<Type> coreProfiles = typeof(EditEventDtoMappingProfile).GetTypeInfo().Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x)).ToList();
            IEnumerable<Type> profiles = typeof(Startup).GetTypeInfo().Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));

            coreProfiles.AddRange(profiles);
            Mapper.Initialize(cfg => cfg.AddProfiles(coreProfiles));

            // Find all link strategies and register them
            IEnumerable<Type> linkStrategies = typeof(Startup).GetTypeInfo().Assembly.GetTypes().Where(x => typeof(ILinkStrategy).IsAssignableFrom(x));

            foreach (Type linkStrategy in linkStrategies)
            {
                services.AddTransient(typeof (ILinkStrategy), linkStrategy);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            ILogger startupLogger = loggerFactory.CreateLogger("Startup");

            // Ensure database is created and migrated
            startupLogger.LogInformation("Migrating database...");
            DomainDbContext dbContext = serviceProvider.GetService<DomainDbContext>();
            dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                    {
                        serviceScope.ServiceProvider.GetService<DomainDbContext>()
                             .Database.Migrate();
                    }
                }
                catch { }
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
