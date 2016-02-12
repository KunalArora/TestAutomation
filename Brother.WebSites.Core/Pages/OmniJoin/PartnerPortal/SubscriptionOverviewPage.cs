using System;
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

        [FindsBy(How = How.CssSelector, Using = "#content_0_innercontent_2_btnPreview")]
        public IWebElement  ManageSubscriptionUpdatePlanButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_innercontent_2_valNumberOfLicencesRequired")]
        public IWebElement NumberofLicensesRequiredErrorMessage;

        [FindsBy(How = How.LinkText, Using = "Cancel Subscription")]
        public IWebElement CancelSubscripitonLink;

     

       public SubscriptionOverviewPage ClickManageSubscriptionLink()
       {
           if (ManageSubscriptionLink == null)
           {
               throw new NullReferenceException("Unable to locate the ManageSubscriptionLink ob the page");
           }
           ManageSubscriptionLink.Click();
           return GetInstance<SubscriptionOverviewPage>(Driver);
       }

       public SubscriptionOverviewPage ClickManageSubscriptionUpdatePlanButton()
       {
           if (ManageSubscriptionUpdatePlanButton == null)
           {
               throw new NullReferenceException("Unable to locate the ManageSubscriptionSubmitButton");
           }
           ManageSubscriptionUpdatePlanButton.Click();
           return GetInstance<SubscriptionOverviewPage>(Driver);
       }

       public void IsNumberofLicensesRequiredErrorMessageDisplayed()
       {
           TestCheck.AssertIsEqual(true, NumberofLicensesRequiredErrorMessage.Displayed, "Is  number of licenses reuqired error mesage displayed");
       }

       public CancelSubscriptionPage ClickCancelSubscriptionLink()
       {
           if (CancelSubscripitonLink == null)
           {
               throw new NullReferenceException("Unable to locate the cancel subscription link on the page");
           }
           CancelSubscripitonLink.Click();
           return GetInstance<CancelSubscriptionPage>(Driver);
       }
    
    }
}
