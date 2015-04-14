using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.Tests.Selenium.Lib.Pages.BrotherOnline.AccountManagement
{
    public class ExtendedWarrantyPage :BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["ActivateYourExtendedWarranty"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = "#activate-warranty > div:nth-child(3) > a")]
        public IWebElement MyPrintersAndDevicesButton;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_3_btnContinue")]
        public IWebElement ContinueButton;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_3_RowRptr_ddlWattantyType_0")]
        public IWebElement WarrantyPackTypeDropDown;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_3_RowRptr_txtActivationCode_0")]
        public IWebElement ActivationCodeTextBox;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div > p > a")]
        public IWebElement BackToBrotherOnlineHomeButton;

        public void IsBackToBrotherOnlineHomeButtonAvailable()
        {
            if (BackToBrotherOnlineHomeButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementText(BackToBrotherOnlineHomeButton, "back to brother online home", "Back To Brother Online Home Button");
        }

        public WelcomeBackPage WelcomeBackToBrotherOnlineHomeButtonClick()
        {
            BackToBrotherOnlineHomeButton.Click();
            return GetInstance<WelcomeBackPage>(Driver);
        }

        public void IsMyPrintersAndDevicesButtonAvailable()
        {
            if (MyPrintersAndDevicesButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementText(MyPrintersAndDevicesButton, "MY PRINTERS & DEVICES", "My Printers & Devices Button");
        }

        public MyPrintersAndDevicesPage MyPrintersAndDevicesButtonClick()
        {
            MyPrintersAndDevicesButton.Click();
            return GetInstance<MyPrintersAndDevicesPage>();
        }

        public void IsContinueButtonAvailable()
        {
            if (ContinueButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            AssertElementText(ContinueButton, "Continue", "Continue Button");
        }

        //public MyPrintersAndDevices ContinueButtonClick()
        //{
        //    ContinueButton.Click();
        //    //return GetInstance<MyPrintersAndDevices>();
        //}
    }
}
