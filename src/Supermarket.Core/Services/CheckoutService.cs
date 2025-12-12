using Supermarket.Core.Interfaces;

namespace Supermarket.Core.Services
{
    public class CheckoutService : ICheckout
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CheckoutService(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        public void Scan(string item)
        {
            // TODO discount rules should only be fetched once

            var product = _productService.GetProduct(item);

            if (product == null)
            {
                Console.WriteLine("Product not found");
                return;
            }
            _cartService.AddItem(product);
        }

        public int GetTotalPrice()
        {
            var cartItems = _cartService.GetAllItems();

            // TODO refactor - does not seem right to scan through each, need a wrapper for prices and counts
            Dictionary<int, int> priceCount = new Dictionary<int, int>();
            foreach (var cartItem in cartItems)
            {
                var price = _productService.GetProduct(cartItem.Key)?.UnitPrice;
                if (price != null) 
                {
                    priceCount.Add(price.Value, cartItem.Value);
                }
            }

            return 0;
        }
    }
}
