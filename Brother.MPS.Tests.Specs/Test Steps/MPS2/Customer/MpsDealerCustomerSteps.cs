using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Customer;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Customer
{
    [Binding]
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
        private readonly MpsDealerCustomerStepActions _mpsDealerCustomerStepActions;

        //page objects used by these steps
        private DealerDashBoardPage _dealerDashboardPage;
        private DealerCustomersExistingPage _dealerCustomersExistingPage;
        private DealerCustomersManagePage _dealerCustomersManagePage;

        public MpsDealerCustomerSteps(MpsSignInStepActions mpsSignInStepActions,
            MpsDealerCustomerStepActions mpsDealerCustomerStepActions,
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
            _mpsDealerCustomerStepActions = mpsDealerCustomerStepActions;
        }

        [Given(@"I have navigated to the Create Customer page as a ""(.*)"" from ""(.*)""")]
        public void GivenIHaveNavigatedToTheCreateCustomerPageAsRoleFromCountry(string role, string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);

            switch (role)
            {
                case "Cloud MPS Dealer":
                    _dealerDashboardPage = _mpsSignInStepActions.SignInAsDealer(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
                    break;
                default:
                    ScenarioContext.Current.Pending();
                    break;

            }
            var dealerCustomersExistingPage = _mpsDealerCustomerStepActions.NavigateToCustomerContractPage(_dealerDashboardPage);
            _dealerCustomersManagePage = dealerCustomersExistingPage.ClickCreateCustomerPage();
        }

        [When(@"I create and save a new Customer")]
        public void WhenICreateAndSaveANewCustomer()
        {
            string companyName;
            string eMail;
            _dealerCustomersExistingPage = _mpsDealerCustomerStepActions.ProceedCreateAndSaveANewCustomer(_dealerCustomersManagePage, out companyName, out eMail, _contextData.Country);
            _contextData.CustomerInformationName = companyName;
            _contextData.CustomerEmail = eMail;
        }

        [Then(@"I can see the customer created above in the customers & contacts list")]
        public void ThenICanSeeTheCustomerCreatedAboveInTheCustomersContactsList()
        {
            _mpsDealerCustomerStepActions.ThenICanSeeTheCustomerCreatedAboveInTheCustomersContactsList(_dealerCustomersExistingPage, _contextData.CustomerInformationName, _contextData.CustomerEmail);
        }

    }
}
