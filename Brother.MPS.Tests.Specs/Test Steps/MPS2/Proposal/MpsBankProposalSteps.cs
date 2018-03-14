using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Contract;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Proposal
{
    [Binding]
    public class MpsBankProposalSteps
    {
        private readonly ScenarioContext _context;
        private readonly MpsContextData _contextData;
        private readonly ICountryService _countryService;
        private readonly IWebDriver _driver;
        private readonly MpsBankProposalStepActions _mpsBankProposalStepActions;
        private readonly MpsBankContractStepActions _mpsBankContractStepActions;
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private readonly PageService _pageService;
        private readonly ITranslationService _translationService;
        private readonly IUrlResolver _urlResolver;
        private readonly IUserResolver _userResolver;

        private BankProposalsApprovedPage _bankProposalsApprovedPage;
        private BankContractsAcceptedPage _bankContractsAcceptedPage;
        private BankContractsAwaitingAcceptancePage _bankContractsAwaitingAcceptancePage;

        public MpsBankProposalSteps(
            MpsBankContractStepActions mpsBankContractStepActions,
            MpsBankProposalStepActions mpsBankProposalStepActions,
            MpsSignInStepActions mpsSignInStepActions,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            ITranslationService translationService
            )
        {
            _context = context;
            _driver = driver;
            _contextData = contextData;
            _pageService = pageService;
            _countryService = countryService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignInStepActions = mpsSignInStepActions;
            _translationService = translationService;
            _mpsBankProposalStepActions = mpsBankProposalStepActions;
            _mpsBankContractStepActions = mpsBankContractStepActions;
        }
        [When(@"a Cloud MPS Bank release the above proposal")]
        public void WhenACloudMPSBankReleaseTheAboveProposal()
        {
            var bankDashBoardPage = _mpsSignInStepActions.SignInAsBank(_userResolver.BankUsername, _userResolver.BankPassword,string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var bankProposalsAwaitingApprovalPage = _mpsBankProposalStepActions.NavigateToProposalsAwaitingApprovalPage(bankDashBoardPage);
            var bankProposalsSummaryPage = _mpsBankProposalStepActions.ClickViewSummary(bankProposalsAwaitingApprovalPage);
            _mpsBankProposalStepActions.AssertAreEqualBankSummary(bankProposalsSummaryPage);
            _bankProposalsApprovedPage = _mpsBankProposalStepActions.ClickOnAccept(bankProposalsSummaryPage);
        }

        [When(@"a Cloud MPS Bank Cloud MPS Bank Summary Accept")]
        public void WhenACloudMPSBankCloudMPSBankSummaryAccept()
        {
            // Login as Bank and go to “Signature Expected” tab and search for the created agreement and click Summary option 
            var bankDashBoardPage = _mpsSignInStepActions.SignInAsBank(_userResolver.BankUsername, _userResolver.BankPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var bankContractsApprovedProposalsPage = _mpsBankContractStepActions.NavigateToContractsApprovedProposalsPage(bankDashBoardPage);
            var bankContractsAwaitingAcceptancePage = _mpsBankContractStepActions.NavigateToContractsAwaitingAcceptancePage(bankContractsApprovedProposalsPage);
            // On the summary page Click “Accept” button  and then again click “accept “ Button
            var bankContractsSummaryPage = _mpsBankContractStepActions.ClickOnViewSummary(bankContractsAwaitingAcceptancePage);
            _bankContractsAcceptedPage = _mpsBankContractStepActions.ClickOnAccept(bankContractsSummaryPage);
        }

        [When(@"a Cloud MPS Bank Populated Maintain Contact")]
        public void WhenACloudMPSBankPopulatedMaintainContact()
        {
            // Go to “Signed “ tab and search for the contract and Click “Action” button and select “Contract Edit” menu
            // On  “Maintain Contact Page”
            var bankContractsMaintenancePage = _mpsBankContractStepActions.ClickOnContractEdit(_bankContractsAcceptedPage);
            // Accept the Prepopulate start date , enter reference data and click all check boxes
            _bankContractsAwaitingAcceptancePage = _mpsBankContractStepActions.CheckAllBoxesAndSave(bankContractsMaintenancePage);
        }

        [When(@"a Cloud MPS Bank Checking the billing to ensure details are correctly populated")]
        public void WhenACloudMPSBankCheckingTheBillingToEnsureDetailsAreCorrectlyPopulated()
        {
            // using Flux capacitor Move the contract back by 3 months
            _mpsBankContractStepActions.ContractTimeShift(3);
            // Checking the billing to ensure details are correctly populated
            _mpsBankContractStepActions.CheckTheBillingToEnsureDetailsAreCorrectlyPopulated();
            
        }

    }
}
