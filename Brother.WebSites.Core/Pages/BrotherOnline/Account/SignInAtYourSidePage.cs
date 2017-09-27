using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Account
{
    public class SignInAtYourSidePage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "footer.common-global-footer";
        private const string _url = "/sign-in";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        [FindsBy(How = How.Id,
            Using =
                "email"
            )]
        public IWebElement EmailAddressTextBox;

        [FindsBy(How = How.Id,
            Using =
                "password"
            )]
        public IWebElement PasswordTextBox;

        [FindsBy(How = How.Id, Using = "btnSignin")]
        public IWebElement SignInButton;

        public SignInAtYourSidePage()
        {
        }

        public void PopulateEmailAddressTextBox(string emailAddress)
        {
            EmailAddressTextBox.Clear();
            EmailAddressTextBox.SendKeys(emailAddress);
            EmailAddressTextBox.SendKeys(Keys.Tab);
        }

        public void PopulatePassword(string password)
        {
            PasswordTextBox.SendKeys(password);
        }

        public void IsSignInButtonAvailable()
        {
            if (SignInButton == null)
            {
                throw new NullReferenceException("Unable to locate sign in button on page");
            }
            AssertElementPresent(SignInButton, "Sign In Button");
        }

        public MyAccountAtYourSidePage SignInButtonToMyAccount()
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<MyAccountAtYourSidePage>(Driver);
        }
    }
}
