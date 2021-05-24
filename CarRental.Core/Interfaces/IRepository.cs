using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Core.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> All();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

       Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
