using System;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.BrotherMainSite.SuppliesAndAccessories.Printers
{
    public class PrintersPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "[href*='/printers/all-printers']")]
        public IWebElement ViewOurPrinterRangeButton;

        public void IsViewOurPrinterRangeButtonAvailable()
        {
            if (ViewOurPrinterRangeButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(ViewOurPrinterRangeButton, "View Printer Range Button");
        }

        public AllPrintersPage ViewOurPrinterRangeButtonClick()
        {
            ViewOurPrinterRangeButton.Click();
            return GetInstance<AllPrintersPage>(Driver);
        }
        
    }
}
