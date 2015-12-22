using System;
using System.Collections.Generic;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement.PaymentMethods
{
    public class MyPaymentMethodsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".button-blue.new-card")]
        public IWebElement AddPaymentMethodButton;

        [FindsBy(How = How.CssSelector, Using = ".card-details p")] 
        public IList<IWebElement> CreditCardDetailsList;

        [FindsBy(How = How.CssSelector, Using = ".card-details")]
        public IWebElement CreditCardDetails;

        [FindsBy(How = How.CssSelector, Using = "#Warnings")]
        public IWebElement WarningMessagePaymentMethod;

        //AddedLocator 

        [FindsBy(How = How.XPath, Using = ".//*[@id='AddPaymentBtn']")]
        public IWebElement AddPaymentMethodBtn;

        //added 22/12
     
        [FindsBy(How = How.XPath, Using = ".//*[@id='main']/div/div/div[2]/div/h3")]
        public IWebElement OrderConfirmationPageMessage;


        public void IsOrderConfirmationPageMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, OrderConfirmationPageMessage.Displayed, " Is order confirmation message displayed");
        }

        public void IsAddPaymentMethodButtonAvailable()
        {
            if (AddPaymentMethodButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(AddPaymentMethodButton, "Add Payment Method Button");
        }

        public void IsAddPaymentMethodBtnDisplayed()
        {
            TestCheck.AssertIsEqual(true, AddPaymentMethodBtn.Displayed,"Is Button Displayed");
            
        }

        public BillingDetailsPage MyPaymentMethodsAddPaymentMethodButtonClick()
        {
            MoveToElement(AddPaymentMethodButton);
            AddPaymentMethodButton.Click();
            return GetInstance<BillingDetailsPage>(Driver); 
        }

        public BillingDetailsPage AddPaymentMethodButtonClick()
        {
            AddPaymentMethodButton.Click();
            return GetInstance<BillingDetailsPage>(Driver);
        }

        public void IsCardDetailsInformationAvailable()
        {
            if (CreditCardDetails == null)
            {
                throw new Exception("Unable to locate information on page");
            }
            AssertElementPresent(CreditCardDetails, "Credit Card Information");
        }

        public void ValidateCorrectCreditCardTypeWasAdded()
        {
            if (CreditCardDetailsList != null && CreditCardDetailsList.Count > 0)
            {
                var type = CreditCardDetailsList[0].Text;
                TestCheck.AssertIsEqual(CreditCardDetailsList[0].Text.Contains(Helper.CreditCardType), true, "Credit Card Type");
            }
        }

        public void ValidateCorrectExpiryDateWasAdded()
        {
            if (CreditCardDetailsList != null && CreditCardDetailsList.Count > 0)
            {
                var type = CreditCardDetailsList[0].Text;
                TestCheck.AssertIsEqual(CreditCardDetailsList[0].Text.Contains(Helper.CreditCardType), true, "Credit Card Expiry Date");
            }
        }
        public void PaymentMehodErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, WarningMessagePaymentMethod.Displayed, "Is Error Message Displayed");
        }
    }
}
