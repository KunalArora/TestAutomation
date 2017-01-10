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

        [Then(@"I click AddANewDebitCard/CreditCard")]
        public void ThenIClickAddANewDebitCardCreditCard()
        {
            CurrentPage.As<SavedPaymentDetailsPage>().AddNewDebitorCreditCardButtonClick();
        }

        [Then(@"I click on CardAddress Button")]
        public void ThenIClickOnCardAddressButton()
        {
            NextPage = CurrentPage.As<SavedPaymentDetailsPage>().PaymentDetailsPageCardAddressButtonClick();
        }

        [Then(@"I should see OrderSummary Page")]
        public void ThenIShouldSeeOrderSummaryPage()
        {
            CurrentPage.As<OrderSummaryPage>().IsSummaryPageProceedtoPaymentButtonDisplayed();
        }

        [Then(@"I accept terms and conditions")]
        public void ThenIAcceptTermsAndConditions()
        {
         CurrentPage.As<OrderSummaryPage>().CheckSummaryPageTermsAndConditions();
        }
        [Then(@"I click on proceed to payment button")]
        public void ThenIClickOnProceedToPaymentButton()
        {
            NextPage = CurrentPage.As<OrderSummaryPage>().SummaryPageProceedtoPaymentButtonClick();
        }

        [Then(@"I should see summary payment page")]
        public void ThenIShouldSeeSummaryPaymentPage()
        {
            CurrentPage.As<CreditCardDetailsPage>().IsAddNewCardSendPaymentButtonAvailable();
        }

        //End
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

        [Then(@"I should see added credit card details")]
        public void ThenIShouldSeeAddedCreditCardDetails()
        {
            CurrentPage.As<MyPaymentMethodsPage>().IsAddPaymentMethodBtnDisplayed();
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
