using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DriveWorks_MVC.Controllers
{
    public class BuyItemController : Controller
    {
        private IPurchase purchaseService;

        public BuyItemController(IPurchase purchaseService)
        {
            this.purchaseService = purchaseService;
        }

        [HttpPost]
        public IActionResult BuyCarPart(CarPartViewModel carPartViewModel)
        {
            return View(carPartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmPurchase(CarPartViewModel carPartViewModel)
        {
            await purchaseService.ConfirmPurchase(carPartViewModel);

            return RedirectToAction("ConfirmedPurchase");
        }

        [HttpGet]

        public IActionResult ConfirmedPurchase()
        {
            return View();
        }
    }
}
