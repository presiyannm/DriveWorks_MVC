using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DriveWorks_MVC.Interfaces
{
    public interface ICarManipulate
    {
        public Task<CarModelViewModel> AddCar(CarModelViewModel addCarModelViewModel);

        public Task EditCar(CarModelViewModel carModelViewModel);

        public Task<List<CarModel>> GetAllCarsAsync();

        public Task<CarModelViewModel> GetCarById(int id);

        public CarModel UpdateCarValues(CarModelViewModel carModelViewModel, CarModel carModel);

        public Task RemoveCar(int id);

    }
}
