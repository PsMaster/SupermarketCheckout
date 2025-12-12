using Supermarket.Core.Interfaces;
using Supermarket.Core.Models;

namespace Supermarket.Core.Services
{
    public class CartService : ICartService
    {
        public void AddItem(Product item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Product item)
        {
            throw new NotImplementedException();
        }

        public void ClearCart()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyDictionary<string, int> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public bool IsCartEmpty()
        {
            throw new NotImplementedException();
        }
    }
}
