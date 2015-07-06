﻿using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework.Constraints;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPSTwo.Customer
{
    [Binding]
    public class DealerCanOperateCustomersSteps : BaseSteps
    {
        [Given(@"I navigate to existing customer screen")]
        public void GivenINavigateToExistingCustomerScreen()
        {
            var page = CurrentPage.As<DealerDashBoardPage>();
            NextPage = page.NavigateToExistingCustomerPage();
            
        }
        
        [Then(@"I can see the Existing Customers table")]
        public void ThenICanSeeTheExistingCustomersTable()
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            page.FindExistingCustomerList();
        }

        [Given(@"I click Create Customer Button")]
        public void GivenIClickCreateCustomerButton()
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            page.FindCreateCustomerButton();
            NextPage = page.ClickCreateCustomerPage();
        }


        [When(@"I create new Customer")]
        [When(@"I edit the customer")]
        public void WhenICreateNewCustomer()
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.FillOrganisationDetails();
            page.FillOrganisationContactDetail();
            page.FillOrganisationBankDetail("Invoice");

            NextPage = page.ClickSaveButton();
        }

        [Then(@"I can see the Created Customer")]
        [Then(@"I can see the edited Customer")]
        public void ThenICanSeeTheCreatedCustomer()
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            page.ConfirmCreatedCustomer(CurrentDriver);
        }

		[When(@"I click the delete button against ""(.*)"" on Exisiting Customers table")]
        public void WhenIClickTheDeleteButtonAgainstOnExisitingCustomersTable(string targertitem)
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            page.FindExistingCustomerList();

            if (targertitem == "NewlyCreatedItem")
            {
                page.ClickOnDeleteOnActionItemAgainstNewlyCreated(CurrentDriver);
            }
            else if (targertitem == "NewlyCreatedProposalCustomer")
            {
                page.ClickOnDeleteOnActionItemAgainstNewlyCreatedProposalCustomer(CurrentDriver);
            }
            else
            {
                page.ClickOnDeleteOnActionItem(CurrentDriver);
            }
        }
		
        [When(@"I click the ""(.*)"" button on Confirmation Dialog in Customers")]
        public void WhenIClickTheButtonOnConfirmationDialogInCustomers(string confirm)
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            if (confirm == "OK")
            {
                page.ClickAcceptOnConfrimation(CurrentDriver);
            }
            else
            {
                page.ClickDismissOnConfrimation(CurrentDriver);
            }
        }

        [Then(@"I can see the deleted customer does not exist on the table")]
        public void ThenICanSeeTheDeletedCustomerDoesNotExistOnTheTable()
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            page.NotExistTheDeletedItem(CurrentDriver);
        }

        [Then(@"I can see the deleted item still exists on the customer table")]
        public void ThenICanSeeTheDeletedItemStillExistsOnTheCustomerTable()
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            page.ExistsNotDeletedItem(CurrentDriver);
        }

        [When(@"I click the edit button against ""(.*)"" on Exisiting Customers table")]
        [Then(@"I click the edit button against ""(.*)"" on Exisiting Customers table")]
        public void WhenIClickTheEditButtonAgainstOnExisitingCustomersTable(string p0)
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            NextPage = page.ClickOnEditOnActionItemAgainstNewlyCreated(CurrentDriver);
        }

        [Then(@"I can confirm the edited Cusotemr in detail")]
        public void ThenICanConfirmTheEditedCusotemrInDetail()
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.ConfirmOrganisationDetails();
            page.ConfirmOrganisationContactDetail();
            page.ConfirmOrganisationBankDetail();
        }

    }
}
