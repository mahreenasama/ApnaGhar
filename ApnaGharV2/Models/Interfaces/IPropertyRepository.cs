using ApnaGharV2.Models.ViewModels;
using ApnaGharV2.Models.Classes;

namespace ApnaGharV2.Models.Interfaces
{
    public interface IPropertyRepository
    {
        public bool AddProperty(PropertyViewModel p, List<IFormFile> PropertyImages);
        public bool UpdateProperty(int id, Property newData);
        public bool DeleteProperty(int id);
        public Property ViewProperty(int id);
        public List<Property> ViewAllProperties();

    }
}
