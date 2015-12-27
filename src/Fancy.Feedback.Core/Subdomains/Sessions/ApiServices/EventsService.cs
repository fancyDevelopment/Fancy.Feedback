using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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