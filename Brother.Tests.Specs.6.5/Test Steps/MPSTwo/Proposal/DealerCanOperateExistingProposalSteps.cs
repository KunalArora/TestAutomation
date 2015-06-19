using System;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework.Constraints;
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

        [When(@"I can edit an item of Exisiting Proposal table")]
        public void WhenICanEditTheTopItemOfExisitingProposalTable()
        {
            var page = CurrentPage.As<CloudExistingProposalPage>();
            page.FindExistingPoposalList();
            page.ClickOnEditOnActionItem(CurrentDriver);
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
    }
}
