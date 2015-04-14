using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.MPSTwo
{
    public class LocalOfficeAdminDashBoardPage : Base.BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["HomePage"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/leasing'] .media-body")]
        private IWebElement LeasingContractLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/purchase-and-click'] .media-body")]
        private IWebElement EasyPrintProContractLinkElement;
        


        public void IsLeasingContractLinkAvailable()
        {
            if (LeasingContractLinkElement == null) 
                throw new Exception("Unable to locate leasing contract link on dashboard page");

            AssertElementPresent(LeasingContractLinkElement, "Create New Proposal Link");
        }

        public EasyPrintProPage NavigateToEasyPrintProPage()
        {
            if (EasyPrintProContractLinkElement == null)
                throw new NullReferenceException("EPP link is not LOAdmin Dashboard");
            EasyPrintProContractLinkElement.Click();
            return GetTabInstance<EasyPrintProPage>(Driver);
        }

    }
}
