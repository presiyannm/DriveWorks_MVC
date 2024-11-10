using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DriveWorks_MVC.Models
{
    public class CarPart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public double Price { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; }

        public bool IsPartAccessible { get; set; }
        public virtual ICollection<CarModel> CarModels { get; set; } = new HashSet<CarModel>();
    }
}
