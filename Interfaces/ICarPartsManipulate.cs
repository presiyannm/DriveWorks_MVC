using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;

namespace DriveWorks_MVC.Interfaces
{
    public interface ICarPartsManipulate
    {
        public Task<CarPartViewModel> AddCarPartAsync(CarPartViewModel carPartViewModel);

        public Task<List<CarModel>> GetAllCarModels();

        public Task<List<CarPart>> GetAllCarPartsAsync();
    }
}
