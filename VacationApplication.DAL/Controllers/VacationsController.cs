using Microsoft.AspNetCore.Mvc;
using VacationApplication.DAL.Models;

namespace VacationApplication.DAL.Controllers
{
    public class VacationsController : Controller
    {
        private readonly VacationService _vacationService;

        public VacationsController(VacationService vacationService)
        {
            _vacationService = vacationService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVacationApplicationRequest request)
        {
            var result = await _vacationService.CreateVacationAsync(request);
            if (result != null)
            {
                return RedirectToAction("Details", new { createBy = result.CreateBy });
            }

            ModelState.AddModelError(string.Empty, "Failed to create vacation application.");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int createBy)
        {
            var vacations = await _vacationService.GetVacationsByCreateByAsync(createBy);
            return View(vacations);
        }
    }
}