using ApnaGharV2.Models.Interfaces;

namespace ApnaGharV2.Models.Repositories
{
    public class EnquiryRepository:IEnquiryRepository
    {
        //public static List<Enquiry>? agencies;

        public bool SubmitEnquiry(Enquiry enquiry)
        {
            var context = new ApnaGharV2_DBContext();

            enquiry.CreatedBy = 1;
            enquiry.CreatedDate = System.DateTime.Now;

            context.Enquiries.Add(enquiry);
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

        public List<Enquiry> GetAllEnquiries()
        {
            List<Enquiry> enquiries = new List<Enquiry>();

            var context = new ApnaGharV2_DBContext();

            var query = context.Enquiries;      //get all
            foreach (var enquiry in query)
            {
                Enquiry e = new Enquiry();

                e.Id = enquiry.Id;
                e.Name = enquiry.Name;
                e.Email = enquiry.Email;
                e.PhoneNumber = enquiry.PhoneNumber;
                e.Message = enquiry.Message;
                e.PropertyId = enquiry.PropertyId;

                enquiries.Add(e);
            }
            return enquiries;
        }
    }
}
