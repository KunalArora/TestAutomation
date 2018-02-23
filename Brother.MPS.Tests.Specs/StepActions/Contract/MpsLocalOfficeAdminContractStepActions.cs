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
            dataQueryPage.FilterAndClickAgreement(proposalId);
            return PageService.GetPageObject<LocalOfficeAdminReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout,_webDriver);
        }

        public LocalOfficeAdminContractsEditEndDatePage ClickOnCancelContract(LocalOfficeAdminReportsProposalSummaryPage localOfficeApproverReportsProposalSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeApproverReportsProposalSummaryPage);

            ActionsModule.ClickOnTheActionsDropdown(-1/* =contract end  9,4 */, _webDriver);
            ActionsModule.NavigateToCacncelContractActionButton(_webDriver);
            return PageService.GetPageObject<LocalOfficeAdminContractsEditEndDatePage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public LocalOfficeAdminReportsProposalSummaryPage EnterContractCancellationDetailsAndSave(LocalOfficeAdminContractsEditEndDatePage localOfficeAdminContractsEditEndDatePage, string billingType)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminContractsEditEndDatePage, billingType);

            var endDay = DateTime.Today.AddDays(1);
            localOfficeAdminContractsEditEndDatePage.EnterCancellationDateAndReason(endDay, "details set end is " + endDay.ToString());

            ClickSafety(localOfficeAdminContractsEditEndDatePage.ButtonSaveElement, localOfficeAdminContractsEditEndDatePage);
            ClickSafety(localOfficeAdminContractsEditEndDatePage.ButtonApplyContractCancellationElement, localOfficeAdminContractsEditEndDatePage);
            return PageService.GetPageObject<LocalOfficeAdminReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);

        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            LoggingService.WriteLogOnMethodEntry(element, pageObject);
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }

        public string ApplyOverUsageAndContractShiftAndDownload()
        {
            LoggingService.WriteLogOnMethodEntry();
            ApplyOverusage();

            // Seek Out of Date
            _contractShiftService.ContractTimeShiftCommand(_contextData.ProposalId, 2, "d", false, false, "Any");
            BocNotifyInclementMono();

            // Generate Final Invoice
            _contractShiftService.ContractTimeShiftCommand(_contextData.ProposalId, 0, "d", false, true, "Any");
            _runCommandService.RunContractClosingMonitorCommand();
            _webDriver.Navigate().Refresh();
            // download Final Invoice
            var pdfName = _pdfHelper.Download(ph =>
            {
                var endDate = MpsUtil.DateTimeString(DateTime.Today.AddDays(-1));
                var trlist = _webDriver
                    .FindElement(By.CssSelector("table.table-striped.mps-billing-dates-container"))
                    .FindElement(By.TagName("tbody"))
                    .FindElements(By.TagName("tr"));
                foreach (var tr in trlist)
                {
                    var endDateElement = tr.FindElement(By.CssSelector("[id*=_BillingDatesList_BillingDates_CellEndDate_]"));
                    if (endDate == endDateElement.Text.Trim())
                    {
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
            return pdfName;
        }
        public void AssertAreEqualOverusageValues(string pdfFinalInvoice)
        {
            // validate pdf
            _pdfHelper.AssertAreEqualOverusageValues(pdfFinalInvoice, _contextData.PrintersProperties, _contextData.Culture);
        }

        private void ApplyOverusage()
        {
            LoggingService.WriteLogOnMethodEntry();

            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                int updatedMono;
                int updatedColor;

                LoggingService.WriteLog(LoggingLevel.DEBUG, "product.Model={0},product.MonoPrintCount={1}, product.VolumeMono={2}", product.Model, product.MonoPrintCount, product.VolumeMono);
                LoggingService.WriteLog(LoggingLevel.DEBUG, "product.Model={0},product.ColorPrintCount={1}, product.VolumeColour={2}", product.Model, product.ColorPrintCount, product.VolumeColour);
                updatedMono =  product.MonoPrintCount  + (product.MonoPrintCount  != 0 ? product.VolumeMono   : 0);
                updatedColor = product.ColorPrintCount + (product.ColorPrintCount != 0 ? product.VolumeColour : 0);
                LoggingService.WriteLog(LoggingLevel.DEBUG, "updatedMono={0},updatedColor={1}", updatedMono, updatedColor);

                string deviceId = product.DeviceId;
                _deviceSimulatorService.SetPrintCounts(deviceId, updatedMono, updatedColor);
                _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
                // divorce coefficient= 1/30..1/1. The contract end day is yesterday (at caluclation).
                var divorce = Math.Min(((double)DateTime.Today.AddDays(-1).Day) / 30.0, 1.0);
                var divorceVolumeMono = (int)(product.VolumeMono * divorce);
                var divorceVolumeColour = (int)(product.VolumeColour * divorce);
                LoggingService.WriteLog(LoggingLevel.DEBUG, "divorce={0} mono={1} colour={2}", divorce, divorceVolumeMono, divorceVolumeColour);
                product.monoOverusage = Math.Max( updatedMono - product.MonoPrintCount -  divorceVolumeMono, 0);
                product.colorOverusage = Math.Max( updatedColor - product.ColorPrintCount - divorceVolumeColour, 0);
                LoggingService.WriteLog(LoggingLevel.DEBUG, "product.monoOverusage={0}, product.colorOverusage={1}", product.monoOverusage, product.colorOverusage);
                // Update the product's print counts with the latest print count values
                product.MonoPrintCount = updatedMono;
                product.ColorPrintCount = updatedColor;
            }
            //The Print Counts are not updated on the MPS portal if implicit wait is not applied as the system processing is slow.
            _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId);

        }

        private void BocNotifyInclementMono()
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
            _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId);

        }
    }
}
