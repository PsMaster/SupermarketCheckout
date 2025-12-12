using Supermarket.Core.Models;

namespace Supermarket.Core.Interfaces
{
    public interface ICartService
    {
        void AddItem(Product item);
        void RemoveItem(Product item);
        void ClearCart();
        IReadOnlyDictionary<string, ItemCountWrapper> GetAllItems();
        bool IsCartEmpty();
    }
}
