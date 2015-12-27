using System.Collections.Generic;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;

namespace Fancy.Feedback.Core.Subdomains.Sessions.ApiServices
{
    public interface IEventsService
    {
        IEnumerable<EventDto> GetAllEvents();

        int SaveOrUpdateEvent(EventDto eventDto);
    }
}