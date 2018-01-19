using Brother.Tests.Specs.Configuration;
using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Services;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Logging;

namespace Brother.Tests.Specs.StepActions.Contract
{
    public class MpsDealerContractStepActions: StepActionBase
    {
        private readonly IWebDriver _dealerWebDriver;
        private readonly IContextData _contextData;
        private readonly DeviceSimulatorService _deviceSimulatorService;
        private readonly RunCommandService _runCommandService;
        private readonly ITranslationService _translationService;

        public MpsDealerContractStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            DeviceSimulatorService deviceSimulatorService,
            ITranslationService translationService,
            ILoggingService loggingService,
            RunCommandService runCommandService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
            _runCommandService = runCommandService;
            _translationService = translationService;
        }

        public DealerContractsPage NavigateToContractsPage(DealerDashBoardPage dealerDashboardPage)
        {
            WriteLogOnMethodEntry(dealerDashboardPage);
            dealerDashboardPage.ExistingContractLinkElement.Click();
            return PageService.GetPageObject<DealerContractsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerContractsAcceptedPage NavigateToContractsAcceptedPage(DealerContractsPage dealerContractsPage)
        {
            WriteLogOnMethodEntry(dealerContractsPage);
            dealerContractsPage.AcceptedTabElement.Click();
            return PageService.GetPageObject<DealerContractsAcceptedPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerManageDevicesPage NavigateToManageDevicesPageFix(DealerContractsAcceptedPage dealerContractsAcceptedPage, int proposalId)
        {
            WriteLogOnMethodEntry(dealerContractsAcceptedPage,proposalId);
            dealerContractsAcceptedPage.NavigateToSpecificManageDevicesPage(proposalId, RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void InstallationCompleteCheck(DealerManageDevicesPage _dealerManageDevicesPage)
        {
            WriteLogOnMethodEntry(_dealerManageDevicesPage);
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                _dealerManageDevicesPage.InstallationCompleteCheck(product.SerialNumber);
            }
            CheckForUpdatedPrintCount(_dealerManageDevicesPage);
        }

        public void UpdateAndNotifyBOCForPrintCounts()
        {
            WriteLogOnMethodEntry();
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                product.TotalPageCount = (product.MonoPrintCount + product.ColorPrintCount);
                string deviceId = product.DeviceId;
                _deviceSimulatorService.SetPrintCounts(deviceId, product.MonoPrintCount, product.ColorPrintCount);
                _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
            }
        }

        public void UpdateAndNotifyBOCForConsumableOrder()
        {
            WriteLogOnMethodEntry();
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                string deviceId = product.DeviceId;
                _deviceSimulatorService.RaiseConsumableOrder(deviceId, product.TonerInkBlackStatus, product.TonerInkCyanStatus, product.TonerInkMagentaStatus, product.TonerInkYellowStatus);
                _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
            }
        }

        public void UpdateAndNotifyBOCForServiceRequest()
        {
            WriteLogOnMethodEntry();
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                string deviceId = product.DeviceId;
                _deviceSimulatorService.RaiseServiceRequest(deviceId, product.LaserUnit, product.FuserUnit, product.PaperFeedingKit1, product.PaperFeedingKit2, product.PaperFeedingKit3);
                _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
            }
        }

        public void RunCommandServicesRequests()
        {
            WriteLogOnMethodEntry();
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId);
            _runCommandService.RunConsumableOrderRequestsCommand();
            _runCommandService.RunCreateConsumableOrderCommand();
        }

        public DealerManageDevicesPage RetrieveDealerManageDevicesPage()
        {
            WriteLogOnMethodEntry();
            string currentUrl = _dealerWebDriver.Url;
            return PageService.LoadUrl<DealerManageDevicesPage>(currentUrl, RuntimeSettings.DefaultPageLoadTimeout, ".active a[href=\"/mps/dealer/contracts/manage-devices/manage\"]", true, _dealerWebDriver);
        }

        public void CheckForUpdatedPrintCount(DealerManageDevicesPage dealerManageDevicesPage)
        {
            WriteLogOnMethodEntry(dealerManageDevicesPage);
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                var totalPageCount = product.TotalPageCount; 
                dealerManageDevicesPage.CheckForUpdatedPrintCount(_dealerWebDriver, totalPageCount, product.SerialNumber);
            }
        }

        public void CheckForSwapDeviceUpdatedPrintCount(DealerManageDevicesPage dealerManageDevicesPage, string swappedSerialNumber)
        {
            WriteLogOnMethodEntry(dealerManageDevicesPage,swappedSerialNumber);
            var totalPageCount = (_contextData.SwapNewDeviceMonoPrintCount + _contextData.SwapNewDeviceColourPrintCount);
            dealerManageDevicesPage.CheckForUpdatedPrintCount(_dealerWebDriver, totalPageCount, swappedSerialNumber);
        }

        //Similar function is already present in this file so, refactor this particular function.
        public void MoveToAcceptedContractsTab(DealerContractsPage dealerContractsPage)
        {
            WriteLogOnMethodEntry(dealerContractsPage);
            dealerContractsPage.MoveToAcceptedContracts();
        }
        
        public void FilterContractUsingProposalIdAction(DealerContractsPage dealerContractsPage)
        {
            WriteLogOnMethodEntry(dealerContractsPage);
            int proposalId = _contextData.ProposalId;
            dealerContractsPage.FilterContractUsingProposalId(proposalId);
        }

        public DealerManageDevicesPage ClickOnManageDevicesAndProceed(DealerContractsPage dealerContractsPage)
        {
            WriteLogOnMethodEntry(dealerContractsPage);
            dealerContractsPage.ClickOnManageDevicesButton();
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSetCommunicationMethodPage CreateInstallationRequest(DealerManageDevicesPage dealerManageDevicesPage)
        {
            WriteLogOnMethodEntry(dealerManageDevicesPage);
            // Filter Location
            _contextData.CompanyLocation = dealerManageDevicesPage.SelectLocation();
            
            dealerManageDevicesPage.ClickCreateRequest();
            return PageService.GetPageObject<DealerSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSetInstallationTypePage SelectCommunicationMethodAndProceed(DealerSetCommunicationMethodPage dealerSetCommunicationMethodPage, string communicationMethod)
        {
            WriteLogOnMethodEntry(dealerSetCommunicationMethodPage, communicationMethod);
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
            WriteLogOnMethodEntry(dealerSetInstallationTypePage, installationType);
            SelectInstallationTypeAndClickNext(dealerSetInstallationTypePage, installationType);
            return PageService.GetPageObject<DealerSendInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerManageDevicesPage PopulateInstallerEmailAndSendEmail(DealerSendInstallationEmailPage dealerSendInstallationEmailPage)
        {
            WriteLogOnMethodEntry(dealerSendInstallationEmailPage);
            _contextData.InstallerEmail = dealerSendInstallationEmailPage.EnterInstallerEmailAndProceed();
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public string RetrieveInstallationRequestUrl(DealerManageDevicesPage dealerManageDevicesPage)
        {
            WriteLogOnMethodEntry(dealerManageDevicesPage);
            string resourceInstallationStatusNotStarted = _translationService.GetInstallationStatusText(TranslationKeys.InstallationStatus.NotStarted, _contextData.Culture);
            string installerEmail = _contextData.InstallerEmail;
            string companyLocation = _contextData.CompanyLocation;

            string url = dealerManageDevicesPage.RetrieveInstallationRequestUrl(installerEmail, companyLocation, resourceInstallationStatusNotStarted);
            
            if (url == null)
            {
                throw new NullReferenceException("Installation Request Url not found");
            }
            return url;
        }

        public void ClickOnSwapDevice(DealerManageDevicesPage dealerManageDevicesPage, string serialNumber)
        {
            WriteLogOnMethodEntry(dealerManageDevicesPage, serialNumber);
            dealerManageDevicesPage.ClickOnSwapDevice(serialNumber);
        }

        public DealerSetCommunicationMethodPage ConfirmSwapAndSelectSwapType(DealerManageDevicesPage dealerManageDevicesPage)
        {
            WriteLogOnMethodEntry(dealerManageDevicesPage);
            string resourceSwapTypeReplaceWithDifferentModel = _translationService.GetSwapTypeText(TranslationKeys.SwapType.ReplaceWithDifferentModel, _contextData.Culture);
            string swapType = _contextData.SwapType;
            dealerManageDevicesPage.ConfirmSwapAndSelectSwapType(swapType, resourceSwapTypeReplaceWithDifferentModel);
            return PageService.GetPageObject<DealerSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSendSwapInstallationEmailPage SelectInstallationTypeAndProceedForSwap(DealerSetInstallationTypePage dealerSetInstallationTypePage, string installationType)
        {
            WriteLogOnMethodEntry(dealerSetInstallationTypePage, installationType);
            SelectInstallationTypeAndClickNext(dealerSetInstallationTypePage, installationType);
            return PageService.GetPageObject<DealerSendSwapInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerManageDevicesPage PopulateInstallerEmailAndSendEmailForSwap(DealerSendSwapInstallationEmailPage dealerSendSwapInstallationEmailPage)
        {
            WriteLogOnMethodEntry(dealerSendSwapInstallationEmailPage);
            _contextData.InstallerEmail = dealerSendSwapInstallationEmailPage.EnterInstallerEmailAndProceed();
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifySwappedDeviceStatusAction(DealerManageDevicesPage dealerManageDevicesPage)
        {
            WriteLogOnMethodEntry(dealerManageDevicesPage);
            string resourceInstalledPrinterStatusBeingReplaced = _translationService.GetInstalledPrinterStatusText(TranslationKeys.InstalledPrinterStatus.BeingReplaced, _contextData.Culture);
            string swapOldDeviceSerialNumber = _contextData.SwapOldDeviceSerialNumber;

            bool exists = dealerManageDevicesPage.VerifySwappedDeviceStatus(swapOldDeviceSerialNumber, resourceInstalledPrinterStatusBeingReplaced);
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
            WriteLogOnMethodEntry(dealerSetInstallationTypePage, installationType);
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
