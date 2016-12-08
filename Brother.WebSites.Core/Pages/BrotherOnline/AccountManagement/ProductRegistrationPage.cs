
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Brother.Online.TestSpecs._80.Test_Steps;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.ProductService;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class ProductRegistrationPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = @"div.common-global-header--title > a > img")]
        public IWebElement BrotherLogo;

        [FindsBy(How = How.CssSelector, Using = @"footer .row.common-global-footer--row .col-sm-9.col-lg-9 > ul > li")]
        public IWebElement FooterLinks;

        [FindsBy(How = How.CssSelector, Using = "#serial-number")]
        public IWebElement SerialNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#btn-find-product-by-serial")]
        public IWebElement FindProductButton;

        [FindsBy(How = How.CssSelector, Using = "#input-purchase-date")]
        public IWebElement PurchaseDateTextBox;

        [FindsBy(How = How.CssSelector, Using = "#input-promo-code")]
        public IWebElement PromoCodeTextBox;

        [FindsBy(How = How.CssSelector, Using = "#btn-apply-purchase-date")]
        public IWebElement ApplyPurchaseDateButton;

        [FindsBy(How = How.CssSelector, Using = "#btn-apply-promo-code")]
        public IWebElement AddCodeButton;

        [FindsBy(How = How.Id, Using = "btn-continue-to-next-step")]
        public IWebElement ContinueButton;

        [FindsBy(How = How.CssSelector, Using = "#link-not-your-product")]
        public IWebElement RetrieveDataProductId;


        
        public void GetProductRegistrationPage(string url)
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
            Helper.MsgOutput(string.Format("Response time from website [{0}] was [{1}ms]", webSite, responseTime.Milliseconds));

            return responseCode;
        }
        
        public void CheckForHeaderAndFooter()
        {
            //Checks for the existance of elements on Header and Footer
            AssertElementPresent(BrotherLogo, "Brother Logo missing in the Header");
            AssertElementPresent(FooterLinks, "Fotter Links missing on the landing page");
        }
        
        public void PopulateSerialNumberTextBox(string serialnumber)
        {

            SerialNumberTextBox.SendKeys(serialnumber);
        }

        public void ClickFindProductButton()
        {
            ScrollTo(FindProductButton);
            FindProductButton.Click();
        }

        public void EnterProductDate(string purchasedate)
        {
            PurchaseDateTextBox.SendKeys(purchasedate);
            WaitForElementToBeClickableByCssSelector("#btn-apply-purchase-date", 5, 20);
        }

        public void EnterPromoCode(string promocode)
        {
            PromoCodeTextBox.SendKeys(promocode);
            WaitForElementToBeClickableByCssSelector("#btn-apply-promo-code", 5, 20);
        }

        public void ClickApplyButton()
        {
            ScrollTo(ApplyPurchaseDateButton);
            ApplyPurchaseDateButton.Click();
            WaitForElementToBeClickableById("btn-continue-to-next-step", 20);
           
        }

        public void ClickAddCodeButton()
        {
            Thread.Sleep(10000);
            ScrollTo(AddCodeButton);
            AddCodeButton.Click();
            WaitForElementToBeClickableById("btn-continue-to-next-step", 10);
        }
        
        public UserDetailsPage ClickContinueButton()
        {
            ScrollTo(ContinueButton);
            ContinueButton.Click();
             return GetInstance<UserDetailsPage>(Driver); 
        }

        public AddressDetailsPage ClickContinueButtonAdPage()
        {
            Thread.Sleep(10000);
            ScrollTo(ContinueButton);
            ContinueButton.Click();
            return GetInstance<AddressDetailsPage>(Driver);
        }

        public MyPrintersAndDevicesPage ClickContinueButtonMyPrinterandDevicePage()
        {
            Thread.Sleep(10000);
            var pId = SpecFlow.GetContext("ProductId");
            ScrollTo(Driver, ContinueButton);
            ContinueButton.Click();
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
            System.Threading.Thread.Sleep(5000);
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


        public void EnterProductSerialCode(string serialCode)
        {
            IsProductSerialCodeTextBoxAvailable();
            SerialNumberTextBox.SendKeys(serialCode);
            TestCheck.AssertIsEqual(serialCode, SerialNumberTextBox.GetAttribute("value"), "Serial Code Text Box");
            // store for validation later
            Helper.CurrentDeviceSerialNumber = serialCode;
            SerialNumberTextBox.SendKeys(Keys.Tab);
            // As it takes a few seconds for the serial number to be recognised which populates
            // the model number text field, we have to wait for this to occur otherwise
            // the model number will show incorrectly.
            //StoreModelNumber();
        }

        public void IsProductSerialCodeTextBoxAvailable()
        {
            if (SerialNumberTextBox == null)
            {
                throw new Exception("Unable to locate TextBox on page");
            }
            AssertElementPresent(SerialNumberTextBox, "Serial Code Text Box");
        }

        public void RetreiveDataProductId()
        {
            System.Threading.Thread.Sleep(2000);
            var text = RetrieveDataProductId.GetAttribute("data-product-id");
            SpecFlow.SetContext("ProductId", text);
        }

    }

    
}
