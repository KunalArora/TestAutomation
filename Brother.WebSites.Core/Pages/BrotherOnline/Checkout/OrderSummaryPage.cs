using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Checkout
{
    public class OrderSummaryPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["CheckOutOrderSummaryPage"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_0_checkoutcontent_1_PlaceOrderButton")]
        public IWebElement PlaceYourOrderButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_checkoutcontent_1_chk_TNC")] 
        public IWebElement AgreeToTermsAndConditionsCheckbox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_checkoutcontent_1_PaymentControl_PaymentGatewayIFrame")]
        public IWebElement CreditCardDetailsFrame;

        [FindsBy(How = How.CssSelector, Using = ".price")]
        public IWebElement ItemPrice;

        [FindsBy(How = How.CssSelector, Using = ".products .product-info")]
        public IWebElement ProductInfo;

        [FindsBy(How = How.CssSelector, Using = ".warning-bar")]
        public IWebElement WarningBar;

        [FindsBy(How = How.CssSelector, Using = ".info-bar")]
        public IWebElement InformationBar;

        public string GetItemPrice()
        {
            return ItemPrice.Text;
        }

        public string GetProductInfo()
        {
            return ProductInfo.Text;
        }

        public void ReloadPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        public void IsPlaceYourOrderButtonAvailable()
        {
            if (PlaceYourOrderButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(PlaceYourOrderButton, "Place Your Order Button");
        }
        
        public void PlaceYourOrderButtonClick()
        {
            ScrollTo(PlaceYourOrderButton);
            PlaceYourOrderButton.Click();
        }
        
        public void CheckTermsAndConditions()
        {
            ScrollTo(AgreeToTermsAndConditionsCheckbox);
            AgreeToTermsAndConditionsCheckbox.Click();
            TestCheck.AssertIsEqual(AgreeToTermsAndConditionsCheckbox.Selected.ToString(), "True", "Accept Terms and Conditions");
        }

        public string GetOrderCancellationWarnings()
        {
            if (WarningBar != null)
            {
                try
                {
                    if (WarningBar.Text != string.Empty)
                    {
                        return WarningBar.Text;
                    }
                }
                catch (NoSuchElementException)
                {
                    return string.Empty;
                }
                
            }
            return string.Empty;
        }

        public string GetOrderCancellationInformation()
        {
            return InformationBar != null ? InformationBar.Text : string.Empty;
        }
    }
}
