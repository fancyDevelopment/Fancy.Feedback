using System.Collections.Generic;

namespace Fancy.Feedback.Core.Subdomains.Sessions.Domain
{
    /// <summary>
    /// An event.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the sessions of the event.
        /// </summary>
        /// <value>
        /// The sessions.
        /// </value>
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
