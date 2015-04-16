using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Checkout;
using Brother.Tests.Selenium.Lib.Support;
using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.BrotherOnline.Checkout;
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
            CurrentPage.As<OrderConfirmationPage>().IsMyAccountButtonAvailable();
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

        [When(@"I click Cancel submit card details I should return to the My Payment Method page")]
        public void ClickCancelSubmitCardDetailsIShouldReturnToTheMyPaymentMethodPage()
        {
            NextPage = CurrentPage.As<CreditCardDetailsPage>().CancelSubmitCardButtonClick();
        }

        [When(@"I click Cancel I should return to the Order Summary page")]
        public void WhenIClickCancelIShouldReturnToTheOrderSummaryPage()
        {
            NextPage = CurrentPage.As<CreditCardDetailsPage>().CancelPaymentButtonClick();
            Assert.AreEqual(CurrentPage.As<OrderSummaryPage>().GetOrderCancellationInformation().Contains("Payment cancel"), true, "Unable to determine Order cancellation information");
            //Assert.AreEqual(CurrentPage.As<OrderSummaryPage>().GetOrderCancellationWarnings().Equals(string.Empty), true, "Unable to determine Order cancellation warning");
        }
    }
}
