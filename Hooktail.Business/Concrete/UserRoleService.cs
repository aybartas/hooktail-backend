using Hooktail.Business.Interfaces;
using Hooktail.DataAccess.Interfaces;
using Hooktail.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hooktail.Business.Concrete
{
    public class UserRoleService: GenericService<UserRole>, IUserRoleService
    {
        readonly IGenericRepository<UserRole> genericRepository;
        readonly IGenericRepository<User> userRepository;
        readonly IRoleService roleService;

        public UserRoleService(IGenericRepository<UserRole> genericRepository,IGenericRepository<User> userRepository, IRoleService roleService) : base(genericRepository)
        {
            this.genericRepository = genericRepository;
            this.userRepository = userRepository;
            this.roleService = roleService;
        }

        public async Task<List<Role>> GetUserRolesByUsername(string username)
        {
            var user = userRepository.GetAsync(I => I.Username == username);
            var roleList = new List<Role>();
            List<Role> roles = new List<Role>();
            if(user != null)
            {
                var userRoles = await genericRepository.GetAsync(I => I.UserId == user.Id);

                roleList = (List<Role>)userRoles.Select(async userRole =>{
                    var roleName = await roleService.GetRoleById(userRole.RoleId);
                    var role = new Role { Id = userRole.RoleId, Name = roleName };
                    return role;});
            } 
            return roleList;
        }
    }
}
