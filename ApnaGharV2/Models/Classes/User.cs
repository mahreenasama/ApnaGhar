using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApnaGharV2.Models.Classes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace ApnaGharV2.Models.Classes
{
    public class User: FullAuditModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Email must be in proper format")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Phone Number is Required")]
        [StringLength(10, ErrorMessage = "Enter a valid phone number")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }


        [Column(TypeName ="nvarchar(10)")]
        public string? Role { get; set; }

        [NotMapped]
        public IFormFile? ProfileImage { get; set; }


        //------------- for relations -------------

        //-- for properties
        //public virtual List<Property>? Properties { get; set; } = new List<Property>();

        //-- for favourites
        public virtual List<Property>? UserFavouriteProperties { get; set; } = new List<Property>();
    }
}
