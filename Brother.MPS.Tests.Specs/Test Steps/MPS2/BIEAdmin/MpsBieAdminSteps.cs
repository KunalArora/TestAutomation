using Brother.Tests.Common.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

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

        // Page objects
        private BieAdminDashboardPage _bieAdminDashboardPage;

        public MpsBieAdminSteps(
            ScenarioContext context,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            MpsSignInStepActions mpsSignInStepActions)
        {
            _context = context;
            _contextData = contextData;
            _pageService = pageService;
            _countryService = countryService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignInStepActions = mpsSignInStepActions;
        }

        [Given(@"a Cloud MPS BIE Admin has navigated to the Dashboard page")]
        public void GivenACloudMPSBIEAdminHasNavigatedToTheDashboardPage()
        {
            _bieAdminDashboardPage = _mpsSignInStepActions.SignInAsBieAdmin(_userResolver.BIEAdminUsername, _userResolver.BIEAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
        }

        [When(@"a Cloud MPS BIE Admin navigates to the Manage Device Order Threshold page")]
        public void WhenACloudMPSBIEAdminNavigatesToTheManageDeviceOrderThresholdPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"a Cloud MPS BIE Admin navigates to the Printer Engine tab")]
        public void WhenACloudMPSBIEAdminNavigatesToThePrinterEngineTab()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"a Cloud MPS BIE Admin selects the country as ""(.*)""")]
        public void WhenACloudMPSBIEAdminSelectsTheCountryAs(string country)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"a Cloud MPS BIE Admin can set the threshold value for printer engines types as follows and saves the details")]
        public void ThenACloudMPSBIEAdminCanSetTheThresholdValueForPrinterEnginesTypesAsFollowsAndSavesTheDetails(Table printerEngineDetails)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"a Cloud MPS BIE Admin navigates to the Installed Printer tab")]
        public void WhenACloudMPSBIEAdminNavigatesToTheInstalledPrinterTab()
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
