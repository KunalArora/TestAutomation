using System;
using System.Runtime.Remoting;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.MPS.Tests.Specs.MPS2.Proposal
{
    [Binding]
    public class MpsLocalOfficeApproverProposalSteps
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
        private readonly MpsLocalOfficeApproverProposalStepActions _mpsLocalOfficeApproverProposalStepActions;

        //page objects used by these steps
        private LocalOfficeApproverDashBoardPage _localOfficeApproverDashBoardPage;
        private LocalOfficeApproverApprovalPage _localOfficeApproverApproverApprovalPage;
        private LocalOfficeApproverProposalsPage _localOfficeApproverProposalsPage;
        private LocalOfficeApproverProposalsSummaryPage _localOfficeApproverProposalsSummaryPage;

        public MpsLocalOfficeApproverProposalSteps(MpsSignInStepActions mpsSignInStepActions,
            MpsLocalOfficeApproverProposalStepActions mpsLocalOfficeApproverProposalStepActions,
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
            _mpsLocalOfficeApproverProposalStepActions = mpsLocalOfficeApproverProposalStepActions;
        }

        [When(@"a Cloud MPS Local Office Approver approves the proposal")]
        public void WhenACloudMpsLocalOfficeApproverApprovesTheProposal()
        {
            //This step follows on from a previous scenario step - check context data has been set
            if (_contextData.Country == null || string.IsNullOrEmpty(_contextData.Culture))
            {
                throw new Exception("Context data not set correctly");
            }

            _localOfficeApproverDashBoardPage = _mpsSignInStepActions.SignInAsLocalOfficeApprover(_userResolver.LocalOfficeAdminUsername, _userResolver.LocalOfficeApproverPassword, string.Format("{0}/sign-in", _urlResolver.AtYourSideUrl));
            _localOfficeApproverApproverApprovalPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToApprovalDashboard(_localOfficeApproverDashBoardPage);
            _localOfficeApproverProposalsPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToApprovalListPage(_localOfficeApproverApproverApprovalPage);
            //select proposal based on context data and view summary
            //approve proposal
        }
    }
}
