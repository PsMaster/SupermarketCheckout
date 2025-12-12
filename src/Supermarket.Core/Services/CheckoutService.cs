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

        /// <summary>
        /// Scans SKU of the product. If product exits it will be added to the current user cart.
        /// </summary>
        /// <param name="item">Product SKU</param>
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

        /// <summary>
        /// Get total basket cost
        /// </summary>
        /// <returns>int - total basket cost</returns>
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

        /// <summary>
        /// Clears cart and transaction rules
        /// </summary>
        public void Checkout()
        {
            // TODO process payment and anything else that need to happen during checkout

            // reset state
            _cartService.ClearCart();
            _currentTransactionRules = null;
        }
    }
}
