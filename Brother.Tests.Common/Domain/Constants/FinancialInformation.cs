using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using NUnit.Framework;

namespace Brother.Tests.Common.Domain.Constants
{
    public class FinancialInformation
    {
        public double GetVatRateMultiplyingFactor(string countryIso)
        {
            double vatMultiplyFactor = 0;

            switch (countryIso)
            {
                case CountryIso.UnitedKingdom:
                    vatMultiplyFactor = 1.2;
                    break;
                case CountryIso.Switzerland:
                    vatMultiplyFactor = 1.077;
                    break;
                case CountryIso.Germany:
                    vatMultiplyFactor = 1.19;
                    break;
                case CountryIso.Poland:
                    vatMultiplyFactor = 1.23;
                    break;
                default:
                    Assert.Fail(string.Format("Vat information for this country with country ISO = {0} has yet not been formulated", countryIso));
                    break;
            }

            return vatMultiplyFactor;
        }
    }
}
