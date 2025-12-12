using Supermarket.Core.Interfaces;
using Supermarket.Core.Models;

namespace Supermarket.Core.Services
{
    public class CartService : ICartService
    {
        private readonly Dictionary<string, ItemCountWrapper> _cart = new();

        public void AddItem(Product item)
        {
            if (_cart.TryGetValue(item.Sku, out var value))
            {
                value.Count++;
            }
            else
            {
                _cart.Add(item.Sku, new ItemCountWrapper(item) { Count = 1});
            }
        }

        public void RemoveItem(Product item)
        {
            if (!_cart.TryGetValue(item.Sku, out var value)) return;
            if (value.Count <= 1)
            {
                _cart.Remove(item.Sku);
            }
            else
            {
                value.Count--;
            }
        }

        public void ClearCart() => _cart.Clear();

        public IReadOnlyDictionary<string, ItemCountWrapper> GetAllItems() => _cart.AsReadOnly();

        public bool IsCartEmpty()
        {
            return _cart.Count == 0;
        }
    }
}
