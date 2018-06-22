using NUnit.Framework;
using System.Collections.Generic;

namespace Brother.Tests.Common.Domain.Constants
{
    public class FinancialInformation
    {
        private readonly Dictionary<string, double> Country2Vat = new Dictionary<string, double>()
        {
            { CountryIso.Denmark, 1.25 }, // 25% see https://en.wikipedia.org/wiki/Taxation_in_Denmark
            { CountryIso.Germany, 1.19},
            { CountryIso.Switzerland, 1.077},
            { CountryIso.UnitedKingdom,1.2}
        };

        public double GetVatRateMultiplyingFactor(string countryIso)
        {
            Assert.IsTrue(Country2Vat.ContainsKey(countryIso), "Vat information for this country with country ISO = {0} has yet not been formulated", countryIso);
            return Country2Vat[countryIso];
        }
    }
}
