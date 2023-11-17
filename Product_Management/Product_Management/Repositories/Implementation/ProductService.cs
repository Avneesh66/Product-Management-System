using Microsoft.EntityFrameworkCore;
using Product_Management.Data;
using Product_Management.Models.Domain;
using Product_Management.Repositories.Abstract;

namespace Product_Management.Repositories.Implementation
{
    public class ProductService:IProductService
    {
        private readonly ProductManagementDbContext Product_Context;
        public ProductService(ProductManagementDbContext context)
        {
            Product_Context = context;

        }
        public async Task<IEnumerable<Models.Domain.Product>> getProduct()
        {
            var data = await Product_Context.TblProducts.ToListAsync();
            return data;
        }

        public async Task<int> AddProduct(Models.Domain.Product product)
        {
            if (product != null)
            {
                await Product_Context.TblProducts.AddAsync(product); // Use AddAsync for asynchronous operations
                await Product_Context.SaveChangesAsync();
                return product.Id; // Use category.Id instead of Category.Id
            }

            return 0; // Return a default value or throw an exception in case of a null category

        }

        public async Task<Models.Domain.Product> getProductById(int id)
        {
            var data = await Product_Context.TblProducts.Where(e => e.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> UpdateProduct(Models.Domain.Product product)
        {

            bool status = false;
            if (product != null)
            {
                Product_Context.TblProducts.Update(product);
                await Product_Context.SaveChangesAsync();
                status = true;
            }
            return status;
        }

        public async Task<bool> DeleteProduct(int productId)
        {

            var productToDelete = await Product_Context.TblProducts.FindAsync(productId);

            if (productToDelete != null)
            {
                Product_Context.TblProducts.Remove(productToDelete);
                await Product_Context.SaveChangesAsync();
                return true;
            }

            return false; // Category with the given ID not found
        }

    }
}
