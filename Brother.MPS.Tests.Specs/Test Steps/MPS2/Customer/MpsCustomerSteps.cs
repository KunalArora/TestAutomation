using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Customer;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Customer
{
    [Binding]
    public class MpsCustomerSteps
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly ITranslationService _translationService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsCustomerStepActions _mpsCustomerStepActions;

        public MpsCustomerSteps(MpsSignInStepActions mpsSignInStepActions,
            MpsCustomerStepActions mpsDealerCustomerStepActions,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            ITranslationService translationService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            IMpsWebToolsService webToolService,
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
            _mpsCustomerStepActions = mpsDealerCustomerStepActions;
        }

        [StepDefinition(@"a Customer has navigated to the Consumables Devices page to verify that above device have updated Ink Status and Service Request is raised")]
        public void WhenACustomerHasNavigatedToTheConsumablesDevicesPageToVerifyThatAboveDeviceHaveUpdatedInkStatusAndServiceRequestIsRaised()
        {
            var customerDashBoardPage = _mpsCustomerStepActions.SignInAsCustomerAndNavigateToDashboard(_contextData.CustomerEmail, _contextData.CustomerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var customerConsumablesDevicesPage = _mpsCustomerStepActions.ClickOnComsumablesTab(customerDashBoardPage);
            _mpsCustomerStepActions.VerifyRaisedConsumableOrderStatus(customerConsumablesDevicesPage, _contextData.PrintersProperties);
            var customerServiceRequestActivePage = _mpsCustomerStepActions.ClickOnServiceRequestsTab(customerDashBoardPage);
            _mpsCustomerStepActions.VerifyHasRequestOnList(customerServiceRequestActivePage, _contextData.PrintersProperties);
        }
    }
}
