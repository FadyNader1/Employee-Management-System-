using Company.BLL.Interfaces;
using Company.DAL.Context;
using Company.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Repositories
{
    public class DepartmentRepository:GenericRepository<Department>,IDepartmentRepository
    {

        public DepartmentRepository(CompanyDbContext db):base(db)
        {
        }

   
    }
}
