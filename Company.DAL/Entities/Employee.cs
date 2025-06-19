using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public string Address { get; set; }

        public  string Email{ get; set; }

        public  string? Image{ get; set; }

        public  string PhoneNumber{ get; set; }

        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department? department { get; set; }

    }
}
