using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminDashBoardPage : BasePage, IPageObject
    {
        public static string Url = "/mps/local-office/dashboard";
        private const string _validationElementSelector = ".separator [href=\"/mps/local-office/admin\"]"; // Admin URL selector
        private const string _url = "/mps/local-office/dashboard";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }



        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/lease-and-click'] .media-body")]
        public IWebElement LeasingContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/purchase-and-click'] .media-body")]
        public IWebElement PurchaseAndClickLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/all-in-click'] .media-body")]
        public IWebElement AllInClickLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/dealers'] .media-body")]
        public IWebElement DealerDefaultsElement;
        [FindsBy(How = How.CssSelector, Using = ".media a[href=\"/mps/local-office/programs\"]")]
        public IWebElement LOAdminProgramElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/admin\"] .media-body")]
        public IWebElement LOAdminAdministrationLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/reports\"] .media-body")]
        public IWebElement LOAdminReportElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/enhanced-usage-monitoring-admin/installed-printer\"] .media-body")]
        public IWebElement ManageDeviceOrderThresholdLink;
        

      

        public void IsPurchaseAndClickLinkAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (PurchaseAndClickLinkElement == null) 
                throw new Exception("Unable to locate Purchase And Click link on dashboard page");

            AssertElementPresent(PurchaseAndClickLinkElement, "Create New Proposal Link");
        }

        

        public void IsDealerDefaultsLinkAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (DealerDefaultsElement == null)
                throw new Exception("Unable to locate dealer defaults link on dashboard page");

            AssertElementPresent(DealerDefaultsElement, "Create Dealer Defaults Link");
        }

        public LocalOfficeAdminProgramsDashboardPage NavigateToLoProgramPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (LOAdminProgramElement == null)
                throw new NullReferenceException("EPP link is not LOAdmin Dashboard");
            LOAdminProgramElement.Click();
            return GetTabInstance<LocalOfficeAdminProgramsDashboardPage>(Driver);
        }

        public LocalOfficeReportsDashboardPage NavigateToReportPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (LOAdminReportElement == null)
                throw new NullReferenceException("Report link is not LOAdmin Dashboard");
            LOAdminReportElement.Click();
            return GetTabInstance<LocalOfficeReportsDashboardPage>(Driver);
        }
        

        public LocalOfficeAdminDealerDefaultsPage NavigateToDealerDefaultsPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsDealerDefaultsLinkAvailable();
            DealerDefaultsElement.Click();
            return GetTabInstance<LocalOfficeAdminDealerDefaultsPage>(Driver);
        }

        public LocalOfficeAdminAdministrationDashboardPage NavigateToAdministrationPagePage()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (LOAdminAdministrationLinkElement == null)
                throw new Exception("Administration link is not displayed");
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, LOAdminAdministrationLinkElement);
            return GetTabInstance<LocalOfficeAdminAdministrationDashboardPage>(Driver);
        }

        public string ClickLanguageLink()
        {
            LoggingService.WriteLogOnMethodEntry();
            var languageLinkElement = SeleniumHelper.FindElementByCssSelector(string.Format("a[href='/mps/local-office/dashboard?sc_lang={0}']", CultureInfo.Name));
            var language = languageLinkElement.Text;
            SeleniumHelper.ClickSafety(languageLinkElement);
            return language;
        }
    }
}
