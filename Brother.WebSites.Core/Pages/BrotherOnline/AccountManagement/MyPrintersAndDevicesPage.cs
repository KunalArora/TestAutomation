﻿using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class MyPrintersAndDevicesPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["MyPrintersAndDevices"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = "#Information > p")]
        public IWebElement DeviceRegistrationConfirmation;

        [FindsBy(How = How.CssSelector, Using = @"a.button-grey[href='/']")]
        public IWebElement BackToBrotherOnlineHomeButton;

        [FindsBy(How = How.CssSelector, Using = "#MyDevices > tbody > tr > td.serial")]
        public IWebElement SerialNumberText;

        [FindsBy(How = How.CssSelector, Using = "#MyDevices > tbody > tr > td.model")]
        public IWebElement DeviceModelText;

        [FindsBy(How = How.CssSelector, Using = ".purchased")]
        public IWebElement PurchasedDateText;

        public void IsBackToBrotherOnlineHomeButtonAvailable()
        {
            if (BackToBrotherOnlineHomeButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementPresent(BackToBrotherOnlineHomeButton, "Back To Brother Online Home Button");
        }

        public WelcomeBackPage GoBackToBrotherOnlineHomeButtonClick()
        {
            BackToBrotherOnlineHomeButton.Click();
            return GetInstance<WelcomeBackPage>(Driver);
        }

        public void IsDeviceRegistrationConfirmationMessagePresent()
        {
            if (DeviceRegistrationConfirmation == null)
            {
                throw new Exception("Unable to locate message on page");
            }
            AssertElementText(DeviceRegistrationConfirmation, "Congratulations, your device(s) were successfully registered", "Device Registration Confirmation Message");
        }

        public string GetPurchasedDate()
        {
            return PurchasedDateText.Text;
        }
        
        public string GetDeviceModel()
        {
            return DeviceModelText.Text;
        }

        public string GetDeviceSerialNumber()
        {
            return SerialNumberText.Text;
        }

        public void ValidateDeviceRegistrationInfo()
        {
            TestCheck.AssertIsEqual(GetDeviceSerialNumber(), CurrentDeviceSerialNumber, "Device Serial Number");
            TestCheck.AssertIsEqual(GetDeviceModel(), CurrentDeviceModelNumber, "Device Model Number");
        }
    }
}
