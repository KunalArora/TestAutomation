using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal
{
    public class MyCustomers : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#txtEmail")]
        public IWebElement EmaiLAddressTextBox;

        [FindsBy(How = How.CssSelector, Using = ".btn-add-colleague.button-aqua")]
        public IWebElement AddCustomerButton;

        [FindsBy(How = How.CssSelector, Using = "a.check-email.button-blue")]
        public IWebElement AddCustomerNextButton;

        [FindsBy(How = How.CssSelector, Using = ".add-colleague.dp-pop-up.cf")]
        public IWebElement AddCustomerPopupDialog;

        [FindsBy(How = How.CssSelector, Using = ".add-colleague-message.dp-pop-up.cf")]
        public IWebElement AddCustomerSuccessPopupDialog;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_btnSumbit")]
        public IWebElement AddCustomerOnAddCustomerFormButton;

        [FindsBy(How = How.CssSelector, Using = "#txtFirstName")]
        public IWebElement FirstNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtLastName")]
        public IWebElement LastNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtCompanyName")]
        public IWebElement CompanyNameTextBox;

        [FindsBy(How = How.CssSelector, Using = ".lightbox-close")]
        public IWebElement AddCustomerSuccessPopupDialogCloseSystemButton;

        private bool IsAddCustomerNextButtonAvailable()
        {
            var addCustomerNextButton = false;
            addCustomerNextButton = WaitForElementToExistByCssSelector("a.check-email.button-blue", 5, 30);
            return addCustomerNextButton;
        }

        public void IsAddCustomerButtonAvailable()
        {
            if (AddCustomerButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(AddCustomerButton, "Add Customer Button");
        }

        public bool WaitForAddCustomerSuccessPopupDialogToAppear()
        {
            var isPresent = WaitForElementToExistByCssSelector(".add-colleague-message.dp-pop-up.cf", 5, 30);
            if (!isPresent) return false;
            var popupDialog = GetElementByCssSelector(".add-colleague-message.dp-pop-up.cf");
            return popupDialog.Displayed;
        }

        public bool WaitForAddCustomerSuccessPopupDialogToDisAppear()
        {
            var isPresent = WaitForElementToExistByCssSelector(".add-colleague-message.dp-pop-up.cf", 5, 30);
            if (!isPresent) return false;
            var popupDialog = GetElementByCssSelector(".add-colleague-message.dp-pop-up.cf");
            return !popupDialog.Displayed;
        }

        public bool WaitForAddCustomerPopupToDisAppear()
        {
            var isPresent = WaitForElementToExistByCssSelector(".add-colleague.dp-pop-up.cf", 5, 30);
            if (!isPresent) return false;
            var popupDialog = GetElementByCssSelector(".add-colleague.dp-pop-up.cf");
            return !popupDialog.Displayed;
        }

        public bool WaitForAddCustomerPopupToAppear()
        {
            var isPresent = WaitForElementToExistByCssSelector(".add-colleague.dp-pop-up.cf", 5, 30);
            if (!isPresent) return false;
            var popupDialog = GetElementByCssSelector(".add-colleague.dp-pop-up.cf");
            return popupDialog.Displayed;
        }

        public void EnterEmailAddress(string emailAddress)
        {
            var enterCodeTextBox = GetElementByCssSelector("#txtEmail");
            if (enterCodeTextBox == null) return;
            enterCodeTextBox.Clear();
            enterCodeTextBox.SendKeys(emailAddress);
            TestCheck.AssertIsEqual(emailAddress, enterCodeTextBox.Text,
                "Customer Email Text Box");
        }

        private bool IsAddCustomerOnAddCustomerFormButtonAvailable()
        {
            var addCustomerOnAddCustomerButton = WaitForElementToExistByCssSelector("#content_1_innercontent_2_btnSumbit", 5, 30);
            return addCustomerOnAddCustomerButton;
        }
        
        public void ClickAddCustomerNextButton()
        {
            IsAddCustomerNextButtonAvailable();
            var addCustomerNextButton = GetElementByCssSelector("a.check-email.button-blue");
            if (addCustomerNextButton == null) return;
            ScrollTo(addCustomerNextButton);
            addCustomerNextButton.Click();
            IsAddCustomerOnAddCustomerFormButtonAvailable();
            TestCheck.AssertIsEqual(true, IsAddCustomerOnAddCustomerFormButtonAvailable(), "Add Customer On Add Customer Button Exists");
        }

        public void ClickAddCustomerOnAddCustomerButton()
        {
            IsAddCustomerOnAddCustomerFormButtonAvailable();
            var addCustomerOnAddCustomerButton = GetElementByCssSelector("#content_1_innercontent_2_btnSumbit");
            if (addCustomerOnAddCustomerButton != null)
            {
                ScrollTo(addCustomerOnAddCustomerButton);
                addCustomerOnAddCustomerButton.Click();
                WaitForAddCustomerPopupToDisAppear();
                WaitForAddCustomerSuccessPopupDialogToAppear();
                TestCheck.AssertIsEqual(true, WaitForAddCustomerSuccessPopupDialogToAppear(), "Add Customer Success Dialog Visible");
            }
        }

        public void EnterCustomerFirstName(string customerFirstName)
        {
            var firstNameTextBox = GetElementByCssSelector("#txtFirstName");
            if (firstNameTextBox == null) return;
            firstNameTextBox.Clear();
            firstNameTextBox.SendKeys(customerFirstName);
            TestCheck.AssertIsEqual(customerFirstName, firstNameTextBox.Text,
                "Customer First Name Text Box");
        }

        public void EnterCustomerLastName(string customerLastName)
        {
            var lastNameTextBox = GetElementByCssSelector("#txtLastName");
            if (lastNameTextBox == null) return;
            lastNameTextBox.Clear();
            lastNameTextBox.SendKeys(customerLastName);
            TestCheck.AssertIsEqual(customerLastName, lastNameTextBox.Text,
                "Customer Last Name Text Box");
        }

        public void EnterCustomerCompanyName(string companyName)
        {
            var companyNameTextBox = GetElementByCssSelector("#txtCompanyName");
            if (companyNameTextBox == null) return;
            companyNameTextBox.Clear();
            companyNameTextBox.SendKeys(companyName);
            TestCheck.AssertIsEqual(companyName, companyNameTextBox.Text,
                "Company Name Text Box");
        }

        public void CloseAddCustomerSuccessDialog()
        {
            if (WaitForAddCustomerSuccessPopupDialogToAppear())
            {
                var closeSuccessDialogButton = GetElementByCssSelector(".lightbox-close");
                if (closeSuccessDialogButton != null)
                {
                    closeSuccessDialogButton.Click();
                    TestCheck.AssertIsEqual(true, WaitForAddCustomerSuccessPopupDialogToDisAppear(), "Add Customer Success Dialog Closed");
                }
            }
        }
    }
}
