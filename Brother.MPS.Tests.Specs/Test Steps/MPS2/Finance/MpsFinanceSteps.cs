using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Finance;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Finance
{
    [Binding]
    public class MpsFinanceSteps
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly ITranslationService _translationService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsFinanceStepActions _mpsFinanceStepActions;
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private LocalOfficeFinanceAccrualsReportPage _localOfficeFinanceAccrualsReportPage;
        private LocalOfficeFinanceDashBoardPage _localOfficeFinanceDashBoardPage;

        public MpsFinanceSteps(
            MpsSignInStepActions mpsSignInStepActions,
            MpsFinanceStepActions mpsFinanceStepActions,
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
            _mpsFinanceStepActions = mpsFinanceStepActions;
            _mpsSignInStepActions = mpsSignInStepActions;
        }

        [Given(@"Country is ""(.*)""")]
        public void GivenCountryIs(string country)
        {
            _contextData.SetBusinessType("1");
            _contextData.Country = _countryService.GetByName(country);
            if (_contextData.Country.Cultures.Count != 1)
            {
                throw new ArgumentException("can not auto select culture. please call alternate some garkin");
            }
            _contextData.Culture = _contextData.Country.Cultures[0];
        }

        [When(@"a Cloud MPS Finance navigate to Accruals Page")]
        public void WhenACloudMPSFinanceNavigateToAccrualsPage()
        {
            var localOfficeFinanceDashBoardPage = _mpsSignInStepActions.SignInAsFinance(_userResolver.FinanceUsername, _userResolver.FinancePassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            _localOfficeFinanceAccrualsReportPage = _mpsFinanceStepActions.NavigateToAccrualsPage(localOfficeFinanceDashBoardPage);
        }

        [When(@"a Cloud MPS Finance select run at date and click run report")]
        public void WhenACloudMPSFinanceSelectRunAtDateAndClickRunReport()
        {
            string zipFilePath = _mpsFinanceStepActions.ClickOnRunReport(_localOfficeFinanceAccrualsReportPage, DateTime.Now.AddDays(-1));
            _mpsFinanceStepActions.DeleteFile(zipFilePath);
            _localOfficeFinanceDashBoardPage = _mpsFinanceStepActions.NavigateToDashBoardPage(_localOfficeFinanceAccrualsReportPage);
        }


    }
}
