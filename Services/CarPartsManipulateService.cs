using DriveWorks_MVC.Data;
using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DriveWorks_MVC.Services
{
    public class CarPartsManipulateService : ICarPartsManipulate
    {
        private ApplicationDbContext _dbContext;

        public CarPartsManipulateService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CarPartViewModel> AddCarPartAsync(CarPartViewModel carPartViewModel)
        {
            var carPartToAdd = new CarPart()
            {
                Id = carPartViewModel.Id,
                Name = carPartViewModel.Name,
                Description = carPartViewModel.Description,
                Price = carPartViewModel.Price,
                Quantity = carPartViewModel.Quantity,
                Type = carPartViewModel.Type,
                CarModels = carPartViewModel.Cars,
            };

            if (carPartToAdd.Quantity > 0)
            {
                carPartToAdd.IsPartAccessible = true;
            }

            await _dbContext.CarParts.AddAsync(carPartToAdd);

            await _dbContext.SaveChangesAsync();

            return carPartViewModel;
        }

        public async Task<List<CarModel>> GetAllCarModels()
        {
            return (await _dbContext.CarModels.ToListAsync());
        }
    }
}
