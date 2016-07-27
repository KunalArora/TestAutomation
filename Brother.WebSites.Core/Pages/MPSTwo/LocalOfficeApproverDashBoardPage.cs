using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverDashBoardPage : BasePage
    {
        public static string Url = "/mps/local-office/dashboard";

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




        public void IsApprovalLinkAvailable()
        {
            if (ApprovalTabElement == null)
                throw new Exception("Unable to locate Approval link on dashboard page");

            AssertElementPresent(ApprovalTabElement, "Create New Proposals Link");
        }


        public LocalOfficeApproverApprovalPage NavigateToOfficeApproverApprovalPage()
        {
            IsApprovalLinkAvailable();
            ApprovalTabElement.Click();

            return GetInstance<LocalOfficeApproverApprovalPage>(Driver);
        }

        public void SwitchBetweenMultipleLanguages()
        {
            var language = SpecFlow.GetContext("BelgianLanguage");

            if (IsBelgiumSystem())
            {
                
                SwitchBelgianLanguage(language);
            }
            else if (IsFinlandSystem())
            {
                
                SwitchFinnishLanguage(language);
            }
            else if (IsSwissSystem())
            {
                SwitchSwissLanguage(language);
            }

         }

        private void SwitchBelgianLanguage(string lang)
        {
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
            if (lang.Equals("Suomi"))
            {
                MultipleLanguagesElement.First().Click();
                IsSwitchedLanguageSelected("Hyv�ksyminen");
            }
            else if (lang.Equals("Svenska"))
            {
                MultipleLanguagesElement.Last().Click();
                IsSwitchedLanguageSelected("Godk�nnande");
            }
        }

        private void SwitchSwissLanguage(string lang)
        {
            if (lang.Equals("Deutsch"))
            {
                MultipleLanguagesElement.First().Click();
                IsSwitchedLanguageSelected("Freigabe");
            }
            else if (lang.Equals("Fran�ais"))
            {
                MultipleLanguagesElement.Last().Click();
                IsSwitchedLanguageSelected("Acceptation");
            }
        }

        private void IsSwitchedLanguageSelected(string text)
        {
            if (MultipleLanguagesElement == null)
                throw new Exception("Unable to locate existing proposals link on dashboard page");

            AssertElementContainsText(SwitchedLanguageIdentifierElement, text,
                                    String.Format("The word displayed was {0}", SwitchedLanguageIdentifierElement.Text));
        }


       
       
    }
}
