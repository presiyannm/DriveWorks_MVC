using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveWorks_MVC.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }

        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public CarBrand Brand { get; set; } = null!;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int YearOfRelease { get; set; }

        [Required]
        public string EngineInformation { get; set; } = string.Empty;

        public virtual ICollection<CarPart> CarParts { get; set; } = new HashSet<CarPart>();
    }
}
