using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminDashBoardPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/lease-and-click'] .media-body")]
        public IWebElement LeasingContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/purchase-and-click'] .media-body")]
        public IWebElement PurchaseAndClickLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/dealer-defaults'] .media-body")]
        public IWebElement DealerDefaultsElement;        


        public void IsLeasingContractLinkAvailable()
        {
            if (LeasingContractLinkElement == null) 
                throw new Exception("Unable to locate leasing contract link on dashboard page");

            AssertElementPresent(LeasingContractLinkElement, "Create New Proposal Link");
        }

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

        public LocalOfficeAdminProgramSettingPage NavigateToPurchaseAndClickPage()
        {
            if (PurchaseAndClickLinkElement == null)
                throw new NullReferenceException("EPP link is not LOAdmin Dashboard");
            PurchaseAndClickLinkElement.Click();
            return GetTabInstance<LocalOfficeAdminProgramSettingPage>(Driver);
        }

        public LocalOfficeAdminDealerDefaultsPage NavigateToDealerDefaultsPage()
        {
            IsDealerDefaultsLinkAvailable();
            DealerDefaultsElement.Click();
            return GetTabInstance<LocalOfficeAdminDealerDefaultsPage>(Driver);
        }

        public LocalOfficeAdminProgramSettingPage NavigateToLeaseAndClickPage()
        {
            IsLeasingContractLinkAvailable();
            LeasingContractLinkElement.Click();
            return GetTabInstance<LocalOfficeAdminProgramSettingPage>(Driver);
        }

    }
}
