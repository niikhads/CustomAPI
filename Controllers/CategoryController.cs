namespace WebApplication2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using WebApplication2.Entity.Dto;
    using WebApplication2.Entity.Request;
    using WebApplication2.Entity.Response;
    using WebApplication2.Services;
    using WebApplication2.Services.ServicesInterface;

    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = _categoryService.GetAll();
                return Ok(response.Result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetCategoryByİd(int id)
        {
            try
            {
                var response = _categoryService.GetCategoryById(id);
                if (response.Result.IsSuccess)
                    return Ok(response.Result);
                else
                    return NotFound(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task <IActionResult> AddCategory( CategoryRequest categoryRequest)
        {
            try
            {
                var response = _categoryService.AddCategory(categoryRequest);
                if (response.Result.IsSuccess)
                    return Ok(response.Result);
                else
                    return NotFound(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCategory(int id,  CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                var response = _categoryService.UpdateCategory(id, categoryUpdateDto);
                if (response.Result.IsSuccess)
                    return Ok(response.Result);
                else
                    return NotFound(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var response = _categoryService.DeleteCategory(id);
                if (response.Result.IsSuccess)
                    return Ok(response.Result);
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

