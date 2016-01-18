using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
   public class EditAddressPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_btnAddressSave")]
        public IWebElement SaveButton;

        [FindsBy(How = How.CssSelector, Using = "#HouseNameTextBox")]
        public IWebElement HouseNameTextBox;

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement HouseNameTextBoxErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#AddrLine1Text")]
        public IWebElement AddressLine1TextBox;

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement AddressLine1TextBoxErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#HouseNumberTextBox")]
        public IWebElement HouseNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement HouseNumberTextBoxErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#RegexPostCodeText")]
        public IWebElement PostCodeTextBox;

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement PostCodeTextBoxErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#CityTownText")]
        public IWebElement CityTownTextBox;

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement CityTownTextBoxErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#PhoneNumberText")]
        public IWebElement PhoneNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement PhoneNumberTextBoxErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_rptAddressFields_AddrLine1Validtor_1")]
        public IWebElement MandatoryFieldValidationErrorMessage;

        public void ClickSaveButton()
        {
           AssertElementPresent(SaveButton, "Save Button");
           SaveButton.Click();
          
        }
        public void IsSaveButtonDisplayed()
        {
            if (SaveButton == null)
            {
                throw new NullReferenceException("Unable to locate save button");
            }
           TestCheck.AssertIsEqual(true, SaveButton.Displayed, "Is Save button displayed");
        }

       public void IsMandatoryFieldValidationErrorMessageDisplayed()
        {
           TestCheck.AssertIsEqual(true, MandatoryFieldValidationErrorMessage.Displayed, "Is mandatory field valdiation error message displayed");
        }

       public void EmptyHouseNameTextBox()
        {
           if (HouseNameTextBox == null)
           {
               throw new NullReferenceException("Unable to locate HouseName TextBox");
           }
          AssertElementPresent(HouseNameTextBox, "HouseName TextBox");
          HouseNameTextBox.Clear();
          HouseNameTextBox.SendKeys(Keys.Tab);
       }

       public void IsHouseNameTextBoxErrorMessageDisplayed()
       {
           TestCheck.AssertIsEqual(true, HouseNameTextBox.Displayed, "Is Housename error message displayed");
       }
       public void EmptyAddressLine1TextBox()
       {
           if (AddressLine1TextBox == null)
           {
               throw new NullReferenceException("Unable to locate AddressLine1 TextBox");
           }
           AssertElementPresent(AddressLine1TextBox, "AddressLine1 TextBox");
           AddressLine1TextBox.Clear();
           HouseNameTextBox.SendKeys(Keys.Tab);
       }

       public void IsAddressLine1TextBoxErrorMessageDisplayed()
       {
           TestCheck.AssertIsEqual(true, AddressLine1TextBox.Displayed, "Is AddressLine1 error message displayed");
       }
       public void EmptyHouseNumberTextBox()
       {
           if (HouseNumberTextBox == null)
           {
               throw new NullReferenceException("Unable to locate HouseNumber TextBox");
           }
           AssertElementPresent(HouseNumberTextBox, "HouseNumber TextBox");
           HouseNumberTextBox.Clear();
           HouseNumberTextBox.SendKeys(Keys.Tab);
       }
       public void IsHouseNumberTextBoxErrorMessageDisplayed()
       {
           TestCheck.AssertIsEqual(true, HouseNumberTextBox.Displayed, "Is HouseNumber error message displayed");
       }

       public void EmptyPostCodeTextBox()
       {
           if (PostCodeTextBox == null)
           {
               throw new NullReferenceException("Unable to locate postcode TextBox");
           }
           AssertElementPresent(PostCodeTextBox, "postcode TextBox");
           PostCodeTextBox.Clear();
           PostCodeTextBox.SendKeys(Keys.Tab);
       }
       public void IsPostCodeTextBoxErrorMessageDisplayed()
       {
           TestCheck.AssertIsEqual(true, PostCodeTextBox.Displayed, "Is postcode error message displayed");
       }
       public void EmptyPhoneNumberTextBox()
       {
           if (PhoneNumberTextBox == null)
           {
               throw new NullReferenceException("Unable to locate phonenumber TextBox");
           }
           AssertElementPresent(PhoneNumberTextBox, "phonenumber TextBox");
           PhoneNumberTextBox.Clear();
           PhoneNumberTextBox.SendKeys(Keys.Tab);
       }
       public void IsPhoneNumberTextBoxErrorMessageDisplayed()
       {
           TestCheck.AssertIsEqual(true, PhoneNumberTextBox.Displayed, "Is PhoneNumberTextBox error message displayed");
       }

    }
}
