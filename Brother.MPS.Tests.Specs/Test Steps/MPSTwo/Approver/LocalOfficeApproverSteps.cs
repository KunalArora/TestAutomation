﻿using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Approver
{
    [Binding]
    public class LocalOfficeApproverSteps : BaseSteps
    {

        [Given(@"I navigate to ProposalPage")]
        [When(@"I navigate to ProposalPage")]
        public void WhenINavigateToOfferPage()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
            NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToProposalsPage();
        }

        [Given(@"I navigate to Awaiting Approval screen under Proposals page")]
        [When(@"I navigate to Awaiting Approval screen under Proposals page")]
        public void GivenINavigateToAwaitingApprovalScreenUnderOfferPage()
        {
            CurrentPage.As<LocalOfficeApproverProposalsPage>().NavigateToAwaitingApprovalPage();
        }

        [When(@"I select a proposal from ""(.*)"" of Proposal")]
        public void WhenISelectAProposalFromOfProposal(string name)
        {
           NextPage = CurrentPage.As<LocalOfficeApproverProposalsPage>().NavigateToViewSummary(name);
        }

        [Then(@"I select the proposal on Awaiting Proposal")]
        public void ThenISelectTheProposalOnAwaitingProposal()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverProposalsPage>().NavigateToViewSummary();
        }

        [Then(@"the decline proposal should be displayed under Declined tab")]
        public void ThenTheDeclineProposalShouldBeDisplayedUnderDeclinedTab()
        {
            CurrentPage.As<LocalOfficeApproverProposalsPage>().VerifyDeclinedProposalIsDisplayed();
        }

        [Then(@"the approved proposal should be displayed under Approved tab")]
        public void ThenTheApprovedProposalShouldBeDisplayedUnderApprovedTab()
        {
            CurrentPage.As<LocalOfficeApproverProposalsPage>().VerifyApprovedProposalIsDisplayed();
        }

        [Given(@"I approve the purchase and click proposal created above")]
        public void GivenIApproveThepurchaseAndClickProposalCreatedAbove()
        {
            WhenINavigateToOfferPage();
            GivenINavigateToAwaitingApprovalScreenUnderOfferPage();
            NextPage = CurrentPage.As<LocalOfficeApproverProposalsPage>().NavigateToProposalSummary();
            CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickApproveButton();
            CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().EnterApprovalInformation();
            NextPage = CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickAccpetButton();
        }

        [Then(@"navigate to Local Office Approver contract Awaiting Acceptance page")]
        public void ThenNavigateToLocalOfficeApproverContractAwaitingAcceptancePage()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
            NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToContractsPage();
            CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToAwaitingAcceptancePage();
        }

        [Then(@"the signed purchase and click contract is displayed")]
        public void ThenTheSignedpurchaseAndClickContractIsDisplayed()
        {
            CurrentPage.As<LocalOfficeApproverContractsPage>().IsAwaitingAcceptancePageOpened();
            CurrentPage.As<LocalOfficeApproverContractsPage>().IsContractsSignedByDealerDisplayed();
        }
        
        [When(@"I navigate to Contract Awaiting Acceptance page")]
        [Then(@"I navigate to Contract Awaiting Acceptance page")]
        public void WhenINavigateToContractAwaitingAcceptancePage()
        {
            CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToAwaitingAcceptancePage();
        }

        [When(@"I navigate to Contract Awaiting Acceptance page from Local Office DashBoard")]
        [Then(@"I navigate to Contract Awaiting Acceptance page from Local Office DashBoard")]
        public void WhenINavigateToContractAwaitingAcceptancePageFromLocalOfficeDashBoard()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
            NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToContractsPage();
            WhenINavigateToContractAwaitingAcceptancePage();
        }

        [Then(@"I can view all the contracts that have been signed by dealer")]
        public void ThenICanViewAllTheContractsThatHaveBeenSignedByDealer()
        {
            CurrentPage.As<LocalOfficeApproverContractsPage>().IsContractsSignedByDealerDisplayed();
        }

        [Then(@"I can either reject or approve the contract")]
        public void ThenICanEitherRejectOrApproveTheContract()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToViewSummary();
            CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().IsAcceptButtonAvailable();
            CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().IsRejectButtonAvailable();
        }

        [Then(@"I can successfully approve the contract")]
        public void ThenICanSuccessfullyApproveTheContract()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToViewSummary();
            CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().VerifyThatTheContractDataIsEqualToProposalCreatedByDealer();
            CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickAcceptButton();
            NextPage = CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickFinalAcceptButton();
        }

        [Then(@"I can successfully reject the contract")]
        public void ThenICanSuccessfullyRejectTheContract()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToViewSummary();
            CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickRejectButton();
            CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().SelectRejectionReason();
            NextPage = CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickFinalRejectButton();
        }

        [Then(@"the accepted contract is displayed on contract Accepted screen")]
        public void ThenTheAcceptedContractIsDisplayedOnContractAcceptedScreen()
        {
            CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToAcceptedPage();
            CurrentPage.As<LocalOfficeApproverContractsPage>().IsContractsSignedByDealerDisplayed();
        }

        [Then(@"the rejected contract is displayed on contract Rejected screen")]
        public void ThenTheRejectedContractIsDisplayedOnContractRejectedScreen()
        {
            CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToRejectedPage();
            CurrentPage.As<LocalOfficeApproverContractsPage>().IsContractsSignedByDealerDisplayed();
        }

        [Then(@"the accepted contract is displayed on proposal Approved screen")]
        public void ThenTheAcceptedContractIsDisplayedOnProposalApprovedScreen()
        {

        }

        [Then(@"I should see a list of Proposals on Awaiting Approval Tab")]
        public void ThenIShouldSeeAListOfProposalsOnAwaitingApprovalTab()
        {
            CurrentPage.As<LocalOfficeApproverProposalsPage>().IsProposalListAvailable();
        }

        [When(@"I navigate to Local Office Approver Contracts screen on ""(.*)"" Tab")]
        public void WhenINavigateToLocalOfficeApproverContractsScreenOnTab(string acceptance)
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
            NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToContractsPage();
            switch (acceptance)
            {
                case "Awating Acceptance":
                    CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToAwaitingAcceptancePage();
                    break;

                case "Rejected":
                    CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToRejectedPage();
                    break;

                case "Accepted":
                    CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToAcceptedPage();
                    break;
            }
        }

        [Then(@"I should see a list of Proposals")]
        public void ThenIShouldSeeAListOfProposals()
        {
            CurrentPage.As<LocalOfficeApproverContractsPage>().IsContractsListAvailable();
        }
    }
}
