using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Agreement;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
using System;
using System.Globalization;
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
        private readonly IRuntimeSettings _runtimeSettings;
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
        private DealerAgreementBillingPage _dealerAgreementBillingPage;
        private DealerReportsDashboardPage _dealarReportsDashboardPage;

        public MpsDealerAgreementSteps(
            MpsSignInStepActions mpsSignIn,
            MpsDealerAgreementStepActions mpsDealerAgreement,
            ScenarioContext context,
            MpsContextData contextData,
            ICountryService countryService,
            ITranslationService translationService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            IAgreementHelper agreementHelper,
            IRuntimeSettings runtimeSettings)
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
            _runtimeSettings = runtimeSettings;
        }


        [Given(@"I have navigated to the Create Agreement page as a Cloud MPS Dealer from ""(.*)""")]
        public void GivenIHaveNavigatedToTheCreateAgreementPageAsACloudMPSDealerFrom(string country)
        {
            _contextData.SetBusinessType("3");
            _contextData.Country = _countryService.GetByName(country);
            _contextData.UsableDeviceIndex = 1;
            if (_contextData.Country.Cultures.Count != 1)
            {
                throw new ArgumentException("Cannot Auto select Culture. Please call Alternate gherkin or specify culture");
            }
            _contextData.Culture = _contextData.Country.Cultures[0];
            _mpsSignIn.SetCultureInfoAndRegionInfo();

            _dealerDashboardPage = _mpsDealerAgreement.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealerAgreementCreateDescriptionPage = _mpsDealerAgreement.NavigateToCreateAgreementPage(_dealerDashboardPage);
        }

        [When(@"I enter the agreement description for ""(.*)"" type agreement")]
        public void WhenIEnterTheAgreementDescriptionForTypeAgreement(string agreementType)
        {
            _contextData.AgreementType = _translationService.GetAgreementTypeText(agreementType, _contextData.Culture);
            _dealerAgreementCreateTermAndTypePage = _mpsDealerAgreement.PopulateAgreementDescriptionAndProceed(_dealerAgreementCreateDescriptionPage, _agreementHelper.GenerateAgreementName());
        }

        [When(@"I input the fields \(Fill Optional fields: ""(.*)""\) on Agreement Description Page for ""(.*)"" type agreement")]
        public void WhenIInputTheFieldsFillOptionalFieldsOnAgreementDescriptionPageForTypeAgreement(string optionalFields, string agreementType)
        {
            _contextData.AgreementType = _translationService.GetAgreementTypeText(agreementType, _contextData.Culture);
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
            _contextData.UsageType = _translationService.GetUsageTypeText(usageType, _contextData.Culture);
            _contextData.ContractTerm = _translationService.GetContractTermText(contractTerm, _contextData.Culture);
            _contextData.ServicePackType = _translationService.GetServicePackTypeText(service, _contextData.Culture);

            _dealerAgreementCreateProductsPage = _mpsDealerAgreement.PopulateAgreementTermAndTypeAndProceed(
                _dealerAgreementCreateTermAndTypePage, _contextData.UsageType, _contextData.ContractTerm, _contextData.ServicePackType);
        }

        [When(@"I add these printers and verify click price:")]
        public void WhenIAddThesePrintersAndVerifyClickPrice(Table printers)
        {
            var products = printers.CreateSet<PrinterProperties>();
            _contextData.PrintersProperties = products;
            _dealerAgreementCreateClickPricePage = _mpsDealerAgreement.AddThesePrintersToAgreementAndProceed(_dealerAgreementCreateProductsPage);
            _dealerAgreementCreateSummaryPage = _mpsDealerAgreement.PopulateCoverageAndVolumeAndProceed(_dealerAgreementCreateClickPricePage);
        }

        [When(@"I complete the setup of agreement")]
        public void WhenICompleteTheSetupOfAgreement()
        {
            _mpsDealerAgreement.AssertAreEqualServiceInstallation(_dealerAgreementCreateSummaryPage);
            _dealerAgreementsListPage = _mpsDealerAgreement.ValidateSummaryPageAndCompleteSetup(_dealerAgreementCreateSummaryPage);
        }

        [StepDefinition(@"I can verify the creation of agreement in the agreement list")]
        public void ThenICanVerifyTheCreationOfAgreementInTheAgreementList()
        {
            _mpsDealerAgreement.VerifyCreatedAgreement(_dealerAgreementsListPage);
        }

        [Then(@"I Check data in the CPP Agreement Device Report")]
        public void ThenICheckDataInTheCPPAgreementDeviceReport()
        {
            _mpsDealerAgreement.SnapAgreementPagesValues(_dealerAgreementBillingPage);
            _dealerDashboardPage = _mpsDealerAgreement.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _dealarReportsDashboardPage =  _mpsDealerAgreement.NavigateToReportsDashboardPage(_dealerDashboardPage);
            string CPPAgreementDevicesReportXlsx=_mpsDealerAgreement.DownloadCPPAgreementDevicesReport(_dealarReportsDashboardPage);
            _mpsDealerAgreement.VerifyCheckDataInTheCPPAgreementDeviceReport(CPPAgreementDevicesReportXlsx);
        }

        [Then(@"I can delete the agreement")]
        public void ThenICanDeleteTheAgreement()
        {
            _mpsDealerAgreement.DeleteAgreement(_dealerAgreementsListPage);
        }

        [Then(@"I can verify that the agreement is removed from the agreement list")]
        public void ThenICanVerifyThatTheAgreementIsRemovedFromTheAgreementList()
        {
            //TODO: A more conclusive test for the removal of an agreement is to check the
            //database directly - but requires the db connector. See ticket MPS-4955
            _mpsDealerAgreement.VerifyAgreementIsRemoved(_dealerAgreementsListPage);
        }

        [When(@"I navigate to the agreement list")]
        public void WhenINavigateToTheAgreementList()
        {
            _mpsDealerAgreement.NavigateToAgreementsListPage();
        }

        [When(@"I navigate to edit device data page")]
        public void WhenINavigateToEditDeviceDataPage()
        {
            string resourceInstalledPrinterStatusAddressRequired = _translationService.GetInstalledPrinterStatusText(
                TranslationKeys.InstalledPrinterStatus.AddressRequiredType3, _contextData.Culture);
            _dealerAgreementDevicesPage = _mpsDealerAgreement.NavigateToManageDevicesPage(
                _dealerAgreementsListPage, resourceInstalledPrinterStatusAddressRequired);
        }

        [When(@"I edit device data one by one for all devices \(Fill Optional fields: ""(.*)""\)")]
        public void WhenIEditDeviceDataOneByOneForAllDevicesFillOptionalFields(string optionalFields)
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.EditDeviceDataOneByOne(
                _dealerAgreementDevicesPage, optionalFields);
        }

        [When(@"I edit device data bulk for all devices \(Fill Optional fields: ""(.*)""\)")]
        public void WhenIEditDeviceDataBulkForAllDevicesFillOptionalFields(string optionalFields)
        {
            string validationExpression;
            _dealerAgreementDevicesPage = _mpsDealerAgreement.EditDeviceDataBulk(_dealerAgreementDevicesPage, optionalFields, out validationExpression);
        }

        [When(@"I edit device data using bulk edit option \(Fill Optional fields: ""(.*)""\)")]
        public void WhenIEditDeviceDataUsingBulkEditOptionFillOptionalFields(string optionalFields)
        {
            string validationExpression;
            _dealerAgreementDevicesPage = _mpsDealerAgreement.EditDeviceDataBulk(_dealerAgreementDevicesPage, optionalFields, out validationExpression);
            _mpsDealerAgreement.VerifyAddressOfEditedDevice(_dealerAgreementDevicesPage, validationExpression);
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
            string resourceInstalledPrinterStatusReadyForInstall = _translationService.GetInstalledPrinterStatusText(
                TranslationKeys.InstalledPrinterStatus.ReadyForInstallType3, _contextData.Culture);
            _mpsDealerAgreement.VerifyStatusOfDevices(
                _dealerAgreementDevicesPage, resourceInstalledPrinterStatusReadyForInstall);
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

        [When(@"I export the device data into excel and retrieve installation information")]
        public void WhenIExportTheDeviceDataIntoExcelAndRetrieveInstallationInformation()
        {
            _mpsDealerAgreement.ExportDeviceDetailsAndReadExcel(_dealerAgreementDevicesPage);
        }

        [Then(@"I can verify that all devices are installed and responding")]
        public void ThenICanVerifyThatAllDevicesAreInstalledAndResponding()
        {
            _contextData.AgreementStartDate = MpsUtil.DateTimeString(DateTime.Now, _contextData.Country.CountryIso);
            _contextData.AgreementEndDate = MpsUtil.ContractEndDate(_contextData.AgreementStartDate, Int32.Parse(_contextData.ContractTerm[0].ToString()));

            string resourceInstalledPrinterStatusInstalled = _translationService.GetInstalledPrinterStatusText(
                TranslationKeys.InstalledPrinterStatus.InstalledType3, _contextData.Culture);
            string resourceDeviceConnectionStatusResponding = _translationService.GetDeviceConnectionStatusText(
                TranslationKeys.DeviceConnectionStatus.Responding, _contextData.Culture);
            _dealerAgreementDevicesPage = _mpsDealerAgreement.VerifyThatDevicesAreInstalled(
                _dealerAgreementDevicesPage, resourceInstalledPrinterStatusInstalled, resourceDeviceConnectionStatusResponding);
        }

        [Then(@"I can verify the correct reflection of updated print counts")]
        public void ThenICanVerifyTheCorrectReflectionOfUpdatedPrintCounts()
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.VerifyUpdatedPrintCounts(_dealerAgreementDevicesPage);
        }

        [When(@"I manually raise a consumable order for above devices")]
        public void WhenIManuallyRaiseAConsumableOrderForAboveDevices()
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.RaiseConsumableOrdersManually(_dealerAgreementDevicesPage);
        }

        [Then(@"I can verify the generation of manual consumable orders alongwith status")]
        public void ThenICanVerifyTheGenerationOfManualConsumableOrdersAlongwithStatus()
        {
            string resourceConsumableOrderMethodManual = _translationService.GetConsumableOrderMethodText(TranslationKeys.ConsumableOrderMethod.Manual, _contextData.Culture);
            _dealerAgreementDevicesPage = _mpsDealerAgreement.VerifyConsumableOrders(_dealerAgreementDevicesPage, resourceConsumableOrderMethodManual);
        }

        [Then(@"I can verify the generation of automatic consumable orders alongwith status")]
        public void ThenICanVerifyTheGenerationOfAutomaticConsumableOrdersAlongwithStatus()
        {
            string resourceConsumableOrderMethodAutomatic = _translationService.GetConsumableOrderMethodText(TranslationKeys.ConsumableOrderMethod.Automatic, _contextData.Culture);
            _dealerAgreementDevicesPage = _mpsDealerAgreement.VerifyConsumableOrders(_dealerAgreementDevicesPage, resourceConsumableOrderMethodAutomatic);
        }

        [When(@"I manually raise a service request for above devices")]
        public void WhenIManuallyRaiseAServiceRequestForAboveDevices()
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.RaiseServiceRequestsManually(_dealerAgreementDevicesPage);
        }

        [Then(@"I can verify that service request has been closed succesfully")]
        public void ThenICanVerifyThatServiceRequestHasBeenClosedSuccesfully()
        {
           _dealerAgreementDevicesPage = _mpsDealerAgreement.VerifyServiceRequestStatus(_dealerAgreementDevicesPage, _translationService.GetServiceRequestStatusText(TranslationKeys.ServiceRequestStatus.Closed, _contextData.Culture));
        }

        [Then(@"I can verify the device details using show device details option")]
        public void ThenICanVerifyTheDeviceDetailsUsingShowDeviceDetailsOption()
        {
            _mpsDealerAgreement.VerifyDeviceDetails(_dealerAgreementDevicesPage);
        }

        [Then(@"I can verify the device details on device dashboard page")]
        public void ThenICanVerifyTheDeviceDetailsOnDeviceDashboardPage()
        {
            _mpsDealerAgreement.VerifyDeviceDetailsOnDashboard(_dealerAgreementDevicesPage);
        }

        [Then(@"I can verify the Print Summary and Consumables on device dashboard page")]
        public void ThenICanVerifyThePrintSummaryAndConsumablesOnDeviceDashboardPage()
        {
            _mpsDealerAgreement.VerifyPrintSummaryAndConsumablesOnDashboard(_dealerAgreementDevicesPage);
        }

        [Then(@"I can verify the click rate billing invoice")]
        public void ThenICanVerifyTheClickRateBillingInvoice()
        {
            _dealerAgreementBillingPage = _mpsDealerAgreement.VerifyClickRateInvoice(_dealerAgreementDevicesPage);
        }

        [Then(@"I can verify the service/installation billing invoice")]
        public void ThenICanVerifyTheServiceInstallationBillingInvoice()
        {
            _dealerAgreementBillingPage = _mpsDealerAgreement.VerifyServiceInstallationInvoice(_dealerAgreementBillingPage);
        }

        [When(@"I create and send a ""(.*)"" swap device installation request")]
        public void WhenICreateAndSendASwapDeviceInstallationRequest(string swapDeviceType)
        {
            _mpsDealerAgreement.ContractShiftBeforeSwapDeviceInstallationRequest(1);
            _contextData.SwapType = swapDeviceType;
            _dealerAgreementDevicesPage = _mpsDealerAgreement.SendSwapDeviceInstallationRequest(_dealerAgreementDevicesPage, swapDeviceType);
        }

        [Then(@"I can verify that the new devices are installed and responding")]
        public void ThenICanVerifyThatTheNewDevicesAreInstalledAndResponding()
        {
            _dealerAgreementDevicesPage = _mpsDealerAgreement.VerifyStatusOfSwappedInAndSwappedOutDevices(_dealerAgreementDevicesPage);
        }

        [Then(@"I can verify that the reinstalled devices are responding")]
        public void ThenICanVerifyThatTheReinstalledDevicesAreResponding()
        {
            string resourceInstalledPrinterStatusInstalled = _translationService.GetInstalledPrinterStatusText(
                TranslationKeys.InstalledPrinterStatus.InstalledType3, _contextData.Culture);
            string resourceDeviceConnectionStatusResponding = _translationService.GetDeviceConnectionStatusText(
                TranslationKeys.DeviceConnectionStatus.Responding, _contextData.Culture);
            _dealerAgreementDevicesPage = _mpsDealerAgreement.VerifyThatDevicesAreInstalled(
                _dealerAgreementDevicesPage, resourceInstalledPrinterStatusInstalled, resourceDeviceConnectionStatusResponding);
        }

        [Then(@"I can verify the CPP Agreement Report")]
        public void ThenICanVerifyTheCPPAgreementReport()
        {
            var dealerReportsDashboardPage = _mpsDealerAgreement.NavigateToReports(_dealerAgreementDevicesPage);
            _mpsDealerAgreement.DownloadCPPAgreementReportAndVerify(dealerReportsDashboardPage);
        }
    }
}
