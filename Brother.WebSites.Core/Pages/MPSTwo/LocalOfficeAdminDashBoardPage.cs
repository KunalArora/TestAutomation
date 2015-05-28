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

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/leasing'] .media-body")]
        private IWebElement LeasingContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/purchase-and-click'] .media-body")]
        private IWebElement EasyPrintProContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/dealer-defaults'] .media-body")]
        private IWebElement DealerDefaultsElement;        


        public void IsLeasingContractLinkAvailable()
        {
            if (LeasingContractLinkElement == null) 
                throw new Exception("Unable to locate leasing contract link on dashboard page");

            AssertElementPresent(LeasingContractLinkElement, "Create New Proposal Link");
        }

        public void IsDealerDefaultsLinkAvailable()
        {
            if (DealerDefaultsElement == null)
                throw new Exception("Unable to locate dealer defaults link on dashboard page");

            AssertElementPresent(DealerDefaultsElement, "Create Dealer Defaults Link");
        }

        public EasyPrintProPage NavigateToEasyPrintProPage()
        {
            if (EasyPrintProContractLinkElement == null)
                throw new NullReferenceException("EPP link is not LOAdmin Dashboard");
            EasyPrintProContractLinkElement.Click();
            return GetTabInstance<EasyPrintProPage>(Driver);
        }

        public DealerDefaultsPage NavigateToDealerDefaultsPage()
        {
            IsDealerDefaultsLinkAvailable();
            DealerDefaultsElement.Click();
            return GetTabInstance<DealerDefaultsPage>(Driver);
        }
    }
}
