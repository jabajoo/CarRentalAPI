using CarRental.Core.Entities;
using CarRental.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Repositories
{
    public class LocalRepository<T> : IRepository<T> where T : class, new()
    {
        private List<T> _collection;

        public LocalRepository()
        {
            _collection = new List<T>();
        }
        public Task<T> AddAsync(T entity)
        {
            _collection.Add(entity);
            return null; 
            
        }

        public IQueryable<T> All()
        {
            return _collection.AsQueryable();
        }

        public Task<T> UpdateAsync(T entity)
        {
            _collection.Remove(entity);
            _collection.Add(entity);

            return null;
        }

        public IQueryable<T> Where(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _collection.AsQueryable().Where(expression).AsQueryable();
        }
    }
}
