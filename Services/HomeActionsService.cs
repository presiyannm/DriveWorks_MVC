using DriveWorks_MVC.Data;
using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DriveWorks_MVC.Services
{
    public class HomeActionsService : IHomeActions
    {
        private ApplicationDbContext _dbContext;

        public HomeActionsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CarBrand>> GetAllCarBrandsAsync()
        {
            var carBrands = await _dbContext.CarBrands.Include(b => b.CarModels).ToListAsync();

            return carBrands;
        }

        public async Task<List<CarModelViewModel>> GetAllCarModelsAsync()
        {
            var carModels = await _dbContext.CarModels.Include(m => m.Brand).ToListAsync();

            List<CarModelViewModel> carModelViewModels = new List<CarModelViewModel>();

            foreach(var model in carModels)
            {
                var carModelViewModel = new CarModelViewModel()
                {
                    ModelName = model.Name,
                    BrandId = model.Brand.Id,
                    Id = model.Id
                };
                carModelViewModels.Add(carModelViewModel);
            }

            return carModelViewModels;

        }

        public async Task<List<CarPartViewModel>> GetCarPartsByModelAsync(int modelId)
        {
            var carModel = await _dbContext.CarModels.Include(cm => cm.CarParts).FirstOrDefaultAsync(cm => cm.Id == modelId);

            if (carModel == null)
            {
                throw new Exception("Car model cannot be null");
            }

            var carPartsViewModels = new List<CarPartViewModel>();

            foreach (var carPart in carModel.CarParts)
            {
                var carPartViewModel = new CarPartViewModel()
                {
                    Name = carPart.Name,
                    Description = carPart.Description,
                    Type = carPart.Type,
                    Price = carPart.Price,
                    Quantity = carPart.Quantity,
                    IsPartAccessible = carPart.Quantity > 0
                };

                carPartsViewModels.Add(carPartViewModel);
            }

            return carPartsViewModels;
        }
    }
}
