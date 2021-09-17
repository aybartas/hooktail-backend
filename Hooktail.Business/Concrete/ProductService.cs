
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
    public class ProductService : GenericService<Product>, IProductService
    {
        readonly IGenericRepository<Product> genericRepository;

        public ProductService(IGenericRepository<Product> genericRepository) : base(genericRepository)
        {
            this.genericRepository = genericRepository;
        }


    }
}
