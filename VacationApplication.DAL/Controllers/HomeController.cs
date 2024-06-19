using Microsoft.AspNetCore.Mvc;

namespace VacationApplication.DAL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}