using System.ComponentModel.DataAnnotations;

namespace System_Management.Models
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }
        public string Token { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string New_Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("New_Password", ErrorMessage = "This password not match")]
        public string Confirm_Password { get; set; }
    }
}
