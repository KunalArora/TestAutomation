using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class NavigationModule : BasePage
    {
        // Static Global Navigation class which services the ORP Dealer actions

        private const string PartnerPortalBreadcrumb =
            @"#content_1_breadcrumb_0_rptBreadcrumb_hlkBreadcrumb_0[href*='/partner-portal']";

        private const string OrpHome = ".button-aqua[href='/']";
        private const string ProductList = @"#product-list";
        private const string BrotherHomePage = "#master-logo > a";
        private const string MyAccountButtons = ".conference-button[href*='']";
        private const string InstankInkButtons = ".dp-button-aqua[href*='']";
        private const string PartnerPortalButtons = ".dp-button-aqua[href*='']";
        private const string TopNavigationBar = "#primary-nav .wrapper .cf";
        private const string SignOutLink = "a[href*='sign-out']";
        private const string BackToBrotherOnlineButton = ".back-button-holder";

        public static PartnerPortalPage PartnerPortalBreadcrumbClick(IWebDriver driver)
        {
            var partnerPortalHome = driver.FindElement(By.CssSelector(PartnerPortalBreadcrumb));

            if (partnerPortalHome == null)
            {
                throw new NullReferenceException("Partner Portal Breadcrumb is Null");
            }
            partnerPortalHome.Click();
            return GetInstance<PartnerPortalPage>(driver, "", "");
        }

        public static MyAccountPage PartnerPortalReturnToMyAccount(IWebDriver driver)
        {
            var partnerPortalHomeButton = driver.FindElement(By.CssSelector(OrpHome));

            if (partnerPortalHomeButton == null)
            {
                throw new NullReferenceException("Partner Portal Home Button Null");
            }
            partnerPortalHomeButton.Click();
            return GetInstance<MyAccountPage>(driver, "", "");
        }
    }
}
