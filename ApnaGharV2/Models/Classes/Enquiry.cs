using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApnaGharV2.Models
{
    public class Enquiry:AdditiveInformation
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber  { get; set; }
        public string Message { get; set; }
        public int PropertyId { get; set; }             //about which property this enquiry is
        public int UserId { get; set; }
    }
}
