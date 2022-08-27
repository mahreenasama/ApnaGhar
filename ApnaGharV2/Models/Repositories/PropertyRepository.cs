using Microsoft.Data.SqlClient;
using ApnaGharV2.Models.Interfaces;

namespace ApnaGharV2.Models
{
    public class PropertyRepository:IPropertyRepository
    {
        //static string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ApnaGharDB_Final;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool AddProperty(PropertyInfo p)
        {
            var context = new ApnaGharV2_DBContext();

            p.CreatedBy = 1;
            p.CreatedDate = System.DateTime.Now;                //adding additive information
            p.ModifiedBy = 1;
            p.ModifiedDate = System.DateTime.Now;

            context.Properties.Add(p);
            int n = context.SaveChanges();
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateProperty(int id, PropertyInfo newData)
        {
            var context = new ApnaGharV2_DBContext();

            var property = (PropertyInfo)context.Properties.Where(p => p.PropertyID == id);

            property.PropertyID = newData.PropertyID;
            property.Purpose = newData.Purpose;
            property.Type = newData.Type;
            property.SubType = newData.SubType;
            property.City = newData.City;
            property.Area = newData.Area;
            property.Address = newData.Address;
            property.Title = newData.Title;
            property.Description = newData.Description;
            property.Price = newData.Price;
            property.PriceUnit = newData.PriceUnit;
            property.Size = newData.Size;
            property.SizeUnit = newData.SizeUnit;
            property.Bedrooms = newData.Bedrooms;
            property.Bathrooms = newData.Bathrooms;
            property.ImagesPath = newData.ImagesPath;

            property.ModifiedBy = 1;
            property.ModifiedDate = System.DateTime.Now;

            int n = context.SaveChanges();
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteProperty(int id)
        {
            var context = new ApnaGharV2_DBContext();

            var property = context.Properties.Where(p => p.PropertyID == id);  //getting the property

            context.Properties.Remove((PropertyInfo)property);

            int n = context.SaveChanges();
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public PropertyInfo SearchProperty(int id)
        {
            var context = new ApnaGharV2_DBContext();

            var property = context.Properties.Where(p => p.PropertyID == id);  //getting the property

            if (property.Count() > 0)     //means property found
            {
                return (PropertyInfo)property;  //returning by converting into property
            }
            return null;
        }
        public List<PropertyInfo> ViewAllProperties()
        {
            List<PropertyInfo> propList = new List<PropertyInfo>();

            var context = new ApnaGharV2_DBContext();

            var query = context.Properties;      //get all
            foreach (var property in query)
            {
                PropertyInfo p = new PropertyInfo();

                p.PropertyID = property.PropertyID;
                p.Purpose = property.Purpose;
                p.Type = property.Type;
                p.SubType = property.SubType;
                p.City = property.City;
                p.Area = property.Area;
                p.Address = property.Address;
                p.Title = property.Title;
                p.Description = property.Description;
                p.Price = property.Price;
                p.PriceUnit = property.PriceUnit;
                p.Size = property.Size;
                p.SizeUnit = property.SizeUnit;
                p.Bedrooms = property.Bedrooms;
                p.Bathrooms = property.Bathrooms;
                p.ImagesPath = property.ImagesPath;
                p.UserID = property.UserID;

                propList.Add(p);
            }
            return propList;
        }

    }
}
