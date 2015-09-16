﻿using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Account
{
    public class RegistrationConfirmationPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "content_0_GoBackBtn")]
        public IWebElement GoBackButton;

        [FindsBy(How = How.CssSelector, Using = "#Warnings")]
        public IWebElement InvalidItalyTaxCodeErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#Warnings")] 
        public IWebElement InvalidItalyVatNumberErrorMessage;

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

        public void InvalidItalyTaxCodeErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, InvalidItalyTaxCodeErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void InvalidItalyTVatNumberErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, InvalidItalyVatNumberErrorMessage.Displayed, "Is Error Message Displayed");
        }
    }
}
