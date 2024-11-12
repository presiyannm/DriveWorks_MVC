using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;

namespace DriveWorks_MVC.Interfaces
{
    public interface IHomeActions
    {
        public Task<List<CarModelViewModel>> GetAllCarModelsAsync();

        public Task<List<CarBrand>> GetAllCarBrandsAsync();
    }
}
