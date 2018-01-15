using Brother.Tests.Common.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions;
using Brother.Tests.Specs.StepActions.Common;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPS2.Common
{
    [Binding]
    public class MpsSignInSteps
    {
        private const string SUBJECT_PAGE_KEY = "subject_page";

        private readonly ScenarioContext _context;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsSignInStepActions _mpsSignIn;

        public MpsSignInSteps(MpsSignInStepActions mpsSignIn,
            ScenarioContext context,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            IUserResolver userResolver,
            IUrlResolver urlResolver)
        {
            _context = context;
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
            if (role == "Cloud MPS Dealer")
            {
                _mpsSignIn.SignInAsDealer(_userResolver.DealerUsername, _userResolver.DealerPassword,
                    string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            }
            else
            {
                _mpsSignIn.SignInAsLocalOfficeApprover(_userResolver.LocalOfficeApproverUsername, _userResolver.LocalOfficeApproverPassword,
                    string.Format("{0}/sign-in", _urlResolver.BaseUrl));                
            }
        }

    }
}
