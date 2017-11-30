using System.Collections.Generic;

namespace Brother.Tests.Specs.Services
{
    public interface ICalculationService
    {
        void VerifyTotalPrice(string unitCost, string margin, string displayedUnitPrice);
        void VerifySum(List<string> prices, string displayedTotalPrice);
        void VerifyGrossPrice(string netTotalPrice, string displayedGrossTotalPrice);
        double ConvertStringToDouble(string variable);
        double RoundOffUptoDecimalPlaces(double variable, int decimalPlaces);
    }
}
