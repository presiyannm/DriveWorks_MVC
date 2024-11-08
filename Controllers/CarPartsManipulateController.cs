using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models.ViewModels;
using DriveWorks_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DriveWorks_MVC.Controllers
{
    public class CarPartsManipulateController : Controller
    {
        private ICarPartsManipulate carPartsManipulateService;

        public CarPartsManipulateController(ICarPartsManipulate carPartsManipulateService)
        {
            this.carPartsManipulateService = carPartsManipulateService;
        }

        [HttpGet]
        public async Task<IActionResult> AddPart()
        {
            var allCars = await carPartsManipulateService.GetAllCarModels();

            var carModelOptions = allCars.Select(car => new SelectListItem
            {
                Value = car.Id.ToString(),
                Text = car.Name
            }).ToList();

            var viewModel = new CarPartViewModel
            {
                CarModelOptions = carModelOptions
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddPart(CarPartViewModel carPartViewModel)
        {
            await carPartsManipulateService.AddCarPartAsync(carPartViewModel);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllCarParts()
        {
            var carParts = await carPartsManipulateService.GetAllCarPartsAsync();

            return View(carParts);
        }
    }
}
