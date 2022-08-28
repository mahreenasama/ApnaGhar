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
    }
}
