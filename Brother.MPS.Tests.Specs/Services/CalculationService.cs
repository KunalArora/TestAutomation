using System;
using System.Collections.Generic;

namespace Brother.Tests.Specs.Services
{
    public class CalculationService: ICalculationService
    {
        public void VerifyTotalPrice(string cost, string margin, string displayedPrice)
        {
            double expectedPrice = (100 * ConvertStringToDouble(cost)) / (100 - ConvertStringToDouble(margin));
            if (!RoundOffUptoDecimalPlaces(expectedPrice).Equals(ConvertStringToDouble(displayedPrice)))
            {
                throw new Exception("Total Price Calculations did not get validated");
            }
        }

        public void VerifySum(List<string> prices, string displayedTotalPrice)
        {
            double expectedTotalPrice = 0.00;
            foreach(string price in prices)
            {
                expectedTotalPrice = expectedTotalPrice + ConvertStringToDouble(price);
            }
            if (!RoundOffUptoDecimalPlaces(expectedTotalPrice).Equals(ConvertStringToDouble(displayedTotalPrice)))
            {
                throw new Exception("Total Line Price Calculations did not get validated");
            }
        }

        public void VerifyGrossPrice(string netTotalPrice, string displayedGrossTotalPrice)
        {
            // TODO: Maintain & use VAT percentage for every country
            // For now, hard-code it for UK (20%)
            double expectedGrossTotalPrice = ConvertStringToDouble(netTotalPrice) * 1.2; 
            if (!RoundOffUptoDecimalPlaces(expectedGrossTotalPrice).Equals(ConvertStringToDouble(displayedGrossTotalPrice)))
            {
                throw new Exception("Gross total price did not get validated");
            }
        }

        public double ConvertStringToDouble(string variable)
        {
            return double.Parse(variable, System.Globalization.CultureInfo.InvariantCulture);
        }

        public double RoundOffUptoDecimalPlaces(double variable, int decimalPlaces = 2)
        {
            return Math.Round(variable, decimalPlaces);
        }
    }
}
