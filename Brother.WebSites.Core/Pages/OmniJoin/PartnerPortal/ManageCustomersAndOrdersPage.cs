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
    public class ManageCustomersAndOrdersPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".btn-add-colleague.button-aqua")]
        public IWebElement AddNewCustomer;

        [FindsBy(How = How.CssSelector, Using = "#txtEmail")]
        public IWebElement CustomerEmailAddress;

        public void AddNewCustomerButtonClick()
        {
            AddNewCustomer.Click();
        }

        public void AddNewCustomerEmailAddress(string emailAddress)
        {
            if (emailAddress.Equals("ORP_GENERATED_CUSTOMER"))
            {
                // Need to retrieve a new email address generated from this        
                emailAddress = string.Format("ORP_Customer{0}", Email.GenerateUniqueEmailAddress());
            }

            // wait for popup form
            if (WaitForElementToExistById("#txtEmail"))
            {
                CustomerEmailAddress.SendKeys(emailAddress);
            }
            TestCheck.AssertIsEqual(emailAddress, CustomerEmailAddress.Text, "Customer Email Address");
        }
    }
}
