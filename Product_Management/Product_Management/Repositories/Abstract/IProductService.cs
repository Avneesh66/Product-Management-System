using Product_Management.Models.DTO;

namespace Product_Management.Repositories.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> getProduct();
        Task<int> AddProduct(ProductModel product);
        Task<ProductModel> getProductById(int id);

        Task<bool> UpdateProduct(ProductModel product);

        Task<bool> DeleteProduct(int id);
    }

}
