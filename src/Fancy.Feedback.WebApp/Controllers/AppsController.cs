using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Fancy.Feedback.WebApp.Controllers
{
    [Authorize]
    public class AppsController : Controller
    {
        [HttpGet]
        public IActionResult Administration()
        {
            return View();
        }
    }
}