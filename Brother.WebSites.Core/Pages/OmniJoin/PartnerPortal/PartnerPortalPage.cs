﻿using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class PartnerPortalPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string PartnerButtonsSearchString = ".content-box.article-page .content-unit [href*=]";

        [FindsBy(How = How.XPath, Using = ".//*[@id='main']/div/div[2]/div/span/table/tbody/tr/td/a[1]")]
        public IWebElement MaintainaListofUsersButton;


        [FindsBy(How = How.CssSelector, Using = ".button-aqua")]
        public IWebElement HomeButton;

        public ManageServicePage ManageServicesButtonClick()
        {
            var manageServicesButton = Driver.FindElement(By.CssSelector(PartnerButtonsSearchString.Replace("href*=", "href*='my-services'")));
            manageServicesButton.Click();
            return GetInstance<ManageServicePage>();
        }

        public ManageCustomersAndOrdersPage ManageCustomersAndOrdersButtonClick()
        {
            var manageCustomersAndOrdersButton = Driver.FindElement(By.CssSelector(PartnerButtonsSearchString.Replace("href*=", "href*='my-customers'")));
            manageCustomersAndOrdersButton.Click();
            return GetInstance<ManageCustomersAndOrdersPage>();
        }

        public void IsHomeButtonAvailable()
        {
            var homeButton = Driver.FindElement(By.CssSelector(PartnerButtonsSearchString.Replace("href*=", "href*='partner-portal'")));
            if (homeButton == null)
            {
                throw new NullReferenceException("Unable to locate Home Button");
            }

            AssertElementPresent(homeButton, "Home Button");
        }
        public void IsMaintainaListofUsersButonDisplayed()
        {
            TestCheck.AssertIsEqual(true, MaintainaListofUsersButton.Displayed, "Is button displayed");
        }
       
        public ManageCustomersAndOrdersPage MaintainaListofUsersButtonClick()
        {
            MaintainaListofUsersButton.Click();
            return GetInstance<ManageCustomersAndOrdersPage>(Driver);
        }

        public void IsHomeButtonDisplayed()
        {
            TestCheck.AssertIsEqual(true, HomeButton.Displayed, "Is home button displayed");
        }
    }
}
