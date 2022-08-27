using ApnaGharV2.Models.Interfaces;

namespace ApnaGharV2.Models.Repositories
{
    public class AgencyRepository: IAgencyRepository
    {

        public bool AddAgency(Agency agency)
        {
            var context = new ApnaGharV2_DBContext();

            agency.CreatedBy = 1;
            agency.CreatedDate = System.DateTime.Now;

            context.Agencies.Add(agency);
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
        public bool UpdateAgency(int id, Agency newData)
        {
            var context = new ApnaGharV2_DBContext();

            var agency = (Agency)context.Agencies.Where(a => a.AgencyID == id);  //getting the agency
            
            agency.Name = newData.Name;
            agency.ServicesDescription = newData.ServicesDescription;
            agency.CompanyPhone = newData.CompanyPhone;
            agency.CompanyAddress = newData.CompanyAddress;
            agency.CompanyEmail = newData.CompanyEmail;
            agency.LogoPath = newData.LogoPath;

            agency.ModifiedBy = 1;
            agency.ModifiedDate = System.DateTime.Now;

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
        public bool DeleteAgency(int id)
        {
            var context = new ApnaGharV2_DBContext();

            var agency = context.Agencies.Where(a => a.AgencyID == id);  //getting the agency

            context.Agencies.Remove((Agency)agency);

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
        public Agency SearchAgency(int id)
        {
            var context = new ApnaGharV2_DBContext();

            var agency = context.Agencies.Where(a => a.AgencyID == id);  //getting the agency

            if (agency.Count() > 0)     //means agency found
            {
                return (Agency)agency;  //returning by converting into agency
            }
            return null;
        }
        public List<Agency> GetAllAgencies()
        {
            List<Agency> agencies= new List<Agency>();

            var context = new ApnaGharV2_DBContext();

            var query = context.Agencies;      //get all
            foreach(var agency in query)
            {
                Agency a = new Agency();
                a.AgencyID = agency.AgencyID;
                a.Name = agency.Name;
                a.ServicesDescription = agency.ServicesDescription;
                a.CompanyPhone = agency.CompanyPhone;
                a.CompanyAddress = agency.CompanyAddress;
                a.CompanyEmail = agency.CompanyEmail;
                a.LogoPath = agency.LogoPath;
                a.UserID = agency.UserID;

                agencies.Add(a);
            }
            return agencies;
        }
    }

    
}
