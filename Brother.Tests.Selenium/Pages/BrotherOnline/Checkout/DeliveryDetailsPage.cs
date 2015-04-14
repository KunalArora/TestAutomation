using System;
using System.CodeDom;
using System.Collections.Generic;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Properties;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Checkout
{
    public class DeliveryDetailsPage : BasePage
    {
        public static string Url = "/";

        public enum DeliveryAddress {PhoneNumber, FirstName, LastName, PostCode, HouseNumber, CityTown, None};

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["DeliveryAddressPage"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = "#FirstnameTextBox")]
        public IWebElement FirstNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#LastNameTextbox")]
        public IWebElement LastNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#HouseNumberTextBox")]
        public IWebElement HouseNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#HouseNameTextBox")]
        public IWebElement HouseNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#AddrLine1Text")]
        public IWebElement AddressLine1TextBox;

        [FindsBy(How = How.CssSelector, Using = "#AddrLine2Text")]
        public IWebElement AddressLine2TextBox;

        [FindsBy(How = How.CssSelector, Using = "#CityTownText")]
        public IWebElement CityTownTextBox;

        [FindsBy(How = How.CssSelector, Using = "#PhoneNumberText")]
        public IWebElement PhoneNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#ContextSapRegionDropDownList")]
        public IWebElement CountyDropDownBox;

        [FindsBy(How = How.CssSelector, Using = "#DeliverToAddressCB")]
        public IWebElement DeliverToThisAddressTickBox;

        [FindsBy(How = How.CssSelector, Using = "#content_0_checkoutcontent_0_billingedit_btnDeliveryContinue")]
        public IWebElement SaveAndUseAddressButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_checkoutcontent_0_billingedit_btnDeliveryCancel")]
        public IWebElement CancelButton;

        

        public void IsSaveAndUseAddressButtonAvailable()
        {
            if (SaveAndUseAddressButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(SaveAndUseAddressButton, "Save And Use Address Button");
        }

        public SavedPaymentDetailsPage SaveAndUseAddressButtonClick()
        {
            ScrollTo(SaveAndUseAddressButton);
            SaveAndUseAddressButton.Click();
            return GetInstance<SavedPaymentDetailsPage>(Driver);
        }

        public void PopulateFirstNameTextBox(string firstName)
        {
            FirstNameTextBox.SendKeys(firstName);
            AssertIsEqual(firstName, GetTextBoxValue("FirstnameTextBox"), "FirstName Text Box");
        }

        public void PopulateLastNameTextBox(string lastName)
        {
            LastNameTextBox.SendKeys(lastName);
            AssertIsEqual(lastName, GetTextBoxValue("LastNameTextbox"), "LastName Text Box");
        }

        public void PopulateHouseNumberTextBox(string houseNumber)
        {
            HouseNumberTextBox.SendKeys(houseNumber);
            AssertIsEqual(houseNumber, GetTextBoxValue("HouseNumberTextBox"), "House Number Text Box");
        }

        public void PopulateHouseNameTextBox(string houseName)
        {
            HouseNameTextBox.SendKeys(houseName);
            AssertIsEqual(houseName, GetTextBoxValue("HouseNameTextBox"), "House Name Text Box");
        }

        public void PopulateAddressLine1TextBox(string addressLine1)
        {
            AddressLine1TextBox.SendKeys(addressLine1);
            AssertIsEqual(addressLine1, GetTextBoxValue("AddrLine1Text"), "Address Line 1 Text Box");
        }

        public void PopulateAddressLine2TextBox(string addressLine2)
        {
            AddressLine2TextBox.SendKeys(addressLine2);
            AssertIsEqual(addressLine2, GetTextBoxValue("AddrLine2Text"), "Address Line 2 Text Box");
        }

        public void PopulateCityTownTextBox(string cityTown)
        {
            CityTownTextBox.SendKeys(cityTown);
            AssertIsEqual(cityTown, GetTextBoxValue("CityTownText"), "City Town Text Box");
        }

        public void PopulatePhoneTextBox(string phone)
        {
            PhoneNumberTextBox.SendKeys(phone);
            AssertIsEqual(phone, GetTextBoxValue("PhoneNumberText"), "Phone Number Text Box");
        }

        public void ValidateAddressFields(string fields, string country)
        {
            var fieldList = fields.Split(',');
            if (fieldList.Length > 0)
            {
                foreach (var field in fieldList)
                {
                    // Using the xml file (see supporting files) to read in validation options 
                    // by language
                    var fieldXml = string.Format(@"/AddressFields/Language[@Country='{0}']/Fields/{1}", country, field.Trim(' '));
                    //var maxCharsExceeded = string.Format(@"/AddressFields/Language[@Country='{0}']/{1}/{2}/MaxCharsExceeded", country, validationType, field);
                    var validationStringList = Validation.GetValidationItems(fieldXml, "DeliveryAddressFieldValidation.xml");

                    foreach (var validationSet in validationStringList)
                    {
                        switch (field.Trim(' '))
                        {
                            case "PhoneNumber":
                                PhoneNumberTextBox.Clear();
                                PhoneNumberTextBox.SendKeys(validationSet.ValidationString + Keys.Tab);
                                if (validationSet.HasExceededMaxChars)
                                {
                                    Assert.AreNotEqual(validationSet.ValidationString, GetTextBoxValue("PhoneNumberText"), "Phone Number Text Box");
                                }
                                break;

                            case "FirstName":
                                FirstNameTextBox.Clear();
                                FirstNameTextBox.SendKeys(validationSet.ValidationString + Keys.Tab);
                                if (validationSet.HasExceededMaxChars)
                                {
                                    Assert.AreNotEqual(validationSet.ValidationString, GetTextBoxValue("FirstNameText"), "FirstName Text Box");
                                }
                                break;

                            case "LastName":
                                LastNameTextBox.Clear();
                                LastNameTextBox.SendKeys(validationSet.ValidationString + Keys.Tab);
                                if (validationSet.HasExceededMaxChars)
                                {
                                    Assert.AreNotEqual(validationSet.ValidationString, GetTextBoxValue("LastNameText"), "LastName Text Box");
                                }
                                break;

                            case "PostCode":
                            //    .Clear();
                                break;

                            default:
                                Helper.MsgOutput("Unable to determine Address Field");
                                break;
                        }
                        Validation.CheckForErrorNotifications(validationSet.HasExceededMaxChars != true && validationSet.IsErrorExpected);
                    }
                }
            }
        }

        public void PopulateCountyDropDown(string country)
        {
            SelectFromDropdown(CountyDropDownBox, country);
            AssertItemIsSelected(CountyDropDownBox, country, "County Drop Down List");
        }
    }
}
