using Moq;
using Supermarket.Core.Interfaces;
using Supermarket.Core.Models;
using Supermarket.Core.Services;
using Supermarket.DataAccess.PricingRules;

namespace Supermarket.UnitTests
{
    public class CheckoutServiceTests
    {
        private readonly CheckoutService _checkoutService;
        private readonly Mock<ICartService> _cartServiceMock;
        private readonly Mock<IProductService> _productServiceMock;
        private readonly Mock<IRulesService> _rulesServiceServiceMock;

        Product productA = new("A", 50);
        Product productB = new("B", 30);
        Product productC = new("C", 20);
        Product productD = new("D", 15);

        List<IPricingRuleStrategy> _rules =
        [
            new MultiBuyRuleStrategy("A", 3, 130),
            new MultiBuyRuleStrategy("B", 2, 45)
        ];

        public CheckoutServiceTests()
        {
            _cartServiceMock = new Mock<ICartService>();
            _productServiceMock = new Mock<IProductService>();
            _rulesServiceServiceMock = new Mock<IRulesService>();

            _productServiceMock.Setup(x => x.GetProduct("A")).Returns(productA);
            _productServiceMock.Setup(x => x.GetProduct("B")).Returns(productB);
            _productServiceMock.Setup(x => x.GetProduct("C")).Returns(productC);
            _productServiceMock.Setup(x => x.GetProduct("D")).Returns(productD);

            _rulesServiceServiceMock.Setup(x => x.GetDiscountRules()).Returns(_rules);

            _checkoutService = new CheckoutService(_cartServiceMock.Object, _productServiceMock.Object, _rulesServiceServiceMock.Object);
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
            _cartServiceMock.Setup(x => x.GetAllItems()).Returns(new Dictionary<string, ItemCountWrapper>()
            {
                { "A", new ItemCountWrapper(productA) {Count = 1} },
                { "B", new ItemCountWrapper(productB) {Count = 1} }
            });
            // Have to return empty for initial scan, then return false as if the item is there
            _cartServiceMock.SetupSequence(x => x.IsCartEmpty()).Returns(true).Returns(false);

            // Act
            // Have to do a scan to initialize the rules
            _checkoutService.Scan("A");
            // TODO currently throws need to implement rules logic
            var totalPrice = _checkoutService.GetTotalPrice();

            // Assert
            Assert.Equal(80, totalPrice);

        }
    }
}
