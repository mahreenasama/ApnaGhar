using System.ComponentModel.DataAnnotations;
using ApnaGharV2.Models.Classes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ApnaGharV2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }

        //----- audit info added here manually (bcz we cant have multiple base classes)--------
        public string? CreatedByUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }


        //------------adding foreign key relation ships-----------
        //public virtual List<PropertyInfo>? Properties { get; set; } = new List<PropertyInfo>();
    }
}
