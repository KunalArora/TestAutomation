using System;
using System.Threading;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories
{
    public class InkJetCartridgePage : BasePage
    {
        private static string _additionalUrl = string.Empty;

        public static string Url = "" + _additionalUrl;

        private static string _defaultExtraPageTitle = string.Empty;

        public static string SetExtraPageTitle
        {
            set { _defaultExtraPageTitle = value; }
        }

        public static string SetAdditionalPageUrl
        {
            get { return _additionalUrl; }

            set { _additionalUrl = value; }
        }

        public static string SetDefaultTitle
        {
            get { return Url; }

            set { Url = value; }
        }

        public override string DefaultTitle
        {
            get { return MainSitePageTitles.Default["InkJetSuppliesPage"].ToString() + _defaultExtraPageTitle; }
        }

        [FindsBy(How = How.CssSelector, Using = ".product-detail--cta .btn-primary")]
        public IWebElement AddToBasketButton;


        public void IsAddToBasketButtonAvailable()
        {
            if (AddToBasketButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(AddToBasketButton, "Add To Basket Button");
        }

        public void AddToBasketButtonClick()
        {
            AddToBasketButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(4));
        }
    }
}
