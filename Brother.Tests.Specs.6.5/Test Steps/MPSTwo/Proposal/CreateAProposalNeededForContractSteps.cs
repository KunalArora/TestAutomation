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
            CurrentPage.As<DealerProposalsCreateSummaryPage>().SetContractIdValue();
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
            CurrentPage.As<CloudExistingProposalPage>().ClickOnActionButtonAgainstCopiedProposal();
            NextPage = CurrentPage.As<CloudExistingProposalPage>().ClickOnConvertToContractButton(CurrentDriver);
            CurrentPage.As<DealerConvertProposalCustomerInfo>().IsConvertCustomerInfoScreenDisplayed();
        }


        [Then(@"I am redirected to Summary page when I start proposal conversion process")]
        public void ThenRedirectedToSummaryPageWhenIStartProposalConversionProcess()
        {
            CurrentPage.As<CloudExistingProposalPage>().ClickOnActionButtonAgainstCopiedProposal();
            NextPage = CurrentPage.As<CloudExistingProposalPage>().ClickOnConvertToContractButtonForCopiedProposalWithCustomer(CurrentDriver);
            CurrentPage.As<DealerConvertProposalSummaryPage>().IsConvertSummaryPageDisplayed();
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
            //NextPage = CurrentPage.As<LocalOfficeApproverContractsSummaryPage>().NavigateToViewSummaryOnRejectedTab();
            CurrentPage.As<DealerContractsSummaryPage>().ClickReSignButton();
            CurrentPage.As<DealerContractsSummaryPage>().TickResignInformationCheckbox();
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().ClickFinalReSignButton();
            CurrentPage.As<DealerContractsPage>().VerifyRejectedContractIsDisplayed();
        }

    }
}
