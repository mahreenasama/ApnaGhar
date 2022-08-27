using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApnaGharV2.Models;

namespace ApnaGharV2
{
    public partial class User:AdditiveInformation
    {
        public int UserID { get; set; }


        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Email must be in proper format")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password, ErrorMessage = "Password must contain an upper-case letter, a lower-case letter and a special character")]
        [StringLength(8, ErrorMessage = "Password must be 8 characters long")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [StringLength(8)]
        [Compare("Password", ErrorMessage = "Confirm Password must match with Password")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Phone Number is Required")]
        [StringLength(10, ErrorMessage = "Enter a valid phone number")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Country is Required")]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Choose your Role")]
        public string Role { get; set; } = null!;
    }
}
