using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.AccountManagement.PaymentMethods;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Checkout;
using NUnit.Framework;
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
            //CurrentPage.As<MyPaymentMethodsPage>().ValidateCorrectCCTypeWasAdded(creditCardDetails);
            //CurrentPage.As<MyPaymentMethodsPage>().ValidateCorrectExpiryDateWasAdded(creditCardDetails);
            //CurrentPage.As<MyPaymentMethodsPage>().ValidateCorrectCardEndingIsPresent(creditCardDetails);
            //CurrentPage.As<MyPaymentMethodsPage>().ValidateCorrectNameOnCardWasAdded(creditCardDetails);
            //CurrentPage.As<MyPaymentMethodsPage>().ValidateCorrectBillignAddressWasAdded(creditCardDetails);
        }
    }
}
