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
        
        [FindsBy(How = How.CssSelector, Using = ".add-colleague-message.dp-pop-up.cf")]
        public IWebElement CustomerAddedMessage;

        [FindsBy(How = How.CssSelector, Using = ".lightbox-close")]
        public IWebElement CustomerAddedMessageClose;

        private const string AddCustomerDialog = ".box-out.generic-form a.check-email";
        private const string NextButton = ".check-email.button-blue";

        [FindsBy(How = How.CssSelector, Using = "#txtFirstName")] 
        public IWebElement FirstNameTextField;

        [FindsBy(How = How.CssSelector, Using = "#txtLastName")]
        public IWebElement LastNameTextField;

        [FindsBy(How = How.CssSelector, Using = "#txtEmail")]
        public IWebElement CustomerEmailAddress;

        [FindsBy(How = How.CssSelector, Using = "#txtCompanyName")] 
        public IWebElement CompanyNameField;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_btnSumbit")] 
        public IWebElement AddCustomerButton;

        [FindsBy(How = How.CssSelector, Using = "#content_1_breadcrumb_0_rptBreadcrumb_hlkBreadcrumb_0[href*='/partner-portal']")]
        public IWebElement PartnerPortalBreadcrumb;

        public PartnerPortalPage PartnerPortalBreadcrumbClick()
        {
            if (PartnerPortalBreadcrumb == null)
            {
                throw new NullReferenceException("Partner Portal Breadcrumb is Null");
            }

            PartnerPortalBreadcrumb.Click();
            return GetInstance<PartnerPortalPage>();
        }

        public void AddFirstName(string firstName)
        {
            FirstNameTextField.SendKeys(firstName + Keys.Tab);
        }

        public ManageCustomersAndOrdersPage AddCustomerButtonClick()
        {
            if (AddCustomerButton == null)
            {
                throw new NullReferenceException("Add Customer Button");
            }

            AddCustomerButton.Click();

            // Wait for Add Customer confirmation message
            if (!WaitForElementToExistByCssSelector(".add-colleague-message.dp-pop-up.cf", 5, 20)) return null;
            if (!WaitForElementToExistByCssSelector(".add-colleague-message.dp-pop-up.cf a.lightbox-close", 5, 20))
                return null;
            var closeMessage = Driver.FindElement(By.CssSelector(".add-colleague-message.dp-pop-up.cf a.lightbox-close"));
            closeMessage.Click();
            return GetInstance<ManageCustomersAndOrdersPage>(Driver);
        }
        

        public void AddLastName(string lastName)
        {
            LastNameTextField.SendKeys(lastName + Keys.Tab);
        }

        public void AddCompanyName(string companyName)
        {
            CompanyNameField.SendKeys(companyName + Keys.Tab);
        }

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
            catch (WebDriverException timeOut)
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
            if (WaitForElementToExistByCssSelector(AddCustomerDialog, 5, 10))
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
