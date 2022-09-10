namespace ApnaGharV2.Models.Interfaces
{
    public interface IEnquiryRepository
    {
        public bool SubmitEnquiry(Enquiry enquiry);
        public List<Enquiry> GetAllEnquiries();

    }
}
