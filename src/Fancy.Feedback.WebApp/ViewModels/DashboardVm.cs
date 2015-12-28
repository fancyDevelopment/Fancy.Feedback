using Fancy.ResourceLinker.Models;

namespace Fancy.Feedback.WebApp.ViewModels
{
    public class DashboardVm : ResourceBase
    {
        public int EventsCount { get; set; }

        public int SessionsCount { get; set; }

        public int FeedbacksCount { get; set; }
    }
}