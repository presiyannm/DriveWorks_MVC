namespace DriveWorks_MVC.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<CarBrand> Brands { get; set; }

        public List<CarModelViewModel> Models { get; set; }

        public int SelectedModelId { get; set; }
    }
}
