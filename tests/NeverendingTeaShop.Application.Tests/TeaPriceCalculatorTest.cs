using FluentAssertions;
using Xunit;
using static NeverendingTeaShop.Application.TeaPriceCalculator;

namespace NeverendingTeaShop.Application.Tests
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