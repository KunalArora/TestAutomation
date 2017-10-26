using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Domain.Constants;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.MPS.Tests.Specs.MPS2.Proposal
{
    [Binding]
    public class MpsDealerProposalSteps
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
        private readonly MpsDealerProposalStepActions _mpsDealerProposalStepActions;

        //page objects used by these steps
        private DealerDashBoardPage _dealerDashboardPage;
        private DealerProposalsCreateDescriptionPage _dealerProposalsCreateDescriptionPage;
        private DealerProposalsCreateCustomerInformationPage _dealerProposalsCreateCustomerInformationPage;
        private DealerProposalsCreateTermAndTypePage _dealerProposalsCreateTermAndTypePage;
        private DealerProposalsCreateProductsPage _dealerProposalsCreateProductsPage;
        private DealerProposalsCreateClickPricePage _dealerProposalsCreateClickPricePage;
        private DealerProposalsCreateSummaryPage _dealerProposalsCreateSummaryPage;

        public MpsDealerProposalSteps(MpsSignInStepActions mpsSignInStepActions,
            MpsDealerProposalStepActions mpsDealerProposalStepActions,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
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
            _mpsDealerProposalStepActions = mpsDealerProposalStepActions;
        }

        [Given(@"I have navigated to the Create Proposal page as a ""(.*)"" from ""(.*)""")]
        public void GivenIHaveNavigatedToTheCreateProposalPageAsRoleFromCountry(string role, string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);

            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerProposalsCreateDescriptionPage = _mpsDealerProposalStepActions.NavigateToCreateProposalPage(_dealerDashboardPage);
        }

        [When(@"I create a ""(.*)"" proposal")]
        public void WhenICreateAProposalOfContractType(string contractType)
        {
            //if only one contract type is available for the country, the contract type dropdown does not appear.
            //handle this logic
            _translationService.GetContractTypeText(TranslationKeys.ContractType.PurchaseAndClick, _contextData.Culture);
        }

        [When(@"I enter the proposal description")]
        public void WhenIEnterTheProposalDescription()
        {
            //_dealerAgreementCreateTermAndTypePage = _mpsAgreement.PopulateAgreementDescriptionAndProceed(_dealerAgreementCreateDescriptionPage, _proposalHelper.GenerateProposalName(), "", "", "");
        }

        [When(@"I create a new customer for the proposal")]
        public void WhenICreateANewCustomerForTheProposal()
        {
            //_mpsDealerProposalStepActions.CreateCustomerForProposal()
        }

        [When(@"I skip customer creation for the proposal")]
        public void WhenISkipCustomerCreationForTheProposal()
        {
            //_mpsDealerProposalStepActions.SkipCustomerCreationForProposal()
        }

        [When(@"I select ""(.*)"" as the Usage Type and I select ""(.*)"" as the Contract Term")]
        public void WhenISelectTheUsageTypeAndContractTerm(string usageType, string contractTerm)
        {
            //_dealerAgreementCreateProductsPage = _mpsAgreement.PopulateAgreementTermAndTypeAndProceed(_dealerAgreementCreateTermAndTypePage, usageType, contractTerm, "");
        }

        [When(@"I add these printers:")]
        public void WhenIAddThesePrinters(Table printers)
        {
            //create strongly-typed set using CreateSet<PrinterProperties>() method - the PrinterProperties class will need additional properties to match the SpecFlow table
            //step action should add the printers to context data
        }

        [When(@"I calculate the click price for each of the above printers")]
        public void WhenIPopulateTheClickPriceForEachOfTheSpecifiedPrinters()
        {
            //step action should use printers specified in previous step and stored in context data
        }

        [When(@"I save the above proposal and submit it for approval")]
        public void WhenISaveTheAboveProposalAndSubmitItForApproval()
        {
            //wraps up several actions - view summary, save proposal, navigate to open proposals, submit for approval
            //_contextData.ProposalId can be be populated on the summary page - use attribute data-mps-qa-id of 
            //IWebElement property SummaryPageContractIdElement
        }

        [When(@"I add a printer to the proposal")]
        public void WhenIAddAPrinterToTheProposal()
        {
            //TODO: if a printer is not specified, select a random one

            string installationPack = _translationService.GetInstallationPackText("DEALER_INSTALLATION_TYPE3", _contextData.Culture);
            string servicePack = _translationService.GetServicePackText("SERVICE_PACK_TYPE3", _contextData.Culture);

            //_dealerAgreementCreateClickPricePage = _mpsAgreement.AddPrinterToAgreementAndProceed(_dealerAgreementCreateProductsPage, _proposalHelper.SelectPrinter(), 2, installationPack, servicePack);

        }

        [When(@"I enter coverage and volume values on the click price calculation page")]
        public void WhenIEnterCoverageAndVolume()
        {
            //_dealerAgreementCreateSummaryPage = _mpsAgreement.PopulateCoverageAndVolumeAndProceed(_dealerAgreementCreateClickPricePage);
        }
    }
}
