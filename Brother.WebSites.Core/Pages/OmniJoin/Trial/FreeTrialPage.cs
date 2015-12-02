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

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_trynowcontentright_0_FirstNameTextBox']/input")] public IWebElement FirstNameTxtBox;
        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_trynowcontentright_0_LastNameTextBox']/input")] public IWebElement LastNameTxtBox;
        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_trynowcontentright_0_EmailAddressTextBox']/input")] public IWebElement EmailAddressTxtBox;
        [FindsBy(How = How.CssSelector, Using = "#content_0_trynowcontentright_0_OptionalPhoneNumberTextBox")] public IWebElement PhoneNumberTxtBox;
        [FindsBy(How = How.CssSelector, Using = "#content_0_trynowcontentright_0_StartFreeTrialButton")] public IWebElement StartFreeTrailButton;
             
        [FindsBy(How = How.XPath, Using = ".//*[@id='main']/div/div/div[3]/div[2]")] public IWebElement GetYourFreeTrailText;
        [FindsBy(How = How.XPath, Using = ".//*[@id='txtFirstName']")] public IWebElement FreeOjSignUpFirstNameTextBox;
        [FindsBy(How = How.XPath, Using = ".//*[@id='txtLastName']")]  public IWebElement FreeOjSignUpLastNameTextBox;
        [FindsBy(How = How.XPath, Using = ".//*[@id='txtEmailAddress']")] public IWebElement FreeOjSignUpEmailAddressTextBox; 
        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_maincontent_2_txtPassword']")] public IWebElement FreeOjSignUpPasswordTxtBox;
        [FindsBy(How = How.XPath, Using = ".//*[@id='txtConfirmPassword']")] public IWebElement FreeOjSignUpChangePasswordTxtBox;
        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_maincontent_2_txtPhoneNumber']")] public IWebElement FreeOjSignUpPhoneNumberTxtBox;
        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_maincontent_2_chkTerms']")] public IWebElement FreeOjSignUpTermsofServicesCheckbox;
        [FindsBy(How = How.XPath, Using = ".//*[@id='main']/div/div/div[3]/div[3]/div[8]/input")] public IWebElement FreeOjTrailSignUpButton;
                                             
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

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_trynowcontentright_0_TermsAndConditionsCheckbox']")]
        public IWebElement TermsAndServicesCheckBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_vldRegExEmail")]
        public IWebElement EmailAddressErrorMessage;
        
        [FindsBy(How = How.CssSelector, Using = ".button-orange")]
        public IWebElement SubmitButton;

        [FindsBy(How = How.XPath, Using = ".//*[@id='content_0_maincontent_2_ctl08']")]
        public IWebElement ErrorMessageDisplayedTAndCField;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_ctl26")]
        public IWebElement ErrorMessageDisplayedConfirmPasswordField;

        [FindsBy(How = How.CssSelector, Using = "#content_0_maincontent_2_vldRegExPassword")]
        public IWebElement ErrorMessageDisplayedPasswordField;
         
        public void IsSubmitButtonAvailable()
        {
            if (StartFreeTrailButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(StartFreeTrailButton, "Submit (Free-trial) Button");
        }
        public void IsStartFreeTrailButtonAvailable()
        {
            if (StartFreeTrailButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(StartFreeTrailButton, "StartWebFreeTrailButton");
        }


        public FreeTrialDownloadPage SubmitButtonClick()
        {
            StartFreeTrailButton.Click();
            return GetInstance<FreeTrialDownloadPage>(Driver);
        }
        public FreeTrialDownloadPage StartFreeTrailButtonClick()
        {
            StartFreeTrailButton.Click();
            return GetInstance<FreeTrialDownloadPage>(Driver);
        }

        public void PopulateFirstNameTextBox(string firstName)
        {
            FirstNameTextBox.SendKeys(firstName);
            TestCheck.AssertIsEqual(firstName, GetTextBoxValue("txtFirstName"), "FirstName Text Box");
        }

        public void PopulateFreeOjSignUpFirstNameTextBox(string firstName)
        {
            FreeOjSignUpFirstNameTextBox.SendKeys(firstName);
          
        }
        public void PopulateFreeOjSignUpLastNameTextBox(string lastName)
        {

            FreeOjSignUpLastNameTextBox.SendKeys(lastName);
        
          
        }
        public void PopulateFreeOjSignUpEmailAddressTextBox(string emailAddress)
        {
            emailAddress = Email.GenerateUniqueEmailAddress();
            FreeOjSignUpEmailAddressTextBox.SendKeys(emailAddress);
            FreeOjSignUpEmailAddressTextBox.SendKeys(Keys.Tab);
            TestCheck.AssertIsEqual(emailAddress, GetTextBoxValue("txtEmailAddress"), "Email Address Text Box");
        }

        public void PopulateFirstNameTxtBox(string firstName)
        {
            FirstNameTxtBox.Clear();
            FirstNameTxtBox.SendKeys(firstName);
            
        }
        public void PopulateLastNameTextBox(string lastName)
        {
           
            LastNameTextBox.SendKeys(lastName);
            LastNameTextBox.SendKeys(Keys.Tab);
            TestCheck.AssertIsEqual(lastName, GetTextBoxValue("txtLastName"), "LastName Text Box");
        }

        public void PopulateLastNameTxtBox(string lastName)
        {
            LastNameTxtBox.Clear();
            LastNameTxtBox.SendKeys(lastName);
            LastNameTxtBox.SendKeys(Keys.Tab);
            
        }

        public void PopulateEmailAddressTextBox(string emailAddress)
        {
            if (emailAddress.Equals(string.Empty))
            {
                emailAddress = Email.GenerateUniqueEmailAddress();
            }
            emailAddress = Email.GenerateUniqueEmailAddress();
            EmailAddressTextBox.SendKeys(emailAddress);
            EmailAddressTextBox.SendKeys(Keys.Tab);
            TestCheck.AssertIsEqual(emailAddress, GetTextBoxValue("txtEmailAddress"), "Email Address Text Box");
        }


        public void PopulateEmailAddressTxtBox(string emailAddress)
        {
            EmailAddressTxtBox.Clear();
            if (emailAddress.Equals(string.Empty))
            {
                emailAddress = Email.GenerateUniqueEmailAddress();
            }
         
            EmailAddressTxtBox.SendKeys(emailAddress);
            EmailAddressTxtBox.SendKeys(Keys.Tab);
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

        public void PopulateFreeOjSignUpPasswordTxtBox(string password)
        {
            FreeOjSignUpPasswordTxtBox.SendKeys(password);
        }
        public void PopulateFreeOjSignUpConfirmPasswordTxtBox(string password)
        {
            FreeOjSignUpChangePasswordTxtBox.SendKeys(password);
        }
        public void PopulateFreeOjSignUpPhoneNumberTxtBox(string phoneNumber)
        {
            FreeOjSignUpPhoneNumberTxtBox.SendKeys(phoneNumber);
           
        }
        public void FreeOjSignUpTermstoServices()
        {
            ScrollTo(FreeOjSignUpTermsofServicesCheckbox);
            FreeOjSignUpTermsofServicesCheckbox.Click();

        }
        public void PopulatePhoneNumberTextBox(string phoneNumber)
        {
            PhoneNumberTxtBox.SendKeys(phoneNumber);
            TestCheck.AssertIsEqual(phoneNumber, GetTextBoxValue("content_0_maincontent_2_txtPhoneNumber"), "Phone Number Text Box");
        }

        public void PopulatePhoneNumberTxtBox(string phoneNumber)
        {
            PhoneNumberTxtBox.SendKeys(phoneNumber);
            TestCheck.AssertIsEqual(phoneNumber, GetTextBoxValue("#content_0_trynowcontentright_0_OptionalPhoneNumberTextBox"), "Phone Number Text Box");
        }

        public void AgreeToTermsAndConditions()
        {
            ScrollTo(TermsAndConditionsCheckBox);
            TermsAndConditionsCheckBox.Click();
            TestCheck.AssertIsEqual(TermsAndConditionsCheckBox.Selected.ToString(), "True", "Accept Terms and Conditions Button");
        }
        public void AgreeToTermsAndServices()
        {
            ScrollTo(TermsAndServicesCheckBox);
            TermsAndServicesCheckBox.Click();
           
        }

        public void PopulateInvalidEmailAddressTextBox(string invalidemailaddress)
        {
            EmailAddressTxtBox.SendKeys(invalidemailaddress);
            EmailAddressTxtBox.SendKeys(Keys.Tab);
        }

        public void ErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, EmailAddressErrorMessage.Displayed, "Is Email Error message displayed");
        }

        public void ErrorMessageDisplayedTermsConditionsField()
        {
            TestCheck.AssertIsEqual(true, ErrorMessageDisplayedTAndCField.Displayed, "Is Error Message Displayed");
        }

        public void SubmitButtonClickBeforeTAndC()
        {
            StartFreeTrailButton.Click();
        }
        public void ErrorMessageDisplayedPasswordConfirmationField()
        {
            TestCheck.AssertIsEqual(true, ErrorMessageDisplayedConfirmPasswordField.Displayed, "Is Error Message Displayed");

        } 

        public void ErrorMessageDisplayedPasswordFields()
        {
            TestCheck.AssertIsEqual(true, ErrorMessageDisplayedPasswordField.Displayed, "Is Error Message Displayed");
        }

        public void GetYourFreeTrailTextDisplayed()
        {
            TestCheck.AssertIsEqual(true, GetYourFreeTrailText.Displayed,"Is Text Displayed");
        }
        public FreeTrialDownloadPage FreeOjTrailSignUpButtonClick()
        {
            FreeOjTrailSignUpButton.Click();
            return GetInstance<FreeTrialDownloadPage>(Driver);
        }
    }
}
