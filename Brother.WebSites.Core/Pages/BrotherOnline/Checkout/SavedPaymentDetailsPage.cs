using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Checkout
{
    public class SavedPaymentDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        //Main Page
        [FindsBy(How = How.CssSelector, Using = ".button-blue.billing-add")]
        public IWebElement AddBillingAddressButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_checkoutcontent_0_ChangeaddressLB_ChangeInvoiceaddressLB_AddNewAddressButton")]
        public IWebElement AddNewAddressButton;

        [FindsBy(How = How.CssSelector, Using = "a#content_0_checkoutcontent_0_ChangeaddressLB_ChangeInvoiceaddressLB_AddressRepeater_useAsDeliveryAddressButton_0.button-blue")]
        public IWebElement BillToThisAddressButton;

        // added

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_checkoutcontent_0_UserCreditCard']/a")] 
        public IWebElement AddNewDebitorCreditCardButton;

         [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_checkoutcontent_0_ChangeaddressLB_ChangeInvoiceaddressLB_AddressRepeater_useAsDeliveryAddressButton_0']")]
         public IWebElement PaymentDetailsPageCardAddressButton;


         [FindsBy(How = How.XPath, Using = ".//*[@id='main']/div/div/div[2]/div/div[2]/a")]
         public IWebElement OrderConfirmationPageMyAccountButton;       
      
        // Added - 
        public BillingDetailsPage AddNewDebitorCreditCardButtonClick()
        {
            AddNewDebitorCreditCardButton.Click();
            return GetInstance<BillingDetailsPage>(Driver);
        }

        public OrderSummaryPage PaymentDetailsPageCardAddressButtonClick()
        {
            PaymentDetailsPageCardAddressButton.Click();
            return GetInstance<OrderSummaryPage>(Driver);
        }
       
        public void IsOrderConfirmationPageMyAccountButtonDisplayed()
        {
            TestCheck.AssertIsEqual(true, OrderConfirmationPageMyAccountButton.Displayed," Is my account button  displayed");
        }

        public MyAccountPage OrderConfirmationPageMyAccountButtonClick()
         {
             OrderConfirmationPageMyAccountButton.Click();
            return GetInstance<MyAccountPage>(Driver);
          }
 ////////////////End
        public void IsAddBillingButtonAvailable()
        {
            if (AddBillingAddressButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(AddBillingAddressButton, "Add Billing Address Button");
        }

        public BillingDetailsPage AddNewAddressButtonClick()
        {
            AddNewAddressButton.Click();
            return GetInstance<BillingDetailsPage>(Driver);
        }

        public void IsAddNewAddressButtonAvailable()
        {
            if (AddNewAddressButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(AddNewAddressButton, "Add New Address Button");
        }

        public void IsBillToThisAddressButtonAvailable()
        {
            if (BillToThisAddressButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(BillToThisAddressButton, "Bill To This Address Button");
        }

        public void AddBillingAddressButtonClick()
        {
            AddBillingAddressButton.Click();
        }

        public OrderSummaryPage BillToThisAddressButtonClick()
        {
            if (!BillToThisAddressButton.Displayed)
            {
                ScrollTo(BillToThisAddressWrappedButton);
            }

            MoveToElement(BillToThisAddressWrappedButton);
            MoveToElement(BillToThisAddressButton);
            var displayed = AddNewAddressButton.Displayed;
            displayed = AddBillingAddressButton.Displayed;
            displayed = BillToThisAddressButton.Displayed;

            BillToThisAddressWrappedButton.SendKeys(Keys.ArrowDown);
            return  GetInstance<OrderSummaryPage>(Driver);
        }

        private IWebElement BillToThisAddressWrappedButton
        {
            get
            {
                var wrapper = this.BillToThisAddressButton as IWrapsElement;
                return wrapper != null ? wrapper.WrappedElement : null;
            }
        }
    }
}
