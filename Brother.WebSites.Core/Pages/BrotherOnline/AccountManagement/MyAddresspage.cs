using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class MyAddressDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["Addressbook"].ToString(); }
        }

        [FindsBy(How = How.Id, Using = "content_1_innercontent_2_AddAddressButton")]
        public IWebElement AddanewaddressButton;

        [FindsBy(How = How.Id, Using = "FirstnameTextBox")]
        public IWebElement FirstNameTextBox;

        [FindsBy(How = How.Id, Using = "LastNameTextbox")]
        public IWebElement LastNameTextBox;

        [FindsBy(How = How.Id, Using = "RegexPostCodeText")]
        public IWebElement PostcodeTextBox;

        [FindsBy(How = How.Id, Using = "HouseNumberTextBox")]
        public IWebElement HouseNumberTextBox;
         
        [FindsBy(How = How.Id, Using = "HouseNameTextBox")]
        public IWebElement HouseNameTextBox;

        [FindsBy(How = How.Id, Using = "AddrLine1Text")]
        public IWebElement AddressLine1TextBox;

        [FindsBy(How = How.Id, Using = "AddrLine2Text")]
        public IWebElement AddressLine2TextBox;

        [FindsBy(How = How.Id, Using = "CityTownText")]
        public IWebElement CityTownTextBox;

        [FindsBy(How = How.Id, Using = "PhoneNumberText")]
        public IWebElement PhoneNumberTextBox;

        [FindsBy(How = How.Id, Using = "content_1_innercontent_2_billingedit_btnAddressBookContinue")]
        public IWebElement SaveAndUseAddressButton;
        
         public void ClickonAddanewaddressButton()
        {
            ScrollTo(AddanewaddressButton);
            AddanewaddressButton.Click();
        }
        public void PopulateFirstNameTextBox(string firstName)
        {
            FirstNameTextBox.SendKeys(firstName);
            FirstNameTextBox.SendKeys(Keys.Tab);
        }
        public void PopulateLastNameTextBox(string lastName)
        {
           LastNameTextBox.SendKeys(lastName);
           LastNameTextBox.SendKeys(Keys.Tab);
        }
        public void PopulatePostcodeTextBox(string postcode)
        {
            PostcodeTextBox.SendKeys(postcode);
            PostcodeTextBox.SendKeys(Keys.Tab);
        }
        public void PopulateHouseNumberTextBox(String houseNumber)
        {
            HouseNumberTextBox.SendKeys(houseNumber);
            HouseNumberTextBox.SendKeys(Keys.Tab);
        }
        public void PopulateHouseNameTextBox(string houseName)
        {
            HouseNameTextBox.SendKeys(houseName);
            HouseNameTextBox.SendKeys(Keys.Tab);
        }
        public void PopulateAddressLine1TextBox(string addressLine1)
        {
            AddressLine1TextBox.SendKeys(addressLine1);
            AddressLine1TextBox.SendKeys(Keys.Tab);
        }
        public void PopulateAddressLine2TextBox(string addressLine2)
        {
            AddressLine2TextBox.SendKeys(addressLine2);
            AddressLine2TextBox.SendKeys(Keys.Tab);
        }
        public void PopulateCityTownTextBox(string cityTown)
        {
            CityTownTextBox.SendKeys(cityTown);
            CityTownTextBox.SendKeys(Keys.Tab);
        }

        public void PopulatePhoneTextBox(string phone)
        {
            PhoneNumberTextBox.SendKeys(phone);
        }
        public void ClickOnSaveAddress()
        {
            if (SaveAndUseAddressButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(SaveAndUseAddressButton, "Save And Use Address Button");
            ScrollTo(SaveAndUseAddressButton);
            SaveAndUseAddressButton.Click();
        }
        
    }
}
