using Hooktail.Business.Concrete;
using Hooktail.Business.Interfaces;
using Hooktail.Business.Utility.Jwt;
using Hooktail.DataAccess.Concrete;
using Hooktail.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            services.AddScoped<IJwtService, JwtService>();
        }
    }
}
