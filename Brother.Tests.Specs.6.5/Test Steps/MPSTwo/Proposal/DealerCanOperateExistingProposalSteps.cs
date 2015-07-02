using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPSTwo.Proposal
{
    [Binding]
    public class DealerCanOperateProposalOffersSteps : BaseSteps
    {
        [Given(@"I navigate to existing proposal screen")]
        public void GivenINavigateToExistingProposalScreen()
        {
            var page = CurrentPage.As<DealerDashBoardPage>();
            NextPage = page.NavigateToExistingProposalPage();
        }

        [Then(@"I can see the Existing Proposal table")]
        public void ThenICanSeeTheExistingProposalTable()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
        }

        [When(@"I can click edit button on proposal item of Exisiting Proposal table")]
        public void WhenICanClickEditButtonOnProposalItemOfExisitingProposalTable()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
            page.ClickOnEditOnActionItem(CurrentDriver);
            NextPage = page.NavigateToEditProposalPage();
        }

        [When(@"I edit Proposal Description for ""(.*)"" Contract type")]
        public void WhenIFillProposalDescriptionForContractType(string contract)
        {
            var page = CurrentPage.As<DealerProposalsCreateDescriptionPage>();
            page.IsPromptTextDisplayed();
            page.SelectingContractType(contract);
            page.EnterProposalName("");
            page.EnterLeadCodeRef("");
            NextPage = page.ClickNextButton();
        }

        [When(@"I go to ""(.*)"" Tab in Proposal")]
        public void WhenIGoToTabInProposal(string tabname)
        {
            switch (tabname)
            {
                case "Description":
                    NextPage = DealerProposalsCreateNavTabs.NavigateToDescriptionTab(CurrentDriver);
                    break;

                case "Summary":
                    NextPage = DealerProposalsCreateNavTabs.NavigateToSummaryTab(CurrentDriver);
                    break;
            }
        }

        [Then(@"I can confirm ""(.*)"" on Summary Tab in Proposal")]
        public void ThenICanConfirmOnSummaryTabInProposal(string tabname)
        {
            var page = CurrentPage.As<DealerProposalsCreateSummaryPage>();
            switch (tabname)
            {
                case "Description":
                    page.VerifyDescriptionTabInput();
                    break;

                case "Summary":
                    NextPage = DealerProposalsCreateNavTabs.NavigateToSummaryTab(CurrentDriver);
                    break;
            }
        }


        [When(@"I click the delete button against ""(.*)"" on Exisiting Proposal table")]
        public void WhenIClickTheDeleteButtonAgainstAnItemOnExisitingProposalTable(string targertitem)
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
            if (targertitem == "NewlyCreatedItem")
            {
                page.ClickOnDeleteOnActionItemAgainstNewlyCreated(CurrentDriver);
            }
            else
            {
                page.ClickOnDeleteOnActionItem(CurrentDriver);
            }
        }

        [When(@"I click the ""(.*)"" button on Confirmation Dialog")]
        public void WhenIClickTheButtonOnConfirmationDialog(string confirm)
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            if (confirm == "OK")
            {
                page.ClickAcceptOnConfrimation(CurrentDriver);
            }
            else
            {
                page.ClickDismissOnConfrimation(CurrentDriver);
            }
        }

        [Then(@"I can see the deleted item does not exist on the table")]
        public void ThenICanSeeTheDeletedItemDoesNotExistOnTheTable()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.NotExistTheDeletedItem(CurrentDriver);
        }

        [Then(@"I can see the deleted item still exists on the table")]
        public void ThenICanSeeTheDeletedItemStillExistsOnTheTable()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.ExistsNotDeletedItem(CurrentDriver);
        }

        [When(@"I can Copy ""(.*)"" Customer an item of Exisiting Proposal table ""(.*)"" Customer")]
        public void WhenICanCopyCustomerAnItemOfExisitingProposalTableCustomer(string operation, string target)
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
            page.ClickOnCopyOnActionItemWithoutCustomer(CurrentDriver, operation, target);
        }

        [Then(@"I can see the Proposal offer which copied ""(.*)"" Customer")]
        public void ThenICanSeeTheProposalOfferWhichCopiedCustomer(string operation)
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
            page.ExistsCopiedProposalOffer(CurrentDriver, operation);
        }

        [Given(@"I navigate to Dealer Dashboard page from Dealer Proposal page")]
        public void GivenINavigateToDealerDashboardPageFromDealerProposalPage()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            NextPage = page.NavigateToDashboard(CurrentDriver);
        }
    }
}