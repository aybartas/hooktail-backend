using Hooktail.DataAccess.Context;
using Hooktail.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hooktail.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        public async Task AddAsync(T entity)
        {
            using var context = new HooktailContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            using var context = new HooktailContext();
            context.Remove<T>(entity);
            await context.SaveChangesAsync(); 
        }

        public async Task<List<T>> GetAllAsync()
        {
            using var context = new HooktailContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new HooktailContext();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new HooktailContext();
            context.Update<T>(entity);
            await context.SaveChangesAsync();
        }
    }
}
