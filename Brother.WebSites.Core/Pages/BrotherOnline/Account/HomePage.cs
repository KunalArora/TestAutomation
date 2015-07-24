using System;
using System.Collections.Generic;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Account
{
    public class HomePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".content.cf .wrapper .hero .hero-buttons .button")]
        public IWebElement SignInCreateAccountButton;

        public void IsSignInCreateAccountButtonAvailable()
        {
            if (SignInCreateAccountButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(SignInCreateAccountButton, "Sign in / Create an account");
        }

        public RegistrationPage ClickSignInCreateAccountButton()
        {
            MoveToElement(SignInCreateAccountButton);
            SignInCreateAccountButton.Click();
            return GetInstance<RegistrationPage>(Driver);
        }

        [FindsBy(How = How.CssSelector, Using = "#AcceptCookieLawHyperLink")]
        public IWebElement AcceptCookiesButton;

        [FindsBy(How = How.CssSelector, Using = "#cookieLawBar > div > p")]
        public IWebElement CookiesInformationBar;

        //public RegistrationPage ClickCreateAccountButton()
        //{
        //    MoveToElement(CreateAccountButton);
        //    CreateAccountButton.Click();
        //    return GetInstance<RegistrationPage>(Driver);
        //}

        private static readonly Dictionary<string, string> _pageTitle = new Dictionary<string, string>
        {
            {"Spain", "Inicio de sesión / Cree una cuenta"},
	        {"Poland", "Zaloguj się / Utwórz konto"},    
	        {"United Kingdom", "Sign in / Create an account"},
	        {"Ireland", "Sign in / Create an account"},
        };

        private static readonly Dictionary<string, string> _welcomePageTitle = new Dictionary<string, string>
        {
            {"Spain", "Inicio de Brother Online"},
	        {"Poland", "Strona główna serwisu Brother Online"},    
	        {"United Kingdom", "Brother Online Home"},
	        {"Ireland", "Brother Online Home"},
        };

        public static String WelcomePageCountryTitle(string country)
        {
            string title;
            return _welcomePageTitle.TryGetValue(country, out title) ? title : string.Empty;
        }

        public void IsAcceptCookieButtonAvailable()
        {
            if (AcceptCookiesButton == null)
            {
                throw new NullReferenceException("Unable to locate accept cookies button on page");
            }
            AssertElementPresent(AcceptCookiesButton, "Accept Cookies Button", 80);
        }

        public void IsAcceptCookieButtonNotAvailable()
        {
            TestCheck.AssertIsNotEqual("True", AcceptCookiesButton.Displayed.ToString(), "Use Account For Business Button");
        }

        public void AcceptCookiesButtonClick()
        {
            ScrollTo(AcceptCookiesButton);
            AcceptCookiesButton.Click();
        }

        public void IsCookiesInformationBarAvailable()
        {
            if (CookiesInformationBar == null)
            {
                throw new NullReferenceException("Unable to locate accept cookies button on page");
            }
            AssertElementPresent(CookiesInformationBar, "Accept Cookies Button", 80);
        }
       
    }

}
