using System.Collections.Generic;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;

namespace Fancy.Feedback.Core.Subdomains.Sessions.ApiServices
{
    public interface IEventsService
    {
        int GetEventsCount();

        EventDto GetById(int id);

        IEnumerable<EventDto> GetAllEvents();

        int SaveOrUpdateEvent(EventDto eventDto);
    }
}