using System;
using System.Runtime.InteropServices;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories.Printers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages8._0.CMS
{
    public class CmsHomepage: BasePage
    {

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement UserNameTextBox;

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordTextBox;

        public void PopulateFirstNameTextBox(string username)
        {
            UserNameTextBox.SendKeys(username);
            TestCheck.AssertIsEqual(username, GetTextBoxValue("username"), "UserName Text Box");
        }

        public void PopulateLastNameTextBox(string password)
        {
            PasswordTextBox.SendKeys(password);
            TestCheck.AssertIsEqual(password, GetTextBoxValue("password"), "Password Text Box");
        }
    }
}
