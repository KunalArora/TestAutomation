using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Checkout
{
    public class PaymentPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "Ecom_Payment_Card_Name")]
        public IWebElement CardHolderNameTxt;
        
        [FindsBy(How = How.CssSelector, Using = "#Ecom_Payment_Card_Number")]
        public IWebElement CardNumberTxt;

        [FindsBy(How = How.Id, Using = "Ecom_Payment_Card_ExpDate_Month")]
        public IWebElement CardExpiryDateMonth;

        [FindsBy(How = How.Id, Using = "Ecom_Payment_Card_ExpDate_Year")]
        public IWebElement CardExpiryDateYear;

        [FindsBy(How = How.Id, Using = "Ecom_Payment_Card_Verification")]
        public IWebElement CardVerficationNumber;

        [FindsBy(How = How.Id, Using = "submit3")]
        public IWebElement ConfirmPaymentButton;

        public void EnterTheCardNumber(string number)
        {   
            ScrollTo(CardNumberTxt);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            CardNumberTxt.SendKeys(number);
        }

        public void SelectTheExpiryDateMonth(string month)
        {
            SelectFromDropdown(CardExpiryDateMonth, month);
        }

        public void SelectTheExpiryDateYear(string year)
        {
            SelectFromDropdown(CardExpiryDateYear, year);
        }

        public void EnterTheCardCVVNumber(string number)
        {
            CardVerficationNumber.SendKeys(number);
        }

        public OrderConfirmationPage ClickOnConfirmPaymentButton()
        {
            try
            {
                MoveToElement(ConfirmPaymentButton);
                ConfirmPaymentButton.Click();
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                TestCheck.AssertFailTest(string.Format("Unable to reference the Confirm Payment Button on Credit Card Details Page > [{0}]", elementNotVisible));
            }
            return GetInstance<OrderConfirmationPage>(Driver);
        }
    }
}
