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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CompanyDbContext dbContext;

        public GenericRepository(CompanyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        private IQueryable<T> ApplyEvaluator(ISpecification<T> spec)
        {
            return BuildQuery<T>.GetQuery(dbContext.Set<T>(), spec);
        }
        public async Task AddAsync(T item)
        {
             await dbContext.Set<T>().AddAsync(item);
        }

        public void Delete(T item)
        {
            dbContext.Set<T>().Remove(item);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllSpecAsync(ISpecification<T> spec)
        {
            return await ApplyEvaluator(spec).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
                return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdSpecAsync(ISpecification<T> spec)
        {
            return await ApplyEvaluator(spec).FirstOrDefaultAsync();
        }

        public void Update(T item)
        {
            dbContext.Set<T>().Update(item);
        }


    }
}
