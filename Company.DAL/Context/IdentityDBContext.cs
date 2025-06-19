using Company.DAL.Entities.identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Context
{
    public class IdentityDBContext:IdentityDbContext<AppUser>
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options):base(options)
        {
            
        }



    }
}
