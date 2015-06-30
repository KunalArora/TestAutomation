using Brother.WebSites.Core.Pages.Base;
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

        [Given(@"I am on Proposal List page")]
        public void GivenIAmOnProposalListPage()
        {
            WhenIClickSaveProposalButtonOnSummaryScreen();
            ThenIAmDirectedToProposalsScreenOfProposalListPage();
            ThenTheNewlyCreatedProposalIsDisplayedOnTheList();
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

     
        [When(@"I navigate to Rejected screen")]
        public void WhenINavigateToRejectedScreen()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            CurrentPage.As<DealerContractsPage>().NavigateToRejectedOfferScreen();
        }

        [Then(@"I can successfully re-sign the rejected contract")]
        public void ThenICanSuccessfullyResignTheRejectedContract()
        {
            NextPage = CurrentPage.As<DealerContractsPage>().NavigateToViewSummaryOnRejectedTab();
            CurrentPage.As<DealerContractsSummaryPage>().ClickReSignButton();
            CurrentPage.As<DealerContractsSummaryPage>().TickResignInformationCheckbox();
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().ClickFinalReSignButton();
            CurrentPage.As<DealerContractsPage>().VerifyRejectedContractIsDisplayed();
        }

        [Then(@"fields on ""(.*)"" screen are disabled")]
        public void ThenFieldsOnScreenAreDisabled(string screens)
        {
            CurrentPage.As<CreateNewProposalPage>().ClickOnProposalTabsDuringContractConversionTransform(screens);
            CurrentPage.As<CreateNewProposalPage>().VerifyFieldsOnScreensAreDisabled(screens);
        }


    }
}
