namespace Supermarket.Core.Models
{
    public class ItemCountWrapper(Product item)
    {
        public Product Item { get; set; } = item;
        public int Count { get; set; }
    }
}
