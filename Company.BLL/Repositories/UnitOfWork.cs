using Company.BLL.Interfaces;
using Company.DAL.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Hashtable _repositories;
        private readonly CompanyDbContext dbContext;

        public UnitOfWork(CompanyDbContext dbContext)
        {
            _repositories = new Hashtable();
            this.dbContext = dbContext;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<T>(dbContext);
                _repositories.Add(type, repository);

            }
            return _repositories[type] as IGenericRepository<T>;
        }
        public async Task<int> Complete()
        {
         return   await dbContext.SaveChangesAsync();
        }
    }
}
