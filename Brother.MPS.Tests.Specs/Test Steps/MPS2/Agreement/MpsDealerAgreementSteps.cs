using Brother.Tests.Selenium.Lib;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain;
using Brother.Tests.Specs.Extensions;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.Helpers;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement;
using Brother.Tests.Specs.StepActions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.MPS.Tests.Specs.MPS2.Agreement
{
    [Binding]
    public class MpsDealerAgreementSteps
    {
        private const string SUBJECT_PAGE_KEY = "subject_page";

        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly IProposalHelper _proposalHelper;
        private readonly MpsSignIn _mpsSignIn;
        private readonly MpsAgreement _mpsAgreement;

        private DealerDashBoardPage _dealerDashboardPage;
        private DealerAgreementCreateDescriptionPage _dealerAgreementCreateDescriptionPage;
        private DealerAgreementCreateTermAndTypePage _dealerAgreementCreateTermAndTypePage;

        public MpsDealerAgreementSteps(MpsSignIn mpsSignIn,
            MpsAgreement mpsAgreement,
            ScenarioContext context,
            IWebDriver driver,
            MpsContextData contextData,
            PageService pageService,
            ICountryService countryService,
            IUserResolver userResolver,
            IUrlResolver urlResolver,
            IProposalHelper proposalHelper)
        {
            _context = context;
            _driver = driver;
            _contextData = contextData;
            _pageService = pageService;
            _countryService = countryService;
            _userResolver = userResolver;
            _urlResolver = urlResolver;
            _proposalHelper = proposalHelper;
            _mpsSignIn = mpsSignIn;
            _mpsAgreement = mpsAgreement;
        }

        [Given(@"I have navigated to the Create Agreement page as a ""(.*)"" from ""(.*)""")]
        public void GivenIHaveNavigatedToTheCreateAgreementPageAsRoleFromCountry(string role, string country)
        {
            _contextData.SetBusinessType("3");
            _contextData.Country = _countryService.GetByName(country);

            _dealerDashboardPage = _mpsAgreement.SignInAsDealerAndNavigateToDashboard(_userResolver.DealerUsername, _userResolver.DealerPassword, string.Format("{0}/sign-in", _urlResolver.AtYourSideUrl));
            _dealerAgreementCreateDescriptionPage = _mpsAgreement.NavigateToCreateAgreementPage(_dealerDashboardPage);
        }

        [When(@"I enter the agreement description")]
        public void WhenIEnterTheAgreemementDescription()
        {
            _dealerAgreementCreateTermAndTypePage = _mpsAgreement.PopulateAgreementDescriptionAndProceed(_dealerAgreementCreateDescriptionPage, _proposalHelper.GenerateProposalName(), "", "", "");
        }

        [When(@"I select ""(.*)"" as the Usage Type and I select ""(.*)"" as the Contract Term")]
        public void WhenISelectTheUsageTypeAndContractTerm(string usageType, string contractTerm)
        {
            _mpsAgreement.PopulateAgreementTermAndTypeAndProceed(_dealerAgreementCreateTermAndTypePage, usageType, contractTerm, "");
        }

    }
}
