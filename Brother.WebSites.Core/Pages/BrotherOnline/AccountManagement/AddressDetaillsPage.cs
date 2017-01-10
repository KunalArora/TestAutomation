using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Brother.Online.TestSpecs._80.Test_Steps;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.ProductService;
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

        [FindsBy(How = How.CssSelector, Using = ".checkbox label[for='TermsandConditions']")]
        public IWebElement AcceptCheckbox;

        [FindsBy(How = How.Id, Using = "btnComplete")]
        public IWebElement CompleteRegistrationButton;

        [FindsBy(How = How.CssSelector, Using = " #btnDeliveryContnue")] public IWebElement ContinueButton;

        [FindsBy(How = How.Id, Using = "account-holder")]
        public IWebElement AccountHoldersName;

        [FindsBy(How = How.Id, Using = "sort-code")]
        public IWebElement SortCode;

        [FindsBy(How = How.Id, Using = "account-number")]
        public IWebElement AccountNumber;

        [FindsBy(How = How.CssSelector, Using = ".checkbox label[for='NoProofofPurchase']")]
        public IWebElement AcceptProofOfPurchaseCheckbox ;

        [FindsBy(How = How.Id, Using = "txtHousenumber")]
        public IWebElement HouseNumber;

        public void EnterPostcode(string postcode)
        {
            PostcodeField.Clear();
            PostcodeField.SendKeys(postcode);
        }

        public void ClickOnFindAddressButton()
        {
            FindAddressButton.Click();
            WaitForElementToBeClickableByCssSelector("#btnDeliveryContnue",3, 10);
        }

        public void EnterAccountDetails(string accountholdername, string sortcode, string accountnumber)
        {
            AccountHoldersName.SendKeys(accountholdername);
            AccountNumber.SendKeys(accountnumber);
            SortCode.SendKeys(sortcode);
        }

        public void ClickAcceptCheckbox()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", AcceptCheckbox);
        }

        public void ClickAcceptProofOfPurchase()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", AcceptProofOfPurchaseCheckbox);
            WaitForElementToBeClickableByCssSelector("#btnDeliveryContnue", 3, 10);
        }

        public void EnterHouseNumber(string housenumber)
        {
            HouseNumber.Clear();
            HouseNumber.SendKeys(housenumber);
        }


        //public ConfirmationPage ClickCompleteRegistrationButton()
        //{
        //    CompleteRegistrationButton.Click();

        //    return GetInstance<ConfirmationPage>(Driver);
        //}

        public MyPrintersAndDevicesPage ClickCompleteRegistrationButton()
        {
            var pId = SpecFlow.GetContext("ProductId");
            ScrollTo(CompleteRegistrationButton);
            CompleteRegistrationButton.Click();
            RecycleSerialNumber(pId);
            return GetInstance<MyPrintersAndDevicesPage>(Driver);
        }
          private static void RecycleSerialNumber(string productId)
        {
             Guid prodId;
            if (!Guid.TryParse(productId, out prodId))
            {
                return;
            }
            System.Threading.Thread.Sleep(15000);
            //serialNumber = "A2N125652";//"U1T004750";
            try
            {

                using (var productServiceClient = new ProductServiceClient())
                {
                    productServiceClient.DeregisterProduct(prodId);
                }
            }
            catch (Exception ex)
            {

            }

        }

        public void ClickContinueButtonOnAdPage()
        {
            Thread.Sleep(10000);
            ScrollTo(ContinueButton);
            ContinueButton.Click();
        }
        
    }
}
