using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Constants;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
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
        private CloudExistingProposalPage _cloudExistingProposalPage;
        private DealerProposalsApprovedPage _dealerProposalsApprovedPage;
        private DealerProposalsSummaryPage _dealerProposalsSummaryPage;
        private SummaryValue _proposalSummaryValues;

        // other
        private string _pdfFile;

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

        [Given(@"I have navigated to the Open Proposals page as a ""(.*)"" from ""(.*)""")]
        public void GivenIHaveNavigatedToTheOpenProposalsPageAsAFrom(string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
        }

        [Given(@"I have navigated to the Create Proposal page as a Cloud MPS Dealer from ""(.*)""")]
        public void GivenIHaveNavigatedToTheCreateProposalPageAsACloudMPSDealerFrom(string country)
        {
            GivenIHaveNavigatedToTheOpenProposalsPageAsAFrom(country);
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
            string proposalName = _proposalHelper.GenerateProposalName();
            _contextData.ProposalName = proposalName;
            _dealerProposalsCreateCustomerInformationPage = _mpsDealerProposalStepActions.PopulateProposalDescriptionAndProceed(_dealerProposalsCreateDescriptionPage, proposalName, "", "");
        }

        [When(@"I create a new customer for the proposal")]
        public void WhenICreateANewCustomerForTheProposal()
        {
            _dealerProposalsCreateTermAndTypePage = _mpsDealerProposalStepActions.CreateCustomerForProposal(_dealerProposalsCreateCustomerInformationPage);
        }

        [When(@"I skip customer creation for the proposal")]
        public void WhenISkipCustomerCreationForTheProposal()
        {
            _dealerProposalsCreateTermAndTypePage = _mpsDealerProposalStepActions.SkipCustomerCreationForProposal(_dealerProposalsCreateCustomerInformationPage);
        }

        [When(@"I select Usage Type of ""(.*)"", Contract Term of ""(.*)"", Billing Type of ""(.*)"" and Service Pack type of ""(.*)""")]
        public void WhenISelectUsageTypeOfContractTermOfBillingTypeOfAndServicePackTypeOf(string usageType, string contractTerm, string billingType, string servicePackType)
        {
            _contextData.UsageType = usageType;
            _contextData.ContractTerm = contractTerm;
            _contextData.BillingType = billingType;
            _contextData.ServicePackType = servicePackType;
          
            _dealerProposalsCreateProductsPage = _mpsDealerProposalStepActions.PopulateProposalTermAndTypeAndProceed(_dealerProposalsCreateTermAndTypePage, usageType, contractTerm, billingType, servicePackType);
        }

        [When(@"I add these printers:")]
        public void WhenIAddThesePrinters(Table printers)
        {
            //create strongly-typed set using CreateSet<PrinterProperties>() method - the PrinterProperties class will need additional properties to match the SpecFlow table
            //step action should add the printers to context data
            var products = printers.CreateSet<PrinterProperties>();
            _contextData.PrintersProperties = products; 
            _dealerProposalsCreateClickPricePage = _mpsDealerProposalStepActions.AddPrinterToProposalAndProceed(_dealerProposalsCreateProductsPage, products);               
        }

        [When(@"I calculate the click price for each of the above printers")]
        public void WhenIPopulateTheClickPriceForEachOfTheSpecifiedPrinters()
        {
            //step action should use printers specified in previous step and stored in context data
            _dealerProposalsCreateSummaryPage = _mpsDealerProposalStepActions.CalculateClickPriceAndProceed(_dealerProposalsCreateClickPricePage, _contextData.PrintersProperties);          
        }

        [When(@"I save the proposal")]
        public void WhenISaveTheProposal()
        {
            _cloudExistingProposalPage = _mpsDealerProposalStepActions.SaveTheProposalAndProceed(_dealerProposalsCreateSummaryPage);
        }

        [Then(@"I can see the proposal created above in the open proposals list")]
        public void ThenICanSeeTheProposalCreatedAboveInTheOpenProposalsList()
        {
            _mpsDealerProposalStepActions.VerifySavedProposalInOpenProposalsList(_cloudExistingProposalPage, _contextData.ProposalId, _contextData.ProposalName);
        }

        [When(@"I save the above proposal and submit it for approval")]
        public void WhenISaveTheAboveProposalAndSubmitItForApproval()
        {
            //wraps up several actions - view summary, save proposal, navigate to open proposals, submit for approval
            //_contextData.ProposalId can be be populated on the summary page - use attribute data-mps-qa-id of 
            //IWebElement property SummaryPageContractIdElement
            
            //Refactor
            var cloudExistingProposalPage = _mpsDealerProposalStepActions.SaveTheProposalAndProceed(_dealerProposalsCreateSummaryPage);
            _mpsDealerProposalStepActions.VerifySavedProposalInOpenProposalsList(cloudExistingProposalPage, _contextData.ProposalId, _contextData.ProposalName);
            var dealerProposalsConvertCustomerInformationPage = _mpsDealerProposalStepActions.SubmitForApproval(cloudExistingProposalPage, _contextData.ProposalId, _contextData.ProposalName);
            var dealerProposalsConvertTermAndTypePage = _mpsDealerProposalStepActions.SetForApprovalInformationAndProceed(dealerProposalsConvertCustomerInformationPage, _contextData.Country);
            var dealerProposalsConvertProductsPage = _mpsDealerProposalStepActions.ClickNext(dealerProposalsConvertTermAndTypePage);
            var dealerProposalsConvertClickPricePage = _mpsDealerProposalStepActions.ClickNext(dealerProposalsConvertProductsPage);
            DealerProposalsConvertSummaryPage _dealerProposalsConvertSummaryPage = _mpsDealerProposalStepActions.SetInformationAndClickSubmitForApproval(dealerProposalsConvertClickPricePage);
            _mpsDealerProposalStepActions.SubmitForApproval(_dealerProposalsConvertSummaryPage);
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

        [When(@"I locate the proposal with id ""(.*)"" and submit it for approval")]
        public void WhenILocateTheProposalWithIdAndSubmitItForApproval(int id)
        {
            _contextData.ProposalId = id;
            var dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dealerProposalsInprogressPage = _mpsDealerProposalStepActions.NavigateToDealerProposalsInprogressPage(dealerDashboardPage);
            var dealerProposalsConvertCustomerInformationPage = _mpsDealerProposalStepActions.SubmitForApproval(dealerProposalsInprogressPage);
            var dealerProposalsConvertTermAndTypePage = _mpsDealerProposalStepActions.CreateCustomerForProposal(dealerProposalsConvertCustomerInformationPage);
            var dealerProposalsConvertProductsPage = _mpsDealerProposalStepActions.ClickNext(dealerProposalsConvertTermAndTypePage);
            var dealerProposalsConvertClickPricePage = _mpsDealerProposalStepActions.ClickNext(dealerProposalsConvertProductsPage);
            var dealerProposalsConvertSummaryPage = _mpsDealerProposalStepActions.SetInformationAndClickSubmitForApproval(dealerProposalsConvertClickPricePage);
            _mpsDealerProposalStepActions.SubmitForApproval(dealerProposalsConvertSummaryPage);
        }

        [Given(@"I have navigated to the Approved Proposals page as a ""(.*)"" from ""(.*)""")]
        public void GivenIHaveNavigatedToTheApprovedProposalsPageAsAFrom(string role, string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            switch (role)
            {
                case "Cloud MPS Dealer":
                    _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;
            }
            _dealerProposalsApprovedPage = _mpsDealerProposalStepActions.NavigateToDealerProposalsApprovedPage(_dealerDashboardPage);
        }

        [Given(@"I navigate to the Proposal summary page for proposal id ""(.*)""")]
        public void GivenINavigateToTheProposalSummaryPageForProposalId(string proposalId)
        {
            _dealerProposalsSummaryPage = _mpsDealerProposalStepActions.ClickOnViewSummary(_dealerProposalsApprovedPage, proposalId);
            _proposalSummaryValues = SummaryValue.Parse(_dealerProposalsSummaryPage);

        }

        [When(@"I click the download proposal button")]
        public void WhenIClickTheDownloadProposalButton()
        {
            _pdfFile = _mpsDealerProposalStepActions.DownloadPdf(_dealerProposalsSummaryPage);
        }

        [Then(@"I should be able to open the PDF")]
        public void ThenIShouldBeAbleToOpenThePDF()
        {
            try {
                _mpsDealerProposalStepActions.AssertAreEqualSummaryValues(_pdfFile, _contextData.Country, _proposalSummaryValues);
            }
            finally
            {
                _mpsDealerProposalStepActions.DeletePdfFileErrorIgnored(_pdfFile);
            }
            
        }

    }
}
