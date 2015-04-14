using System;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.SuppliesAndAccessories.Printers
{
    public class AllInOnePrintersPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".content-box.cf .box-out #total-results-heading")]
        public IWebElement PrinterSearchResultsBar;

        public bool WaitForPrinterSearchResults(string waitForText)
        {
            Helper.MsgOutput("Looking for Printer search results");
            return WaitForElementTextToExist(".content-box.cf .box-out #total-results-heading",waitForText, 60);
        }
    }
}
