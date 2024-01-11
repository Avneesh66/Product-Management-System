using Microsoft.EntityFrameworkCore;
using Product_Management.Data;
using Product_Management.Models.Domain;
using Product_Management.Models.DTO;
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
        public async Task<IEnumerable<ProductModel>> getProduct()
        {
            var data = await Product_Context.Products.Select(model => new ProductModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Purchage_Price = model.PurchagePrice,
                Sale_Price = model.SalePrice,
                ImageUrl = model.ImageUrl
            }).ToListAsync();
            return data;
        }

        public async Task<int> AddProduct(ProductModel model)
        {
            if (model != null)
            {
                var data = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    PurchagePrice = model.Purchage_Price,
                    SalePrice = model.Sale_Price,
                    CategoryId = model.CategoryId,
                    ImageUrl=model.ImageUrl

                };

                await Product_Context.Products.AddAsync(data); // Use AddAsync for asynchronous operations
                await Product_Context.SaveChangesAsync();
                return data.Id;
            }

            return 0; 

        }

        public async Task<ProductModel> getProductById(int id)
        {
            var data = await Product_Context.Products.Where(e => e.Id == id).Select(model => new ProductModel
            {
                Id = model.Id,
                Name = model.Name,
                Description=model.Description,
                Purchage_Price=model.PurchagePrice,
                Sale_Price = model.SalePrice,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl
            }).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> UpdateProduct(ProductModel model)
        {

            bool status = false;
            if (model != null)
            {
                var data = new Product()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    PurchagePrice = model.Purchage_Price,
                    SalePrice = model.Sale_Price,
                    CategoryId = model.CategoryId,
                    ImageUrl = model.ImageUrl
                };
                Product_Context.Products.Update(data);
                await Product_Context.SaveChangesAsync();
                status = true;
            }
            return status;
        }

        public async Task<bool> DeleteProduct(int productId)
        {

            var productToDelete = await Product_Context.Products.FindAsync(productId);

            if (productToDelete != null)
            {
                Product_Context.Products.Remove(productToDelete);
                await Product_Context.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
