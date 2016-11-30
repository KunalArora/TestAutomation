using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Brother.Online.TestSpecs._80.Test_Steps;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.ProductLookup;
using Brother.WebSites.Core.ProductRegistration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    [Binding]
    public class AddressDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        public void GetAddressDetailsPage(string url)
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

        [FindsBy(How = How.CssSelector, Using = "#txtPostcode")] public IWebElement PostcodeField;

        [FindsBy(How = How.CssSelector, Using = "#btnFindAddress")] public IWebElement FindAddressButton;

        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div/div[1]/section/form/div/div/div[2]/div/label")] public
            IWebElement AcceptCheckbox;

        [FindsBy(How = How.Name, Using = "submit")] public IWebElement CompleteRegistrationButton;

        [FindsBy(How = How.CssSelector, Using = " #btnDeliveryContnue")] public IWebElement ContinueButton;


        public void EnterPostcode(string postcode)
        {
            PostcodeField.SendKeys(postcode);
        }

        public void ClickOnFindAddressButton()
        {
            FindAddressButton.Click();
        }

        public void ClickAcceptCheckbox()
        {
            AcceptCheckbox.Click();
        }

        public ConfirmationPage ClickCompleteRegistrationButton()
        {
            CompleteRegistrationButton.Click();
            
            RecycleSerialNumber("BPId", "SerialNumber");

            return GetInstance<ConfirmationPage>(Driver);
        }

        public void ClickContinueButtonOnAdPage()
        {
            ContinueButton.Click();
        }

        private static void RecycleSerialNumber(string bpId, string serialNumber)
        {
            //System.Threading.Thread.Sleep(5000);
            //serialNumber = "A2N125652";//"U1T004750";
            try
            {
                using (var productLookupServiceClient = new ProductLookupServiceClient())
                {
                    var products = productLookupServiceClient.GetRegisteredDevices(bpId, "GB");

                    if (products == null) return;

                    var firstOrDefault = products.RegisteredDevices.FirstOrDefault(d => d.SerialNumber == serialNumber);
                    if (firstOrDefault != null)
                    {
                        var productId = firstOrDefault.ProductId;
                        using (var productRegistrationServiceClient = new ProductRegistrationServiceClient())
                        {
                            productRegistrationServiceClient.DeregisterProduct(productId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
       
        }
    }
}
