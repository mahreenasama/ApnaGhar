namespace ApnaGharV2.Models.Interfaces
{
    public interface IPropertyRepository
    {
        public bool AddProperty(PropertyInfo p);
        public bool UpdateProperty(int id, PropertyInfo newData);
        public bool DeleteProperty(int id);
        public PropertyInfo SearchProperty(int id);
        public List<PropertyInfo> ViewAllProperties();

    }
}
