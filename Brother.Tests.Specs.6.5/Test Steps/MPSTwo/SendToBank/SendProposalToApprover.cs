using Brother.WebSites.Core.Pages.Base;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.SendToBank
{
    [Binding]
    public class SendProposalToApprover : BaseSteps
    {
        [Given(@"I have created ""(.*)"" proposal")]
        public void GivenIHaveCreatedProposal(string type)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on Action button against the proposal created above")]
        public void WhenIClickOnActionButtonAgainstTheProposalCreatedAbove()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can click on Convert to Contract button under the Action button")]
        public void ThenICanClickOnConvertToContractButtonUnderTheActionButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I am taken to the proposal summary where I can enter envisage contract start date")]
        public void ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I can successfully convert the proposal to contract")]
        public void ThenICanSuccessfullyConvertTheProposalToContract()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the newly converted contract is available under Awaiting Approval tab")]
        public void ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I sign into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        public void ThenISignIntoCloudMPSAsAFrom(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I navigate to bank Awaiting Approval screen under Offer page")]
        public void ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the converted Leasing and Click and Service proposal above is displayed on the screen")]
        public void ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I navigate to Local Approver Awaiting Approval screen under Offer page")]
        public void ThenINavigateToLocalApproverAwaitingApprovalScreenUnderOfferPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the converted Purchase and Click and Service proposal above is displayed on the screen")]
        public void ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
