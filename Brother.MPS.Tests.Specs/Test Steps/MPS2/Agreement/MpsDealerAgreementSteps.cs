using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Agreement;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace Brother.MPS.Tests.Specs.MPS2.Agreement
{
    [Binding]
    public class MpsDealerAgreementSteps
    {
        private const string SUBJECT_PAGE_KEY = "subject_page";

        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly ITranslationService _translationService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly IProposalHelper _proposalHelper;
        private readonly IAgreementHelper _agreementHelper;
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly MpsDealerAgreementStepActions _mpsAgreement;

        //page objects used by these steps
        private DealerDashBoardPage _dealerDashboardPage;
        private DealerAgreementCreateDescriptionPage _dealerAgreementCreateDescriptionPage;
        private DealerAgreementCreateTermAndTypePage _dealerAgreementCreateTermAndTypePage;
        private DealerAgreementCreateProductsPage _dealerAgreementCreateProductsPage;
        private DealerAgreementCreateClickPricePage _dealerAgreementCreateClickPricePage;
        private DealerAgreementCreateSummaryPage _dealerAgreementCreateSummaryPage;
        private DealerAgreementsListPage _dealerAgreementsListPage;
        private DealerAgreementDevicesPage _dealerAgreementDevicesPage;

        public MpsDealerAgreementSteps(MpsSignInStepActions mpsSignIn,
            MpsDealerAgreementStepActions mpsAgreement,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            ITranslationService translationService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            IProposalHelper proposalHelper,
            IAgreementHelper agreementHelper)
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
            _agreementHelper = agreementHelper;
            _mpsSignIn = mpsSignIn;
            _mpsAgreement = mpsAgreement;
        }


        [Given(@"I have navigated to the Create Agreement page as a Cloud MPS Dealer from ""(.*)""")]
        public void GivenIHaveNavigatedToTheCreateAgreementPageAsACloudMPSDealerFrom(string country)
        {
            _contextData.SetBusinessType("3");
            _contextData.Country = _countryService.GetByName(country);

            _dealerDashboardPage = _mpsAgreement.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerAgreementCreateDescriptionPage = _mpsAgreement.NavigateToCreateAgreementPage(_dealerDashboardPage);
        }

        [When(@"I enter the agreement description")]
        public void WhenIEnterTheAgreementDescription()
        {
            _dealerAgreementCreateTermAndTypePage = _mpsAgreement.PopulateAgreementDescriptionAndProceed(_dealerAgreementCreateDescriptionPage, _agreementHelper.GenerateAgreementName());
        }

        [When(@"I input the fields \(""(.*)"" fields also\) on Agreement Description Page")]
        public void WhenIInputTheFieldsFieldsAlsoOnAgreementDescriptionPage(string NonMandatory)
        {
            if (NonMandatory.ToLower().Equals("yes"))
            {
                _dealerAgreementCreateTermAndTypePage = _mpsAgreement.PopulateAgreementDescriptionAndProceed(
                    _dealerAgreementCreateDescriptionPage, 
                    _agreementHelper.GenerateAgreementName(), 
                    _agreementHelper.GenerateReference(),
                    _agreementHelper.GenerateReference(),
                    _agreementHelper.GenerateReference());
            }
            else
            {
                _dealerAgreementCreateTermAndTypePage = _mpsAgreement.PopulateAgreementDescriptionAndProceed(
                    _dealerAgreementCreateDescriptionPage, 
                    _agreementHelper.GenerateAgreementName());
            }
        }


        [When(@"I select the Usage Type of ""(.*)"", Contract Term of ""(.*)"" and Service of ""(.*)""")]
        public void WhenISelectTheUsageTypeOfContractTermOfAndServiceOf(string usageType, string contractTerm, string service)
        {
            _dealerAgreementCreateProductsPage = _mpsAgreement.PopulateAgreementTermAndTypeAndProceed(_dealerAgreementCreateTermAndTypePage, usageType, contractTerm, service);
        }

 
        [Given(@"I add a printer to the agreement")]
        public void WhenIAddAPrinterToTheAgreement()
        {
            //TODO: if a printer is not specified, select a random one
            //TODO: Refactor this function 
            string installationPack = _translationService.GetInstallationPackText("DEALER_INSTALLATION_TYPE3", _contextData.Culture);
            string servicePack = _translationService.GetServicePackTypeText("SERVICE_PACK_TYPE3", _contextData.Culture);

            _dealerAgreementCreateClickPricePage = _mpsAgreement.AddPrinterToAgreementAndProceed(_dealerAgreementCreateProductsPage, _proposalHelper.SelectPrinter(), 2, installationPack, servicePack);

        }

        [When(@"I add these printers and verify click price:")]
        public void WhenIAddThesePrintersAndVerifyClickPrice(Table printers)
        {
            var products = printers.CreateSet<PrinterProperties>();
            _contextData.PrintersProperties = products;
            _dealerAgreementCreateClickPricePage = _mpsAgreement.AddThesePrintersToAgreementAndProceed(_dealerAgreementCreateProductsPage, products);
            _dealerAgreementCreateSummaryPage = _mpsAgreement.PopulateCoverageAndVolumeAndProceed(_dealerAgreementCreateClickPricePage, products);
        }                   

        [When(@"I complete the setup of agreement")]
        public void WhenICompleteTheSetupOfAgreement()
        {
            _dealerAgreementsListPage = _mpsAgreement.ValidateSummaryPageAndCompleteSetup(_dealerAgreementCreateSummaryPage);
        }

        [Then(@"I can verify the creation of agreement in the agreement list")]
        public void ThenICanVerifyTheCreationOfAgreementInTheAgreementList()
        {
            _mpsAgreement.VerifyCreatedAgreement(_dealerAgreementsListPage);
        }

        [When(@"I navigate to edit device data page")]
        public void WhenINavigateToEditDeviceDataPage()
        {
            _dealerAgreementDevicesPage = _mpsAgreement.NavigateToManageDevicesPage(_dealerAgreementsListPage);            
        }

        [When(@"I edit device data one by one for all devices \(""(.*)"" fields also\)")]
        public void WhenIEditDeviceDataOneByOneForAllDevicesFieldsAlso(string NonMandatory)
        {
            _dealerAgreementDevicesPage = _mpsAgreement.EditDeviceDataOneByOne(
                _dealerAgreementDevicesPage, NonMandatory);
        }

        [When(@"I edit device data using bulk edit option \(""(.*)"" fields also\)")]
        public void WhenIEditDeviceDataUsingBulkEditOptionFieldsAlso(string NonMandatory)
        {
            _dealerAgreementDevicesPage = _mpsAgreement.EditDeviceDataUsingBulkEditOption(
                _dealerAgreementDevicesPage, NonMandatory);
        }

        [When(@"I edit device data using excel edit option \(""(.*)"" fields also\)")]
        public void WhenIEditDeviceDataUsingExcelEditOptionFieldsAlso(string NonMandatory)
        {
            _dealerAgreementDevicesPage = _mpsAgreement.EditDeviceDataUsingExcelEditOption(
                _dealerAgreementDevicesPage, NonMandatory);
        }

        [When(@"I edit device data using a combination of single device edit, bulk edit and excel edit options \(""(.*)"" fields also\)")]
        public void WhenIEditDeviceDataUsingACombinationOfSingleDeviceEditBulkEditAndExcelEditOptionsFieldsAlso(string NonMandatory)
        {
            _dealerAgreementDevicesPage = _mpsAgreement.EditUsingCombinationOfAllEditOptions(
                _dealerAgreementDevicesPage, NonMandatory);
        }

        [Then(@"I can verify that devices are ready for installation")]
        public void ThenICanVerifyThatDevicesAreReadyForInstallation()
        {
            _mpsAgreement.VerifyStatusOfDevices(_dealerAgreementDevicesPage);
        }
    }
}
