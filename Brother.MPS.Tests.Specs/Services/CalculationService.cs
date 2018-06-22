using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Brother.Tests.Specs.Services
{
    public class CalculationService: ICalculationService
    {
        private ILoggingService LoggingService { get; set; }
        public IContextData ContextData { get; private set; }

        public CalculationService(ILoggingService loggingService, IContextData contextData)
        {
            LoggingService = loggingService;
            ContextData = contextData;
        }

        public void VerifyTotalPrice(string cultureNumericUnitCost, string cultureNumericMargin, string cultureNumericDisplayedUnitPrice)
        {
            LoggingService.WriteLogOnMethodEntry(cultureNumericUnitCost, cultureNumericMargin, cultureNumericDisplayedUnitPrice);
            double expectedPrice = (100 * ConvertCultureNumericStringToInvariantDouble(cultureNumericUnitCost)) / (100 - ConvertCultureNumericStringToInvariantDouble(cultureNumericMargin));

            TestCheck.AssertIsEqual(
                RoundOffUptoDecimalPlaces(expectedPrice), ConvertCultureNumericStringToInvariantDouble(cultureNumericDisplayedUnitPrice), "Total Price Calculations did not get validated");
        }

        // TODO OIKE 呼び元invaliant化やめる
        public void VerifySum(List<string> prices, string displayedTotalPrice)
        {
            LoggingService.WriteLogOnMethodEntry(prices, displayedTotalPrice);
            double expectedTotalPrice = 0.00;
            foreach(string price in prices)
            {
                expectedTotalPrice = expectedTotalPrice + double.Parse(price, NumberStyles.Currency, ContextData.CultureInfo);
            }

            var actualTotalPrice = double.Parse(displayedTotalPrice, NumberStyles.Currency, ContextData.CultureInfo);
            Assert.AreEqual(expectedTotalPrice, actualTotalPrice, 2, "Total Line Price Calculations did not get validated");
        }

        public void VerifyGrossPrice(string netTotalPrice, string displayedGrossTotalPrice)
        {
            LoggingService.WriteLogOnMethodEntry(netTotalPrice, displayedGrossTotalPrice);

            var financialInfo = new FinancialInformation();
            var expectedGrossTotalPrice = double.Parse(netTotalPrice, NumberStyles.Currency,ContextData.CultureInfo) * financialInfo.GetVatRateMultiplyingFactor(ContextData.Country.CountryIso);
            var actualGrossTotalPrice = double.Parse(displayedGrossTotalPrice, NumberStyles.Currency, ContextData.CultureInfo);
            Assert.AreEqual(expectedGrossTotalPrice, actualGrossTotalPrice, 2, "Gross total price did not get validated");
        }

        public double ConvertCultureNumericStringToInvariantDouble(string variable)
        {
            LoggingService.WriteLogOnMethodEntry(variable);
            if(variable == "-")
            {
                return 0.0;
            }
            else
            {
                return double.Parse(Regex.Replace(variable, @"['\s]+", string.Empty), ContextData.CultureInfo == null ? new CultureInfo(ContextData.Culture) : ContextData.CultureInfo);
            }
        }

        public double ConvertCultureNumericStringToInvariantDouble(string variable, NumberStyles numberStyles)
        {
            LoggingService.WriteLogOnMethodEntry(variable, numberStyles);
            if (variable == "-")
            {
                return 0.0;
            }
            else
            {
                return double.Parse(Regex.Replace(variable, @"['\s]+", string.Empty), numberStyles, ContextData.CultureInfo == null ? new CultureInfo(ContextData.Culture) : ContextData.CultureInfo);
            }
        }

        public double ConvertStringToDoubleInvariant(string variable)
        {
            LoggingService.WriteLogOnMethodEntry(variable);
            return double.Parse(variable, CultureInfo.InvariantCulture);
        }

        public string ConvertInvariantNumericStringToCultureNumericString(string invariant)
        {
            LoggingService.WriteLogOnMethodEntry(invariant);
            // 12345  -[de]-> 12345
            // 123.45 -[de]-> 123,45
            // 12,345 -[de]-> 12.345
            // 12,345.670 -[de]-> 12.345,670

            if (string.IsNullOrWhiteSpace(invariant)) { return invariant; }

            invariant = invariant.Trim();
            var ciInvariant = CultureInfo.InvariantCulture;
            var ciCulture = ContextData.CultureInfo;
            var regx = new Regex("[0-9]");
            var format = regx.Replace(invariant, "0");
            double doubleValue = double.Parse(invariant, ciInvariant);
            var cultured = doubleValue.ToString(format, ciCulture);
            return cultured;
        }

        public string ConvertCultureNumericStringToInvariantNumericString(string cultureString, NumberStyles numberStyles = NumberStyles.Currency | NumberStyles.Number)
        {
            LoggingService.WriteLogOnMethodEntry(cultureString, numberStyles);
            return ConvertCultureNumericStringToInvariantDouble(cultureString, numberStyles).ToString();
        }

        public double RoundOffUptoDecimalPlaces(double variable, int decimalPlaces = 2)
        {
            LoggingService.WriteLogOnMethodEntry(variable, decimalPlaces);
            double roundedValue = Math.Round(variable, decimalPlaces, MidpointRounding.AwayFromZero);
            return roundedValue;
        }

        public void VerifyMultiplication(string varA, string varB, string result)
        {
            LoggingService.WriteLogOnMethodEntry(varA, varB, result);
            double expectedResult = ConvertCultureNumericStringToInvariantDouble(varA) * ConvertCultureNumericStringToInvariantDouble(varB);
            
            TestCheck.AssertIsEqual(
                RoundOffUptoDecimalPlaces(expectedResult), ConvertCultureNumericStringToInvariantDouble(result), "Multiplication calculations did not get validated");
        }

        public void VerifyTheCorrectPositionOfCurrencySymbol(string countryIso, List<string> values)
        {
            LoggingService.WriteLogOnMethodEntry(countryIso, values);
            // TODO: Check correct position of currency symbols for all countries
            // Check for UK only for now

            string currencySymbol = ContextData.CultureInfo.NumberFormat.CurrencySymbol;

            if (values.Any(v => v[0].ToString() != currencySymbol))
            {
                LoggingService.WriteLog(LoggingLevel.WARNING, "Currency symbol position did not get validated for values : " + values); // Don't fail test as not fatal error, just throw a warning message
            }
        }

        public string CalculateProportionalVolume(int minimumVolume, string startDate, string endDate)
        {
            LoggingService.WriteLogOnMethodEntry(minimumVolume, startDate, endDate);
         
            // Logic to calculate pro rata used in Type 3
            DateTime sd = MpsUtil.StringToDateTimeFormat(startDate, ContextData.Country.CountryIso);
            DateTime ed = MpsUtil.StringToDateTimeFormat(endDate, ContextData.Country.CountryIso).AddDays(1);
            int monthsDifference = GetMonthsBetween(sd, ed);
            DateTime tempD = ed.AddMonths(-monthsDifference); // Go back "X" months from (end date + 1)
            var surplusDays = (tempD - sd).TotalDays;
            if(surplusDays == 0)
            {
                return minimumVolume.ToString();
            }
            else
            {
                return RoundOffUptoDecimalPlaces((minimumVolume * surplusDays / 30), 0).ToString();
            }
            
        }

        public int GetMonthsBetween(DateTime from, DateTime to)
        {
            LoggingService.WriteLogOnMethodEntry(from, to);

            if (from > to) return GetMonthsBetween(to, from);

            var monthDiff = Math.Abs((to.Year * 12 + (to.Month - 1)) - (from.Year * 12 + (from.Month - 1)));

            if (from.AddMonths(monthDiff) > to || to.Day < from.Day)
            {
                return monthDiff - 1;
            }
            else
            {
                return monthDiff;
            }
        }

        public string CalculateProRataForSwappedOutDevice(int minimumVolume, string startPeriodDate, string endDeviceDate)
        {
            LoggingService.WriteLogOnMethodEntry(minimumVolume, startPeriodDate, endDeviceDate);

            // Logic to calculate pro rata for swapped out device used in Type 3
            DateTime sd = MpsUtil.StringToDateTimeFormat(startPeriodDate, ContextData.Country.CountryIso);
            DateTime ed = MpsUtil.StringToDateTimeFormat(endDeviceDate, ContextData.Country.CountryIso);
            var surplusDays = (ed - sd).TotalDays + 1;   
            return RoundOffUptoDecimalPlaces((minimumVolume * surplusDays / 30), 0).ToString();
        }

        public string CalculateProRataForSwappedInDevice(int minimumVolume, AdditionalDeviceProperties swappedOutDevice, AdditionalDeviceProperties swappedIndevice)
        {
            LoggingService.WriteLogOnMethodEntry(minimumVolume, swappedOutDevice, swappedIndevice);

            string swappedOutDeviceProRata = CalculateProRataForSwappedOutDevice(swappedOutDevice.VolumeMono, swappedOutDevice.StartDeviceDate, swappedOutDevice.EndDeviceDate);
            return (minimumVolume - Int32.Parse(swappedOutDeviceProRata)).ToString();
        }
    }
}
