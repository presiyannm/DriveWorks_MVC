using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models.ViewModels;
using DriveWorks_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DriveWorks_MVC.Controllers
{
    public class CarManipulateController : Controller
    {
        private ICarManipulate carManipulateService;

        public CarManipulateController(ICarManipulate carManipulateService)
        {
            this.carManipulateService = carManipulateService;
        }

        [HttpGet]
        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(AddCarModelViewModel addCarModelViewModel)
        {
            await carManipulateService.AddCar(addCarModelViewModel);

            return RedirectToAction("Index", "Home");
        }
    }
}
