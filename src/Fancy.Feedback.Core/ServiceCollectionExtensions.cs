using System;
using System.Collections.Generic;
using AutoMapper;
using Fancy.Feedback.Core.Infrastructure;
using Fancy.Feedback.Core.Subdomains.Sessions.ApiServices;
using Fancy.Feedback.Core.Subdomains.Sessions.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using Microsoft.Data.Entity;

namespace Fancy.Feedback.Core
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Convenience method to register the fancy feedback core to the IOC container.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddFancyFeedbackCore(this IServiceCollection serviceCollection, string dbConnectionString)
        {
            serviceCollection.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DomainDbContext>(options => options.UseSqlServer(dbConnectionString));

            // Register sessions subdomain
            serviceCollection.AddTransient<ISessionsContext>(sp => sp.GetService<DomainDbContext>());

            serviceCollection.AddTransient<IEventsService, EventsService>();
            serviceCollection.AddTransient<ISessionService, SessionService>();

            // Find all auto mapper profiles and register them
            IEnumerable<Type> profiles = typeof(ServiceCollectionExtensions).GetTypeInfo().Assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));

            foreach (Type profile in profiles)
            {
                Mapper.AddProfile(Activator.CreateInstance(profile) as Profile);
            }

            return serviceCollection;
        }
    }
}