﻿using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Contract
{
    [Binding]
    class MpsLocalOfficeApproverContractStepActions : StepActionBase
    {
        private readonly IContextData _contextData;
        private readonly DeviceSimulatorService _deviceSimulatorService;
        private readonly RunCommandService _runCommandService;
        private readonly IWebDriver _localOfficeApproverWebDriver;
        private readonly ITranslationService _translationService;

        public MpsLocalOfficeApproverContractStepActions(IWebDriverFactory webDriverFactory,
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
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
            _runCommandService = runCommandService;
            _localOfficeApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
            _translationService = translationService;
        }

        public LocalOfficeApproverContractsAwaitingAcceptancePage NavigateToApprovalContractsAwaitingAcceptancePage(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            WriteLogOnMethodEntry(localOfficeApproverDashBoardPage);
            ClickSafety(localOfficeApproverDashBoardPage.ApprovalTabElement, localOfficeApproverDashBoardPage);
            var localOfficeApproverApprovalPage = PageService.GetPageObject<LocalOfficeApproverApprovalPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
            ClickSafety(localOfficeApproverApprovalPage.ContractLinkElement, localOfficeApproverApprovalPage);
            var localOfficeApproverApprovalContractsApprovedProposalsPage = PageService.GetPageObject<LocalOfficeApproverApprovalContractsApprovedProposalsPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
            ClickSafety(localOfficeApproverApprovalContractsApprovedProposalsPage.AwaitingAcceptancLinkElement, localOfficeApproverApprovalContractsApprovedProposalsPage);
            return PageService.GetPageObject<LocalOfficeApproverContractsAwaitingAcceptancePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsSummaryPage ClickViewSummary(LocalOfficeApproverContractsAwaitingAcceptancePage localofficeApproverApprovalContractsAwaitingAcceptancePage)
        {
            WriteLogOnMethodEntry(localofficeApproverApprovalContractsAwaitingAcceptancePage);
            int proposalId = _contextData.ProposalId;
            localofficeApproverApprovalContractsAwaitingAcceptancePage.ClickOnViewSummary(proposalId, _localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsAcceptedPage AcceptContract(LocalOfficeApproverApprovalContractsSummaryPage localOfficeApproverApprovalContractsSummaryPage)
        {
            WriteLogOnMethodEntry(localOfficeApproverApprovalContractsSummaryPage);
            localOfficeApproverApprovalContractsSummaryPage.OnClickAccept();
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsAcceptedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void VerifyAcceptContract(LocalOfficeApproverApprovalContractsAcceptedPage _localOfficeApproverApprovalContractsAcceptedPage, int proposalId, string proposalName)
        {
            WriteLogOnMethodEntry(_localOfficeApproverApprovalContractsAcceptedPage, proposalId, proposalName);
            _localOfficeApproverApprovalContractsAcceptedPage.VerifyContractFilter(proposalId, proposalName, RuntimeSettings.DefaultFindElementTimeout);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            WriteLogOnMethodEntry(element, pageObject);
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }

        public LocalOfficeApproverManageDevicesContractsPage NavigateToDeviceManagementPage(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            WriteLogOnMethodEntry(localOfficeApproverDashBoardPage);
            ClickSafety(localOfficeApproverDashBoardPage.DeviceManagementTabTabElement, localOfficeApproverDashBoardPage);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesContractsPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesManagePage ClickOnActionsManageDevices(LocalOfficeApproverManageDevicesContractsPage localOfficeApproverManagedevicesContractsPage, int proposalId)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesContractsPage, proposalId);
            ActionsModule.SetFilter(proposalId.ToString(), localOfficeApproverManagedevicesContractsPage.InputFilterBy, localOfficeApproverManagedevicesContractsPage.ContractOrProposalNameElementList, RuntimeSettings.DefaultFindElementTimeout, _localOfficeApproverWebDriver);
            ActionsModule.ClickOnTheActionsDropdown(0, _localOfficeApproverWebDriver);
            ActionsModule.NavigateToManageDevicesActionButton(_localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesSetCommunicationMethodPage CreateInstallationRequest(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage);
            _contextData.CompanyLocation = localOfficeApproverManagedevicesManagePage.SelectLocation();

            localOfficeApproverManagedevicesManagePage.ClickCreateRequest();
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesSetInstallationTypePage SelectCommunicationMethodAndProceed(LocalOfficeApproverManageDevicesSetCommunicationMethodPage localOfficeApproverSetCommunicationMethodPage, string communicationMethod)
        {
            WriteLogOnMethodEntry(localOfficeApproverSetCommunicationMethodPage, communicationMethod);
            switch (communicationMethod)
            {
                case "Cloud":
                    localOfficeApproverSetCommunicationMethodPage.SetCloudCommunicationMethod();
                    break;
                case "Email":
                    localOfficeApproverSetCommunicationMethodPage.SetEmailCommunicationMethod();
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
            ClickSafety( localOfficeApproverSetCommunicationMethodPage.ProceedElement, localOfficeApproverSetCommunicationMethodPage);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSetInstallationTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesSendInstallationEmailPage SelectInstallationTypeAndProceed(LocalOfficeApproverManageDevicesSetInstallationTypePage localOfficeApproverManagedevicesSetInstallationTypePage, string installationType)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesSetInstallationTypePage, installationType);
            SelectInstallationTypeAndClickNext(localOfficeApproverManagedevicesSetInstallationTypePage, installationType);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSendInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesManagePage PopulateInstallerEmailAndSendEmail(LocalOfficeApproverManageDevicesSendInstallationEmailPage localOfficeApproverManagedevicesSendInstallationEmailPage)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesSendInstallationEmailPage);
            _contextData.InstallerEmail = localOfficeApproverManagedevicesSendInstallationEmailPage.EnterInstallerEmailAndProceed();
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public string RetrieveInstallationRequestUrl(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage);
            string resourceInstallationStatusNotStarted = _translationService.GetInstallationStatusText(TranslationKeys.InstallationStatus.NotStarted, _contextData.Culture);
            string installerEmail = _contextData.InstallerEmail;
            string companyLocation = _contextData.CompanyLocation;

            string url = localOfficeApproverManagedevicesManagePage.RetrieveInstallationRequestUrl(installerEmail, companyLocation, resourceInstallationStatusNotStarted);

            if (url == null)
            {
                throw new NullReferenceException("Installation Request Url not found");
            }
            return url;
        }

        public void InstallationCompleteCheck(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage, IEnumerable<PrinterProperties> products)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage, products);
            foreach (var product in products)
            {
                localOfficeApproverManagedevicesManagePage.InstallationCompleteCheck(product.SerialNumber);
            }
            CheckForUpdatedPrintCount(localOfficeApproverManagedevicesManagePage);
        }

        public LocalOfficeApproverManageDevicesManagePage RetrieveDealerManageDevicesPage()
        {
            WriteLogOnMethodEntry();
            string currentUrl = _localOfficeApproverWebDriver.Url;
            string validationElementSelector = new LocalOfficeApproverManageDevicesManagePage().ValidationElementSelector;
            return PageService.LoadUrl<LocalOfficeApproverManageDevicesManagePage>(currentUrl, RuntimeSettings.DefaultPageLoadTimeout, validationElementSelector, true, _localOfficeApproverWebDriver);
        }

        public void CheckForUpdatedPrintCount(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage);
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                var totalPageCount = product.TotalPageCount;
                localOfficeApproverManagedevicesManagePage.CheckForUpdatedPrintCount(_localOfficeApproverWebDriver, totalPageCount, product.SerialNumber);
            }
        }

        public LocalOfficeApproverManageDevicesSetCommunicationMethodPage ConfirmSwapAndSelectSwapType(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage, string swapType, string resourceSwapTypeReplaceWithDifferentModel)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage, swapType, resourceSwapTypeReplaceWithDifferentModel);
            localOfficeApproverManagedevicesManagePage.ConfirmSwapAndSelectSwapType(swapType, resourceSwapTypeReplaceWithDifferentModel);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesSendSwapDeviceInstallationEmail SelectInstallationTypeAndProceedForSwap(LocalOfficeApproverManageDevicesSetInstallationTypePage localOfficeApproverManagedevicesSetInstallationTypePage, string installationType)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesSetInstallationTypePage, installationType);
            SelectInstallationTypeAndClickNext(localOfficeApproverManagedevicesSetInstallationTypePage, installationType);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSendSwapDeviceInstallationEmail>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesManagePage PopulateInstallerEmailAndSendEmailForSwap(LocalOfficeApproverManageDevicesSendSwapDeviceInstallationEmail localOfficeApproverManagedevicesSendSwapDeviceInstallationEmail)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesSendSwapDeviceInstallationEmail);
            _contextData.InstallerEmail = localOfficeApproverManagedevicesSendSwapDeviceInstallationEmail.EnterInstallerEmailAndProceed();
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void CheckForSwapDeviceUpdatedPrintCount(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage, string swapNewDeviceSerialNumber)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage, swapNewDeviceSerialNumber);
            var totalPageCount = (_contextData.SwapNewDeviceMonoPrintCount + _contextData.SwapNewDeviceColourPrintCount);
            localOfficeApproverManagedevicesManagePage.CheckForUpdatedPrintCount(_localOfficeApproverWebDriver, totalPageCount, swapNewDeviceSerialNumber);
        }

        public void VerifySwappedDeviceStatus(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage)
        {
            WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage);
            string resourceInstalledPrinterStatusBeingReplaced = _translationService.GetInstalledPrinterStatusText(TranslationKeys.InstalledPrinterStatus.BeingReplaced, _contextData.Culture);
            string swapOldDeviceSerialNumber = _contextData.SwapOldDeviceSerialNumber;

            bool exists = localOfficeApproverManagedevicesManagePage.VerifySwappedDeviceStatus(swapOldDeviceSerialNumber, resourceInstalledPrinterStatusBeingReplaced);
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
