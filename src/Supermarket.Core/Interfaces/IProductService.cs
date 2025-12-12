using Supermarket.Core.Models;

namespace Supermarket.Core.Interfaces
{
    public interface IProductService
    {
        Product? GetProduct(string sku);
    }
}
