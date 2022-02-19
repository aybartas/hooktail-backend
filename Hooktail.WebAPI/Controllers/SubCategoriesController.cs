using AutoMapper;
using Hooktail.Business.Interfaces;
using Hooktail.Entities.Concrete;
using Hooktail.Entities.DTOs.SubCategoryDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hooktail.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        readonly IMapper mapper;
        ISubCategoryService subCategoryService;

        public SubCategoriesController(ISubCategoryService subCategoryService, IMapper mapper)
        {
            this.mapper = mapper;
            this.subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subCategories = await subCategoryService.GetSubCategoriesWithProducts();
            var subCategoriesDto = mapper.Map<List<SubCategoryListDto>>(subCategories);

            return Ok(subCategoriesDto);
        }

    }
}
 