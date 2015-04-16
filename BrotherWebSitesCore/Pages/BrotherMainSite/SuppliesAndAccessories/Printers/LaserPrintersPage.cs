using System.Collections.ObjectModel;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.BrotherMainSite.SuppliesAndAccessories.Printers
{
    public class LaserPrintersPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".content-box.cf .box-out #total-results-heading")]
        public IWebElement PrinterSearchResultsBar;

        private string standardPrinterFeatureList = @".cf.feature-listings-info .feature-list";
        private string secondaryPrinterFeatureList = ".cf.feature-listings-info p";
        
        private bool CheckPrinterDesc(ISearchContext element, string printerName, string featureListSearch)
        {
            try
            {
                var featureList = element.FindElement(By.CssSelector(featureListSearch));
                if (featureList.Text != string.Empty)
                {
                    Helper.MsgOutput(string.Format("Printer [{0}] contains the following feature info [{1}]",
                        printerName, featureList.Text));
                    return true;
                }
                Helper.MsgOutput(string.Format("Printer [{0}] does not contain a feature list", printerName));
            }
            catch (NoSuchElementException notFound)
            {
                Helper.MsgOutput("Unable to find Elements for Printer Information", notFound.Message);
            }
            return false;
        }

        public bool ValidatePrintersSpainPortugal()
        {
            const string printerList = "#results article";
            ReadOnlyCollection<IWebElement> printers = null;
            printers = FindPrinters(printerList);
            if (printers == null)
            {
                return false;
            }

            var validationError = false;

            Helper.MsgOutput("Checking each printer for validity");
            foreach (var element in printers)
            {
                var url = element.FindElement(By.CssSelector(".cf.feature-listings-info h3 [href]"));
                // for each printer we need to check the description exists
                if (CheckPrinterDesc(element, url.Text, secondaryPrinterFeatureList))
                {
                    Helper.MsgOutput("OK: Validating Printer Descriptions");
                }
                else
                {
                    validationError = true;
                    Helper.MsgOutput("ERROR: Validating Printer Descriptions");
                }
            }
            return validationError;
        }

        public bool ValidatePrintersRussia()
        {
            return false;
        }

        private ReadOnlyCollection<IWebElement> FindPrinters(string printerList)
        {
            ReadOnlyCollection<IWebElement> printers = null;
            try
            {
                printers = Driver.FindElements(By.CssSelector(printerList));
                if (printers.Count > 0)
                {
                    return printers;
                }
            }
            catch (NoSuchElementException elementNotFound)
            {
                Helper.MsgOutput("Unable to locate printer list", elementNotFound.Message);
            }
            return printers;
        }

        public bool ValidatePrinters()
        {
            const string printerList = "#results article";
            ReadOnlyCollection<IWebElement> printers = null;
            printers = FindPrinters(printerList);
            if (printers == null)
            {
                return false;
            }
            
            var validationError = false;

            Helper.MsgOutput("Checking each printer for validity");
            foreach (var element in printers)
            {
                var url = element.FindElement(By.CssSelector(".cf.feature-listings-info h3 [href]"));
                // for each printer we need to check the description exists
                if (CheckPrinterDesc(element, url.Text, standardPrinterFeatureList))
                {
                    Helper.MsgOutput("OK: Validating Printer Descriptions");
                }
                else
                {
                    validationError = true;
                    Helper.MsgOutput("ERROR: Validating Printer Descriptions");
                }
            }
            return validationError;
        }

        public int WaitForPrinterSearchResults()
        {
            Helper.MsgOutput("Looking for Laser Printer search results");
            const string resultsElement = "#results";
            if (!WaitForElementToExistByCssSelector(resultsElement, 4, 30)) // 2 mins is long enough
            {
                Helper.MsgOutput(string.Format("Unable to locate [{0}] element whilst searching for Printers", resultsElement));
                return 0;
            }
            const string printerList = "#results article";
            try
            {
                if (!WaitForElementToExistByCssSelector(printerList, 4, 30)) // 2 mins is long enough
                {
                    Helper.MsgOutput(string.Format("Unable to locate [{0}] any printers in the results list", printerList));
                    return 0;
                }

                ScrollToLocation(TestController.CurrentDriver, 0, (TestController.CurrentDriver.Manage().Window.Size.Height * 5));

                var printers = Driver.FindElements(By.CssSelector(printerList));
                if (printers.Count > 0)
                {
                    Helper.MsgOutput(string.Format("Found {0} laser printers in list", printers.Count));
                    return printers.Count;
                }
            }
            catch (NoSuchElementException noSuchElement)
            {
                Helper.MsgOutput("No printers returned from list", noSuchElement.Message);
            }
            return 0;
        }
    }
}
