using System.ComponentModel.DataAnnotations;

namespace DriveWorks_MVC.Models.ViewModels
{
    public class EditCarPartViewModel
    {
        public CarPart CarPart { get; set; }

        public ICollection<CarModel> CarModels { get; set; } = new HashSet<CarModel>();

        public IEnumerable<int> SelectedCarModelIds { get; set; } = new HashSet<int>();
    }
}
