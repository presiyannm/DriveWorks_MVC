using DriveWorks_MVC.Data;
using DriveWorks_MVC.Interfaces;
using DriveWorks_MVC.Models;
using DriveWorks_MVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DriveWorks_MVC.Services
{
    public class AssignService : IAssign
    {
        private ApplicationDbContext _dbContext;

        public AssignService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AssignCarPartsAsync(int carModelId, IEnumerable<int> carPartsIds)
        {
            var carModel = await _dbContext.CarModels.FirstOrDefaultAsync(c => c.Id == carModelId);

            if (carModel == null)
            {
                throw new Exception("Car model cannot be null");
            }

            var carParts = await _dbContext.CarParts
                .Where(cp => carPartsIds.Contains(cp.Id)) 
                .ToListAsync();

            foreach (var carPart in carParts)
            {
                carModel.CarParts.Add(carPart);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<CarModel>> GetAllCarModels()
        {
            var carModels = await _dbContext.CarModels.Include(cp => cp.CarParts).ToListAsync();

            return carModels;
        }

        public async Task<List<CarPart>> GetAllCarParts()
        {
            var carParts = await _dbContext.CarParts.Include(cp => cp.CarModels).ToListAsync();

            return carParts;
        }

        public async Task<List<CarPart>> GetCarPartsForModel(int carModelId)
        {
            var carData = await _dbContext.CarModels.Include(c => c.CarParts)
                        .FirstOrDefaultAsync(c => c.Id == carModelId);

            if (carData == null)
            {
                throw new Exception("Car cannot be null");
            }

            return (carData.CarParts.ToList());
        }
    }
}
