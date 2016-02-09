using System;

namespace Fancy.Feedback.Core.Subdomains.Sessions.Dtos
{
    /// <summary>
    /// A DTO with the editable fields of a session.
    /// </summary>
    public class EditSessionDto
    {
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