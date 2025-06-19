using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Interfaces
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllSpecAsync(ISpecification<T> spec);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdSpecAsync(ISpecification<T> spec);
        Task AddAsync(T item);
        void Update(T item);
        void Delete(T item);

    }
}
