using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class SuccessPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#content_1_breadcrumb_0_rptBreadcrumb_hlkBreadcrumb_0[href*='/partner-portal']")]
        public IWebElement PartnerPortalBreadcrumb;

        public PartnerPortalPage PartnerPortalBreadcrumbClick()
        {
            if (PartnerPortalBreadcrumb == null)
            {
                throw new NullReferenceException("Partner Portal Breadcrumb is Null");
            }

            PartnerPortalBreadcrumb.Click();
            return GetInstance<PartnerPortalPage>();
        }
    }
}
