using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Bank
{
    [Binding]
    public class StepDefinition1 : BaseSteps
    {

        [Given(@"I navigate to OfferPage")]
        public void WhenINavigateToOfferPage()
        {
           NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToOffersPage();
        }

        [Given(@"I navigate to Awaiting Approval screen under Offer page")]
        public void GivenINavigateToAwaitingApprovalScreenUnderOfferPage()
        {
            CurrentPage.As<BankOffersPage>().NavigateToAwaitingApprovalPage();
        }

        [When(@"I select a proposal from ""(.*)"" of Proposal")]
        public void WhenISelectAProposalFromOfProposal(string name)
        {
           NextPage = CurrentPage.As<BankOffersPage>().NavigateToViewSummary(name);
        }

        [Then(@"I should be able to decline that proposal")]
        public void ThenIShouldBeAbleToDeclineThatProposal()
        {
            CurrentPage.As<BankProposalsSummaryPage>().ClickDeclineButton();
            CurrentPage.As<BankProposalsSummaryPage>().SelectDeclineReason("Expired");
            NextPage = CurrentPage.As<BankProposalsSummaryPage>().ClickRejectButton();
        }

        [Then(@"the decline proposal should be displayed under Declined tab")]
        public void ThenTheDeclineProposalShouldBeDisplayedUnderDeclinedTab()
        {
            CurrentPage.As<BankOffersPage>().VerifyDeclinedProposalIsDisplayed();
        }

    }
}
