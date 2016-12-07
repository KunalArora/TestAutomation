using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement.PaymentMethods;
using Brother.WebSites.Core.Pages.OmniJoin.Plans;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Checkout
{
    public class CreditCardDetailsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["PaymentPage"].ToString(); }
        }

        //private const string CreditCardTestPage = "https://testpage.payments.digitalriver.com/pay/?creq=BEii9whIovYlcGLxmfpW6BbtbwV8_Xdk8eulgVCMGaCTa5tOw9muh0vlW3Ssy5q-yR3VkBJrejq5rzxpEV_Q2Dk4Y828PQ4ry3SHMArP--5Yx_mmfVFGW54xZ_ZPXDFrpicvXPqlwSometDrmeMIHKakP096tQsIZkNqnwRbxCfIcoPNHd-fM8k9h38WIwtupxClzqdvbYGVeMt026yRAvJon6hYH9kDw3A-weaTf_5qytndiGB5q1XKiNFM_x7FvBOtUCbYR_ic-aGJlKU4rDTbDJ4fOzKz1qmkJ2LMw3H1nrei1FI5aRPbZoN2UtsFHyuPQ9r7UCuHzj4o2_GTHc0IiGyJA1lQZbSRUKtejiCiEMI2DErwxuKCc15uz7Qiu-fvZw0XJZ0WAgCcSNL129yFT8TJpCSwsrOrgHowWvOkrYYC8ek77OkyxvVJ-9b1dfKfMJ-PTlG__kw7S-zZgGRHa3ZGyLkjU-cs-Uj7lTN-Ix4oR7FmHRFcdiIbRHeDHoS7SVsAZZRSgX2OYWj_RwN-WrGYJgyeaacNo4wb8s4EhCb56Nnq6Ycm0RZej6oWFCqvFJyD77HENyOPB4t9Sp7Bd1dvjj21bXhACZmrh930hkopctYK-b9h8FgGjlrWcU_QLIdqkBn0";

        [FindsBy(How = How.CssSelector, Using = "#VISA")] 
        public IWebElement VisaCreditCardOptionButton;

        [FindsBy(How = How.CssSelector, Using = "#MASTERCARD")]
        public IWebElement MasterCardCreditCardOptionButton;

        [FindsBy(How = How.CssSelector, Using = "#lKbfaYnzxdBcqax")]
        public IWebElement CreditCardNumberEditBox;

        [FindsBy(How = How.CssSelector, Using = "[size='4']")]
        public IWebElement CreditCardSecurityCodeEditBox;

        [FindsBy(How = How.CssSelector, Using = "#expdatemonth")]
        public IWebElement CreditCardExpDateMonthPicker;

        [FindsBy(How = How.CssSelector, Using = "#expdateyear")]
        public IWebElement CreditCardExpDateYearPicker;

        [FindsBy(How = How.CssSelector, Using = "#creditCard > div.button > span > input")] 
        public IWebElement SendButton;

        [FindsBy(How = How.CssSelector, Using = "#paymentChoiceCC > form.paymentForm > span > input")]
        public IWebElement CancelButton;

        [FindsBy(How = How.CssSelector, Using = "#content_0_checkoutcontent_0_PaymentGatewayIFrame")]
        public IWebElement CreditCardDetailsFramePageOrderSummary;

        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_1_PaymentControl_PaymentGatewayIFrame")]
        public IWebElement CreditCardDetailsFramePageAddNewCard;

        //added locators
        //[FindsBy(How = How.XPath, Using = "//*[@id='creditCard']//input[@data-control='SUBMIT']")]
        [FindsBy(How = How.Id, Using = "payment-submit")]
        public IWebElement AddNewCardSendPaymentButton;

        [FindsBy(How = How.Id, Using = "submit3")]
        public IWebElement ConfirmPaymentButton;

        //[FindsBy(How = How.XPath, Using = "//*[@id='creditCard']//input[@data-control='CARD']")]
        [FindsBy(How = How.Id, Using = "Ecom_Payment_Card_Number")]
        public IWebElement CreditCardNumberTextBox;

        //[FindsBy(How = How.XPath, Using = ".//*[@id='creditCard']//input[@data-control='CVV']")]
        [FindsBy(How = How.Id, Using = "Ecom_Payment_Card_Verification")]
        public IWebElement CreditCardCvvTextBox;

        //[FindsBy(How = How.XPath, Using = ".//*[@id='creditCard']//select[@data-control='MONTH']")]
        [FindsBy(How = How.Id, Using = "Ecom_Payment_Card_ExpDate_Month")]
        public IWebElement CreditCardExpiryMonth;

        //[FindsBy(How = How.XPath, Using = ".//*[@id='creditCard']//select[@data-control='YEAR']")]
        [FindsBy(How = How.Id, Using = "Ecom_Payment_Card_ExpDate_Year")]
        public IWebElement CreditCardExpiryYear;

        [FindsBy(How = How.Id, Using = "MASTERCARD")]  
        public IWebElement MasterCardRadioButton;

        #region IWrapsElement

        private IWebElement VisaOptionButton
        {
            get
            {
                var wrapper = this.VisaCreditCardOptionButton as IWrapsElement;
                return wrapper != null ? wrapper.WrappedElement : null;
            }
        }

        private IWebElement SecurityCode
        {
            get
            {
                var wrapper = this.CreditCardSecurityCodeEditBox as IWrapsElement;
                return wrapper != null ? wrapper.WrappedElement : null;
            }
        }

        private IWebElement MasterCardOptionButton
        {
            get
            {
                var wrapper = this.MasterCardCreditCardOptionButton as IWrapsElement;
                return wrapper != null ? wrapper.WrappedElement : null;
            }
        }

        private IWebElement ExpDateMonthPicker
        {
            get
            {
                var wrapper = this.CreditCardExpDateMonthPicker as IWrapsElement;
                return wrapper != null ? wrapper.WrappedElement : null;
            }
        }

        private IWebElement ExpDateYearPicker
        {
            get
            {
                var wrapper = this.CreditCardExpDateYearPicker as IWrapsElement;
                return wrapper != null ? wrapper.WrappedElement : null;
            }
        }

        private IWebElement SendPaymentButton
        {
            get
            {
                var wrapper = this.SendButton as IWrapsElement;
                
                return wrapper != null ? wrapper.WrappedElement : null;
            }
        }

        private IWebElement CancelPaymentButton
        {
            get
            {
                var wrapper = this.CancelButton as IWrapsElement;
                return wrapper != null ? wrapper.WrappedElement : null;
            }
        }

        private IWebElement CreditCardNumber
        {
            get
            {
                var element = Driver.FindElement(By.XPath("html/body/div[1]/div/form[1]/table/tbody/tr[4]/td[2]/input")); 
                return element;
            }
        }
        #endregion

        private IWebElement CreditCardDetailsFramePageOrderSummaryPage
        {
            get
            {
                IWrapsElement wrapper = this.CreditCardDetailsFramePageOrderSummary as IWrapsElement;
                if (wrapper != null)
                {
                    return wrapper.WrappedElement;
                }
                return null;
            }
        }

        private IWebElement CreditCardDetailsFramePageAddNewCardPage
        {
            get
            {
                IWrapsElement wrapper = this.CreditCardDetailsFramePageAddNewCard as IWrapsElement;
                if (wrapper != null)
                {
                    return wrapper.WrappedElement;
                }
                return null;
            }
        }

        public void IsMasterCardCreditCardOptionAvailable()
        {
            if (MasterCardOptionButton == null)
            {
                throw new Exception("Unable to locate option button on page");
            }
            AssertElementPresent(MasterCardOptionButton, "Mastercard Option Button");
        }

        public void IsVisaCreditCardOptionAvailable()
        {
            if (VisaOptionButton == null)
            {
                throw new Exception("Unable to locate option button on page");
            }
            AssertElementPresent(VisaOptionButton, "Visa Option Button");
        }

        public void IsSendPaymentButtonAvailable()
        {
            if (SendPaymentButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            MoveToElement(SendPaymentButton);
            AssertElementPresent(SendButton, "Send Payment Button");
        }

        //added methods
        public void IsAddNewCardSendPaymentButtonAvailable()
        {
            if (AddNewCardSendPaymentButton == null)
            {
                throw new Exception("Unable to locate button on page");
            }
            MoveToElement(AddNewCardSendPaymentButton);
            AssertElementPresent(AddNewCardSendPaymentButton, "Send Payment Button");
        }
   
        public void SelectMasterCardRadioButton()
        {
            MasterCardRadioButton.Click();
        }

        public void PopulateCreditCardNumber(string number)
        {
            CreditCardNumberTextBox.SendKeys(number);
        }

        public void PopulateCreditCardCvvNumber(string cvvNumber)
        {
            CreditCardCvvTextBox.SendKeys(cvvNumber);
        }

        public void PopulateCreditCardExpiryMonthDropDown(string month)
        {
            SelectFromDropdown(CreditCardExpiryMonth, month);
        }

        public void PopulateCreditCardExpiryYearDropDown(string year)
        {
            SelectFromDropdown(CreditCardExpiryYear, year);
        }

        public MyPaymentMethodsPage AddNewCardSendPaymentButtonClick()
        {
            AddNewCardSendPaymentButton.Click();
            return GetInstance<MyPaymentMethodsPage>(Driver);
        }

        public void SwitchToCreditCardDetailsFrameAddCard()
        {
            if (WaitForElementToExistByCssSelector("#content_2_innercontent_1_PaymentControl_PaymentGatewayIFrame", 2, 10))
            {
                var element = Driver.FindElement(By.CssSelector("#content_2_innercontent_1_PaymentControl_PaymentGatewayIFrame"));
                if (element == null)
                {
                    TestCheck.AssertFailTest(
                        string.Format("Unable to Switch to the Credit Card details frame. Could not find CssSelector"));
                }
            }
            else
            {
                TestCheck.AssertFailTest(
                    string.Format("Unable to Switch to the Credit Card details frame. Could not find CssSelector"));
            }
            MsgOutput("Switching to Credit Card details frame (Add New Card)");
            Driver.SwitchTo().Frame(CreditCardDetailsFramePageAddNewCardPage);
        }

        public void SwitchToCreditCardDetailsFrameOrderSummary()
        {
            try
            {
                if (WaitForElementToExistByCssSelector("#content_0_checkoutcontent_0_PaymentGatewayIFrame", 2, 10))
                {
                    var element = Driver.FindElement(By.CssSelector("#content_0_checkoutcontent_0_PaymentGatewayIFrame"));
                    if (element == null)
                    {
                        TestCheck.AssertFailTest(
                            "Unable to Switch to the Credit Card details frame. Could not find CssSelector");
                    }
                }
                else
                {
                    TestCheck.AssertFailTest("Unable to find Credit Card Payment Frame - Digital River Page - due to timeout");
                }
            }
            catch (WebDriverException timeOutException)
            {
                MsgOutput(string.Format("Exception was [{0}]", timeOutException));
                TestCheck.AssertFailTest("Unable to find Credit Card Payment Frame - Digital River Page - due to timeout");
            }
            MsgOutput("Switching to Credit Card details frame (Order Summary)");
            Driver.SwitchTo().Frame(CreditCardDetailsFramePageOrderSummaryPage);
        }

        public void SelectVisaOption()
        {
            VisaOptionButton.Click();
        }

        public void SelectMasterCardOption()
        {
            MasterCardOptionButton.Click();
        }

        public void EnterExpiryMonthDate()
        {
            ExpDateMonthPicker.Click();
        }

        public void EnterExpiryYearDate()
        {
            ExpDateYearPicker.Click();
        }

        // for the Add new payment page
        public MyPaymentMethodsPage SendPaymentDetailsButtonClick()
        {
            try
            {
                MoveToElement(SendButton);
                SendButton.Click();
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                TestCheck.AssertFailTest(string.Format("Unable to reference the Send Button element on the Add New Payment Method Page > [{0}]", elementNotVisible));
            }
            return GetInstance<MyPaymentMethodsPage>(Driver);
        }

        public OrderConfirmationPage SendPaymentButtonClick()
        {
            try
            {
                MoveToElement(SendButton);
                SendButton.Click();
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                TestCheck.AssertFailTest(string.Format("Unable to reference the Send Button element on the Credit Card Details Page > [{0}]", elementNotVisible));
            }
            return GetInstance<OrderConfirmationPage>(Driver);
        }

        public OrderConfirmationPage ConfirmPaymentButtonClick()
        {
            try
            {
                MoveToElement(ConfirmPaymentButton);
                ConfirmPaymentButton.Click();
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                TestCheck.AssertFailTest(string.Format("Unable to reference the Confirm Payment Button on Credit Card Details Page > [{0}]", elementNotVisible));
            }
            return GetInstance<OrderConfirmationPage>(Driver);
        }

        public ManagePlanPage SendEditPaymentButtonClick()
        {
            try
            {
                MoveToElement(SendButton);
                ScrollTo(Driver, SendButton);
                SendButton.Click();
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                TestCheck.AssertFailTest(string.Format("Unable to reference the Send Button element on the Credit Card Details Page > [{0}] for Edit Payment method", elementNotVisible));
            }
            return GetInstance<ManagePlanPage>(Driver);
        }

        public OrderSummaryPage CancelPaymentButtonClick()
        {
            CancelPaymentButton.Click();
            return GetInstance<OrderSummaryPage>(Driver);
        }

        public MyPaymentMethodsPage CancelSubmitCardButtonClick()
        {
            CancelPaymentButton.Click();
            return GetInstance<MyPaymentMethodsPage>(Driver);
        }

        public void EnterCreditCardNumber(string ccNumber)
        {
            IWebElement element = CreditCardNumber;
            element.SendKeys(ccNumber);
        }

        public void EnterCreditCardSecurityCode(string code)
        {
            SecurityCode.SendKeys(code);
        }

        /// <summary>
        /// Populates the Credit Card page with data. Data is retrieved from the ProductInfo.xml unless overridden
        /// expiry is not an empty string
        /// </summary>
        /// <param name="validInfo">Flag to determine if Valid or Invalid card details are requested. </param>
        /// <param name="overrideExpiry">string value to override the expiry date</param>
        public void PopulateCreditCardInformation(bool validInfo, string overrideExpiry)
        {
            string expiryDate;
            if (validInfo)
            {
                // Determine if Visa or Mastercard options are selected
                if (VisaCreditCardOptionButton.Selected)
                {
                    Helper.CreditCardType = "VISA";
                    EnterCreditCardNumber(Helper.GetVisaCcInfo("Number", true));
                    EnterCreditCardSecurityCode(Helper.GetVisaCcInfo("SecurityCode", true));
                    expiryDate = overrideExpiry != string.Empty ? overrideExpiry : Helper.GetVisaCcInfo("Expiry", true);
                    SelectFromDropdown(ExpDateMonthPicker, expiryDate.Split('-')[0]);
                    SelectFromDropdown(ExpDateYearPicker, expiryDate.Split('-')[1]);
                }
                else
                {
                    Helper.CreditCardType = "MASTERCARD";
                    EnterCreditCardNumber(Helper.GetMasterCardCcInfo("Number", true));
                    EnterCreditCardSecurityCode(Helper.GetMasterCardCcInfo("SecurityCode", true));
                    expiryDate = overrideExpiry != string.Empty ? overrideExpiry : Helper.GetMasterCardCcInfo("Expiry", true);
                    SelectFromDropdown(ExpDateMonthPicker, expiryDate.Split('-')[0]);
                    SelectFromDropdown(ExpDateYearPicker, expiryDate.Split('-')[1]);
                }
            }
            else
            {
                // Determine if Visa or Mastercard options are selected
                if (VisaCreditCardOptionButton.Selected)
                {
                    Helper.CreditCardType = "VISA";
                    EnterCreditCardNumber(Helper.GetVisaCcInfo("Number", false));
                    EnterCreditCardSecurityCode(Helper.GetVisaCcInfo("SecurityCode", false));
                    expiryDate = overrideExpiry != string.Empty ? overrideExpiry : Helper.GetVisaCcInfo("Expiry", false);
                    SelectFromDropdown(ExpDateMonthPicker, expiryDate.Split('-')[0]);
                    SelectFromDropdown(ExpDateYearPicker, expiryDate.Split('-')[1]);
                }
                else
                {
                    Helper.CreditCardType = "MASTERCARD";
                    EnterCreditCardNumber(Helper.GetMasterCardCcInfo("Number", false));
                    EnterCreditCardSecurityCode(Helper.GetMasterCardCcInfo("SecurityCode", false));
                    expiryDate = overrideExpiry != string.Empty ? overrideExpiry : Helper.GetMasterCardCcInfo("Expiry", false);
                    SelectFromDropdown(ExpDateMonthPicker, expiryDate.Split('-')[0]);
                    SelectFromDropdown(ExpDateYearPicker, expiryDate.Split('-')[1]);
                }
            }
        }
    }
}
