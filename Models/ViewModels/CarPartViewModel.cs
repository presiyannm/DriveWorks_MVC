using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DriveWorks_MVC.Models.ViewModels
{
    public class CarPartViewModel
    {
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

        public List<CarModel> Cars { get; set; } = new();

        public IEnumerable<int> SelectedCarIds { get; set; } = new HashSet<int>();

        public List<SelectListItem> CarModelOptions { get; set; } = new();
    }
}
