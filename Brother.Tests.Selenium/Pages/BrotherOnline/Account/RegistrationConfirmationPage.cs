﻿using System;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Account
{
    public class RegistrationConfirmationPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["RegistrationConfirmationPage"].ToString(); }
        }

        [FindsBy(How = How.Id, Using = "content_0_GoBackBtn")]
        public IWebElement GoBackButton;

        public void IsGoBackButtonAvailable()
        {
            if (GoBackButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(GoBackButton, "Confirm Registration Go Back Button");
        }

        public RegistrationPage ClickGoBackButton()
        {
            ScrollTo(GoBackButton);
            GoBackButton.Click();
            return GetInstance<RegistrationPage>(Driver);
        }
    }
}
