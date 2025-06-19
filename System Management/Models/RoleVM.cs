using System.ComponentModel.DataAnnotations;

namespace System_Management.Models
{
    public class RoleVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="pleace enter role name")]
        public string Name { get; set; }
        public RoleVM()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
