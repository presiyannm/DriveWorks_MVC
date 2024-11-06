using System.ComponentModel.DataAnnotations;

namespace DriveWorks_MVC.Models
{
    public class CarBrand
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<CarModel> CarModels { get; set; } = new HashSet<CarModel>();
    }
}
