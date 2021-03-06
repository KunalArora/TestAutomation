﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.Trial
{
    public class FreeTrialPage : BasePage
    {
        public static string URL = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#txtFirstName")]
        public IWebElement FirstNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtLastName")]
        public IWebElement LastNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtEmailAddress")]
        public IWebElement EmailAddressTextBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_txtPassword")]
        public IWebElement PasswordTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtConfirmPassword")]
        public IWebElement ConfirmPasswordTextBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_txtPhoneNumber")]
        public IWebElement PhoneNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_chkMarketingOptIn")]
        public IWebElement SendInfoCheckBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_chkTerms")]
        public IWebElement TermsAndConditionsCheckBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_vldRegExEmail")]
        public IWebElement EmailAddressErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_vldRegExEmail")]
        public IWebElement EmailAddressValidationErrorMessage;
        
        [FindsBy(How = How.CssSelector, Using = ".button-orange")]
        public IWebElement SubmitButton;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_maincontent_2_ctl08']")]
        public IWebElement ErrorMessageDisplayedTAndCField;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_ctl26")]
        public IWebElement ErrorMessageDisplayedConfirmPasswordField;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_vldRegExPassword")]
        public IWebElement ErrorMessageDisplayedPasswordField;


        //Added StartFreeTrailOmniJoinSignUpPage Locators

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_trynowcontentright_0_StartFreeTrialButton']")] 
        public IWebElement StartFreeTrailSignUpOmniJoinButton;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_trynowcontentright_0_FirstNameTextBox']/input")]
        public IWebElement StartFreeTrailSignUpPageFirstNameTxtBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_trynowcontentright_0_LastNameTextBox']/input")]
        public IWebElement StartFreeTrialSignUpPageLastNameTxtBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_trynowcontentright_0_CompanyNameTextBox']/input")] 
        public IWebElement StartFreeTrailSignUpPageCompanyNameTxtBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_trynowcontentright_0_MandatoryPhoneNumberTextBox']/input")]
        public IWebElement StartFreeTrailOmniJoinPhoneNumberTxtBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_trynowcontentright_0_TermsAndConditionsCheckbox']")]
        public IWebElement StartFreeTrailOmniJoinTermsofServciesCheckBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_trynowcontentright_0_EmailAddressTextBox']/input")]
        public IWebElement FreeTrailEmailAddressTextBox;


        public void EnterEmailAddressTextBox(string emailAddress)
        {
            if (emailAddress.Equals(string.Empty))
            {
                emailAddress = Email.GenerateUniqueEmailAddress();
            }
            FreeTrailEmailAddressTextBox.SendKeys(emailAddress);
         
        }
         
        public void IsSubmitButtonAvailable()
        {
            if (SubmitButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AcceptCookieLaw(Driver);
            AssertElementPresent(SubmitButton, "Submit (Free-trial) Button");
        }

        public FreeTrialDownloadPage SubmitButtonClick()
        {   
           
            SubmitButton.Click();
            return GetInstance<FreeTrialDownloadPage>(Driver);
        }

        public void PopulateFirstNameTextBox(string firstName)
        {
            FirstNameTextBox.SendKeys(firstName);
            TestCheck.AssertIsEqual(firstName, GetTextBoxValue("txtFirstName"), "FirstName Text Box");
        }

        public void PopulateLastNameTextBox(string lastName)
        {
            LastNameTextBox.SendKeys(lastName);
            TestCheck.AssertIsEqual(lastName, GetTextBoxValue("txtLastName"), "LastName Text Box");
        }

        public void PopulateEmailAddressTextBox(string emailAddress)
        {
            if (emailAddress.Equals(string.Empty))
            {
                emailAddress = Email.GenerateUniqueEmailAddress();
            }

            EmailAddressTextBox.Clear();
            EmailAddressTextBox.SendKeys(emailAddress);
            EmailAddressTextBox.SendKeys(Keys.Tab);
            TestCheck.AssertIsEqual(emailAddress, GetTextBoxValue("txtEmailAddress"), "Email Address Text Box");
        }

        public void PopulateConfirmPasswordTextBox(string password)
        {
            IsPopulateConfirmPasswordTextBoxAvailable();
            ScrollTo(ConfirmPasswordTextBox);
            ConfirmPasswordTextBox.SendKeys(password);
        }

        public void IsPopulatePasswordTextBoxAvailable()
        {
            // Override PageFactory loader
            if (WaitForElementToExistByCssSelector("#content_0_maincontent_2_txtPassword",5,5))
            {
                PasswordTextBox = Driver.FindElement(By.CssSelector("#content_0_maincontent_2_txtPassword"));
            }
            AssertElementPresent(PasswordTextBox, "Password Text Box (Free-trial)");
        }

        public void IsPopulateConfirmPasswordTextBoxAvailable()
        {
            // Override PageFactory loader
            if (WaitForElementToExistByCssSelector("#txtConfirmPassword", 5, 5))
            {
                ConfirmPasswordTextBox = Driver.FindElement(By.CssSelector("#txtConfirmPassword"));
            }
            AssertElementPresent(ConfirmPasswordTextBox, "Confirm Password Text Box (Free-trial)");
        }

        public void PopulatePasswordTextBox(string password)
        {
            IsPopulatePasswordTextBoxAvailable();
            ScrollTo(PasswordTextBox);
            PasswordTextBox.SendKeys(password);
        }

        public void PopulatePhoneNumberTextBox(string phoneNumber)
        {
            PhoneNumberTextBox.SendKeys(phoneNumber);
            TestCheck.AssertIsEqual(phoneNumber, GetTextBoxValue("content_0_maincontent_2_txtPhoneNumber"), "Phone Number Text Box");
        }

        public void AgreeToTermsAndConditions()
        {
            ScrollTo(TermsAndConditionsCheckBox);
            TermsAndConditionsCheckBox.Click();
            TestCheck.AssertIsEqual(TermsAndConditionsCheckBox.Selected.ToString(), "True", "Accept Terms and Conditions Button");
        }

        public void PopulateInvalidEmailAddressTextBox(string invalidemailaddress)
        {
            EmailAddressTextBox.SendKeys(invalidemailaddress);
            EmailAddressTextBox.SendKeys(Keys.Tab);
        }

        public void ErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, EmailAddressErrorMessage.Displayed, "Is Email Error message displayed");
        }

        public void ValidationErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, EmailAddressValidationErrorMessage.Displayed, "Is Email Error message displayed");
        }
        public void ErrorMessageDisplayedTermsConditionsField()
        {
            TestCheck.AssertIsEqual(true, ErrorMessageDisplayedTAndCField.Displayed, "Is Error Message Displayed");
        }

        public void SubmitButtonClickBeforeTAndC()
        {
            SubmitButton.Click();
        }
        public void ErrorMessageDisplayedPasswordConfirmationField()
        {
            TestCheck.AssertIsEqual(true, ErrorMessageDisplayedConfirmPasswordField.Displayed, "Is Error Message Displayed");

        } 

        public void ErrorMessageDisplayedPasswordFields()
        {
            TestCheck.AssertIsEqual(true, ErrorMessageDisplayedPasswordField.Displayed, "Is Error Message Displayed");
        }

        // Added FreeTrailSignUp PO's methods

        public void PopulateStartFreeTrailOmniJoinFirstNameTxtBox(string firstName)
        {
            StartFreeTrailSignUpPageFirstNameTxtBox.Clear();
            StartFreeTrailSignUpPageFirstNameTxtBox.SendKeys(firstName);
           
        }

        public void PopulateStartFreeTrailOmniJoinLastNameTxtBox(string lastName)
        {
            StartFreeTrialSignUpPageLastNameTxtBox.Clear();
            StartFreeTrialSignUpPageLastNameTxtBox.SendKeys(lastName);
            StartFreeTrialSignUpPageLastNameTxtBox.SendKeys(Keys.Tab);

        }

        public void PopulateStartFreeTrailCompanyNameTxtBox(string companyName)
        {
            StartFreeTrailSignUpPageCompanyNameTxtBox.SendKeys(companyName);
            StartFreeTrailSignUpPageCompanyNameTxtBox.SendKeys(Keys.Tab);
        }
        public void IsStartFreeTrailOmniJoinButtonAvailable()
        {
            if (StartFreeTrailSignUpOmniJoinButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(StartFreeTrailSignUpOmniJoinButton, "Submit (Free-trial) Button");
        }


        public void PopulateStartFreeTrailOmniJoinPhoneNumberTxtBox(string phoneNumber)
        {
            StartFreeTrailOmniJoinPhoneNumberTxtBox.SendKeys(phoneNumber);
        }

        public void AgreeToStartFreeTrailOmniJoinTermsofServices()
        {
            ScrollTo(StartFreeTrailOmniJoinTermsofServciesCheckBox);
            StartFreeTrailOmniJoinTermsofServciesCheckBox.Click();
            TestCheck.AssertIsEqual(StartFreeTrailOmniJoinTermsofServciesCheckBox.Selected.ToString(), "True", "Accept Terms and Services CheckBox");
        }

        public FreeTrialDownloadPage StartFreeTrailSignUpOmniJoinButtonClick()
        {
            StartFreeTrailSignUpOmniJoinButton.Click();
            return GetInstance<FreeTrialDownloadPage>(Driver);
        }
      
    }
}
