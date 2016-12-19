using Fancy.Feedback.Core.Subdomains.Sessions.ApiServices;
using Fancy.Feedback.WebApp.ViewModels;
using Fancy.ResourceLinker;
using Microsoft.AspNetCore.Mvc;

namespace Fancy.Feedback.WebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IEventsService _eventsService;

        public DashboardController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        [HttpGet(Name = "Dashboard index")]
        public IActionResult Index()
        {
            DashboardVm dashboardVm = new DashboardVm();

            dashboardVm.EventsCount = _eventsService.GetCount();

            this.LinkResource(dashboardVm);

            return Json(dashboardVm);
        }
    }
}