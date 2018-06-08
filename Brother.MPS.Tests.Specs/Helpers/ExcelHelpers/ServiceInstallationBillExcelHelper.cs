using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Specs.Services;
using NUnit.Framework;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public class ServiceInstallationBillExcelHelper: ExcelBaseHelper, IServiceInstallationBillExcelHelper
    {
        // Detail excelsheet properties
        private const int Detail_Country_Col_No = 1;
        private const int Detail_DealershipNumber_Col_No = 2;
        private const int Detail_DealershipName_Col_No = 3;
        private const int Detail_AgreementNumber_Col_No = 4;
        private const int Detail_AgreementName_Col_No = 5;
        private const int Detail_LeadCodeReference_Col_No = 6;
        private const int Detail_DealerReference_Col_No = 7;
        private const int Detail_LeasingFinancialReference_Col_No = 8;
        private const int Detail_CostCentre_Col_No = 9;
        private const int Detail_BillPeriodFrom_Col_No = 10;
        private const int Detail_BillPeriodTo_Col_No = 11;
        private const int Detail_ProductName_Col_No = 12;
        private const int Detail_SerialNumber_Col_No = 13;
        private const int Detail_InstallationDate_Col_No = 14;
        private const int Detail_InstallationCharge_Col_No = 15;
        private const int Detail_ServicePackDescription_Col_No = 16;
        private const int Detail_ServicePackCharge_Col_No = 17;
        private const int Detail_ServiceInstallationTotal_Col_No = 18;
        private const int Detail_DeviceLocation_Col_No = 19;
        private const int Detail_CustomerName_Col_No = 20;
        private const int Detail_ContactFirstName_Col_No = 21;
        private const int Detail_ContactLastName_Col_No = 22;
        private const int Detail_Telephone_Col_No = 23;
        private const int Detail_Email_Col_No = 24;
        private const int Detail_AddressNumber_Col_No = 25;
        private const int Detail_AddressStreet_Col_No = 26;
        private const int Detail_AddressArea_Col_No = 27;
        private const int Detail_AddressTown_Col_No = 28;
        private const int Detail_AddressPostCode_Col_No = 29;
        private const int Detail_AddressRegion_Col_No = 30;

        private ILoggingService LoggingService { get; set; }
        private IContextData _contextData;
        private ICalculationService _calculationService { get; set; }

        public ServiceInstallationBillExcelHelper(
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService,
            IContextData contextData,
            ICalculationService calculationService
            ): base(loggingService, runtimeSettings, contextData)
        {
            LoggingService = loggingService;
            _contextData = contextData;
            _calculationService = calculationService;
        }

        public void VerifyDetailWorksheet(string excelFilePath, string startDate, string endDate, string expectedServiceInstallationTotal)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath, startDate, endDate, expectedServiceInstallationTotal);

            var fileInfo = new FileInfo(excelFilePath);
            Assert.True(fileInfo.Exists, string.Format("Excel sheet = {0} does not exist", excelFilePath));
          
            
            using (ExcelPackage pack = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.First();

                double calculatedServiceInstallationTotal = 0;

                foreach (var device in _contextData.AdditionalDeviceProperties)
                {
                    int rowIndex = GetNumberOfRows(excelFilePath, 1);

                    if (device.InstallationPack.ToLower().Equals("no") && device.ServicePack.ToLower().Equals("no"))
                    {
                        // Device information should not be present in the excel sheet
                        while (!(HandleNullCase(ws.Cells[rowIndex, Detail_SerialNumber_Col_No].Value) == device.SerialNumber &&
                            FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, Detail_BillPeriodFrom_Col_No].Value)) == startDate &&
                            FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, Detail_BillPeriodTo_Col_No].Value)) == endDate))
                        {
                            rowIndex--;
                            if (rowIndex < 2)
                            {
                                break;
                            }
                        }

                        if (rowIndex >= 2)
                        {
                            TestCheck.AssertFailTest(
                                string.Format(
                                "Information for device with serial number {0} with billing dates {1} - {2} should not be present in the Detail tab sheet of excel file {3}, as service pack or installation pack have not been selected for this device", device.SerialNumber, startDate, endDate, excelFilePath));
                        }
                    }
                    else
                    {
                        if(device.IsSwappedInDevice) // Swapped In device information will not be present in the service/installation bill
                        {
                            continue;
                        }

                        while (!(HandleNullCase(ws.Cells[rowIndex, Detail_SerialNumber_Col_No].Value) == device.SerialNumber &&
                            FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, Detail_BillPeriodFrom_Col_No].Value)) == startDate &&
                            FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, Detail_BillPeriodTo_Col_No].Value)) == endDate))
                        {
                            rowIndex--;
                            if (rowIndex < 2)
                            {
                                TestCheck.AssertFailTest(
                                    string.Format(
                                    "Information for device with serial number {0} with billing dates {1} - {2} not present in the Detail tab sheet of excel file {3}", device.SerialNumber, startDate, endDate, excelFilePath));
                            }
                        }

                        VerifyAgreementDetailsInDetailWorksheet(ws, rowIndex, device, startDate, endDate, excelFilePath);

                        TestCheck.AssertIsEqual(
                            double.Parse(device.InstallationPackPrice), _calculationService.RoundOffUptoDecimalPlaces(double.Parse(HandleNullCase(ws.Cells[rowIndex, Detail_InstallationCharge_Col_No].Value)), 2), string.Format(
                            "Installation Charge for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                        TestCheck.AssertIsEqual(
                            double.Parse(device.ServicePackPrice), _calculationService.RoundOffUptoDecimalPlaces(double.Parse(HandleNullCase(ws.Cells[rowIndex, Detail_ServicePackCharge_Col_No].Value)), 2), string.Format(
                            "Service Pack Charge for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                        var displayedServiceInstallationTotal = _calculationService.RoundOffUptoDecimalPlaces(double.Parse(HandleNullCase(ws.Cells[rowIndex, Detail_ServiceInstallationTotal_Col_No].Value)), 2);

                        TestCheck.AssertIsEqual(
                            double.Parse(device.ServicePackPrice) + double.Parse(device.InstallationPackPrice), displayedServiceInstallationTotal, string.Format(
                            "Service Pack Charge for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

                        calculatedServiceInstallationTotal += displayedServiceInstallationTotal;
                    }
                }

                TestCheck.AssertIsEqual(
                    double.Parse(expectedServiceInstallationTotal), calculatedServiceInstallationTotal, string.Format(
                    "Net Total of Service Pack/Installation Charge for agreement {0} and billing dates {1} - {2} in excel file {3} could not be verified", _contextData.AgreementId, startDate, endDate, excelFilePath));                 
            }
        }


        #region private functions

        private void VerifyAgreementDetailsInDetailWorksheet(ExcelWorksheet ws, int rowIndex, AdditionalDeviceProperties device, string startDate, string endDate, string excelFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(ws, rowIndex, device, startDate, endDate, excelFilePath);

            // Verify agreement & dealership details
            TestCheck.AssertIsEqual(
                _contextData.AgreementName, HandleNullCase(ws.Cells[rowIndex, Detail_AgreementName_Col_No].Value), string.Format(
                "Agreement Name for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.Country.CountryIso, HandleNullCase(ws.Cells[rowIndex, Detail_Country_Col_No].Value), string.Format(
                "Country ISO for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.DealerName, HandleNullCase(ws.Cells[rowIndex, Detail_DealershipName_Col_No].Value), string.Format(
                "Dealership Name for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.DealerSAPAccountNumber, HandleNullCase(ws.Cells[rowIndex, Detail_DealershipNumber_Col_No].Value), string.Format(
                "Dealership SAP Account Number for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.LeadCodeReference, HandleNullCase(ws.Cells[rowIndex, Detail_LeadCodeReference_Col_No].Value), string.Format(
                "Lead code reference for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.DealerReference, HandleNullCase(ws.Cells[rowIndex, Detail_DealerReference_Col_No].Value), string.Format(
                "Dealer Reference for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                _contextData.LeasingFinanceReference, HandleNullCase(ws.Cells[rowIndex, Detail_LeasingFinancialReference_Col_No].Value), string.Format(
                "Leasing/Financial Reference for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                device.CostCentre, HandleNullCase(ws.Cells[rowIndex, Detail_CostCentre_Col_No].Value), string.Format(
                "Cost centre for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));

            TestCheck.AssertIsEqual(
                device.Model, HandleNullCase(ws.Cells[rowIndex, Detail_ProductName_Col_No].Value), string.Format(
                "Product Name for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));
            
            TestCheck.AssertIsEqual(
                device.DeviceLocation, HandleNullCase(ws.Cells[rowIndex, Detail_DeviceLocation_Col_No].Value), string.Format(
                "Device Location for agreement {0}, device {1} and billing dates {2} - {3} in excel file {4} could not be verified", _contextData.AgreementId, device.SerialNumber, startDate, endDate, excelFilePath));
        }

        #endregion
    }
}
