using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Globalization;
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
        private readonly ILoggingService _loggingService;
        private readonly ICalculationService _calculationService;
        private readonly IPageParseHelper _pageParseHelper;

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
        private SummaryPageValue _proposalSummaryValues;
        private DealerCustomersManagePage _dealerCustomersManagePage;
        private DealerCustomersExistingPage _dealerCustomersExistingPage;
        private DealerProposalsAwaitingApprovalPage _dealerProposalsAwaitingApprovalPage;
        private DealerProposalsDeclinedPage _dealerProposalsDeclinedPage;
        private DealerDashBoardPage _subDealerDashboardPage;

        // other
        private string _pdfFile;

        public MpsDealerProposalSteps(
            IPageParseHelper pageParseHelper,
            MpsSignInStepActions mpsSignInStepActions,
            MpsDealerProposalStepActions mpsDealerProposalStepActions,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ILoggingService loggingService,
            ICountryService countryService,
            ITranslationService translationService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            ICalculationService calculationService,
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
            _loggingService = loggingService;
            _calculationService = calculationService;
            _pageParseHelper = pageParseHelper;
        }

        [Given(@"I have navigated to the Create Customer page as a Cloud MPS Dealer from ""(.*)""")]
        public void GivenIHaveNavigatedToTheCreateCustomerPageAsACloudMPSDealerFrom(string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerCustomersExistingPage = _mpsDealerProposalStepActions.NavigateToCustomersExistingPage(_dealerDashboardPage);
        }


        [StepDefinition(@"I have navigated to the Open Proposals page as a ""(.*)"" from ""(.*)""")]
        public void GivenIHaveNavigatedToTheOpenProposalsPageAsAFrom(string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            if(_contextData.Country.Cultures.Count != 1)
            {
                throw new ArgumentException("can not auto select culture. please call alternate some garkin");
            }
            _contextData.Culture = _contextData.Country.Cultures[0];
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));

        }

        [Given(@"I have navigated to the Create Proposal page as a Cloud MPS Dealer with culture ""(.*)"" from ""(.*)""")]
        public void GivenIHaveNavigatedToTheCreateProposalPageAsACloudMPSDealerWithCultureFrom(string culture, string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            if (_contextData.Country.Cultures.Contains(culture) == false && culture != string.Empty)
            {
                throw new ArgumentException("can not support culture in select this country. please check arguments. country=" + country + " culture=" + culture);
            }
            _contextData.Culture = culture != string.Empty ? culture : _contextData.Country.Cultures[0];
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerProposalsCreateDescriptionPage = _mpsDealerProposalStepActions.NavigateToCreateProposalPage(_dealerDashboardPage);
        }

        [When(@"I have navigated to the Create Proposal page")]
        public void WhenIHaveNavigatedToTheCreateProposalPage()
        {
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerProposalsCreateDescriptionPage = _mpsDealerProposalStepActions.NavigateToCreateProposalPage(_dealerDashboardPage);
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
            _contextData.ContractType = _translationService.GetContractTypeText(contractType, _contextData.Culture);
        }
        
        [When(@"I enter the proposal description")]
        public void WhenIEnterTheProposalDescription()
        {
            string proposalName = _proposalHelper.GenerateProposalName();
            _contextData.ProposalName = proposalName;
            if(_contextData.Country.LogicSettings.IsNextDealerProposalsCreateTermAndTypePage)
            {
                _dealerProposalsCreateTermAndTypePage = _mpsDealerProposalStepActions.PopulateProposalDescriptionAndProceed<DealerProposalsCreateTermAndTypePage>(_dealerProposalsCreateDescriptionPage, proposalName, "", _contextData.ContractType);
            }
            else
            {
                _dealerProposalsCreateCustomerInformationPage = _mpsDealerProposalStepActions.PopulateProposalDescriptionAndProceed<DealerProposalsCreateCustomerInformationPage>(_dealerProposalsCreateDescriptionPage, proposalName, "", "");
            }
        }

        [When(@"I create a new customer for the proposal")]
        public void WhenICreateANewCustomerForTheProposal()
        {
            _dealerProposalsCreateTermAndTypePage = _mpsDealerProposalStepActions.CreateCustomerForProposal(_dealerProposalsCreateCustomerInformationPage);
        }

        [When(@"a Sub dealer create a new customer for the proposal")]
        public void WhenASubDealerCreateANewCustomerForTheProposal()
        {
            _dealerProposalsCreateTermAndTypePage = _mpsDealerProposalStepActions.CreateCustomerForProposal(_dealerProposalsCreateCustomerInformationPage);
        }


        [When(@"I select an existing customer for the proposal")]
        public void WhenISelectAnExistingCustomerForTheProposal()
        {
            _dealerProposalsCreateTermAndTypePage = _mpsDealerProposalStepActions.SelectExistingCustomerForProposal(_dealerProposalsCreateCustomerInformationPage);
        }


        [When(@"I create a new customer by clicking on Create Customer button")]
        public void WhenICreateANewCustomerByClickingOnCreateCustomerButton()
        {
            string payment = _translationService.GetPaymentTypeText(TranslationKeys.PaymentType.Invoice, _contextData.Culture);
            _dealerCustomersManagePage = _mpsDealerProposalStepActions.NavigateToCustomersManagePage(_dealerCustomersExistingPage);
            _mpsDealerProposalStepActions.CreateAndSaveANewCustomer(_dealerCustomersManagePage, _contextData.Country, payment);
            _mpsDealerProposalStepActions.ThenICanSeeTheCustomerCreatedAboveInTheCustomersContactsList(_dealerCustomersExistingPage, _contextData.CustomerInformationName, _contextData.CustomerEmail);
        }

        [When(@"I skip customer creation for the proposal")]
        public void WhenISkipCustomerCreationForTheProposal()
        {
            _dealerProposalsCreateTermAndTypePage = _mpsDealerProposalStepActions.SkipCustomerCreationForProposal(_dealerProposalsCreateCustomerInformationPage);
        }

        [When(@"I select Usage Type of ""(.*)"", Contract Term of ""(.*)"", Billing Type of ""(.*)"" and Service Pack type of ""(.*)""")]
        public void WhenISelectUsageTypeOfContractTermOfBillingTypeOfAndServicePackTypeOf(string usageType, string contractTerm, string billingType, string servicePackType)
        {
            WhenISelectUsageTypeOfContractTermOfBillingTypeOfAndServicePackTypeOf(usageType, contractTerm, billingType, servicePackType, "");
        }

        [When(@"a Sub dealer select Usage Type of ""(.*)"", Contract Term of ""(.*)"", Billing Type of ""(.*)"" and Service Pack type of ""(.*)""")]
        public void WhenASubDealerSelectUsageTypeOfContractTermOfBillingTypeOfAndServicePackTypeOf(string usageType, string contractTerm, string billingType, string servicePackType)
        {
            WhenISelectUsageTypeOfContractTermOfBillingTypeOfAndServicePackTypeOf(usageType, contractTerm, billingType, servicePackType, "");
        }

        [When(@"I select Usage Type of ""(.*)"", Contract Term of ""(.*)"", Billing Type of ""(.*)"", Service Pack type of ""(.*)"" and Leasing Billing Cycle of ""(.*)""")]
        public void WhenISelectUsageTypeOfContractTermOfBillingTypeOfAndServicePackTypeOf(string usageType, string contractTerm, string billingType, string servicePackType, string leasingBillingCycle)
        {
            string usage_type = _translationService.GetUsageTypeText(usageType, _contextData.Culture);
            string contract_term = _translationService.GetContractTermText(contractTerm, _contextData.Culture);
            string billing_type = _translationService.GetBillingTypeText(billingType, _contextData.Culture);
            string service_pack = _translationService.GetServicePackTypeText(servicePackType, _contextData.Culture);
            string leasing_billing_cycle = _translationService.GetLeasingBillingCycle(leasingBillingCycle, _contextData.Culture);
            _contextData.UsageType = usage_type;
            _contextData.ContractTerm = contract_term;
            _contextData.BillingType = billing_type;
            _contextData.ServicePackType = service_pack;
            _contextData.LeasingBillingCycle = leasing_billing_cycle;

            _dealerProposalsCreateProductsPage = _mpsDealerProposalStepActions.PopulateProposalTermAndTypeAndProceed(_dealerProposalsCreateTermAndTypePage, usage_type, contract_term, billing_type, service_pack, leasing_billing_cycle);
        }

        [When(@"I add these printers:")]
        public void WhenIAddThesePrinters(Table printers)
        {
            var products = printers.CreateSet<PrinterProperties>();
            var cultureInfo = new CultureInfo(_contextData.Culture);
            foreach ( var product in products)
            {
                product.Price = _calculationService.ConvertInvariantNumericToCultureNumericString(product.Price);
                product.InstallationPack = _translationService.GetInstallationPackText(product.InstallationPack, _contextData.Culture);
            }
            _contextData.PrintersProperties = products;
            _dealerProposalsCreateClickPricePage = _mpsDealerProposalStepActions.AddPrinterToProposalAndProceed(_dealerProposalsCreateProductsPage);
        }

        [When(@"I add these printers for EPP:")]
        public void WhenIAddThesePrintersForEPP(Table printers)
        {
            var products = printers.CreateSet<PrinterProperties>();
            _contextData.PrintersProperties = products;
            _dealerProposalsCreateClickPricePage = _mpsDealerProposalStepActions.AddPrinterToProposalforEPPAndProceed(_dealerProposalsCreateProductsPage);
        }


        [When(@"I calculate the click price for each of the above printers")]
        public void WhenIPopulateTheClickPriceForEachOfTheSpecifiedPrinters()
        {
            _dealerProposalsCreateSummaryPage = _mpsDealerProposalStepActions.CalculateClickPriceAndProceed(_dealerProposalsCreateClickPricePage);          
        }

        [When(@"I save the proposal")]
        public void WhenISaveTheProposal()
        {
            _cloudExistingProposalPage = _mpsDealerProposalStepActions.SaveTheProposalAndProceed(_dealerProposalsCreateSummaryPage);
        }

        [Then(@"I can see the proposal created above in the open proposals list")]
        public void ThenICanSeeTheProposalCreatedAboveInTheOpenProposalsList()
        {
            _mpsDealerProposalStepActions.VerifySavedProposalInOpenProposalsList(_cloudExistingProposalPage);
        }

        [When(@"I save the above proposal and submit it for approval")]
        public void WhenISaveTheAboveProposalAndSubmitItForApproval()
        {
            WhenISaveTheProposal();
            WhenISubmitItForApproval();
        }

        [When(@"I save the above proposal and submit it for approval with payment type ""(.*)""")]
        public void WhenISaveTheAboveProposalAndSubmitItForApprovalWithTheGivenPaymentType(string paymentType)
        {
            _contextData.PaymentType = paymentType;
            _contextData.SkipBOLRegistration = true;
            WhenISaveTheProposal();
            WhenISubmitItForApproval();
        }

        [When(@"a Sub dealer save the above proposal and submit it for approval")]
        public void WhenASubDealerSaveTheAboveProposalAndSubmitItForApproval()
        {
            WhenISaveTheProposal();
            WhenISubmitItForApproval();
        }


        public void WhenISubmitItForApproval()
        {
            _mpsDealerProposalStepActions.VerifySavedProposalInOpenProposalsList(_cloudExistingProposalPage);
            var dealerProposalsConvertCustomerInformationPage = _mpsDealerProposalStepActions.SubmitForApproval(_cloudExistingProposalPage);
            if(_mpsDealerProposalStepActions.IsCanSelectNewCustomer(dealerProposalsConvertCustomerInformationPage) )
            {
                dealerProposalsConvertCustomerInformationPage = _mpsDealerProposalStepActions.SelectNewCustomerAndNext(dealerProposalsConvertCustomerInformationPage);
            }
            var dealerProposalsConvertTermAndTypePage = _mpsDealerProposalStepActions.SetForApprovalInformationAndProceed(dealerProposalsConvertCustomerInformationPage);
            var dealerProposalsConvertProductsPage = _mpsDealerProposalStepActions.ClickNext(dealerProposalsConvertTermAndTypePage);
            var dealerProposalsConvertClickPricePage = _mpsDealerProposalStepActions.ClickNext(dealerProposalsConvertProductsPage);
            var dealerProposalsConvertSummaryPage = _mpsDealerProposalStepActions.SetInformationAndClickSubmitForApproval(dealerProposalsConvertClickPricePage);
            _dealerProposalsAwaitingApprovalPage = _mpsDealerProposalStepActions.SubmitForApproval(dealerProposalsConvertSummaryPage);
        }

        [When(@"I save the above proposal and submit it for approval for existing customer")]
        public void WhenISaveTheAboveProposalAndSubmitItForApprovalForExistingCustomer()
        {
            WhenISaveTheProposal();
            _mpsDealerProposalStepActions.VerifySavedProposalInOpenProposalsList(_cloudExistingProposalPage);
            var dealerProposalsConvertSummaryPage = _mpsDealerProposalStepActions.SubmitForTheApproval(_cloudExistingProposalPage);
            _dealerProposalsAwaitingApprovalPage = _mpsDealerProposalStepActions.SubmitForApproval(dealerProposalsConvertSummaryPage);
        }

        [When(@"I submit it for approval for existing customer")]
        public void WhenISubmitItForApprovalForExistingCustomer()
        {
            _dealerProposalsCreateDescriptionPage = _mpsDealerProposalStepActions.ClickOnEditActionButton(_cloudExistingProposalPage);
            _dealerProposalsCreateCustomerInformationPage = _mpsDealerProposalStepActions.NavigateToProposalsCustomersPage(_dealerProposalsCreateDescriptionPage);
            _dealerProposalsCreateTermAndTypePage = _mpsDealerProposalStepActions.NavigateToProposalTermAndTypePage(_dealerProposalsCreateCustomerInformationPage);
            _dealerProposalsCreateProductsPage = _mpsDealerProposalStepActions.NavigateToProposalProductsPage(_dealerProposalsCreateTermAndTypePage);
            _dealerProposalsCreateClickPricePage = _mpsDealerProposalStepActions.NavigateToProposalClickPricePage(_dealerProposalsCreateProductsPage);
            _dealerProposalsCreateSummaryPage = _mpsDealerProposalStepActions.NavigateToCreateSummaryPage(_dealerProposalsCreateClickPricePage);
            WhenISaveTheProposal();
            _mpsDealerProposalStepActions.VerifySavedProposalInOpenProposalsList(_cloudExistingProposalPage);
            var dealerProposalsConvertSummaryPage = _mpsDealerProposalStepActions.SubmitForTheApproval(_cloudExistingProposalPage);
            _dealerProposalsAwaitingApprovalPage = _mpsDealerProposalStepActions.SubmitForApproval(dealerProposalsConvertSummaryPage);
        }


        [When(@"I locate the proposal with id ""(.*)"" and submit it for approval")]
        public void WhenILocateTheProposalWithIdAndSubmitItForApproval(int id)
        {
            _contextData.ProposalId = id;
            var dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dealerProposalsInProgressPage = _mpsDealerProposalStepActions.NavigateToDealerProposalsInprogressPage(dealerDashboardPage);
            var dealerProposalsConvertCustomerInformationPage = _mpsDealerProposalStepActions.SubmitForApproval(dealerProposalsInProgressPage);
            var dealerProposalsConvertTermAndTypePage = _mpsDealerProposalStepActions.SetForApprovalInformationAndProceed(dealerProposalsConvertCustomerInformationPage);
            var dealerProposalsConvertProductsPage = _mpsDealerProposalStepActions.ClickNext(dealerProposalsConvertTermAndTypePage);
            var dealerProposalsConvertClickPricePage = _mpsDealerProposalStepActions.ClickNext(dealerProposalsConvertProductsPage);
            var dealerProposalsConvertSummaryPage = _mpsDealerProposalStepActions.SetInformationAndClickSubmitForApproval(dealerProposalsConvertClickPricePage);
            _mpsDealerProposalStepActions.SubmitForApproval(dealerProposalsConvertSummaryPage);
        }

        [When(@"I add a printer to the proposal")]
        public void WhenIAddAPrinterToTheProposal()
        {
            //TODO: if a printer is not specified, select a random one

            string installationPack = _translationService.GetInstallationPackText("DEALER_INSTALLATION_TYPE3", _contextData.Culture);
            string servicePack = _translationService.GetServicePackTypeText("SERVICE_PACK_TYPE3", _contextData.Culture);
        }


        [When(@"I have navigated to the Approved Proposals page and navigate to the proposal Summary page for this proposal")]
        public void WhenIHaveNavigatedToTheApprovedProposalsPageAndNavigateToTheProposalSummaryPageForThisProposal()
        {
            _contextData.SetBusinessType("1");
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerProposalsApprovedPage = _mpsDealerProposalStepActions.NavigateToDealerProposalsApprovedPage(_dealerDashboardPage);
            _dealerProposalsSummaryPage = _mpsDealerProposalStepActions.ClickOnViewSummary(_dealerProposalsApprovedPage);
            _proposalSummaryValues = _pageParseHelper.ParseSummaryPageValues(_dealerProposalsSummaryPage.SeleniumHelper);
        }

        [When(@"I have navigated to the Approved Proposals page and verify the proposal is displayed")]
        public void WhenIHaveNavigatedToTheApprovedProposalsPageAndVerifyTheProposalIsDisplayed()
        {
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerProposalsApprovedPage = _mpsDealerProposalStepActions.NavigateToDealerProposalsApprovedPage(_dealerDashboardPage);
            _mpsDealerProposalStepActions.IsProposalPresent(_dealerProposalsApprovedPage);
        }


        [When(@"I click the download proposal button and verify if I am able to open the PDF")]
        public void WhenIClickTheDownloadProposalButtonAndVerifyIfIAmAbleToOpenThePDF()
        {
            if (_contextData.SpecialPriceList != null)
            {
                _mpsDealerProposalStepActions.AssertAreAffectSpecialPricing(_proposalSummaryValues);
            }
            
            _pdfFile = _mpsDealerProposalStepActions.DownloadPdf(_dealerProposalsSummaryPage);
            try
            {
                var resourceContractTypePurchaseAndClick = _translationService.GetContractTypeText(TranslationKeys.ContractType.PurchaseAndClick, _contextData.Culture);
                var resourceContractTypeLeasingAndService = _translationService.GetContractTypeText(TranslationKeys.ContractType.LeasingAndService, _contextData.Culture);
                if ( _contextData.ContractType == resourceContractTypePurchaseAndClick)
                {
                    _mpsDealerProposalStepActions.AssertAreEqualSummaryValues(_pdfFile, _proposalSummaryValues);
                }
                else if(_contextData.ContractType == resourceContractTypeLeasingAndService)
                {
                    // PDF validation skip in T1S6
                }
            }
            finally
            {
                _mpsDealerProposalStepActions.DeletePdfFileErrorIgnored(_pdfFile);
            }
        }

        [When(@"I navigate to the decline proposals page and Copy the proposal along with customer")]
        public void WhenINavigateToTheDeclineProposalsPageAndCopyTheProposalAlongWithCustomer()
        {
            _dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerProposalsDeclinedPage = _mpsDealerProposalStepActions.NavigateToDealerProposalsDeclinedPage(_dealerDashboardPage);
            _cloudExistingProposalPage = _mpsDealerProposalStepActions.ClickOnCopyWithCustomerTab(_dealerProposalsDeclinedPage);
        }

        [When(@"I copy declined proposal and create new customer and submit it for approval")]
        public void WhenICopyDeclinedProposalAndCreateNewCustomerAndSubmitItForApproval()
        {
            string proposalNameForSearch;

            var dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dealerProposalsDeclinedPage = _mpsDealerProposalStepActions.NavigateToDealerProposalsDeclinedPage(dealerDashboardPage);
            var dealerProposalsInprogressPage = _mpsDealerProposalStepActions.ClickOnActionsCopy(dealerProposalsDeclinedPage, _contextData.ProposalId.ToString(), out proposalNameForSearch);
            var dealerProposalsCreateDescriptionPage = _mpsDealerProposalStepActions.ClickOnActionsEdit(dealerProposalsInprogressPage, proposalNameForSearch);
            _contextData.ProposalName = dealerProposalsCreateDescriptionPage.ProposalNameField.GetAttribute("value"); // update for verify
            var dealerProposalsCreateCustomerInformationPage =  _mpsDealerProposalStepActions.ClickOnNext(dealerProposalsCreateDescriptionPage);
            var dealerProposalsCreateTermAndTypePage = _mpsDealerProposalStepActions.CreateCustomerForProposal(dealerProposalsCreateCustomerInformationPage);
            var dealerProposalsCreateProductsPage = _mpsDealerProposalStepActions.PopulateProposalTermAndTypeAndProceed(dealerProposalsCreateTermAndTypePage, _contextData.UsageType, _contextData.ContractTerm, _contextData.BillingType, _contextData.ServicePackType);
            var dealerProposalsCreateClickPricePage =  _mpsDealerProposalStepActions.ClickOnNext(dealerProposalsCreateProductsPage); // printers no update
            var dealerProposalsCreateSummaryPage = _mpsDealerProposalStepActions.ClickOnNext(dealerProposalsCreateClickPricePage); // click prices no update 
            _cloudExistingProposalPage = _mpsDealerProposalStepActions.SaveTheProposalAndProceed(dealerProposalsCreateSummaryPage);
            WhenISubmitItForApproval();

        }

        [Then(@"I can see the above proposal in the Declined list")]
        public void WhenICanSeeTheAboveProposalInTheDeclinedList()
        {
            var dealerDashboardPage = _mpsDealerProposalStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var dealerProposalsDeclinedPage = _mpsDealerProposalStepActions.NavigateToDealerProposalsDeclinedPage(dealerDashboardPage);
            _mpsDealerProposalStepActions.VerifyDeclinedProposalInDeclinedProposalsList(dealerProposalsDeclinedPage);
        }

        [Given(@"a Sub dealer has navigated to the create proposal page from ""(.*)""")]
        public void GivenASubDealerHasNavigatedToTheCreateProposalPageFrom(string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            if (_contextData.Country.Cultures.Count != 1)
            {
                throw new ArgumentException("can not auto select culture. please call alternate some garkin");
            }
            _contextData.Culture = _contextData.Country.Cultures[0];
            _subDealerDashboardPage = _mpsDealerProposalStepActions.SignInAsSubDealerAndNavigateToDashboard(_contextData.SubDealerEmail, _contextData.SubDealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerProposalsCreateDescriptionPage = _mpsDealerProposalStepActions.NavigateToCreateProposalPage(_subDealerDashboardPage);
        }

        [When(@"a Sub dealer create a ""(.*)"" proposal")]
        public void WhenASubDealerCreateAProposal(string contractType)
        {
            _contextData.ContractType = _translationService.GetContractTypeText(contractType, _contextData.Culture);
        }

        [When(@"a Sub dealer enter the proposal description")]
        public void WhenASubDealerEnterTheProposalDescription()
        {
            string proposalName = _proposalHelper.GenerateProposalName();
            _contextData.ProposalName = proposalName;
            if (_contextData.Country.LogicSettings.IsNextDealerProposalsCreateTermAndTypePage)
            {
                _dealerProposalsCreateTermAndTypePage = _mpsDealerProposalStepActions.PopulateProposalDescriptionAndProceed<DealerProposalsCreateTermAndTypePage>(_dealerProposalsCreateDescriptionPage, proposalName, "", _contextData.ContractType);
            }
            else
            {
                _dealerProposalsCreateCustomerInformationPage = _mpsDealerProposalStepActions.PopulateProposalDescriptionAndProceed<DealerProposalsCreateCustomerInformationPage>(_dealerProposalsCreateDescriptionPage, proposalName, "", "");
            }
        }

        [When(@"a Sub dealer add these printers:")]
        public void WhenASubDealerAddThesePrinters(Table printers)
        {
            var products = printers.CreateSet<PrinterProperties>();
            var cultureInfo = new CultureInfo(_contextData.Culture);
            foreach (var product in products)
            {
                product.Price = _calculationService.ConvertInvariantNumericToCultureNumericString(product.Price);
                product.InstallationPack = _translationService.GetInstallationPackText(product.InstallationPack, _contextData.Culture);
            }
            _contextData.PrintersProperties = products;
            _dealerProposalsCreateClickPricePage = _mpsDealerProposalStepActions.AddPrinterToProposalAndProceed(_dealerProposalsCreateProductsPage);
        }

        [When(@"a Sub dealer calculate the click price for each of the above printers")]
        public void WhenASubDealerCalculateTheClickPriceForEachOfTheAbovePrinters()
        {
            _dealerProposalsCreateSummaryPage = _mpsDealerProposalStepActions.CalculateClickPriceAndProceed(_dealerProposalsCreateClickPricePage);
        }


    }
}
