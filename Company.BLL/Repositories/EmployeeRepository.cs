using Company.BLL.Interfaces;
using Company.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Repositories
{
    public class EmployeeRepository:GenericRepository<EmployeeRepository>
    {
        public EmployeeRepository(CompanyDbContext db):base(db)
        {
            
        }

    }
}
