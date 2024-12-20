﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApnaGharV2.Models.Classes;
using ApnaGharV2.Models;

namespace ApnaGharV2.Models.ViewModels
{
    public class RegisterViewModel
    {
        public List<string> Roles { get; set; }

        public RegisterViewModel()
        {
            Roles = new List<string>() { "Admin", "User" };
        }
    
        [Required(ErrorMessage = "Choose the Role")]
        public string Role { get; set; }


        [Required(ErrorMessage = "Username is Required")]
        [StringLength(20, ErrorMessage = "Username should not exceed 20 characters")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password, ErrorMessage = "Password must contain an upper-case letter, a lower-case letter and a special character")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password must match with Password")]
        public string ConfirmPassword { get; set; }


        public User User { get; set; } = new User();            //all data of user also

        public IFormFile? ProfileImage { get; set; }

    }
}
