namespace ApnaGharV2.Models
{
    public class Enquiry:AdditiveInformation
    {
        public int EnquiryID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber  { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }
    }
}
