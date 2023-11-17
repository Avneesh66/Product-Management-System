using Product_Management.Models.Domain;

namespace Product_Management.Repositories.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> getCategory();
        Task<int> AddCategory(Category category);

        Task<Category> getCategoryById(int id);

        Task<bool> UpdateCategory(Category category);

        Task<bool> DeleteCategory(int id);
    }
}
