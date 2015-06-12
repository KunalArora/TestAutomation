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
            NextPage = CurrentPage.As<CloudExistingProposalPage>().ClickOnConvertToContractButton(CurrentDriver);
        }

        [Then(@"I am taken to the proposal summary where I can enter envisage contract start date")]
        public void ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate()
        {
            CurrentPage.As<ConvertProposalSummaryPage>().IsConvertSummaryPageDisplayed();
            CurrentPage.As<ConvertProposalSummaryPage>().EnterProposedStartDateForContract();
            CurrentPage.As<ConvertProposalSummaryPage>().GiveThirdPartyCheckApproval();
            CurrentPage.As<ConvertProposalSummaryPage>().GiveSchufaAuthorization();
        }

        [Then(@"I am taken to purchase and click summary where I can enter envisage contract start date")]
        public void ThenIAmTakenToPurchaseAndClickSummaryWhereICanEnterEnvisageContractStartDate()
        {
            CurrentPage.As<ConvertProposalSummaryPage>().IsConvertSummaryPageDisplayed();
            CurrentPage.As<ConvertProposalSummaryPage>().EnterProposedStartDateForContract();
            CurrentPage.As<ConvertProposalSummaryPage>().GiveBrotherAuthorisation();
            //CurrentPage.As<ConvertProposalSummaryPage>().GiveSchufaAuthorization();
        }

        [Given(@"I send the created proposal for approval")]
        public void GivenISendTheCreatedProposalForApproval()
        {
            WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
            ThenICanClickOnConvertToContractButtonUnderTheActionButton();
            ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
            ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
            ThenICanSuccessfullyConvertTheProposalToContract();
            ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
        }

        [Given(@"I decline the proposal created above")]
        [When(@"I decline the proposal created above")]
        public void WhenIDeclineTheProposalCreatedAbove()
        {
            ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
            CurrentPage.As<BankOffersPage>().ClickOnActionButtonAgainstRelevantProposal(CurrentDriver);
            CurrentPage.As<BankOffersPage>().NavigateToAwaitingApprovalSummaryPage(CurrentDriver);
            CurrentPage.As<BankOffersPage>().DeclineAnAwaitingApprovalProposal();
            CurrentPage.As<BankOffersPage>().IsProposalDeclined();
        }

        [When(@"I navigate to decline proposal list page")]
        public void WhenINavigateToDeclineProposalListPage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToExistingProposalPage();
            CurrentPage.As<CloudExistingProposalPage>().NavigateToDeclinedProposalScreen();
            

        }

        [Then(@"I can copy the declined proposal without customer")]
        public void ThenICanCopyTheDeclinedProposalWithoutCustomer()
        {
            CurrentPage.As<CloudExistingProposalPage>().ClickOnActionButtonAgainstDeclinedProposal(CurrentDriver);
            CurrentPage.As<CloudExistingProposalPage>().CopyAProposalWithoutCustomer(CurrentDriver);
            CurrentPage.As<CloudExistingProposalPage>().IsProposalCopiedWithoutCustomer(CurrentDriver);
        }

        [Then(@"I can copy the declined proposal with customer")]
        public void ThenICanCopyTheDeclinedProposalWithCustomer()
        {
            CurrentPage.As<CloudExistingProposalPage>().ClickOnActionButtonAgainstDeclinedProposal(CurrentDriver);
            CurrentPage.As<CloudExistingProposalPage>().CopyAProposalWithCustomer(CurrentDriver);
            CurrentPage.As<CloudExistingProposalPage>().IsProposalCopiedWithCustomer(CurrentDriver);
        }



        [Then(@"I am directed to customer detail page for more data capture")]
        public void ThenIAmDirectedToCustomerDetailPageForMoreDataCapture()
        {
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterRemainingCustomerInfo();
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterAllBankInformation();
            NextPage = CurrentPage.As<ConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<ConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();
        }

        [Then(@"I am directed to customer detail page for can order data capture")]
        public void ThenIAmDirectedToCustomerDetailPageForCanOrderDataCapture()
        {
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterRemainingCustomerInfo();
            CurrentPage.As<ConvertProposalCustomerInfo>().CustomerCanOrderConsumables();
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterAllBankInformation();
            NextPage = CurrentPage.As<ConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<ConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();
        }

        [Then(@"I am directed to customer detail page for privately liable data capture")]
        public void ThenIAmDirectedToCustomerDetailPageForPrivateLiableDataCapture()
        {
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterPrivateLiableCustomerInfo();
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterAllBankInformation();
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterPrivateLiableInfo();
            NextPage = CurrentPage.As<ConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<ConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();
        }

        [Then(@"I am directed to capture customer detail page for privately liable customer who can order")]
        public void ThenIAmDirectedToCaptureCustomerDetailPageForPrivatelyLiableCustomerWhoCanOrder()
        {
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterPrivateLiableCustomerInfo();
            CurrentPage.As<ConvertProposalCustomerInfo>().CustomerCanOrderConsumables();
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterAllBankInformation();
            CurrentPage.As<ConvertProposalCustomerInfo>().EnterPrivateLiableInfo();
            NextPage = CurrentPage.As<ConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<ConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();
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

        [Then(@"I navigate to Proposal Summary Page under Awaiting Approval tab")]
        public void ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab()
        {
            CurrentPage.As<DealerProposalsAwaitingApproval>().NavigateToViewSummary();
        }

        [Then(@"I navigate to bank Awaiting Approval screen under Offer page")]
        public void ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage()
        {
            NextPage = CurrentPage.As<BankDashBoardPage>().NavigateToOffersPage();
        }

        [Then(@"the converted Leasing and Click and Service proposal above is displayed on the screen")]
        public void ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen()
        {
            CurrentPage.As<BankOffersPage>().IsProposalSentToBankAwaitingProposalPage();
        }

        [Then(@"I navigate to Local Approver Awaiting Approval screen under Offer page")]
        public void ThenINavigateToLocalApproverAwaitingApprovalScreenUnderOfferPage()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToProposalsPage();
            CurrentPage.As<LocalOfficeApproverProposalsPage>().IsProposalSentToLocalOfficeApproverAwaitingProposalPage();
        }

        [Then(@"the converted Purchase and Click and Service proposal above is displayed on the screen")]
        public void ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen()
        {
            CurrentPage.As<LocalOfficeApproverProposalsPage>().IsProposalSentToLocalOfficeApproverAwaitingProposalPage();
        }

        [Then(@"I can view all the proposals declined by both Bank and LocalOffice Approver")]
        public void ThenICanViewAllTheProposalsDeclinedByBothBankAndLocalOfficeApprover()
        {
            CurrentPage.As<BankOffersPage>().IsAllTheDeclinedProposalDisplayed();
        }

    }
}
