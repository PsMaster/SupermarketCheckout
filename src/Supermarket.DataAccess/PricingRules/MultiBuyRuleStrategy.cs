using Supermarket.Core.Interfaces;
using Supermarket.Core.Models;

namespace Supermarket.DataAccess.PricingRules
{
    public class MultiBuyRuleStrategy : IPricingRuleStrategy
    {
        public string Sku { get; }
        public int SpecialQuantity { get; }
        public int SpecialPrice { get; }

        public MultiBuyRuleStrategy(string sku, int quantity, int price)
        {
            Sku = sku;
            SpecialQuantity = quantity;
            SpecialPrice = price;
        }

        public int CalculateDiscount(IReadOnlyDictionary<string, ItemCountWrapper> cart)
        {
            throw new NotImplementedException();
        }
    }
}
