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
        [When(@"I navigate to OfferPage")]
        public void WhenINavigateToOfferPage()
        {
            NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToOffersPage();
        }

        [Given(@"I navigate to Awaiting Approval screen under Offer page")]
        [When(@"I navigate to Awaiting Approval screen under Offer page")]
        public void GivenINavigateToAwaitingApprovalScreenUnderOfferPage()
        {
            CurrentPage.As<BankOffersPage>().NavigateToAwaitingApprovalPage();
        }

        [When(@"I select a proposal from ""(.*)"" of Proposal")]
        public void WhenISelectAProposalFromOfProposal(string name)
        {
           NextPage = CurrentPage.As<BankOffersPage>().NavigateToViewSummary(name);
        }

        [When(@"I select the proposal on Awaiting Proposal")]
        [Then(@"I select the proposal on Awaiting Proposal")]
        public void ThenISelectTheProposalOnAwaitingProposal()
        {
            NextPage = CurrentPage.As<BankOffersPage>().NavigateToViewSummary();
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
            CurrentPage.As<BankContractsPage>().IsContractsSignedByDealerDisplayed();
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
            CurrentPage.As<BankContractsSummaryPage>().VerifyThatTheContractDataIsEqualToProposalCreatedByDealer();
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
            CurrentPage.As<BankContractsPage>().IsContractsSignedByDealerDisplayed();
        }

        [Then(@"I can successfully download a Contract PDF")]
        public void ThenICanSuccessfullyDownloadAContractPDF()
        {
            CurrentPage.As<BankContractsPage>().DownloadPDFOnBankContractPages();
        }

        [Then(@"I can successfully download a Contract Invoice PDF")]
        public void ThenICanSuccessfullyDownloadAContractInvoicePDF()
        {
           CurrentPage.As<BankContractsPage>().DownloadInvoicePDFOnBankContractPages();
        }

        [When(@"I navigate to bank contract Rejected page")]
        public void WhenINavigateToBankContractRejectedPage()
        {
            NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToContractsPage();
            CurrentPage.As<BankContractsPage>().NavigateToRejectedPage();
        }

        [Then(@"I should see a list of Offers on Awaiting Approbal Tab")]
        public void ThenIShouldSeeAListOfOffersOnAwaitingApprobalTab()
        {
            CurrentPage.As<BankOffersPage>().IsProposalListAvailable();
        }

        [When(@"I navigate to Contracts screen on ""(.*)"" Tab")]
        public void WhenINavigateToContractsScreenOnTab(string p0)
        {
            NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToContractsPage();
            switch (p0)
            {
                case "Awating Acceptance":
                    CurrentPage.As<BankContractsPage>().NavigateToAwaitingAcceptancePage();
                    break;

                case "Rejected":
                    CurrentPage.As<BankContractsPage>().NavigateToRejectedPage();
                    break;

                case "Accepted":
                    CurrentPage.As<BankContractsPage>().NavigateToAcceptedPage();
                    break;
            }
        }

        [Then(@"I should see a list of Offers")]
        public void ThenIShouldSeeAListOfOffers()
        {
            CurrentPage.As<BankContractsPage>().IsContractsListAvailable();
        }
    }
}
