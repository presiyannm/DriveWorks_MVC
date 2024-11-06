using DriveWorks_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DriveWorks_MVC.Interfaces
{
    public interface ICarManipulate
    {
        public Task<AddCarModelViewModel> AddCar(AddCarModelViewModel addCarModelViewModel);

    }
}
