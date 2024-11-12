using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models.ViewModels;
using DriveWorks_MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DriveWorks_MVC.Controllers
{
    [Authorize(Roles = "Manager")]
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
            var allCars = await carPartsManipulateService.GetAllCarModelsAsync();

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


        [HttpGet]
        public async Task<IActionResult> EditCarPart(int id)
        {
            var carPart = await carPartsManipulateService.GetCarPartByIdAsync(id);

            var carModels = await carPartsManipulateService.GetAllCarModelsAsync();

            var carPartViewModel = new EditCarPartViewModel()
            {
                CarPart = carPart,
                CarModels = carModels 
            };

            return View(carPartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditCarPart(EditCarPartViewModel editCarPartViewModel)
        {
             await carPartsManipulateService.EditCarPart(editCarPartViewModel);

            return RedirectToAction("ShowAllCarParts", "CarPartsManipulate");
        }

        public async Task<IActionResult> RemoveCarPart(int id)
        {
            await carPartsManipulateService.RemoveCarPartByIdAsync(id);

            return RedirectToAction("ShowAllCarParts", "CarPartsManipulate");
        }
    }
}
