using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class SignInPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '#Existing')]")]
        public IWebElement ExistingUserTab;

        [FindsBy(How = How.Id, Using = "#lnkForgottenPassword")]
        public IWebElement ForgottenPasswordLink;

        [FindsBy(How = How.Id, Using = "#txtEmail")]
        public IWebElement EnterEmailId;


        public void ClickExistingUserTab()
        {
            ExistingUserTab.Click();
        }
        public void ClickForgottenPasswordLink()
        {
            ForgottenPasswordLink.Click();
        }

        public void PopulateInvalidEmailAddress(string emailid)
        {
            EnterEmailId.SendKeys(emailid);
        }

        public void VerifyErrorMessageExist()
        {
        }



    }
}
