using BlazorShop.Models;

namespace BlazorShop.Data
{
    public interface IProductRepository
    {
        public IReadOnlyCollection<Product> GetProducts();
        public void AddProduct(Product product);
    }
}