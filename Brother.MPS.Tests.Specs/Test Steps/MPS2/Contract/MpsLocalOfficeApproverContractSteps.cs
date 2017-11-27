using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Contract;
using Brother.Tests.Specs.StepActions.Proposal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Brother.WebSites.Core.Pages.MPSTwo;

namespace Brother.Tests.Specs.Test_Steps.MPS2.Contract
{
    [Binding]
    class MpsLocalOfficeApproverContractSteps
    {
        private readonly ScenarioContext _context;
        private readonly IWebDriver _driver;
        private readonly IContextData _contextData;
        private readonly PageService _pageService;
        private readonly ICountryService _countryService;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly MpsSignInStepActions _mpsSignInStepActions;
        private readonly MpsDealerProposalStepActions _mpsDealerProposalStepActions;
        private readonly MpsDealerContractStepActions _mpsDealerContractStepActions;
        private readonly MpsLocalOfficeApproverContractStepActions _mpsLocalOfficeApproverContractStepActions;
        private LocalOfficeApproverApprovalContractsAcceptedPage _localOfficeApproverApprovalContractsAcceptedPage;

        public MpsLocalOfficeApproverContractSteps(
            MpsSignInStepActions mpsSignInStepActions,
            MpsDealerProposalStepActions mpsDealerProposalStepActions,
            MpsDealerContractStepActions mpsDealerContractStepActions,
            MpsLocalOfficeApproverContractStepActions mpsLocalOfficeApproverContractStepActions,
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
            _mpsSignInStepActions = mpsSignInStepActions;
            _mpsDealerProposalStepActions = mpsDealerProposalStepActions;
            _mpsDealerContractStepActions = mpsDealerContractStepActions;
            _mpsLocalOfficeApproverContractStepActions = mpsLocalOfficeApproverContractStepActions;
        }

        [When(@"a Cloud MPS Local Office Approver accepts the above proposal")]
        public void WhenACloudMPSLocalOfficeApproverAcceptsTheAboveProposal()
        {
            //This step follows on from a previous scenario step - check context data has been set
            if (_contextData.Country == null || string.IsNullOrEmpty(_contextData.Culture))
            {
                throw new Exception("Context data not set correctly");
            }

            var localOfficeApproverDashBoardPage = _mpsSignInStepActions.SignInAsLocalOfficeApprover(_userResolver.LocalOfficeApproverUsername, _userResolver.LocalOfficeApproverPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var localOfficeApproverApprovalContractsAwaitingAcceptancePage = _mpsLocalOfficeApproverContractStepActions.NavigateToApprovalContractsAwaitingAcceptancePage(localOfficeApproverDashBoardPage);
            var localOfficeApproverApprovalContractsSummaryPage = _mpsLocalOfficeApproverContractStepActions.ClickViewSummary(localOfficeApproverApprovalContractsAwaitingAcceptancePage, _contextData.ProposalId);
            _localOfficeApproverApprovalContractsAcceptedPage = _mpsLocalOfficeApproverContractStepActions.AcceptContract(localOfficeApproverApprovalContractsSummaryPage);
        }

        [Then(@"I navigate to Accepted Contracts page and validate its existence")]
        public void WhenINavigateToAcceptedContractsPageAndValidateItsExistence()
        {
            _mpsLocalOfficeApproverContractStepActions.VerifyAcceptContract(_localOfficeApproverApprovalContractsAcceptedPage, _contextData.ProposalId, _contextData.ProposalName);
        }

    }
}
