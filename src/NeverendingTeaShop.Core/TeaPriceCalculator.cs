using System;

namespace NeverendingTeaShop.Core
{
    public static class TeaPriceCalculator
    {
        public static double CalculateTaxedPrice(double retailPrice) => Math.Round(retailPrice + (retailPrice * 0.0875), 2);
    }
}