using Product_Management.Models.Domain;

namespace Product_Management.Repositories.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> getCategory();
        Task<int> AddCategory(Category category);
    }
}
