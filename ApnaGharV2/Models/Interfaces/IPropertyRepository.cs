﻿using ApnaGharV2.Models.ViewModels;

namespace ApnaGharV2.Models.Interfaces
{
    public interface IPropertyRepository
    {
        public bool AddProperty(Property p, List<IFormFile> PropertyImages);
        public bool UpdateProperty(int id, PropertyInfo newData);
        public bool DeleteProperty(int id);
        public PropertyInfo ViewProperty(int id);
        public List<PropertyInfo> ViewAllProperties();

    }
}
