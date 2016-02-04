using Fancy.ResourceLinker.Models;

namespace Fancy.Feedback.Core.Subdomains.Sessions.Dtos
{
    public class EventDto : ResourceBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the count of sessions the event has.
        /// </summary>
        /// <value>
        /// The session count.
        /// </value>
        public int SessionCount { get; set; }
    }
}