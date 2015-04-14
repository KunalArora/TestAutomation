﻿using System;
using System.Collections.Generic;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Account
{
    public class HomePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["HomePage"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = ".button.blue")]
        public IWebElement SignInCreateAccountButton;

        public void IsSignInCreateAccountButtonAvailable()
        {
            if (SignInCreateAccountButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(SignInCreateAccountButton, "Sign in / Create an account");
        }

        public RegistrationPage ClickSignInCreateAccountButton(string country)
        {
            MoveToElement(SignInCreateAccountButton);
            SignInCreateAccountButton.Click();
            var title = ValidateCountryTitle(country);
            return GetInstance<RegistrationPage>(Driver, BasePage.BaseUrl, title);
        }

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

        public static String ValidateCountryTitle(string country)
        {
            string title;
            return _pageTitle.TryGetValue(country, out title) ? title : string.Empty;
        }

    }

}
