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
            var adminRole = await roleService.GetAsync(I => I.Name == Roles.RoleInfo.Admin);
            var userRole = await roleService.GetAsync(I => I.Name == Roles.RoleInfo.User);

            if (adminRole.Count == 0)
            {
                var role = new Role {  Name = Roles.RoleInfo.Admin };
                await roleService.AddAsync(role);
            }
            if (userRole.Count == 0)
            {
                var role = new Role { Name = Roles.RoleInfo.User };
                await roleService.AddAsync(role);
            }

            await userService.AddAsync(new User { Username = "admin", Password = "12345" });
            var user = await userService.GetUserByUsername("admin");

            await userRoleService.AddAsync(new UserRole { RoleId = adminRole[0].Id, UserId = user.Id });

        }
    }
}
