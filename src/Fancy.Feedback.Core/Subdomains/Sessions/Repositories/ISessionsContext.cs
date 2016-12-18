using Fancy.Feedback.Core.Infrastructure;
using Fancy.Feedback.Core.Subdomains.Sessions.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fancy.Feedback.Core.Subdomains.Sessions.Repositories
{
    public interface ISessionsContext : IDataContext
    {
        DbSet<Event> Events { get; } 

        DbSet<Session> Sessions { get; } 
    }
}