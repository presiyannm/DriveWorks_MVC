using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;

namespace DriveWorks_MVC.Interfaces
{
    public interface ICarPartsManipulate
    {
        public Task<CarPartViewModel> AddCarPartAsync(CarPartViewModel carPartViewModel);

        public Task RemoveCarPartByIdAsync(int id);

        public Task EditCarPart(EditCarPartViewModel carPartViewModel);

        public CarPart UpdateCarPartValues(EditCarPartViewModel carPartViewModel, CarPart carPart);

        public Task<List<CarModel>> GetAllCarModelsAsync();

        public Task<List<CarPart>> GetAllCarPartsAsync();

        public Task<CarPart> GetCarPartByIdAsync(int id);
    }
}
