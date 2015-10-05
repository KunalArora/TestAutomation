using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
    public class SuppliesPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#by-supply-number > input")]
        public IWebElement SuppliesCodeExitBox;

        [FindsBy(How = How.CssSelector, Using = "#by-supply-number > a")]
        public IWebElement SuppliesCodeSearchButton;

        [FindsBy(How = How.CssSelector, Using = "#by-device-number > input")]
        public IWebElement DeviceCodeExitBox;

        [FindsBy(How = How.CssSelector, Using = "#by-device-number > a")]
        public IWebElement DeviceCodeSearchButton;

        [FindsBy(How = How.CssSelector, Using = "#ui-id-1")]
        public IWebElement SupplierCodeDropDownList;

        public void IsSuppliesSearchButtonAvailable()
        {
            if (SuppliesCodeSearchButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(SuppliesCodeSearchButton, "Search Supplies Button");
        }

        public void AddSupplyCode(string code)
        {
            SuppliesCodeExitBox.SendKeys(code);
            WebDriver.Wait(DurationType.Second, 3);
            SuppliesCodeExitBox.SendKeys(Keys.ArrowDown);
            WebDriver.Wait(DurationType.Second, 3);
            SuppliesCodeExitBox.SendKeys(Keys.Tab);
            SuppliesCodeExitBox.SendKeys(Keys.Tab);
        }

        public void AddModelCode(string code)
        {
            DeviceCodeExitBox.SendKeys(code);
            WebDriver.Wait(DurationType.Second, 3);
            DeviceCodeExitBox.SendKeys(Keys.ArrowDown);
            WebDriver.Wait(DurationType.Second, 3);
            DeviceCodeExitBox.SendKeys(Keys.Tab);
            DeviceCodeExitBox.SendKeys(Keys.Tab);
        }

        public InkJetCartridgePage SearchSuppliesButtonClick()
        {
            SuppliesCodeSearchButton.Click();
            return GetInstance<InkJetCartridgePage>(Driver);
        }

        public OriginalSuppliesPage SearchModelSuppliesButtonClick()
        {
            DeviceCodeSearchButton.Click();
            return GetInstance<OriginalSuppliesPage>(Driver);
        }
    }
}
