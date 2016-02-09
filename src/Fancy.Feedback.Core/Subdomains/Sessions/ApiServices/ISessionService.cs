using Fancy.Feedback.Core.Subdomains.Sessions.Dtos;

namespace Fancy.Feedback.Core.Subdomains.Sessions.ApiServices
{
    /// <summary>
    /// Api service to work with sessions.
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Gets a session by its identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A session.</returns>
        SessionDto GetById(long id);

        /// <summary>
        /// Creates a new session.
        /// </summary>
        /// <param name="editSessionDto">The edit session dto.</param>
        /// <returns>The id of the created session.</returns>
        long Create(EditSessionDto editSessionDto);
    }
}