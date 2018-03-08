using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Proposal
{
    [Binding]
    public class MpsBankProposalSteps
    {
        private readonly ScenarioContext _context;
        private readonly MpsContextData _contextData;
        private readonly ICountryService _countryService;
        private readonly IWebDriver _driver;
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private readonly PageService _pageService;
        private readonly ITranslationService _translationService;
        private readonly IUrlResolver _urlResolver;
        private readonly IUserResolver _userResolver;

        public MpsBankProposalSteps(
            MpsSignInStepActions mpsSignInStepActions,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            ITranslationService translationService
            )
        {
            _context = context;
            _driver = driver;
            _contextData = contextData;
            _pageService = pageService;
            _countryService = countryService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _mpsSignInStepActions = mpsSignInStepActions;
            _translationService = translationService;
        }
        [When(@"a Cloud MPS Bank release the above proposal")]
        public void WhenACloudMPSBankReleaseTheAboveProposal()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
