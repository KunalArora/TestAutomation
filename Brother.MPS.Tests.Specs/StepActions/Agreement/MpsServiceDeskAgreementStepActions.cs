﻿using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
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
            ILoggingService loggingService,
            IRuntimeSettings runtimeSettings,
            ITranslationService translationService,
            IRunCommandService runCommandService,
            IDevicesExcelHelper devicesExcelHelper,
            IClickBillExcelHelper clickBillExcelHelper,
            IServiceInstallationBillExcelHelper serviceInstallationBillExcelHelper,
            IUserResolver userResolver,
            ICalculationService calculationService)
            : base(webDriverFactory, 
            contextData, 
            pageService, 
            context, 
            urlResolver, 
            loggingService, 
            runtimeSettings, 
            translationService, 
            runCommandService, 
            devicesExcelHelper, 
            clickBillExcelHelper, 
            serviceInstallationBillExcelHelper, 
            userResolver,
            calculationService)
        {
            _serviceDeskWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeSupportDesk);
            _contextData = contextData;
            _translationService = translationService;
        }

        public DataQueryPage NavigateToReportsDataQuery(ServiceDeskDashBoardPage serviceDeskDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(serviceDeskDashBoardPage);
            ClickSafety(serviceDeskDashBoardPage.ServiceReportLink, serviceDeskDashBoardPage);
            var reportingDashboardPage = PageService.GetPageObject<LocalOfficeReportsDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);
            ClickSafety(reportingDashboardPage.DataQueryElement, reportingDashboardPage);
            return PageService.GetPageObject<DataQueryPage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);
        }

        public LocalOfficeAgreementDevicesPage NavigateToAgreementDevicesPage(DataQueryPage dataQueryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage);
            return NavigateToAgreementDevicesPage(dataQueryPage, _serviceDeskWebDriver);
        }
 
        public LocalOfficeAgreementDevicesPage SendBulkInstallationRequest(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);
            return SendBulkInstallationRequest(localOfficeAgreementDevicesPage, _serviceDeskWebDriver);
        }

        public LocalOfficeAgreementDevicesPage SendSingleInstallationRequests(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);
            return SendSingleInstallationRequests(localOfficeAgreementDevicesPage, _serviceDeskWebDriver);           
        }

        public void VerifyServiceRequest(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);

            string resourceServiceRequestStatusNew = _translationService.GetServiceRequestStatusText(TranslationKeys.ServiceRequestStatus.New, _contextData.Culture);

            ClickSafety(localOfficeAgreementDevicesPage.LocalOfficeDashboardButtonLink, localOfficeAgreementDevicesPage);
            var serviceDeskDashBoardPage = PageService.GetPageObject<ServiceDeskDashBoardPage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);

            ClickSafety(serviceDeskDashBoardPage.ServiceDeskLink, serviceDeskDashBoardPage);
            var serviceDeskServiceDeskDashBoardPage = PageService.GetPageObject<ServiceDeskServiceDeskDashBoardPage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);

            ClickSafety(serviceDeskServiceDeskDashBoardPage.ServiceRequestsLink, serviceDeskServiceDeskDashBoardPage);
            var serviceDeskServiceRequestsActivePage = PageService.GetPageObject<ServiceDeskServiceRequestsActivePage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);

            foreach(var device in _contextData.AdditionalDeviceProperties)
            {
                serviceDeskServiceRequestsActivePage.VerifyServiceRequest(device.Model, device.SerialNumber, device.ServiceRequestId, device.ServiceRequestType, resourceServiceRequestStatusNew);
                serviceDeskServiceRequestsActivePage = Refresh(serviceDeskServiceRequestsActivePage);
            }
        }

        public void CloseServiceRequest(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);

            ClickSafety(localOfficeAgreementDevicesPage.LocalOfficeDashboardButtonLink, localOfficeAgreementDevicesPage);
            var serviceDeskDashBoardPage = PageService.GetPageObject<ServiceDeskDashBoardPage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);

            ClickSafety(serviceDeskDashBoardPage.ServiceDeskLink, serviceDeskDashBoardPage);
            var serviceDeskServiceDeskDashBoardPage = PageService.GetPageObject<ServiceDeskServiceDeskDashBoardPage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);

            ClickSafety(serviceDeskServiceDeskDashBoardPage.ServiceRequestsLink, serviceDeskServiceDeskDashBoardPage);
            var serviceDeskServiceRequestsActivePage = PageService.GetPageObject<ServiceDeskServiceRequestsActivePage>(RuntimeSettings.DefaultPageObjectTimeout, _serviceDeskWebDriver);

            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                device.ServiceRequestReplyMessage = serviceDeskServiceRequestsActivePage.CloseServiceRequest(device.Model, device.SerialNumber, device.ServiceRequestId);
                device.ClosedServiceRequestCount++;
                serviceDeskServiceRequestsActivePage = Refresh(serviceDeskServiceRequestsActivePage);
            }
        }

        public LocalOfficeAgreementDevicesPage SendSwapDeviceInstallationRequest(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, string swapDeviceType)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage, swapDeviceType);
            return SendSwapDeviceInstallationRequest(localOfficeAgreementDevicesPage, swapDeviceType, _serviceDeskWebDriver);
        }

        public LocalOfficeAgreementDevicesPage VerifyStatusOfSwappedInAndSwappedOutDevices(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);
            return VerifyStatusOfSwappedInAndSwappedOutDevices(localOfficeAgreementDevicesPage, _serviceDeskWebDriver);
        }
    }
}