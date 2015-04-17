using System;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.BrotherOnline.AccountManagement
{
    public class OrderDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".order-details top")]
        public IWebElement OrderPlaced;

        [FindsBy(How = How.CssSelector, Using = ".order-details bottom")]
        public IWebElement OrderStatus;

        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_1_BackToOrder")]
        public IWebElement BackToOrderButton;

        public void IsBackToOrderButtonAvailable()
        {
            if (BackToOrderButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(BackToOrderButton, "Back To Order Button");
        }

        public MyOrdersPage BackToOrderButtonClick()
        {
            ScrollTo(BackToOrderButton);
            BackToOrderButton.Click();
            return GetInstance<MyOrdersPage>(Driver);
        }
    }
}
