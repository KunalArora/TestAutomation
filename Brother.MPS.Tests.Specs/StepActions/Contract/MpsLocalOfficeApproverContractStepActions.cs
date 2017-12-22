﻿using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
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

        public MpsLocalOfficeApproverContractStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            DeviceSimulatorService deviceSimulatorService,
            RunCommandService runCommandService)
                    : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
            _runCommandService = runCommandService;
            _localOfficeApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
        }

        public LocalOfficeApproverContractsAwaitingAcceptancePage NavigateToApprovalContractsAwaitingAcceptancePage(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            ClickSafety(localOfficeApproverDashBoardPage.ApprovalTabElement, localOfficeApproverDashBoardPage);
            var localOfficeApproverApprovalPage = PageService.GetPageObject<LocalOfficeApproverApprovalPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
            ClickSafety(localOfficeApproverApprovalPage.ContractLinkElement, localOfficeApproverApprovalPage);
            var localOfficeApproverApprovalContractsApprovedProposalsPage = PageService.GetPageObject<LocalOfficeApproverApprovalContractsApprovedProposalsPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
            ClickSafety(localOfficeApproverApprovalContractsApprovedProposalsPage.AwaitingAcceptancLinkElement, localOfficeApproverApprovalContractsApprovedProposalsPage);
            return PageService.GetPageObject<LocalOfficeApproverContractsAwaitingAcceptancePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsSummaryPage ClickViewSummary(LocalOfficeApproverContractsAwaitingAcceptancePage localofficeApproverApprovalContractsAwaitingAcceptancePage, int proposalId)
        {
            localofficeApproverApprovalContractsAwaitingAcceptancePage.ClickOnViewSummary(proposalId, RuntimeSettings.DefaultFindElementTimeout, _localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsAcceptedPage AcceptContract(LocalOfficeApproverApprovalContractsSummaryPage localOfficeApproverApprovalContractsSummaryPage)
        {
            localOfficeApproverApprovalContractsSummaryPage.OnClickAccept(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsAcceptedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void VerifyAcceptContract(LocalOfficeApproverApprovalContractsAcceptedPage _localOfficeApproverApprovalContractsAcceptedPage, int proposalId, string proposalName)
        {
            _localOfficeApproverApprovalContractsAcceptedPage.VerifyContractFilter(proposalId, proposalName, RuntimeSettings.DefaultFindElementTimeout);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }

        public LocalOfficeApproverManageDevicesContractsPage NavigateToDeviceManagementPage(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            ClickSafety(localOfficeApproverDashBoardPage.DeviceManagementTabTabElement, localOfficeApproverDashBoardPage);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesContractsPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesManagePage ClickOnActionsManageDevices(LocalOfficeApproverManageDevicesContractsPage localOfficeApproverManagedevicesContractsPage, int proposalId)
        {
            ActionsModule.SetFilter(proposalId.ToString(), localOfficeApproverManagedevicesContractsPage.InputFilterBy, localOfficeApproverManagedevicesContractsPage.ContractOrProposalNameElementList, RuntimeSettings.DefaultFindElementTimeout, _localOfficeApproverWebDriver);
            ActionsModule.ClickOnTheActionsDropdown(0, _localOfficeApproverWebDriver);
            ActionsModule.NavigateToManageDevicesActionButton(_localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesSetCommunicationMethodPage CreateInstallationRequest(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage)
        {
            _contextData.CompanyLocation = localOfficeApproverManagedevicesManagePage.SelectLocation();

            localOfficeApproverManagedevicesManagePage.ClickCreateRequest();
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesSetInstallationTypePage SelectCommunicationMethodAndProceed(LocalOfficeApproverManageDevicesSetCommunicationMethodPage localOfficeApproverSetCommunicationMethodPage, string communicationMethod)
        {
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
            SelectInstallationTypeAndClickNext(localOfficeApproverManagedevicesSetInstallationTypePage, installationType);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSendInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesManagePage PopulateInstallerEmailAndSendEmail(LocalOfficeApproverManageDevicesSendInstallationEmailPage localOfficeApproverManagedevicesSendInstallationEmailPage)
        {
            _contextData.InstallerEmail = localOfficeApproverManagedevicesSendInstallationEmailPage.EnterInstallerEmailAndProceed(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public string RetrieveInstallationRequestUrl(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage, string installerEmail, string companyLocation, string resourceInstallationStatusNotStarted)
        {
            string url = localOfficeApproverManagedevicesManagePage.RetrieveInstallationRequestUrl(installerEmail, companyLocation, RuntimeSettings.DefaultFindElementTimeout, resourceInstallationStatusNotStarted);

            if (url == null)
            {
                throw new NullReferenceException("Installation Request Url not found");
            }
            return url;
        }

        public void InstallationCompleteCheck(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage, IEnumerable<PrinterProperties> products)
        {
            foreach (var product in products)
            {
                localOfficeApproverManagedevicesManagePage.InstallationCompleteCheck(product.SerialNumber, RuntimeSettings.DefaultFindElementTimeout);
            }
            CheckForUpdatedPrintCount(localOfficeApproverManagedevicesManagePage);
        }

        public LocalOfficeApproverManageDevicesManagePage RetrieveDealerManageDevicesPage()
        {
            string currentUrl = _localOfficeApproverWebDriver.Url;
            string validationElementSelector = new LocalOfficeApproverManageDevicesManagePage().ValidationElementSelector;
            return PageService.LoadUrl<LocalOfficeApproverManageDevicesManagePage>(currentUrl, RuntimeSettings.DefaultPageLoadTimeout, validationElementSelector, true, _localOfficeApproverWebDriver);
        }

        public void CheckForUpdatedPrintCount(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage)
        {
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                var totalPageCount = product.TotalPageCount;
                localOfficeApproverManagedevicesManagePage.CheckForUpdatedPrintCount(_localOfficeApproverWebDriver, totalPageCount, product.SerialNumber, RuntimeSettings.DefaultRetryCount, RuntimeSettings.DefaultFindElementTimeout);
            }
        }

        public LocalOfficeApproverManageDevicesSetCommunicationMethodPage ConfirmSwapAndSelectSwapType(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage, string swapType, string resourceSwapTypeReplaceWithDifferentModel)
        {
            localOfficeApproverManagedevicesManagePage.ConfirmSwapAndSelectSwapType(swapType, RuntimeSettings.DefaultFindElementTimeout, resourceSwapTypeReplaceWithDifferentModel);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesSendSwapDeviceInstallationEmail SelectInstallationTypeAndProceedForSwap(LocalOfficeApproverManageDevicesSetInstallationTypePage localOfficeApproverManagedevicesSetInstallationTypePage, string installationType)
        {
            SelectInstallationTypeAndClickNext(localOfficeApproverManagedevicesSetInstallationTypePage, installationType);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSendSwapDeviceInstallationEmail>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesManagePage PopulateInstallerEmailAndSendEmailForSwap(LocalOfficeApproverManageDevicesSendSwapDeviceInstallationEmail localOfficeApproverManagedevicesSendSwapDeviceInstallationEmail)
        {
            _contextData.InstallerEmail = localOfficeApproverManagedevicesSendSwapDeviceInstallationEmail.EnterInstallerEmailAndProceed(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void CheckForSwapDeviceUpdatedPrintCount(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage, string swapNewDeviceSerialNumber)
        {
            var totalPageCount = (_contextData.SwapNewDeviceMonoPrintCount + _contextData.SwapNewDeviceColourPrintCount);
            localOfficeApproverManagedevicesManagePage.CheckForUpdatedPrintCount(_localOfficeApproverWebDriver, totalPageCount, swapNewDeviceSerialNumber, RuntimeSettings.DefaultRetryCount, RuntimeSettings.DefaultFindElementTimeout);
        }

        public void VerifySwappedDeviceStatus(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage, string swapOldDeviceSerialNumber, string resourceInstalledPrinterStatusBeingReplaced)
        {
            bool exists = localOfficeApproverManagedevicesManagePage.VerifySwappedDeviceStatus(swapOldDeviceSerialNumber, RuntimeSettings.DefaultFindElementTimeout, resourceInstalledPrinterStatusBeingReplaced);
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
