using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveWorks_MVC.Models
{
    public class CarModelParts
    {
        public int CarModelId { get; set; }

        [ForeignKey(nameof(CarModelId))]
        public CarModel CarModel { get; set; }

        public int CarPartId { get; set; }

        [ForeignKey(nameof(CarPartId))]
        public CarPart CarPart { get; set; }
    }
}
