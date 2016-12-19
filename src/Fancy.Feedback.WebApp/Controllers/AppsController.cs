using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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