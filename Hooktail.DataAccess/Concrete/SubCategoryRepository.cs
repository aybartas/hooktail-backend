using Hooktail.DataAccess.Context;
using Hooktail.DataAccess.Interfaces;
using Hooktail.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.DataAccess.Concrete
{
    public class SubCategoryRepository : GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public async Task<List<SubCategory>> GetAllWithProducts()
        {
            using var context = new HooktailContext();
            return await context.SubCategories.Include(I =>I.Products).ToListAsync();
        }
    }
}
