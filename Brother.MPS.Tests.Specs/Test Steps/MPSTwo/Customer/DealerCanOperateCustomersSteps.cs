using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Customer
{
    [Binding]
    public class DealerCanOperateCustomersSteps : BaseSteps
    {
        [When(@"I navigate to existing customer screen")]
        [Then(@"I navigate to existing customer screen")]
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

        [Given(@"I navigate to the details of the newly edited customer")]
        [When(@"I navigate to the details of the newly edited customer")]
        [Then(@"I navigate to the details of the newly edited customer")]
        public void ThenINavigateToTheDetailsOfTheNewlyEditedCustomer()
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            NextPage = page.ClickOnEditOnActionItemAgainstNewlyEditedCustomer();
        }

        [Given(@"I add additional address to the customer")]
        [When(@"I add additional address to the customer")]
        [Then(@"I add additional address to the customer")]
        public void ThenIAddAdditionalAddressToTheCustomer()
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
           
            
            NextPage = page.NavigateToCustomerAdditionalAddressPage();

            var page1 = CurrentPage.As<DealerCustomerAdditionalAddressPage>(); 

            page1.EnterAdditionalCustomerInformation();
            NextPage = page1.SaveAdditionalDetailsAdded();
        }

        [When(@"the newly added additional address is displayed")]
        [Given(@"the newly added additional address is displayed")]
        [Then(@"the newly added additional address is displayed")]
        public void ThenTheNewlyAddedAdditionalAddressIsDisplayed()
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.IsCustomerContractLocationAddressDisplayed();
            page.IsAdditionalAddressSuccessfullyAdded();
            NextPage = page.ClickSaveButton();
        }

        [Then(@"customer edited details are displayed")]
        public void ThenCustomerEditedDetailsAreDisplayed()
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.IsEditedCustomerDetailDisplayed();
        }


        [Then(@"customer property town edited name is correctly displayed")]
        public void ThenCustomerPropertyTownEditedNameIsCorrectlyDisplayed()
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.IsEditedCustomerTownNameDisplayed();
        }

        [Then(@"customer contact edited first name is correctly displayed")]
        public void ThenCustomerContactEditedFirstNameIsCorrectlyDisplayed()
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.IsEditedCustomerContactFirstNameDisplayed();
        }

        [Then(@"customer contact edited last name is correctly displayed")]
        public void ThenCustomerContactEditedLastNameIsCorrectlyDisplayed()
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.IsEditedCustomerContactLastNameDisplayed();
        }
        

        [Given(@"I click Create Customer Button")]
        public void GivenIClickCreateCustomerButton()
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            page.FindCreateCustomerButton();
            NextPage = page.ClickCreateCustomerPage();
        }

        [When(@"I create new Customer with payment type ""(.*)"" for ""(.*)""")]
        public void WhenICreateNewCustomerWithPaymentTypeFor(string payment, string country)
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.FillCustomerDetails(payment, country);
            NextPage = page.ClickSaveButton();
        }

        [When(@"I create new ""(.*)"" Customer with payment type ""(.*)"" for ""(.*)""")]
        public void WhenICreateNewCustomerWithPaymentTypeFor(string culture, string payment, string country)
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.FillCustomerDetails(payment, country, culture);
            NextPage = page.ClickSaveButton();
        }



        [When(@"I edit ""(.*)"" customer payment type to ""(.*)""")]
        public void WhenIEditCustomerPaymentTypeTo(string country, string payment)
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.FillCustomerDetails(payment, country);
            NextPage = page.ClickSaveButton();
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
            page.IsEditedCustomerCreated();
        }

		[When(@"I click the delete button against ""(.*)"" on Exisiting Customers table")]
        public void WhenIClickTheDeleteButtonAgainstOnExisitingCustomersTable(string targertitem)
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            page.FindExistingCustomerList();

            if (targertitem == "NewlyCreatedItem")
            {
                page.ClickOnDeleteOnActionItemAgainstNewlyCreated();
            }
            else if (targertitem == "NewlyCreatedProposalCustomer")
            {
                page.ClickOnDeleteOnActionItemAgainstNewlyCreatedProposalCustomer();
            }
		    //else
            //{
            //    page.ClickOnDeleteOnActionItem(CurrentDriver);
            //}
        }
		
        [When(@"I click the ""(.*)"" button on Confirmation Dialog in Customers")]
        public void WhenIClickTheButtonOnConfirmationDialogInCustomers(string confirm)
        {
            var page = CurrentPage.As<DealerCustomersExistingPage>();
            if (confirm == "OK")
            {
                page.ClickAcceptOnConfrimation();
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
           // page.NotExistTheDeletedItem();
           page.IsCustomerDeleted();
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
            NextPage = page.ClickOnEditOnActionItemAgainstNewlyCreated();
        }

        [Then(@"I can confirm the edited Cusotemr in detail")]
        public void ThenICanConfirmTheEditedCusotemrInDetail()
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.ConfirmOrganisationDetails();
            page.ConfirmOrganisationContactDetail();
            //page.ConfirmOrganisationBankDetail();
        }

        [Then(@"I can confirm the edited Customer in detail")]
        public void ThenICanConfirmTheEditedCustomerInDetail()
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.IsEditedDetailsRetained();
        }


        [Then(@"I can verify that payment details are displayed")]
        public void ThenICanVerifyThatPaymentDetailsAreDisplayed()
        {
            var page = CurrentPage.As<DealerCustomersManagePage>();
            page.IsPaymentDetailDisplayedAfterEditing();
        }



    }
}
