using Supermarket.Core.Interfaces;
using Supermarket.Core.Models;

namespace Supermarket.DataAccess
{
    public class ProductService : IProductService
    {
        // normally this would come from database or another service
        private Dictionary<string, Product> _catalog = new()
        {
            { "A", new Product("A", 50) },
            { "B", new Product("B", 30) },
            { "C", new Product("C", 20) },
            { "D", new Product("D", 15) }
        };

        public Product? GetProduct(string sku)
        {
            return _catalog.GetValueOrDefault(sku);
        }
    }
}
