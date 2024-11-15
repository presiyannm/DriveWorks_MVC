using DriveWorks_MVC.Models.ViewModels;

namespace DriveWorks_MVC.Interfaces
{
    public interface IPurchase
    {
        public Task ConfirmPurchase(BuyCarPartViewModel buyCarPartViewModel);
    }
}
