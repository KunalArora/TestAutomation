using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Customer
{
    public class MpsDealerCustomerSteps
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
        //private readonly MpsDealerCustomerStepActions _mpsDealerCustomerStepActions;

        //page objects used by these steps
        private DealerDashBoardPage _dealerDashboardPage;
        //TODO: implement IPageObject interface for the following page objects
        private DealerCustomersExistingPage _dealerCustomersExistingPage;
        private DealerCustomersManagePage _dealerCustomersManagePage;

        public MpsDealerCustomerSteps(MpsSignInStepActions mpsSignInStepActions,
            //MpsDealerCustomerStepActions mpsDealerProposalStepActions,
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
            //_mpsDealerCustomerStepActions = mpsDealerCustomerStepActions;
        }

        [Given(@"I have navigated to the Create Customer page as a ""(.*)"" from ""(.*)""")]
        public void GivenIHaveNavigatedToTheCreateCustomerPageAsRoleFromCountry(string role, string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            //TODO - create MPSDealerCustomerStepActions class. See WhenICreateNewCustomer() method in Brother.MPS.Tests.Specs\Test Steps\MPSTwo\Customer\DealerCanOperateCustomersSteps for how the Selenium actions are implemented in the existing framework
            //_dealerDashboardPage = _mpsDealerCustomerStepActions.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.AtYourSideUrl));
            //_dealerProposalsCreateDescriptionPage = _mpsDealerCustomerStepActions.NavigateToCreateCustomerPage(_dealerDashboardPage);
        }
    }
}
