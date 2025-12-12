using FluentAssertions;
using Supermarket.Core.Models;
using Supermarket.Core.Services;

namespace Supermarket.UnitTests
{
    public class CartServiceTests
    {

        private readonly CartService _cartService;
        public CartServiceTests()
        {
            _cartService = new CartService();
        }

        [Fact]
        public void AddItem_ShouldAddItemToCart_WhenItemDoesNotExist()
        {
            // Arrange
            var product = new Product("SKU_123", 100);

            // Act
            _cartService.AddItem(product);

            // Assert
            var cartItems = _cartService.GetAllItems();
            cartItems.Should().HaveCount(1);
            cartItems["SKU_123"].Should().Be(1);
        }

        [Fact]
        public void AddItem_ShouldIncrementCount_WhenItemAlreadyExists()
        {
            // Arrange
            var product = new Product("SKU_123", 100);
            _cartService.AddItem(product);

            // Act
            _cartService.AddItem(product);

            // Assert
            var cartItems = _cartService.GetAllItems();
            cartItems.Should().HaveCount(1);
            cartItems["SKU_123"].Should().Be(2);
        }
    }
}
