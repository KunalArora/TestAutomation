using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Specs.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Approver
{
    [Binding]
    public class ApproverSteps : BaseSteps
    {
        private bool PurchaseAndClick = false;
        private bool LeaseAndClick = false;
        private bool PayAsYouGo = false;
        private bool MinimumVolume = false;
        public ApproverSteps()
        {
            string ContractType = "";
            string UsageType = "";
            foreach (KeyValuePair<string, object> kv in Selenium.Lib.Support.HelperClasses.SpecFlow.GetEnumerator())
            {
                if (kv.Key.Equals("CreateContractType"))
                    ContractType = kv.Value.ToString();
                if (kv.Key.Equals("CreateUsageType"))
                    UsageType = kv.Value.ToString();
            }
            if (ContractType.Equals("Purchase & Click with Service") || ContractType.Equals(string.Empty))
                PurchaseAndClick = true;
            if (ContractType.Equals("Lease & Click with Service"))
                LeaseAndClick = true;
            if (UsageType.Equals("Minimum Volume"))
                MinimumVolume = true;
            if (UsageType.Equals("Pay As You Go"))
                PayAsYouGo = true;

        }

        [Given(@"Approver navigate to ProposalsPage")]
        public void WhenApproverNavigateToOfferPage()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToOffersPage();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
                NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToProposalsPage();
            }
        }

        [Given(@"Approver navigate to Awaiting Approval screen under Proposals page")]
        public void GivenApproverNavigateToAwaitingApprovalScreenUnderProposalsPage()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankOffersPage>().NavigateToAwaitingApprovalPage();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsPage>().NavigateToAwaitingApprovalPage();
            }
        }

        [When(@"Approver select the proposal on Awaiting Proposal")]
        [Then(@"Approver select the proposal on Awaiting Proposal")]
        public void ThenApproverSelectTheProposalOnAwaitingProposal()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankOffersPage>().NavigateToViewSummary();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverProposalsPage>().NavigateToViewSummary();
            }
        }

        [Then(@"Approver should be able to decline that proposal with ""(.*)""")]
        public void ThenApproverShouldBeAbleToDeclineThatProposalWith(string reason)
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<BankProposalsSummaryPage>().SelectDeclineReason(reason);
                NextPage = CurrentPage.As<BankProposalsSummaryPage>().ClickRejectButton();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().SelectDeclineReason(reason);
                NextPage = CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickRejectButton();
            }
        }


        [Then(@"Approver should be able to decline that proposal")]
        public void ThenApproverShouldBeAbleToDeclineThatProposal()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<BankProposalsSummaryPage>().SelectDeclineReason("Expired");
                NextPage = CurrentPage.As<BankProposalsSummaryPage>().ClickRejectButton();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().SelectDeclineReason("Expired");
                NextPage = CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickRejectButton();
            }
        }

        [When(@"Approver navigate to Contract Awaiting Acceptance page from Dashboard")]
        [Then(@"Approver navigate to Contract Awaiting Acceptance page from Dashboard")]
        public void WhenApproverNavigateToContractAwaitingAcceptancePage()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToContractsPage();
                CurrentPage.As<BankContractsPage>().NavigateToAwaitingAcceptancePage();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
                NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToContractsPage();
                CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToAwaitingAcceptancePage();
            }
        }

        [Then(@"the decline proposal should be displayed under Declined tab by Approver")]
        public void ThenTheDeclineProposalShouldBeDisplayedUnderDeclinedTabByApprover()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankOffersPage>().VerifyDeclinedProposalIsDisplayed();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsPage>().VerifyDeclinedProposalIsDisplayed();
            }
        }

        [Then(@"Approver can view all the contracts that have been signed by dealer")]
        public void ThenApproverCanViewAllTheContractsThatHaveBeenSignedByDealer()
        {
            if (LeaseAndClick)
                CurrentPage.As<BankContractsPage>().IsContractsSignedByDealerDisplayed();
            else if (PurchaseAndClick)
                CurrentPage.As<LocalOfficeApproverContractsPage>().IsContractsSignedByDealerDisplayed();
        }

        [Then(@"Approver can either reject or approve the contract")]
        public void ThenApproverCanEitherRejectOrApproveTheContract()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankContractsPage>().NavigateToViewSummary();
                CurrentPage.As<BankContractsSummaryPage>().IsAcceptButtonAvailable();
                CurrentPage.As<BankContractsSummaryPage>().IsRejectButtonAvailable();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToViewSummary();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().IsAcceptButtonAvailable();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().IsRejectButtonAvailable();
            }
        }

        [Then(@"Approver can successfully approve the contract")]
        public void ThenApproverCanSuccessfullyApproveTheContract()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankContractsPage>().NavigateToViewSummary();
//                CurrentPage.As<BankContractsSummaryPage>().VerifyThatTheContractDataIsEqualToProposalCreatedByDealer();
                CurrentPage.As<BankContractsSummaryPage>().ClickAcceptButton();
                NextPage = CurrentPage.As<BankContractsSummaryPage>().ClickFinalAcceptButton();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToViewSummary();
//                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().VerifyThatTheContractDataIsEqualToProposalCreatedByDealer();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickAcceptButton();
                NextPage = CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickFinalAcceptButton();
            }
        }

        [Then(@"Approver can successfully reject the contract")]
        public void ThenApproverCanSuccessfullyRejectTheContract()
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankContractsPage>().NavigateToViewSummary();
                CurrentPage.As<BankContractsSummaryPage>().ClickRejectButton();
                CurrentPage.As<BankContractsSummaryPage>().SelectRejectionReason("Expired");
                NextPage = CurrentPage.As<BankContractsSummaryPage>().ClickFinalRejectButton();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToViewSummary();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickRejectButton();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().SelectRejectionReason("Expired");
                NextPage = CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickFinalRejectButton();  
            }
        }

        [Then(@"Approver can successfully reject the contract with ""(.*)"" option")]
        public void ThenApproverCanSuccessfullyRejectTheContractWithOption(string option)
        {
            if (LeaseAndClick)
            {
                NextPage = CurrentPage.As<BankContractsPage>().NavigateToViewSummary();
                CurrentPage.As<BankContractsSummaryPage>().ClickRejectButton();
                CurrentPage.As<BankContractsSummaryPage>().SelectRejectionReason(option);
                NextPage = CurrentPage.As<BankContractsSummaryPage>().ClickFinalRejectButton();
            }
            else if (PurchaseAndClick)
            {
                NextPage = CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToViewSummary();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickRejectButton();
                CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().SelectRejectionReason(option);
                NextPage = CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().ClickFinalRejectButton();
            }
        }

        [Given(@"the contract created above is approved")]
        [Then(@"the contract created above is approved")]
        public void ThenTheContractCreatedAboveIsApproved()
        {
             var instance3 = new AccountManagementSteps();
            WhenApproverNavigateToContractAwaitingAcceptancePage();
            ThenApproverCanViewAllTheContractsThatHaveBeenSignedByDealer();
            ThenApproverCanSuccessfullyApproveTheContract();
            ThenTheAcceptedContractByApproverIsDisplayedOnContractAcceptedScreen();
            instance3.ThenIfISignOutOfBrotherOnline();
        }

        [Given(@"the contract created above is approved without signing out")]
        [Then(@"the contract created above is approved without signing out")]
        public void ThenTheContractCreatedAboveIsApprovedWithoutSigningOut()
        {
            
            WhenApproverNavigateToContractAwaitingAcceptancePage();
            ThenApproverCanViewAllTheContractsThatHaveBeenSignedByDealer();
            ThenApproverCanSuccessfullyApproveTheContract();
            ThenTheAcceptedContractByApproverIsDisplayedOnContractAcceptedScreen();
            
        }


        [Then(@"the accepted contract by Approver is displayed on contract Accepted screen")]
        public void ThenTheAcceptedContractByApproverIsDisplayedOnContractAcceptedScreen()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankContractsPage>().NavigateToAcceptedPage();
                CurrentPage.As<BankContractsPage>().IsContractsSignedByDealerDisplayed();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToAcceptedPage();
                CurrentPage.As<LocalOfficeApproverContractsPage>().IsContractsSignedByDealerDisplayed();
            }
        }

        [Then(@"the rejected contract by Approver is displayed on contract Rejected screen")]
        public void ThenTheRejectedContractByApproverIsDisplayedOnContractRejectedScreen()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankContractsPage>().NavigateToRejectedPage();
                CurrentPage.As<BankContractsPage>().IsContractsSignedByDealerDisplayed();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToRejectedPage();
                CurrentPage.As<LocalOfficeApproverContractsPage>().IsContractsSignedByDealerDisplayed();
            }
        }

        [Then(@"I should be able to approve that proposal")]
        public void ThenIShouldBeAbleToApproveThatProposal()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankProposalsSummaryPage>().ClickApproveButton();
                CurrentPage.As<BankProposalsSummaryPage>().EnterApprovalInformation();
                CurrentPage.As<BankProposalsSummaryPage>().ClickAccpetButton();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickApproveButton();
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().EnterApprovalInformation();
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickAccpetButton();
            }
        }

        [Then(@"I should be able to decline that proposal")]
        public void ThenIShouldBeAbleToDeclineThatProposal()
        {
            if (LeaseAndClick)
            {
                CurrentPage.As<BankProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<BankProposalsSummaryPage>().SelectDeclineReason("Expired");
                NextPage = CurrentPage.As<BankProposalsSummaryPage>().ClickRejectButton();
            }
            else if (PurchaseAndClick)
            {
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickDeclineButton();
                CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().SelectDeclineReason("Expired");
                NextPage = CurrentPage.As<LocalOfficeApproverProposalsSummaryPage>().ClickRejectButton();
            }
        }
    }
}
