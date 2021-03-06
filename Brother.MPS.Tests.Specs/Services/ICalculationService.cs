﻿using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Brother.Tests.Specs.Services
{
    public interface ICalculationService
    {
        /// <summary>
        /// Verify the relation between Unit Cost, Margin & Unit Price (Used in Type 1)
        /// </summary>
        /// <param name="cultureNumericUnitCost"></param>
        /// <param name="cultureNumericMargin"></param>
        /// <param name="cultureNumericDisplayedUnitPrice"></param>
        void VerifyTotalPrice(string cultureNumericUnitCost, string cultureNumericMargin, string cultureNumericDisplayedUnitPrice);

        /// <summary>
        /// Verify that the sum of the string values in "prices" parameter is calculated correctly 
        /// </summary>
        /// <param name="invariantPrices">Note: This parameter takes only invariant values</param>
        /// <param name="invariantDisplayedTotalPrice">Note: This parameter takes only invariant value</param>
        void VerifySum(List<string> invariantPrices, string invariantDisplayedTotalPrice);

        /// <summary>
        /// Verify that gross price is calculated correctly given the net price
        /// </summary>
        /// <param name="netTotalPrice"></param>
        /// <param name="displayedGrossTotalPrice"></param>
        void VerifyGrossPrice(string netTotalPrice, string displayedGrossTotalPrice);

        /// <summary>
        /// Converts culture dependent string value to invariant double value
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        double ConvertCultureNumericStringToInvariantDouble(string variable);

        /// <summary>
        /// Converts culture dependent string value to invariant double value
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="numberStyles"></param>
        /// <returns></returns>
        double ConvertCultureNumericStringToInvariantDouble(string variable, NumberStyles numberStyles);

        /// <summary>
        /// Convert invariant numeric to cultured numeric string
        /// </summary>
        /// <param name="invariant"></param>
        /// <returns></returns>
        string ConvertInvariantNumericStringToCultureNumericString(string invariant);

        /// <summary>
        /// Convert invariant numeric to cultured numeric string
        /// </summary>
        /// <param name="invariant"></param>
        /// <returns></returns>
        string ConvertCultureNumericStringToInvariantNumericString(string cultureString, NumberStyles numberStyles = NumberStyles.Currency | NumberStyles.Number);

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

        /// <summary>
        /// Calculate proportional minimum volume for the given time period
        /// </summary>
        /// <param name="minimumVolume"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        string CalculateProportionalVolume(int minimumVolume, string startDate, string endDate);

        /// <summary>
        /// Calculate proportional volume (pro rata) for the swapped out device
        /// </summary>
        /// <param name="minimumVolume"></param>
        /// <param name="startPeriodDate"></param>
        /// <param name="endDeviceDate"></param>
        /// <returns></returns>
        string CalculateProRataForSwappedOutDevice(int minimumVolume, string startPeriodDate, string endDeviceDate);

        /// <summary>
        /// Calculate proportional volume (pro rata) for the swapped in device
        /// </summary>
        /// <param name="minimumVolume"></param>
        /// <param name="swappedOutDevice"></param>
        /// <param name="swappedInDevice"></param>
        /// <returns></returns>
        string CalculateProRataForSwappedInDevice(int minimumVolume, AdditionalDeviceProperties swappedOutDevice, AdditionalDeviceProperties swappedIndevice);
    }
}