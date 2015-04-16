using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.BrotherMainSite.SuppliesAndAccessories.Printers
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
