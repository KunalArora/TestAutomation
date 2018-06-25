using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs.Helpers.ExcelHelpers
{
    public class CppAgreementDevicesExcelHelper : ExcelBaseHelper, ICppAgreementDevicesExcelHelper
    {
        private readonly IContextData _contextData;
        private readonly IPageParseHelper _pageParseHelper;

        private ILoggingService LoggingService { get; set; }

        public CppAgreementDevicesExcelHelper(
            IPageParseHelper pageParseHelper,
            IContextData contextData,
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService
            ): base(loggingService, runtimeSettings, contextData)
        {
            LoggingService = loggingService;
            _contextData = contextData;
            _pageParseHelper = pageParseHelper;
        }

        public IEnumerable<CppAgreementDeviceProperties> Parse(string excelFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath);
            var table = ParseExcelFileToTable(excelFilePath);
            var properties = table.CreateSet<CppAgreementDeviceProperties>();
            return properties;
        }

        public void AssertAreEqualProperties(
            Dictionary<string, string> expectedSummaryPageValues,
            Dictionary<string, string> expectedDevicesPageValues,
            Dictionary<string, string> expectedServiceRequestsPageValues,
            Dictionary<string, string> expectedConsumablesPageValues,
            IEnumerable<CppAgreementDeviceProperties> actualXlsProperties, int agreementId, Country country, string message)
        {
            LoggingService.WriteLogOnMethodEntry(expectedSummaryPageValues, expectedDevicesPageValues, expectedServiceRequestsPageValues, expectedConsumablesPageValues, actualXlsProperties, agreementId, country, message);
            var ci = CultureInfo.GetCultureInfo(_contextData.Culture);
            var numberStyles = NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol;
            var messageFormat = message + "/ key={0}, agreementId=" + agreementId + ", SerialNo={1}";
            var agreementIdString = agreementId.ToString();
            var actualXlsCountWhereAgreementId = actualXlsProperties
                .Where(pp => pp.AgreementNumber == agreementIdString)
                .Count(actualXlsItem =>
            {
                var expectedDevice = _contextData.AdditionalDeviceProperties.FirstOrDefault(pp=>pp.SerialNumber == actualXlsItem.SerialNumber);
                Assert.NotNull(expectedDevice, messageFormat, "AdditionalDeviceProperties not found", actualXlsItem.SerialNumber);
                // Agreement Number
                Assert.AreEqual(agreementIdString, actualXlsItem.AgreementNumber, messageFormat, "AgreementNumber",actualXlsItem.SerialNumber);
                // Agreement Name
                Assert.AreEqual(expectedSummaryPageValues["SummaryTable.AgreementName"], actualXlsItem.AgreementName, messageFormat, "AgreementName",actualXlsItem.SerialNumber);
                // Lead Code Reference
                // Dealer Reference
                // Finance Reference
                Assert.AreEqual(_contextData.LeadCodeReference, actualXlsItem.LeadCodeReference, messageFormat, "LeadCodeReference",actualXlsItem.SerialNumber);
                Assert.AreEqual(_contextData.DealerReference, actualXlsItem.DealerReference, messageFormat, "DealerReference", actualXlsItem.SerialNumber);
                Assert.AreEqual(_contextData.LeasingFinanceReference, actualXlsItem.FinanceReference, messageFormat, "FinanceReference", actualXlsItem.SerialNumber);
                // Product Name
                var model = actualXlsItem.ProductName;
                Assert.AreEqual(expectedSummaryPageValues[model + ".HardwareSku"],actualXlsItem.ProductName, messageFormat, "ProductName", actualXlsItem.SerialNumber);
                // Installation Date (is Today)
                Assert.AreEqual(expectedDevice.StartDeviceDate, actualXlsItem.InstallationDate.Split(' ')[0], messageFormat, "InstallationDate", actualXlsItem.SerialNumber);
                // Cost Centre
                // Location
                // Contact Address
                Assert.AreEqual(expectedDevice.CostCentre,actualXlsItem.CostCentre, messageFormat, "CostCentre", actualXlsItem.SerialNumber);
                Assert.AreEqual(expectedDevice.DeviceLocation, actualXlsItem.Location, messageFormat, "Location", actualXlsItem.SerialNumber);
                Assert.AreEqual(expectedDevice.AddressString, actualXlsItem.ContactAddress, messageFormat, "ContactAddress", actualXlsItem.SerialNumber);
                // Mono Coverage
                // Mono minimum volume
                // Mono Click Price
                Assert.AreEqual((double)expectedDevice.CoverageMono, double.Parse(actualXlsItem.MonoCoverage), 2, messageFormat, "MonoCoverage", actualXlsItem.SerialNumber);
                Assert.AreEqual(expectedSummaryPageValues[model + ".MonoVolume"], actualXlsItem.Monominimumvolume, messageFormat, "Monominimumvolume", actualXlsItem.SerialNumber);
                var expectedDouble = double.Parse(expectedSummaryPageValues[model + ".MonoClickRate"], numberStyles, ci);
                var actualDouble = double.Parse(actualXlsItem.MonoClickPrice);
                Assert.AreEqual(expectedDouble, actualDouble, 2, messageFormat, "MonoClickPrice", actualXlsItem.SerialNumber);
                // Colour Coverage
                // Colour Minimum Volume
                // Colour Click Price
                Assert.AreEqual((double)expectedDevice.CoverageColour, double.Parse(actualXlsItem.ColourCoverage, numberStyles, ci), 2, messageFormat, "ColourCoverage", actualXlsItem.SerialNumber);
                Assert.AreEqual(expectedSummaryPageValues[model + ".ColourVolume"], actualXlsItem.ColourMinimumVolume, messageFormat, "ColourMinimumVolume", actualXlsItem.SerialNumber);
                expectedDouble = double.Parse(expectedSummaryPageValues[model + ".ColourClickRate"], numberStyles, ci);
                actualDouble = double.Parse(actualXlsItem.ColourClickPrice, numberStyles, ci);
                Assert.AreEqual(expectedDouble, actualDouble, 2, messageFormat, "ColourClickPrice", actualXlsItem.SerialNumber);
                // Mono Print Count
                // Colour Print Count
                Assert.AreEqual(expectedDevice.MonoPrintCount, int.Parse(actualXlsItem.MonoPrintCount, numberStyles, ci), messageFormat, "MonoPrintCount", actualXlsItem.SerialNumber);
                Assert.AreEqual(expectedDevice.ColorPrintCount, int.Parse(actualXlsItem.ColourPrintCount, numberStyles, ci), messageFormat, "ColourPrintCount", actualXlsItem.SerialNumber);
                // Latest Reading Date
                var rowArray = Enumerable.Range(0, int.Parse(expectedDevicesPageValues["Devices.Count"])).ToArray().Select(r=>r.ToString());
                var idx = rowArray.FirstOrDefault(row => expectedDevicesPageValues["Devices." + row + ".SerialNo"] == actualXlsItem.SerialNumber);
                var expectedDate = expectedDevicesPageValues["Devices." + idx + ".MeterRead.0.Date"].Split(' ')[0];
                Assert.AreEqual(expectedDate, actualXlsItem.LatestReadingDate, messageFormat, "LatestReadingDate", actualXlsItem.SerialNumber);
                // Latest Service Request Date
                var serviceRequestsList = _pageParseHelper.ToList(expectedServiceRequestsPageValues, "ServiceRequests").Where(rec => rec["SerialNumber"] == actualXlsItem.SerialNumber);
                var serviceRequestsListOrderd = serviceRequestsList.OrderBy(item => DateTime.Parse(item["ClosedDate"], ci)).ToArray();
                expectedDate = serviceRequestsListOrderd[0]["ClosedDate"];
                Assert.AreEqual(expectedDate,actualXlsItem.LatestServiceRequestDate, messageFormat, "LatestServiceRequestDate", actualXlsItem.SerialNumber);

                // Number Of Service Requests
                var expectCount = serviceRequestsList.Count();
                Assert.AreEqual(expectCount, int.Parse(actualXlsItem.NumberOfServiceRequests, ci), messageFormat, "NumberOfServiceRequests", actualXlsItem.SerialNumber);
                // Latest Service Request Status
                // Latest Service Request Subject
                Assert.AreEqual(serviceRequestsListOrderd[0]["Status"], actualXlsItem.LatestServiceRequestStatus, messageFormat, "LatestServiceRequestStatus", actualXlsItem.SerialNumber);
                Assert.AreEqual(serviceRequestsListOrderd[0]["RequestType"], actualXlsItem.LatestServiceRequestSubject, messageFormat, "LatestServiceRequestSubject", actualXlsItem.SerialNumber);

                // Number of Consumable Orders
                var consumablesList = _pageParseHelper.ToList(expectedConsumablesPageValues, "Consumables").Where(item => item["SerialNumber"] == actualXlsItem.SerialNumber);
                Assert.AreEqual(consumablesList.Count(), int.Parse(actualXlsItem.NumberofConsumableOrders, numberStyles, ci), messageFormat, "NumberofConsumableOrders", actualXlsItem.SerialNumber);
                // Latest Consumable Order Date
                //var consumablesListOrderd = consumablesList.OrderBy(item => DateTime.Parse(item["OrderDate"], ci)).ToArray();
                var consumablesListOrderd = consumablesList.OrderBy(item => DateTime.Parse(item["OrderDate-data-sort"], null, DateTimeStyles.RoundtripKind)).ToArray();
                expectedDate = consumablesListOrderd[0]["OrderDate"];
                // TODO MPS-5772 Order Date is not seeked in /mps/dealer/agreement/nnnnnn/consumables page. waiting for fix API.
                //Assert.AreEqual(expectedDate, actual.LatestConsumableOrderDate, messageFormat, "LatestConsumableOrderDate", actual.SerialNumber);
                // Country
                Assert.AreEqual(country.CountryIso, actualXlsItem.Country, messageFormat, "Country", actualXlsItem.SerialNumber);
                return true; // OK
            });
            var expectedDeviceCount = _contextData.AdditionalDeviceProperties.Count();
            Assert.AreEqual(expectedDeviceCount ,actualXlsCountWhereAgreementId, message + " / enough model items agreementId=" + agreementId);
        }

    }

    public class CppAgreementDeviceProperties
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
