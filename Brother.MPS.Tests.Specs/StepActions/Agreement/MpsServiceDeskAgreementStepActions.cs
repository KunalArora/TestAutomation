using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Agreement
{
    public class MpsServiceDeskAgreementStepActions : MpsLocalOfficeStepActions
    {
        private readonly IWebDriver _serviceDeskWebDriver;
        private readonly IContextData _contextData;
        private readonly ITranslationService _translationService;

        public MpsServiceDeskAgreementStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            ITranslationService translationService,
            IRunCommandService runCommandService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings, translationService, runCommandService)
        {
            _serviceDeskWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeSupportDesk);
            _contextData = contextData;
            _translationService = translationService;
        }

        public DataQueryPage NavigateToReportsDataQuery(ServiceDeskDashBoardPage serviceDeskDashBoardPage)
        {
            ClickSafety(serviceDeskDashBoardPage.ServiceReportLink, serviceDeskDashBoardPage);
            var reportingDashboardPage = PageService.GetPageObject<ReportingDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);
            ClickSafety(reportingDashboardPage.DataQueryElement, reportingDashboardPage);
            return PageService.GetPageObject<DataQueryPage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);
        }

        public LocalOfficeAgreementDevicesPage NavigateToAgreementDevicesPage(DataQueryPage dataQueryPage)
        {
            return NavigateToAgreementDevicesPage(dataQueryPage, _serviceDeskWebDriver);
        }
 
        public LocalOfficeAgreementDevicesPage SendBulkInstallationRequest(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            return SendBulkInstallationRequest(localOfficeAgreementDevicesPage, _serviceDeskWebDriver);
        }

        public LocalOfficeAgreementDevicesPage SendSingleInstallationRequests(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            return SendSingleInstallationRequests(localOfficeAgreementDevicesPage, _serviceDeskWebDriver);           
        }

        public void VerifyServiceRequestAndCloseIt(ServiceDeskDashBoardPage serviceDeskDashBoardPage)
        {
            string resourceServiceRequestStatusNew = _translationService.GetServiceRequestStatusText(TranslationKeys.ServiceRequestStatus.New, _contextData.Culture);

            ClickSafety(serviceDeskDashBoardPage.ServiceDeskLink, serviceDeskDashBoardPage);
            var serviceDeskServiceDeskDashBoardPage = PageService.GetPageObject<ServiceDeskServiceDeskDashBoardPage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);

            ClickSafety(serviceDeskServiceDeskDashBoardPage.ServiceRequestsLink, serviceDeskServiceDeskDashBoardPage);
            var serviceDeskServiceRequestsActivePage = PageService.GetPageObject<ServiceDeskServiceRequestsActivePage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);

            foreach(var device in _contextData.AdditionalDeviceProperties)
            {
                device.ServiceRequestReplyMessage = serviceDeskServiceRequestsActivePage.VerifyAndCloseServiceRequest(device.Model, device.SerialNumber, device.ServiceRequestId, device.ServiceRequestType, resourceServiceRequestStatusNew);
                _serviceDeskWebDriver.Navigate().Refresh();
                serviceDeskServiceRequestsActivePage = PageService.GetPageObject<ServiceDeskServiceRequestsActivePage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);
            }
        }
    }
}
