using Supermarket.DataAccess;

namespace Supermarket.UnitTests
{
    public class RulesServiceTests
    {
        private RulesService _rulesService;
        public RulesServiceTests()
        {
            _rulesService = new RulesService();
        }

        [Fact]
        public void GetDiscountRules_ShouldReturnDiscountRules()
        {
            // Arrange

            // Act
            var rules = _rulesService.GetDiscountRules();

            // Assert
            Assert.Equal(2, rules.Count());
        }
    }
}
