﻿using System;
using Brother.Tests.Selenium.Lib.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.OmniJoin.PartnerPortal
{
    public class PartnerPortalPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private string partnerButtonsSearchString = ".content-box.article-page .content-unit [href*=]";

        public ManageServicePage ManageServicesButtonClick()
        {
            var manageServicesButton = Driver.FindElement(By.CssSelector(partnerButtonsSearchString.Replace("href*=", "href*='my-services'")));
            manageServicesButton.Click();
            return GetInstance<ManageServicePage>();
        }

        public void IsHomeButtonAvailable()
        {
            var homeButton = Driver.FindElement(By.CssSelector(partnerButtonsSearchString.Replace("href*=", "href*='partner-portal'")));
            if (homeButton == null)
            {
                throw new NullReferenceException("Unable to locate Home Button");
            }

            AssertElementPresent(homeButton, "Home Button");
        }
    }
}
