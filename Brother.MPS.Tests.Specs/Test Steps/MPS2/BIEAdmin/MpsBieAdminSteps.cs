using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.BIEAdmin;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs.Test_Steps.MPS2.BIEAdmin
{
    [Binding]
    public class MpsBieAdminSteps
    {
        private readonly ScenarioContext _context;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private readonly MpsBieAdminStepActions _mpsBieAdminStepActions;

        // Page objects
        private BieAdminDashboardPage _bieAdminDashboardPage;
        private BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage _bieAdminEnhancedUsageMonitoringNewInstalledPrinterPage;
        private BieAdminEnhancedUsageMonitoringNewPrinterEnginePage _bieAdminEnhancedUsageMonitoringNewPrinterEnginePage;

        public MpsBieAdminSteps(
            ScenarioContext context,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            MpsSignInStepActions mpsSignInStepActions,
            MpsBieAdminStepActions mpsBieAdminStepActions
            )
        {
            _context = context;
            _contextData = contextData;
            _pageService = pageService;
            _countryService = countryService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignInStepActions = mpsSignInStepActions;
            _mpsBieAdminStepActions = mpsBieAdminStepActions;
        }

        [Given(@"a Cloud MPS BIE Admin has navigated to the Dashboard page")]
        public void GivenACloudMPSBIEAdminHasNavigatedToTheDashboardPage()
        {
            _bieAdminDashboardPage = _mpsSignInStepActions.SignInAsBieAdmin(_userResolver.BIEAdminUsername, _userResolver.BIEAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
        }

        [When(@"a Cloud MPS BIE Admin navigates to the Printer Engine tab under Manage Device Order Threshold section")]
        public void WhenACloudMPSBIEAdminNavigatesToThePrinterEngineTabUnderManageDeviceOrderThresholdSection()
        {
            _bieAdminEnhancedUsageMonitoringNewInstalledPrinterPage = _mpsBieAdminStepActions.NavigateToEnhancedUsageMonitoringNewInstalledPrinterPage(_bieAdminDashboardPage);
            _bieAdminEnhancedUsageMonitoringNewPrinterEnginePage = _mpsBieAdminStepActions.NavigateToEnhancedUsageMonitoringNewPrinterEnginePage(_bieAdminEnhancedUsageMonitoringNewInstalledPrinterPage);
        }

        [When(@"a Cloud MPS BIE Admin selects the country as ""(.*)""")]
        public void WhenACloudMPSBIEAdminSelectsTheCountryAs(string country)
        {
            _bieAdminEnhancedUsageMonitoringNewPrinterEnginePage = _mpsBieAdminStepActions.SelectCountry(_bieAdminEnhancedUsageMonitoringNewPrinterEnginePage, country);
        }

        [Then(@"a Cloud MPS BIE Admin can set the threshold value for printer engines types as follows and saves the details")]
        public void ThenACloudMPSBIEAdminCanSetTheThresholdValueForPrinterEnginesTypesAsFollowsAndSavesTheDetails(Table printerEngineThresholdDetails)
        {
            _contextData.PrinterEngineThresholdDetails = printerEngineThresholdDetails.CreateSet<PrinterEngineThresholdDetails>();
            _bieAdminEnhancedUsageMonitoringNewPrinterEnginePage = _mpsBieAdminStepActions.UpdatePrinterEngineThresholdDetailsAndSave(_bieAdminEnhancedUsageMonitoringNewPrinterEnginePage);

        }

        [When(@"a Cloud MPS BIE Admin navigates to the Installed Printer tab under Manage Device Order Threshold section")]
        public void WhenACloudMPSBIEAdminNavigatesToTheInstalledPrinterTabUnderManageDeviceOrderThresholdSection()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a Cloud MPS BIE Admin searches for the agreement and ensures correct printer details")]
        public void ThenACloudMPSBIEAdminSearchesForTheAgreementAndEnsuresCorrectPrinterDetails()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a Cloud MPS BIE Admin validates the default threshold values for the printers")]
        public void ThenACloudMPSBIEAdminValidatesTheDefaultThresholdValuesForThePrinters()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a Cloud MPS BIE Admin updates the threshold value for printers and saves the details")]
        public void ThenACloudMPSBIEAdminUpdatesTheThresholdValueForPrintersAndSavesTheDetails()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
