using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Interfaces
{
    public interface IEmailServic
    {
        public Task SendEmailAsync(string to,string subject,string body);
    }
}
