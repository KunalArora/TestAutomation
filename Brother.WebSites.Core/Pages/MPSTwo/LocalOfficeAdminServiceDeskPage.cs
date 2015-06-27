using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminServiceDeskPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_1_InputEmailAddress_Input")]
        public IWebElement EmailAddressElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonNext")]
        public IWebElement SaveButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/service-desk/users]")]
        public IWebElement ServiceDeskUsersLinkElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/local-office/service-desk/settings']")]
        public IWebElement ServiceDeskSettingsLinkElement;

        private void IsServiceDeskUsersLinkElementAvailable()
        {
            if (ServiceDeskUsersLinkElement == null)
                throw new NullReferenceException("Create Service desk users link");
        }

        private void IsServiceDeskSettingsElementAvailable()
        {
            if (ServiceDeskSettingsLinkElement == null)
                throw new NullReferenceException("Create Service desk settings link");
        }

        public void EnterEmailAddress(string emailaddress)
        {
            ClearAndType(EmailAddressElement, emailaddress);
        }
        
        public void ClickSave()
        {
                SaveButtonElement.Click();
        }

        public void NavigateToServiceDeskUsersPage()
        {
            IsServiceDeskUsersLinkElementAvailable();
            ServiceDeskUsersLinkElement.Click();
        }

        public void NavigateToServiceDeskSettingsPage()
        {
            IsServiceDeskSettingsElementAvailable();
            ServiceDeskSettingsLinkElement.Click();
        }
    }
}
