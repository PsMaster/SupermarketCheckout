using Supermarket.DataAccess;

namespace Supermarket.UnitTests
{
    public class ProductServiceTests
    {
        private ProductService _productService;
        public ProductServiceTests()
        {
            _productService = new ProductService();
        }

        [Theory]
        [InlineData("A", true)]
        [InlineData("B", true)]
        [InlineData("C", true)]
        [InlineData("D", true)]
        [InlineData("some", false)]
        [InlineData("other", false)]
        [InlineData("none", false)]
        public void GetProduct_ShouldRetrieveProduct_WhenProductIsValid(string sku, bool expectedToExist)
        {
            // Arrange

            // Act
            var product = _productService.GetProduct(sku);

            // Assert
            Assert.Equal(expectedToExist, product != null);
        }
    }
}
