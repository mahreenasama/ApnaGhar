using ApnaGharV2.Models;
using ApnaGharV2.Models.Classes;

namespace ApnaGharV2.Models.ViewModels
{
    public class PropertyViewModel
    {
        public Property Prop { get; set; }
        public List<IFormFile> PropertyImages { get; set; }

        public Amenities? Amen { get; set; }
    }
}
