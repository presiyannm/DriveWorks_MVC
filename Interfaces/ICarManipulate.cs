using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DriveWorks_MVC.Interfaces
{
    public interface ICarManipulate
    {
        public Task<CarModelViewModel> AddCar(CarModelViewModel addCarModelViewModel);

        //public Task<CarModelViewModel> EditCar(CarModelViewModel carModelViewModel);

        public Task<List<CarModelViewModel>> GetAllCarsAsync();

    }
}
