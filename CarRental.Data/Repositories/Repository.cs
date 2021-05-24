using CarRental.Core.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRental.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        protected readonly CarContext DbContext;

        public Repository(CarContext dbContext)
        {
            DbContext = dbContext;
        }
       
        public IQueryable<T> All()
        {
            try
            {
                return DbContext.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"No result found: {ex.Message}");
            }
        }

        public async Task<T> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await DbContext.AddAsync(entity);
                await DbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }
       
        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                DbContext.Update(entity);
                await DbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Where(expression);
        }
    }
}
