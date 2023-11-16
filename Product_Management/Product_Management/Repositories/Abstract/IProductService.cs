using Product_Management.Models.Domain;

namespace Product_Management.Repositories.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> getProduct();
        Task<int> AddProduct(Product product);
    }
}
