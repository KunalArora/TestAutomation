using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Account;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherOnline.ThirdParty
{
    public class MailinatorEmailConfirmationPage : BasePage
    {
        public static string Url = @"http://mailinator.com/inbox.jsp?to=";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["MailinatorInboxPage"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = ".subject.ng-binding")]
        public IWebElement EmailItemLink;

        [FindsBy(How = How.CssSelector, Using = ".btn .icon-trash")]
        public IWebElement EmailDeleteButton;
        
        private string emailIFrame = @".full-height .app-content .inbox-content #mailshowdivbody [name='rendermail']";

        public void IsEmailItemlinkAvailable()
        {
            if (EmailItemLink == null)
            {
                throw new NullReferenceException("Unable to locate Email item on page");
            }
            AssertElementPresent(EmailItemLink, "Email Item Hyperlink");
        }

        public void IsDeleteEmailButtonAvailable()
        {
            if (EmailDeleteButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(EmailDeleteButton, "Email Delete Button");
        }

        public void ValidateEmailIsCorrect(string emailSubject)
        {
            if (!EmailItemLink.Text.ToLower().Contains(emailSubject))
            {
                Assert.Fail("Error verifying partial eMail subject line. Expected [{0}] Actual [{1}]", emailSubject, EmailItemLink.Text);
            }
        }

        public void ClickEmailLink()
        {
            EmailItemLink.Click();
        }

        public string GetVerifyBolAccountUrl()
        {
            var iFrame = Driver.FindElement(By.CssSelector(emailIFrame));
            Driver.SwitchTo().Frame(iFrame);

            var element = Driver.FindElement(By.CssSelector("[href*='online']"));
            Assert.IsNotNull(element, "BOL account Url");

            var validationUrl = element.GetAttribute("href");
            Driver.SwitchTo().Window(Driver.CurrentWindowHandle);

            return validationUrl;
        }


        public void DeleteEmailButtonClick()
        {
            EmailDeleteButton.Click();
            Assert.AreEqual(true, WasEmailDeleted(), "Validate Email Was Deleted");
        }

        private bool WasEmailDeleted()
        {
            var noEmailPresent = Driver.FindElement(By.CssSelector("#noemailmsg"));
            return noEmailPresent != null || false;
        }
    }
}
