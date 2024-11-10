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
                IsPartAccessible = carPartViewModel.Quantity > 0
            };

            var selectedCarModels = await _dbContext.CarModels
            .Where(cm => carPartViewModel.SelectedCarIds.Contains(cm.Id))
            .ToListAsync();

            foreach(var carModel in selectedCarModels)
            {
                carPartToAdd.CarModels.Add(carModel);
            }

            await _dbContext.CarParts.AddAsync(carPartToAdd);

            await _dbContext.SaveChangesAsync();

            return carPartViewModel;
        }

        public async Task EditCarPart(EditCarPartViewModel carPartViewModel)
        {
            var carPartToUpdate = await _dbContext.CarParts.FirstOrDefaultAsync(c => c.Id == carPartViewModel.CarPart.Id);

            if (carPartToUpdate == null)
            {
                throw new Exception("Car Part to update cannot be null");
            }

            UpdateCarPartValues(carPartViewModel, carPartToUpdate);

            carPartToUpdate.CarModels.Clear();

            var partsToRemove = _dbContext.CarParts.Where(cp => cp.Id == carPartToUpdate.Id);

            _dbContext.CarParts.RemoveRange(partsToRemove);

            var selectedCarModels = await _dbContext.CarModels
           .Where(cm => carPartViewModel.SelectedCarModelIds.Contains(cm.Id))
           .ToListAsync();

            foreach (var carModel in selectedCarModels)
            {
                carPartToUpdate.CarModels.Add(carModel);
            }

            await _dbContext.CarParts.AddAsync(carPartToUpdate);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<List<CarModel>> GetAllCarModelsAsync()
        {
            return (await _dbContext.CarModels.ToListAsync());
        }

        public async Task<List<CarPart>> GetAllCarPartsAsync()
        {
            var carParts = await _dbContext.CarParts.Include(c => c.CarModels).ToListAsync();

            return carParts;
        }

        public async Task<CarPart> GetCarPartByIdAsync(int id)
        {
            var carPart = await _dbContext.CarParts.FirstOrDefaultAsync(c => c.Id == id);

            if (carPart == null)
            {
                throw new Exception("Car Part cannot be null");
            }

            return carPart;
        }

        public async Task RemoveCarPartById(int id)
        {
            var carPartToRemove = await _dbContext.CarParts.FirstOrDefaultAsync(c => c.Id == id);

            if (carPartToRemove == null)
            {
                throw new Exception("Car part to be removed cannot be null");
            }

            _dbContext.CarParts.Remove(carPartToRemove);

            await _dbContext.SaveChangesAsync();
        }

        public CarPart UpdateCarPartValues(EditCarPartViewModel carPartViewModel, CarPart carPart)
        {
            carPart.Id = carPartViewModel.CarPart.Id;
            carPart.Name = carPartViewModel.CarPart.Name;
            carPart.Description = carPartViewModel.CarPart.Description;
            carPart.Price = carPartViewModel.CarPart.Price;
            carPart.Quantity = carPartViewModel.CarPart.Quantity;
            carPart.IsPartAccessible = carPartViewModel.CarPart.Quantity > 0;
            carPart.Type = carPartViewModel.CarPart.Type;

            return carPart;
        }
    }
}
