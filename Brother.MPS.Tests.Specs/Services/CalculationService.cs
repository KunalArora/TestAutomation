﻿using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brother.Tests.Specs.Services
{
    public class CalculationService: ICalculationService
    {
        private ILoggingService LoggingService { get; set; }

        public CalculationService(ILoggingService loggingService)
        {
            LoggingService = loggingService;
        }

        public void VerifyTotalPrice(string cost, string margin, string displayedPrice)
        {
            LoggingService.WriteLogOnMethodEntry(cost, margin, displayedPrice);
            double expectedPrice = (100 * ConvertStringToDouble(cost)) / (100 - ConvertStringToDouble(margin));

            TestCheck.AssertIsEqual(
                RoundOffUptoDecimalPlaces(expectedPrice), ConvertStringToDouble(displayedPrice), "Total Price Calculations did not get validated");
        }

        public void VerifySum(List<string> prices, string displayedTotalPrice)
        {
            LoggingService.WriteLogOnMethodEntry(prices, displayedTotalPrice);
            double expectedTotalPrice = 0.00;
            foreach(string price in prices)
            {
                expectedTotalPrice = expectedTotalPrice + ConvertStringToDouble(price);
            }

            TestCheck.AssertIsEqual(
                RoundOffUptoDecimalPlaces(expectedTotalPrice), ConvertStringToDouble(displayedTotalPrice), "Total Line Price Calculations did not get validated");
        }

        public void VerifyGrossPrice(string netTotalPrice, string displayedGrossTotalPrice)
        {
            LoggingService.WriteLogOnMethodEntry(netTotalPrice, displayedGrossTotalPrice);

            // TODO: Maintain & use VAT percentage for every country
            // For now, hard-code it for UK (20%)
            double expectedGrossTotalPrice = ConvertStringToDouble(netTotalPrice) * 1.2;
            TestCheck.AssertIsEqual(
                RoundOffUptoDecimalPlaces(expectedGrossTotalPrice), ConvertStringToDouble(displayedGrossTotalPrice), "Gross total price did not get validated");
        }

        public double ConvertStringToDouble(string variable)
        {
            LoggingService.WriteLogOnMethodEntry(variable);
            return double.Parse(variable, System.Globalization.CultureInfo.InvariantCulture);
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
            double expectedResult = ConvertStringToDouble(varA) * ConvertStringToDouble(varB);
            
            TestCheck.AssertIsEqual(
                RoundOffUptoDecimalPlaces(expectedResult), ConvertStringToDouble(result), "Multiplication calculations did not get validated");
        }

        public void VerifyTheCorrectPositionOfCurrencySymbol(string countryIso, List<string> values)
        {
            LoggingService.WriteLogOnMethodEntry(countryIso, values);
            // TODO: Check correct position of currency symbols for all countries
            // Check for UK only for now

            string currencySymbol = MpsUtil.GetCurrencySymbol(countryIso);

            if (values.Any(v => v[0].ToString() != currencySymbol))
            {
                LoggingService.WriteLog(LoggingLevel.WARNING, "Currency symbol position did not get validated for values : " + values); // Don't fail test as not fatal error, just throw a warning message
            }
        }

        public string CalculateProportionalVolume(int minimumVolume, string startDate, string endDate)
        {
            LoggingService.WriteLogOnMethodEntry(minimumVolume, startDate, endDate);
         
            // Logic to calculate pro rata used in Type 3
            DateTime sd = MpsUtil.StringToDateTimeFormat(startDate);
            DateTime ed = MpsUtil.StringToDateTimeFormat(endDate).AddDays(1);
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
    }
}
