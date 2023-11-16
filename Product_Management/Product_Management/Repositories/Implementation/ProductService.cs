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
        public async Task<IEnumerable<Product>> getProduct()
        {
            var data = await Product_Context.TblProducts.ToListAsync();
            return data;
        }

        public async Task<int> AddProduct(Product product)
        {
            if (product != null)
            {
                await Product_Context.TblProducts.AddAsync(product); // Use AddAsync for asynchronous operations
                await Product_Context.SaveChangesAsync();
                return product.Id; // Use category.Id instead of Category.Id
            }

            return 0; // Return a default value or throw an exception in case of a null category

        }

    }
}
