using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
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
            // save print count



            // contract end
            ActionsModule.ClickOnTheActionsDropdown((5+4)/* =contract end */, _webDriver);
            ActionsModule.NavigateToCacncelContracrActionButton(_webDriver);
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

        public void SetPrintCountForOverusage()
        {
            LoggingService.WriteLogOnMethodEntry();
            ApplyOverusage(1);

            _contractShiftService.ContractTimeShiftCommand(_contextData.ProposalId, 2, "d", false, false, "Any");
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                string deviceId = product.DeviceId;
                //_deviceSimulatorService.SetPrintCounts(deviceId, updatedMono, updatedColor);
                _deviceSimulatorService.SetPrintCounts(product.DeviceId, 
                    product.MonoPrintCount != 0 ? (product.MonoPrintCount + 1) : 0,
                    product.ColorPrintCount != 0 ? (product.ColorPrintCount + 1) : 0);
                _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
            }
            _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId);

            _contractShiftService.ContractTimeShiftCommand(_contextData.ProposalId, 0, "d", true/*dummy*/, true, "Any");
            _runCommandService.RunContractClosingMonitorCommand();
        }

        public void ValidateFinalInvoice()
        {
            LoggingService.WriteLogOnMethodEntry();
            throw new NotImplementedException();
        }

        public void TimeShiftForOutOfDay()
        {
            LoggingService.WriteLogOnMethodEntry();
            throw new NotImplementedException();
        }

        private void ApplyOverusage(int contractShiftTimeOffsetValue)
        {
            LoggingService.WriteLogOnMethodEntry(contractShiftTimeOffsetValue);

            var products = _contextData.PrintersProperties;
            // Calling contract shift API and shifting by 6 months(in case of Half yearly) and 3 months(in case of Quarterly).
            //_contractShiftService.ContractTimeShiftCommand(_contextData.ProposalId, contractShiftTimeOffsetValue, "m", false, false, "Any");
            foreach (var product in products)
            {
                int updatedMono;
                int updatedColor;
                // Calculate the mono and colour print count for the next billing period depending on MonoPrintCount and Volume Mono. 
                // Making sure that the updated print count is more than Minimum Volume for the billing period.
                LoggingService.WriteLog(LoggingLevel.DEBUG, "product.Model={0},product.MonoPrintCount={1}, product.VolumeMono={2}", product.Model, product.MonoPrintCount, product.VolumeMono);
                LoggingService.WriteLog(LoggingLevel.DEBUG, "product.Model={0},product.ColorPrintCount={1}, product.VolumeColour={2}", product.Model, product.ColorPrintCount, product.VolumeColour);
                updatedMono = contractShiftTimeOffsetValue * product.MonoPrintCount + (product.MonoPrintCount != 0 ? product.VolumeMono : 0);
                updatedColor = contractShiftTimeOffsetValue * product.ColorPrintCount + (product.ColorPrintCount != 0 ? product.VolumeColour : 0);
                LoggingService.WriteLog(LoggingLevel.DEBUG, "updatedMono={0},updatedColor={1}", updatedMono, updatedColor);

                string deviceId = product.DeviceId;
                _deviceSimulatorService.SetPrintCounts(deviceId, updatedMono, updatedColor);
                _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
                // Calculate the Overusage for mono and colour for each printer to verify it in the Invoice PDF.
                // Subtract the previous Billing period's print count and Minimum volume for the current billing period from the latest/updated print counts. 
                var divorce = Math.Min(DateTime.Today.Day / 30,1.0);
                var divorceVolumeMono = (int)( product.VolumeMono * divorce);
                var divorceVolumeColour =(int)( product.VolumeColour * divorce);
                LoggingService.WriteLog(LoggingLevel.DEBUG, "divorce={0} mono={1} colour={2}", divorce,divorceVolumeMono,divorceVolumeColour);
                product.monoOverusage = updatedMono - product.MonoPrintCount - contractShiftTimeOffsetValue * divorceVolumeMono;
                product.colorOverusage = updatedColor - product.ColorPrintCount - contractShiftTimeOffsetValue * divorceVolumeColour;
                LoggingService.WriteLog(LoggingLevel.DEBUG, "product.monoOverusage={0}, product.colorOverusage={1}", product.monoOverusage, product.colorOverusage);
                // Update the product's print counts with the latest print count values
                product.MonoPrintCount = updatedMono;
                product.ColorPrintCount = updatedColor;
            }
            //The Print Counts are not updated on the MPS portal if implicit wait is not applied as the system processing is slow.
            _webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(3));
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.ProposalId);
            // Finally, run the contract shift API to generate Billing Invoices upto 3 Billing Periods 
            //_contractShiftService.ContractTimeShiftCommand(_contextData.ProposalId, contractShiftTimeOffsetValue, "m", false, true, "Any");

        }

    }
}
