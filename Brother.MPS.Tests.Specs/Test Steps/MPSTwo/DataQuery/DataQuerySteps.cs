using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.DataQuery
{
    [Binding]
    public class DataQuerySteps :BaseSteps
    {
        
        [Then(@"I can search with contract id ""(.*)""")]
        public void ThenICanSearchWithContractId(string id)
        {
            CurrentPage.As<DataQueryPage>().SearchWithContractId(id);
            CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }


        [Then(@"search using serial number ""(.*)""")]
        public void ThenSearchUsingSerialNumber(string number)
        {
            CurrentPage.As<DataQueryPage>().SearchUsingSerialNumber(number);
            CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }


        [Then(@"I can change the search dates")]
        public void ThenICanChangeTheSearchDates()
        {
            CurrentPage.As<DataQueryPage>().SearchWithDates();
        }

        [Then(@"I can search with show ending contracts")]
        public void ThenICanSearchWithShowEndingContracts()
        {
            
        }

        [Then(@"I can filter out Open Proposals")]
        public void ThenICanFilterOutOpenProposals()
        {
            CurrentPage.As<DataQueryPage>().FilterOpenProposalStatus();
            CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }

        [Then(@"I can filter out Awaiting Approval Proposal")]
        public void ThenICanFilterOutAwaitingApprovalProposal()
        {
            CurrentPage.As<DataQueryPage>().FilterAwaitingApprovalProposalStatus();
            CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }

        [Then(@"I can filter out Approved Proposal")]
        public void ThenICanFilterOutApprovedProposal()
        {
            CurrentPage.As<DataQueryPage>().FilterApprovedProposalStatus();
            CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }

        [Then(@"I can filter out Closed Proposal")]
        public void ThenICanFilterOutClosedProposal()
        {
            CurrentPage.As<DataQueryPage>().FilterClosedProposalStatus();
            CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }

        [Then(@"I can filter out Decline Proposal")]
        public void ThenICanFilterOutDeclineProposal()
        {
            CurrentPage.As<DataQueryPage>().FilterDeclinedProposalStatus();
            CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }

        [Then(@"I can filter out Awaiting Acceptance Contract")]
        public void ThenICanFilterOutAwaitingAcceptanceContract()
        {
            CurrentPage.As<DataQueryPage>().FilterAwaitingAcceptanceContractStatus();
            CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }

        [Then(@"I can filter out Accepted Contract")]
        public void ThenICanFilterOutAcceptedContract()
        {
           CurrentPage.As<DataQueryPage>().FilterAcceptedContractStatus();
           CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }

        [Then(@"I can filter out Running Contract")]
        public void ThenICanFilterOutRunningContract()
        {
            CurrentPage.As<DataQueryPage>().FilterRunningContractStatus();
            CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }

        [Then(@"I can filter out Closed Contract")]
        public void ThenICanFilterOutClosedContract()
        {
            CurrentPage.As<DataQueryPage>().FilterClosedContractStatus();
            CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }

        [Then(@"I can filter out Rejected Contract")]
        public void ThenICanFilterOutRejectedContract()
        {
            CurrentPage.As<DataQueryPage>().FilterRejectedContractStatus();
            CurrentPage.As<DataQueryPage>().IsResultDisplayedAfterSearch(1);
        }

        [Then(@"I can filter out Lease \+ Click with Service Contract")]
        public void ThenICanFilterOutLeaseClickWithServiceContract()
        {
            CurrentPage.As<DataQueryPage>().FilterLeaseAndClickContracts();
            CurrentPage.As<DataQueryPage>().AreContractTypeAndUsageTypeReturned();
        }

        [Then(@"I can filter out Purchase \+ Click with Service Contract")]
        public void ThenICanFilterOutPurchaseClickWithServiceContract()
        {
            CurrentPage.As<DataQueryPage>().FilterPurchaseAndClickContracts();
            CurrentPage.As<DataQueryPage>().AreContractTypeAndUsageTypeReturned();
        }

        [Then(@"I can filter out Minimum Volume Usage")]
        public void ThenICanFilterOutMinimumVolumeUsage()
        {
            CurrentPage.As<DataQueryPage>().FilterMinimumVolumeContracts();
            CurrentPage.As<DataQueryPage>().AreContractTypeAndUsageTypeReturned();
        }

        [Then(@"I can filter out Pay As You Go Usage")]
        public void ThenICanFilterOutPayAsYouGoUsage()
        {
            CurrentPage.As<DataQueryPage>().FilterPayAsYouGoContracts();
            CurrentPage.As<DataQueryPage>().AreContractTypeAndUsageTypeReturned();
        }

    }
}
