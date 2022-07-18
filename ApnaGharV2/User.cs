using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApnaGharV2
{
    public partial class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(8)]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(8)]
        [Compare("Password", ErrorMessage = "The two passwords not match")]
        public string ConfirmPassword { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!;
    }
}
