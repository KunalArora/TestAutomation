using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Contract
{
    public class MpsDealerContractStepActions: StepActionBase
    {
        private readonly IWebDriver _dealerWebDriver;
        private readonly IContextData _contextData;
        private readonly DeviceSimulatorService _deviceSimulatorService;
        private readonly RunCommandService _runCommandService;

        public MpsDealerContractStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            RuntimeSettings runtimeSettings,
            DeviceSimulatorService deviceSimulatorService,
            RunCommandService runCommandService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
            _runCommandService = runCommandService;
        }

        public DealerContractsPage NavigateToContractsPage(DealerDashBoardPage dealerDashboardPage)
        {
            dealerDashboardPage.ExistingContractLinkElement.Click();
            return PageService.GetPageObject<DealerContractsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerContractsAcceptedPage NavigateToContractsAcceptedPage(DealerContractsPage dealerContractsPage)
        {
            dealerContractsPage.AcceptedTabElement.Click();
            return PageService.GetPageObject<DealerContractsAcceptedPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerManageDevicesPage NavigateToManageDevicesPageFix(DealerContractsAcceptedPage dealerContractsAcceptedPage, int proposalId)
        {
            dealerContractsAcceptedPage.NavigateToSpecificManageDevicesPage(proposalId, RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void InstallationCompleteCheck(DealerManageDevicesPage _dealerManageDevicesPage, IEnumerable<PrinterProperties> products)
        {
            foreach (var product in products)
            {
                _dealerManageDevicesPage.InstallationCompleteCheck(product.SerialNumber, RuntimeSettings.DefaultFindElementTimeout);
            }
            CheckForUpdatedPrintCount(_dealerManageDevicesPage);
        }

        public void UpdatePrintCounts()
        {
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                product.TotalPageCount = (product.MonoPrintCount + product.ColorPrintCount);
                string deviceId = product.DeviceId;
                _deviceSimulatorService.SetPrintCounts(deviceId, product.MonoPrintCount, product.ColorPrintCount);
                _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
            }
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId);
        }

        public DealerManageDevicesPage RetrieveDealerManageDevicesPage()
        {
            string currentUrl = _dealerWebDriver.Url;
            return PageService.LoadUrl<DealerManageDevicesPage>(currentUrl, RuntimeSettings.DefaultPageLoadTimeout, ".active a[href=\"/mps/dealer/contracts/manage-devices/manage\"]", true, _dealerWebDriver);
        }

        public void CheckForUpdatedPrintCount(DealerManageDevicesPage dealerManageDevicesPage)
        {
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                var totalPageCount = product.TotalPageCount; 
                dealerManageDevicesPage.CheckForUpdatedPrintCount(_dealerWebDriver, totalPageCount, product.SerialNumber, RuntimeSettings.DefaultRetryCount, RuntimeSettings.DefaultFindElementTimeout);
            }
        }

        //Similar function is already present in this file so, refactor this particular function.
        public void MoveToAcceptedContractsTab(DealerContractsPage dealerContractsPage)
        {
            dealerContractsPage.MoveToAcceptedContracts(RuntimeSettings.DefaultFindElementTimeout);
        }
        
        public void FilterContractUsingProposalId(DealerContractsPage dealerContractsPage, int proposalId)
        {
            dealerContractsPage.FilterContractUsingProposalId(proposalId, RuntimeSettings.DefaultFindElementTimeout);
        }

        public DealerManageDevicesPage ClickOnManageDevicesAndProceed(DealerContractsPage dealerContractsPage)
        {
            // Click on Actions & Manage Devices link
            dealerContractsPage.ClickOnManageDevicesButton(RuntimeSettings.DefaultFindElementTimeout);
            // Move to Manage Devices Page
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSetCommunicationMethodPage CreateInstallationRequest(DealerManageDevicesPage dealerManageDevicesPage)
        {
            // Filter Location
            _contextData.CompanyLocation = dealerManageDevicesPage.SelectLocation();
            
            dealerManageDevicesPage.ClickCreateRequest();
            return PageService.GetPageObject<DealerSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSetInstallationTypePage SelectCommunicationMethodAndProceed(DealerSetCommunicationMethodPage dealerSetCommunicationMethodPage, string communicationMethod)
        {
            switch(communicationMethod)
            {
                case "Cloud":
                    dealerSetCommunicationMethodPage.SetCloudCommunicationMethod();
                    break;
                case "Email":
                    dealerSetCommunicationMethodPage.SetEmailCommunicationMethod();
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
            dealerSetCommunicationMethodPage.ProceedElement.Click();
            return PageService.GetPageObject<DealerSetInstallationTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSendInstallationEmailPage SelectInstallationTypeAndProceed(DealerSetInstallationTypePage dealerSetInstallationTypePage, string installationType)
        {
            SelectInstallationTypeAndClickNext(dealerSetInstallationTypePage, installationType);
            return PageService.GetPageObject<DealerSendInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerManageDevicesPage PopulateInstallerEmailAndSendEmail(DealerSendInstallationEmailPage dealerSendInstallationEmailPage)
        {
            _contextData.InstallerEmail = dealerSendInstallationEmailPage.EnterInstallerEmailAndProceed(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public string RetrieveInstallationRequestUrl(DealerManageDevicesPage dealerManageDevicesPage, string installerEmail, string companyLocation)
        {  
            string url = dealerManageDevicesPage.RetrieveInstallationRequestUrl(installerEmail, companyLocation, RuntimeSettings.DefaultFindElementTimeout);
            
            if (url == null)
            {
                throw new NullReferenceException("Installation Request Url not found");
            }
            return url;
        }

        public void ClickOnSwapDevice(DealerManageDevicesPage dealerManageDevicesPage, string serialNumber)
        {
            dealerManageDevicesPage.ClickOnSwapDevice(serialNumber, RuntimeSettings.DefaultFindElementTimeout);
        }

        public DealerSetCommunicationMethodPage ConfirmSwapAndSelectSwapType(DealerManageDevicesPage dealerManageDevicesPage, string swapType)
        {
            dealerManageDevicesPage.ConfirmSwapAndSelectSwapType(swapType, RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<DealerSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSendSwapInstallationEmailPage SelectInstallationTypeAndProceedForSwap(DealerSetInstallationTypePage dealerSetInstallationTypePage, string installationType)
        {
            SelectInstallationTypeAndClickNext(dealerSetInstallationTypePage, installationType);
            return PageService.GetPageObject<DealerSendSwapInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerManageDevicesPage PopulateInstallerEmailAndSendEmailForSwap(DealerSendSwapInstallationEmailPage dealerSendSwapInstallationEmailPage)
        {
            _contextData.InstallerEmail = dealerSendSwapInstallationEmailPage.EnterInstallerEmailAndProceed(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifySwappedDeviceStatus(DealerManageDevicesPage dealerManageDevicesPage, string serialNumber)
        {
            bool exists = dealerManageDevicesPage.VerifySwappedDeviceStatus(serialNumber, RuntimeSettings.DefaultFindElementTimeout);
            if (exists)
            {
                return;
            }
            else
            {
                throw new NullReferenceException(string.Format("Swapped Device status could not be verified"));
            }             
        }

        private void SelectInstallationTypeAndClickNext(DealerSetInstallationTypePage dealerSetInstallationTypePage, string installationType)
        {
            switch (installationType)
            {
                case "Web":
                    dealerSetInstallationTypePage.SetWebInstallationType();
                    break;
                case "BOR":
                    dealerSetInstallationTypePage.SetBORInstallationType();
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
            dealerSetInstallationTypePage.NextElement.Click();
        }
    }
}
