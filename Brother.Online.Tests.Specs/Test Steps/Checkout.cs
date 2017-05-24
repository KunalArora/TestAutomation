using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Brother.Tests.Selenium.Lib;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
using Brother.WebSites.Core.Pages.BrotherOnline.ThirdParty;
using TechTalk.SpecFlow;
using Brother.Online.TestSpecs._80.Test_Steps;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Online.TestSpecs._80.Test_Steps
{
    [Binding]
    public class CheckoutSteps : BaseSteps
    {

        [Given(@"That I navigate to ""(.*)"" in order to add a product to validate a published page")]
        public void GivenThatINavigateToInOrderToAddAProductToValidateAPublishedPage(string url)
        {
            CurrentPage = BasePage.LoadMainSiteHomePage(CurrentDriver, url);
            CurrentPage.As<CheckoutPage>().GetPublishedPage(url);
        }
        [Given(@"I click on Add to Basket")]
        public void GivenIClickOnAddToBasket()
        {
            CurrentPage.As<CheckoutPage>().AddToBasketButtonClick();
        }
        
        [Given(@"I browse to the ""(.*)"" BOL checkout page")]
        public void GivenIBrowseToTheBolCheckoutPage(string url)
        {
            CurrentPage = CurrentPage.As<CheckoutPage>().GoToBolBasketPage(url);
        }


        [Given(@"I click on continue as guest button")]
        public void GivenIClickOnContinueAsGuestButton()
        {
            CurrentPage.As<BasketPage>().ClickOnContinueAsGuest();
        }

        [Given(@"I click on the login button")]
        public void GivenIClickOnTheLoginButton()
        {
            CurrentPage.As<BasketPage>().ClickOnLoginButton();
        }

        [Given(@"I enter ""(.*)"" in your details")]
        public void GivenIEnterInYourDetails(string emailid)
        {
            CurrentPage.As<BasketPage>().EnterEmail(emailid);
        }

        [Given(@"I enter the registered ""(.*)"" in the Email field")]
        public void GivenIEnterTheRegisteredInTheEmailField(string emailid)
        {
            CurrentPage.As<BasketPage>().EnterExistingUserName(emailid);
        }

        [Given(@"I enter the registered ""(.*)"" in the Password field")]
        public void GivenIEnterTheRegisteredInThePasswordField(string password)
        {
            CurrentPage.As<BasketPage>().EnterPasswordForExistingUser(password);
        }

        [Given(@"I click on Existing User SiginIn Button")]
        public void GivenIClickOnExistingUserSiginInButton()
        {
            CurrentPage.As<BasketPage>().ClickOnExistingUserSignInButton();
        }

        [Given(@"I select title in your details")]
        public void GivenISelectTitleInYourDetails()
        {
            CurrentPage.As<BasketPage>().SelectTile();
        }
        [Given(@"I enter ""(.*)""  and ""(.*)"" on your details page")]
        public void GivenIEnterAndOnYourDetailsPage(string firstname, string lastname)
        {
            CurrentPage.As<BasketPage>().EnterName(firstname, lastname);
        }
        [Given(@"I enter ""(.*)"" and ""(.*)"" on your details page")]
        public void GivenIEnterOnYourDetailsPage(string phonenumber, string mobilenumber)
        {
            CurrentPage.As<BasketPage>().EnterPhoneNumber(phonenumber, mobilenumber);
        }
        [Given(@"I click on Continue to Delivery Button")]
        public void GivenIClickOnContinueToDeliveryButton()
        {
            Thread.Sleep(TimeSpan.FromSeconds(4));
            CurrentPage.As<BasketPage>().ClickOnContinueToDelivery();
        }
        [Given(@"I can register my ""(.*)"" on the delivery address step")]
        public void GivenICanRegisterMyOnTheDeliveryAddressStep(string postcode)
        {
            CurrentPage.As<BasketPage>().EnterPostcode(postcode);
        }
        [Given(@"I click on Find Address Button")]
        public void GivenIClickOnFindAddressButton()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            CurrentPage.As<BasketPage>().ClickOnFindAddressButton();
        }
        [Given(@"I enter ""(.*)"" on delivery address step")]
        public void GivenIEnterOnDeliveryAddressStep(string housenumber)
        {
            CurrentPage.As<BasketPage>().EnterHouseNumber(housenumber);
        }
        [Given(@"I click on Continue to Billing & Payment Button")]
        public void GivenIClickOnContinueToBillingPaymentButton()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            CurrentPage.As<BasketPage>().ClickOnContinueToBillingAndPayment();
        }
        [Given(@"I click on Checkbox to use the same delivery address")]
        public void GivenIClickOnCheckboxToUseTheSameDeliveryAddress()
        {
            CurrentPage.As<BasketPage>().ClickOnCheckboxUseSameDeliveryAddress();
        }

        [Given(@"I click on Continue to Payment Button")]
        public void GivenIClickOnContinueToPaymentButton()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            NextPage = CurrentPage.As<BasketPage>().ClickOnContinueToPayment();
        }
        
        [When(@"I fill in creditCard details ""(.*)""")]
        public void WhenIFillInCreditCardDetails(string number)
        {
            CurrentPage.As<PaymentPage>().EnterTheCardNumber(number);
        }

        [When(@"I select a month as (.*)")]
        public void WhenISelectAMonthAs(int month)
        {
            CurrentPage.As<PaymentPage>().SelectTheExpiryDateMonth(month.ToString());
        }

        [When(@"I select a year as ""(.*)""")]
        public void WhenISelectAYearAs(int year)
        {
            CurrentPage.As<PaymentPage>().SelectTheExpiryDateYear(year.ToString());
        }

        [When(@"I fill in security number as  ""(.*)""")]
        public void WhenIFillInSecurityNumberAs(int cvvNumber)
        {
            CurrentPage.As<PaymentPage>().EnterTheCardCVVNumber(cvvNumber.ToString());
        }

        [When(@"I click the Confirm My Payment button")]
        public void WhenIClickTheConfirmMyPaymentButton()
        {
            CurrentPage = CurrentPage.As<PaymentPage>().ClickOnConfirmPaymentButton();
        }

        [Then(@"I should see the order confirmation message")]
        public void ThenIShouldSeeTheOrderConfirmationMessage()
        {
            CurrentPage.As<OrderConfirmationPage>().IsPurchaseOrderConfirmationMessageDisplayed();
        }

    }

}
