using FluentValidation;
using Hooktail.Business.Concrete;
using Hooktail.Business.Interfaces;
using Hooktail.Business.Utility.Jwt;
using Hooktail.Business.Validation;
using Hooktail.DataAccess.Concrete;
using Hooktail.DataAccess.Interfaces;
using Hooktail.Entities.DTOs.ProductDTOs;
using Microsoft.Extensions.DependencyInjection;

namespace Hooktail.Business.Containers
{
    public static class IoCContainer
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped< IUserRepository, UserRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleRepository, RoleRepository>();


            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserRoleRepository,UserRoleRepository>();

            services.AddScoped<IJwtService, JwtService>();

            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();

        }
    }
}
