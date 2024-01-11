using BlazorShop.Models;

namespace BlazorShop.Data
{
    public class InMemoryCatalog : IProductRepository
    {
        private readonly List<Product> products = new()
        {
            new Product{Id = 1, Name = "Clean Code", Price = 1000 },
            new Product{Id = 2, Name = "Elegant objects", Price = 2000 }
        };
        public IReadOnlyCollection<Product> GetProducts()
        {
            return products;
        }
        public void AddProduct(Product product)
        {
            product.Id = products.Count + 1; // Устанавливаем уникальный ID для нового продукта
            products.Add(product); // Добавляем новый продукт в список продуктов
        }
    }

}
