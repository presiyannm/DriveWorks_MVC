using DriveWorks_MVC.Models;

namespace DriveWorks_MVC.Interfaces
{
    public interface IAssign
    {
        public Task<List<CarModel>> GetAllCarModels();

        public Task<List<CarPart>> GetAllCarParts();

        public Task<List<CarPart>> GetCarPartsForModel(int carModelId);

        public Task AssignCarPartsAsync(int carModelId, IEnumerable<int> carPartsIds);
    }
}
