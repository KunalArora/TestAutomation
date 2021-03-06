﻿using System;
using System.Collections.Generic;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
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
            //SuppliesCodeExitBox.SendKeys(Keys.Tab);
            //SuppliesCodeExitBox.SendKeys(Keys.Tab);
        }

        public CheckoutPage SelectItemFromList(string code)
        {
            IList<IWebElement> optionsToSelect = Driver.FindElements(By.CssSelector(".common-autocomplete_list li a"));
            for (int i = 0; i < optionsToSelect.Count; i++)
            {
                if (optionsToSelect[i].Text == code)
                {
                    optionsToSelect[i].Click();
                    break;
                }
            }
            //SuppliesCodeExitBox.SendKeys(Keys.ArrowDown);
            WebDriver.Wait(DurationType.Second, 3);
            return GetInstance<CheckoutPage>(Driver);
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

        public OriginalSuppliesPage SearchModelSuppliesButtonClick()
        {
            DeviceCodeSearchButton.Click();
            return GetInstance<OriginalSuppliesPage>(Driver);
        }
    }
}
