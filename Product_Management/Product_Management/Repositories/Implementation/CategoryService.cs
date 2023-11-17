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
        public async Task<IEnumerable<Models.Domain.Category>> getCategory()
        {
            var data=await _context.Categories.ToListAsync();
            return data;
        }

        public async Task<int> AddCategory(Models.Domain.Category category)
        {
            if (category != null)
            {
                await _context.Categories.AddAsync(category); // Use AddAsync for asynchronous operations
                await _context.SaveChangesAsync();
                return category.Id; // Use category.Id instead of Category.Id
            }

            return 0; // Return a default value or throw an exception in case of a null category

        }

        public async Task<Models.Domain.Category> getCategoryById(int id)
        {
            var data =await  _context.Categories.Where(e => e.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> UpdateCategory(Models.Domain.Category category)
        {
           
            bool status = false;
            if (category != null)
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                status = true;
            }
            return status;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
           
            var categoryToDelete = await _context.Categories.FindAsync(categoryId);

            if (categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false; // Category with the given ID not found
        }


    }
}
