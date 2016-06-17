using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminDashBoardPage : BasePage
    {
        public static string Url = "/mps/local-office/dashboard";

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


       

        public void IsPurchaseAndClickLinkAvailable()
        {
            if (PurchaseAndClickLinkElement == null) 
                throw new Exception("Unable to locate Purchase And Click link on dashboard page");

            AssertElementPresent(PurchaseAndClickLinkElement, "Create New Proposal Link");
        }

        

        public void IsDealerDefaultsLinkAvailable()
        {
            if (DealerDefaultsElement == null)
                throw new Exception("Unable to locate dealer defaults link on dashboard page");

            AssertElementPresent(DealerDefaultsElement, "Create Dealer Defaults Link");
        }

        public LocalOfficeAdminProgramPage NavigateToLoProgramPage()
        {
            if (LOAdminProgramElement == null)
                throw new NullReferenceException("EPP link is not LOAdmin Dashboard");
            LOAdminProgramElement.Click();
            return GetTabInstance<LocalOfficeAdminProgramPage>(Driver);
        }

        

        public LocalOfficeAdminDealerDefaultsPage NavigateToDealerDefaultsPage()
        {
            IsDealerDefaultsLinkAvailable();
            DealerDefaultsElement.Click();
            return GetTabInstance<LocalOfficeAdminDealerDefaultsPage>(Driver);
        }

        
    }
}
