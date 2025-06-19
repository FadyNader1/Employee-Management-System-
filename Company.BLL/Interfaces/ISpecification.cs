using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Interfaces
{
    public interface ISpecification<T> where T:class
    {
       Expression<Func<T,bool>> WH { get; set; }
        List<Expression<Func<T, object>>> INclude { get; set; }
    }
}
