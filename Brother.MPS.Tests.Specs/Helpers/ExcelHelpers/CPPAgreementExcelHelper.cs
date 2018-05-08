using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public class CPPAgreementExcelHelper: ExcelBaseHelper, ICPPAgreementExcelHelper
    {
        // Report Tab sheet properties
        private const int Report_Country_Col_No = 1;
        private const int Report_DealershipNumber_Col_No = 2;
        private const int Report_DealerName_Col_No = 3;
        private const int Report_AgreementNumber_Col_No = 4;
        private const int Report_AgreementName_Col_No = 5;
        private const int Report_LeadCodeReference_Col_No = 6;
        private const int Report_DealerReference_Col_No = 7;
        private const int Report_FinanceReference_Col_No = 8;
        private const int Report_DateCreated_Col_No = 9;
        private const int Report_Status_Col_No = 10;
        private const int Report_UsageType_Col_No = 11;
        private const int Report_AgreementTerm_Col_No = 12;
        private const int Report_NumberOfDevices_Col_No = 13;
        private const int Report_NumberOfDevicesInstalled_Col_No = 14;
        private const int Report_InstallationTotal_Col_No = 15;
        private const int Report_ServiceTotal_Col_No = 16;
        private const int Report_ClickTotal_Col_No = 17;
        private const int Report_StartDate_Col_No = 18;
        private const int Report_EndDate_Col_No = 19;
        private const int Report_SalesRep_Col_No = 20;

        private ILoggingService LoggingService { get; set; }
        private ITranslationService _translationService { get; set; }
        private IContextData _contextData;

        public CPPAgreementExcelHelper(
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService,
            IContextData contextData,
            ITranslationService translationService): base(loggingService, runtimeSettings)
        {
            LoggingService = loggingService;
            _contextData = contextData;
            _translationService = translationService;
        }

        public void VerifyAgreementDetails(string excelFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath);

            var fileInfo = new FileInfo(excelFilePath);

            Assert.True(fileInfo.Exists, string.Format("Excel sheet = {0} does not exist", excelFilePath));

            using (ExcelPackage pack = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet ws = pack.Workbook.Worksheets.First();

                int rowIndex = 2;

                while (!(HandleNullCase(ws.Cells[rowIndex, Report_AgreementNumber_Col_No].Value) == _contextData.AgreementId.ToString()))
                {
                    rowIndex++;
                    if (rowIndex > GetNumberOfRows(excelFilePath))
                    {
                        TestCheck.AssertFailTest(
                            string.Format(
                            "Information for agreement {0} not present in the Report tab sheet of excel file {1}", _contextData.AgreementId, excelFilePath));
                    }
                }

                int totalDevices = _contextData.PrintersProperties.Sum(item => item.Quantity);

                TestCheck.AssertIsEqual(
                    _contextData.Country.CountryIso, HandleNullCase(ws.Cells[rowIndex, Report_Country_Col_No].Value), string.Format(
                    "Country ISO for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqual(
                    _contextData.DealerSAPAccountNumber, HandleNullCase(ws.Cells[rowIndex, Report_DealershipNumber_Col_No].Value), string.Format(
                    "Dealership (SAP) Number for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqual(
                    _contextData.DealerName, HandleNullCase(ws.Cells[rowIndex, Report_DealerName_Col_No].Value), string.Format(
                    "Dealer Name for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqual(
                    _contextData.AgreementName, HandleNullCase(ws.Cells[rowIndex, Report_AgreementName_Col_No].Value), string.Format(
                    "Agreement Name for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqual(
                    _contextData.LeadCodeReference, HandleNullCase(ws.Cells[rowIndex, Report_LeadCodeReference_Col_No].Value), string.Format(
                    "Lead code reference for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqual(
                    _contextData.DealerReference, HandleNullCase(ws.Cells[rowIndex, Report_DealerReference_Col_No].Value), string.Format(
                    "Dealer Reference for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqual(
                    _contextData.LeasingFinanceReference, HandleNullCase(ws.Cells[rowIndex, Report_FinanceReference_Col_No].Value), string.Format(
                    "Leasing/Financial Reference for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqual(
                    _contextData.DateCreated, FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, Report_DateCreated_Col_No].Value)), string.Format(
                    "Date Created for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                // Verify Agreement Status is Running
                TestCheck.AssertIsEqual(
                    _translationService.GetAgreementStatusText(TranslationKeys.AgreementStatus.Running, _contextData.Culture), HandleNullCase(ws.Cells[rowIndex, Report_Status_Col_No].Value), string.Format(
                    "Status for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));


                TestCheck.AssertIsEqual(
                    _contextData.UsageType, HandleNullCase(ws.Cells[rowIndex, Report_UsageType_Col_No].Value), string.Format(
                    "Usage Type for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                // Agreement Term in months
                TestCheck.AssertIsEqual(
                    (Int32.Parse(_contextData.ContractTerm[0].ToString())*12).ToString(), HandleNullCase(ws.Cells[rowIndex, Report_AgreementTerm_Col_No].Value), string.Format(
                    "Agreement Term for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqual(
                    totalDevices.ToString(), HandleNullCase(ws.Cells[rowIndex, Report_NumberOfDevices_Col_No].Value), string.Format(
                    "Number of devices for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqual(
                    totalDevices.ToString(), HandleNullCase(ws.Cells[rowIndex, Report_NumberOfDevicesInstalled_Col_No].Value), string.Format(
                    "Number of devices installed for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqualDouble(
                    _contextData.InstallationPackTotal, double.Parse(HandleNullCase(ws.Cells[rowIndex, Report_InstallationTotal_Col_No].Value)), 2, string.Format(
                    "Installation Pack Total for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqualDouble(
                    _contextData.ServicePackTotal, double.Parse(HandleNullCase(ws.Cells[rowIndex, Report_ServiceTotal_Col_No].Value)), 2, string.Format(
                    "Service Pack Total for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqualDouble(
                   _contextData.ClickRateTotal, double.Parse(HandleNullCase(ws.Cells[rowIndex, Report_ClickTotal_Col_No].Value)), 2, string.Format(
                   "Click Rate Total for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqual(
                    _contextData.StartDate, FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, Report_StartDate_Col_No].Value)), string.Format(
                    "Start Date for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));

                TestCheck.AssertIsEqual(
                    _contextData.EndDate, FormatExcelSerialDate(HandleNullCase(ws.Cells[rowIndex, Report_EndDate_Col_No].Value)), string.Format(
                    "End Date for agreement {0} in excel file {1} could not be verified", _contextData.AgreementId, excelFilePath));
            }
        }
    }
}
