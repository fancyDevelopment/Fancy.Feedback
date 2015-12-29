using System;
using System.Linq;
using AutoMapper;
using Fancy.Feedback.Core.Infrastructure;
using Fancy.Feedback.Core.Subdomains.Sessions.Domain;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;
using Fancy.Feedback.Core.Subdomains.Sessions.Repositories;

namespace Fancy.Feedback.Core.Subdomains.Sessions.ApiServices
{
    /// <summary>
    /// Implements the <see cref="IEventsService"/> interface.
    /// </summary>
    /// <seealso cref="Fancy.Feedback.Core.Subdomains.Sessions.ApiServices.IEventsService" />
    public class EventsService : IEventsService
    {
        /// <summary>
        /// The sessions context.
        /// </summary>
        private readonly ISessionsContext _sessionsContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsService"/> class.
        /// </summary>
        /// <param name="sessionsContext">The sessions context.</param>
        public EventsService(ISessionsContext sessionsContext)
        {
            _sessionsContext = sessionsContext;
        }

        /// <summary>
        /// Gets the count of all events.
        /// </summary>
        /// <returns>
        /// The number of all events.
        /// </returns>
        public int GetCount()
        {
            return _sessionsContext.Events.Count();
        }

        /// <summary>
        /// Gets an event by its identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// An event.
        /// </returns>
        public EventDto GetById(int id)
        {
            Event @event = _sessionsContext.Events.SingleOrDefault(e => e.Id == id);
            return Mapper.Map<EventDto>(@event);
        }

        /// <summary>
        /// Finds events by a specified title filter and returns one page of the result.
        /// </summary>
        /// <param name="titleFilter">The title filter.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// A paged result set.
        /// </returns>
        public PagedResultSet<EventDto> Find(string titleFilter = null, int page = 1, int pageSize = 100)
        {
            IQueryable<Event> events = _sessionsContext.Events.OrderBy(e => e.Name);

            if (!string.IsNullOrEmpty(titleFilter))
            {
                events = events.Where(e => e.Name.Contains(titleFilter));
            }

            PagedResultSet<EventDto> result = events.CreateResultPage<Event, EventDto>(page, pageSize);

            return result;
        }

        /// <summary>
        /// Updates an event.
        /// </summary>
        /// <param name="id">The identifier of the event to update.</param>
        /// <param name="eventDto">The event dto.</param>
        public void Update(int id, EventDto eventDto)
        {
            Event @event = _sessionsContext.Events.Single(e => e.Id == eventDto.Id);

            // Update an existing event
            Mapper.Map(eventDto, @event);

            _sessionsContext.Commit();

        }

        /// <summary>
        /// Saves an event.
        /// </summary>
        /// <param name="eventDto">The event dto.</param>
        /// <returns>
        /// The id of the saved event.
        /// </returns>
        public int Save(EventDto eventDto)
        {
            if (eventDto.Id != 0)
            {
                throw new InvalidOperationException("Id has to be 0");
            }

            // Create a new entity and add it to the repository
            Event @event = Mapper.Map<Event>(eventDto);
            _sessionsContext.Events.Add(@event);

            _sessionsContext.Commit();

            return @event.Id;
        }
    }
}