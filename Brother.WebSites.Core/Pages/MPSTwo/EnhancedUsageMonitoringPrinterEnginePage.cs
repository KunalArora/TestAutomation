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
        private const string EnabledTickBox = @"#content_1_PrinterEngineRepeater_InputEnabled_{0}_Input_{0}";
        private const string ThresholdField = @"#content_1_PrinterEngineRepeater_InputThreshold_{0}_Input_{0}";

        [FindsBy(How = How.CssSelector, Using = "#content_1_InputCountries")]
        public IWebElement PrinterEngineByCountryDropdown;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement PrinterEngineList;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement SaveButton;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/bie-admin/enhanced-usage-monitoring/installed-printer\"] span")]
        public IWebElement InstalledPrinterTab;
        
        
        


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


        public EnhancedUsageMonitoringInstalledPrinterPage NavigateToEnhancedUsageMonitoringInstalledPrinterPage()
        {
            if(InstalledPrinterTab == null)
                throw new Exception("installed printer is returned as null");

            InstalledPrinterTab.Click();

            return GetInstance<EnhancedUsageMonitoringInstalledPrinterPage>();
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

        public void EnablePrinterMonoThreshold(string index)
        {
            var element = string.Format(EnabledTickBox, index);
            var tickBox = Driver.FindElement(By.CssSelector(element));

            if (String.IsNullOrWhiteSpace(tickBox.GetAttribute("checked")))
            {
                tickBox.Click();
            }
        }

        public void EnablePrinterColourThreshold(string index)
        {
            EnablePrinterMonoThreshold(index);
        }

        public void DisablePrinterThreshold(string index)
        {
            var element = string.Format(EnabledTickBox, index);
            var tickBox = Driver.FindElement(By.CssSelector(element));

            if (tickBox.Selected)
            {
                tickBox.Click();
            }
        }

        public void EnterPrinterThreshold(string threshold, string index)
        {
            var element = string.Format(ThresholdField, index);
            var tickBox = Driver.FindElement(By.CssSelector(element));

            ClearAndType(tickBox, threshold);
           
            
        }
        
    }
}
