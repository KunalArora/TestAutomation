using Brother.Tests.Selenium.Lib;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Extensions;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.Tests.Specs.StepActions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPS2.Common
{
    [Binding]
    public class MpsSignInSteps
    {
        private const string SUBJECT_PAGE_KEY = "subject_page";

        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsSignIn _mpsSignIn;

        public MpsSignInSteps(MpsSignIn mpsSignIn,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            IUserResolver userResolver,
            IUrlResolver urlResolver)
        {
            _context = context;
            _driver = driver;
            _contextData = contextData;
            _pageService = pageService;
            _countryService = countryService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignIn = mpsSignIn;
        }

        [Given(@"I sign into Cloud MPS as a type ""(.*)"" ""(.*)"" from ""(.*)""")]
        public void GivenISignIntoMpsAsBusinessTypeRoleFromCountry(string businessType, string role, string country)
        {
            _contextData.SetBusinessType(businessType);
            _contextData.Country = _countryService.GetByName(country);
            _mpsSignIn.SignInAsDealer(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.AtYourSideUrl));
        }

    }
}
