using Newtonsoft.Json.Linq;

namespace Fancy.Feedback.WebApp.ViewModels
{
    public class ResourceMetaVm
    {
         /// <summary>
        /// Gets or sets the schema.
        /// </summary>
        /// <value>
        /// The schema.
        /// </value>
        public JToken Schema { get; set; }

        /// <summary>
        /// Gets or sets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        public JToken Form { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public JToken Model { get; set; }
    }
}