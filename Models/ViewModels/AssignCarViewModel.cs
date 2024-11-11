namespace DriveWorks_MVC.Models.ViewModels
{
    public class AssignCarViewModel
    {
        public List<CarModel> carModels {  get; set; }

        public List<CarPart> carParts { get; set; }

        public int carModelId { get; set; }

        public IEnumerable<int> carPartsIds { get; set; } = new HashSet<int>();
    }
}
