using ApnaGharV2.Models.Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApnaGharV2.Models.Classes
{
    public class Enquiry: FullAuditModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber  { get; set; }
        public string Message { get; set; }

        //------------foreign key relations------------
        //public virtual
    }
}
