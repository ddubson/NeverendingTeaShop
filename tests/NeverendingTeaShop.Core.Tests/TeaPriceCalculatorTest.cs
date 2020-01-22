using FluentAssertions;
using Xunit;
using static NeverendingTeaShop.Core.TeaPriceCalculator;

namespace NeverendingTeaShop.Core.Tests
{
    public class TeaPriceCalculatorTest
    {
        [Fact]
        public void CalculateTaxedPrice_GivenARetailPrice_ReturnsFullPriceWithTaxApplied()
        {
            CalculateTaxedPrice(19.99).Should().Be(21.74);
        }
    }
}