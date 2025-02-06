using MyCRUDApi.MyCRUDApi.Domain.Entities;

namespace MyCRUDApi.MyCRUDApi.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(Product product);  // ✅ No method body
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
