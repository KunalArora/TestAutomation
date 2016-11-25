using System;
using System.Collections.Generic;
using System.Threading;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories.Printers
{
    public class AllPrintersPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "[href*='/printers/all-in-one-printers']")]
        public IWebElement ViewAllInOnePrinterRangeButton;

        [FindsBy(How = How.CssSelector, Using = "[href*='/printers/laser-printers']")]
        public IWebElement ViewLaserPrinterRangeButton;

        [FindsBy(How = How.CssSelector, Using = ".content-box.cf .box-out #total-results-heading")]
        public IWebElement PrinterSearchResultsBar;

        [FindsBy(How = How.CssSelector, Using = @".product-results--item")]
        public IList<IWebElement> AllPrintersList;

        public void IsViewOurPrinterRangeButtonAvailable()
        {
            if (ViewAllInOnePrinterRangeButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(ViewAllInOnePrinterRangeButton, "View All In One Printer Range Button");
        }

        public AllInOnePrintersPage ViewAllInOnePrinterRangeButtonClick()
        {
            ViewAllInOnePrinterRangeButton.Click();
            return GetInstance<AllInOnePrintersPage>(Driver);
        }

        public void IsViewLaserPrinterRangeButtonAvailable()
        {
            if (ViewLaserPrinterRangeButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(ViewLaserPrinterRangeButton, "View Laser Printer Range Button");
        }

        public LaserPrintersPage ViewLaserPrinterRangeButtonClick()
        {
            ViewLaserPrinterRangeButton.Click();
            return GetInstance<LaserPrintersPage>(Driver);
        }

        public string GetPrinterSearchResults()
        {
            IWebElement printerSearchBar = null;
            try
            {
                printerSearchBar = Driver.FindElement(By.CssSelector(".content-box.cf .box-out #total-results-heading"));
            }
            catch (NoSuchElementException notFound)
            {
                TestCheck.AssertFailTest(string.Format("Unable to locate Printer Search Results bar - [{0}]", notFound));
            }
            return printerSearchBar.Text;
        }

        public int GetListOfPrintersLoaded()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            //To scroll down web page by document body size In x(vertical) direction.  
            //You can the y parameter to scroll page In horizontal direction.
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            if (AllPrintersList != null && AllPrintersList.Count > 6)
            {
                return AllPrintersList.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
