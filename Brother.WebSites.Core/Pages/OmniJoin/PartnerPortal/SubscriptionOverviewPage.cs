﻿using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
   public class SubscriptionOverviewPage :BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.LinkText, Using = "Manage Subscription")]
        public IWebElement  ManageSubscriptionLink;

        [FindsBy(How = How.CssSelector, Using = "#content_0_innercontent_2_btnSubmit")]
        public IWebElement  ManageSubscriptionSubmitButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_innercontent_2_valNumberOfLicencesRequired")]
        public IWebElement NumberofLicensesRequiredErrorMessage;

       public SubscriptionOverviewPage ClickManageSubscriptionLink()
       {
           if (ManageSubscriptionLink == null)
           {
               throw new NullReferenceException("Unable to locate the ManageSubscriptionLink ob the page");
           }
           ManageSubscriptionLink.Click();
           return GetInstance<SubscriptionOverviewPage>(Driver);
       }

       public SubscriptionOverviewPage ClickManageSubscriptionSubmitButton()
       {
           if (ManageSubscriptionSubmitButton == null)
           {
               throw new NullReferenceException("Unable to locate the ManageSubscriptionSubmitButton");
           }
           ManageSubscriptionSubmitButton.Click();
           return GetInstance<SubscriptionOverviewPage>(Driver);
       }

       public void IsNumberofLicensesRequiredErrorMessageDisplayed()
       {
           TestCheck.AssertIsEqual(true, NumberofLicensesRequiredErrorMessage.Displayed, "Is  number of licenses reuqired error mesage displayed");
       }
    }
}
