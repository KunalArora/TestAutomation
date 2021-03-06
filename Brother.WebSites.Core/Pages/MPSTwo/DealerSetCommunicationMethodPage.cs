﻿using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerSetCommunicationMethodPage : BasePage, IPageObject
    {
        public static string Url = "/mps/dealer/contracts/manage-devices/set-communication-method";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        private const string _validationElementSelector = ".active a[href=\"/mps/dealer/contracts/manage-devices/set-communication-method\"]";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return Url;
            }
        }

        [FindsBy(How = How.CssSelector, Using = ".active a[href*=\"/set-communication-method\"]")]
        public IWebElement SetCommunicationTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputCloud_Input")]
        public IWebElement CloudCommunicationElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputEmail_Input")]
        public IWebElement EmailCommunicationTabElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonNext")]
        public IWebElement ProceedElement;


        public void IsSetCommunicationTabDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (SetCommunicationTabElement == null)
                throw new Exception("Set Communication Screen not displayed");

            AssertElementPresent(SetCommunicationTabElement, "Set communication screen");
        }

        public void SetCloudCommunicationMethod()
        {
            LoggingService.WriteLogOnMethodEntry();
            CloudCommunicationElement.Click();
        }

        public void SetEmailCommunicationMethod()
        {
            LoggingService.WriteLogOnMethodEntry();
            EmailCommunicationTabElement.Click();
        }

        public void SetCommunicationMethod(string method)
        {
            LoggingService.WriteLogOnMethodEntry(method);
            switch (method)
            {
                case  "Cloud" :
                    SetCloudCommunicationMethod();
                    break;

                case "Email" :
                    SetEmailCommunicationMethod();
                    break;
            }
        }

        public DealerSetInstallationTypePage ProceedToNextPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ProceedElement);
            
            return GetTabInstance<DealerSetInstallationTypePage>(Driver);
        }


        public DealerSendInstallationEmailPage ProceedToNextPageForEmail()
        {
            LoggingService.WriteLogOnMethodEntry();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ProceedElement);

            return GetTabInstance<DealerSendInstallationEmailPage>(Driver);
        }

    }
}
