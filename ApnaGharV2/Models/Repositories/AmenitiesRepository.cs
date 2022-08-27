using ApnaGharV2.Models.Interfaces;

namespace ApnaGharV2.Models.Repositories
{
    public class AmenitiesRepository:IAmenitiesRepository
    {
        public bool AddAmenities(PropertyAmenities amenities)
        {
            var context = new ApnaGharV2_DBContext();

            amenities.CreatedBy = 1;
            amenities.CreatedDate = System.DateTime.Now;

            context.Amenities.Add(amenities);
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
        public bool UpdateAmeninties(int propertyId, PropertyAmenities newData)
        {
            var context = new ApnaGharV2_DBContext();

            var amenities = (PropertyAmenities)context.Amenities.Where(am => am.PropertyID == propertyId);  //getting the agency

            /*agency.Name = newData.Name;
            agency.ServicesDescription = newData.ServicesDescription;
            agency.CompanyPhone = newData.CompanyPhone;
            agency.CompanyAddress = newData.CompanyAddress;
            agency.CompanyEmail = newData.CompanyEmail;
            agency.LogoPath = newData.LogoPath;*/

            amenities.ModifiedBy = 1;
            amenities.ModifiedDate = System.DateTime.Now;

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
        public bool DeleteAgency(int propertyId)
        {
            var context = new ApnaGharV2_DBContext();

            var amenities = (PropertyAmenities)context.Amenities.Where(am => am.PropertyID == propertyId);  //getting the agency

            context.Amenities.Remove((PropertyAmenities)amenities);

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
    }
}
