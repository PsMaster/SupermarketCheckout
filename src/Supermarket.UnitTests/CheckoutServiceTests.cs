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

        Product productA = new("A", 50);
        Product productB = new("B", 30);
        Product productC = new("C", 20);
        Product productD = new("D", 15);

        public CheckoutServiceTests()
        {
            _cartServiceMock = new Mock<ICartService>();
            _productServiceMock = new Mock<IProductService>();

            _productServiceMock.Setup(x => x.GetProduct("A")).Returns(productA);
            _productServiceMock.Setup(x => x.GetProduct("B")).Returns(productB);
            _productServiceMock.Setup(x => x.GetProduct("C")).Returns(productC);
            _productServiceMock.Setup(x => x.GetProduct("D")).Returns(productD);

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

        [Fact]
        public void GetTotalPrice_ShouldGiveCorrectAmount()
        {
            // Arrange
            _cartServiceMock.Setup(x => x.GetAllItems()).Returns(new Dictionary<string, int>()
            {
                { "A", 1 },
                { "B", 1 }
            });

            // Act
            var totalPrice = _checkoutService.GetTotalPrice();

            // Assert
            Assert.Equal(80, totalPrice);

        }
    }
}
