using System.Collections.Generic;

namespace Brother.Tests.Specs.Services
{
    public interface ICalculationService
    {
        /// <summary>
        /// Verify the relation between Unit Cost, Margin & Unit Price (Used in Type 1)
        /// </summary>
        /// <param name="unitCost"></param>
        /// <param name="margin"></param>
        /// <param name="displayedUnitPrice"></param>
        void VerifyTotalPrice(string unitCost, string margin, string displayedUnitPrice);

        /// <summary>
        /// Verify that the sum of the string values in "prices" parameter is calculated correctly 
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="displayedTotalPrice"></param>
        void VerifySum(List<string> prices, string displayedTotalPrice);

        /// <summary>
        /// Verify that gross price is calculated correctly given the net price
        /// </summary>
        /// <param name="netTotalPrice"></param>
        /// <param name="displayedGrossTotalPrice"></param>
        void VerifyGrossPrice(string netTotalPrice, string displayedGrossTotalPrice);

        /// <summary>
        /// Converts string value to double value
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        double ConvertStringToDouble(string variable);

        /// <summary>
        /// Round off a double variable to certain decimal places
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="decimalPlaces"></param>
        /// <returns></returns>
        double RoundOffUptoDecimalPlaces(double variable, int decimalPlaces);

        /// <summary>
        /// Verify that multiplication of varA & varB is calculated correctly
        /// </summary>
        /// <param name="varA"></param>
        /// <param name="varB"></param>
        /// <param name="result"></param> /// Displayed value
        void VerifyMultiplication(string varA, string varB, string result);

        /// <summary>
        /// Verify that the currency symbol is correctly positioned in all the string values
        /// </summary>
        /// <param name="countryIso"></param>
        /// <param name="values"></param>
        void VerifyTheCorrectPositionOfCurrencySymbol(string countryIso, List<string> values);
    }
}
