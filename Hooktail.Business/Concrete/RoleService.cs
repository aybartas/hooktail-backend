using Hooktail.Business.Interfaces;
using Hooktail.DataAccess.Interfaces;
using Hooktail.Entities.Concrete;
using System.Threading.Tasks;

namespace Hooktail.Business.Concrete
{
    public class RoleService: GenericService<Role>,IRoleService
    {
        readonly IGenericRepository<Role> genericRepository;

        public RoleService(IGenericRepository<Role> genericRepository) : base(genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<string> GetRoleById(int id)
        {
            var role = await genericRepository.FindByIdAsync(id);
            return role.Name ?? string.Empty;
        }
    }
}
