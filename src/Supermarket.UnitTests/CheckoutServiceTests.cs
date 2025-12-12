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
        private readonly Mock<IProductService> _productServiceMock;

        public CheckoutServiceTests()
        {
            _cartServiceMock = new Mock<ICartService>();
            _productServiceMock = new Mock<IProductService>();
            _checkoutService = new CheckoutService(_cartServiceMock.Object, _productServiceMock.Object);
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
