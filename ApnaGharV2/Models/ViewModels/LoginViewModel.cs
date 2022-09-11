using System.ComponentModel.DataAnnotations;

namespace ApnaGharV2.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is Required")]
        [StringLength(20, ErrorMessage = "Username should not exceed 20 characters")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password, ErrorMessage = "Password must contain an upper-case letter, a lower-case letter and a special character")]
        public string Password { get; set; }
    }
}
