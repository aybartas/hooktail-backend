using Hooktail.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hooktail.DataAccess.Interfaces
{
    public interface ISubCategoryRepository: IGenericRepository<SubCategory>
    {

        Task<List<SubCategory>> GetAllWithProducts();
    }
}
