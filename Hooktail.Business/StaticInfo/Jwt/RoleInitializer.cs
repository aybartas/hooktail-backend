using Hooktail.Business.Interfaces;
using Hooktail.Entities.Concrete;
using System.Threading.Tasks;

namespace Hooktail.Business.StaticInfo.Jwt
{
    public static class RoleInitializer
    {
        public static async Task InitializeRoles(
            IUserService userService,
            IUserRoleService userRoleService,
            IRoleService roleService)
        {
            var adminRole = roleService.GetAsync(I => I.Name == Roles.RoleInfo.Admin);
            var userRole = roleService.GetAsync(I => I.Name == Roles.RoleInfo.User);

            if (adminRole == null)
            {
                var role = new Role { Id = 1, Name = Roles.RoleInfo.Admin };
                await roleService.AddAsync(role);
            }
            if (userRole == null)
            {
                var role = new Role { Id = 2, Name = Roles.RoleInfo.User };
                await roleService.AddAsync(role);
            }

            await userService.AddAsync(new User { Username = "admin", Password = "12345" });
            var user = userService.GetUserByUsername("admin");
            await userRoleService.AddAsync(new UserRole { RoleId = 1, UserId = user.Id });

        }
    }
}
