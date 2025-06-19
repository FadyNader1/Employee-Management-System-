using Company.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace System_Management.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        public IFormFile? UploadImage { get; set; }
        public string? Image { get; set; }
        [MaxLength(20, ErrorMessage = " first name must be less than 20 characters.")]
        [MinLength(3, ErrorMessage = " first name must be greater than 2 characters.")]
        [Required(ErrorMessage = "first name is required.")]
        public string FirstName { get; set; }
        [MaxLength(20, ErrorMessage = " last name must be less than 20 characters.")]
        [MinLength(3, ErrorMessage = " last name must be greater than 2 characters.")]
        [Required(ErrorMessage = "last name is required.")]
        public string LastName { get; set; }
        [Range(18,50,ErrorMessage ="Age must be between 18 to 50 years")]
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Salary is required.")]
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Date is required.")]
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }

        public int? DepartmentId { get; set; }
        public Department? department { get; set; }
    }
}
