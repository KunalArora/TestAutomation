﻿using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Contract
{
    [Binding]
    public class MpsLocalOfficeAdminContractStepActions : StepActionBase
    {
        private readonly IContextData _contextData;
        private readonly DeviceSimulatorService _deviceSimulatorService;
        private readonly RunCommandService _runCommandService;
        private readonly IWebDriver _loAdminWebDriver;
        private readonly ITranslationService _translationService;
        private readonly IPdfHelper _pdfHelper;
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IContractShiftService _contractShiftService;
        private readonly IPageParseHelper _pageParseHelper;

        public MpsLocalOfficeAdminContractStepActions(
            DeviceSimulatorService deviceSimulatorService,
            RunCommandService runCommandService,
            ITranslationService translationService,
            IPdfHelper pdfHelper,
            MpsSignInStepActions mpsSignIn,
            IContractShiftService contractShiftService,
            IPageParseHelper pageParseHelper,

            IWebDriverFactory webDriverFactory, 
            IContextData contextData, 
            IPageService pageService, 
            ScenarioContext scenarioContext, 
            IUrlResolver urlResolver, 
            ILoggingService loggingService, 
            IRuntimeSettings runtimeSettings) 
            : base(webDriverFactory, contextData, pageService, scenarioContext, urlResolver, loggingService, runtimeSettings)
        {
            _contextData = contextData;
            _deviceSimulatorService = deviceSimulatorService;
            _runCommandService = runCommandService;
            _loAdminWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeAdmin);
            _translationService = translationService;
            _pdfHelper = pdfHelper;
            _mpsSignIn = mpsSignIn;
            _contractShiftService = contractShiftService;
            _pageParseHelper = pageParseHelper;

        }

        public LocalOfficeAdminReportsProposalSummaryPage NavigateToContractSummaryPage(DataQueryPage dataQueryPage, int proposalId)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage, proposalId);

            dataQueryPage.FilterAndClickAgreement(proposalId);
            return PageService.GetPageObject<LocalOfficeAdminReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAdminContractsEditEndDatePage ClickOnCancelContract(LocalOfficeAdminReportsProposalSummaryPage localOfficeApproverReportsProposalSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsProposalSummaryPage);

            ActionsModule.ClickOnTheActionsDropdown(-1/* =contract end  9,4 */, _loAdminWebDriver);
            ActionsModule.NavigateToCancelContractActionButton(_loAdminWebDriver, localOfficeApproverReportsProposalSummaryPage.SeleniumHelper);
            return PageService.GetPageObject<LocalOfficeAdminContractsEditEndDatePage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAdminReportsProposalSummaryPage EnterContractCancellationDetailsAndSave(LocalOfficeAdminContractsEditEndDatePage localOfficeAdminContractsEditEndDatePage, string billingType)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminContractsEditEndDatePage, billingType);

            var endDay = DateTime.Today.AddDays(1);
            localOfficeAdminContractsEditEndDatePage.EnterCancellationDateAndReason(endDay, "details set end is " + endDay.ToString());

            var snapValues = _pageParseHelper.ParseLocalOfficeAdminContractsEditEndDatePage(localOfficeAdminContractsEditEndDatePage);
            AssertAreEqualsAdditionalCharges(_contextData.AdditionalChargesItemList, snapValues);
            _contextData.SnapValues[typeof(LocalOfficeAdminContractsEditEndDatePage)] = snapValues;

            ClickSafety(localOfficeAdminContractsEditEndDatePage.ButtonSaveElement, localOfficeAdminContractsEditEndDatePage);
            ClickSafety(localOfficeAdminContractsEditEndDatePage.ButtonApplyContractCancellationElement, localOfficeAdminContractsEditEndDatePage,true);
            return PageService.GetPageObject<LocalOfficeAdminReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);

        }

        public void AssertAreEqualsAdditionalCharges( IList<AdditionalChargesItem> expectedAdditionalChargesItemList, LocalOfficeAdminContractsEditEndDatePageValue actualSnapValues)
        {
            LoggingService.WriteLogOnMethodEntry(expectedAdditionalChargesItemList,actualSnapValues);
            var actualChargesList = actualSnapValues.GetExistingChargesList(_pageParseHelper) ;
            Assert.AreEqual(actualChargesList.Count, expectedAdditionalChargesItemList.Count, "AssertAreEqualsAdditionalCharges() different item count");
            expectedAdditionalChargesItemList.All(expectedItem =>
            {
                var found = actualChargesList.Any(actualItem =>
               {
                   if( actualItem["ChargeType@value"] != expectedItem.chargeTypeValue.ToString()) { return false; }
                   if (double.Parse(actualItem["CostPrice"],_contextData.CultureInfo) != expectedItem.costPrice) { return false; }
                   if (double.Parse(actualItem["DealerMargin"], _contextData.CultureInfo) != expectedItem.marginPercent) { return false; }
                   return true;
               });
                Assert.True(found, "AssertAreEqualsAdditionalCharges() target charges not found. expectedItem=" + expectedItem);
                return found;
            });
        }

        public LocalOfficeAdminReportsProposalSummaryPage EditProposalNotes(LocalOfficeAdminReportsProposalSummaryPage localOfficeAdminReportsProposalSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminReportsProposalSummaryPage);

            localOfficeAdminReportsProposalSummaryPage.EditProposalNotes();
            ClickSafety(localOfficeAdminReportsProposalSummaryPage.SaveButtonElement, localOfficeAdminReportsProposalSummaryPage);
            return PageService.GetPageObject<LocalOfficeAdminReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public void AssertTheContractStatusIsClosed(DataQueryPage dataQueryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage);
            try
            {
                dataQueryPage.SeleniumHelper.ClickSafety(dataQueryPage.ClosedContractElement);
                dataQueryPage.SeleniumHelper.SetListFilter(dataQueryPage.DataQuerySearchField, _contextData.ProposalId.ToString(), dataQueryPage.VisibleItemDivElements);
            }
            catch(Exception e)
            {
                Assert.Fail( "AssertTheContractStatusIsClosed() Contract may not closed or not found id={0}, e={1}, tacktrace={2}" , _contextData.ProposalId, e, e.StackTrace);   
            }

        }

        public LocalOfficeAdminContractsAdditionalCharges ClickOnAdditionalCharges(LocalOfficeAdminReportsProposalSummaryPage localOfficeAdminReportsProposalSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminReportsProposalSummaryPage);
            ActionsModule.ClickOnTheActionsDropdown(-1/* =contract end  9,4 */, _loAdminWebDriver);
            ActionsModule.NavigateToAdditionalChargesActionButton(_loAdminWebDriver, localOfficeAdminReportsProposalSummaryPage.SeleniumHelper);
            return PageService.GetPageObject<LocalOfficeAdminContractsAdditionalCharges>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public void AddAdditionalCharges(LocalOfficeAdminContractsAdditionalCharges localOfficeAdminContractsAdditionalCharges, LocalOfficeAdminContractsAdditionalCharges.ChargeTypeSelectorElementValue chargeType, double costPrice, double marginPercent)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminContractsAdditionalCharges, chargeType, costPrice, marginPercent);
            var SeleniumHelper = localOfficeAdminContractsAdditionalCharges.SeleniumHelper;
            localOfficeAdminContractsAdditionalCharges.EnterAdditionalChargesValue(chargeType, costPrice, marginPercent);
            SeleniumHelper.ClickSafety(localOfficeAdminContractsAdditionalCharges.AddButtonElement);
            ContextData.AdditionalChargesItemList.Add( new AdditionalChargesItem() { chargeTypeValue = (int)chargeType, costPrice = costPrice, marginPercent = marginPercent } );
        }

        public LocalOfficeAdminReportsProposalSummaryPage ClickOnBack(LocalOfficeAdminContractsAdditionalCharges localOfficeAdminContractsAdditionalCharges)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminContractsAdditionalCharges);
            var SeleniumHelper = localOfficeAdminContractsAdditionalCharges.SeleniumHelper;
            SeleniumHelper.ClickSafety(localOfficeAdminContractsAdditionalCharges.BackElement,IsUntilUrlChanges:true);
            return PageService.GetPageObject<LocalOfficeAdminReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public void VerifyProposalNotes(LocalOfficeAdminReportsProposalSummaryPage localOfficeAdminReportsProposalSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminReportsProposalSummaryPage);

            var isNotes = localOfficeAdminReportsProposalSummaryPage.VerifyProposalNotes();
            if (isNotes == false)
            {
                throw new Exception("Proposal note is not updated successfully");
            }
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject, bool IsUntilUrlChanges=false)
        {
            LoggingService.WriteLogOnMethodEntry(element, pageObject);
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout,IsUntilUrlChanges);
        }

        public string ApplyOverUsageAndContractShiftAndDownload( out DateTime startDateString)
        {
            LoggingService.WriteLogOnMethodEntry();
            ApplyOverusage();

            // Seek Out of Date
            _contractShiftService.ContractTimeShiftCommand(_contextData.ProposalId, 2, "d", false, false, "Any");
            BocNotifyIncrementMono();

            // Generate Final Invoice
            _contractShiftService.ContractTimeShiftCommand(_contextData.ProposalId, 0, "d", false, true, "Any");
            _runCommandService.RunContractClosingMonitorCommand();
            _loAdminWebDriver.Navigate().Refresh();
            // download Final Invoice
            IWebElement startDateElement=null;
            var pdfName = _pdfHelper.Download(ph =>
            {
                var endDate = MpsUtil.DateTimeString(DateTime.Today.AddDays(-1), _contextData.Country.CountryIso);
                var trlist = _loAdminWebDriver
                    .FindElement(By.CssSelector("table.table-striped.mps-billing-dates-container"))
                    .FindElement(By.TagName("tbody"))
                    .FindElements(By.TagName("tr"));
                foreach (var tr in trlist)
                {
                    var endDateElement = tr.FindElement(By.CssSelector("[id*=_BillingDatesList_BillingDates_CellEndDate_]"));
                    if (endDate == endDateElement.Text.Trim())
                    {
                        startDateElement = tr.FindElement(By.CssSelector("[id*=_BillingDatesList_BillingDates_CellStartDate_]")); // 01/03/2018 = Mar.1
                        var step = "";
                        try
                        {
                            step = "button";
                            tr.FindElement(By.TagName("button")).Click();
                            step = "a";
                            tr.FindElement(By.TagName("a")).Click();
                        }
                        catch (Exception e)
                        {
                            Assert.Fail("Actions ViewBill can't click target line endate={0} step={1} e={2}",endDate,step,e);
                        }
                        return true;
                    }
                }
                throw new Exception("pdf download target view bill button not found.");
            });
            Assert.NotNull(startDateElement.Text);
            startDateString = MpsUtil.StringToDateTimeFormat(startDateElement.Text, _contextData.Country.CountryIso);
            return pdfName;
        }

        private const int FINAL_PV_COEFFICIENT = 2;

        public void AssertAreEqualOverusageValues(string pdfFinalInvoice,DateTime startDate)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFinalInvoice, startDate);

            var products = _contextData.PrintersProperties;
            var endDate = DateTime.Today.AddDays(-1); // yesterday
            var mvCoefficient = CalculateFilnalInvoiceMinimumVolume(startDate, endDate);
            LoggingService.WriteLog(LoggingLevel.DEBUG, "period start={0}, end={1}, mvCoefficient={2}", startDate, endDate, mvCoefficient);

            foreach (var product in products)
            {
                string deviceId = product.DeviceId;

                // calclate periodic MinimumVolume and PrintVolume.
                var mvMono = (int)Math.Round(product.VolumeMono * mvCoefficient);
                var mvColour = (int)Math.Round(product.VolumeColour * mvCoefficient);
                var pvMono = (product.MonoPrintCount != 0 ? (product.VolumeMono * FINAL_PV_COEFFICIENT) + 1/*cause BocNotifyIncrementMono*/ : 0);
                var pvColour = (product.ColorPrintCount != 0 ? product.VolumeColour * FINAL_PV_COEFFICIENT : 0);
                product.monoOverusage = Math.Max(pvMono - mvMono, 0);
                product.colorOverusage = Math.Max(pvColour - mvColour, 0);
                LoggingService.WriteLog(LoggingLevel.DEBUG, "product.Model={0}, mvMono={2}, mvColour={3}, product.monoOverusage={4}, product.colorOverusage={5}", product.Model, mvCoefficient, mvMono, mvColour, product.monoOverusage, product.colorOverusage);
            }
            // validate pdf
            _pdfHelper.AssertAreEqualOverusageValues(pdfFinalInvoice, _contextData.PrintersProperties, _contextData.Culture);
        }

        public void AssertAreEqualAdditionalCharges(string pdfFinalInvoice, LocalOfficeAdminContractsEditEndDatePageValue expectedSnapValues)
        {
            LoggingService.WriteLogOnMethodEntry(pdfFinalInvoice, expectedSnapValues);            
            _pdfHelper.AssertAreEqualAdditionalCharges(pdfFinalInvoice, expectedSnapValues.GetExistingChargesList(_pageParseHelper), _contextData.CultureInfo);
        }

        public LocalOfficeAdminProgramsDashboardPage NavigateToProgramPage(LocalOfficeAdminDashBoardPage localOfficeAdminDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminDashboardPage);
            localOfficeAdminDashboardPage.SeleniumHelper.ClickSafety(localOfficeAdminDashboardPage.LOAdminProgramElement);
            return PageService.GetPageObject<LocalOfficeAdminProgramsDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAdminProgramsLeaseAndClickProgramSettingsPage NavigateToLeaseAndClickProgramSettingsPage(LocalOfficeAdminProgramsDashboardPage localOfficeAdminProgramPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminProgramPage);
            localOfficeAdminProgramPage.SeleniumHelper.ClickSafety(localOfficeAdminProgramPage.LeasingContractLinkElement);
            return PageService.GetPageObject<LocalOfficeAdminProgramsLeaseAndClickProgramSettingsPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage NavigateToPurchaseAndClickProgramSettingsPage(LocalOfficeAdminProgramsDashboardPage localOfficeAdminProgramPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminProgramPage);
            localOfficeAdminProgramPage.SeleniumHelper.ClickSafety(localOfficeAdminProgramPage.PurchaseAndClickLinkElement);
            return PageService.GetPageObject<LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAdminProgramsLeaseAndClickProgramSettingsPage ClickOnProgramEnabledButtonAndSave(LocalOfficeAdminProgramsLeaseAndClickProgramSettingsPage localOfficeAdminProgramLeaseAndClickPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminProgramLeaseAndClickPage);
            localOfficeAdminProgramLeaseAndClickPage.ClickOnProgramEnabledButton();
            localOfficeAdminProgramLeaseAndClickPage.SeleniumHelper.ClickSafety(localOfficeAdminProgramLeaseAndClickPage.SaveButton);
            return PageService.GetPageObject<LocalOfficeAdminProgramsLeaseAndClickProgramSettingsPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAdminProgramsLeaseAndClickProgramSettingsPage DisableProgramAndSave(LocalOfficeAdminProgramsLeaseAndClickProgramSettingsPage localOfficeAdminProgramLeaseAndClickPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminProgramLeaseAndClickPage);
            localOfficeAdminProgramLeaseAndClickPage.ClickOnProgramDisableButton();
            localOfficeAdminProgramLeaseAndClickPage.SeleniumHelper.ClickSafety(localOfficeAdminProgramLeaseAndClickPage.SaveButton);
            return PageService.GetPageObject<LocalOfficeAdminProgramsLeaseAndClickProgramSettingsPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage AddANewBillingCycle(LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage localOfficeAdminProgramPurchaseAndClickPage,
            string billingType, string billingUsageType, string billingPaymentType)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminProgramPurchaseAndClickPage, billingType, billingUsageType, billingPaymentType);
            localOfficeAdminProgramPurchaseAndClickPage.SeleniumHelper.ClickSafety(localOfficeAdminProgramPurchaseAndClickPage.AddBillingCycleButtonElement);
            localOfficeAdminProgramPurchaseAndClickPage.CreateANewBillingCycleDetails(billingType, billingUsageType, billingPaymentType);
            return PageService.GetPageObject<LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage EnableTheCreatedBillingCycle(LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage localOfficeAdminProgramPurchaseAndClickPage,
            string billingType, string billingUsageType, string billingPaymentType)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminProgramPurchaseAndClickPage, billingType, billingUsageType, billingPaymentType);
            var resourceBillingCysleStatusDisabled = _translationService.GetBillingCycleStatusText(TranslationKeys.BillingCycleStatus.Disabled, _contextData.Culture);
            localOfficeAdminProgramPurchaseAndClickPage.VerifyAndEnableNewlyCreatedBillingCycle(billingType, billingUsageType, billingPaymentType, resourceBillingCysleStatusDisabled);
            return PageService.GetPageObject<LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage DeleteTheCreatedBillingCycle(LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage localOfficeAdminProgramPurchaseAndClickPage, 
            string billingType, string billingUsageType, string billingPaymentType)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminProgramPurchaseAndClickPage, billingType, billingUsageType, billingPaymentType);
            var resourceBillingCysleStatusEnabled = _translationService.GetBillingCycleStatusText(TranslationKeys.BillingCycleStatus.Enabled, _contextData.Culture);
            localOfficeAdminProgramPurchaseAndClickPage.DeleteNewlyCreatedBillingCycle(billingType, billingUsageType, billingPaymentType, resourceBillingCysleStatusEnabled);
            return PageService.GetPageObject<LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        private double CalculateFilnalInvoiceMinimumVolume(DateTime startDate, DateTime endDate)
        {
            LoggingService.WriteLogOnMethodEntry(startDate, endDate);
            if (startDate.Day==1 && endDate.Day == DateTime.DaysInMonth(endDate.Year, endDate.Month))
            {
                var elapsedMonth = (endDate.Year*12+endDate.Month) - (startDate.Year*12+startDate.Month) + 1;
                return (double)elapsedMonth; // Apr.1-30=1 May.1-31=1 Apr.1-May.31=2
            }
            // if billing cycle below
            // 01/03/2018    03/04/2018
            // 
            // *Final invoice*
            // currentDate.Subtract(previousDate.AddMonths(months)).Days
            // where CurrentDate is the enddate and PreviousDate is the day before the startdate
            // 
            // 28/2 + 1 month = 28/3, 4/3 - 28/3 = 6 days
            //
            var previousDate = startDate.AddDays(-1);
            var months = endDate.Month - startDate.Month + (previousDate.Day <= endDate.Day ? 1 : 0);
            var days = Math.Min(endDate.Subtract(previousDate.AddMonths(months)).Days, 30);
            double mv = months + days / 30.0;
            return mv;
        }

        private void ApplyOverusage()
        {
            LoggingService.WriteLogOnMethodEntry();

            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                int updatedMono;
                int updatedColor;

                LoggingService.WriteLog(LoggingLevel.DEBUG, "product.Model={0}, .deviceId={1}, .MonoPrintCount={2}, .VolumeMono={3}, .ColorPrintCount={4}, .VolumeColour={5}", 
                    product.Model, product.DeviceId,
                    product.MonoPrintCount, product.VolumeMono,
                    product.ColorPrintCount, product.VolumeColour
                    );
                updatedMono =  product.MonoPrintCount  + (product.MonoPrintCount  != 0 ? product.VolumeMono* FINAL_PV_COEFFICIENT : 0);
                updatedColor = product.ColorPrintCount + (product.ColorPrintCount != 0 ? product.VolumeColour* FINAL_PV_COEFFICIENT : 0);
                LoggingService.WriteLog(LoggingLevel.DEBUG, "product.Model={0}, updatedMono={1}, updatedColor={2}", product.Model, updatedMono, updatedColor);

                string deviceId = product.DeviceId;
                _deviceSimulatorService.SetPrintCounts(deviceId, updatedMono, updatedColor);
                _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);

                product.MonoPrintCount = updatedMono;
                product.ColorPrintCount = updatedColor;
            }
            //The Print Counts are not updated on the MPS portal if implicit wait is not applied as the system processing is slow.
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId, _contextData.Country.CountryIso);

        }


        private void BocNotifyIncrementMono()
        {
            LoggingService.WriteLogOnMethodEntry();
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                string deviceId = product.DeviceId;
                _deviceSimulatorService.SetPrintCounts(product.DeviceId,++ product.MonoPrintCount,product.ColorPrintCount );
                _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
                if (product.monoOverusage != 0) product.monoOverusage++;
            }
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId, _contextData.Country.CountryIso);

        }

        public LocalOfficeEnhancedUsageMonitoringAdminInstalledPrinterPage NavigateToEnhancedUsageMonitoringAdminInstalledPrinterPage(LocalOfficeAdminDashBoardPage localOfficeAdminDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminDashboardPage);

            ClickSafety(localOfficeAdminDashboardPage.LOAdminAdministrationLinkElement, localOfficeAdminDashboardPage, IsUntilUrlChanges: true);
            var localOfficeAdminAdministratorDashboardPage = PageService.GetPageObject<LocalOfficeAdminAdministrationDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
            ClickSafety(localOfficeAdminDashboardPage.ManageDeviceOrderThresholdLink, localOfficeAdminDashboardPage, IsUntilUrlChanges: true);
            return PageService.GetPageObject<LocalOfficeEnhancedUsageMonitoringAdminInstalledPrinterPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public LocalOfficeEnhancedUsageMonitoringAdminPrinterEnginePage NavigateToEnhancedUsageMonitoringAdminPrinterEnginePage(LocalOfficeEnhancedUsageMonitoringAdminInstalledPrinterPage localOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage);

            ClickSafety(localOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage.PrinterEngineTabElement, localOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage, IsUntilUrlChanges: true);
            return PageService.GetPageObject<LocalOfficeEnhancedUsageMonitoringAdminPrinterEnginePage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public LocalOfficeEnhancedUsageMonitoringAdminPrinterEnginePage UpdatePrinterEngineThresholdDetailsAndSave(LocalOfficeEnhancedUsageMonitoringAdminPrinterEnginePage localOfficeAdminEnhancedUsageMonitoringAdminPrinterEnginePage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminEnhancedUsageMonitoringAdminPrinterEnginePage);

            foreach (var printerEngine in _contextData.PrinterEngineThresholdDetails)
            {
                localOfficeAdminEnhancedUsageMonitoringAdminPrinterEnginePage.EditPrinterEngineThresholdDetails(printerEngine);
            }

            ClickSafety(localOfficeAdminEnhancedUsageMonitoringAdminPrinterEnginePage.SaveButtonElement, localOfficeAdminEnhancedUsageMonitoringAdminPrinterEnginePage);

            // Validate success element
            localOfficeAdminEnhancedUsageMonitoringAdminPrinterEnginePage.CloseSuccessElementIfPresent();

            return PageService.GetPageObject<LocalOfficeEnhancedUsageMonitoringAdminPrinterEnginePage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver); 
        }
    }
}
