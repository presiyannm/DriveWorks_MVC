using DriveWorks_MVC.Data;
using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
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
                Id = addCarModelViewModel.Id,
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

        public async Task EditCar(CarModelViewModel carModelViewModel)
        {            
            var carModel = await _dbContext.CarModels.FirstOrDefaultAsync(c => c.Id ==  carModelViewModel.Id);

            if (carModel == null)
            {
                throw new Exception("Car cannnot be found");
            }

            UpdateCarValues(carModelViewModel, carModel);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<CarModel>> GetAllCarsAsync()
        {
            var cars = await _dbContext.CarModels.Include(c => c.Brand).ToListAsync();

            return cars;
        }

        public async Task<CarModelViewModel> GetCarById(int id)
        {
            var car = await _dbContext.CarModels.FirstOrDefaultAsync(c => c.Id == id);

            if (car == null)
            {
                throw new Exception("Car cannot be found");
            }

            var carBrand = await _dbContext.CarBrands.FirstOrDefaultAsync(b => b.Id == car.BrandId);

            if (carBrand == null)
            {
                throw new Exception("Car's brand cannot be found");
            }

            var carViewModel = new CarModelViewModel()
            {
                BrandName = carBrand.Name,
                Description = car.Description,
                EngineInformation = car.EngineInformation,
                ModelName = car.Name,
                YearOfRelease = car.YearOfRelease
            };

            return carViewModel;
        }

        public CarModel UpdateCarValues(CarModelViewModel carModelViewModel, CarModel carModel)
        {
            carModel.Name = carModelViewModel.ModelName;
            carModel.Description = carModelViewModel.Description;
            carModel.EngineInformation = carModelViewModel.EngineInformation;
            carModel.YearOfRelease = carModelViewModel.YearOfRelease;
            carModel.CarParts = carModelViewModel.Parts;

            return carModel;
        }

        public async Task RemoveCar(int id)
        {
            var carToRemove = await _dbContext.CarModels.FirstOrDefaultAsync(c => c.Id == id);

            if (carToRemove != null)
            {
                _dbContext.CarModels.Remove(carToRemove);

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Car that you want to remove cannot be found");
            }

        }
    }

}

