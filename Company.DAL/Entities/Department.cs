using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Department_Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();

    }
}
