using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Helpers.ExcelHelpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs.StepActions.Dealership
{
    public class MpsValidateDealerReportStepActions : StepActionBase
    {
        public MpsValidateDealerReportStepActions(
            IUserResolver userResolver,
            IDealerReportExcelHelper dealerReportExcelHelper,
            IPageParseHelper pageParseHelper,
            IWebDriverFactory webDriverFactory, 
            IContextData contextData, 
            IPageService pageService, 
            ScenarioContext scenarioContext, 
            IUrlResolver urlResolver, 
            ILoggingService loggingService, 
            IRuntimeSettings runtimeSettings) : base(webDriverFactory, contextData, pageService, scenarioContext, urlResolver, loggingService, runtimeSettings)
        {
            _pageParseHelper = pageParseHelper;
            _dealerReportExcelHelper = dealerReportExcelHelper;
            _userResolver = userResolver;

        }

        private readonly string SnapNamePrefix = typeof(DealerProposalsCreateSummaryPage) + "-forValidateDealerReport";
        private readonly IPageParseHelper _pageParseHelper;
        private readonly IDealerReportExcelHelper _dealerReportExcelHelper;
        private readonly IUserResolver _userResolver;
        private Dictionary<int, IEnumerable<PrinterProperties>> _saveprop = new Dictionary<int, IEnumerable<PrinterProperties>>();

        public void SnapPrintersForVaridateDealerReport(int innerContractId)
        {
            LoggingService.WriteLogOnMethodEntry(innerContractId);
            _saveprop[innerContractId] = ContextData.PrintersProperties;
        }

        public void SnapDealerProposalsCreateSummaryPage(int innerContractId, DealerProposalsCreateSummaryPage dealerProposalsCreateSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(innerContractId, dealerProposalsCreateSummaryPage);
            string snapName = string.Format("{0}.{1}", SnapNamePrefix, innerContractId);
            ContextData.SnapValues[snapName] = _pageParseHelper.ParseSummaryPageValues(dealerProposalsCreateSummaryPage.SeleniumHelper);
        }

        public void DownloadReportAndVerify(DealerReportsDashboardPage dealerReportsDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry( dealerReportsDashboardPage);
            var numberStyles = NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol;
            var excelFilePath = _dealerReportExcelHelper.Download(() => {
                dealerReportsDashboardPage.SeleniumHelper.ClickSafety(dealerReportsDashboardPage.DealerContractElement);
                return true;
            });
            var dealerReportProperties = _dealerReportExcelHelper
                .ParseExcelFileToTable(excelFilePath)
                .CreateSet<DealerReportProperties>();

            var dealerReportProp = dealerReportProperties.FirstOrDefault(kv=>kv.EmailAddress == _userResolver.DealerUsername);
            Assert.NotNull(dealerReportProp, "Target record not found EmailAddress={0} file={1} TotalLinesInFile={2}", 
                _userResolver.DealerUsername, excelFilePath, dealerReportProperties.Count());
            Assert.AreEqual(_saveprop.Count.ToString(), dealerReportProp.NumberOfContractsSigned, "Incorrect NumberOfContractsSigned file={0}", excelFilePath);
            var expectedNumberOfDevices = _saveprop.Sum(kv => kv.Value.Count());
            Assert.AreEqual(expectedNumberOfDevices.ToString(), dealerReportProp.NumberOfDevices, "Incorrect NumberOfDevices file={0}", excelFilePath);
            var expectedTotalValueInContracts = ContextData.SnapValues
                .Where(kv => kv.Key.StartsWith(SnapNamePrefix))
                .Select(kv => kv.Value["SummaryTable.DeviceTotalsTotalPriceNet"])
                .Sum(DeviceTotalsTotalPriceNet => double.Parse(DeviceTotalsTotalPriceNet, numberStyles, ContextData.CultureInfo));
            var actualToralValueInContracts = double.Parse(dealerReportProp.TotalValueInContracts, ContextData.CultureInfo);
            Assert.AreEqual(expectedTotalValueInContracts, actualToralValueInContracts, 2, "Incorrect TotalValueInContracts file={0}", excelFilePath);

            _dealerReportExcelHelper.DeleteExcelFile(excelFilePath);
        }
    }
}
