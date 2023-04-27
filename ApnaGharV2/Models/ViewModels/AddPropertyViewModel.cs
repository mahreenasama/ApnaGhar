using ApnaGharV2.Models;
using ApnaGharV2.Models.Classes;
using System.ComponentModel.DataAnnotations;

namespace ApnaGharV2.Models.ViewModels
{
    public class AddPropertyViewModel
    {
        public List<string> Purposes { get; set; }
        public List<string> Types { get; set; }
      

        [Required(ErrorMessage = "This field is required")]
        public string Purpose { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Type { get; set; }
        public AddPropertyViewModel()
        {
            Purposes = new List<string>() { "Rent", "Sale" };
            Types = new List<string>() { "Home", "Plot", "Commercial" };
        }
        public Property? Prop { get; set; } = new Property();
        public List<IFormFile>? PropertyImages { get; set; }

    }
}
