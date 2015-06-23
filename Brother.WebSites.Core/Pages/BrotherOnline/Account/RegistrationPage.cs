using System;
using System.Threading;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Account
{
    public class RegistrationPage : BasePage
    {
        public static string Url = "/sign-in";

        public override string DefaultTitle
        {
            get { return BrotherOnlineHomePages.Default["LoginRegisterPage"].ToString(); }
        }

        public static string PageTitle
        {
            get { return BrotherOnlineHomePages.Default["LoginRegisterPage"].ToString(); }
        }

        [FindsBy(How = How.Id, Using = "SignInButton")]
        public IWebElement SignInButton;

        [FindsBy(How = How.Id, Using = "content_0_twocolumnsformright_0_SignUpButton")]
        public IWebElement CreateYourAccountButton;

        [FindsBy(How = How.Id, Using = "FirstNameTextBox")]
        public IWebElement FirstNameTextBox;

        [FindsBy(How = How.Id, Using = "LastNameTextBox")]
        public IWebElement LastNameTextBox;

        // Note: there are Three password fields, one for Sign In, Two for Sign Up
        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password;

        [FindsBy(How = How.Id, Using = "PasswordTextBox")]
        public IWebElement PasswordTextBox;

        [FindsBy(How = How.Id, Using = "ConfirmPasswordTextBox")]
        public IWebElement ConfirmPasswordTextBox;

        [FindsBy(How = How.Id, Using = "CompanyNameTextBox")]
        public IWebElement CompanyNameTextBox;

        [FindsBy(How = How.Id, Using = "BusinessDropDown")]
        public IWebElement BusinessSectorDropDownList;

        [FindsBy(How = How.Id, Using = "CompanyDropDown")]
        public IWebElement EmployeeCountDropDownList;

        [FindsBy(How = How.Id, Using = "CreateNewAccountRadioButton")]
        public IWebElement DoNotHaveAnAccountOptionButton;

        [FindsBy(How = How.Id, Using = "VatNumberTextBox")]
        public IWebElement VatNumberTextBox;

        [FindsBy(How = How.Id, Using = "SignInRadioRadioButton")]
        public IWebElement DoHaveAnAccountOptionButton;

        [FindsBy(How = How.Id, Using = "BusinessAccountNoRadioButton")]
        public IWebElement DoNotUseMyAccountForBusinessCheckbox;

        [FindsBy(How = How.Id, Using = "BusinessAccountYesRadioButton")]
        public IWebElement UseMyAccountForBusinessCheckbox;

        [FindsBy(How = How.Id, Using = "TermsAndConditionsCheckbox")]
        public IWebElement AgreeToTermsAndConditions;

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement EmailAddressTextBox;

        [FindsBy(How = How.CssSelector, Using = ".half-col.validation-failed.blur .error")]
        public IWebElement PasswordErrorMessage;

        [FindsBy(How = How.XPath, Using = ".//*[@id='form-sign-up']/div[1]/span[2]/div")]
        public IWebElement ConfirmPasswordErrorMessage;

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement EmailAddressErrorMessage;

        [FindsBy(How = How.CssSelector, Using = ".forgotten-password-link[href]")]
        public IWebElement ResetPasswordLink;

        [FindsBy(How = How.CssSelector, Using = "#EmailTextBox")]
        public IWebElement EmailAddressPasswordResetTextBox;

        [FindsBy(How = How.CssSelector, Using = "#content_1_ResetPasswordButton")]
        public IWebElement ResetYourPasswordButton;

        //[FindsBy(How = How.ClassName, Using = ".button-blue")]
        //public IWebElement ResetYourPasswordButton;

        [FindsBy(How = How.CssSelector, Using = ".form-section.cf.validation-failed.load .error")]
        public IWebElement TermsAndConditionsErrorMessage;
        

        public bool IsWarningBarPresent()
        {
            try
            {
                var warningBar = Driver.FindElement(By.CssSelector(".warning-bar"));
                if (warningBar != null)
                {
                    if (warningBar.Displayed)
                    {
                        return true;
                    }
                }
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                MsgOutput(string.Format("Warning bar could not be located [{0}]", elementNotVisible.Message));
                return false;
            }
            return false;
        }

        public void IsResetYourPasswordButtonAvailable()
        {
            if (ResetYourPasswordButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(ResetYourPasswordButton, "Reset Password Button");
        }

        public void ResetYourPasswordButtonClick()
        {
            if (!WaitForElementToExistByCssSelector("#content_1_ResetPasswordButton"))
            {
                ResetYourPasswordButton = Driver.FindElement(By.CssSelector("#content_1_ResetPasswordButton"));
                //TestCheck.AssertIsNotEqual(null, ResetYourPasswordButton, "Reset Password Button");
            }
            ScrollTo(ResetYourPasswordButton);
            ResetYourPasswordButton.Click();
        }

        //public void ResetYourPasswordButtonClick()
        //{
        //    if (!WaitForElementToExistById("#content_1_ResetPasswordButton"))
        //    {
        //        ResetYourPasswordButton = Driver.FindElement(By.Id("#content_1_ResetPasswordButton"));
        //        TestCheck.AssertIsNotEqual(null, ResetYourPasswordButton, "Reset Password Button");
        //    }
        //    ScrollTo(ResetYourPasswordButton);
        //    ResetYourPasswordButton.Click();
        //}
       
        //public void ResetYourPasswordButtonClick()
        //{
        //    if (!WaitForElementToExistByClassName(".button-blue"))
        //    {
        //        ResetYourPasswordButton = Driver.FindElement(By.ClassName(".button-blue"));
        //        TestCheck.AssertIsNotEqual(null, ResetYourPasswordButton, "Reset Password Button");
        //    }
        //    ScrollTo(ResetYourPasswordButton);
        //    ResetYourPasswordButton.Click();
        //}

        public void IsEmailResetTextBoxAvailable()
        {
            if (EmailAddressPasswordResetTextBox == null)
            {
                throw new NullReferenceException("Unable to locate text box on page");
            }
            AssertElementPresent(EmailAddressPasswordResetTextBox, "Email Reset Text Box");
        }

        public void IsSignInButtonAvailable()
        {
            if (SignInButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(SignInButton, "Create Your Account / Sign In Button");
        }

        public void IsResetPasswordLinkAvailable()
        {
            if (ResetPasswordLink == null)
            {
                throw new NullReferenceException("Unable to locate password reset link on page");
            }
            AssertElementPresent(ResetPasswordLink, "Reset Password Link", 80);
        }

        public void ResetPasswordLinkClick()
        {
            ScrollTo(ResetPasswordLink);
            ResetPasswordLink.Click();
        }

        // Clicks the Sign In button 
        public void ClickSignInButtonStandAlone()
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            // added for Firefox HTTPS warning
            if (IsFireFoxBrowser())
            {
                DismissAlert();
            }
        }

        // Clicks the Sign In button and returns a Welcome Back page
        public WelcomeBackPage ClickSignInButton(string country)
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            // added for Firefox HTTPS warning
            if (IsFireFoxBrowser())
            {
                DismissAlert();
            }
            var title = HomePage.WelcomePageCountryTitle(country);
            return GetInstance<WelcomeBackPage>(Driver, BasePage.BaseUrl, title);
        }

        public DealerDashBoardPage SignInButtonToDealerDashboard(string country)
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            // added for Firefox HTTPS warning
            if (IsFireFoxBrowser())
            {
                DismissAlert();
            }
            var title = HomePage.WelcomePageCountryTitle(country);
            return GetInstance<DealerDashBoardPage>(Driver, BasePage.BaseUrl, title);
        }

        public LocalOfficeAdminDashBoardPage SignInButtonToLocalOfficeDashboard(string country)
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            // added for Firefox HTTPS warning
            if (IsFireFoxBrowser())
            {
                DismissAlert();
            }
            var title = HomePage.WelcomePageCountryTitle(country);
            return GetInstance<LocalOfficeAdminDashBoardPage>(Driver, BasePage.BaseUrl, title);
        }

        public LocalOfficeApproverDashBoardPage SignInButtonToLocalOfficeApproverDashboard(string country)
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            // added for Firefox HTTPS warning
            if (IsFireFoxBrowser())
            {
                DismissAlert();
            }
            var title = HomePage.WelcomePageCountryTitle(country);
            return GetInstance<LocalOfficeApproverDashBoardPage>(Driver, BasePage.BaseUrl, title);
        }

        public BankDashBoardPage SignInButtonToBankUser(string country)
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            // added for Firefox HTTPS warning
            if (IsFireFoxBrowser())
            {
                DismissAlert();
            }
            var title = HomePage.WelcomePageCountryTitle(country);
            return GetInstance<BankDashBoardPage>(Driver, BasePage.BaseUrl, title);
        }

        public RegistrationPage ClickSignUpButton()
        {
            ScrollTo(CreateYourAccountButton);
            CreateYourAccountButton.Click();
            return GetInstance<RegistrationPage>(Driver);
        }

        public RegistrationConfirmationPage ClickCreateAccountButton()
        {
            ScrollTo(CreateYourAccountButton);
            CreateYourAccountButton.Click();
            return GetInstance<RegistrationConfirmationPage>(Driver);
        }

        public void PopulateEmailAdressForChangeOfPassword(string emailAddress)
        {
            EmailAddressPasswordResetTextBox.Clear();
            EmailAddressPasswordResetTextBox.SendKeys(emailAddress);
            TestCheck.AssertIsEqual(emailAddress, GetTextBoxValue("EmailTextBox"), "Email For Password Reset Text Box");
        }

        public void PopulateFirstNameTextBox(string firstName)
        {
            FirstNameTextBox.SendKeys(firstName);
            TestCheck.AssertIsEqual(firstName, GetTextBoxValue("FirstNameTextBox"), "FirstName Text Box");
        }

        public void PopulateCompanyNameTextBox(string companyName)
        {
            ScrollTo(CompanyNameTextBox);
            CompanyNameTextBox.SendKeys(companyName);
            TestCheck.AssertIsEqual(companyName, GetTextBoxValue("CompanyNameTextBox"), "CompanyName Text Box");
        }

        public void PopulateVatNumberTextBox(string vatNumber)
        {
            ScrollTo(VatNumberTextBox);
            VatNumberTextBox.SendKeys(vatNumber);
            TestCheck.AssertIsEqual(vatNumber, GetTextBoxValue("VatNumberTextBox"), "Vat number Text Box");
        }

        public void PopulateLastNameTextBox(string lastName)
        {
            LastNameTextBox.SendKeys(lastName);
            TestCheck.AssertIsEqual(lastName, GetTextBoxValue("LastNameTextBox"), "LastName Text Box");
        }

        public void PopulatePasswordTextBox(string password)
        {
            PasswordTextBox.SendKeys(password.Equals("@@@@@") ? Helper.Password : password);
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password, GetTextBoxValue("PasswordTextBox"), "Password Text Box");
        }
      public void PopulateConfirmPasswordTextBox(string password)
        {
            ConfirmPasswordTextBox.SendKeys(password.Equals("@@@@@") ? Helper.Password : password);
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password, GetTextBoxValue("ConfirmPasswordTextBox"), "Confirm Password Text Box");
        }

        public void DoNotHaveAnAccountOption()
        {
            DoNotHaveAnAccountOptionButton.Click();
            TestCheck.AssertIsEqual(true, DoNotHaveAnAccountOptionButton.Selected, "Do Not Have An Account Button");
        }

        public void PopulateEmployeeCountDropDown(string numEmployees)
        {
            SelectFromDropdown(EmployeeCountDropDownList, numEmployees);
            AssertItemIsSelected(EmployeeCountDropDownList, numEmployees, "Number of Employees Drop Down List");
        }

        public void PopulateBusinessSectorDropDown(string businessSector)
        {
            SelectFromDropdown(BusinessSectorDropDownList, businessSector);
            AssertItemIsSelected(BusinessSectorDropDownList, businessSector, "Business Sector Drop Down List");
        }

        public void DoHaveAnAccountOption()
        {
            DoHaveAnAccountOptionButton.Click();
            TestCheck.AssertIsEqual("True", DoHaveAnAccountOptionButton.Selected.ToString(), "Do Have An Account Button");
        }

        public void DoNotUseAccountForBusiness()
        {
            DoNotUseMyAccountForBusinessCheckbox.Click();
            TestCheck.AssertIsEqual("True", DoNotUseMyAccountForBusinessCheckbox.Selected.ToString(), "Do Not Use Account For Business Button");
        }

        public void UseAccountForBusiness()
        {
            UseMyAccountForBusinessCheckbox.Click();
            TestCheck.AssertIsEqual("True", UseMyAccountForBusinessCheckbox.Selected.ToString(), "Use Account For Business Button");
        }

        public void CheckTermsAndConditions()
        {
            ScrollTo(AgreeToTermsAndConditions);
            AgreeToTermsAndConditions.Click();
            TestCheck.AssertIsEqual("True", AgreeToTermsAndConditions.Selected.ToString(), "Accept Terms and Conditions Button");
        }

        public void PopulatePassword(string password)
        {
            Password.SendKeys(password.Equals("@@@@@") ? Helper.Password : password);
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password, GetTextBoxValue("Password"), "Password");
        }

        public void PopulateEmailAddressTextBox(string emailAddress)
        {
            TestCheck.AssertIsEqual(false, EmailAddressErrorMessage.Displayed, "Is Email Error message displayed");
            if (emailAddress.Equals(string.Empty))
            {
                emailAddress = Email.GenerateUniqueEmailAddress();
            }
          
            EmailAddressTextBox.Clear();
            EmailAddressTextBox.SendKeys(emailAddress);
            EmailAddressTextBox.SendKeys(Keys.Tab);
            TestCheck.AssertIsEqual(emailAddress, GetTextBoxValue("Email"), "Email Text Box");
        }
        
        public void EmptyEmailAddressTextBox()
        {
            EmailAddressTextBox.SendKeys(Keys.Tab);
            EmailAddressTextBox.Clear();
            EmailAddressTextBox.SendKeys(Keys.Tab);
        }
        public void EmptyPasswordTextBox()
        {
            PasswordTextBox.SendKeys(Keys.Tab);
            PasswordTextBox.Clear();
            PasswordTextBox.SendKeys(Keys.Tab);
        }
        
        public void IsErrorMessageDisplayed()
        {
           TestCheck.AssertIsEqual(true, EmailAddressErrorMessage.Displayed, "Is Error Message Displayed");
        }
        public void PasswordErrorMessageDisplayed()
        {   
            PasswordTextBox.SendKeys(Keys.Tab);
            TestCheck.AssertIsEqual(true, PasswordErrorMessage.Displayed, "Is Error Message Displayed");
        }
        public void ConfirmPasswordErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, ConfirmPasswordErrorMessage.Displayed, "Is Error Message Displayed");
        }
        public void TermsAndConditionsErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, TermsAndConditionsErrorMessage.Displayed, "Is Error Message Displayed");
        }

       }
}
