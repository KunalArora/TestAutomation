using Brother.WebSites.Core.Pages.Base;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.DataQuery
{
    [Binding]
    public class DataQuerySteps :BaseSteps
    {
        
        [Then(@"I can search with contract id ""(.*)""")]
        public void ThenICanSearchWithContractId(string id)
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"search using serial number ""(.*)""")]
        public void ThenSearchUsingSerialNumber(string number)
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"I can change the search dates")]
        public void ThenICanChangeTheSearchDates()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can search with show ending contracts")]
        public void ThenICanSearchWithShowEndingContracts()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Open Proposals")]
        public void ThenICanFilterOutOpenProposals()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Awaiting Approval Proposal")]
        public void ThenICanFilterOutAwaitingApprovalProposal()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Approved Proposal")]
        public void ThenICanFilterOutApprovedProposal()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Closed Proposal")]
        public void ThenICanFilterOutClosedProposal()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Decline Proposal")]
        public void ThenICanFilterOutDeclineProposal()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Awaiting Acceptance Contract")]
        public void ThenICanFilterOutAwaitingAcceptanceContract()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Accepted Contract")]
        public void ThenICanFilterOutAcceptedContract()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Running Contract")]
        public void ThenICanFilterOutRunningContract()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Closed Contract")]
        public void ThenICanFilterOutClosedContract()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Rejected Contract")]
        public void ThenICanFilterOutRejectedContract()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Lease \+ Click with Service Contract")]
        public void ThenICanFilterOutLeaseClickWithServiceContract()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Purchase \+ Click with Service Contract")]
        public void ThenICanFilterOutPurchaseClickWithServiceContract()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Minimum Volume Usage")]
        public void ThenICanFilterOutMinimumVolumeUsage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can filter out Pay As You Go Usage")]
        public void ThenICanFilterOutPayAsYouGoUsage()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
