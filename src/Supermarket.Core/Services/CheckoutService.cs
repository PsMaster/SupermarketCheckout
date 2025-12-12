using Supermarket.Core.Interfaces;

namespace Supermarket.Core.Services
{
    public class CheckoutService : ICheckout
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IRulesService _discountRulesService;
        private IEnumerable<IPricingRuleStrategy>? _currentTransactionRules;

        public CheckoutService(ICartService cartService, IProductService productService, IRulesService discountRulesService)
        {
            _cartService = cartService;
            _productService = productService;
            _discountRulesService = discountRulesService;
        }

        public void Scan(string item)
        {
            var product = _productService.GetProduct(item);

            if (product == null)
            {
                Console.WriteLine("Product not found");
                return;
            }

            // Only retrieve rules if the current cart is empty (new session)
            if (_cartService.IsCartEmpty())
            {
                _currentTransactionRules = _discountRulesService.GetDiscountRules().ToList();
            }

            _cartService.AddItem(product);
        }

        public int GetTotalPrice()
        {
            if (_cartService.IsCartEmpty() || _currentTransactionRules == null)
            {
                return 0;
            }
            var cartItems = _cartService.GetAllItems();
            
            var total = cartItems.Sum(i => i.Value.Count * i.Value.Item.UnitPrice);

            foreach (var strategy in _currentTransactionRules)
            {
                total -= strategy.CalculateDiscount(cartItems);
            }

            return total;
        }

        public void Checkout()
        {
            // TODO process payment and anything else that need to happen during checkout

            // reset state
            _cartService.ClearCart();
            _currentTransactionRules = null;
        }
    }
}
