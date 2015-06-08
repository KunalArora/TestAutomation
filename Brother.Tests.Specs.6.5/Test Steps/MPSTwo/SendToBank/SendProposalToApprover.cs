using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.SendToBank
{
    [Binding]
    public class SendProposalToApprover : BaseSteps
    {
        
        [When(@"I click on Action button against the proposal created above")]
        public void WhenIClickOnActionButtonAgainstTheProposalCreatedAbove()
        {
            CurrentPage.As<CloudExistingProposalPage>().ClickOnActionButtonAgainstRelevantProposal(CurrentDriver);
        }

        [Then(@"I can click on Convert to Contract button under the Action button")]
        public void ThenICanClickOnConvertToContractButtonUnderTheActionButton()
        {
            CurrentPage.As<CloudExistingProposalPage>().ClickOnConvertToContractButton(CurrentDriver);
        }

        [Then(@"I am taken to the proposal summary where I can enter envisage contract start date")]
        public void ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate()
        {
            CurrentPage.As<ConvertProposalSummaryPage>().IsConvertSummaryPageDisplayed();
            CurrentPage.As<ConvertProposalSummaryPage>().EnterProposedStartDateForContract();
            CurrentPage.As<ConvertProposalSummaryPage>().GiveThirdPartyCheckApproval();
        }

        [Then(@"I am directed to customer detail page for more data capture")]
        public void ThenIAmDirectedToCustomerDetailPageForMoreDataCapture()
        {
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterRemainingCustomerInfo();
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterAllBankInformation();
            NextPage = CurrentPage.As<ConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<ConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();
        }

        [Given(@"I have created Purchase and Click proposal")]
        public void GivenIHaveCreatedPurchaseAndClickProposal()
        {
            
        }


        [Then(@"I can successfully convert the proposal to contract")]
        public void ThenICanSuccessfullyConvertTheProposalToContract()
        {
            NextPage = CurrentPage.As<ConvertProposalSummaryPage>().SaveProposalAsAContract();
        }

        [Then(@"the newly converted contract is available under Awaiting Approval tab")]
        public void ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab()
        {
            CurrentPage.As<DealerProposalsAwaitingApproval>().IsProposalSentToDealerAwaitingProposalPage();
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
