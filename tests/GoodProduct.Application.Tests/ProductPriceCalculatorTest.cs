using FluentAssertions;
using Xunit;
using static GoodProduct.Application.ProductPriceCalculator;

namespace GoodProduct.Application.Tests
{
    public class ProductPriceCalculatorTest
    {
        [Fact]
        public void CalculateTax_GivenARetailPrice_ReturnsFullPriceWithTaxApplied()
        {
            CalculateTax(19.99).Should().Be(21.74);
        }
    }
}