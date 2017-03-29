using System;
using System.Net;
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
            get { return string.Empty; }
        }

        public void GetMyPrintersAndDevicesPage(string url)
        {
            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(60));
            WebSites.Core.Pages.General.SiteAccess.ValidateSiteUrl(url);
            WebDriver.SetPageLoadTimeout(WebDriver.DefaultTimeout);
        }

        private HttpStatusCode GetWebPageResponse(string webSite)
        {
            var responseTimer = new System.Diagnostics.Stopwatch();
            responseTimer.Start();
            // get response from WebSite
            var responseCode = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
            responseTimer.Stop();
            var responseTime = responseTimer.Elapsed;
            Helper.MsgOutput(string.Format("Response time from website [{0}] was [{1}ms]", webSite,
                responseTime.Milliseconds));

            return responseCode;
        }

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-success > p")]
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
            //AssertElementText(DeviceRegistrationConfirmation, "Your device was successfully registered.", "Device Registration Confirmation Message");
            AssertElementText(DeviceRegistrationConfirmation, @"Your have successfully registered your products(s).", "Device Registration Confirmation Message");
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
