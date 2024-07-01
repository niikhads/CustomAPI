using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entity.Request;
using WebApplication2.Services.ServicesInterface;

namespace WebApplication2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApplication2.Entity.Dto;

    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var response = _productService.GetAllProducts();
                return Ok(response.Data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            try
            {
                var response = _productService.GetProductById(Id);
                if (response.IsSuccess)
                    return Ok(response.Data);
                else
                    return NotFound(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct( ProductAddDto productAddDto)
        {
            try
            {
                var response = _productService.AddProduct(productAddDto);
                return CreatedAtAction(nameof(GetProductById), new { Id = response.Data }, response); // id yazmaliyam
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int Id,  ProductUpdateDto productUpdateDto)
        {
            try
            {
                var response = _productService.UpdateProduct(Id, productUpdateDto);
                if (response.IsSuccess)
                    return Ok(response.Data);
                else
                    return NotFound(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            try
            {
                var response = _productService.DeleteProduct(Id);
                if (response.IsSuccess)
                    return Ok(response.Data);
                else
                    return NotFound(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
