﻿using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Agreement;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace Brother.MPS.Tests.Specs.MPS2.Agreement
{
    [Binding]
    public class MpsDealerAgreementSteps
    {
        private const string SUBJECT_PAGE_KEY = "subject_page";

        private readonly ScenarioContext _context;
        private readonly IContextData _contextData;
        private readonly ICountryService _countryService;
        private readonly ITranslationService _translationService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly IAgreementHelper _agreementHelper;
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly MpsDealerAgreementStepActions _mpsDealerAgreement;

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
            MpsDealerAgreementStepActions mpsDealerAgreement,
            ScenarioContext context,
            MpsContextData contextData,
            ICountryService countryService,
            ITranslationService translationService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            IAgreementHelper agreementHelper)
        {
            _context = context;
            _contextData = contextData;
            _countryService = countryService;
            _translationService = translationService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _agreementHelper = agreementHelper;
            _mpsSignIn = mpsSignIn;
            _mpsDealerAgreement = mpsDealerAgreement;
        }


        [Given(@"I have navigated to the Create Agreement page as a Cloud MPS Dealer from ""(.*)""")]
        public void GivenIHaveNavigatedToTheCreateAgreementPageAsACloudMPSDealerFrom(string country)
        {
            _contextData.SetBusinessType("3");
            _contextData.Country = _countryService.GetByName(country);
            _contextData.ContractType = "CPP Agreement"; // TODO: Replace hard coded string

            _dealerDashboardPage = _mpsDealerAgreement.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerAgreementCreateDescriptionPage = _mpsDealerAgreement.NavigateToCreateAgreementPage(_dealerDashboardPage);
        }

        [When(@"I enter the agreement description")]
        public void WhenIEnterTheAgreementDescription()
        {
            _dealerAgreementCreateTermAndTypePage = _mpsDealerAgreement.PopulateAgreementDescriptionAndProceed(_dealerAgreementCreateDescriptionPage, _agreementHelper.GenerateAgreementName());
        }

        [When(@"I input the fields \(Fill Optional fields: ""(.*)""\) on Agreement Description Page")]
        public void WhenIInputTheFieldsFillOptionalFieldsOnAgreementDescriptionPage(string optionalFields)
        {
            if (optionalFields.ToLower().Equals("true"))
            {
                string reference = _agreementHelper.GenerateReference();
                _dealerAgreementCreateTermAndTypePage = _mpsDealerAgreement.PopulateAgreementDescriptionAndProceed(
                    _dealerAgreementCreateDescriptionPage, _agreementHelper.GenerateAgreementName(), reference, reference, reference);
            }
            else
            {
                _dealerAgreementCreateTermAndTypePage = _mpsDealerAgreement.PopulateAgreementDescriptionAndProceed(
                    _dealerAgreementCreateDescriptionPage,
                    _agreementHelper.GenerateAgreementName());
            }
        }

        [When(@"I select the Usage Type of ""(.*)"", Contract Term of ""(.*)"" and Service of ""(.*)""")]
        public void WhenISelectTheUsageTypeOfContractTermOfAndServiceOf(string usageType, string contractTerm, string service)
        {
            _dealerAgreementCreateProductsPage = _mpsDealerAgreement.PopulateAgreementTermAndTypeAndProceed(_dealerAgreementCreateTermAndTypePage, usageType, contractTerm, service);
        }

        [When(@"I add these printers and verify click price:")]
        public void WhenIAddThesePrintersAndVerifyClickPrice(Table printers)
        {
            var products = printers.CreateSet<PrinterProperties>();
            _contextData.PrintersProperties = products;
            _dealerAgreementCreateClickPricePage = _mpsDealerAgreement.AddThesePrintersToAgreementAndProceed(_dealerAgreementCreateProductsPage, products);
            _dealerAgreementCreateSummaryPage = _mpsDealerAgreement.PopulateCoverageAndVolumeAndProceed(_dealerAgreementCreateClickPricePage, products);
        }                   

        [When(@"I complete the setup of agreement")]
        public void WhenICompleteTheSetupOfAgreement()
        {
            _dealerAgreementsListPage = _mpsDealerAgreement.ValidateSummaryPageAndCompleteSetup(_dealerAgreementCreateSummaryPage);
        }

        [Then(@"I can verify the creation of agreement in the agreement list")]
        public void ThenICanVerifyTheCreationOfAgreementInTheAgreementList()
        {
            _mpsDealerAgreement.VerifyCreatedAgreement(_dealerAgreementsListPage);
        }

        [When(@"I navigate to edit device data page")]
        public void WhenINavigateToEditDeviceDataPage()
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.NavigateToManageDevicesPage(_dealerAgreementsListPage);            
        }

        [When(@"I edit device data one by one for all devices \(Fill Optional fields: ""(.*)""\)")]
        public void WhenIEditDeviceDataOneByOneForAllDevicesFillOptionalFields(string optionalFields)
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.EditDeviceDataOneByOne(
                _dealerAgreementDevicesPage, optionalFields);
        }

        [When(@"I edit device data using bulk edit option \(Fill Optional fields: ""(.*)""\)")]
        public void WhenIEditDeviceDataUsingBulkEditOptionFillOptionalFields(string optionalFields)
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.EditDeviceDataUsingBulkEditOption(
                _dealerAgreementDevicesPage, optionalFields);
        }

        [When(@"I edit device data using excel edit option \(Fill Optional fields: ""(.*)""\)")]
        public void WhenIEditDeviceDataUsingExcelEditOptionFillOptionalFields(string optionalFields)
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.EditDeviceDataUsingExcelEditOption(
                _dealerAgreementDevicesPage, optionalFields);
        }

        [When(@"I edit device data using a combination of single device edit, bulk edit and excel edit options \(Fill Optional fields: ""(.*)""\)")]
        public void WhenIEditDeviceDataUsingACombinationOfSingleDeviceEditBulkEditAndExcelEditOptionsFillOptionalFields(string optionalFields)
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.EditUsingCombinationOfAllEditOptions(
                            _dealerAgreementDevicesPage, optionalFields);
        }

        [When(@"I can verify that devices are ready for installation")]
        public void WhenICanVerifyThatDevicesAreReadyForInstallation()
        {
            _mpsDealerAgreement.VerifyStatusOfDevices(_dealerAgreementDevicesPage);
        }

        [Then(@"I can create and send a bulk installation request")]
        public void ThenICanCreateAndSendABulkInstallationRequest()
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.SendBulkInstallationRequest(_dealerAgreementDevicesPage);
        }

        [Then(@"I can create and send installation requests for devices one by one")]
        public void ThenICanCreateAndSendInstallationRequestsForDevicesOneByOne()
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.SendSingleInstallationRequests(_dealerAgreementDevicesPage);
        }
    }
}
