using Brother.Tests.Common.ContextData;
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
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Contract
{
    [Binding]
    public class MpsLocalOfficeAdminContractStepActions : StepActionBase
    {
        private readonly IContextData _contextData;
        private readonly DeviceSimulatorService _deviceSimulatorService;
        private readonly RunCommandService _runCommandService;
        private readonly IWebDriver _webDriver;
        private readonly ITranslationService _translationService;
        private readonly IPdfHelper _pdfHelper;
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IContractShiftService _contractShiftService;

        public MpsLocalOfficeAdminContractStepActions(
            DeviceSimulatorService deviceSimulatorService,
            RunCommandService runCommandService,
            ITranslationService translationService,
            IPdfHelper pdfHelper,
            MpsSignInStepActions mpsSignIn,
            IContractShiftService contractShiftService,

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
            _webDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeAdmin);
            _translationService = translationService;
            _pdfHelper = pdfHelper;
            _mpsSignIn = mpsSignIn;
            _contractShiftService = contractShiftService;

        }

        public LocalOfficeAdminReportsProposalSummaryPage NavigateToContractSummaryPage(DataQueryPage dataQueryPage, int proposalId)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage, proposalId);

            dataQueryPage.FilterAndClickAgreement(proposalId);
            return PageService.GetPageObject<LocalOfficeAdminReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout,_webDriver);
        }

        public LocalOfficeAdminContractsEditEndDatePage ClickOnCancelContract(LocalOfficeAdminReportsProposalSummaryPage localOfficeApproverReportsProposalSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsProposalSummaryPage);

            ActionsModule.ClickOnTheActionsDropdown(-1/* =contract end  9,4 */, _webDriver);
            ActionsModule.NavigateToCancelContractActionButton(_webDriver, localOfficeApproverReportsProposalSummaryPage.SeleniumHelper);
            return PageService.GetPageObject<LocalOfficeAdminContractsEditEndDatePage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public LocalOfficeAdminReportsProposalSummaryPage EnterContractCancellationDetailsAndSave(LocalOfficeAdminContractsEditEndDatePage localOfficeAdminContractsEditEndDatePage, string billingType)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminContractsEditEndDatePage, billingType);

            var endDay = DateTime.Today.AddDays(1);
            localOfficeAdminContractsEditEndDatePage.EnterCancellationDateAndReason(endDay, "details set end is " + endDay.ToString());

            ClickSafety(localOfficeAdminContractsEditEndDatePage.ButtonSaveElement, localOfficeAdminContractsEditEndDatePage);
            ClickSafety(localOfficeAdminContractsEditEndDatePage.ButtonApplyContractCancellationElement, localOfficeAdminContractsEditEndDatePage,true);
            return PageService.GetPageObject<LocalOfficeAdminReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);

        }

        public LocalOfficeAdminReportsProposalSummaryPage EditProposalNotes(LocalOfficeAdminReportsProposalSummaryPage localOfficeAdminReportsProposalSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminReportsProposalSummaryPage);

            localOfficeAdminReportsProposalSummaryPage.EditProposalNotes();
            ClickSafety(localOfficeAdminReportsProposalSummaryPage.SaveButtonElement, localOfficeAdminReportsProposalSummaryPage);
            return PageService.GetPageObject<LocalOfficeAdminReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
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
            _webDriver.Navigate().Refresh();
            // download Final Invoice
            IWebElement startDateElement=null;
            var pdfName = _pdfHelper.Download(ph =>
            {
                var endDate = MpsUtil.DateTimeString(DateTime.Today.AddDays(-1), _contextData.Country.CountryIso);
                var trlist = _webDriver
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
            LoggingService.WriteLogOnMethodEntry(pdfFinalInvoice);

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

        private double CalculateFilnalInvoiceMinimumVolume(DateTime startDate, DateTime endDate)
        {
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
    }
}
