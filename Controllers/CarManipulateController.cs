using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models;
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
        public async Task<IActionResult> AddCar(CarModelViewModel addCarModelViewModel)
        {
            await carManipulateService.AddCar(addCarModelViewModel);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllCars()
        {
            var cars = await carManipulateService.GetAllCarsAsync();

            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> EditCar(int id)
        {
            var carModelViewModel = await carManipulateService.GetCarById(id);

            return View(carModelViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditCar(CarModelViewModel carModelViewModel)
        {
            await carManipulateService.EditCar(carModelViewModel);

            return RedirectToAction(nameof(ShowAllCars));
            
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            await carManipulateService.RemoveCar(id);

            return RedirectToAction(nameof(ShowAllCars));
        }
    }
}
