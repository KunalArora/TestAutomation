using System;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories.Printers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
    public class MainSiteHomePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        //[FindsBy(How = How.CssSelector, Using = "#main > div > div.feature-carousel > div > ul.feature-carousel-items > li:nth-child(2) > div > a")]
        //public IWebElement SuppliesLink;

        [FindsBy(How = How.CssSelector, Using = "[href='/supplies']")]
        public IWebElement SuppliesLink;

        [FindsBy(How = How.CssSelector, Using = ".prev")]
        public IWebElement PreviousArrow;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div.feature-carousel > div > ul.feature-carousel-items > li:nth-child(1) > div > a")]
        public IWebElement PrintersLink;

        private const string CarouselItems = ".feature-carousel-items";
        
        public void IsSuppliesLinkAvailable()
        {
            SuppliesLink = Driver.FindElement(By.CssSelector(".feature-carousel-items [href='/supplies']"));
            if (!SuppliesLink.Displayed)
            {
                while (!SuppliesLink.Displayed)
                {
                    WaitForElementToExistByCssSelector(".feature-carousel-items [href='/supplies']", 1, 5);
                    PreviousArrow.Click();
                    SuppliesLink = Driver.FindElement(By.CssSelector(".feature-carousel-items [href='/supplies']"));
                }
            }
            AssertElementPresent(SuppliesLink, "Supplies Link");
        }

        public SuppliesPage ClickSuppliesLink()
        {
            //MoveToElement(SuppliesLink);
            SuppliesLink.Click();
            return GetInstance<SuppliesPage>(Driver);
        }

        public void IsPrintersLinkAvailable()
        {
            if (PrintersLink == null)
            {
                throw new NullReferenceException("Unable to locate link on page");
            }
            AssertElementPresent(PrintersLink, "Printers Link");
        }

        public PrintersPage ClickPrintersLink()
        {
            MoveToElement(PrintersLink);
            PrintersLink.Click();
            return GetInstance<PrintersPage>(Driver);
        }
    }
}
