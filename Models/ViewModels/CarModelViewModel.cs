using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DriveWorks_MVC.Models.ViewModels
{
    public class CarModelViewModel
    {

        public int Id { get; set; }

        public int BrandId { get; set; }

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

        public List<CarPart> Parts { get; set; } = new();

        public IEnumerable<int> SelectedCarPartsIds { get; set; } = new HashSet<int>();

        public List<SelectListItem> CarModelOptions { get; set; } = new();

        public List<IGrouping<string, CarPart>> CarPartsGrouped { get; set; } = new();

    }
}
