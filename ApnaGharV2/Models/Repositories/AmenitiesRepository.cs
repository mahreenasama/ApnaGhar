using ApnaGharV2.Models.Interfaces;
using ApnaGharV2.Models.Classes;

namespace ApnaGharV2.Models.Repositories
{
    public class AmenitiesRepository:IAmenitiesRepository
    {
        public bool AddAmenities(Amenities amenities)
        {
            var context = new AccountsDbContext();

            /*amenities.CreatedBy = 1;
            amenities.CreatedDate = System.DateTime.Now;*/

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
        public bool UpdateAmeninties(int propertyId, Amenities newData)
        {
            /*var context = new AccountsDbContext();

            var amenities = (PropertyAmenities)context.Amenities.Where(am => am.Id == propertyId);  //getting the agency
*/
            /*agency.Name = newData.Name;
            agency.ServicesDescription = newData.ServicesDescription;
            agency.CompanyPhone = newData.CompanyPhone;
            agency.CompanyAddress = newData.CompanyAddress;
            agency.CompanyEmail = newData.CompanyEmail;
            agency.LogoPath = newData.LogoPath;*/

            /*amenities.ModifiedBy = 1;
            amenities.ModifiedDate = System.DateTime.Now;*/

            /*int n = context.SaveChanges();
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }*/
            return false;
        }
        public bool DeleteAgency(int propertyId)
        {
            return false;
            /*var context = new AccountsDbContext();

            var amenities = (PropertyAmenities)context.Amenities.Where(am => am.Id == propertyId);  //getting the agency

            context.Amenities.Remove((PropertyAmenities)amenities);

            int n = context.SaveChanges();
            if (n > 0)
            {
                return true;
            }
            else
            {
                return false;
            }*/
        }
    }
}
