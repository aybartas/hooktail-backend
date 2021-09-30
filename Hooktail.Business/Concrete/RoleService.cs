using Hooktail.Business.Interfaces;
using Hooktail.DataAccess.Interfaces;
using Hooktail.Entities.Concrete;

namespace Hooktail.Business.Concrete
{
    public class RoleService: GenericService<Role>,IRoleService
    {
        readonly IGenericRepository<Role> genericRepository;

        public RoleService(IGenericRepository<Role> genericRepository) : base(genericRepository)
        {
            this.genericRepository = genericRepository;
        }

    }
}
