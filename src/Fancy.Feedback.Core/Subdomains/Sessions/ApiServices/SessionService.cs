using AutoMapper;

using Fancy.Feedback.Core.Subdomains.Sessions.Domain;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;
using Fancy.Feedback.Core.Subdomains.Sessions.Repositories;
using System.Linq;

namespace Fancy.Feedback.Core.Subdomains.Sessions.ApiServices
{
    /// <summary>
    /// Implements the <see cref="ISessionService"/> interface.
    /// </summary>
    public class SessionService : ISessionService
    {
        /// <summary>
        /// The sessions context.
        /// </summary>
        private readonly ISessionsContext _sessionsContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionService"/> class.
        /// </summary>
        /// <param name="sessionsContext">The sessions context.</param>
        public SessionService(ISessionsContext sessionsContext)
        {
            _sessionsContext = sessionsContext;
        }

        /// <summary>
        /// Gets a session by its identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A session.</returns>
        public SessionDto GetById(long id)
        {
            Session session = _sessionsContext.Sessions.SingleOrDefault(s => s.Id == id);
            return Mapper.Map<SessionDto>(session);
        }

        /// <summary>
        /// Creates a new session.
        /// </summary>
        /// <param name="editSessionDto">The edit session dto.</param>
        /// <returns>The id of the created session.</returns>
        public long Create(EditSessionDto editSessionDto)
        {
            // Create a new entity and add it to the repository
            Session session = Mapper.Map<Session>(editSessionDto);
            _sessionsContext.Sessions.Add(session);

            // Add the session to the corrent event
            Event @event = _sessionsContext.Events.Single(e => e.Id == editSessionDto.EventId);
            @event.Sessions.Add(session);

            _sessionsContext.Commit();

            return session.Id;
        }
    }
}