using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement.PaymentMethods;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline.Purchasing
{
    [Binding]
    public class CreditCardDetailsSteps : BaseSteps
    {
        [When(@"I click Select the Visa Credit Card Option")]
        public void WhenISelectTheVisaCreditCardOption()
        {
            CurrentPage.As<CreditCardDetailsPage>().SelectVisaOption();
        }

        [When(@"I click Select the MasterCard Credit Card Option")]
        public void WhenISelectTheMasterCardCreditCardOption()
        {
            CurrentPage.As<CreditCardDetailsPage>().SelectMasterCardOption();
        }

        [When(@"I click Send to commit the new card details")]
        public void ThenIClickSendToCommitTheNewCardDetails()
        {
            NextPage = CurrentPage.As<CreditCardDetailsPage>().SendPaymentDetailsButtonClick();
        }
        [Then(@"I should get error message to enter the card details")]
        public void ThenIShouldGetErrorMessageToEnterTheCardDetails()
        {
            CurrentPage.As<MyPaymentMethodsPage>().PaymentMehodErrorMessageDisplayed();
        }
        [When(@"I click Send")]
        public void WhenIClickSend()
        {
            NextPage = CurrentPage.As<CreditCardDetailsPage>().SendPaymentButtonClick();
        }

        [When(@"I click on Send for Payment Information on Edit Payment page")]
        public void WhenIClickSendForPaymentInformationOnEditPaymentPage()
        {
            NextPage = CurrentPage.As<CreditCardDetailsPage>().SendEditPaymentButtonClick();
        }

        [Then(@"I should see the Enter card details page")]
        public void ThenIShouldSeeTheEnterCardDetailsPage()
        {
            CurrentPage.As<CreditCardDetailsPage>().IsSendPaymentButtonAvailable();
        }

        [Then(@"I can enter a valid set of Credit Card details")]
        public void ThenICanEnterAValidSetOfCreditCardDetails()
        {
            When("I enter valid credit card details for a Visa Credit Card");
            When("I click Send");
            //CurrentPage.As<OrderConfirmationPage>().IsMyAccountButtonAvailable();
        }

        [When(@"I enter valid credit card details for a Visa Credit Card")]
        public void WhenIEnterValidCreditCardDetailsForAVisaCreditCard()
        {
            NextPage = BasePage.LoadCreditCardDetailsFrame(CurrentDriver);
            CurrentPage.As<CreditCardDetailsPage>().SwitchToCreditCardDetailsFrameOrderSummary();
            AddVisaCreditCardDetails(string.Empty);
        }

        [When(@"I enter valid credit card details for a Visa Credit Card with an expired date of ""(.*)""")]
        public void WhenIEnterValidCreditCardDetailsForAVisaCreditCardWithAnExpiredDateOf(string expiryDateOverride)
        {
            NextPage = BasePage.LoadCreditCardDetailsFrame(CurrentDriver);
            CurrentPage.As<CreditCardDetailsPage>().SwitchToCreditCardDetailsFrameAddCard();
           AddVisaCreditCardDetails(expiryDateOverride);
        }
        [When(@"I fill in valid credit card details for a Master Credit card")]
        [When(@"I fill in valid credit card details for a Visa Credit card")]
        public void WhenIFillInValidCreditCardDetailsForAVisaCreditCard()
        {

            NextPage = BasePage.LoadCreditCardDetailsFrame(CurrentDriver);
            CurrentPage.As<CreditCardDetailsPage>().SwitchToCreditCardDetailsFrameAddCard();
        }

        [When(@"I select a master card option")]
        public void WhenISelectAMasterCardOption()
        {
            CurrentPage.As<CreditCardDetailsPage>().SelectMasterCardRadioButton();
        }

        [When(@"I fill in an expired date of ""(.*)""")]
        public void WhenIFillInAnExpiredDateOf(string expiryDateOverride)
        {
           AddNewVisaCreditCardDetails(expiryDateOverride);

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
        public void WhenISelectExpiryYearAs(string  year)
        {
            CurrentPage.As<CreditCardDetailsPage>().PopulateCreditCardExpiryYearDropDown(year);
        }

        [When(@"I fill in security number as  ""(.*)""")]
        public void WhenIFillInSecurityNumberAs(string number)
        {
           CurrentPage.As<CreditCardDetailsPage>().PopulateCreditCardCvvNumber(number);
        }
        [When(@"I click send to sumbit card details")]
        public void WhenIClickSendToSumbitCardDetails()
        {
            NextPage = CurrentPage.As<CreditCardDetailsPage>().AddNewCardSendPaymentButtonClick();
        }

        [When(@"I click send to submit card details to see order confirmation")]
        public void WhenIClickSendToSumbitCardDetailsToSeeOrderConfirmation()
        {
            NextPage = CurrentPage.As<CreditCardDetailsPage>().AddNewCardSendPaymentButtonClick();
          
        }

        [Then(@"I am redirtected to the card details page")]
        public void ThenIAmRedirtectedToTheCardDetailsPage()
        {
            NextPage = BasePage.LoadCreditCardDetailsFrame(CurrentDriver);
            CurrentPage.As<CreditCardDetailsPage>().SwitchToCreditCardDetailsFrameAddCard();
        }

        [When(@"I enter valid credit card details for a MasterCard Credit Card with an expired date of ""(.*)""")]
        public void WhenIEnterValidCreditCardDetailsForAMasterCardCreditCardWithAnExpiredDateOf(string expiryDateOverride)
        {
            NextPage = BasePage.LoadCreditCardDetailsFrame(CurrentDriver);
            CurrentPage.As<CreditCardDetailsPage>().SwitchToCreditCardDetailsFrameAddCard();
            AddMasterCardCreditCardDetails(expiryDateOverride);
        }

        [When(@"I enter valid credit card details for a MasterCard Credit Card")]
        public void WhenIEnterValidCreditCardDetailsForAMasterCardCreditCard()
        {
            NextPage = BasePage.LoadCreditCardDetailsFrame(CurrentDriver);
            CurrentPage.As<CreditCardDetailsPage>().SwitchToCreditCardDetailsFrameOrderSummary();
            AddMasterCardCreditCardDetails(string.Empty);
        }

        private void AddMasterCardCreditCardDetails(string expiryOverride)
        {
            CurrentPage.As<CreditCardDetailsPage>().IsSendPaymentButtonAvailable();
            When("I click Select the MasterCard Credit Card Option");
            CurrentPage.As<CreditCardDetailsPage>().PopulateCreditCardInformation(true, expiryOverride);
        }

        private void AddVisaCreditCardDetails(string expiryOverride)
        {
            CurrentPage.As<CreditCardDetailsPage>().IsSendPaymentButtonAvailable();
            When("I click Select the Visa Credit Card Option");
            CurrentPage.As<CreditCardDetailsPage>().PopulateCreditCardInformation(true, expiryOverride);
        }

        //added method

        private void AddNewVisaCreditCardDetails(string expiryOverride)
        {
            CurrentPage.As<CreditCardDetailsPage>().IsAddNewCardSendPaymentButtonAvailable();
           When("I click Select the Visa Credit Card Option");
            CurrentPage.As<CreditCardDetailsPage>().PopulateCreditCardInformation(true, expiryOverride);
        }

        [When(@"I click Cancel submit card details I should return to the My Payment Method page")]
        public void ClickCancelSubmitCardDetailsIShouldReturnToTheMyPaymentMethodPage()
        {
            NextPage = CurrentPage.As<CreditCardDetailsPage>().CancelSubmitCardButtonClick();
        }

        [When(@"I click Cancel I should return to the Order Summary page")]
        public void WhenIClickCancelIShouldReturnToTheOrderSummaryPage()
        {
            NextPage = CurrentPage.As<CreditCardDetailsPage>().CancelPaymentButtonClick();
            TestCheck.AssertIsEqual(CurrentPage.As<OrderSummaryPage>().GetOrderCancellationInformation().Contains("Payment cancel"), true, "Unable to determine Order cancellation information");
        }
        [Then(@"I see payment details page")]
        public void ThenISeePaymentDetailsPage()
        {
           CurrentPage.As<AddNewCardPage>().IsAddNewCardChangeBillingAddressButtonAvailable();
        }

        
    }
}
