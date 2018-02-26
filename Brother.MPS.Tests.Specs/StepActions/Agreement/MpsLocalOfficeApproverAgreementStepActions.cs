using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers.ExcelHelpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Agreement
{
    public class MpsLocalOfficeApproverAgreementStepActions : MpsLocalOfficeStepActions
    {
        private readonly IWebDriver _loApproverWebDriver;

        public MpsLocalOfficeApproverAgreementStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ILoggingService loggingService,
            IRuntimeSettings runtimeSettings,
            ITranslationService translationService,
            IRunCommandService runCommandService,
            IClickBillExcelHelper clickBillExcelHelper)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings, translationService, runCommandService, clickBillExcelHelper)
        {
            _loApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
        }

        public DataQueryPage NavigateToReportsDataQuery(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverDashBoardPage);
            ClickSafety(localOfficeApproverDashBoardPage.LocalApprovalReportingElement, localOfficeApproverDashBoardPage);
            var reportingDashboardPage = PageService.GetPageObject<ReportingDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _loApproverWebDriver);
            ClickSafety(reportingDashboardPage.DataQueryElement, reportingDashboardPage);
            return PageService.GetPageObject<DataQueryPage>(RuntimeSettings.DefaultPageObjectTimeout, _loApproverWebDriver);
        }

        public LocalOfficeAgreementDevicesPage NavigateToAgreementDevicesPage(DataQueryPage dataQueryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage);
            return NavigateToAgreementDevicesPage(dataQueryPage, _loApproverWebDriver);
        }

        public LocalOfficeAgreementDevicesPage SendBulkInstallationRequest(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);
            return SendBulkInstallationRequest(localOfficeAgreementDevicesPage, _loApproverWebDriver);
        }

        public LocalOfficeAgreementDevicesPage SendSingleInstallationRequests(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);
            return SendSingleInstallationRequests(localOfficeAgreementDevicesPage, _loApproverWebDriver);
        }
    }
}
