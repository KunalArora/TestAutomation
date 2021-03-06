﻿using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
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
using TechTalk.SpecFlow.Assist;


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
        private readonly ICalculationService _calculationService;
        private readonly MpsLocalOfficeAdminContractStepActions _mpsLocalOfficeAdminContractStepActions;
        private readonly MpsLocalOfficeAdminAgreementStepActions _mpsLocalOfficeAdminAgreementStepActions;
        private LocalOfficeAdminReportsProposalSummaryPage _localOfficeAdminReportsProposalSummaryPage;
        private LocalOfficeAdminDashBoardPage _localOfficeAdminDashboardPage;
        private LocalOfficeAdminAdministrationDashboardPage _localOfficeAdminAdministrationDashboardPage;
        private LocalOfficeAdminAdministrationDealerPage _localOfficeAdminAdministrationDealerPage;
        private LocalOfficeAdminDealersCreateDealershipPage _localOfficeAdminDealersCreateDealershipPage;
        private LocalOfficeAdminDealersEditDealershipPage _localOfficeAdminDealersEditDealershipPage;
        private LocalOfficeEnhancedUsageMonitoringAdminInstalledPrinterPage _localOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage;
        private LocalOfficeEnhancedUsageMonitoringAdminPrinterEnginePage _localOfficeAdminEnhancedUsageMonitoringAdminPrinterEnginePage;
        private LocalOfficeAdminProgramsDashboardPage _localOfficeAdminProgramPage;
        private LocalOfficeAdminProgramsLeaseAndClickProgramSettingsPage _localOfficeAdminProgramLeaseAndClickPage;
        private LocalOfficeAdminProgramsPurchaseAndClickProgramSettingsPage _localOfficeAdminProgramPurchaseAndClickPage;

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
            IProposalHelper proposalHelper,
            ICalculationService calculationService)
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
            _calculationService = calculationService;
            _mpsLocalOfficeAdminContractStepActions = mpsLocalOfficeAdminContractStepActions;
            _mpsLocalOfficeAdminAgreementStepActions = mpsLocalOfficeAdminAgreementStepActions;

        }

        [Given(@"a Cloud MPS Local Office Admin has navigated to the Dashboard page for country ""(.*)""")]
        public void GivenACloudMPSLocalOfficeAdminHasNavigatedToTheDashboardPageForCountry(string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            if (_contextData.Country.Cultures.Count != 1)
            {
                throw new ArgumentException("Cannot Auto select Culture. Please call Alternate gherkin or specify culture");
            }
            _contextData.Culture = _contextData.Country.Cultures[0];
            _mpsSignInStepActions.SetCultureInfoAndRegionInfo();
            _localOfficeAdminDashboardPage = _mpsSignInStepActions.SignInAsLocalOfficeAdmin(
                _userResolver.LocalOfficeAdminUsername, _userResolver.LocalOfficeAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _localOfficeAdminDashboardPage = _mpsLocalOfficeAdminAgreementStepActions.SelectLanguageGivenCulture(_localOfficeAdminDashboardPage);
        }
        
        [Given(@"I have navigated to the dashboard page as a Cloud MPS Local office admin with culture ""(.*)"" from ""(.*)""")]
        public void GivenIHaveNavigatedToTheDashboardPageAsACloudMPSLocalOfficeAdminWithCultureFrom(string culture, string country)
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

        [When(@"I create a new dealer with SAP Vendor Id as ""(.*)"" and verify the created dealer details")]
        public void WhenICreateANewDealerWithSAPVendorIdAsAndVerifyTheCreatedDealerDetails(string sapVendorId)
        {
            _localOfficeAdminAdministrationDealerPage = _mpsLocalOfficeAdminAgreementStepActions.NavigateToAdministrationDealerPage(_localOfficeAdminAdministrationDashboardPage);
            _localOfficeAdminDealersCreateDealershipPage = _mpsLocalOfficeAdminAgreementStepActions.ClickOnAddDealerButton(_localOfficeAdminAdministrationDealerPage);
            //In case of United kingdom, there is a need to verify sap vendor number before making the dealer 
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

        [When(@"a Cloud MPS Local Office Admin navigates to the Printer Engine tab under Manage Device Order Threshold section")]
        public void WhenACloudMPSLocalOfficeAdminNavigatesToThePrinterEngineTabUnderManageDeviceOrderThresholdSection()
        {
            _localOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage = _mpsLocalOfficeAdminContractStepActions.NavigateToEnhancedUsageMonitoringAdminInstalledPrinterPage(_localOfficeAdminDashboardPage);
            _localOfficeAdminEnhancedUsageMonitoringAdminPrinterEnginePage = _mpsLocalOfficeAdminContractStepActions.NavigateToEnhancedUsageMonitoringAdminPrinterEnginePage(_localOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage);
        }

        [Then(@"a Cloud MPS Local Office Admin can set the threshold value for printer engines types as follows and saves the details")]
        public void ThenACloudMPSLocalOfficeAdminCanSetTheThresholdValueForPrinterEnginesTypesAsFollowsAndSavesTheDetails(Table printerEngineThresholdDetails)
        {
            _contextData.PrinterEngineThresholdDetails = printerEngineThresholdDetails.CreateSet<PrinterEngineThresholdDetails>();

            foreach (var printerEngineThresholdDetail in _contextData.PrinterEngineThresholdDetails)
            {
                printerEngineThresholdDetail.Threshold = _calculationService.ConvertInvariantNumericStringToCultureNumericString(printerEngineThresholdDetail.Threshold);
            }

            _localOfficeAdminEnhancedUsageMonitoringAdminPrinterEnginePage = _mpsLocalOfficeAdminContractStepActions.UpdatePrinterEngineThresholdDetailsAndSave(_localOfficeAdminEnhancedUsageMonitoringAdminPrinterEnginePage);
        }

        [When(@"I navigate to the lease and click program settings page and enable the program")]
        public void WhenINavigateToTheLeaseAndClickProgramSettingsPageAndEnableTheProgram()
        {
            _localOfficeAdminProgramPage = _mpsLocalOfficeAdminContractStepActions.NavigateToProgramPage(_localOfficeAdminDashboardPage);
            _localOfficeAdminProgramLeaseAndClickPage = _mpsLocalOfficeAdminContractStepActions.NavigateToLeaseAndClickProgramSettingsPage(_localOfficeAdminProgramPage);
            _localOfficeAdminProgramLeaseAndClickPage = _mpsLocalOfficeAdminContractStepActions.ClickOnProgramEnabledButtonAndSave(_localOfficeAdminProgramLeaseAndClickPage);
        }

        [Then(@"I disable the program that was previously enabled")]
        public void ThenIDisableTheProgramThatWasPreviouslyEnabled()
        {
            _localOfficeAdminProgramLeaseAndClickPage = _mpsLocalOfficeAdminContractStepActions.DisableProgramAndSave(_localOfficeAdminProgramLeaseAndClickPage);
        }

        [When(@"I navigate to the purchase and click program settings page")]
        public void WhenINavigateToThePurchaseAndClickProgramSettingsPage()
        {
            _localOfficeAdminDashboardPage = _mpsSignInStepActions.SignInAsLocalOfficeAdmin(
                _userResolver.LocalOfficeAdminUsername, _userResolver.LocalOfficeAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _localOfficeAdminDashboardPage = _mpsLocalOfficeAdminAgreementStepActions.SelectLanguageGivenCulture(_localOfficeAdminDashboardPage);
            _localOfficeAdminProgramPage = _mpsLocalOfficeAdminContractStepActions.NavigateToProgramPage(_localOfficeAdminDashboardPage);
            _localOfficeAdminProgramPurchaseAndClickPage = _mpsLocalOfficeAdminContractStepActions.NavigateToPurchaseAndClickProgramSettingsPage(_localOfficeAdminProgramPage);
        }

        [When(@"I create a billing cycle with billing type as ""(.*)"", billing usage type as ""(.*)"" and billing payment type as ""(.*)""")]
        public void WhenICreateABillingCycleWithBillingTypeAsBillingUsageTypeAsAndBillingPaymentTypeAs(string billingType, string billingUsageType, string billingPaymentType)
        {
            var billingTypeValue = _translationService.GetBillingTypeText(billingType, _contextData.Culture);
            var billingUsageTypeValue = _translationService.GetUsageTypeText(billingUsageType, _contextData.Culture);
            var billingPaymentTypeValue = _translationService.GetBillingPaymentTypeText(billingPaymentType, _contextData.Culture);

            _localOfficeAdminProgramPurchaseAndClickPage = _mpsLocalOfficeAdminContractStepActions.AddANewBillingCycle(_localOfficeAdminProgramPurchaseAndClickPage,
                billingTypeValue, billingUsageTypeValue, billingPaymentTypeValue);
            _localOfficeAdminProgramPurchaseAndClickPage = _mpsLocalOfficeAdminContractStepActions.EnableTheCreatedBillingCycle(_localOfficeAdminProgramPurchaseAndClickPage,
                billingTypeValue, billingUsageTypeValue, billingPaymentTypeValue);
        }

        [Then(@"I delete the newly created billing type as ""(.*)"", billing usage type as ""(.*)"" and billing payment type as ""(.*)""")]
        public void ThenIDeleteTheNewlyCreatedBillingTypeAsBillingUsageTypeAsAndBillingPaymentTypeAs(string billingType, string billingUsageType, string billingPaymentType)
        {
            var billingTypeValue = _translationService.GetBillingTypeText(billingType, _contextData.Culture);
            var billingUsageTypeValue = _translationService.GetUsageTypeText(billingUsageType, _contextData.Culture);
            var billingPaymentTypeValue = _translationService.GetBillingPaymentTypeText(billingPaymentType, _contextData.Culture);

            _localOfficeAdminProgramPurchaseAndClickPage = _mpsLocalOfficeAdminContractStepActions.DeleteTheCreatedBillingCycle(_localOfficeAdminProgramPurchaseAndClickPage,
                billingTypeValue, billingUsageTypeValue, billingPaymentTypeValue);

        }
    }
}
