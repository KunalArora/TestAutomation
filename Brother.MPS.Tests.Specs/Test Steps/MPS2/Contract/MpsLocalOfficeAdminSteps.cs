using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
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
        private LocalOfficeAdminDashBoardPage _localOfficeAdminDashboardPage;
        private LocalOfficeAdminAdministrationDashboardPage _localOfficeAdminAdministrationDashboardPage;
        private LocalOfficeAdminAdministrationDealerPage _localOfficeAdminAdministrationDealerPage;
        private LocalOfficeAdminDealersCreateDealershipPage _localOfficeAdminDealersCreateDealershipPage;
        private LocalOfficeAdminDealersEditDealershipPage _localOfficeAdminDealersEditDealershipPage;

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

        [Given(@"I navigate to the administration page with culture ""(.*)"" from ""(.*)""")]
        public void GivenINavigateToTheAdministrationPageWithCultureFrom(string culture, string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            if (_contextData.Country.Cultures.Contains(culture) == false && culture != string.Empty)
            {
                throw new ArgumentException("Does not support this culture for this country.Please check arguments provided from feature file. country=" + country + " culture=" + culture);
            }
            _contextData.Culture = culture != string.Empty ? culture : _contextData.Country.Cultures[0];
            _mpsSignInStepActions.SetCultureInfoAndRegionInfo();
            _localOfficeAdminDashboardPage = _mpsSignInStepActions.SignInAsLocalOfficeAdmin(
                _userResolver.LocalOfficeAdminUsername, _userResolver.LocalOfficeAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _localOfficeAdminDashboardPage = _mpsLocalOfficeAdminAgreementStepActions.SelectLanguageGivenCulture(_localOfficeAdminDashboardPage);
            _localOfficeAdminAdministrationDashboardPage = _mpsLocalOfficeAdminAgreementStepActions.NavigateToAdministrationPage(_localOfficeAdminDashboardPage);
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
            _mpsLocalOfficeAdminContractStepActions.AssertAreEqualAdditionalCharges(pdfFinalInvoice, _contextData.SnapValues[typeof(LocalOfficeAdminContractsEditEndDatePage)] as LocalOfficeAdminContractsEditEndDatePageValue);
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

        [When(@"I create a new dealer with ""(.*)"" and verify the created dealer details")]
        public void WhenICreateANewDealerWithAndVerifyTheCreatedDealerDetails(int sapVendorId)
        {
            _localOfficeAdminAdministrationDealerPage = _mpsLocalOfficeAdminAgreementStepActions.NavigateToAdministrationDealerPage(_localOfficeAdminAdministrationDashboardPage);
            _localOfficeAdminDealersCreateDealershipPage = _mpsLocalOfficeAdminAgreementStepActions.ClickOnAddDealerButton(_localOfficeAdminAdministrationDealerPage);
            if (_contextData.Country.CountryIso == CountryIso.UnitedKingdom)
            {
                _localOfficeAdminDealersCreateDealershipPage = _mpsLocalOfficeAdminAgreementStepActions.EnterSapVendorNumber(_localOfficeAdminDealersCreateDealershipPage, sapVendorId);
            }
            _mpsLocalOfficeAdminAgreementStepActions.SelectBusinessType(_localOfficeAdminDealersCreateDealershipPage);
            _localOfficeAdminAdministrationDealerPage = _mpsLocalOfficeAdminAgreementStepActions.IputDealerDetails(_localOfficeAdminDealersCreateDealershipPage);
            _mpsLocalOfficeAdminAgreementStepActions.VerifyDealerCreation(_localOfficeAdminAdministrationDealerPage);
        }

        [When(@"I edit the details for created dealer")]
        public void WhenIEditTheDetailsForCreatedDealer()
        {
            _localOfficeAdminDealersEditDealershipPage = _mpsLocalOfficeAdminAgreementStepActions.NavigateToEditDealershipPage(_localOfficeAdminAdministrationDealerPage);
            _localOfficeAdminAdministrationDealerPage = _mpsLocalOfficeAdminAgreementStepActions.EditDealerDetails(_localOfficeAdminDealersEditDealershipPage);
            _mpsLocalOfficeAdminAgreementStepActions.VerifyUpdatedDealerDeatils(_localOfficeAdminAdministrationDealerPage);
        }

        [Then(@"I delete the created MPS dealer")]
        public void ThenIDeleteTheCreatedMPSDealer()
        {
            _mpsLocalOfficeAdminAgreementStepActions.DeleteCreatedDealer();
        }        
    }
}
