using Company.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Repositories
{
    public class DepartmentSpecification:BaseSpecification<Department>
    {
        public DepartmentSpecification(string? name)
        {

            if (!string.IsNullOrEmpty(name))
                WH = x => x.Department_Name.ToLower() == name.ToLower();

        }
        public DepartmentSpecification(int id):base(x=>x.Id==id)
        {
            
        }
    }
}
