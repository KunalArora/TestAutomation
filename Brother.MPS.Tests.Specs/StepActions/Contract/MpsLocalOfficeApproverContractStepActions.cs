﻿using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Helpers.ExcelHelpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Contract
{
    [Binding]
    public class MpsLocalOfficeApproverContractStepActions : MpsLocalOfficeStepActions 
    {
        private readonly IContextData _contextData;
        private readonly DeviceSimulatorService _deviceSimulatorService;
        private readonly RunCommandService _runCommandService;
        private readonly IWebDriver _localOfficeApproverWebDriver;
        private readonly ITranslationService _translationService;
        private readonly IPdfHelper _pdfHelper;
        private readonly IContractShiftService _contractShiftService;
        private readonly IUserResolver _userResolver;

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
            RunCommandService runCommandService,
            IDevicesExcelHelper devicesExcelHelper,
            IClickBillExcelHelper clickBillExcelHelper,
            IServiceInstallationBillExcelHelper serviceInstallationBillExcelHelper,
            IContractShiftService contractShiftService,
            IUserResolver userResolver,
            ICalculationService calculationService)
            : base(
            webDriverFactory,
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
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
            _runCommandService = runCommandService;
            _localOfficeApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
            _translationService = translationService;
            _pdfHelper = pdfHelper;
            _contractShiftService = contractShiftService;
            _userResolver = userResolver;
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
            localofficeApproverApprovalContractsAwaitingAcceptancePage.ClickOnViewSummary(ContextData.ProposalId, ContextData.ProposalName, _localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsAcceptedPage AcceptContract(LocalOfficeApproverApprovalContractsSummaryPage localOfficeApproverApprovalContractsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalContractsSummaryPage);
            string resourceContractTypeEPP = _translationService.GetContractTypeText(TranslationKeys.ContractType.EasyPrintProAndService, _contextData.Culture);
            string contextDataContractType = _contextData.ContractType;
            localOfficeApproverApprovalContractsSummaryPage.OnClickAccept(contextDataContractType, resourceContractTypeEPP);
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsAcceptedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void RejectContract(LocalOfficeApproverApprovalContractsSummaryPage localOfficeApproverContractsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverContractsSummaryPage);
            string contractRejectReasonExpired = _translationService.GetProposalDeclineReasonText(TranslationKeys.ContractRejectReason.Expired, _contextData.Culture);

            localOfficeApproverContractsSummaryPage.RejectContract(contractRejectReasonExpired);
            PageService.GetPageObject<LocalOfficeApproverApprovalProposalsDeclinedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void VerifyAcceptContract(LocalOfficeApproverApprovalContractsAcceptedPage localOfficeApproverApprovalContractsAcceptedPage, int proposalId, string proposalName)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverApprovalContractsAcceptedPage, proposalId, proposalName);
            localOfficeApproverApprovalContractsAcceptedPage.VerifyContractFilter(proposalId, proposalName);
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

        public LocalOfficeApproverManageDevicesManagePage ClickOnActionsManageDevices(LocalOfficeApproverManageDevicesContractsPage localOfficeApproverManagedevicesContractsPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesContractsPage);
            localOfficeApproverManagedevicesContractsPage.SetListFilter(_contextData.ProposalId, _contextData.ProposalName);
            localOfficeApproverManagedevicesContractsPage.NavigateToManageDevicesPage();
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

            // note: IsElementDisplayed(...SendButtonElement) => see https://brother-bie.atlassian.net/browse/MPS-5846
            while (localOfficeApproverManagedevicesSendInstallationEmailPage.SeleniumHelper.IsElementDisplayed(localOfficeApproverManagedevicesSendInstallationEmailPage.WarningAlertElement) ||
                localOfficeApproverManagedevicesSendInstallationEmailPage.SeleniumHelper.IsElementDisplayed(localOfficeApproverManagedevicesSendInstallationEmailPage.SendButtonElement) == false )
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

            _contextData.InstallerEmail = _userResolver.InstallerUsername;
            localOfficeApproverManagedevicesSendInstallationEmailPage.EnterInstallerEmailAndProceed(_contextData.InstallerEmail);
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

                while (!(localOfficeApproverManagedevicesManagePage.CheckForUpdatedPrintCount(_localOfficeApproverWebDriver, totalPageCount, product.SerialNumber)))
                {
                    _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId, _contextData.Country.CountryIso);
                    _localOfficeApproverWebDriver.Navigate().Refresh();
                    localOfficeApproverManagedevicesManagePage = PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
                    continue;
                }
                _localOfficeApproverWebDriver.Navigate().Refresh();
                localOfficeApproverManagedevicesManagePage = PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
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
            _contextData.InstallerEmail = _userResolver.InstallerUsername;
            localOfficeApproverManagedevicesSendSwapDeviceInstallationEmail.EnterInstallerEmailAndProceed(_contextData.InstallerEmail);
            return PageService.GetPageObject<LocalOfficeApproverManageDevicesManagePage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void CheckForSwapDeviceUpdatedPrintCount(LocalOfficeApproverManageDevicesManagePage localOfficeApproverManagedevicesManagePage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverManagedevicesManagePage);
            var totalPageCount = (_contextData.SwapNewDeviceMonoPrintCount + _contextData.SwapNewDeviceColourPrintCount);
            localOfficeApproverManagedevicesManagePage.CheckForUpdatedPrintCount(_localOfficeApproverWebDriver, totalPageCount, _contextData.SwapNewDeviceSerialNumber);
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

        public LocalOfficeApproverReportsProposalSummaryPage ApplyOverusage(LocalOfficeApproverReportsProposalSummaryPage localOfficeApproverReportsProposalsSummaryPage, int contractShiftTimeOffsetValue)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsProposalsSummaryPage, contractShiftTimeOffsetValue);
            var products = _contextData.PrintersProperties;
            // Shift the contract 2 times to update print counts and generate Invoices for upto 3 Billing periods.
            for (int i = 0; i < 2; i++)
            {
                // Calling contract shift API and shifting by 6 months(in case of Half yearly) and 3 months(in case of Quarterly).
                //TODO: Shift the contract according to proper caluculations for days
                _contractShiftService.ContractTimeShiftCommand(_contextData.ProposalId, contractShiftTimeOffsetValue*31, "d", false, false, "Any");
                foreach (var product in products)
                {
                    int updatedMono;
                    int updatedColor;
                    // Calculate the mono and colour print count for the next billing period depending on MonoPrintCount and Volume Mono. 
                    // Making sure that the updated print count is more than Minimum Volume for the billing period.
                    updatedMono = contractShiftTimeOffsetValue * product.MonoPrintCount + (product.MonoPrintCount != 0 ? product.VolumeMono : 0);
                    updatedColor = contractShiftTimeOffsetValue * product.ColorPrintCount + (product.ColorPrintCount != 0 ? product.VolumeColour : 0);

                    string deviceId = product.DeviceId;
                    _deviceSimulatorService.SetPrintCounts(deviceId, updatedMono, updatedColor);
                    _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
                    // Calculate the Overusage for mono and colour for each printer to verify it in the Invoice PDF.
                    // Subtract the previous Billing period's print count and Minimum volume for the current billing period from the latest/updated print counts. 
                    product.monoOverusage = updatedMono - product.MonoPrintCount - contractShiftTimeOffsetValue * product.VolumeMono;
                    product.colorOverusage = updatedColor - product.ColorPrintCount - contractShiftTimeOffsetValue * product.VolumeColour;
                    // Update the product's print counts with the latest print count values
                    product.MonoPrintCount = updatedMono;
                    product.ColorPrintCount = updatedColor;
                    product.TotalPageCount = updatedMono + updatedColor;
                }
                //Verify the updated print counts on the portal and retry running meter read command if not updated.
                localOfficeApproverReportsProposalsSummaryPage = VerifyUpdatedPrintCounts(localOfficeApproverReportsProposalsSummaryPage);
            }
            // Finally, run the contract shift API to generate Billing Invoices upto 3 Billing Periods 
            _contractShiftService.ContractTimeShiftCommand(_contextData.ProposalId, contractShiftTimeOffsetValue*31, "d", false, true, "Any");
            
            _localOfficeApproverWebDriver.Navigate().Refresh();
            localOfficeApproverReportsProposalsSummaryPage = PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);

            return localOfficeApproverReportsProposalsSummaryPage;
        }

        private LocalOfficeApproverReportsProposalSummaryPage VerifyUpdatedPrintCounts(LocalOfficeApproverReportsProposalSummaryPage localOfficeApproverReportsProposalsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsProposalsSummaryPage);

            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId, _contextData.Country.CountryIso);

            _localOfficeApproverWebDriver.Navigate().Refresh();
            localOfficeApproverReportsProposalsSummaryPage = PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);

            int retries = 0;

            foreach (var product in _contextData.PrintersProperties)
            {
                while (!localOfficeApproverReportsProposalsSummaryPage.VerifyPrintCountsOfDevice(product.SerialNumber, product.TotalPageCount))
                {
                    _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId, _contextData.Country.CountryIso);

                    _localOfficeApproverWebDriver.Navigate().Refresh();
                    localOfficeApproverReportsProposalsSummaryPage = PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);

                    retries++;
                    if (retries > RuntimeSettings.DefaultRetryCount)
                    {
                        TestCheck.AssertFailTest(
                            string.Format("Number of retries exceeded the default limit during verification of print counts for agreement {0}", _contextData.ProposalId));
                    }
                    continue;
                }
            }

            _localOfficeApproverWebDriver.Navigate().Refresh();
            localOfficeApproverReportsProposalsSummaryPage = PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);

            return localOfficeApproverReportsProposalsSummaryPage;
        } 
        
        public string DownloadPdf(LocalOfficeApproverReportsProposalSummaryPage localOfficeApproverReportsProposalsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsProposalsSummaryPage);
            return _pdfHelper.Download(ph =>
           {
               localOfficeApproverReportsProposalsSummaryPage.ClickOnBillAction();
               return true;
           });
        }
                
        public void AssertAreEqualOverusageValues(string pdfFile)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFile);
            _pdfHelper.AssertAreEqualOverusageValues(pdfFile, _contextData.PrintersProperties, _contextData.Culture);
        }

        public void DeletePdfFile(string pdfFile)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFile);
            _pdfHelper.DeletePdfErrorIgnored(pdfFile);
        }

        public LocalOfficeApproverReportsProposalSummaryPage RaiseManualConsumableOrder(LocalOfficeApproverReportsProposalSummaryPage localOfficeApproverReportsProposalSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsProposalSummaryPage);

            foreach(var printer in _contextData.PrintersProperties)
            {
                if (printer.hasEmptyInkToner)
                {
                    localOfficeApproverReportsProposalSummaryPage.ClickRaiseManualConsumableOrder(printer);
                    var localOfficeReportsProposalSummaryRaiseOrderPage =
                                            PageService.GetPageObject<LocalOfficeReportsProposalSummaryRaiseOrderPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
                    // Select consumables
                    localOfficeReportsProposalSummaryRaiseOrderPage.SelectConsumables(
                        printer.TonerInkBlackStatus, printer.TonerInkCyanStatus, printer.TonerInkMagentaStatus, printer.TonerInkYellowStatus);

                    ClickSafety(
                        localOfficeReportsProposalSummaryRaiseOrderPage.SubmitOrderButtonElement, localOfficeReportsProposalSummaryRaiseOrderPage);
                    localOfficeReportsProposalSummaryRaiseOrderPage.SeleniumHelper.AcceptJavascriptAlert();

                    // Verify success alert
                    localOfficeReportsProposalSummaryRaiseOrderPage.VerifySuccessfulOrderCreation();
                    ClickSafety(localOfficeReportsProposalSummaryRaiseOrderPage.BackButtonElement, localOfficeReportsProposalSummaryRaiseOrderPage, true);

                    localOfficeApproverReportsProposalSummaryPage = PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
                }   
            }

            return localOfficeApproverReportsProposalSummaryPage;
        }
    }
}
