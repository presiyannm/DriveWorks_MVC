using DriveWorks_MVC.Data;
using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriveWorks_MVC.Services
{
    public class CarManipulateService : ICarManipulate
    {
        private ApplicationDbContext _dbContext;

        public CarManipulateService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CarModelViewModel> AddCar(CarModelViewModel addCarModelViewModel)
        {

            var brand = await _dbContext.CarBrands.FirstOrDefaultAsync(b => b.Name == addCarModelViewModel.BrandName);

            if (brand == null)
            {
                var brandToCreate = new CarBrand()
                {
                    Name = addCarModelViewModel.BrandName
                };

                await _dbContext.CarBrands.AddAsync(brandToCreate);
                await _dbContext.SaveChangesAsync();

                brand = await _dbContext.CarBrands.FirstOrDefaultAsync(b => b.Name == addCarModelViewModel.BrandName);
            }

            var car = new CarModel()
            {
                BrandId = brand.Id,
                Name = addCarModelViewModel.ModelName,
                Description = addCarModelViewModel.Description,
                YearOfRelease = addCarModelViewModel.YearOfRelease,
                EngineInformation = addCarModelViewModel.EngineInformation,
            };

            brand.CarModels.Add(car);

            await _dbContext.CarModels.AddAsync(car);

            await _dbContext.SaveChangesAsync();

            return addCarModelViewModel;
        }

        //public async Task<CarModelViewModel> EditCar(CarModelViewModel carModelViewModel)
        //{
        //    var car = _dbContext.CarModels.FirstOrDefaultAsync(x => x.Name == carModelViewModel.ModelName);

        //    if (car == null)
        //    {
        //        throw new Exception("Car cannot be found");
        //    }


        //}

        public async Task<List<CarModel>> GetAllCarsAsync()
        {
           
        }
    }

}

