using BlazorShop.Data;
using BlazorShop.Models;

namespace BlazorShop.Services
{
    public class ProductService // анемичная модель
    {
        private readonly IProductRepository _productRepository;

        private readonly IClock _nowTime;
        private readonly DayOfWeek _discountDay;

        public ProductService(IProductRepository catalog)
        {
            _productRepository = catalog ?? throw new ArgumentNullException(nameof(catalog));
            _nowTime = new NowTime();
            _discountDay = DayOfWeek.Sunday; // присвоение дня скидки
        }

        public IReadOnlyCollection<Product> GetProducts()
        {
            if (_nowTime.DayOfWeek == _discountDay)
            {
                var products = _productRepository.GetProducts();
                var newProducts = products.Select(product => new Product()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price - product.Price * 0.1m
                }).ToList();

                return newProducts;
            }
            else
            {
                return _productRepository.GetProducts();
            }
        }
    }
}
