using ApnaGharV2.Models;

namespace ApnaGharV2.Models.ViewModels
{
    public class Property
    {
        public PropertyInfo MyPropInfo { get; set; }
        public List<IFormFile> PropertyImages { get; set; }

        //public PropertyAmenities? MyPropAmenities { get; set; }
    }
}
