using System.Collections.Generic;
using Fancy.Feedback.Core.Infrastructure;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;

namespace Fancy.Feedback.Core.Subdomains.Sessions.ApiServices
{
    public interface IEventsService
    {
        int GetEventsCount();

        EventDto GetById(int id);

        PagedResultSet<EventDto> Find(string titleFilter = null, int page = 1, int pageSize = 100);

        int SaveOrUpdateEvent(EventDto eventDto);
    }
}