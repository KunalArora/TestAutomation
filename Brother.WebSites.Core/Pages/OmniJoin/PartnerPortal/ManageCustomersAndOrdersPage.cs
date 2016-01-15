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

        [FindsBy(How = How.CssSelector, Using = ".btn-add-colleague.button-aqua")] 
        public IWebElement AddNewColleaguebutton;

        [FindsBy(How = How.CssSelector, Using = "#txtEmail")]
        public IWebElement AddNewColleagueEmailAddressTxtBox;

        [FindsBy(How = How.CssSelector, Using = ".check-email.button-blue")] 
        public IWebElement FollowingButton;

        [FindsBy(How = How.CssSelector, Using = "#txtFirstName")] 
        public IWebElement FirstNameTxtBox;

        [FindsBy(How = How.CssSelector, Using = "#txtLastName")] 
        public IWebElement LastNameTxtBox;

        [FindsBy(How = How.CssSelector, Using = "#content_1_innercontent_2_btnSumbit")] 
        public IWebElement SubmitButton;

        [FindsBy(How = How.CssSelector, Using = ".add-colleague-message .box-out p")]
        public IWebElement SuccessMessage;

        [FindsBy(How = How.CssSelector, Using = ".add-colleague-message.dp-pop-up.cf .lightbox-close")]
        public IWebElement MessageClose;
     
        [FindsBy(How = How.CssSelector, Using = ".odd>td")]
        public IWebElement CreatedUsersinList;


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

        public ManageCustomersAndOrdersPage AddNewColleagueButtonClick()
        {
            if (AddNewColleaguebutton == null)
            {
                throw new NullReferenceException("Add new colleague button");
            }

            AddNewColleaguebutton.Click();
            return GetInstance<ManageCustomersAndOrdersPage>(Driver);

        }

        public void IsAddNewColleagueEmailAddressTxtBoxDisplayed()
        {
            TestCheck.AssertIsEqual(true, AddNewColleagueEmailAddressTxtBox.Displayed, "Is Email address textbox displayed");
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

        public void IsAddNewCustomerButtonDisplayed()
        {
            TestCheck.AssertIsEqual(true, AddNewCustomer.Displayed, "Is add new  customer button displayed");
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

        public void PopulateAddNewColleagueEmailAddressTxtBox(string emailAddress)
        {
            if (emailAddress.Equals(string.Empty))
            {
                emailAddress = Email.GenerateUniqueEmailAddress();
                SpecFlow.SetContext("Colleague Email Address", emailAddress);
            }

            AddNewColleagueEmailAddressTxtBox.SendKeys(emailAddress);
        }

        public ManageCustomersAndOrdersPage ClickFollowingButton()
        {
            FollowingButton.Click();
            return GetInstance<ManageCustomersAndOrdersPage>(Driver);

        }

        public void IsSubmitButtonDisplayed()
        {
            TestCheck.AssertIsEqual(true, SubmitButton.Displayed,"Is submit button displayed");
        }

        public void  EnterFirstNameTextBox(string firstName)
        {
            FirstNameTxtBox.SendKeys(firstName);
            FirstNameTxtBox.SendKeys(Keys.Tab);
        }

        public void EnterLastNameTextBox(string lastName)
        {
            LastNameTxtBox.SendKeys(lastName);
        }
        public ManageCustomersAndOrdersPage ClickSubmitButton()
        {
            if (SubmitButton == null)
            {
                throw new NullReferenceException("Unable to locate element");
            }
            SubmitButton.Click();       
            return GetInstance<ManageCustomersAndOrdersPage>(Driver);
        }

        public void IsSuccessMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, SuccessMessage.Displayed, "Is Success Message Displayed");
        }

        public ManageCustomersAndOrdersPage PopUpMessageClose()
        {
            //var PopUpMessageClose = Driver.FindElement(By.CssSelector(".add-colleague-message.dp-pop-up.cf .lightbox-close"));
            MessageClose.Click();
            return GetInstance<ManageCustomersAndOrdersPage>(Driver);
        }

        public void IsColleagueEmailAddressDisplayed()
        {
            var createdColleagueEmail = SpecFlow.GetContext("Colleague Email Address");

            var newlyGenerated = CreatedEmailActionButton(createdColleagueEmail);

            var newlyGeneratedColleague = FindElementByJs(newlyGenerated);

            TestCheck.AssertIsEqual(true, newlyGeneratedColleague.Displayed, "");

        }

        private static string CreatedEmailActionButton(string user)
        {
            return String.Format("return $('td:contains(\"{0}\")')",
                user);
        }

        public void IsCreatedUsersListDisplayed()
        {
            TestCheck.AssertIsEqual(true, CreatedUsersinList.Displayed, "Is Cretaed User list Displayed");
            IsColleagueEmailAddressDisplayed();

        }
    }
}
