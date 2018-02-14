using Brother.Tests.Common.ContextData;
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
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.Helpers;
using System.Globalization;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;

namespace Brother.Tests.Specs.StepActions.Contract
{
    [Binding]
    class MpsLocalOfficeApproverContractStepActions : MpsLocalOfficeStepActions 
    {
        private readonly IContextData _contextData;
        private readonly DeviceSimulatorService _deviceSimulatorService;
        private readonly RunCommandService _runCommandService;
        private readonly IWebDriver _localOfficeApproverWebDriver;
        private readonly ITranslationService _translationService;
        private readonly IPdfHelper _pdfHelper;

        public MpsLocalOfficeApproverContractStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            DeviceSimulatorService deviceSimulatorService,
            ITranslationService translationService,
            ILoggingService loggingService,
            IPdfHelper pdfHelper,
            RunCommandService runCommandService)
                    : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings, translationService, runCommandService)
        {
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
            _runCommandService = runCommandService;
            _localOfficeApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
            _translationService = translationService;
            _pdfHelper = pdfHelper;
        }

        public LocalOfficeApproverContractsAwaitingAcceptancePage NavigateToApprovalContractsAwaitingAcceptancePage(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverDashBoardPage);
            ClickSafety(localOfficeApproverDashBoardPage.ApprovalTabElement, localOfficeApproverDashBoardPage);
            var localOfficeApproverApprovalPage = PageService.GetPageObject<LocalOfficeApproverApprovalPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
            ClickSafety(localOfficeApproverApprovalPage.ContractLinkElement, localOfficeApproverApprovalPage);
            var localOfficeApproverApprovalContractsApprovedProposalsPage = PageService.GetPageObject<LocalOfficeApproverApprovalContractsApprovedProposalsPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
            ClickSafety(localOfficeApproverApprovalContractsApprovedProposalsPage.AwaitingAcceptancLinkElement, localOfficeApproverApprovalContractsApprovedProposalsPage);
            return PageService.GetPageObject<LocalOfficeApproverContractsAwaitingAcceptancePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsSummaryPage ClickViewSummary(LocalOfficeApproverContractsAwaitingAcceptancePage localofficeApproverApprovalContractsAwaitingAcceptancePage)
        {
            LoggingService.WriteLogOnMethodEntry(localofficeApproverApprovalContractsAwaitingAcceptancePage);
            int proposalId = _contextData.ProposalId;
            localofficeApproverApprovalContractsAwaitingAcceptancePage.ClickOnViewSummary(proposalId, _localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsAcceptedPage AcceptContract(LocalOfficeApproverApprovalContractsSummaryPage localOfficeApproverApprovalContractsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalContractsSummaryPage);
            localOfficeApproverApprovalContractsSummaryPage.OnClickAccept();
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsAcceptedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void VerifyAcceptContract(LocalOfficeApproverApprovalContractsAcceptedPage _localOfficeApproverApprovalContractsAcceptedPage, int proposalId, string proposalName)
        {
            LoggingService.WriteLogOnMethodEntry(_localOfficeApproverApprovalContractsAcceptedPage, proposalId, proposalName);
            _localOfficeApproverApprovalContractsAcceptedPage.VerifyContractFilter(proposalId, proposalName);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            LoggingService.WriteLogOnMethodEntry(element, pageObject);
            pageObject.SeleniumHelper.ClickSafety(element);
        }

        public LocalOfficeApproverManageDevicesContractsPage NavigateToDeviceManagementPage(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverDashBoardPage);
            ClickSafety(localOfficeApproverDashBoardPage.DeviceManagementTabTabElement, localOfficeApproverDashBoardPage);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesContractsPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesManagePage ClickOnActionsManageDevices(LocalOfficeApproverManageDevicesContractsPage localOfficeApproverManagedevicesContractsPage, int proposalId)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesContractsPage, proposalId);
            ActionsModule.SetFilter(proposalId.ToString(), localOfficeApproverManagedevicesContractsPage.InputFilterBy, localOfficeApproverManagedevicesContractsPage.ContractOrProposalNameElementList, RuntimeSettings.DefaultFindElementTimeout, _localOfficeApproverWebDriver);
            ActionsModule.ClickOnTheActionsDropdown(0, _localOfficeApproverWebDriver);
            ActionsModule.NavigateToManageDevicesActionButton(_localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesSetCommunicationMethodPage CreateInstallationRequest(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage);
            _contextData.CompanyLocation = localOfficeApproverManagedevicesManagePage.SelectLocation();

            localOfficeApproverManagedevicesManagePage.ClickCreateRequest();
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesSetInstallationTypePage SelectCommunicationMethodAndProceed(LocalOfficeApproverManageDevicesSetCommunicationMethodPage localOfficeApproverSetCommunicationMethodPage, string communicationMethod)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverSetCommunicationMethodPage, communicationMethod);
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
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesSetInstallationTypePage, installationType);
            SelectInstallationTypeAndClickNext(localOfficeApproverManagedevicesSetInstallationTypePage, installationType);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSendInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesManagePage PopulateInstallerEmailAndSendEmail(LocalOfficeApproverManageDevicesSendInstallationEmailPage localOfficeApproverManagedevicesSendInstallationEmailPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesSendInstallationEmailPage);

            int retries = 0;

            while (localOfficeApproverManagedevicesSendInstallationEmailPage.SeleniumHelper.IsElementDisplayed(localOfficeApproverManagedevicesSendInstallationEmailPage.WarningAlertElement))
            {
                _localOfficeApproverWebDriver.Navigate().Refresh();
                localOfficeApproverManagedevicesSendInstallationEmailPage = PageService.GetPageObject<LocalOfficeApproverManageDevicesSendInstallationEmailPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);

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

            _contextData.InstallerEmail = localOfficeApproverManagedevicesSendInstallationEmailPage.EnterInstallerEmailAndProceed();
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public string RetrieveInstallationRequestUrl(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage);
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
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage, products);
            foreach (var product in products)
            {
                localOfficeApproverManagedevicesManagePage.InstallationCompleteCheck(product.SerialNumber);
            }
            CheckForUpdatedPrintCount(localOfficeApproverManagedevicesManagePage);
        }

        public LocalOfficeApproverManageDevicesManagePage RetrieveDealerManageDevicesPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            string currentUrl = _localOfficeApproverWebDriver.Url;
            string validationElementSelector = new LocalOfficeApproverManageDevicesManagePage().ValidationElementSelector;
            return PageService.LoadUrl<LocalOfficeApproverManageDevicesManagePage>(currentUrl, RuntimeSettings.DefaultPageLoadTimeout, validationElementSelector, true, _localOfficeApproverWebDriver);
        }

        public void CheckForUpdatedPrintCount(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage);
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                var totalPageCount = product.TotalPageCount;
                localOfficeApproverManagedevicesManagePage.CheckForUpdatedPrintCount(_localOfficeApproverWebDriver, totalPageCount, product.SerialNumber);
            }
        }

        public LocalOfficeApproverManageDevicesSetCommunicationMethodPage ConfirmSwapAndSelectSwapType(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage, string swapType, string resourceSwapTypeReplaceWithDifferentModel)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage, swapType, resourceSwapTypeReplaceWithDifferentModel);
            localOfficeApproverManagedevicesManagePage.ConfirmSwapAndSelectSwapType(swapType, resourceSwapTypeReplaceWithDifferentModel);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSetCommunicationMethodPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesSendSwapDeviceInstallationEmail SelectInstallationTypeAndProceedForSwap(LocalOfficeApproverManageDevicesSetInstallationTypePage localOfficeApproverManagedevicesSetInstallationTypePage, string installationType)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesSetInstallationTypePage, installationType);
            SelectInstallationTypeAndClickNext(localOfficeApproverManagedevicesSetInstallationTypePage, installationType);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesSendSwapDeviceInstallationEmail>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverManageDevicesManagePage PopulateInstallerEmailAndSendEmailForSwap(LocalOfficeApproverManageDevicesSendSwapDeviceInstallationEmail localOfficeApproverManagedevicesSendSwapDeviceInstallationEmail)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesSendSwapDeviceInstallationEmail);
            _contextData.InstallerEmail = localOfficeApproverManagedevicesSendSwapDeviceInstallationEmail.EnterInstallerEmailAndProceed();
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void CheckForSwapDeviceUpdatedPrintCount(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage, string swapNewDeviceSerialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage, swapNewDeviceSerialNumber);
            var totalPageCount = (_contextData.SwapNewDeviceMonoPrintCount + _contextData.SwapNewDeviceColourPrintCount);
            localOfficeApproverManagedevicesManagePage.CheckForUpdatedPrintCount(_localOfficeApproverWebDriver, totalPageCount, swapNewDeviceSerialNumber);
        }

        public void VerifySwappedDeviceStatus(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage);
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


        public LocalOfficeApproverReportsDashboardPage NavigateToReportsDashboardPage(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverDashBoardPage);
            ClickSafety(localOfficeApproverDashBoardPage.LocalApprovalReportingElement, localOfficeApproverDashBoardPage);
            return PageService.GetPageObject<LocalOfficeApproverReportsDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public DataQueryPage NavigateToReportsDataQueryPage(LocalOfficeApproverReportsDashboardPage localOfficeApproverReportsDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsDashboardPage);
            ClickSafety(localOfficeApproverReportsDashboardPage.DataQueryElement, localOfficeApproverReportsDashboardPage);
            return PageService.GetPageObject<DataQueryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverReportsProposalSummaryPage NavigateToContractsSummaryPage(DataQueryPage localOfficeApproverReportsDataQueryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsDataQueryPage);
            return NavigateToContractsSummaryPage(localOfficeApproverReportsDataQueryPage, _localOfficeApproverWebDriver);
        }

        public string DownloadPdf(LocalOfficeApproverReportsProposalSummaryPage localOfficeApproverReportsProposalsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsProposalsSummaryPage);
            var fileList = _pdfHelper.ListDownloadsFolder();
            localOfficeApproverReportsProposalsSummaryPage.ClickOnBillAction();
            var task = _pdfHelper.WaitforNewfile(fileList);
            if (task.Wait(new TimeSpan(0, 0, RuntimeSettings.DefaultDownloadTimeout)))
            {
                return task.Result;
            }
            else
            {
                throw new Exception("download pdf timeout");
            }
        }
                
        public void AssertAreEqualOverusageValues(string pdfFile)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFile);
            string monoOverusageText = _translationService.GetOverusageText(TranslationKeys.OverusageText.MonoText, _contextData.Culture);
            string colourOverusageText = _translationService.GetOverusageText(TranslationKeys.OverusageText.ColourText, _contextData.Culture);
            var products = _contextData.PrintersProperties;

            if(_pdfHelper.PdfExists(pdfFile) == false )
            {
                throw new Exception("pdf file does not exist=" + pdfFile);
            }
            foreach (var product in products)
            {
                var searchTextArray = new List<string>();
                if (product.VolumeMono!= 0 && product.monoOverusage > 0)
                {
                    string expected = product.monoOverusage.ToString("N0", new CultureInfo(_contextData.Culture)); 
                    searchTextArray.Add(product.Model + "\n" + product.SerialNumber + "\n" + monoOverusageText + " " + expected);
                }
                if (product.VolumeColour!=0 && product.colorOverusage > 0)
                {
                    string expected = product.colorOverusage.ToString("N0", new CultureInfo(_contextData.Culture));
                    searchTextArray.Add(product.Model + "\n" + product.SerialNumber + "\n" + colourOverusageText + " " + expected);
                }
                searchTextArray.ForEach(expected =>
                {
                    if (_pdfHelper.PdfContainsText(pdfFile, expected) == false)
                    {
                        throw new Exception(string.Format("String not found in pdf. pdfFile=[{0}], expected=[{1}]", pdfFile, expected));
                    }
                });
            }
        }

        public void DeletePdfFIle(string pdfFile)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFile);
            try { _pdfHelper.DeletePdf(pdfFile); }catch { /* ignored */ }
        }
    }
}
