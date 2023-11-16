using Microsoft.EntityFrameworkCore;
using Product_Management.Data;
using Product_Management.Models.Domain;
using Product_Management.Repositories.Abstract;

namespace Product_Management.Repositories.Implementation
{
    public class CategoryService:ICategoryService
    {

        private readonly ProductManagementDbContext _context;
        public CategoryService(ProductManagementDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Category>> getCategory()
        {
            var data=await _context.Categories.ToListAsync();
            return data;
        }

        public async Task<int> AddCategory(Category category)
        {
            if (category != null)
            {
                await _context.Categories.AddAsync(category); // Use AddAsync for asynchronous operations
                await _context.SaveChangesAsync();
                return category.Id; // Use category.Id instead of Category.Id
            }

            return 0; // Return a default value or throw an exception in case of a null category

        }
    }
}
