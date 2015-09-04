using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages8._0.FooterNavPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;



namespace Brother.WebSites.Core.Pages8._0.BrotherMainSite
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

       public void CheckPageExist()
       {
           AssertElementPresent(UsernameInputField, "login input field");
       }


    }
}


