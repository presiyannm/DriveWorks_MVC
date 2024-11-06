using System.ComponentModel.DataAnnotations.Schema;

namespace DriveWorks_MVC.Models
{
    public class CarModelParts
    {
        public int CarModelId { get; set; }
        public int CarPartId { get; set; }

        [ForeignKey(nameof(CarModelId))]
        public virtual CarModel CarModel { get; set; } = null!;

        [ForeignKey(nameof(CarPartId))]
        public virtual CarPart CarPart { get; set; } = null!;
    }
}
