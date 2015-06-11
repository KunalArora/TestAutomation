﻿using System;
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
    public class ManageCustomersAndOrdersPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".btn-add-colleague.button-aqua")]
        public IWebElement AddNewCustomer;
        
        private const string AddCustomerDialog = ".box-out.generic-form";
        private const string NextButton = ".check-email.button-blue";
    
        [FindsBy(How = How.CssSelector, Using = "#txtEmail")]
        public IWebElement CustomerEmailAddress;

        public void AddNewCustomerButtonClick()
        {
            AddNewCustomer.Click();
        }

        public void NextButtonClick()
        {
            try
            {
                var nextButton = Driver.FindElement(By.CssSelector(NextButton));
                nextButton.Click();
            }
            catch (Exception timeOut)
            {
                throw new WebDriverTimeoutException(string.Format("Timeout searching for Next button on Add Customer form {0}", timeOut));
            }
        }

        public void AddNewCustomerEmailAddress(string emailAddress)
        {
            if (emailAddress.Equals("ORP_GENERATED_CUSTOMER"))
            {
                // Need to retrieve a new email address generated from this        
                emailAddress = string.Format("ORP_Customer{0}", Email.GenerateUniqueEmailAddress());
            }

            // wait for popup form
            if (WaitForElementToExistByCssSelector(AddCustomerDialog, 5, 20))
            {
                if (WaitForElementToExistByCssSelector(NextButton, 10, 10))
                {
                    CustomerEmailAddress.SendKeys(emailAddress);
                }
                else
                {
                    MsgOutput("Not visible");
                }
            }
            else
            {
                MsgOutput("Not visible");
            }
            AssertElementValue(CustomerEmailAddress, emailAddress, "Validate Customer Email Address");
        }
    }
}
