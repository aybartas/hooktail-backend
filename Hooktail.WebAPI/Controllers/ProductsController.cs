using AutoMapper;
using Hooktail.Business.Interfaces;
using Hooktail.Entities.Concrete;
using Hooktail.Entities.DTOs.ProductDTOs;
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
    public class ProductsController : ControllerBase
    {
        readonly IProductService productService;
        readonly IMapper mapper;
        public ProductsController(IProductService productService,IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productEntities = await productService.GetAllAsync();
            var products =  mapper.Map<List<ProductListDto>>(productEntities) ;
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await productService.GetAsync(I => I.Id == id);
            return Ok(mapper.Map<ProductListDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductAddDto productAddDto)
        {
            await productService.AddAsync(mapper.Map<Product>(productAddDto));
            return Created("", productAddDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, ProductUpdateDto productUpdateDto)
        {
            if (productUpdateDto.Id != id)
                return BadRequest("Invalid Product Id");

            await productService.UpdateAsync(mapper.Map<Product>(productUpdateDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteAsync(new Product{Id = id});
            return NoContent();
        }
    }
}
