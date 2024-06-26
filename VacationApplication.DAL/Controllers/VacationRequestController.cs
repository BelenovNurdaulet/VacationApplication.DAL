using Microsoft.AspNetCore.Mvc;

namespace VacationApplication.Portal.Controllers
{
    public class VacationRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ApprovedRequests()
        {
            return View();
        }
    }
}
