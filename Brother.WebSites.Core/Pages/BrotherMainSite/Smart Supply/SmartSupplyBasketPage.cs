using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite.Smart_Supply
{
    internal class SmartSupplyBasketPage : BasePage
    {
        public static SmartSupplyBasketPage Productpageload(IWebDriver driver)
        {
            return GetInstance<SmartSupplyBasketPage>(driver, "", "");
        }

        [FindsBy(How = How.CssSelector, Using = ".styled-checkbox")]
        public IWebElement BSCOptincheckbox;

        [FindsBy(How = How.CssSelector, Using = ".BC-basket li")]
        public IList<IWebElement> BSCBasketpageBenefits;

        [FindsBy(How = How.CssSelector, Using = "#div.row.delivery.cf.BC-basket")]
        public IWebElement BCBasketElements;


    }
}
