using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class BusinessDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }
        [FindsBy(How = How.XPath, Using = ".//*[@id='content_2_navigationcontainer_0_MenuItemsRepeater_LeftMenuLink_6']")]
        public IWebElement BusinessDetailsLink;
        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_1_SubmitButton")]
        public IWebElement UpdateDetailsButton;
        [FindsBy(How = How.Id, Using = "BusinessAccountYesRadioButton")]
        public IWebElement UseMyAccountForBusinessCheckbox;

        public void IsUpdateButtonAvailable()
        {
            if (UpdateDetailsButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(UpdateDetailsButton, "Continue Button");
        }
        public void UseAccountForBusiness()
        {
            UseMyAccountForBusinessCheckbox.Click();
            TestCheck.AssertIsEqual("True", UseMyAccountForBusinessCheckbox.Selected.ToString(), "Use Account For Business Button");
        }
    }





}