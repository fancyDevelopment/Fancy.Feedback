﻿using Fancy.Feedback.Core.Subdomains.Feedbacks.Domain.ValueObjects;
using Fancy.Feedback.Core.Subdomains.Identity.Domain;
using Fancy.Feedback.Core.Subdomains.Sessions.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Fancy.Feedback.Core.Infrastructure
{
    public class DomainDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public DbSet<Event> Events { get; set; }

        /// <summary>
        /// Gets or sets the sessions.
        /// </summary>
        /// <value>
        /// The sessions.
        /// </value>
        public DbSet<Session> Sessions { get; set; }

        /// <summary>
        /// Gets or sets the feedbacks.
        /// </summary>
        /// <value>
        /// The feedbacks.
        /// </value>
        public DbSet<Subdomains.Feedbacks.Domain.Feedback> Feedbacks { get; set; }

        /// <summary>
        /// Called when configuring the model.
        /// </summary>
        /// <param name="optionsBuilder">The options builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=.;Database=aspnet5-WebApplication1;Trusted_Connection=True");
        }

        /// <summary>
        /// Called when the model is creating.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Session>().HasMany<Subdomains.Feedbacks.Domain.Feedback>();

            builder.Entity<Subdomains.Feedbacks.Domain.Feedback>().HasOne<Rating>();
        }
    }
}