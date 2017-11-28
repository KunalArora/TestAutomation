using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.Base;

namespace Brother.Tests.Specs.StepActions.Proposal
{
    public class MpsLocalOfficeApproverProposalStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IWebDriver _localOfficeApproverWebDriver;

        public MpsLocalOfficeApproverProposalStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            RuntimeSettings runtimeSettings,
            MpsSignInStepActions mpsSignIn)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _localOfficeApproverWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeApprover);
        }

        public LocalOfficeApproverDashBoardPage SignInAsLocalOfficeApproverAndNavigateToDashboard(string email, string password, string url)
        {
            return _mpsSignIn.SignInAsLocalOfficeApprover(email, password, url);
        }

        public LocalOfficeApproverApprovalPage NavigateToApprovalDashboard(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            ClickSafety(localOfficeApproverDashBoardPage.ApprovalTabElement, localOfficeApproverDashBoardPage);
            return PageService.GetPageObject<LocalOfficeApproverApprovalPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverProposalsPage NavigateToApprovalListPage(LocalOfficeApproverApprovalPage localOfficeApproverApprovalPage)
        {
            ClickSafety( localOfficeApproverApprovalPage.ProposalLinkElement, localOfficeApproverApprovalPage );
            return PageService.GetPageObject<LocalOfficeApproverProposalsPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalProposalsSummaryPage NavigateToViewSummary(LocalOfficeApproverProposalsPage localOfficeApproverProposalsPage, int proposalId)
        {
            localOfficeApproverProposalsPage.ClickOnSummaryPage(proposalId.ToString(), RuntimeSettings.DefaultFindElementTimeout, _localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverApprovalProposalsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalProposalsApprovedPage ApproveProposal(LocalOfficeApproverApprovalProposalsSummaryPage localOfficeApproverAprovalProposalsSummaryPage)
        {
            localOfficeApproverAprovalProposalsSummaryPage.ClickOnAccept(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<LocalOfficeApproverApprovalProposalsApprovedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
            
        }

        public LocalOfficeApproverApprovalContractsSummaryPage ClickViewSummary(LocalOfficeApproverContractsAwaitingAcceptancePage localofficeApproverApprovalContractsAwaitingAcceptancePage, int proposalId)
        {

            localofficeApproverApprovalContractsAwaitingAcceptancePage.ClickOnViewSummary(proposalId, RuntimeSettings.DefaultFindElementTimeout, _localOfficeApproverWebDriver);
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverApprovalContractsAcceptedPage AcceptContract(LocalOfficeApproverApprovalContractsSummaryPage localOfficeApproverApprovalContractsSummaryPage)
        {
            localOfficeApproverApprovalContractsSummaryPage.OnClickAccept(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<LocalOfficeApproverApprovalContractsAcceptedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void VerifyAcceptContract(LocalOfficeApproverApprovalContractsAcceptedPage _localOfficeApproverApprovalContractsAcceptedPage, int proposalId, string proposalName)
        {
            _localOfficeApproverApprovalContractsAcceptedPage.VerifyContractFilter(proposalId, proposalName, RuntimeSettings.DefaultFindElementTimeout);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }

    }
}
