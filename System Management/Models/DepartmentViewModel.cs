using System.ComponentModel.DataAnnotations;

namespace System_Management.Models
{
    public class DepartmentViewModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30,ErrorMessage ="The code must be less than 30 characters.")]
        [MinLength(3,ErrorMessage = "The code must be greater than 2 characters.")]
        [Required(ErrorMessage ="The code is required.")]
        public string Code { get; set; }
        [MaxLength(30, ErrorMessage = "The department name must be less than 30 characters.")]
        [MinLength(2, ErrorMessage = "The department name must be greater than 1 character.")]
        [Required(ErrorMessage = "The department name is required.")]
        public string Department_Name { get; set; }
        [Required(ErrorMessage = "The date name is required.")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
    }
}
