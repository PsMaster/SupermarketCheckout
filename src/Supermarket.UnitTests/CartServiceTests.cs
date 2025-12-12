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
            var product = new Product("A", 50);

            // Act
            _cartService.AddItem(product);

            // Assert
            var cartItems = _cartService.GetAllItems();
            cartItems.Should().HaveCount(1);
            cartItems["A"].Count.Should().Be(1);
        }

        [Fact]
        public void AddItem_ShouldIncrementCount_WhenItemAlreadyExists()
        {
            // Arrange
            var product = new Product("A", 50);
            _cartService.AddItem(product);

            // Act
            _cartService.AddItem(product);

            // Assert
            var cartItems = _cartService.GetAllItems();
            cartItems.Should().HaveCount(1);
            cartItems["A"].Count.Should().Be(2);
        }
    }
}
