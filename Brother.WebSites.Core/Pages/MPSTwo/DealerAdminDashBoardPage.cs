using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerAdminDashBoardPage : BasePage
    {
        public static string Url = "/mps/dealer/admin/dashboard";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/admin/staff'] .media-body")] 
        public IWebElement CreateAndManagerStaffElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/admin/default-margins'] .media-body")] 
        public IWebElement DefaultMarginsElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/dealer/admin/profile'] .media-body")]
        public IWebElement DealershipProfileElement;
       

        private void IsDefaultMarginsLinkAvailable()
        {
            if (DefaultMarginsElement == null)
                throw new Exception("Unable to locate default margins on dashboard page");

            AssertElementPresent(DefaultMarginsElement, "Create New Default Margins Link");
        }

        private void IsDealershipProfileLinkAvailable()
        {
            if (DealershipProfileElement == null)
                throw new Exception("Unable to locate Dealership Profile on dashboard page");

            AssertElementPresent(DealershipProfileElement, "Dealership Profile Link");
        }

        public DealerAdminDefaultMarginsPage NavigateToDealerAdminDefaultMarginsPage()
        {
            IsDefaultMarginsLinkAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, DefaultMarginsElement);
            return GetTabInstance<DealerAdminDefaultMarginsPage>(Driver);
        }

        public DealerAdminDealershipProfilePage NavigateToDealerAdminDealershipProfilePage()
        {
            IsDealershipProfileLinkAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, DealershipProfileElement);
            return GetTabInstance<DealerAdminDealershipProfilePage>(Driver);
        }

    }
}
