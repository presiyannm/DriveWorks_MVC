using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DriveWorks_MVC.Controllers
{
    [Authorize]
    public class BuyItemController : Controller
    {
        private IPurchase purchaseService;

        public BuyItemController(IPurchase purchaseService)
        {
            this.purchaseService = purchaseService;
        }

        [HttpPost]
        public IActionResult BuyCarPart(BuyCarPartViewModel BuyCarPartViewModel)
        {
            return View(BuyCarPartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmPurchase(BuyCarPartViewModel carPartViewModel)
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
