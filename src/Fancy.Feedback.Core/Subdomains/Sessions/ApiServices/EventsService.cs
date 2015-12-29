using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Fancy.Feedback.Core.Infrastructure;
using Fancy.Feedback.Core.Subdomains.Sessions.Domain;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;
using Fancy.Feedback.Core.Subdomains.Sessions.Repositories;

namespace Fancy.Feedback.Core.Subdomains.Sessions.ApiServices
{
    public class EventsService : IEventsService
    {
        private readonly ISessionsContext _sessionsContext;

        public EventsService(ISessionsContext sessionsContext)
        {
            _sessionsContext = sessionsContext;
        }

        public int GetEventsCount()
        {
            return _sessionsContext.Events.Count();
        }

        public EventDto GetById(int id)
        {
            Event @event = _sessionsContext.Events.SingleOrDefault(e => e.Id == id);
            return Mapper.Map<EventDto>(@event);
        }

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

        private static PagedResultSet<TDto> CreateResultPage<TEntiy, TDto>(IQueryable<TEntiy> events, int page, int pageSize)
        {
            IEnumerable<TEntiy> pagedEvents = events.Skip((page - 1)*pageSize).Take(pageSize).ToList();

            PagedResultSet<TDto> result = new PagedResultSet<TDto>
            {
                Items = Mapper.Map<IEnumerable<TDto>>(pagedEvents),
                TotalItems = events.Count(),
                Page = page,
                PageSize = pageSize
            };
            return result;
        }

        public IEnumerable<EventDto> GetAllEvents()
        {
            IEnumerable<Event> events = _sessionsContext.Events;
            return Mapper.Map<IEnumerable<EventDto>>(events);
        }

        public int SaveOrUpdateEvent(EventDto eventDto)
        {
            Event @event = _sessionsContext.Events.SingleOrDefault(e => e.Id == eventDto.Id);

            if (@event != null)
            {
                // Update an existing event
                Mapper.Map(eventDto, @event);
            }
            else
            {
                // Create a new entity and add it to the repository
                @event = Mapper.Map<Event>(eventDto);
                _sessionsContext.Events.Add(@event);
            }

            _sessionsContext.Commit();

            return @event.Id;
        }
    }
}