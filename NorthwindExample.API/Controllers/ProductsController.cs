﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindExample.Core.DTOs;
using NorthwindExample.Core.Models;
using NorthwindExample.Core.Services;

namespace NorthwindExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products=await _productService.GetAllAsync();
            var productsDto=_mapper.Map<List<ProductDto>>(products.ToList());
            return Ok(products.ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product= await _productService.GetByIdAsync(id);           
            return Ok(_mapper.Map<ProductDto>(product));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            var newProduct = await _productService.AddAsync(product);
            return Ok(_mapper.Map<ProductDto>(newProduct));
           // return Created("",_mapper.Map<ProductDto>(newProduct));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);
            return NoContent();
        }
        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            var products = await _productService.GetProductsWithCategory();

            return Ok(products);
        }
    }
}
