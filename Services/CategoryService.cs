using System.Diagnostics.Eventing.Reader;
using WebApplication2.Entity.Dto;
using WebApplication2.Entity.Model;
using WebApplication2.Entity.Request;
using WebApplication2.Entity.Response;
using WebApplication2.Repositories.IRepositories;
using WebApplication2.Services.ServicesInterface;


namespace WebApplication2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseBaseColumn> GetAll()
        {
                IEnumerable<Category> categories;
            try
            {

                categories = await _categoryRepository.GetAll();
            }
            catch (Exception ex)
            {

                //var response = new ResponseBaseColumn();
                //  response = new ResponseBaseColumn
                return new ResponseBaseColumn()
                {
                  //  Data = categories,
                    IsSuccess = false,
                    Message = "Category retrieved unlucky",
                    Status = "500"
                };


               // return response;
            }
            return new ResponseBaseColumn()
            {
                Data = categories,  
                IsSuccess = true,
                Message = "Category retrieved successfully",
                Status = "200"
            };
        }


        public async Task<ResponseBaseColumn> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryRepository.GetByCategoryId(id);

                if (category == null)
                {
                    return new ResponseBaseColumn
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Category not found",
                        Status = "404"
                    };
                }

                var categoryResponse = new CategoryResponse
                {
                    id = category.id,
                    Name = category.Name
                    
                };

                return new ResponseBaseColumn
                {
                    Data = categoryResponse,
                    IsSuccess = true,
                    Message = "Category retrieved successfully",
                    Status = "200"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching category with ID: {id}. Exception: {ex.Message}");

                throw new Exception($"Error occurred while fetching category with ID: {id}", ex);
            }
        }



        public async Task<ResponseBaseColumn> AddCategory(CategoryRequest categoryRequest)
        {
            try
            {
                var category = new Category
                {
                    Name = categoryRequest.Name
                };

                var insertedCategory = await _categoryRepository.Insert(categoryRequest);

                if (insertedCategory == null)
                {
                    return new ResponseBaseColumn
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Failed to add category",
                        Status = "500"
                    };
                }

                var categoryResponse = new CategoryResponse
                {
                     id = insertedCategory.id,
                    Name = insertedCategory.Name
                };

                return new ResponseBaseColumn
                {
                    Data = categoryResponse,
                    IsSuccess = true,
                    Message = "Category added successfully",
                    Status = "200"
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding category", ex);
            }
        }

        public async Task<ResponseBaseColumn> UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                var existingCategory = await _categoryRepository.GetByCategoryId(id);

                if (existingCategory == null)
                {
                    return new ResponseBaseColumn
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Category not found",
                        Status = "404"
                    };
                }
                else {
                    existingCategory.Name = categoryUpdateDto.Name;

                    var updatedCategory = await _categoryRepository.Update(categoryUpdateDto);

                    var categoryResponse = new CategoryResponse
                    {
                        //  id = updatedCategory.Id,
                        Name = updatedCategory.Name
                    };

                    return new ResponseBaseColumn
                    {
                        Data = categoryResponse,
                        IsSuccess = true,
                        Message = "Category updated successfully",
                        Status = "200"
                    };
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while updating category with ID: {id}", ex);
            }
        }





        public async Task<ResponseBaseColumn> DeleteCategory(int id)
        {
            try
            {
                var category = _categoryRepository.GetByCategoryId(id);

                if (category == null)
                {
                    return new ResponseBaseColumn
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Category not found",
                        Status = "404"
                    };
                }

                _categoryRepository.Delete(id);

                var categoryResponse = new CategoryResponse
                {
                    id = category.Id,
                    Name = category.Result.Name
                };

                return new ResponseBaseColumn
                {
                    Data = categoryResponse,
                    IsSuccess = true,
                    Message = "Category deleted successfully",
                    Status = "200"
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting category with ID: {id}", ex);
            }
        }

       
    }

}