using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverDashBoardPage : BasePage, IPageObject
    {
        public static string Url = "/mps/local-office/dashboard";

        private const string _validationElementSelector = ".active a[href=\"/mps/local-office/dashboard\"]";
        private const string _url = "/mps/local-office/dashboard";

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
                return _url;
            }
        }



        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

       
        [FindsBy(How = How.CssSelector, Using = ".separator [href=\"/mps/local-office/approval\"]")]
        public IWebElement ApprovalTabElement;
        [FindsBy(How = How.CssSelector, Using = ".separator [href=\"/mps/local-office/manage-devices\"]")]
        public IWebElement DeviceManagementTabTabElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-lang > span > a")]
        public IList<IWebElement> MultipleLanguagesElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/approval'] .media-body .media-heading")]
        public IWebElement SwitchedLanguageIdentifierElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/reports\"] .media-heading")]
        public IWebElement LocalApprovalReportingElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/enhanced-usage-monitoring-authorised/installed-printer\"] .media-heading")]
        public IWebElement ManageDeviceOrderThresholdElement;
        




        public void IsApprovalLinkAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ApprovalTabElement == null)
                throw new Exception("Unable to locate Approval link on dashboard page");

            AssertElementPresent(ApprovalTabElement, "Create New Proposals Link");
        }


        public LocalOfficeApproverApprovalPage NavigateToOfficeApproverApprovalPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsApprovalLinkAvailable();
            ApprovalTabElement.Click();

            return GetInstance<LocalOfficeApproverApprovalPage>(Driver);
        }

        public LocalOfficeReportsDashboardPage NavigateToLocalOfficeApproverReportingPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsApprovalLinkAvailable();
            LocalApprovalReportingElement.Click();

            return GetInstance<LocalOfficeReportsDashboardPage>(Driver);
        }

        public void SwitchBetweenMultipleLanguages()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (IsBelgiumSystem())
            {
                try
                {
                    var language = SpecFlow.GetContext("BelgianLanguage");
                    SwitchBelgianLanguage(language);
                }
                catch (KeyNotFoundException keyNotFound)
                {
                    //Do nothing
                }
                
            }
            else if (IsFinlandSystem())
            {
                try
                {
                    var language = SpecFlow.GetContext("BelgianLanguage");
                    SwitchFinnishLanguage(language);
                }
                catch (KeyNotFoundException keyNotFound)
                {
                   //Do nothing
                }
            }
            else if (IsSwissSystem())
            {
                try
                {
                    var language = SpecFlow.GetContext("BelgianLanguage");
                    SwitchSwissLanguage(language);
                }
                catch (KeyNotFoundException keyNotFound)
                {
                   //Do nothing
                }
            }

         }

        public void ClickLanguageLink()
        {
            LoggingService.WriteLogOnMethodEntry();
            var languageLinkElement = SeleniumHelper.FindElementByCssSelector(string.Format("a[href='/mps/local-office/dashboard?sc_lang={0}']", CultureInfo.Name));
            SeleniumHelper.ClickSafety(languageLinkElement);
        }

        private void SwitchBelgianLanguage(string lang)
        {
            LoggingService.WriteLogOnMethodEntry();
            if (lang.Equals("French"))
            {
                MultipleLanguagesElement.First().Click();
                IsSwitchedLanguageSelected("Acceptation");
            }
            else if (lang.Equals("Dutch"))
            {
                MultipleLanguagesElement.Last().Click();
                IsSwitchedLanguageSelected("Goedkeuring");
            }
        }

        private void SwitchFinnishLanguage(string lang)
        {
            LoggingService.WriteLogOnMethodEntry(lang);
            if (lang.Equals("Suomi"))
            {
                MultipleLanguagesElement.First().Click();
                IsSwitchedLanguageSelected("Hyväksyminen");
            }
            else if (lang.Equals("Svenska"))
            {
                MultipleLanguagesElement.Last().Click();
                IsSwitchedLanguageSelected("Godkännande");
            }
        }

        private void SwitchSwissLanguage(string lang)
        {
            LoggingService.WriteLogOnMethodEntry(lang);
            if (lang.Equals("Deutsch"))
            {
                MultipleLanguagesElement.First().Click();
                IsSwitchedLanguageSelected("Freigabe");
            }
            else if (lang.Equals("Français"))
            {
                MultipleLanguagesElement.Last().Click();
                IsSwitchedLanguageSelected("Acceptation");
            }
        }

        private void IsSwitchedLanguageSelected(string text)
        {
            LoggingService.WriteLogOnMethodEntry(text);
            try
            {
                WaitForElementToExistByCssSelector("a[href='/mps/dealer/contracts'] .media-body .media-heading", 3, 5);

                if (SwitchedLanguageIdentifierElement == null)
                    throw new Exception("Unable to locate existing proposals link on dashboard page");

                AssertElementContainsText(SwitchedLanguageIdentifierElement, text,
                                    String.Format("The word displayed was {0}", SwitchedLanguageIdentifierElement.Text));
            }
            catch (StaleElementReferenceException e)
            {
                throw new Exception("The page refreshed and the element became stale with the following error" + e);

            }
        }
    }
}
