using System.ComponentModel.DataAnnotations;

namespace DriveWorks_MVC.Models.ViewModels
{
    public class AddCarModelViewModel
    {
        [Required]
        public string BrandName {  get; set; } = string.Empty;

        [Required]
        public string ModelName { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string EngineInformation { get; set; } = string.Empty;

        [Required]
        public int YearOfRelease { get; set; }

    }
}
