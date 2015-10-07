using System;
using System.Security.Authentication;
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
            get { return string.Empty; }
        }

        public static string PageTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector,
            Using =
                ".content.cf .content-box.login-register.cf .box-out.regular-sign-in.cf .generic-form #form-sign-in .button-blue"
            )] public IWebElement SignInButton;

        [FindsBy(How = How.CssSelector,
            Using =
                ".content.cf .content-box.login-register.cf .box-out.regular-sign-in.cf .generic-form #form-sign-up .button-blue"
            )] public IWebElement CreateYourAccountButton;

        [FindsBy(How = How.Id, Using = "FirstNameTextBox")] public IWebElement FirstNameTextBox;

        [FindsBy(How = How.Id, Using = "LastNameTextBox")] public IWebElement LastNameTextBox;

        // Note: there are Three password fields, one for Sign In, Two for Sign Up
        [FindsBy(How = How.Id, Using = "Password")] public new IWebElement Password;

        [FindsBy(How = How.Id, Using = "PasswordTextBox")] public IWebElement PasswordTextBox;

        [FindsBy(How = How.Id, Using = "ConfirmPasswordTextBox")] public IWebElement ConfirmPasswordTextBox;

        [FindsBy(How = How.Id, Using = "CompanyNameTextBox")] public IWebElement CompanyNameTextBox;

        [FindsBy(How = How.Id, Using = "BusinessDropDown")] public IWebElement BusinessSectorDropDownList;

        [FindsBy(How = How.Id, Using = "CompanyDropDown")] public IWebElement EmployeeCountDropDownList;

        [FindsBy(How = How.CssSelector, Using = "#CreateNewAccountRadioButton")] public IWebElement
            DoNotHaveAnAccountOptionButton;

        [FindsBy(How = How.Id, Using = "VatNumberTextBox")] public IWebElement VatNumberTextBox;

        [FindsBy(How = How.Id, Using = "error-vat-already-registered")] public IWebElement WarningMessageSameVATNumber;


        [FindsBy(How = How.Id, Using = "SignInRadioRadioButton")] public IWebElement DoHaveAnAccountOptionButton;

        [FindsBy(How = How.Id, Using = "BusinessAccountNoRadioButton")] public IWebElement
            DoNotUseMyAccountForBusinessCheckbox;

        [FindsBy(How = How.Id, Using = "BusinessAccountYesRadioButton")] public IWebElement
            UseMyAccountForBusinessCheckbox;

        [FindsBy(How = How.Id, Using = "TermsAndConditionsCheckbox")] public IWebElement AgreeToTermsAndConditions;

        [FindsBy(How = How.Id, Using = "Email")] public IWebElement EmailAddressTextBox;

        [FindsBy(How = How.CssSelector, Using = ".half-col.validation-failed.blur .error")] public IWebElement
            PasswordErrorMessage;

        [FindsBy(How = How.CssSelector, Using = ".half-col.validation-failed.blur .error")] public IWebElement
            FirstNameErrorMessageDisplayed;

        [FindsBy(How = How.CssSelector,
            Using = "#form-sign-up > div:nth-child(2) > span.half-col.validation-failed.blur > div")] public IWebElement
            LastNameErrorMessageDisplayed;

        [FindsBy(How = How.CssSelector,
            Using = "#form-sign-up > div:nth-child(5) > span.half-col.validation-failed.blur > div")] public IWebElement
            CompanyNameErrorMessageDisplayed;

        [FindsBy(How = How.CssSelector,
            Using = "#form-sign-up > div:nth-child(6) > span.half-col.validation-failed.blur > div")] public IWebElement
            BusinessSectorErrorMessageDisplayed;

        [FindsBy(How = How.XPath, Using = ".//*[@id='form-sign-up']/div[1]/span[2]/div")] public IWebElement
            ConfirmPasswordErrorMessage;

        [FindsBy(How = How.CssSelector, Using = ".error")] public IWebElement EmailAddressErrorMessage;

        [FindsBy(How = How.CssSelector, Using = ".forgotten-password-link[href]")] public IWebElement ResetPasswordLink;

        [FindsBy(How = How.CssSelector, Using = "#EmailTextBox")] public IWebElement EmailAddressPasswordResetTextBox;

        [FindsBy(How = How.CssSelector, Using = "#content_1_ResetPasswordButton")] public IWebElement
            ResetYourPasswordButton;

        [FindsBy(How = How.CssSelector, Using = ".form-section.cf.validation-failed.load .error")] public IWebElement
            TermsAndConditionsErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#Warnings")] public IWebElement DuplicateEmailErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#Warnings.warning-bar p")] public IWebElement
            InvalidCredentialsErrorMessage;

        [FindsBy(How = How.CssSelector, Using = "#txtTax1")] public IWebElement NiNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtTax1")] public IWebElement TaxNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#TopNavigationControl_rptPrimaryLevelNav_aSectionLink_3")] public
            IWebElement MyAccountNavigationButton;

        public bool IsWarningBarPresent(int retry, int timeToWait)
        {
            try
            {
                if (WaitForElementToExistByCssSelector(".warning-bar", retry, timeToWait))
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
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                MsgOutput(string.Format("Warning bar could not be located [{0}]", elementNotVisible.Message));
                return false;
            }
            return false;
        }

        public bool IsAccountValidationSuccessMessagePresent(int retry, int timeToWait)
        {
            try
            {
                if (WaitForElementToExistByCssSelector(".box-out.email-success", retry, timeToWait))
                {
                    return true;
                }
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                MsgOutput(string.Format("Account Verification Sucess message could not be located [{0}]",
                    elementNotVisible.Message));
            }
            return false;
        }

        public bool IsResetYourPasswordButtonAvailable(int retry, int timeToWait)
        {
            try
            {
                if (WaitForElementToExistByCssSelector("#content_1_ResetPasswordButton.button-blue", retry, timeToWait))
                {
                    var resetPasswordButton =
                        Driver.FindElement(By.CssSelector("#content_1_ResetPasswordButton.button-blue"));
                    if (resetPasswordButton != null)
                    {
                        if (resetPasswordButton.Displayed)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (ElementNotVisibleException elementNotVisible)
            {
                MsgOutput(string.Format("Reset Password Button could not be located [{0}]", elementNotVisible.Message));
            }
            return false;
        }

        public void ResetYourPasswordButtonClick()
        {
            if (
                !WaitForElementToExistByCssSelector(
                    ".content.cf .wrapper .content-box.password-reset.cf .content-unit.six .box-out.reset-pass-container .generic-form .button-blue",
                    5, 5))
            {
                ResetYourPasswordButton =
                    Driver.FindElement(
                        By.CssSelector(
                            ".content.cf .wrapper .content-box.password-reset.cf .content-unit.six .box-out.reset-pass-container .generic-form .button-blue"));
            }
            ScrollTo(ResetYourPasswordButton);
            ResetYourPasswordButton.Click();
        }

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

        // Clicks the Sign In button and returns a Welcome Back page
        public WelcomeBackPage ClickSignInButton()
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<WelcomeBackPage>(Driver);
        }

        public DealerDashBoardPage SignInButtonToDealerDashboard()
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<DealerDashBoardPage>(Driver);
        }

        public LocalOfficeAdminDashBoardPage SignInButtonToLocalOfficeDashboard()
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<LocalOfficeAdminDashBoardPage>(Driver);
        }

        public LocalOfficeApproverDashBoardPage SignInButtonToLocalOfficeApproverDashboard()
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<LocalOfficeApproverDashBoardPage>(Driver);
        }

        public BankDashBoardPage SignInButtonToBankUser()
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<BankDashBoardPage>(Driver);
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

        public RegistrationPage ClickSignInWithInvalidDetails()
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<RegistrationPage>(Driver);
        }



        public void PopulateEmailAdressForChangeOfPassword(string emailAddress)
        {
            EmailAddressPasswordResetTextBox.Clear();
            EmailAddressPasswordResetTextBox.SendKeys(emailAddress);
            EmailAddressPasswordResetTextBox.SendKeys(Keys.Tab); // Tab out to trigger warning bar message
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
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password,
                GetTextBoxValue("PasswordTextBox"), "Password Text Box");
        }

        public void PopulateConfirmPasswordTextBox(string password)
        {
            ConfirmPasswordTextBox.SendKeys(password.Equals("@@@@@") ? Helper.Password : password);
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password,
                GetTextBoxValue("ConfirmPasswordTextBox"), "Confirm Password Text Box");
        }

        public void PopulateNiNumberTextBox(string numeroDni)
        {
            NiNumberTextBox.SendKeys(numeroDni);
        }

        public void PopulateTaxNumberTextBox(string codiceFiscale)
        {
            TaxNumberTextBox.SendKeys(codiceFiscale);
        }

        public void PopulateInvalidTaxNumberTextBox(string invalidTaxCode)
        {
            TaxNumberTextBox.SendKeys(invalidTaxCode);
        }

        public void PopulateInvalidItalyVatNumber(string invalidVatNumber)
        {
            VatNumberTextBox.SendKeys(invalidVatNumber);
            VatNumberTextBox.SendKeys(Keys.Tab);
        }

        public void ErrorMessageDisplayedForUsingSameVATNumber()
        {
            TestCheck.AssertIsEqual(true, WarningMessageSameVATNumber.Displayed, "Is Warning message displayed");
        }

        public void DoNotHaveAnAccountOption()
        {
            Driver.FindElement(By.CssSelector("#CreateNewAccountRadioButton"));
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
            TestCheck.AssertIsEqual("True", DoNotUseMyAccountForBusinessCheckbox.Selected.ToString(),
                "Do Not Use Account For Business Button");
        }

        public void UseAccountForBusiness()
        {
            UseMyAccountForBusinessCheckbox.Click();
            TestCheck.AssertIsEqual("True", UseMyAccountForBusinessCheckbox.Selected.ToString(),
                "Use Account For Business Button");
        }

        public void CheckTermsAndConditions()
        {
            ScrollTo(AgreeToTermsAndConditions);
            AgreeToTermsAndConditions.Click();
            TestCheck.AssertIsEqual("True", AgreeToTermsAndConditions.Selected.ToString(),
                "Accept Terms and Conditions Button");
        }

        public void CheckTermsAndConditionsForItaly()
        {
            ScrollTo(AgreeToTermsAndConditions);
            AgreeToTermsAndConditions.Click();
        }

        public void PopulatePassword(string password)
        {
            Password.SendKeys(password.Equals("@@@@@") ? Helper.Password : password);
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password, GetTextBoxValue("Password"),
                "Password");
        }

        public void PopulateMaxPassword()
        {
            Password.SendKeys("Max30CharacterPasswooooooooord");
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

        public void PopulateEmailAddressTextBoxWithMaxLengthEmail(string emailAddress)
        {
            TestCheck.AssertIsEqual(false, EmailAddressErrorMessage.Displayed, "Is Email Error message displayed");
            if (emailAddress.Equals(string.Empty))
            {
                emailAddress = Email.GenerateUniqueMaxLengthEmailAddress();
            }

            EmailAddressTextBox.Clear();
            EmailAddressTextBox.SendKeys(emailAddress);
            EmailAddressTextBox.SendKeys(Keys.Tab);
            TestCheck.AssertIsEqual(emailAddress, GetTextBoxValue("Email"), "Email Text Box");
        }


        public void EmptyEmailAddressTextBox()
        {
            EmailAddressTextBox.Clear();
            EmailAddressTextBox.SendKeys(Keys.Tab);
        }

        public void EmptyPasswordTextBox()
        {
            PasswordTextBox.Clear();
            PasswordTextBox.SendKeys(Keys.Tab);
        }

        public void EmptyFirstNameTextBox()
        {
            FirstNameTextBox.Clear();
            FirstNameTextBox.SendKeys(Keys.Tab);
        }

        public void EmptyLastNameTextBox()
        {
            LastNameTextBox.Clear();
            LastNameTextBox.SendKeys(Keys.Tab);
        }

        public void EmptyCompanyNameTextBox()
        {
            CompanyNameTextBox.Clear();
            CompanyNameTextBox.SendKeys(Keys.Tab);
        }

        public void EmptyBusinessSectorTextBox()
        {
            BusinessSectorDropDownList.SendKeys(Keys.Tab);
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

        public void FirstNameErrorMessage()
        {
            TestCheck.AssertIsEqual(true, FirstNameErrorMessageDisplayed.Displayed, "Is Error Message Displayed");
        }

        public void LastNameErrorMessage()
        {
            TestCheck.AssertIsEqual(true, LastNameErrorMessageDisplayed.Displayed, "Is Error Message Displayed");
        }

        public void CompanyNameErrorMessage()
        {
            TestCheck.AssertIsEqual(true, CompanyNameErrorMessageDisplayed.Displayed, "Is Error Message Displayed");
        }

        public void BusinessSectorErrorMessage()
        {
            TestCheck.AssertIsEqual(true, BusinessSectorErrorMessageDisplayed.Displayed, "Is Error Message Displayed");
        }

        public void ConfirmPasswordErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, ConfirmPasswordErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void TermsAndConditionsErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, TermsAndConditionsErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void DuplicateEmailErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, DuplicateEmailErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void InvalidCredentialsErrorMessageDisplayed()
        {
            TestCheck.AssertIsEqual(true, InvalidCredentialsErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void NavigateToMyAccountPage()
        {
            MyAccountNavigationButton.Click();
        }
    }
}
