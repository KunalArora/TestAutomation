using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (ContractType.Equals("Purchase & Click with Service"))
                PurchaseAndClick = true;
            if (ContractType.Equals("Lease & Click with Service"))
                LeaseAndClick = true;
            if (UsageType.Equals("Minimum Volume"))
                MinimumVolume = true;
            if (UsageType.Equals("Pay As You Go"))
                PayAsYouGo = true;

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
                NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToContractsPage();
                CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToAwaitingAcceptancePage();
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

    }
}
