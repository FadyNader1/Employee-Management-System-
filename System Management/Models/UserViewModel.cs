using Company.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace System_Management.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
  
        public string LastName { get; set; }

        public string UserName { get; set; }

    
        public string Email { get; set; }
 
        public string PhoneNumber { get; set; }
      
     
        public IEnumerable<string>? Roles { get; set; }
    }
}
