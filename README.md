## C# .Net 8 Solution for Supermarket checkout.

### Project structure
- Supermarket.App - Console Application that allows to scan items and see the total price after the scan
- Supermarket.Core - Definitions and services
- Supermarket.DataAccess - services that deal with data, for simplicity data is hardcoded
- Supermarket.UnitTests - unit tests

### Top level usage
Run the Supermarket.Application project to see console instructions.

ICheckout.Scan() -> ICheckout.GetTotalPrice() -> ICheckout.Checkout()

### Services in play

- CheckoutService - Scan, GetTotalPrice, Checkout
- CartService - AddItem, RemoveItem, ClearCart, GetAllItems, IsCartEmpty
- ProductSDervice - GetProduct
- RulesService - GetDiscountRules

New rules can be implemented and added to the RulesService, each rule is accounted for individually.
