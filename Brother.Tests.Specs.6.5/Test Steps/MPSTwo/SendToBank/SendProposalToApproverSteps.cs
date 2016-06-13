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
            CurrentPage.As<CloudExistingProposalPage>().ClickOnActionButtonAgainstRelevantProposal();
        }

        [When(@"I copy the proposal created above ""(.*)"" customer")]
        public void WhenICopyTheProposalCreatedAboveCustomer(string status)
        {
            CurrentPage.As<CloudExistingProposalPage>().CopyProposalWithOptions(status);
        }

        [Then(@"the copied proposal above is displayed with appropriate customer status")]
        public void ThenTheCopiedProposalAboveIsDisplayedWithAppropriateCustomerStatus()
        {
            CurrentPage.As<CloudExistingProposalPage>().IsProposalCopied();
            CurrentPage.As<CloudExistingProposalPage>().IsProposalCustomerCopied();
        }


        [Then(@"I can click on Convert to Contract button under the Action button")]
        public void ThenICanClickOnConvertToContractButtonUnderTheActionButton()
        {
            NextPage = CurrentPage.As<CloudExistingProposalPage>().ClickOnConvertToContractButton(CurrentDriver);
        }

        public void ThenICanClickOnConvertToContractButtonToNavigateToConvertSummaryPage()
        {
            NextPage = CurrentPage.As<CloudExistingProposalPage>().ClickOnConvertToContractButton();
        }

        [Then(@"I am taken to the proposal summary where I can enter envisage contract start date")]
        public void ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate()
        {
            CurrentPage.As<DealerConvertProposalSummaryPage>().IsConvertSummaryPageDisplayed();
            CurrentPage.As<DealerConvertProposalSummaryPage>().EnterProposedStartDateForContract();
            CurrentPage.As<DealerConvertProposalSummaryPage>().GiveThirdPartyCheckApproval();
            CurrentPage.As<DealerConvertProposalSummaryPage>().GiveSchufaAuthorization();
        }

        [Then(@"I am taken to purchase and click summary where I can enter envisage contract start date")]
        public void ThenIAmTakenToPurchaseAndClickSummaryWhereICanEnterEnvisageContractStartDate()
        {
            CurrentPage.As<DealerConvertProposalSummaryPage>().IsConvertSummaryPageDisplayed();
            CurrentPage.As<DealerConvertProposalSummaryPage>().EnterProposedStartDateForContract();
            CurrentPage.As<DealerConvertProposalSummaryPage>().GiveBrotherAuthorisation();
            CurrentPage.As<DealerConvertProposalSummaryPage>().GiveSchufaAuthorization();
        }


        [When(@"I send the created proposal for approval")]
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

        [When(@"I navigate to the Summary page of the proposal awaiting approval")]
        public void WhenINavigateToTheSummaryPageOfTheProposalAwaitingApproval()
        {
            NextPage = CurrentPage.As<DealerProposalsAwaitingApproval>().NavigateToViewSummary();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().StoreValuesFromSummaryPage();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().GetDownloadedPdfPath();
           // NextPage = CurrentPage.As<DealerProposalsCreateSummaryPage>().CloseProposal();
        }


        [Given(@"I send the created German proposal for approval")]
        public void GivenISendTheCreatedGermanProposalForApproval()
        {
            WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
            ThenICanClickOnConvertToContractButtonUnderTheActionButton();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().FillAllCustomerDetailsOnConvert();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterRemainingCustomerInfo();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterAllBankInformation();
            NextPage = CurrentPage.As<DealerConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<DealerConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();

            ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
            ThenICanSuccessfullyConvertTheProposalToContract();
            ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
        }

        public void GivenISendTheCreatedGermanProposalForApproval(string customer)
        {
            WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
            ThenICanClickOnConvertToContractButtonUnderTheActionButton();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().ChooseExistingCustomerInConvertProcess();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().SelectASpecificExistingContact(customer);
            NextPage = CurrentPage.As<DealerConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<DealerConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();

            ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
            ThenICanSuccessfullyConvertTheProposalToContract();
            ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
        }



        [Given(@"I send the created proposal to local office approver for approval")]
        public void GivenISendTheCreatedProposalToLocalOfficeApproverForApproval()
        {
            WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
            ThenICanClickOnConvertToContractButtonUnderTheActionButton();
            ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
            ThenIAmTakenToPurchaseAndClickSummaryWhereICanEnterEnvisageContractStartDate();
            ThenICanSuccessfullyConvertTheProposalToContract();
            ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
        }


        [Given(@"I decline the proposal created above")]
        [When(@"I decline the proposal created above")]
        public void WhenIDeclineTheProposalCreatedAbove()
        {
            ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
            CurrentPage.As<BankOffersPage>().ClickOnActionButtonAgainstRelevantProposal();
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
            CurrentPage.As<CloudExistingProposalPage>().ClickOnActionButtonAgainstDeclinedProposal();
            CurrentPage.As<CloudExistingProposalPage>().CopyAProposalWithoutCustomer(CurrentDriver);
            CurrentPage.As<CloudExistingProposalPage>().IsProposalCopiedWithoutCustomer();
        }

        [Then(@"I can copy the declined proposal with customer")]
        public void ThenICanCopyTheDeclinedProposalWithCustomer()
        {
            CurrentPage.As<CloudExistingProposalPage>().ClickOnActionButtonAgainstDeclinedProposal();
            CurrentPage.As<CloudExistingProposalPage>().CopyAProposalWithCustomer(CurrentDriver);
            CurrentPage.As<CloudExistingProposalPage>().IsProposalCopiedWithCustomer();
        }

        [Then(@"I am directed to customer detail page to begin data capture")]
        public void ThenIAmDirectedToCustomerDetailPageToBeginDataCapture()
        {
            CurrentPage.As<DealerConvertProposalCustomerInfo>().FillAllCustomerDetailsOnConvert();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterRemainingCustomerInfo();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterAllBankInformation();
            NextPage = CurrentPage.As<DealerConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<DealerConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();
        }


        [Then(@"I am directed to customer detail page for more data capture")]
        public void ThenIAmDirectedToCustomerDetailPageForMoreDataCapture()
        {
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterRemainingCustomerInfo();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterAllBankInformation();
            NextPage = CurrentPage.As<DealerConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<DealerConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();
        }

        [Then(@"I am directed to customer detail page for can order data capture")]
        public void ThenIAmDirectedToCustomerDetailPageForCanOrderDataCapture()
        {
            CurrentPage.As<DealerConvertProposalCustomerInfo>().FillAllCustomerDetailsOnConvert();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterRemainingCustomerInfo();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().CustomerCanOrderConsumables();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterAllBankInformation();
            NavigateToSummaryPage();
        }

        private void NavigateToSummaryPage()
        {
            NextPage = CurrentPage.As<DealerConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<DealerConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();
        }


        [Then(@"I am directed to customer detail page for ""(.*)"" privately liable data capture")]
        public void ThenIAmDirectedToCustomerDetailPageForPrivatelyLiableDataCapture(string company)
        {
            CurrentPage.As<DealerConvertProposalCustomerInfo>().FillAllCustomerDetailsOnConvert();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterPrivateLiableCustomerInfo(company);
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterAllBankInformation();
            //CurrentPage.As<ConvertProposalCustomerInfo>().EnterPrivateLiableInfo();
            NextPage = CurrentPage.As<DealerConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<DealerConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();
        }

        [Then(@"I am directed to capture customer detail page for ""(.*)"" privately liable customer who can order")]
        public void ThenIAmDirectedToCaptureCustomerDetailPageForPrivatelyLiableCustomerWhoCanOrder(string company)
        {
            CurrentPage.As<DealerConvertProposalCustomerInfo>().FillAllCustomerDetailsOnConvert();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterPrivateLiableCustomerInfo(company);
            CurrentPage.As<DealerConvertProposalCustomerInfo>().CustomerCanOrderConsumables();
            CurrentPage.As<DealerConvertProposalCustomerInfo>().EnterAllBankInformation();
            //CurrentPage.As<ConvertProposalCustomerInfo>().EnterPrivateLiableInfo();
            NextPage = CurrentPage.As<DealerConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
            NextPage = CurrentPage.As<DealerConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();
        }

        
        [Then(@"I can successfully convert the proposal to contract")]
        public void ThenICanSuccessfullyConvertTheProposalToContract()
        {
            NextPage = CurrentPage.As<DealerConvertProposalSummaryPage>().SaveProposalAsAContract();
        }

        [Then(@"the newly converted contract is available under Awaiting Approval tab")]
        public void ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab()
        {
            CurrentPage.As<DealerProposalsAwaitingApproval>().IsProposalSentToDealerAwaitingProposalPage();
        }

        [Then(@"I navigate to Proposal Summary Page under Awaiting Approval tab")]
        public void ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab()
        {
            NextPage = CurrentPage.As<DealerProposalsAwaitingApproval>().NavigateToViewSummary();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().StoreProposalSummaryData();
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

        [Then(@"the converted Purchase and Click and Service proposal above is displayed on the screen")]
        public void ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen()
        {
            CurrentPage.As<LocalOfficeApproverProposalsPage>().IsProposalSentToApproverAwaitingProposalPage();
        }

        [Then(@"I navigate to Local office Awaiting Approval screen under Proposals page")]
        public void ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage()
        {
            CurrentPage.As<LocalOfficeApproverDashBoardPage>().SwitchBetweenMultipleLanguages();
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
            NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToProposalsPage();
            CurrentPage.As<LocalOfficeApproverProposalsPage>().IsProposalSentToLocalOfficeApproverAwaitingProposalPage();
        }

        [Given(@"I navigate to Local Approver Awaiting Approval screen under Proposal page")]
        [When(@"I navigate to Local Approver Awaiting Approval screen under Proposal page")]
        [Then(@"I navigate to Local Approver Awaiting Approval screen under Offer page")]
        [Then(@"I navigate to Local Approver Awaiting Approval screen under Proposal page")]
        [Then(@"I navigate to Local Approver Awaiting Approval screen under Offer page")]
        public void ThenINavigateToLocalApproverAwaitingApprovalScreenUnderOfferPage()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
            NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToProposalsPage();
            CurrentPage.As<LocalOfficeApproverProposalsPage>().IsProposalSentToLocalOfficeApproverAwaitingProposalPage();
        }

        [Then(@"I can view all the proposals declined by both Bank and LocalOffice Approver")]
        public void ThenICanViewAllTheProposalsDeclinedByBothBankAndLocalOfficeApprover()
        {
            CurrentPage.As<BankOffersPage>().VerifyDeclinedProposalIsDisplayed();
        }

    }
}
