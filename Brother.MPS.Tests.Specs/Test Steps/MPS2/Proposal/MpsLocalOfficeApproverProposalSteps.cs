﻿using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Constants;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.Tests.Specs.StepActions.Proposal;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
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
        private readonly MpsDealerProposalStepActions _refMpsDealerProposalStepActions;

        //page objects used by these steps
        private LocalOfficeApproverApprovalProposalsApprovedPage _localOfficeApproverApprovalProposalsApprovedPage;
        private LocalOfficeApproverApprovalContractsAcceptedPage _localOfficeApproverApprovalContractsAcceptedPage;
        private LocalOfficeApproverApprovalProposalsDeclinedPage _localOfficeApproverApprovalProposalsDeclinedPage;

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

        [When(@"a Cloud MPS Local Office Approver approves the above proposal")]
        public void WhenACloudMpsLocalOfficeApproverApprovesTheAboveProposal()
        {
            //This step follows on from a previous scenario step - check context data has been set
            if (_contextData.Country == null || string.IsNullOrEmpty(_contextData.Culture))
            {
                throw new Exception("Context data not set correctly");
            }

            var localOfficeApproverDashBoardPage = _mpsSignInStepActions.SignInAsLocalOfficeApprover(_userResolver.LocalOfficeApproverUsername, _userResolver.LocalOfficeApproverPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var localOfficeApproverApprovalPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToApprovalDashboard(localOfficeApproverDashBoardPage);
            var localOfficeApproverApprovalProposalsPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToApprovalListPage(localOfficeApproverApprovalPage);
            var localOfficeApproverApprovalProposalsSummaryPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToViewSummary(localOfficeApproverApprovalProposalsPage,_contextData.ProposalId);
            _localOfficeApproverApprovalProposalsApprovedPage = _mpsLocalOfficeApproverProposalStepActions.ApproveProposal(localOfficeApproverApprovalProposalsSummaryPage);
        }

        [When(@"a Cloud MPS Local Office Approver declines the above proposal")]
        public void WhenACloudMPSLocalOfficeApproverDeclinesTheAboveProposal()
        {
            //This step follows on from a previous scenario step - check context data has been set
            if (_contextData.Country == null || string.IsNullOrEmpty(_contextData.Culture))
            {
                throw new Exception("Context data not set correctly");
            }

            var proposalDeclineReasonExpired = _translationService.GetProposalDeclineReasonText(TranslationKeys.ProposalDeclineReason.Expired, _contextData.Culture);
            var localOfficeApproverDashBoardPage = _mpsSignInStepActions.SignInAsLocalOfficeApprover(_userResolver.LocalOfficeApproverUsername, _userResolver.LocalOfficeApproverPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));
            var localOfficeApproverApprovalPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToApprovalDashboard(localOfficeApproverDashBoardPage);
            var localOfficeApproverApprovalProposalsPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToApprovalListPage(localOfficeApproverApprovalPage);
            var localOfficeApproverApprovalProposalsSummaryPage = _mpsLocalOfficeApproverProposalStepActions.NavigateToViewSummary(localOfficeApproverApprovalProposalsPage, _contextData.ProposalId);
            _localOfficeApproverApprovalProposalsDeclinedPage = _mpsLocalOfficeApproverProposalStepActions.DeclineProposal(localOfficeApproverApprovalProposalsSummaryPage, proposalDeclineReasonExpired);
        }

    }
}
