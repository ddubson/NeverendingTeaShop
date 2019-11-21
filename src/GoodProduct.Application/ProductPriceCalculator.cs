using System;

namespace GoodProduct.Application
{
    public static class ProductPriceCalculator
    {
        public static double CalculateTax(double retailPrice) => Math.Round(retailPrice + (retailPrice * 0.0875), 2);
    }
}