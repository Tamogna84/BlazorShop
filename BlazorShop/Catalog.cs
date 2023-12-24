namespace BlazorShop
{
	public class Catalog
	{
		private readonly List<Product> _product= new()
		{
			new Product{Id = 1, Name ="Чистый код", Price = 235},
			new Product{Id = 2, Name ="Элегантные объекты", Price = 300}
		};

		public Product[] GetProducts()
		{
			return _product.ToArray();
		}
       

        public void AddProduct(Product product)
        {
            product.Id = _product.Count + 1; // Устанавливаем уникальный ID для нового продукта
            _product.Add(product); // Добавляем новый продукт в список продуктов
        }
    }

	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
	}
}
