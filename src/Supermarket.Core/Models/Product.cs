namespace Supermarket.Core.Models
{
    public class Product(string sku, int unitPrice)
    {
        public string Sku { get; } = sku;
        public int UnitPrice { get; set; } = unitPrice;
    }
}
