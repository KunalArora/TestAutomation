using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System.Collections.Generic;
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
            IRuntimeSettings runtimeSettings,
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

        public LocalOfficeApproverReportsDataQueryPage NavigateToReportsDataQueryPage(LocalOfficeApproverDashBoardPage localOfficeApproverDashBoardPage)
        {
            ClickSafety(localOfficeApproverDashBoardPage.LocalApprovalReportingElement, localOfficeApproverDashBoardPage);
            var localOfficeApproverReportsDashboardPage =  PageService.GetPageObject<LocalOfficeApproverReportsDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
            ClickSafety( localOfficeApproverReportsDashboardPage.DataQueryElement, localOfficeApproverReportsDashboardPage);
            return PageService.GetPageObject<LocalOfficeApproverReportsDataQueryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public LocalOfficeApproverReportsProposalSummaryPage ClidkOnValidateAndApplySpecialPricing(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage)
        {
            localOfficeApproverApprovalSpecialPricingPage.SeleniumHelper.WaitUntil(d => {
                var isDisplayed = localOfficeApproverApprovalSpecialPricingPage.NextButton.Displayed;
                var isHidden = localOfficeApproverApprovalSpecialPricingPage.NextButton.GetAttribute("class").Contains("hidden");
                if (isDisplayed == false || isHidden) return true; 
                ClickSafety(localOfficeApproverApprovalSpecialPricingPage.NextButton, localOfficeApproverApprovalSpecialPricingPage);
                return false;
            }, RuntimeSettings.DefaultFindElementTimeout);
            ClickSafety(localOfficeApproverApprovalSpecialPricingPage.ValidateButton, localOfficeApproverApprovalSpecialPricingPage);
            localOfficeApproverApprovalSpecialPricingPage.EnterAdditionalAuditInformation(RuntimeSettings.DefaultFindElementTimeout);
            ClickSafety(localOfficeApproverApprovalSpecialPricingPage.ApplySpecialPricing, localOfficeApproverApprovalSpecialPricingPage);
            return PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);            
        }

        public LocalOfficeApproverReportsProposalSummaryPage NavigateToReportsProposalSummaryPage(LocalOfficeApproverReportsDataQueryPage localOfficeApproverReportsDataQueryPage, int proposalId )
        {
            var proposalIdString = proposalId.ToString();
            localOfficeApproverReportsDataQueryPage.ClickOnSearchedProposal(proposalId, RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

        public void PopulateSpecialPricingInstallation(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage, IEnumerable<SpecialPriceParameter> specialPriceList)
        {
            localOfficeApproverApprovalSpecialPricingPage.SwitchNavInstallTab(RuntimeSettings.DefaultFindElementTimeout);
            foreach (var specialPrice in specialPriceList)
            {
                localOfficeApproverApprovalSpecialPricingPage.EnterSpecialPriceInstallation(specialPrice, RuntimeSettings.DefaultFindElementTimeout);
            }
        }
        public void PopulateSpecialPricingService(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage, IEnumerable<SpecialPriceParameter> specialPriceList)
        {
            localOfficeApproverApprovalSpecialPricingPage.SwitchNavServiceTab(RuntimeSettings.DefaultFindElementTimeout);
            foreach (var specialPrice in specialPriceList)
            {
                localOfficeApproverApprovalSpecialPricingPage.EnterSpecialPriceService(specialPrice, RuntimeSettings.DefaultFindElementTimeout);
            }
        }

        public void PopulateSpecialPricingClickPrice(LocalOfficeApproverApprovalSpecialPricingPage localOfficeApproverApprovalSpecialPricingPage, IEnumerable<SpecialPriceParameter> specialPriceClickList)
        {
            localOfficeApproverApprovalSpecialPricingPage.SwitchNavClickTab(RuntimeSettings.DefaultFindElementTimeout);
            foreach( var specialPrice in specialPriceClickList) {
                localOfficeApproverApprovalSpecialPricingPage.EnterSpecialPriceClick(specialPrice, RuntimeSettings.DefaultFindElementTimeout);
            }
            
        }

        public LocalOfficeApproverApprovalSpecialPricingPage ClickOnSpecialPricing(LocalOfficeApproverReportsProposalSummaryPage localOfficeApproverReportsProposalSummaryPage)
        {
            ClickSafety(localOfficeApproverReportsProposalSummaryPage.ButtonSpecialPricing, localOfficeApproverReportsProposalSummaryPage);
            return PageService.GetPageObject<LocalOfficeApproverApprovalSpecialPricingPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
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


        public LocalOfficeApproverApprovalProposalsDeclinedPage DeclineProposal(LocalOfficeApproverApprovalProposalsSummaryPage localOfficeApproverApprovalProposalsSummaryPage, string proposalDeclineReasonExpired)
        {
            localOfficeApproverApprovalProposalsSummaryPage.DeclineProposal(RuntimeSettings.DefaultFindElementTimeout, proposalDeclineReasonExpired);
            return PageService.GetPageObject<LocalOfficeApproverApprovalProposalsDeclinedPage>(RuntimeSettings.DefaultPageObjectTimeout, _localOfficeApproverWebDriver);
        }

    }
}
