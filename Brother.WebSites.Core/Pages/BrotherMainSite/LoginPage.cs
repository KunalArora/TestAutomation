using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
    public class LoginPage : BasePage
    {
        public static string Url = "/sitecore/login";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement UserNameTextBox;


        public void PopulateUserNameTextBox(string userName)
        {
            UserNameTextBox.SendKeys(userName);
        }
    }
}
