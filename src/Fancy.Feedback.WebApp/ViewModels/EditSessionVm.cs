using System;

using Fancy.ResourceLinker.Models;
using Fancy.SchemaFormBuilder.Annotations;

namespace Fancy.Feedback.WebApp.ViewModels
{
    public class EditSessionVm : ResourceBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the session.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [FormRequired]
        [FormTitle("Title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the time the session occured.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        [FormRequired]
        [FormTitle("Time")]
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