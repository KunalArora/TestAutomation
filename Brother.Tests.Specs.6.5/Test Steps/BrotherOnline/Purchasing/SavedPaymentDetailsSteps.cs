using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement.PaymentMethods;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline.Purchasing
{
    [Binding]
    public class SavedPaymentDetailsStep : BaseSteps
    {
        [When(@"I click on Add New Address")]
        public void WhenIClickOnAddNewAddress()
        {
            // Add new Billing address
            NextPage = CurrentPage.As<SavedPaymentDetailsPage>().AddNewAddressButtonClick();
        }

        [Then(@"I should see the Saved payment details page")]
        public void ThenIShouldSeeTheSavedPaymentDetailsPage()
        {
            CurrentPage.As<SavedPaymentDetailsPage>().IsAddBillingButtonAvailable();
        }

        [When(@"I click on Add Payment Address")]
        public void WhenIClickOnAddPaymentAddress()
        {
            CurrentPage.As<SavedPaymentDetailsPage>().AddBillingAddressButtonClick();
        }

        [When(@"Click on Use This Address")]
        public void WhenClickOnUseThisAddress()
        {
            CurrentPage.As<SavedPaymentDetailsPage>().IsBillToThisAddressButtonAvailable();
            NextPage = CurrentPage.As<SavedPaymentDetailsPage>().BillToThisAddressButtonClick();
        }

        [Then(@"I can add a new payment method")]
        public void ThenICanAddANewPaymentMethod()
        {
            CurrentPage.As<MyPaymentMethodsPage>().IsAddPaymentMethodButtonAvailable();
            NextPage = CurrentPage.As<MyPaymentMethodsPage>().AddPaymentMethodButtonClick();
        }

        [Then(@"I can see the Credit Card details I have added")]
        public void ThenICanSeeTheCreditCardDetailsIHaveAdded()
        {
            CurrentPage.As<MyPaymentMethodsPage>().IsCardDetailsInformationAvailable();
            CurrentPage.As<MyPaymentMethodsPage>().ValidateCorrectCreditCardTypeWasAdded();
        }

        [Then(@"I can add a new payment method using a valid ""(.*)"" card")]
        public void ThenICanAddANewPaymentMethodUsingAValidCard(string creditCardType)
        {
            Then("I can add a new payment method");
            And("If I click on Add New Address");
            Then("I can add a new billing address details for Country \"United Kingdom\"");

            switch (creditCardType)
            {
                case "Visa":
                    And("I enter valid credit card details for a Visa Credit Card");
                    break;
                case "MasterCard":
                    And("I enter valid credit card details for a MasterCard Credit Card");
                    break;
            }
            When("I click Send to commit the new card details");
            Then("I can see the Credit Card details I have added");
        }

        [Then(@"I can add a new payment method using an invalid ""(.*)"" card")]
        public void ThenICanAddANewPaymentMethodUsingAnInvalidCard(string creditCardType)
        {
            Then("I can add a new payment method");
            And("If I click on Add New Address");
            Then("I can add a new billing address details for Country \"United Kingdom\"");

            switch (creditCardType)
            {
                case "Visa":
                    And("I enter invalid credit card details for a Visa Credit Card");
                    break;
                case "MasterCard":
                    And("I enter invalid credit card details for a MasterCard Credit Card");
                    break;
            }
            When("I click Send to commit the new card details");
            Then("I can see the Credit Card details I have added");
        }
    }
}
