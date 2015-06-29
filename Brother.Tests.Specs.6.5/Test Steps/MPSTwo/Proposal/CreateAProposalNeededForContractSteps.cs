﻿using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;


namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class ProposalCreateAProposalThatWillBeUsedForContractSteps : BaseSteps
    {
        [Then(@"I click Save Proposal button on Summary screen")]
        [When(@"I click Save Proposal button on Summary screen")]
        public void WhenIClickSaveProposalButtonOnSummaryScreen()
        {
            NextPage = CurrentPage.As<DealerProposalsCreateSummaryPage>().SaveProposal();
        }
        
        [Then(@"I am directed to Proposals screen of Proposal List page")]
        public void ThenIAmDirectedToProposalsScreenOfProposalListPage()
        {
            CurrentPage.As<CloudExistingProposalPage>().IsProposalListProposalScreenDiplayed();
        }
        
        [Then(@"the newly created proposal is displayed on the list")]
        public void ThenTheNewlyCreatedProposalIsDisplayedOnTheList()
        {
            CurrentPage.As<CloudExistingProposalPage>().IsNewProposalTemplateCreated();
        }

        [Given(@"I navigate to Customer Information Detail for new customer")]
        public void GivenINavigateToCustomerInformationDetailForNewCustomer()
        {
            //The codes below are copied from CreateATemplateSteps
            Given("I navigate to Dealer Dashboard page");
            Given("I am on MPS New Proposal Page");
            When("I fill Proposal Description");
            When("I enter Customer Information Detail for new customer");
        }

        [Given(@"I am on Proposal List page")]
        public void GivenIAmOnProposalListPage()
        {
            WhenIClickSaveProposalButtonOnSummaryScreen();
            ThenIAmDirectedToProposalsScreenOfProposalListPage();
            ThenTheNewlyCreatedProposalIsDisplayedOnTheList();
        }


        [Given(@"I create the proposal with details above")]
        [When(@"I create the proposal with details above")]
        public void WhenICreateTheProposalWithDetailsAbove()
        {
            //The following codes come from this class
            When("I click Save Proposal button on Summary screen");
            Then("I am directed to Proposals screen of Proposal List page");
            Then("the newly created proposal is displayed on the list");
        }

        [When(@"I start the contract conversion process")]
        [Then(@"I start the contract conversion process")]
        public void ThenIStartTheContractConversionProcess()
        {
            CurrentPage.As <CloudExistingProposalPage>().ClickOnActionButtonAgainstRelevantProposal(CurrentDriver);
            CurrentPage.As<CloudExistingProposalPage>().ClickOnConvertToContractButton(CurrentDriver);
            
        }


        [Then(@"I am redirected to Customer screen when I start proposal conversion process")]
        public void ThenRedirectedToCustomerScreenWhenIAmStartProposalConversionProcess()
        {
            CurrentPage.As<CloudExistingProposalPage>().ClickOnActionButtonAgainstCopiedProposal(CurrentDriver);
            NextPage = CurrentPage.As<CloudExistingProposalPage>().ClickOnConvertToContractButton(CurrentDriver);
            CurrentPage.As<ConvertProposalCustomerInfo>().IsConvertCustomerInfoScreenDisplayed();
        }


        [Then(@"I am redirected to Summary page when I start proposal conversion process")]
        public void ThenRedirectedToSummaryPageWhenIStartProposalConversionProcess()
        {
            CurrentPage.As<CloudExistingProposalPage>().ClickOnActionButtonAgainstCopiedProposal(CurrentDriver);
            NextPage = CurrentPage.As<CloudExistingProposalPage>().ClickOnConvertToContractButtonForCopiedProposalWithCustomer(CurrentDriver);
            CurrentPage.As<ConvertProposalSummaryPage>().IsConvertSummaryPageDisplayed();
        }


        [When(@"I add a date to the proposal")]
        [Then(@"I add a date to the proposal")]
        public void ThenIAddADateToTheProposal()
        {
            CurrentPage.As<CloudExistingProposalPage>().EnterProposedStartDateForContract();
        }

        [When(@"I save the proposal as a contract")]
        [Then(@"I save the proposal as a contract")]
        public void ThenISaveTheProposalAsAContract()
        {
            CurrentPage.As<CloudExistingProposalPage>().SaveProposalAsAContract();
        }

        [Then(@"the newly converted contract is available on Ready for Bank screen")]
        public void ThenTheNewlyConvertedContractIsAvailableOnReadyForBankScreen()
        {
            CurrentPage.As<CloudExistingProposalPage>().IsTheProposalSuccessfullyConverted();
        }

       
        [Then(@"I can send the converted contract to bank")]
        public void ThenICanSendTheConvertedContractToBank()
        {
            //Procced to Send To Bank Page
            NextPage = CurrentPage.As<CloudExistingProposalPage>().StartSendToBankProcess(CurrentDriver);

            //Fill the forms on Company and Bank Screen
            CurrentPage.As<SendToBankPage>().IsCompanyLegendDisplayed();
            CurrentPage.As<SendToBankPage>().IsBankLegendDisplayed();
            CurrentPage.As<SendToBankPage>().FillCompanyDetails();
            CurrentPage.As<SendToBankPage>().FillBankAccountInfo();

            //Proceed to leasing Bank selection page
            CurrentPage.As<SendToBankPage>().ProceedOnSendToBankScreen();

            //Select a leasing bank
            CurrentPage.As<SendToBankPage>().SelectALeasingBankAndProceed();

            //Finalize Send to bank
            NextPage = CurrentPage.As<SendToBankPage>().SendProposalToActualContract();

            //Verify that the contract is created and displayed on Awaiting Processing Screen
            CurrentPage.As<CloudExistingProposalPage>().IsProposalFilterDiplayed();
            CurrentPage.As<CloudExistingProposalPage>().IsProposalSuccessfullySentToBank();

        }

        [Given(@"I navigate to the Term and Type page")]
        public void GivenINavigateToTheTermAndTypePage()
        {
            Given("I navigate to Dealer Dashboard page");
            Given("I am on MPS New Proposal Page");
            When("I fill Proposal Description");
            When("I enter Customer Information Detail for new customer");
        }


        [Given(@"I navigate to the Products page")]
        public void GivenINavigateToTheProductsPage()
        {
            //The codes below are copied from CreateATemplateSteps
            Given("I navigate to Dealer Dashboard page");
            Given("I am on MPS New Proposal Page");
            When("I fill Proposal Description");
            When("I enter Customer Information Detail for new customer");
            When("I Enter Term and Type details");

            CurrentPage.As<DealerProposalsCreateProductsPage>().IsProductScreenTextDisplayed();
        }

        [When(@"I accept the contract above")]
        public void WhenIAcceptTheContractAbove()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToBankLandingPage();
            CurrentPage.As<BankUserLandingPage>().IsBankLandingPageDisplayed();
            CurrentPage.As<BankUserLandingPage>().StartTheAcceptanceProcess(CurrentDriver);
            CurrentPage.As<BankUserLandingPage>().ClickOnAcceptanceButton();
            CurrentPage.As<BankUserLandingPage>().FillAcceptanceForm();
            CurrentPage.As<BankUserLandingPage>().FinalAcceptanceProcess();
            CurrentPage.As<BankUserLandingPage>().VerifyThatContractHasBeenApproved();
            
        }

        [When(@"I reject the contract above")]
        public void WhenIRejectTheContractAbove()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToBankLandingPage();
            CurrentPage.As<BankUserLandingPage>().IsBankLandingPageDisplayed();
            CurrentPage.As<BankUserLandingPage>().StartTheAcceptanceProcess(CurrentDriver);
            CurrentPage.As<BankUserLandingPage>().ClickOnRejectButton();
            CurrentPage.As<BankUserLandingPage>().FillRejectionForm();

            CurrentPage.As<BankUserLandingPage>().VerifyThatContractHasBeenRejected();

        }


        [Then(@"I can successfully complete pre-installation process")]
        public void ThenICanSuccessfullyCompletePre_InstallationProcess()
        {
            //NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToDealerDashboard();
            //NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            //CurrentPage.As<CloudContractPage>().IsContractScreenDisplayed();
            //CurrentPage.As<CloudContractPage>().NavigateToConfirmedOfferScreen();
            //CurrentPage.As<CloudContractPage>().VerifyAcceptedContractIsDisplayed();

            //This gherkin comes from below
            When("I sign the contract");

           
            CurrentPage.As<CloudContractPage>().DealerCompletePreInstallationProcess(CurrentDriver);

        }


        [When(@"I sign the contract as a dealer")]
        public void WhenISignTheContractAsADealer()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            NextPage = CurrentPage.As<CloudContractPage>().NavigateToViewOfferOnApprovedProposalsTab();
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().ClickSignButton();
        }

        [When(@"I navigate to Rejected screen")]
        public void WhenINavigateToRejectedScreen()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            CurrentPage.As<CloudContractPage>().NavigateToRejectedOfferScreen();
        }

        [Then(@"I can successfully re-sign the rejected contract")]
        public void ThenICanSuccessfullyResignTheRejectedContract()
        {
            NextPage = CurrentPage.As<CloudContractPage>().NavigateToViewSummaryOnRejectedTab();
            CurrentPage.As<DealerContractsSummaryPage>().ClickReSignButton();
            CurrentPage.As<DealerContractsSummaryPage>().TickResignInformationCheckbox();
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().ClickFinalReSignButton();
            CurrentPage.As<CloudContractPage>().VerifyRejectedContractIsDisplayed();
        }

        [Then(@"the reject contract above is displayed on dealer rejected offer screen")]
        public void ThenTheRejectContractAboveIsDisplayedOnDealerRejectedOfferScreen()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToDealerDashboard();
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            CurrentPage.As<CloudContractPage>().IsContractScreenDisplayed();
            CurrentPage.As<CloudContractPage>().NavigateToRejectedOfferScreen();
            CurrentPage.As<CloudContractPage>().VerifyRejectedContractIsDisplayed();

        }


        [Then(@"I can successfully maintain the customer for the signed contract")]
        public void ThenICanSuccessfullyMaintainTheCustomerForTheSignedContract()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToBankLandingPage();
            CurrentPage.As<BankUserLandingPage>().IsBankLandingPageDisplayed();

            CurrentPage.As<BankUserLandingPage>().VerifyThatContractHasBeenSigned();
            CurrentPage.As<BankUserLandingPage>().StartMaintainOfferProcess(CurrentDriver);
            CurrentPage.As<BankUserLandingPage>().MaintainContractOffer();

            CurrentPage.As<BankUserLandingPage>().VerifyMaintainOfferCheckboxesAreChecked(CurrentDriver);
            CurrentPage.As<BankUserLandingPage>().IsBankSignedOffersLandingPageDisplayed();

        }

        [Then(@"only the previously selected printer has Details button")]
        public void ThenOnlyThePreviouslySelectedPrinterHasDetailsButton()
        {
            NextPage = CurrentPage.As<CloudExistingProposalPage>().ClickOnProposalTabsDuringContractConversionTransform("Products");
            CurrentPage.As<CreateNewProposalPage>().VerifyThatTheNumbersOfPrintersEqualTheNumbersOfDetailButtonDisplayed();
            CurrentPage.As<CreateNewProposalPage>().NoAddButtonIsDisplayed();

        }

        [Then(@"fields on ""(.*)"" screen are disabled")]
        public void ThenFieldsOnScreenAreDisabled(string screens)
        {
            CurrentPage.As<CreateNewProposalPage>().ClickOnProposalTabsDuringContractConversionTransform(screens);
            CurrentPage.As<CreateNewProposalPage>().VerifyFieldsOnScreensAreDisabled(screens);
        }


    }
}
