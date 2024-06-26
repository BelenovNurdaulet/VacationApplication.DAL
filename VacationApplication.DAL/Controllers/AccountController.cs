using Microsoft.AspNetCore.Mvc;

namespace VacationApplication.Portal.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
