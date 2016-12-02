using System;
using System.Collections.Generic;
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

        //[FindsBy(How = How.CssSelector, Using = "#by-supply-number > input")]
        [FindsBy(How = How.CssSelector, Using = "#supplies-code")]
        public IWebElement SuppliesCodeExitBox;

        [FindsBy(How = How.CssSelector, Using = "#by-supply-number > a")]
        public IWebElement SuppliesCodeSearchButton;

        [FindsBy(How = How.CssSelector, Using = "#by-device-number > input")]
        public IWebElement DeviceCodeExitBox;

        [FindsBy(How = How.CssSelector, Using = "#by-device-number > a")]
        public IWebElement DeviceCodeSearchButton;

        [FindsBy(How = How.CssSelector, Using = ".common-autocomplete_link")]
        public IList<IWebElement> SupplierCodeDropDownList;

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
            //DeviceCodeExitBox.SendKeys(Keys.ArrowDown);
            //WebDriver.Wait(DurationType.Second, 3);
            DeviceCodeExitBox.SendKeys(Keys.Tab);
            DeviceCodeExitBox.SendKeys(Keys.Tab);
        }

        public InkJetCartridgePage SearchForSuppliesItem(string itemCode)
        {
            SuppliesCodeExitBox.SendKeys(itemCode);
            WebDriver.Wait(DurationType.Second, 3);
            if (SupplierCodeDropDownList != null)
            {
                for (int i = 0; i < SupplierCodeDropDownList.Count; i++)
                {
                    if (string.Equals(itemCode, SupplierCodeDropDownList[i].Text.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        SupplierCodeDropDownList[i].Click();
                        WebDriver.Wait(DurationType.Second, 3);
                        break;
                    }
                }
            }
            else
            {
                throw new NullReferenceException("Unable to find the item.");
            }
            InkJetCartridgePage.SetExtraPageTitle = itemCode;
            return GetInstance<InkJetCartridgePage>(Driver);
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
