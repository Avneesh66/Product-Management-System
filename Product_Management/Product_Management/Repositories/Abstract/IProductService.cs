using Product_Management.Models.Domain;

namespace Product_Management.Repositories.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> getProduct();
        Task<int> AddProduct(Product product);
        Task<Product> getProductById(int id);

        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProduct(int id);
    }

}
