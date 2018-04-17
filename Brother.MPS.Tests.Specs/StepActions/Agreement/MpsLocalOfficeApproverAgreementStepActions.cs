using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
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
        private readonly IContextData _contextData;

        public MpsLocalOfficeApproverAgreementStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ILoggingService loggingService,
            IRuntimeSettings runtimeSettings,
            ITranslationService translationService,
            IRunCommandService runCommandService,
            IDevicesExcelHelper devicesExcelHelper,
            IClickBillExcelHelper clickBillExcelHelper,
            IServiceInstallationBillExcelHelper serviceInstallationBillExcelHelper)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings, translationService, runCommandService, devicesExcelHelper, clickBillExcelHelper, serviceInstallationBillExcelHelper)
        {
            _loApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
            _contextData = contextData;
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

        public LocalOfficeAgreementSummaryPage RefinePreInstallAgreementAndNavigateToSummaryPage(DataQueryPage dataQueryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage);
            return RefinePreInstallAgreementAndNavigateToSummaryPage(dataQueryPage, _loApproverWebDriver);
        }

        public LocalOfficeAgreementDetailsPage ApplySpecialPricing(LocalOfficeAgreementSummaryPage localOfficeApproverAgreementSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverAgreementSummaryPage);

            bool isInstallationTab, isServiceTab;

            localOfficeApproverAgreementSummaryPage.ClickSpecialPricing();
            var localOfficeApproverAgreementManageSpecialPricing = PageService.GetPageObject<LocalOfficeAgreementManageSpecialPricing>(
                RuntimeSettings.DefaultPageObjectTimeout, _loApproverWebDriver);

            localOfficeApproverAgreementManageSpecialPricing.VerifyDisplayOfAppropriateTabs(
                _contextData.PrintersProperties, _contextData.ServicePackType, _contextData.Culture, out isInstallationTab, out isServiceTab);

            if(isInstallationTab)
            {
                localOfficeApproverAgreementManageSpecialPricing.EditInstallationPricesAndProceed(_contextData.PrintersProperties);
            }

            if(isServiceTab)
            {
                localOfficeApproverAgreementManageSpecialPricing.EditServicePricesAndProceed(_contextData.PrintersProperties);
            }

            localOfficeApproverAgreementManageSpecialPricing.EditClickPricesAndProceed(
                _contextData.PrintersProperties, _contextData.ServicePackType, _contextData.Culture);

            localOfficeApproverAgreementManageSpecialPricing.ConfirmSpecialPricingAndApply();

            return PageService.GetPageObject<LocalOfficeAgreementDetailsPage>(RuntimeSettings.DefaultPageObjectTimeout, _loApproverWebDriver);
        }

        public void VerifySpecialPricing(LocalOfficeAgreementDetailsPage localOfficeApproverAgreementDetailsPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverAgreementDetailsPage);

            localOfficeApproverAgreementDetailsPage.VerifySpecialPricing(_contextData.PrintersProperties, _contextData.ServicePackType, _contextData.Culture);
        }

        public LocalOfficeAgreementDevicesPage SendReinstallDeviceRequest(LocalOfficeAgreementDevicesPage localOfficeApproverAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverAgreementDevicesPage);

            return SendReinstallDeviceRequest(localOfficeApproverAgreementDevicesPage, _loApproverWebDriver);
        }
    }
}
