using Company.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Repositories
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> WH { get; set; }
        public List<Expression<Func<T, object>>> INclude { get; set; }
        public BaseSpecification()
        {
            INclude = new List<Expression<Func<T, object>>>();
        }
        public BaseSpecification(Expression<Func<T, bool>> WH)
        {
            INclude = new List<Expression<Func<T, object>>>();
            this.WH = WH;
        }
    }
}
