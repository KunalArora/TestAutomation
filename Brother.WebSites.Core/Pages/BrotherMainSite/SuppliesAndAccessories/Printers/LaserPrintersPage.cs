﻿using System;
using System.Collections.ObjectModel;
using System.Data;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories.Printers
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
                    MsgOutput(string.Format("Printer [{0}] contains the following feature info [{1}]",
                        printerName, featureList.Text));
                    return true;
                }
                MsgOutput(string.Format("Printer [{0}] does not contain a feature list", printerName));
            }
            catch (NoSuchElementException notFound)
            {
                MsgOutput("Unable to find Elements for Printer Information", notFound.Message);
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

            MsgOutput("Checking each printer for validity");
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
                    MsgOutput("ERROR: Validating Printer Descriptions");
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
                MsgOutput("Unable to locate printer list", elementNotFound.Message);
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

            MsgOutput(string.Format("Checking each printer in a list of {0} for validity", printers.Count));
            foreach (var element in printers)
            {
                var url = element.FindElement(By.CssSelector(".cf.feature-listings-info h3 [href]"));
                // for each printer we need to check the description exists
                if (CheckPrinterDesc(element, url.Text, standardPrinterFeatureList))
                {
                    MsgOutput("OK: Validating Printer Descriptions");
                }
                else
                {
                    validationError = true;
                    MsgOutput("ERROR: Validating Printer Descriptions");
                }
            }
            return validationError;
        }

        public int WaitForPrinterSearchResults()
        {
            MsgOutput("Looking for Laser Printer search results");
            MsgOutput("Scrolling page to trigger full loading");
            ScrollToLocation(TestController.CurrentDriver, 0, (TestController.CurrentDriver.Manage().Window.Size.Height * 5));
            const string resultsElement = "#results";
            if (!WaitForElementToExistByCssSelector(resultsElement, 4, 30)) // 2 mins is long enough
            {
                MsgOutput(string.Format("Unable to locate [{0}] element whilst searching for Printers", resultsElement));
                return 0;
            }

            const string printerList = "#results article";
            try
            {
                if (!WaitForElementToExistByCssSelector(printerList, 4, 30)) // 2 mins is long enough
                {
                    MsgOutput(string.Format("Unable to locate [{0}] any printers in the results list", printerList));
                    return 0;
                }

                // get the last printer in the list and move to that last element
                ReadOnlyCollection<IWebElement> printerArray = null;
                printerArray = FindPrinters(printerList);
                ScrollTo(TestController.CurrentDriver, printerArray[printerArray.Count-1]);
                ScrollToLocation(TestController.CurrentDriver, 0, (TestController.CurrentDriver.Manage().Window.Size.Height * 10));

                var printerCount = 0;
                var printerCountReCheck = 0;

                var dynamicLoadIndex = Driver.FindElement(By.CssSelector("#dynamic-load-index"));
                for (var pageDown = 0; pageDown < 5; pageDown++)
                {
                    ScrollToLocation(TestController.CurrentDriver, 0, (TestController.CurrentDriver.Manage().Window.Size.Height * 10));
                    dynamicLoadIndex = Driver.FindElement(By.CssSelector("#dynamic-load-index"));
                }

                while (printerCountReCheck < 10)
                {
                    var printers = Driver.FindElements(By.CssSelector(printerList));
                    var indexCount = Convert.ToInt32(dynamicLoadIndex.GetAttribute("value"));
                    if (indexCount == printers.Count)
                    {
                        MsgOutput(string.Format("Found {0} {1} laser printers in list", printers.Count, indexCount));
                        return printers.Count;
                    }
                    //printerCount = printers.Count;
                    //if (printers.Count > 0)
                    //{
                    //    MsgOutput(string.Format("Found {0} {1} laser printers in list", printers.Count, numPrinters));
                    //    return printers.Count;
                    //}
                    ScrollToLocation(TestController.CurrentDriver, 0, (TestController.CurrentDriver.Manage().Window.Size.Height * 10));
                    printerCountReCheck++;
                }
                MsgOutput(string.Format("Printer count = {0}. Re-checked for printers {1} times", printerCount, printerCountReCheck));
            }
            catch (NoSuchElementException noSuchElement)
            {
                MsgOutput("No printers returned from list", noSuchElement.Message);
            }
            return 0;
        }
    }
}
