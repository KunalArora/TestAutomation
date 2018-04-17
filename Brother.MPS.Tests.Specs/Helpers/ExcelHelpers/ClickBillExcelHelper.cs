using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Specs.Services;
using NUnit.Framework;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public class ClickBillExcelHelper: ExcelBaseHelper, IClickBillExcelHelper
    {
        // Summary Tab sheet properties
        private const int Summary_Country_Col_No = 1;
        private const int Summary_DealershipNumber_Col_No = 2;
        private const int Summary_DealershipName_Col_No = 3;
        private const int Summary_AgreementNumber_Col_No = 4;
        private const int Summary_AgreementName_Col_No = 5;
        private const int Summary_BillPeriodFrom_Col_No = 6;
        private const int Summary_BillPeriodTo_Col_No = 7;
        private const int Summary_TotalClickCharge_Col_No = 8;
        private const int Summary_TotalAdditionalCharge_Col_No = 9;
        private const int Summary_Total_Col_No = 10;

        // Click Charges Tab sheet properties
        private const int ClickCharges_Country_Col_No = 1;
        private const int ClickCharges_DealershipNumber_Col_No = 2;
        private const int ClickCharges_DealershipName_Col_No = 3;
        private const int ClickCharges_AgreementNumber_Col_No = 4;
        private const int ClickCharges_AgreementName_Col_No = 5;
        private const int ClickCharges_LeadCodeReference_Col_No = 6;
        private const int ClickCharges_DealerReference_Col_No = 7;
        private const int ClickCharges_LeasingFinancialReference_Col_No = 8;
        private const int ClickCharges_CostCentre_Col_No = 9;
        private const int ClickCharges_BillPeriodFrom_Col_No = 10;
        private const int ClickCharges_BillPeriodTo_Col_No = 11;
        private const int ClickCharges_ProductName_Col_No = 12;
        private const int ClickCharges_SerialNumber_Col_No = 13;
        private const int ClickCharges_StartDate_Col_No = 14;
        private const int ClickCharges_EndDate_Col_No = 15;
        private const int ClickCharges_MinimumVolumeMono_Col_No = 16;
        private const int ClickCharges_StartMonoPrintCount_Col_No = 17;
        private const int ClickCharges_EndMonoPrintCount_Col_No = 18;
        private const int ClickCharges_TotalPagesPrintedMono_Col_No = 19;
        private const int ClickCharges_MonoClickPrice_Col_No = 20;
        private const int ClickCharges_MonoBillablePages_Col_No = 21;
        private const int ClickCharges_MonoAmountBilled_Col_No = 22;
        private const int ClickCharges_MinimumVolumeColour_Col_No = 23;
        private const int ClickCharges_StartColourPrintCount_Col_No = 24;
        private const int ClickCharges_EndColourPrintCount_Col_No = 25;
        private const int ClickCharges_TotalPagesPrintedColour_Col_No = 26;
        private const int ClickCharges_ColourClickPrice_Col_No = 27;
        private const int ClickCharges_ColourBillablePages_Col_No = 28;
        private const int ClickCharges_ColourAmountBilled_Col_No = 29;
        private const int ClickCharges_TotalAmountBilled_Col_No = 30;

        // Additional Charges Tab sheet properties
        private const int AdditionalCharges_Country_Col_No = 1;
        private const int AdditionalCharges_DealershipNumber_Col_No = 2;
        private const int AdditionalCharges_DealershipName_Col_No = 3;
        private const int AdditionalCharges_AgreementNumber_Col_No = 4;
        private const int AdditionalCharges_AgreementName_Col_No = 5;
        private const int AdditionalCharges_LeadCodeReference_Col_No = 6;
        private const int AdditionalCharges_DealerReference_Col_No = 7;
        private const int AdditionalCharges_LeasingFinancialReference_Col_No = 8;
        private const int AdditionalCharges_BillPeriodFrom_Col_No = 9;
        private const int AdditionalCharges_BillPeriodTo_Col_No = 10;
        private const int AdditionalCharges_ChargeDescription_Col_No = 11;
        private const int AdditionalCharges_TotalAmountBilled_Col_No = 12;


        private ILoggingService LoggingService { get; set; }
        private ICalculationService _calculationService;
        private IContextData _contextData;
        private ITranslationService _translationService;

        public ClickBillExcelHelper(
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService,
            ICalculationService calculationService,
            IContextData contextData,
            ITranslationService translationService
            ): base(loggingService, runtimeSettings)
        {
            LoggingService = loggingService;
            _calculationService = calculationService;
            _contextData = contextData;
            _translationService = translationService;
        }

        public void VerifySummaryWorksheet(string excelFilePath, string startDate, string endDate, string expectedClickRateTotal)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath, startDate, endDate, expectedClickRateTotal);

            var fileInfo = new FileInfo(excelFilePath);

            Assert.True(fileInfo.Exists, string.Format("Excel sheet = {0} does not exist", excelFilePath));

            using (ExcelPackage pack = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.First();

                int rowIndex = 2;

                while(!(HandleNullCase(ws.Cells[rowIndex, Summary_AgreementNumber_Col_No].Value).Replace(",", "") == _contextData.AgreementId.ToString() &&
                    FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, Summary_BillPeriodFrom_Col_No].Value)) == startDate &&
                    FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, Summary_BillPeriodTo_Col_No].Value)) == endDate))
                {
                    rowIndex++;
                    if(rowIndex > GetNumberOfRows(excelFilePath))
                    {
                        TestCheck.AssertFailTest(
                            string.Format(
                            "Information for agreement {0} with billing dates {1} - {2} not present in the Summary tab sheet of excel file {3}", _contextData.AgreementId, startDate, endDate, excelFilePath));
                    }
                }

                TestCheck.AssertIsEqual(
                    Convert.ToDouble(expectedClickRateTotal), Convert.ToDouble(ws.Cells[rowIndex, Summary_Total_Col_No].Value), string.Format(
                    "Click Rate total for agreement {0} and billing dates {1} - {2} in excel file {3} could not be verified", _contextData.AgreementId, startDate, endDate, excelFilePath));

                // Verify other agreement details
                VerifyAgreementDetailsInSummaryWorksheet(ws, rowIndex, startDate, endDate, excelFilePath);
            }         
        }

        public void VerifyClickChargesWorksheet(string excelFilePath, string startDate, string endDate, bool isFirstBillingPeriod)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath, startDate, endDate, isFirstBillingPeriod);

            var fileInfo = new FileInfo(excelFilePath);
            Assert.True(fileInfo.Exists, string.Format("Excel sheet = {0} does not exist", excelFilePath));

            using (ExcelPackage pack = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets[2];

                double expectedClickRateTotal = 0;

                foreach(var device in _contextData.AdditionalDeviceProperties)
                {
                    int rowIndex = 2;

                    // Note: Device won't be present in this bill if:
                    // 1. This is not the first billing period bill and this is the swapped out device
                    // 2. This is Pay As You Go usage type and this is the swapped in device (unless the print counts of the new device are raised after swapping)
                    if (!isFirstBillingPeriod && device.IsSwap || (_contextData.UsageType.Equals(_translationService.GetUsageTypeText(TranslationKeys.UsageType.PayAsYouGo, _contextData.Culture)) && device.IsSwappedInDevice))
                    {
                        continue;
                    }

                    while (!(HandleNullCase(ws.Cells[rowIndex, ClickCharges_SerialNumber_Col_No].Value) == device.SerialNumber &&
                    FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, ClickCharges_BillPeriodFrom_Col_No].Value)) == startDate &&
                    FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, ClickCharges_BillPeriodTo_Col_No].Value)) == endDate))
                    {
                        rowIndex++;
                        if (rowIndex > GetNumberOfRows(excelFilePath, 2))
                        {   
                            TestCheck.AssertFailTest(
                                string.Format(
                                "Information for device with serial number {0} with billing dates {1} - {2} not present in the Click-charges tab sheet of excel file {3}", device.SerialNumber, startDate, endDate, excelFilePath));
                        }
                    }

                    device.StartDeviceDate = FormatExcelSerialDate(HandleNullCase(_calculationService.RoundOffUptoDecimalPlaces((double)ws.Cells[rowIndex, ClickCharges_StartDate_Col_No].Value, 0)));
                    device.EndDeviceDate = FormatExcelSerialDate(HandleNullCase(_calculationService.RoundOffUptoDecimalPlaces((double)ws.Cells[rowIndex, ClickCharges_EndDate_Col_No].Value, 0)));
                }

                foreach(var device in _contextData.AdditionalDeviceProperties)
                {
                    int rowIndex = 2;

                    // Note: Device won't be present in this bill if:
                    // 1. This is not the first billing period bill and this is the swapped out device
                    // 2. This is Pay As You Go usage type and this is the swapped in device (unless the print counts of the new device are raised after swapping)
                    if (!isFirstBillingPeriod && device.IsSwap || (_contextData.UsageType.Equals(_translationService.GetUsageTypeText(TranslationKeys.UsageType.PayAsYouGo, _contextData.Culture)) && device.IsSwappedInDevice))
                    {
                        continue;
                    }

                    while (!(HandleNullCase(ws.Cells[rowIndex, ClickCharges_SerialNumber_Col_No].Value) == device.SerialNumber &&
                    FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, ClickCharges_BillPeriodFrom_Col_No].Value)) == startDate &&
                    FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, ClickCharges_BillPeriodTo_Col_No].Value)) == endDate))
                    {
                        rowIndex++;
                        if (rowIndex > GetNumberOfRows(excelFilePath, 2))
                        {
                            TestCheck.AssertFailTest(
                                string.Format(
                                "Information for device with serial number {0} with billing dates {1} - {2} not present in the Click-charges tab sheet of excel file {3}", device.SerialNumber, startDate, endDate, excelFilePath));
                        }
                    }

                    VerifyAgreementDetailsInClickChargesWorksheet(ws, rowIndex, device, startDate, endDate, excelFilePath);

                    // Verify click-charges

                    int expectedMonoBillablePages = 0, expectedColourBillablePages = 0, totalPagesPrintedMono = 0, totalPagesPrintedColour = 0;

                    totalPagesPrintedMono = Int32.Parse(HandleNullCase(ws.Cells[rowIndex, ClickCharges_TotalPagesPrintedMono_Col_No].Value));
                    device.TotalPagesPrintedMono = totalPagesPrintedMono;
                        
                    if (!device.IsMonochrome)
                    {
                        totalPagesPrintedColour = Int32.Parse(HandleNullCase(ws.Cells[rowIndex, ClickCharges_TotalPagesPrintedColour_Col_No].Value));
                        device.TotalPagesPrintedColour = totalPagesPrintedColour;
                    }

                    // Minimum Volume case
                    if (_contextData.UsageType.Equals(_translationService.GetUsageTypeText(TranslationKeys.UsageType.MinimumVolume, _contextData.Culture))) 
                    {
                        string expectedMonoMinimumVolume;

                        int swappedOutDeviceMonoBillablePages = 0;
                        int swappedOutDeviceTotalPagesPrintedMono = 0;

                        // Pro rata calculation
                        if(device.IsSwap && isFirstBillingPeriod) // Swapped out device first billing period
                        {
                            expectedMonoMinimumVolume = _calculationService.CalculateProRataForSwappedOutDevice(device.VolumeMono, startDate, device.EndDeviceDate);
                        }
                        else if(device.IsSwappedInDevice && isFirstBillingPeriod) // Swapped in device first billing period
                        {
                            AdditionalDeviceProperties swappedOutDevice = null;
                            // Find the old device
                            foreach(var oldDevice in _contextData.AdditionalDeviceProperties)
                            {
                                if(oldDevice.SwappedDeviceID.Equals(device.MpsDeviceId))
                                {
                                    swappedOutDevice = oldDevice;
                                    break;
                                }
                            }

                            expectedMonoMinimumVolume = _calculationService.CalculateProRataForSwappedInDevice(Int32.Parse(_calculationService.CalculateProportionalVolume(device.VolumeMono, startDate, endDate)), swappedOutDevice, device);
                            swappedOutDeviceMonoBillablePages = Int32.Parse(_calculationService.CalculateProRataForSwappedOutDevice(swappedOutDevice.VolumeMono, startDate, swappedOutDevice.EndDeviceDate));
                            swappedOutDeviceTotalPagesPrintedMono = swappedOutDevice.TotalPagesPrintedMono;
                        }
                        else if (isFirstBillingPeriod) // Normal device first billing period
                        {
                            expectedMonoMinimumVolume = _calculationService.CalculateProportionalVolume(device.VolumeMono, startDate, endDate);
                        }
                        else // For billing periods other than the first
                        {
                            expectedMonoMinimumVolume = device.VolumeMono.ToString();
                        }

                        TestCheck.AssertIsEqual(
                            expectedMonoMinimumVolume, HandleNullCase(ws.Cells[rowIndex, ClickCharges_MinimumVolumeMono_Col_No].Value), string.Format(
                            "Minimum Volume mono for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                        expectedMonoBillablePages = Int32.Parse(expectedMonoMinimumVolume);
                        if (totalPagesPrintedMono > expectedMonoBillablePages && !device.IsSwap && !device.IsSwappedInDevice)
                        {
                            expectedMonoBillablePages = totalPagesPrintedMono;
                        }
                        else if(device.IsSwappedInDevice && isFirstBillingPeriod)
                        {
                            expectedMonoBillablePages = totalPagesPrintedMono + swappedOutDeviceTotalPagesPrintedMono - swappedOutDeviceMonoBillablePages;
                        }

                        if (!device.IsMonochrome)
                        {
                            string expectedColourMinimumVolume;

                            int swappedOutDeviceColourBillablePages = 0;
                            int swappedOutDeviceTotalPagesPrintedColour = 0;

                            // Pro rata calculation
                            if (device.IsSwap && isFirstBillingPeriod) // Swapped out device first billing period
                            {
                                expectedColourMinimumVolume = _calculationService.CalculateProRataForSwappedOutDevice(device.VolumeColour, startDate, device.EndDeviceDate);
                            }
                            else if (device.IsSwappedInDevice && isFirstBillingPeriod) // Swapped in device first billing period
                            {
                                AdditionalDeviceProperties swappedOutDevice = null;
                                // Find the old device
                                foreach (var oldDevice in _contextData.AdditionalDeviceProperties)
                                {
                                    if (oldDevice.SwappedDeviceID.Equals(device.MpsDeviceId))
                                    {
                                        swappedOutDevice = oldDevice;
                                        break;
                                    }
                                }

                                expectedColourMinimumVolume = _calculationService.CalculateProRataForSwappedInDevice(Int32.Parse(_calculationService.CalculateProportionalVolume(device.VolumeColour, startDate, endDate)), swappedOutDevice, device);
                                swappedOutDeviceColourBillablePages = Int32.Parse(_calculationService.CalculateProRataForSwappedOutDevice(swappedOutDevice.VolumeColour, startDate, swappedOutDevice.EndDeviceDate));
                                swappedOutDeviceTotalPagesPrintedColour = swappedOutDevice.TotalPagesPrintedColour;
                            }
                            else if (isFirstBillingPeriod) // Normal device first billing period
                            {
                                expectedColourMinimumVolume = _calculationService.CalculateProportionalVolume(device.VolumeColour, startDate, endDate);
                            }
                            else // For billing periods other than the first
                            {
                                expectedColourMinimumVolume = device.VolumeColour.ToString();
                            }

                            TestCheck.AssertIsEqual(
                                expectedColourMinimumVolume, HandleNullCase(ws.Cells[rowIndex, ClickCharges_MinimumVolumeColour_Col_No].Value), string.Format(
                                "Minimum Volume colour for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                            expectedColourBillablePages = device.VolumeColour;
                            if (totalPagesPrintedColour > expectedColourBillablePages && !device.IsSwap && !device.IsSwappedInDevice)
                            {
                                expectedColourBillablePages = totalPagesPrintedColour;
                            }
                            else if (device.IsSwappedInDevice && isFirstBillingPeriod)
                            {
                                expectedColourBillablePages = totalPagesPrintedColour + swappedOutDeviceTotalPagesPrintedColour - swappedOutDeviceColourBillablePages;
                            }

                        }
                    }
                    // Pay as you go case
                    else if (_contextData.UsageType.Equals(_translationService.GetUsageTypeText(TranslationKeys.UsageType.PayAsYouGo, _contextData.Culture)))
                    {
                        expectedMonoBillablePages = device.MonoPrintCount;

                        TestCheck.AssertIsEqual(
                                expectedMonoBillablePages, totalPagesPrintedMono, string.Format(
                                "Total Pages Printed Mono for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                        if (!device.IsMonochrome)
                        {
                            expectedColourBillablePages = device.ColorPrintCount;

                            TestCheck.AssertIsEqual(
                                expectedColourBillablePages, totalPagesPrintedColour, string.Format(
                                "Total Pages Printed Colour for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));
                        }
                    }
                        
                    TestCheck.AssertIsEqual(
                        expectedMonoBillablePages.ToString(), HandleNullCase(ws.Cells[rowIndex, ClickCharges_MonoBillablePages_Col_No].Value), string.Format(
                        "Mono Billable pages for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));
                            
                    TestCheck.AssertIsEqual(
                        double.Parse(device.MonoClickPrice), double.Parse(HandleNullCase(ws.Cells[rowIndex, ClickCharges_MonoClickPrice_Col_No].Value)), string.Format(
                        "Mono Click Price for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                    var expectedMonoAmountBilled = expectedMonoBillablePages * double.Parse(device.MonoClickPrice);

                    TestCheck.AssertIsEqual(
                        _calculationService.RoundOffUptoDecimalPlaces(expectedMonoAmountBilled, 5), _calculationService.RoundOffUptoDecimalPlaces(double.Parse(HandleNullCase(ws.Cells[rowIndex, ClickCharges_MonoAmountBilled_Col_No].Value)), 5), string.Format(
                        "Mono Amount Billed for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                    var expectedTotalAmountBilled = expectedMonoAmountBilled;

                    if(!device.IsMonochrome)
                    {
                        TestCheck.AssertIsEqual(
                            expectedColourBillablePages.ToString(), HandleNullCase(ws.Cells[rowIndex, ClickCharges_ColourBillablePages_Col_No].Value), string.Format(
                            "Colour Billable pages for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                        TestCheck.AssertIsEqual(
                            double.Parse(device.ColourClickPrice), double.Parse(HandleNullCase(ws.Cells[rowIndex, ClickCharges_ColourClickPrice_Col_No].Value)), string.Format(
                            "Colour Click Price for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                        var expectedColourAmountBilled = expectedColourBillablePages * double.Parse(device.ColourClickPrice);

                        TestCheck.AssertIsEqual(
                            _calculationService.RoundOffUptoDecimalPlaces(expectedColourAmountBilled, 5), _calculationService.RoundOffUptoDecimalPlaces(double.Parse(HandleNullCase(ws.Cells[rowIndex, ClickCharges_ColourAmountBilled_Col_No].Value)), 5), string.Format(
                            "Colour Amount Billed for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                        expectedTotalAmountBilled += expectedColourAmountBilled;
                    }
                           
                    var displayedTotalAmountBilled = _calculationService.RoundOffUptoDecimalPlaces(Convert.ToDouble(ws.Cells[rowIndex, ClickCharges_TotalAmountBilled_Col_No].Value), 2);

                    TestCheck.AssertIsEqual(
                        _calculationService.RoundOffUptoDecimalPlaces(expectedTotalAmountBilled, 2).ToString(), HandleNullCase(displayedTotalAmountBilled), string.Format(
                        "Mono Amount Billed for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                    expectedClickRateTotal += displayedTotalAmountBilled;
                        
                }

                VerifySummaryWorksheet(
                    excelFilePath, startDate, endDate, HandleNullCase(
                    _calculationService.RoundOffUptoDecimalPlaces(
                    Convert.ToDouble(expectedClickRateTotal), 2)));
            }
        }

        #region private functions

        private void VerifyAgreementDetailsInClickChargesWorksheet(ExcelWorksheet ws, int rowIndex, AdditionalDeviceProperties device, string startDate, string endDate, string excelFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(ws, rowIndex, device, startDate, endDate, excelFilePath);

            // Verify agreement & dealership details
            TestCheck.AssertIsEqual(
                _contextData.AgreementName, HandleNullCase(ws.Cells[rowIndex, ClickCharges_AgreementName_Col_No].Value), string.Format(
                "Agreement Name for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.Country.CountryIso, HandleNullCase(ws.Cells[rowIndex, ClickCharges_Country_Col_No].Value), string.Format(
                "Country ISO for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.DealerName, HandleNullCase(ws.Cells[rowIndex, ClickCharges_DealershipName_Col_No].Value), string.Format(
                "Dealership Name for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.DealerSAPAccountNumber, HandleNullCase(ws.Cells[rowIndex, ClickCharges_DealershipNumber_Col_No].Value), string.Format(
                "Dealership SAP Account Number for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.LeadCodeReference, HandleNullCase(ws.Cells[rowIndex, ClickCharges_LeadCodeReference_Col_No].Value), string.Format(
                "Lead code reference for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.DealerReference, HandleNullCase(ws.Cells[rowIndex, ClickCharges_DealerReference_Col_No].Value), string.Format(
                "Dealer Reference for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.LeasingFinanceReference, HandleNullCase(ws.Cells[rowIndex, ClickCharges_LeasingFinancialReference_Col_No].Value), string.Format(
                "Leasing/Financial Reference for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                device.CostCentre, HandleNullCase(ws.Cells[rowIndex, ClickCharges_CostCentre_Col_No].Value), string.Format(
                "Cost centre for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                device.Model, HandleNullCase(ws.Cells[rowIndex, ClickCharges_ProductName_Col_No].Value), string.Format(
                "Product Name for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));
        }

        private void VerifyAgreementDetailsInSummaryWorksheet(ExcelWorksheet ws, int rowIndex, string startDate, string endDate, string excelFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(ws, rowIndex, startDate, endDate, excelFilePath);

            TestCheck.AssertIsEqual(
                _contextData.AgreementName, HandleNullCase(ws.Cells[rowIndex, Summary_AgreementName_Col_No].Value), string.Format(
                "Agreement Name for agreement {0} and billing dates {1} - {2} in excel file {3} could not be verified", _contextData.AgreementId, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.Country.CountryIso, HandleNullCase(ws.Cells[rowIndex, Summary_Country_Col_No].Value), string.Format(
                "Country ISO for agreement {0} and billing dates {1} - {2} in excel file {3} could not be verified", _contextData.AgreementId, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.DealerName, HandleNullCase(ws.Cells[rowIndex, Summary_DealershipName_Col_No].Value), string.Format(
                "Dealership Name for agreement {0} and billing dates {1} - {2} in excel file {3} could not be verified", _contextData.AgreementId, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.DealerSAPAccountNumber, HandleNullCase(ws.Cells[rowIndex, Summary_DealershipNumber_Col_No].Value), string.Format(
                "Dealership (SAP) Number for agreement {0} and billing dates {1} - {2} in excel file {3} could not be verified", _contextData.AgreementId, startDate, endDate, excelFilePath));
        }

        # endregion
    }
}
