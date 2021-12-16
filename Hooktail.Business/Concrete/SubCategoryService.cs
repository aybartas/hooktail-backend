using Hooktail.Business.Interfaces;
using Hooktail.DataAccess.Interfaces;
using Hooktail.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.Business.Concrete
{
    public class SubCategoryService : GenericService<SubCategory>, ISubCategoryService
    {
        readonly IGenericRepository<SubCategory> genericRepository;
        readonly ISubCategoryRepository subcategoryRepository;

        public SubCategoryService(IGenericRepository<SubCategory> genericRepository, ISubCategoryRepository subcategoryRepository) : base(genericRepository)
        {
            this.genericRepository = genericRepository;
            this.subcategoryRepository = subcategoryRepository;
        }

        public async Task<List<SubCategory>> GetSubCategoriesWithProducts()
        {
            return await subcategoryRepository.GetAllWithProducts();
        }
    }
}
