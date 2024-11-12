using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DriveWorks_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IHomeActions homeActionsService;

        public HomeController(ILogger<HomeController> logger, IHomeActions homeActionsService)
        {
            _logger = logger;
            this.homeActionsService = homeActionsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var brands = await homeActionsService.GetAllCarBrandsAsync();

            var models = await homeActionsService.GetAllCarModelsAsync();

            var HomeViewModel = new HomeViewModel()
            {
                Brands = brands,
                Models = models
            };

            return View(HomeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetModelsByBrand(int brandId)
        {
            var models = await homeActionsService.GetAllCarModelsAsync();

            var filteredModels = models.Where(m => m.BrandId == brandId).Select(m => new
            {
                m.Id,
                m.ModelName
            }).ToList();

            return Json(filteredModels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
