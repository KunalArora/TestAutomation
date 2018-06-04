using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Agreement;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Contract;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPSTwo.Contract
{
    [Binding]
    public class LocalOfficeAdminSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly ITranslationService _translationService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly IProposalHelper _proposalHelper;
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private readonly ILoggingService _loggingService;
        private readonly MpsLocalOfficeAdminContractStepActions _mpsLocalOfficeAdminContractStepActions;
        private readonly MpsLocalOfficeAdminAgreementStepActions _mpsLocalOfficeAdminAgreementStepActions;
        private LocalOfficeAdminReportsProposalSummaryPage _localOfficeAdminReportsProposalSummaryPage;

        public LocalOfficeAdminSteps(
            IPageParseHelper pageParseHelper,
            MpsSignInStepActions mpsSignInStepActions,
            MpsLocalOfficeAdminContractStepActions mpsLocalOfficeAdminContractStepActions,
            MpsLocalOfficeAdminAgreementStepActions mpsLocalOfficeAdminAgreementStepActions,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ILoggingService loggingService,
            ICountryService countryService,
            ITranslationService translationService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            IProposalHelper proposalHelper)
        {
            _context = context;
            _driver = driver;
            _contextData = contextData;
            _pageService = pageService;
            _countryService = countryService;
            _translationService = translationService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _proposalHelper = proposalHelper;
            _mpsSignInStepActions = mpsSignInStepActions;
            _loggingService = loggingService;
            _mpsLocalOfficeAdminContractStepActions = mpsLocalOfficeAdminContractStepActions;
            _mpsLocalOfficeAdminAgreementStepActions = mpsLocalOfficeAdminAgreementStepActions;

        }

        [StepDefinition(@"a Cloud MPS Local Office Admin navigates to the contract end screen")]
        public void GivenACloudMPSLocalOfficeAdminNavigatesToTheContractEndScreen()
        {
            var localOfficeAdminDashboardPage = _mpsSignInStepActions.SignInAsLocalOfficeAdmin(
                _userResolver.LocalOfficeAdminUsername, _userResolver.LocalOfficeAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            
            localOfficeAdminDashboardPage = _mpsLocalOfficeAdminAgreementStepActions.SelectLanguageGivenCulture(localOfficeAdminDashboardPage);
            
            var dataQueryPage = _mpsLocalOfficeAdminAgreementStepActions.NavigateToReportsDataQuery(localOfficeAdminDashboardPage);
            _localOfficeAdminReportsProposalSummaryPage = _mpsLocalOfficeAdminContractStepActions.NavigateToContractSummaryPage(dataQueryPage, _contextData.ProposalId);
        }

        [StepDefinition(@"a Cloud MPS Local Office Admin sets the cancellation date and reason and cancels the contract")]
        public void WhenACloudMPSLocalOfficeAdminSetsTheCancellationDateAndReasonAndCancelsTheContract()
        {
            var localOfficeAdminContractsEditEndDatePage = _mpsLocalOfficeAdminContractStepActions.ClickOnCancelContract(_localOfficeAdminReportsProposalSummaryPage);
            _localOfficeAdminReportsProposalSummaryPage = _mpsLocalOfficeAdminContractStepActions.EnterContractCancellationDetailsAndSave(localOfficeAdminContractsEditEndDatePage, _contextData.BillingType);
        }

        [StepDefinition(@"a Cloud MPS Local Office Admin set the New additional charges , Charge Type of ""(.*)"", Cost Price of ""(.*)"", and Margin Percent of ""(.*)"" and save")]
        public void WhenACloudMPSLocalOfficeAdminSetTheNewAdditionalChargesChargeTypeOfCostPriceOfAndMarginPercentOfAndSave(LocalOfficeAdminContractsAdditionalCharges.ChargeTypeSelectorElementValue chargeType, double costPrice, double marginPercent)
        {
            var localOfficeAdminContractsAdditionalCharges =  _mpsLocalOfficeAdminContractStepActions.ClickOnAdditionalCharges(_localOfficeAdminReportsProposalSummaryPage);
            _mpsLocalOfficeAdminContractStepActions.AddAdditionalCharges(localOfficeAdminContractsAdditionalCharges, chargeType, costPrice, marginPercent);
            _localOfficeAdminReportsProposalSummaryPage = _mpsLocalOfficeAdminContractStepActions.ClickOnBack(localOfficeAdminContractsAdditionalCharges);
        }


        [StepDefinition(@"a Cloud MPS Local Office Admin can validate the final bill")]
        public void ThenACloudMPSLocalOfficeAdminCanValidateTheFinalBill()
        {
            DateTime startDate;
            var pdfFinalInvoice = _mpsLocalOfficeAdminContractStepActions.ApplyOverUsageAndContractShiftAndDownload(out startDate);
            _mpsLocalOfficeAdminContractStepActions.AssertAreEquealsAdditionalCharges(pdfFinalInvoice, _contextData.SnapValues[typeof(LocalOfficeAdminContractsEditEndDatePage)] as LocalOfficeAdminContractsEditEndDatePageValue);
            _mpsLocalOfficeAdminContractStepActions.AssertAreEqualOverusageValues(pdfFinalInvoice, startDate);

            var localOfficeAdminDashboardPage = _mpsSignInStepActions.SignInAsLocalOfficeAdmin(
                _userResolver.LocalOfficeAdminUsername, _userResolver.LocalOfficeAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dataQueryPage = _mpsLocalOfficeAdminAgreementStepActions.NavigateToReportsDataQuery(localOfficeAdminDashboardPage);
            _mpsLocalOfficeAdminContractStepActions.AssertTheContractStatusIsClosed(dataQueryPage);
        }

        [StepDefinition(@"a Local Office Admin assert the final bill is generated/present")]
        public void ThenALocalOfficeAdminAssertTheFinalBillIsGeneratedPresent()
        {
            DateTime startDate;
            var pdfFinalInvoice = _mpsLocalOfficeAdminContractStepActions.ApplyOverUsageAndContractShiftAndDownload(out startDate);
        }

        [Then(@"a Cloud MPS Local office Admin edit the proposal notes and click save")]
        public void ThenACloudMPSLocalOfficeAdminEditTheProposalNotesAndClickSave()
        {
            _localOfficeAdminReportsProposalSummaryPage = _mpsLocalOfficeAdminContractStepActions.EditProposalNotes(_localOfficeAdminReportsProposalSummaryPage);
            _mpsLocalOfficeAdminContractStepActions.VerifyProposalNotes(_localOfficeAdminReportsProposalSummaryPage);
        }
    }
}
