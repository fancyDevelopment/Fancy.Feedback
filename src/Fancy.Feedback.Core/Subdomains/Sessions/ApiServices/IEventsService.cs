using Fancy.Feedback.Core.Infrastructure;
using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;

namespace Fancy.Feedback.Core.Subdomains.Sessions.ApiServices
{
    /// <summary>
    /// Api service to work with events.
    /// </summary>
    public interface IEventsService
    {
        /// <summary>
        /// Gets the count of all events.
        /// </summary>
        /// <returns>The number of all events.</returns>
        int GetCount();

        /// <summary>
        /// Gets an event by its identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>An event.</returns>
        EventDto GetById(int id);

        /// <summary>
        /// Finds events by a specified title filter and returns one page of the result.
        /// </summary>
        /// <param name="titleFilter">The title filter.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>A paged result set.</returns>
        PagedResultSet<EventDto> Find(string titleFilter = null, int page = 1, int pageSize = 100);

        /// <summary>
        /// Updates an event.
        /// </summary>
        /// <param name="id">The identifier of the event to update.</param>
        /// <param name="editEventDto">The edit event dto.</param>
        void Update(int id, EditEventDto editEventDto);

        /// <summary>
        /// Creates an event.
        /// </summary>
        /// <param name="editEventDto">The edit event dto.</param>
        /// <returns>The id of the saved event.</returns>
        int Create(EditEventDto editEventDto);
    }
}