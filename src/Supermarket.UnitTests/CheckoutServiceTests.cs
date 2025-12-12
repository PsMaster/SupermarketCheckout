using Moq;
using Supermarket.Core.Interfaces;
using Supermarket.Core.Models;
using Supermarket.Core.Services;

namespace Supermarket.UnitTests
{
    public class CheckoutServiceTests
    {
        private readonly CheckoutService _checkoutService;
        private readonly Mock<ICartService> _cartServiceMock;

        public CheckoutServiceTests()
        {
            _cartServiceMock = new Mock<ICartService>();
            _checkoutService = new CheckoutService();
        }

        [Fact]
        public void Scan_ShouldAddItemToCart()
        {
            // Arrange
            
            // Act
            _checkoutService.Scan("A");

            // Assert
            _cartServiceMock.Verify(x => x.AddItem(It.IsAny<Product>()), Times.Once);
        }
    }
}
