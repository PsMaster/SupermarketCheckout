using Supermarket.Core.Interfaces;
using Supermarket.DataAccess.PricingRules;

namespace Supermarket.DataAccess
{
    public class RulesService : IRulesService
    {
        private readonly List<IPricingRuleStrategy> _rules =
        [
            new MultiBuyRuleStrategy("A", 3, 130),
            new MultiBuyRuleStrategy("B", 2, 45)
        ];

        public IEnumerable<IPricingRuleStrategy> GetDiscountRules()
        {
            foreach (var rule in _rules)
            {
                switch (rule)
                {
                    case MultiBuyRuleStrategy m:
                        yield return m;
                        break;

                    // TODO other strategies go here
                }
            }
        }
    }
}
