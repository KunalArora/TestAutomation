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
    public class BankSteps : BaseSteps
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

        [Then(@"I select the proposal on Awaiting Proposal")]
        public void ThenISelectTheProposalOnAwaitingProposal()
        {
            NextPage = CurrentPage.As<BankOffersPage>().NavigateToViewSummary();
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

        [Then(@"the approved proposal should be displayed under Approved tab")]
        public void ThenTheApprovedProposalShouldBeDisplayedUnderApprovedTab()
        {
            CurrentPage.As<BankOffersPage>().VerifyApprovedProposalIsDisplayed();
        }

        [Then(@"I should be able to approve that proposal")]
        public void ThenIShouldBeAbleToApproveThatProposal()
        {
            CurrentPage.As<BankProposalsSummaryPage>().ClickApproveButton();
            CurrentPage.As<BankProposalsSummaryPage>().EnterApprovalInformation();
            CurrentPage.As<BankProposalsSummaryPage>().ClickAccpetButton();
            //NextPage = CurrentPage.As<BankProposalsSummaryPage>().ClickAccpetButton();
        }

        [When(@"I navigate to Contract Awaiting Acceptance page")]
        [Then(@"I navigate to Contract Awaiting Acceptance page")]
        public void WhenINavigateToContractAwaitingAcceptancePage()
        {
            CurrentPage.As<BankContractsPage>().NavigateToAwaitingAcceptancePage();
        }

        [When(@"I navigate to Contract Awaiting Acceptance page from Bank DashBoard")]
        [Then(@"I navigate to Contract Awaiting Acceptance page from Bank DashBoard")]
        public void WhenINavigateToContractAwaitingAcceptancePageFromBankDashBoard()
        {
            NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToContractsPage();
            WhenINavigateToContractAwaitingAcceptancePage();
        }

        [Then(@"I can view all the contracts that have been signed by dealer")]
        public void ThenICanViewAllTheContractsThatHaveBeenSignedByDealer()
        {
            CurrentPage.As<BankContractsPage>().IsContractsSignedByDealerDisplayed();
        }

        [Then(@"I can either reject or approve the contract")]
        public void ThenICanEitherRejectOrApproveTheContract()
        {
            NextPage = CurrentPage.As<BankContractsPage>().NavigateToViewSummary();
            CurrentPage.As<BankContractsSummaryPage>().IsAcceptButtonAvailable();
            CurrentPage.As<BankContractsSummaryPage>().IsRejectButtonAvailable();
        }

        [Then(@"I can successfully approve the contract")]
        public void ThenICanSuccessfullyApproveTheContract()
        {
            NextPage = CurrentPage.As<BankContractsPage>().NavigateToViewSummary();
            CurrentPage.As<BankContractsSummaryPage>().ClickAcceptButton();
            NextPage = CurrentPage.As<BankContractsSummaryPage>().ClickFinalAcceptButton();
        }

        [Then(@"I can successfully reject the contract")]
        public void ThenICanSuccessfullyRejectTheContract()
        {
            NextPage = CurrentPage.As<BankContractsPage>().NavigateToViewSummary();
            CurrentPage.As<BankContractsSummaryPage>().ClickRejectButton();
            CurrentPage.As<BankContractsSummaryPage>().SelectRejectionReason("Expired");
            NextPage = CurrentPage.As<BankContractsSummaryPage>().ClickFinalRejectButton();
        }

        [Then(@"the accepted contract is displayed on contract Accepted screen")]
        public void ThenTheAcceptedContractIsDisplayedOnContractAcceptedScreen()
        {
            CurrentPage.As<BankContractsPage>().NavigateToAcceptedPage();
            CurrentPage.As<BankContractsPage>().IsContractsSignedByDealerDisplayed();
        }

        [Then(@"the rejected contract is displayed on contract Rejected screen")]
        public void ThenTheRejectedContractIsDisplayedOnContractRejectedScreen()
        {
            CurrentPage.As<BankContractsPage>().NavigateToRejectedPage();
            CurrentPage.As<BankContractsPage>().IsContractsSignedByDealerDisplayed();
        }

        [Then(@"the accepted contract is displayed on proposal Approved screen")]
        public void ThenTheAcceptedContractIsDisplayedOnProposalApprovedScreen()
        {

        }




    }
}
