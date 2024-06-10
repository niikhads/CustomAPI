using System.Diagnostics.Eventing.Reader;
using WebApplication2.Entity.Model;
using WebApplication2.Entity.Request;
using WebApplication2.Entity.Response;
using WebApplication2.Repositories.IRepositories;
using WebApplication2.Services.ServicesInterface;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace WebApplication2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public List<ResponseBaseColumn> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            var responseList = new List<ResponseBaseColumn>();

            foreach (var category in categories)
            {
                var categoryResponse = new CategoryResponse
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };

                responseList.Add(new ResponseBaseColumn
                {
                    Data = categoryResponse,
                    IsSuccess = true,
                    Message = "Category retrieved successfully",
                    Status = "200"
                });
            }

            return responseList;
        }


        public ResponseBaseColumn GetCategoryById(int CategoryId)
             {
                  var category = _categoryRepository.GetByCategoryId(CategoryId);
            if (category == null)
            {
                return new ResponseBaseColumn
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Code is not running",
                    Status = "404"
                };
               
            }
            else
            {
                return new ResponseBaseColumn
                {
                    Data = category,
                    IsSuccess = true,
                    Message = "Code is  running",
                    Status = "200"
                };
            }
        }



        CategoryResponse ICategoryService.AddCategory(CategoryRequest categoryRequest)
        {
            var category = new Category
            {
                CategoryName = categoryRequest.CategoryName,

            };

            _categoryRepository.Insert(category);
        }

        CategoryResponse DeleteCategory(int CategoryId)
        {
            _categoryRepository.Delete(CategoryId);
        }

         

     
        

        CategoryResponse ICategoryService.UpdateCategory(int CategoryId, CategoryRequest categoryRequest)
        {
            var category = new Category
            {
                CategoryId = CategoryId,
                CategoryName = categoryRequest.CategoryName,

            };

            _categoryRepository.Update(category);
        }
    }
}
