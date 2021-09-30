using Hooktail.Business.Interfaces;
using Hooktail.DataAccess.Interfaces;
using Hooktail.Entities.Concrete;

namespace Hooktail.Business.Concrete
{
    public class UserRoleService: GenericService<UserRole>, IUserRoleService
    {
        readonly IGenericRepository<UserRole> genericRepository;

        public UserRoleService(IGenericRepository<UserRole> genericRepository): base(genericRepository)
        {
            this.genericRepository = genericRepository;
        }


    }
}
