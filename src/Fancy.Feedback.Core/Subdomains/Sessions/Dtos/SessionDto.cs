using System;

using Fancy.ResourceLinker.Models;

namespace Fancy.Feedback.Core.Subdomains.Sessions.Dtos
{
    /// <summary>
    /// A DTO with all fields of a session.
    /// </summary>
    public class SessionDto : ResourceBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the session.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the time the session occured.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public DateTimeOffset Time { get; set; }

        /// <summary>
        /// Gets or sets the event identifier of the event the session belongs to.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int EventId { get; set; }
    }
}