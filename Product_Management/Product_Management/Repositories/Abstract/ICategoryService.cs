using Product_Management.Models.DTO;

namespace Product_Management.Repositories.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategories();
        Task<int> AddCategory(CategoryModel model);

        Task<CategoryModel> getCategoryById(int id);

        Task<bool> UpdateCategory(CategoryModel model);

        Task<bool> DeleteCategory(int id);
        
    }
}
