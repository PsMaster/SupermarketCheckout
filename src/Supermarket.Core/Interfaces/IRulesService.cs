namespace Supermarket.Core.Interfaces
{
    public interface IRulesService
    {
        public IEnumerable<IPricingRuleStrategy> GetDiscountRules();
    }
}
