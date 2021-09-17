﻿using Hooktail.Business.Interfaces;
using Hooktail.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Business.Concrete
{
    public class GenericService<T> : IGenericService<T>  where T : class
    {

        IGenericRepository<T> genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddAsync(T entity)
        {
            await genericRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await genericRepository.DeleteAsync(entity);
        }

        public async Task<T> FindById(int id)
        {
           return  await genericRepository.FindByIdAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await genericRepository.GetAllAsync();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await genericRepository.GetAsync(filter);
        }

        public async Task UpdateAsync(T entity)
        {
            await genericRepository.UpdateAsync(entity);
        }
    }
}
