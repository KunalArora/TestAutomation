using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminProgramsDashboardPage : BasePage, IPageObject
    {
        public static string Url = "/mps/local-office/dashboard";

        private const string _validationElementSelector = ".mps-dashboard"; 
        private const string _url = "/mps/local-office/programs/dashboard";

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

        [FindsBy(How = How.CssSelector, Using = ".media a[href=\"/mps/local-office/programs\"]")]
        public IWebElement LOAdminProgramElement;
        [FindsBy(How = How.CssSelector, Using = ".media [href=\"/mps/local-office/programs/lease-and-click\"] h4.media-heading")]
        public IWebElement LeasingContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".media [href=\"/mps/local-office/programs/purchase-and-click\"] h4.media-heading")]
        public IWebElement PurchaseAndClickLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".media [href=\"/mps/local-office/programs/all-in-click\"] h4.media-heading")]
        public IWebElement AllInClickLinkElement;


        public void IsLeasingContractLinkAvailable()
        {
            if (LeasingContractLinkElement == null)
                throw new Exception("Unable to locate leasing contract link on dashboard page");

            AssertElementPresent(LeasingContractLinkElement, "Create New Proposal Link");
        }

        private void IsAllInClickLinkAvailable()
        {
            if (AllInClickLinkElement == null)
                throw new Exception("Unable to locate All In Click link on dashboard page");

            AssertElementPresent(AllInClickLinkElement, "Create New Proposal Link");
        }

        public LocalOfficeAdminProgramSettingPage NavigateToPurchaseAndClickPage()
        {
            if (PurchaseAndClickLinkElement == null)
                throw new NullReferenceException("EPP link is not LOAdmin Dashboard");
            PurchaseAndClickLinkElement.Click();
            return GetTabInstance<LocalOfficeAdminProgramSettingPage>(Driver);
        }

        public LocalOfficeAdminProgramSettingPage NavigateToLeaseAndClickPage()
        {
            IsLeasingContractLinkAvailable();
            LeasingContractLinkElement.Click();
            return GetTabInstance<LocalOfficeAdminProgramSettingPage>(Driver);
        }

        public LocalOfficeAdminProgramSettingPage NavigateToAllInClickPage()
        {
            IsAllInClickLinkAvailable();
            AllInClickLinkElement.Click();
            return GetTabInstance<LocalOfficeAdminProgramSettingPage>(Driver);
        }



    }
}
