using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Brother.Tests.Selenium.Lib.Helpers;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminAdministrationDashboardPage : BasePage, IPageObject
    {
        private string _validationElementSelector = "a[href=\"/mps/local-office/admin/profiles-and-users\"]";
        private const string _url = "/mps/local-office/admin/dashboard";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }


        // Web Elements
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/admin/dealers\"] .media-body")]
        public IWebElement LOAdminDealerLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/local-office/admin\"]")]
        public IWebElement LOAdminAdminTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/admin/system-settings\"]")]
        public IWebElement SystemSettingsElement;


        public void IsAdministrationPageDisplayed()
        {
            if(LOAdminAdminTabElement == null)
                throw new Exception("Admin Tab is not displayed");

            AssertElementPresent(LOAdminAdminTabElement, "LOAdmin Admin page is not displayed");
        }

        public LocalOfficeAdminAdministrationDealerPage NavigateToAdministrationDealerPage()
        {
            if(LOAdminDealerLinkElement == null)
                throw new Exception("LOAdmin Dealer Link Element is not displayed");

            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, LOAdminDealerLinkElement);

            return GetInstance<LocalOfficeAdminAdministrationDealerPage>();

        }
    }
}
