using Company.BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Repositories
{
    public class BuildQuery<T> where T:class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> basepart,ISpecification<T> spec)
        {
            var query = basepart;

            if (spec.WH is not null)
                query = query.Where(spec.WH);

            query = spec.INclude.Aggregate(query, (current, ex) => current.Include(ex));
            
            return query;
        }
    }
}
