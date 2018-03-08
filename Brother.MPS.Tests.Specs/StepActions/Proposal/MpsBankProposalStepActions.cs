using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Proposal
{
    public class MpsBankProposalStepActions : StepActionBase
    {
        private readonly IWebDriver _webDriver;

        public MpsBankProposalStepActions(
            IWebDriverFactory webDriverFactory, 
            IContextData contextData, 
            IPageService pageService, 
            ScenarioContext scenarioContext, 
            IUrlResolver urlResolver, 
            ILoggingService loggingService, 
            IRuntimeSettings runtimeSettings) 
            : base(webDriverFactory, contextData, pageService, scenarioContext, urlResolver, loggingService, runtimeSettings)
        {
            _webDriver = WebDriverFactory.GetWebDriverInstance(UserType.Bank);

        }

        public BankProposalsAwaitingApprovalPage NavigateToProposalsAwaitingApprovalPage(BankDashBoardPage bankDashBoardPage)
        {
            ClickSafety(bankDashBoardPage.OffersLinkElement, bankDashBoardPage,true);
            return PageService.GetPageObject<BankProposalsAwaitingApprovalPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public BankProposalsSummaryPage ClickViewSummary(BankProposalsAwaitingApprovalPage bankProposalsAwaitingApprovalPage)
        {
            LoggingService.WriteLogOnMethodEntry(bankProposalsAwaitingApprovalPage);
            int proposalId = ContextData.ProposalId;
            bankProposalsAwaitingApprovalPage.ClickOnViewSummary(proposalId, _webDriver);
            return PageService.GetPageObject<BankProposalsSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);
        }

        public BankProposalsApprovedPage ClickOnAccept(BankProposalsSummaryPage bankProposalsSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(bankProposalsSummaryPage);
            ClickSafety(bankProposalsSummaryPage.ApproveButtonElement, bankProposalsSummaryPage);
            bankProposalsSummaryPage.EnterApprovalInformation(); // de:Freigabeinformationen
            ClickSafety(bankProposalsSummaryPage.AcceptButtonElement, bankProposalsSummaryPage,true);
            return PageService.GetPageObject<BankProposalsApprovedPage>(RuntimeSettings.DefaultPageObjectTimeout, _webDriver);

        }


        private void ClickSafety(IWebElement element, IPageObject pageObject, bool IsUntilUrlChanges = false)
        {
            LoggingService.WriteLogOnMethodEntry(element, pageObject);
            pageObject.SeleniumHelper.ClickSafety(element, IsUntilUrlChanges: IsUntilUrlChanges);
        }

    }
}
