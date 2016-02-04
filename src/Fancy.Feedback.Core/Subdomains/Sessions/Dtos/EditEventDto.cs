using Fancy.ResourceLinker.Models;

namespace Fancy.Feedback.Core.Subdomains.Sessions.Dtos
{
    /// <summary>
    /// A DTO with the editable fields of an event.
    /// </summary>
    public class EditEventDto : ResourceBase
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}