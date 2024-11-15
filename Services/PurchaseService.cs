using DriveWorks_MVC.Data;
using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DriveWorks_MVC.Services
{
    public class PurchaseService : IPurchase
    {
        private ApplicationDbContext _dbContext;

        public PurchaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ConfirmPurchase(BuyCarPartViewModel buyCarPartViewModel)
        {
            var carPart = await _dbContext.CarParts.FirstOrDefaultAsync(cp => cp.Name == buyCarPartViewModel.Name);

            if (carPart == null)
            {
                throw new Exception("Car part cannot be null");
            }

            if (carPart.Quantity - buyCarPartViewModel.PurchasedQuantity > 0)
            {
                carPart.Quantity-=buyCarPartViewModel.PurchasedQuantity;
            }

            else if(carPart.Quantity - buyCarPartViewModel.PurchasedQuantity == 0)
            {
                carPart.Quantity = 0;
                carPart.IsPartAccessible = false;
            }

            else
            {
                throw new Exception("Quantity cannot be below zero");
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
