namespace ApnaGharV2.Models
{
    public class AdditiveInformation
    {
        //------ additive information -------------
        public int CreatedBy { get; set; }              //who created the row and at which date
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }             //who modified the row and at which date
        public DateTime? ModifiedDate { get; set; }
    }
}
