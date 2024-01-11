using Microsoft.EntityFrameworkCore;
using Product_Management.Data;
using Product_Management.Models.Domain;
using Product_Management.Models.DTO;
using Product_Management.Repositories.Abstract;
using static System.Reflection.Metadata.BlobBuilder;

namespace Product_Management.Repositories.Implementation
{
    public class CategoryService:ICategoryService
    {

        private readonly ProductManagementDbContext _context;
        public CategoryService(ProductManagementDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            // Use meaningful method names; it's better to use the plural form for collection retrieval
            var data = await _context.Categories.Select(model => new CategoryModel {
                Id = model.Id,
                Name=model.Name
             }).ToListAsync();

            return data;
        }

        public async Task<int> AddCategory(CategoryModel model)
        {
            if (model != null)
            {
                var data = new Category()
                {
                   Name=model.Name
                };
                await _context.Categories.AddAsync(data); // Use AddAsync for asynchronous operations
                await _context.SaveChangesAsync();
                return data.Id;
            }

            return 0; // Return a default value or throw an exception in case of a null category

        }

        public async Task<CategoryModel> getCategoryById(int id)
        {
            var data =await _context.Categories.Where(e => e.Id == id).Select(model => new CategoryModel
            {
                Id = model.Id,
                Name = model.Name
            }).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> UpdateCategory(CategoryModel model)
        {
           
            bool status = false;
            if (model != null)
            {
                var data = new Category()
                {
                    Name = model.Name
                };
                _context.Categories.Update(data);
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
