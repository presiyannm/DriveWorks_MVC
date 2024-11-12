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
                };
                carModelViewModels.Add(carModelViewModel);
            }

            return carModelViewModels;

        }
    }
}
