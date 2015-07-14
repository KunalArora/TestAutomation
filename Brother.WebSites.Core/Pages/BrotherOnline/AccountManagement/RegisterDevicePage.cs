using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement
{
    public class RegisterDevicePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["RegisterYourDevice"].ToString(); }
        }

        [FindsBy(How = How.CssSelector, Using = @"a.button-grey[href='/']")]
        public IWebElement BackToHomeButton;

        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_2_GoToNextStepButton")] 
        public IWebElement ContinueButton;

        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_2_Row1_txtSerial")]
        public IWebElement SerialCodeTextBox;

        [FindsBy(How = How.CssSelector, Using = "#registered-products > table > tbody > tr.row01 > td.model > div > p > div > span > span")]
        public IWebElement ModelNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "[class=\"datepicker hasDatepicker\"]")]
        public IWebElement PurchaseDateTextBox;

        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_2_Row1_txtPromoCode")]
        public IWebElement PromoCodeTextBox;

        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_2_Row1_txtSupplier")]
        public IWebElement SupplierTextBox;

        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_2_Row1_chkExtendedWarr")] 
        public IWebElement PurchaseExtendedWarrantyOption;

        [FindsBy(How = How.CssSelector, Using = "#warranty")] 
        public IWebElement BrotherTermsAndConditionsTickBox;

        public static string continueButtonId = "#content_2_innercontent_2_GoToNextStepButton";

        public bool IsErrorIconPresent()
        {
            // override current time outs
            WebDriver.SetPageLoadTimeout(new TimeSpan(0,0,0,10));
            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, 10));

            var errorIcon = GetElementByCssSelector(".error");

            // revert to default
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.PageLoad);
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);

            return errorIcon != null;
        }

        // Back to Brother Online Home Page
        public void IsBackToWelcomePageButtonAvailable()
        {
            if (BackToHomeButton == null)
            {
                throw new Exception("Unable to locate link on page");
            }
            AssertElementText(BackToHomeButton, "Back to home page >", "Back to Welcome Page Button");
        }

        public void IsSerialNumberTextBoxAvailable()
        {
            IWebElement serialCodeTextBox = null;
            if (WaitForElementToExistByCssSelector("#content_2_innercontent_2_Row1_txtSerial", 5, 5))
            {
               serialCodeTextBox = GetElementByCssSelector("#content_2_innercontent_2_Row1_txtSerial");
            }
            AssertElementPresent(serialCodeTextBox, "Welcome Page Register Device - Serial Number Text Box");    
        }

        public void IsContinueButtonAvailable()
        {
            WaitForElementToExistByCssSelector(continueButtonId, 5, 5);
            var continueButton = GetElementByCssSelector(continueButtonId);
            AssertElementPresent(continueButton, "Register a Device page - Supplier Code Text Box");

            //if (ContinueButton == null)
            //{
            //    throw new Exception("Unable to locate button on page");
            //}
            //AssertElementPresent(ContinueButton, "Continue Button");
        }

        public MyPrintersAndDevicesPage ClickContinueButton()
        {
            if (!WaitForElementToExistByCssSelector("#content_2_innercontent_2_GoToNextStepButton"))
            {
                ContinueButton = Driver.FindElement(By.CssSelector("#content_1_ResetPasswordButton"));
                TestCheck.AssertIsEqual(null, ContinueButton, "Check Continue Button");
            }
            ScrollTo(ContinueButton);
            ContinueButton.Click();
            return GetInstance<MyPrintersAndDevicesPage>(Driver);
        }

        public void IsProductSerialCodeTextBoxAvailable()
        {
            if (SerialCodeTextBox == null)
            {
                throw new Exception("Unable to locate TextBox on page");
            }
            AssertElementPresent(SerialCodeTextBox, "Serial Code Text Box");
        }

        public void IsPurchaseDateFieldAvailable()
        {
            if (PurchaseDateTextBox == null)
            {
                throw new Exception("Unable to locate Date Field on page");
            }
            AssertElementPresent(PurchaseDateTextBox, "Date Field Text Box");
        }

        public void IsPromoCodeTextBoxAvailable()
        {
            if (PromoCodeTextBox == null)
            {
                throw new Exception("Unable to locate Promo Code Text Box on page");
            }
            AssertElementPresent(PromoCodeTextBox, "Promo Code Text Box");
        }

        public void IsSupplierTextBoxAvailable()
        {
            if (SupplierTextBox == null)
            {
                throw new Exception("Unable to locate Supplier Text Box on page");
            }
            AssertElementPresent(SupplierTextBox, "Supplier Text Box");
        }

        public void IsExtendedWarrantyTickBoxAvailable()
        {
             if (PurchaseExtendedWarrantyOption == null)
            {
                throw new Exception("Unable to locate Extended Warranty Tick Box on page");
            }
             AssertElementPresent(PurchaseExtendedWarrantyOption, "Extended Warranty Tick Box");
        }
        
        public void IsBrotherTermsTickBoxAvailable()
        {
             if (BrotherTermsAndConditionsTickBox == null)
            {
                throw new Exception("Unable to locate Brother T&M Tick Box on page");
            }
             AssertElementPresent(BrotherTermsAndConditionsTickBox, "Brother T&M Tick Box");
        }

        public void EnterProductSerialCode(string serialCode)
        {
            IsProductSerialCodeTextBoxAvailable();
            SerialCodeTextBox.SendKeys(serialCode);
            TestCheck.AssertIsEqual(serialCode, SerialCodeTextBox.GetAttribute("value"), "Serial Code Text Box");
            // store for validation later
            Helper.CurrentDeviceSerialNumber = serialCode;
            SerialCodeTextBox.SendKeys(Keys.Tab);
            // As it takes a few seconds for the serial number to be recognised which populates
            // the model number text field, we have to wait for this to occur otherwise
            // the model number will show incorrectly.
            StoreModelNumber();
        }

        private void StoreModelNumber()
        {
            WebDriver.Wait(DurationType.Second, 6); // pause for element to be populated. Explicit wait can cause StaleElement exception
            CurrentDeviceModelNumber = ModelNumberTextBox.Text;        }

        public void EnterPurchaseDate(string purchaseDate)
        {
            IsPurchaseDateFieldAvailable();
            PurchaseDateTextBox.SendKeys(purchaseDate);
            TestCheck.AssertIsEqual(purchaseDate, PurchaseDateTextBox.GetAttribute("value"), "Purchase Date Text Box");
        }

        public void EnterPromoCode(string promoCode)
        {
            IsPromoCodeTextBoxAvailable();
            PromoCodeTextBox.SendKeys(promoCode);
            TestCheck.AssertIsEqual(promoCode, PromoCodeTextBox.GetAttribute("value"), "PromoCode Text Box");
        }

        public void EnterSupplier(string supplier)
        {
            IsSupplierTextBoxAvailable();
            SupplierTextBox.SendKeys(supplier);
            TestCheck.AssertIsEqual(supplier, SupplierTextBox.GetAttribute("value"), "Supplier Text Box");
        }

        public void TickExtendedWarrantyOption(bool ticked)
        {
            IsExtendedWarrantyTickBoxAvailable();
            if (PurchaseExtendedWarrantyOption.Selected != ticked)
            {
                PurchaseExtendedWarrantyOption.Click();
                if (PurchaseExtendedWarrantyOption.Selected != ticked)
                {
                    TestCheck.AssertFailTest("Extended warranty tickbox does not match required ticked status");
                }
            }
            TestCheck.AssertIsEqual(PurchaseExtendedWarrantyOption.Selected.ToString(), ticked.ToString(), "Purchase Extended Warranty Button");
        }

        public void AgreeToBrotherTermsAndConditions()
        {
            IsBrotherTermsTickBoxAvailable();
            BrotherTermsAndConditionsTickBox.Click();
            TestCheck.AssertIsEqual(BrotherTermsAndConditionsTickBox.Selected.ToString(), "True", "Agree to Brother terms and conditions Button");
        }
    }
}
