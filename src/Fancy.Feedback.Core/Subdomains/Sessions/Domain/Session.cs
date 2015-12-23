using System;

namespace Fancy.Feedback.Core.Subdomains.Sessions.Domain
{
    /// <summary>
    /// A session which occured in a specific event.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual long Id { get; set; }

        /// <summary>
        /// Gets or sets the event the session belongs to.
        /// </summary>
        /// <value>
        /// The event.
        /// </value>
        public virtual Event Event { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public virtual DateTimeOffset Time { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }
    }
}
