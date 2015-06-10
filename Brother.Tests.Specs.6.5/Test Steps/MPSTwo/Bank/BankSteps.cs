﻿using System;
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

        [Given(@"I approve the proposal created above")]
        public void GivenIApproveTheProposalCreatedAbove()
        {
            WhenINavigateToOfferPage();
            GivenINavigateToAwaitingApprovalScreenUnderOfferPage();
            NextPage = CurrentPage.As<BankOffersPage>().NavigateToProposalSummary();
            CurrentPage.As<BankProposalsSummaryPage>().ClickApproveButton();
            CurrentPage.As<BankProposalsSummaryPage>().EnterApprovalInformation();
            NextPage = CurrentPage.As<BankProposalsSummaryPage>().ClickAccpetButton();
        }

        [Then(@"navigate to bank contract Awaiting Acceptance page")]
        public void ThenNavigateToBankContractAwaitingAcceptancePage()
        {
            NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToContractApprovedProposalPage();
            CurrentPage.As<BankContractsPage>().NavigateToAwaitingAcceptancePage();
        }

        [Then(@"the signed contract is displayed")]
        public void ThenTheSignedContractIsDisplayed()
        {
            CurrentPage.As<BankContractsPage>().IsAwaitingAcceptancePageOpened();
            CurrentPage.As<BankContractsPage>().IsSignedContractDisplayedUnderAwaitingAcceptancePage();
        }
        
        [When(@"I navigate to Contract Awaiting Acceptance page")]
        public void WhenINavigateToContractAwaitingAcceptancePage()
        {
            NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToContractsPage();
            CurrentPage.As<BankContractsPage>().NavigateToAwaitingAcceptancePage();
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


    }
}
