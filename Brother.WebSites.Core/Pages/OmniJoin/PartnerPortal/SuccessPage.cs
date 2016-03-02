using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class SuccessPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#content_1_breadcrumb_0_rptBreadcrumb_hlkBreadcrumb_0[href*='/partner-portal']")]
        public IWebElement PartnerPortalBreadcrumb;

        [FindsBy(How = How.CssSelector, Using = ".generic-btn.button-aqua")]
        public IWebElement BacktoCustomerListButton;

        public PartnerPortalPage PartnerPortalBreadcrumbClick()
        {
            if (PartnerPortalBreadcrumb == null)
            {
                throw new NullReferenceException("Partner Portal Breadcrumb is Null");
            }

            PartnerPortalBreadcrumb.Click();
            return GetInstance<PartnerPortalPage>();
        }

        public void IsBacktoCustomerListButtonDisplayed()
        {
            if (BacktoCustomerListButton == null)
            {
                throw new Exception("Unable to locate the button");
            }
            TestCheck.AssertIsEqual(true, BacktoCustomerListButton.Displayed, "Is back to customerlist button displayed");

        }

        public ManageCustomersAndOrdersPage ClickBacktoCustomerListButton()
        {
            if (BacktoCustomerListButton == null)
            {
                throw new Exception("Unable to locate the button");
            }
            BacktoCustomerListButton.Click();
            return GetInstance<ManageCustomersAndOrdersPage>(Driver);
        }
    }
}
