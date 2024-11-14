using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DriveWorks_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IHomeActions homeActionsService;

        private UserManager<IdentityUser> _userManager;

        private RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, IHomeActions homeActionsService, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            this.homeActionsService = homeActionsService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (!roles.Any())
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }

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

        [HttpPost]
        public async Task<IActionResult> GetCarPartsByModel(HomeViewModel homeViewModel)
        {
            var carParts = await homeActionsService.GetCarPartsByModelAsync(homeViewModel.SelectedModelId);

            return View(carParts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
