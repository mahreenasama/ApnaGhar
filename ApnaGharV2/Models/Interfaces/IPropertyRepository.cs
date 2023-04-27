using ApnaGharV2.Models.ViewModels;
using ApnaGharV2.Models.Classes;

namespace ApnaGharV2.Models.Interfaces
{
    public interface IPropertyRepository
    {
        public bool AddProperty(AddPropertyViewModel p, List<IFormFile> PropertyImages, int adderId);
        public bool UpdateProperty(Property newData, List<IFormFile> PropertyImages, int id, int changerId);
        public bool DeleteProperty(int id);
        public Property ViewProperty(int id);
        //public Property SearchProperty(int id);

        public List<Property> ViewAllProperties(int num);
        public List<Property> FilterProperties(string city, string purpose, string type);

        public List<Property> SearchBar(string city, string id);

    }
}
