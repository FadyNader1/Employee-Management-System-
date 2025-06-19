using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Entities.identity
{
    public class AppUser:IdentityUser
    {
        public string FName { get; set; }

        public string LName { get; set; }




    }
}
