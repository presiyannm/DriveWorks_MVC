//using DriveWorks_MVC.Interfaces;
//using DriveWorks_MVC.Models.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json.Serialization;
//using System.Text.Json;
//using DriveWorks_MVC.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace DriveWorks_MVC.Controllers
//{
//    public class AssignController : Controller
//    {
//        private IAssign assignService;

//        public AssignController(IAssign assignService)
//        {
//            this.assignService = assignService;
//        }

//        [HttpGet]
//        public async Task<IActionResult> AssignCarParts()
//        {
//            var carModels = await assignService.GetAllCarModels();

//            var carParts = await assignService.GetAllCarParts();

//            var carPartsOptions = carParts.Select(part => new SelectListItem
//            {
//                Value = part.Id.ToString(),
//                Text = part.Name
//            }).ToList();

//            AssignCarViewModel viewModel = new AssignCarViewModel()
//            {
//                carModels = carModels,
//                carParts = carParts,
//                CarPartsOptions = carPartsOptions
                
//            };

//            return View(viewModel);
//        }

//        [HttpPost]

//        public async Task<IActionResult> AssignCarParts(AssignCarViewModel assignCarViewModel)
//        {
//            if(assignCarViewModel == null)
//            {
//                throw new Exception("Car && Parts information cannot be null");
//            }   

//            await assignService.AssignCarPartsAsync(assignCarViewModel.carModelId, assignCarViewModel.carPartsIds);

//            return RedirectToAction("Index", "Home");
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetCarPartsForModel(int carModelId)
//        {
//            var carParts = await assignService.GetCarPartsForModel(carModelId);

//            var carPartsViewModel = carParts.Select(cp => new CarPartsViewModel
//            {
//                Id = cp.Id,
//                Name = cp.Name

//            }).ToList();


//            return Json(new { carParts = carPartsViewModel });
//        }
//    }
//}
