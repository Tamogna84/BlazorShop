using BlazorShop.Models;
using Microsoft.Data.Sqlite;

namespace BlazorShop.Data
{
    public class InDbSQLiteCatalog : IProductRepository
    {
        private readonly AppDbContext _context;

        public InDbSQLiteCatalog(AppDbContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public IReadOnlyCollection<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}