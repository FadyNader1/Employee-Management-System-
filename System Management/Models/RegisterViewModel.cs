using System.ComponentModel.DataAnnotations;

namespace System_Management.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="First name is required")]
        [MaxLength(20,ErrorMessage ="First name must be less than 20 characters")]
        [MinLength(3,ErrorMessage ="First name must be greater than 2 charsacters")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(20, ErrorMessage = "Last name must be less than 20 characters")]
        [MinLength(3, ErrorMessage = "Last name must be greater than 2 charsacters")]
        public string LNmae { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone numberl is required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="This password not match")]
        public string Confirm_Password { get; set; }



    }
}
