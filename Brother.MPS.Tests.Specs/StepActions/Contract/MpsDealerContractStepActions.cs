using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Contract
{
    public class MpsDealerContractStepActions: StepActionBase
    {
        private readonly IWebDriver _dealerWebDriver;
        private readonly IContextData _contextData;
        private readonly DeviceSimulatorService _deviceSimulatorService;
        private readonly RunCommandService _runCommandService;
        private readonly ITranslationService _translationService;
        private readonly IContractShiftService _contractShiftService;
        private readonly IUserResolver _userResolver;

        public MpsDealerContractStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            DeviceSimulatorService deviceSimulatorService,
            ITranslationService translationService,
            ILoggingService loggingService,
            RunCommandService runCommandService,
            IContractShiftService contractShiftService,
            IUserResolver userResolver)            
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
            _runCommandService = runCommandService;
            _translationService = translationService;
            _contractShiftService = contractShiftService;
            _userResolver = userResolver;
        }

        public DealerContractsPage NavigateToContractsPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            dealerDashboardPage.ExistingContractLinkElement.Click();
            return PageService.GetPageObject<DealerContractsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void CloudInstallationCompleteCheck(DealerManageDevicesPage _dealerManageDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(_dealerManageDevicesPage);
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                _dealerManageDevicesPage.InstallationCompleteCheck(product.SerialNumber);
            }
            CheckForUpdatedPrintCount(_dealerManageDevicesPage);
        }

        public void EmailInstallationCompleteCheck(DealerManageDevicesPage dealerManageDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerManageDevicesPage);
            var resourceInstallationCompletedStatus = _translationService.GetInstallationStatusText(TranslationKeys.InstallationStatus.Completed, _contextData.Culture);
            var IRCompleteCheck = dealerManageDevicesPage.EmailInstallationCompleteCheck(resourceInstallationCompletedStatus);
            Assert.AreEqual(IRCompleteCheck, true);
        }

        public void UpdateAndNotifyBOCForPrintCounts()
        {
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId);
            _runCommandService.RunConsumableOrderRequestsCommand();
            _runCommandService.RunCreateConsumableOrderCommand();
        }

        public DealerManageDevicesPage RetrieveDealerManageDevicesPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            string currentUrl = _dealerWebDriver.Url;
            return PageService.LoadUrl<DealerManageDevicesPage>(currentUrl, RuntimeSettings.DefaultPageLoadTimeout, ".active a[href=\"/mps/dealer/contracts/manage-devices/manage\"]", true, _dealerWebDriver);
        }

        public void CheckForUpdatedPrintCount(DealerManageDevicesPage dealerManageDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerManageDevicesPage);
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                var totalPageCount = product.TotalPageCount; 
                while(!(dealerManageDevicesPage.CheckForUpdatedPrintCount(_dealerWebDriver, totalPageCount, product.SerialNumber))) 
                {
                    _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId);
                    _dealerWebDriver.Navigate().Refresh();
                    dealerManageDevicesPage = PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                    continue;
                }
                _dealerWebDriver.Navigate().Refresh();
                dealerManageDevicesPage = PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);               
            }
        }

        public void CheckForSwapDeviceUpdatedPrintCount(DealerManageDevicesPage dealerManageDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerManageDevicesPage);
            var totalPageCount = (_contextData.SwapNewDeviceMonoPrintCount + _contextData.SwapNewDeviceColourPrintCount);
            dealerManageDevicesPage.CheckForUpdatedPrintCount(_dealerWebDriver, totalPageCount, _contextData.SwapNewDeviceSerialNumber);
        }

        //Similar function is already present in this file so, refactor this particular function.
        public void MoveToAcceptedContractsTab(DealerContractsPage dealerContractsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerContractsPage);
            dealerContractsPage.MoveToAcceptedContracts();
        }

        public void MoveToAwaitingAcceptanceContractsTab(DealerContractsPage dealerContractsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerContractsPage);
            dealerContractsPage.MoveToAwaitingAcceptanceContracts();
        }


        public void FilterContractUsingProposalIdAction(DealerContractsPage dealerContractsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerContractsPage);
            dealerContractsPage.FilterContractUsingProposalId(_contextData.ProposalId, _contextData.ProposalName);
        }

        public DealerManageDevicesPage ClickOnManageDevicesAndProceed(DealerContractsPage dealerContractsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerContractsPage);
            dealerContractsPage.ClickOnManageDevicesButton();
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSetCommunicationMethodPage CreateInstallationRequest(DealerManageDevicesPage dealerManageDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerManageDevicesPage);
            // Filter Location
            _contextData.CompanyLocation = dealerManageDevicesPage.SelectLocation();
            
            dealerManageDevicesPage.ClickCreateRequest();
            return PageService.GetPageObject<DealerSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSetInstallationTypePage SelectCommunicationMethodAndProceedForCloud(DealerSetCommunicationMethodPage dealerSetCommunicationMethodPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerSetCommunicationMethodPage);
            dealerSetCommunicationMethodPage.SetCloudCommunicationMethod();
            dealerSetCommunicationMethodPage.ProceedElement.Click();
            return PageService.GetPageObject<DealerSetInstallationTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSendInstallationEmailPage SelectCommunicationMethodAndProceedForEmail(DealerSetCommunicationMethodPage dealerSetCommunicationMethodPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerSetCommunicationMethodPage);
            dealerSetCommunicationMethodPage.SetEmailCommunicationMethod();
            dealerSetCommunicationMethodPage.ProceedElement.Click();
            return PageService.GetPageObject<DealerSendInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }


        public DealerSendInstallationEmailPage SelectInstallationTypeAndProceed(DealerSetInstallationTypePage dealerSetInstallationTypePage, string installationType)
        {
            LoggingService.WriteLogOnMethodEntry(dealerSetInstallationTypePage, installationType);
            SelectInstallationTypeAndClickNext(dealerSetInstallationTypePage, installationType);
            return PageService.GetPageObject<DealerSendInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerManageDevicesPage PopulateInstallerEmailAndSendEmail(DealerSendInstallationEmailPage dealerSendInstallationEmailPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerSendInstallationEmailPage);

            int retries = 0;

            while (dealerSendInstallationEmailPage.SeleniumHelper.IsElementDisplayed(dealerSendInstallationEmailPage.WarningAlertElement))
            {
                _dealerWebDriver.Navigate().Refresh();
                dealerSendInstallationEmailPage = PageService.GetPageObject<DealerSendInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                if (retries > RuntimeSettings.DefaultRetryCount / 2)
                {
                    LoggingService.WriteLog(LoggingLevel.WARNING, string.Format("BOC Pin Generation/Sap Customer Validation is taking time for proposal {0}", _contextData.ProposalId));
                }

                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    TestCheck.AssertFailTest(
                        string.Format("Number of retries exceeded the default limit during verification of boc pin codes generation/Sap customer validation for proposal {0}. BOC server may be slow in responding.", _contextData.ProposalId));
                }
            }

            _contextData.InstallerEmail = _userResolver.InstallerUsername;
            dealerSendInstallationEmailPage.EnterInstallerEmailAndProceed(_contextData.InstallerEmail, actualMessage=> {
                var expectedMessage = _translationService.GetDisplayMessageText(TranslationKeys.DisplayMessage.EmailSendSuccess, _contextData.Culture);
                if(string.IsNullOrWhiteSpace(expectedMessage)) { return true; }
                Assert.AreEqual(expectedMessage, actualMessage);
                return true; });
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public string RetrieveInstallationRequestUrl(DealerManageDevicesPage dealerManageDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerManageDevicesPage);
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
            LoggingService.WriteLogOnMethodEntry(dealerManageDevicesPage, serialNumber);
            dealerManageDevicesPage.ClickOnSwapDevice(serialNumber);
        }

        public DealerSetCommunicationMethodPage ConfirmSwapAndSelectSwapType(DealerManageDevicesPage dealerManageDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerManageDevicesPage);
            string resourceSwapTypeReplaceWithDifferentModel = _translationService.GetSwapTypeText(TranslationKeys.SwapType.ReplaceWithDifferentModel, _contextData.Culture);
            string swapType = _contextData.SwapType;
            dealerManageDevicesPage.ConfirmSwapAndSelectSwapType(swapType, resourceSwapTypeReplaceWithDifferentModel);
            return PageService.GetPageObject<DealerSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerSendSwapInstallationEmailPage SelectInstallationTypeAndProceedForSwap(DealerSetInstallationTypePage dealerSetInstallationTypePage, string installationType)
        {
            LoggingService.WriteLogOnMethodEntry(dealerSetInstallationTypePage, installationType);
            SelectInstallationTypeAndClickNext(dealerSetInstallationTypePage, installationType);
            return PageService.GetPageObject<DealerSendSwapInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerManageDevicesPage PopulateInstallerEmailAndSendEmailForSwap(DealerSendSwapInstallationEmailPage dealerSendSwapInstallationEmailPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerSendSwapInstallationEmailPage);
            _contextData.InstallerEmail = _userResolver.InstallerUsername;
            dealerSendSwapInstallationEmailPage.EnterInstallerEmailAndProceed(_contextData.InstallerEmail);
            return PageService.GetPageObject<DealerManageDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifySwappedDeviceStatusAction(DealerManageDevicesPage dealerManageDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerManageDevicesPage);
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
            LoggingService.WriteLogOnMethodEntry(dealerSetInstallationTypePage, installationType);
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

        public void VerifyRejectedContractInRejectedContractsList(DealerContractsRejectedPage dealerContractsRejectedPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerContractsRejectedPage);
            int proposalId = _contextData.ProposalId;
            string proposalName = _contextData.ProposalName;
            bool exists = dealerContractsRejectedPage.VerifyRejectedContractInRejectedContractsList(proposalId, proposalName);

            if (!exists)
            {
                throw new NullReferenceException(string.Format("Contract = {0} not found ", proposalId));
            }

        }
    }
}
