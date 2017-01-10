using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs._80.Test_Steps.BrotherMainSite.Purchasing
{
    [Binding]
    public class ProductPurchaseValidationSteps : BaseSteps
    {
        [When(@"I am redirected to the Brother Login/Register page")]
        public void WhenIAmRedirectedToTheBrotherLoginRegisterPage()
        {
            CurrentPage.As<RegistrationPage>().IsSignInButtonAvailable();
        }

        [When(@"I enter an email address containing ""(.*)""")]
        public void WhenIEnterAnEmailAddressContaining(string emailAddress)
        {
            CurrentPage.As<RegistrationPage>().PopulateEmailAddressTextBox(emailAddress);
        }

        [When(@"I enter a valid Password ""(.*)"" into the Password field")]
        public void WhenIEnterAValidPasswordIntoThePasswordField(string validPassword)
        {
            CurrentPage.As<RegistrationPage>().PopulatePassword(validPassword);
        }

        [When(@"I click on the signin button after entering valid login details")]
        public void WhenIClickOnTheSigninButtonAfterEnteringValidLoginDetails()
        {
            NextPage = CurrentPage.As<RegistrationPage>().ClickSignInButton();
        }

        [When(@"I click on the signin button to checkout purchase orders")]
        public void WhenIClickOnTheSigninButtonToCheckoutPurchaseOrders()
        {
            NextPage = CurrentPage.As<RegistrationPage>().ClickSignInToPurchaseItems();
        }

        [Then(@"I should see DeliveryAddress page")]
        public void ThenIShouldSeeDeliveryAddressPage()
        {
            CurrentPage.As<DeliveryDetailsPage>().IsDeliveryPageDeliverToThisAddressButtonDisplayed();
        }

        [When(@"I Choose to deliver to the existing address")]
        public void WhenIChooseToDeliverToTheExistingAddress()
        {
            NextPage = CurrentPage.As<DeliveryDetailsPage>().DeliveryPageDeliverToThisAddressButtonClick();
        }

        [Then(@"I should see the Saved payment details page")]
        public void ThenIShouldSeeTheSavedPaymentDetailsPage()
        {
            CurrentPage.As<SavedPaymentDetailsPage>().IsAddBillingButtonAvailable();
        }

        [When(@"I click AddANewDebitCard/CreditCard")]
        public void ThenIClickAddANewDebitCardCreditCard()
        {
            CurrentPage.As<SavedPaymentDetailsPage>().AddNewDebitorCreditCardButtonClick();
        }

        [When(@"I click on CardAddress Button")]
        public void ThenIClickOnCardAddressButton()
        {
            NextPage = CurrentPage.As<SavedPaymentDetailsPage>().PaymentDetailsPageCardAddressButtonClick();
        }

        [Then(@"I should see OrderSummary Page")]
        public void ThenIShouldSeeOrderSummaryPage()
        {
            CurrentPage.As<OrderSummaryPage>().IsSummaryPageProceedtoPaymentButtonDisplayed();
        }

        [When(@"I accept terms and conditions")]
        public void ThenIAcceptTermsAndConditions()
        {
            CurrentPage.As<OrderSummaryPage>().CheckSummaryPageTermsAndConditions();
        }

        [When(@"I click on proceed to payment button")]
        public void ThenIClickOnProceedToPaymentButton()
        {
            NextPage = CurrentPage.As<OrderSummaryPage>().SummaryPageProceedtoPaymentButtonClick();
        }

        [Then(@"I should see summary payment page")]
        public void ThenIShouldSeeSummaryPaymentPage()
        {
            CurrentPage.As<CreditCardDetailsPage>().IsAddNewCardSendPaymentButtonAvailable();
        }

        [When(@"I fill in creditCard details ""(.*)""")]
        public void WhenIFillInCreditCardNumberAs(string number)
        {
            CurrentPage.As<CreditCardDetailsPage>().PopulateCreditCardNumber(number);
        }

        [When(@"I select a month as ""(.*)""")]
        public void WhenISelectExpiryMonthAs(string month)
        {
            CurrentPage.As<CreditCardDetailsPage>().PopulateCreditCardExpiryMonthDropDown(month);
        }

        [When(@"I select a year as ""(.*)""")]
        public void WhenISelectExpiryYearAs(string year)
        {
            CurrentPage.As<CreditCardDetailsPage>().PopulateCreditCardExpiryYearDropDown(year);
        }

        [When(@"I fill in security number as  ""(.*)""")]
        public void WhenIFillInSecurityNumberAs(string number)
        {
            CurrentPage.As<CreditCardDetailsPage>().PopulateCreditCardCvvNumber(number);
        }
        
        [When(@"I click send to submit card details to see order confirmation")]
        public void WhenIClickSendToSumbitCardDetailsToSeeOrderConfirmation()
        {
            NextPage = CurrentPage.As<CreditCardDetailsPage>().ConfirmPaymentButtonClick();
        }

        [Then(@"I should see the Order Confirmation message along with the order number")]
        public void ThenIShouldSeeTheOrderConfirmationMessageAlongWithTheOrderNumber()
        {
            CurrentPage.As<OrderConfirmationPage>().IsOrderConfirmationMessageDisplayed();
            CurrentPage.As<OrderConfirmationPage>().IsOrderConfirmationNumberDisplayed();
        }
    }
}
