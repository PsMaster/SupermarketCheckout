using Supermarket.Core.Models;

namespace Supermarket.Core.Interfaces
{
    public interface IPricingRuleStrategy
    {
        int CalculateDiscount(IReadOnlyDictionary<string, ItemCountWrapper> cart);
    }
}
