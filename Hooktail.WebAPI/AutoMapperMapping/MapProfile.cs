using AutoMapper;
using Hooktail.Entities.Concrete;
using Hooktail.Entities.DTOs.CategoryDTOs;
using Hooktail.Entities.DTOs.ProductDTOs;
using Hooktail.Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hooktail.WebAPI.AutoMapperMapping
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<ProductListDto, Product>();
            CreateMap<Product, ProductListDto>();

            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductAddDto>();

            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product,ProductUpdateDto>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserLoginDto>();

            CreateMap<ActiveUserDto, User>();
            CreateMap<User, ActiveUserDto>();
        }
    }
}
