using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
   public class FooterNavigationPage : BasePage
    {
            
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#loginuser")]
        public IWebElement UsernameInputField;

        [FindsBy(How = How.CssSelector, Using = "[href='http://www.brother-network.co.uk/']")]
        public IWebElement BrotherNetwork;

        public void HoverAndClickBrotherNetwork()
        {
            BrotherNetwork.Click();
        }

        public void CheckPageExist()
        {
            AssertElementPresent(UsernameInputField, "login input field");
        }
    }
}


