using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class EnhancedUsageMonitoringPrinterEnginePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputCountries")]
        public IWebElement PrinterEngineByCountryDropdown;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement PrinterEngineList;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement SaveButton;
        
        


        public void IsEnhancedUsageMonitoringPrinterEnginePageDisplayed()
        {
            if(PrinterEngineByCountryDropdown == null)
                throw new Exception("Printer Engine By Country Dropdown is returned as null");

            AssertElementPresent(PrinterEngineByCountryDropdown, "Printer Engine By Country Dropdown is not displayed");
        }

        public void SaveChanges()
        {
            if(SaveButton == null)
                throw new Exception("Save button is returned as null");

            SaveButton.Click();
        }


        public void IsCountryDropdownMenuWorking(string country)
        {
            if (country.Equals("United Kingdom"))
            {
                country = "UK";
            } else if (country.Equals("Germany"))
            {
                country = "Deutschland";
            }

            SelectFromDropdown(PrinterEngineByCountryDropdown, country);

        }


        public void IsPrinterEngineListDisplayed()
        {
            if(PrinterEngineList == null)
                throw new Exception("Printer Engine List is returned as null");

            AssertElementPresent(PrinterEngineList, "Printer list is not displayed after country selection");
        }
    }
}
