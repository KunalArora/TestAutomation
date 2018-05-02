using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Selenium.Lib.Support.MPS;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public class CppAgreementDevicesExcelHelper : ExcelBaseHelper, ICppAgreementDevicesExcelHelper
    {
        private ILoggingService LoggingService { get; set; }

        public CppAgreementDevicesExcelHelper(
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService
            ): base(loggingService, runtimeSettings)
        {
            LoggingService = loggingService;
        }

        public IEnumerable<CppAgreementDeviceProperty> Parse(string excelFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath);
            var table = ParseExcelFileToTable(excelFilePath);
            var properties = table.CreateSet<CppAgreementDeviceProperty>();
            return properties;
        }

        public void AssertAreEqualProperties(Dictionary<string, string> expectedSummaryPageValues, IEnumerable<CppAgreementDeviceProperty> actualProperties, int agreementId, Country country, string message)
        {
            LoggingService.WriteLogOnMethodEntry(expectedSummaryPageValues, actualProperties, agreementId, message);
            var currencySymbol = MpsUtil.GetCurrencySymbol(country.CountryIso);
            var agreementIdString = agreementId.ToString();
            var actualProps = actualProperties.Where(pp => pp.AgreementNumber == agreementIdString);
            var expectedModelCount = expectedSummaryPageValues.Count(kvp => kvp.Key.Contains(".HardwareSku"));
            //note: can't use AreEquals because Duplicate record exists.
            Assert.True(expectedModelCount<= actualProps.Count(), message + " / enough model items agreementId=" + agreementId);
            actualProps.Count(actual =>
            {
                Assert.AreEqual(expectedSummaryPageValues["SummaryTable.AgreementName"], actual.AgreementName, message + "/ AgreementName not match agreementId=" + agreementId);
                var model = actual.ProductName;
                Assert.AreEqual(expectedSummaryPageValues[model+".MonoVolume"], actual.Monominimumvolume, message + "/ MonoVolume not match agreementId=" + agreementId);
                var expectedDouble =double.Parse(expectedSummaryPageValues[model + ".MonoClickRate"].Replace(currencySymbol, ""));
                var actualDouble = double.Parse(actual.MonoClickPrice);
                Assert.AreEqual(expectedDouble, actualDouble, 2, message + "/ MonoClickRate not match agreementId=" + agreementId);
                Assert.AreEqual(expectedSummaryPageValues[model + ".ColourVolume"], actual.ColourMinimumVolume, message + "/ ColourVolume not match agreementId=" + agreementId);
                expectedDouble = double.Parse(expectedSummaryPageValues[model + ".ColourClickRate"].Replace(currencySymbol, ""));
                actualDouble = double.Parse(actual.ColourClickPrice);
                Assert.AreEqual(expectedDouble, actualDouble, 2, message + "/ ColourClickRate not match agreementId=" + agreementId);            
                return true; // OK
            });
        }

    }

    public class CppAgreementDeviceProperty
    {
        public string DealerNumber { get; set; }
        public string DealerName { get; set; }
        public string AgreementNumber { get; set; }
        public string AgreementName { get; set; }
        public string LeadCodeReference { get; set; }
        public string DealerReference { get; set; }
        public string FinanceReference { get; set; }
        public string ProductName { get; set; }
        public string SerialNumber { get; set; }
        public string InstallationDate { get; set; }
        public string RemovalDate { get; set; }
        public string DeviceStatus { get; set; }
        public string CommunicationStatus { get; set; }
        public string CommunicationMethod { get; set; }
        public string ProductCategory { get; set; }
        public string CostCentre { get; set; }
        public string Location { get; set; }
        public string ContactName { get; set; }
        public string ContactAddress { get; set; }
        public string InstallPrice { get; set; }
        public string ServicePackMaterial { get; set; }
        public string ServicePackDescription { get; set; }
        public string ServicePackPrice { get; set; }
        public string MonoCoverage { get; set; }
        public string Monominimumvolume { get; set; }
        public string MonoClickPrice { get; set; }
        public string ColourCoverage { get; set; }
        public string ColourMinimumVolume { get; set; }
        public string ColourClickPrice { get; set; }
        public string MonoPrintCount { get; set; }
        public string ColourPrintCount { get; set; }
        public string LatestReadingDate { get; set; }
        public string LatestServiceRequestDate { get; set; }
        public string NumberOfServiceRequests { get; set; }
        public string LatestServiceRequestStatus { get; set; }
        public string LatestServiceRequestSubject { get; set; }
        public string NumberofConsumableOrders { get; set; }
        public string LatestConsumableOrderDate { get; set; }
        public string Country { get; set; }        
    }
}
