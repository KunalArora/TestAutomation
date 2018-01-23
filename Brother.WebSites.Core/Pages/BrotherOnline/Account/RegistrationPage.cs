using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;


namespace Brother.WebSites.Core.Pages.BrotherOnline.Account
{
    public class RegistrationPage : BasePage, IPageObject
    {
        public static string Url = "/sign-in";

        private const string _validationElementSelector = "#form-sign-in";
        private const string _url = "/sign-in";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

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

        [FindsBy(How = How.Id, Using = "btnSignin")]
        public IWebElement SignInButtonNew;

        [FindsBy(How = How.CssSelector,
            Using =
                ".content.cf .content-box.login-register.cf .box-out.regular-sign-in.cf .generic-form #form-sign-up .button-blue"
            )] public IWebElement CreateYourAccountButton;

        [FindsBy(How = How.Id, Using = "FirstNameTextBox")] public IWebElement FirstNameTextBox;

        [FindsBy(How = How.Id, Using = "LastNameTextBox")] public IWebElement LastNameTextBox;

        // Note: there are Three password fields, one for Sign In, Two for Sign Up
        [FindsBy(How = How.Id, Using = "Password")] public new IWebElement Password;

        [FindsBy(How = How.Id, Using = "PasswordTextBox")] public IWebElement PasswordTextBox;

        [FindsBy(How = How.CssSelector, Using = "#Password")] public IWebElement Password1TextBox;
      

        [FindsBy(How = How.Id, Using = "ConfirmPasswordTextBox")] public IWebElement ConfirmPasswordTextBox;

        [FindsBy(How = How.Id, Using = "CompanyNameTextBox")] public IWebElement CompanyNameTextBox;

        [FindsBy(How = How.Id, Using = "BusinessDropDown")] public IWebElement BusinessSectorDropDownList;

        [FindsBy(How = How.Id, Using = "CompanyDropDown")] public IWebElement EmployeeCountDropDownList;

        [FindsBy(How = How.CssSelector, Using = "#CreateNewAccountRadioButton")] public IWebElement
            DoNotHaveAnAccountOptionButton;

        [FindsBy(How = How.Id, Using = "VatNumberTextBox")] public IWebElement VatNumberTextBox;

        [FindsBy(How = How.Id, Using = "error-vat-already-registered")] public IWebElement WarningMessageSameVATNumber;

        [FindsBy(How = How.Id, Using = "content_0_twocolumnsformright_0_valVatNumberRequired")] public IWebElement
            VatNumberRequiredErrorMessage;


        [FindsBy(How = How.Id, Using = "SignInRadioRadioButton")] public IWebElement DoHaveAnAccountOptionButton;

        [FindsBy(How = How.Id, Using = "BusinessAccountNoRadioButton")] public IWebElement
            DoNotUseMyAccountForBusinessCheckbox;

        [FindsBy(How = How.Id, Using = "BusinessAccountYesRadioButton")] public IWebElement
            UseMyAccountForBusinessCheckbox;

        [FindsBy(How = How.Id, Using = "TermsAndConditionsCheckbox")] public IWebElement AgreeToTermsAndConditions;

        [FindsBy(How = How.Id, Using = "Email")] public IWebElement EmailAddressTextBox;

        [FindsBy(How = How.Id, Using = "Email")] public IWebElement EmailAddress1TextBox;

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

        [FindsBy(How = How.CssSelector, Using = "#txtTax1")] 
        public IWebElement NiNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtTax1")] public IWebElement PersonalNiNumberPortugalTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtTax1")] public IWebElement TaxNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#TopNavigationControl_rptPrimaryLevelNav_aSectionLink_3")] public
            IWebElement MyAccountNavigationButton;

        public bool IsWarningBarPresent(int retry, int timeToWait)
        {
            LoggingService.WriteLogOnMethodEntry(retry,timeToWait);
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
            LoggingService.WriteLogOnMethodEntry(retry, timeToWait);
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
            LoggingService.WriteLogOnMethodEntry(retry, timeToWait);
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
            LoggingService.WriteLogOnMethodEntry();
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
            LoggingService.WriteLogOnMethodEntry();
            if (EmailAddressPasswordResetTextBox == null)
            {
                throw new NullReferenceException("Unable to locate text box on page");
            }
            AssertElementPresent(EmailAddressPasswordResetTextBox, "Email Reset Text Box");
        }

        public void IsSignInButtonAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (SignInButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(SignInButton, "Create Your Account / Sign In Button");
        }

        public void IsResetPasswordLinkAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ResetPasswordLink == null)
            {
                throw new NullReferenceException("Unable to locate password reset link on page");
            }
            AssertElementPresent(ResetPasswordLink, "Reset Password Link", 80);
        }



        public void ResetPasswordLinkClick()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(ResetPasswordLink);
            ResetPasswordLink.Click();
        }

        // Clicks the Sign In button and returns a Welcome Back page
        public WelcomeBackPage ClickSignInButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<WelcomeBackPage>(Driver);
        }

        // Clicks the Sign In button and returns to Delivery Details Page
        public DeliveryDetailsPage ClickSignInToPurchaseItems()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<DeliveryDetailsPage>(Driver);
        }

        public TPage SignInButtonToDashboard<TPage>() where TPage : BasePage, new()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<TPage>(Driver);            
        }

        public DealerDashBoardPage SignInButtonToDealerDashboard()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<DealerDashBoardPage>(Driver);
        }

        
        public LocalOfficeAdminDashBoardPage SignInButtonToLocalOfficeDashboard()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<LocalOfficeAdminDashBoardPage>(Driver);
        }

        public LocalOfficeApproverDashBoardPage SignInButtonToLocalOfficeApproverDashboard()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<LocalOfficeApproverDashBoardPage>(Driver);
        }

        public BankDashBoardPage SignInButtonToBankUser()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<BankDashBoardPage>(Driver);
        }

        public ServiceDeskDashBoardPage SignInButtonToServiceDeskDashBoardPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<ServiceDeskDashBoardPage>(Driver);
        }

        public BieAdminDashboardPage SignInButtonToBieAdminDashboardPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<BieAdminDashboardPage>(Driver);
        }

        public FinanceDashboardPage SignInButtonToFinanceDashboardPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SignInButton); 
            SignInButton.Click();
            return GetInstance<FinanceDashboardPage>(Driver);
        }

        public RegistrationPage ClickSignUpButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(CreateYourAccountButton);
            CreateYourAccountButton.Click();
            return GetInstance<RegistrationPage>(Driver);
        }

        public RegistrationConfirmationPage ClickCreateAccountButton()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(CreateYourAccountButton);
            CreateYourAccountButton.Click();
            return GetInstance<RegistrationConfirmationPage>(Driver);
        }

        public BasketPage ClickCreateAccountButtonToCheckout()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(CreateYourAccountButton);
            CreateYourAccountButton.Click();
            return GetInstance<BasketPage>(Driver);
        }

        public RegistrationPage ClickSignInWithInvalidDetails()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(SignInButton);
            SignInButton.Click();
            return GetInstance<RegistrationPage>(Driver);
        }



        public void PopulateEmailAdressForChangeOfPassword(string emailAddress)
        {
            LoggingService.WriteLogOnMethodEntry(emailAddress);
            EmailAddressPasswordResetTextBox.Clear();
            EmailAddressPasswordResetTextBox.SendKeys(emailAddress);
            EmailAddressPasswordResetTextBox.SendKeys(Keys.Tab); // Tab out to trigger warning bar message
        }

        public void PopulateFirstNameTextBox(string firstName)
        {
            LoggingService.WriteLogOnMethodEntry(firstName);
            FirstNameTextBox.SendKeys(firstName);
            TestCheck.AssertIsEqual(firstName, GetTextBoxValue("FirstNameTextBox"), "FirstName Text Box");
        }

        public void PopulateCompanyNameTextBox(string companyName)
        {
            LoggingService.WriteLogOnMethodEntry(companyName);
            ScrollTo(CompanyNameTextBox);
            CompanyNameTextBox.SendKeys(companyName);
            TestCheck.AssertIsEqual(companyName, GetTextBoxValue("CompanyNameTextBox"), "CompanyName Text Box");
        }

        public void PopulateVatNumberTextBox(string vatNumber)
        {
            LoggingService.WriteLogOnMethodEntry(vatNumber);
            ScrollTo(VatNumberTextBox);
            VatNumberTextBox.SendKeys(vatNumber);
            TestCheck.AssertIsEqual(vatNumber, GetTextBoxValue("VatNumberTextBox"), "Vat number Text Box");
        }

        public void PopulateLastNameTextBox(string lastName)
        {
            LoggingService.WriteLogOnMethodEntry(lastName);
            LastNameTextBox.SendKeys(lastName);
            TestCheck.AssertIsEqual(lastName, GetTextBoxValue("LastNameTextBox"), "LastName Text Box");
        }

        public void PopulatePasswordTextBox(string password)
        {
            LoggingService.WriteLogOnMethodEntry(password);
            PasswordTextBox.SendKeys(password.Equals("@@@@@") ? Helper.Password : password);
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password,
                GetTextBoxValue("PasswordTextBox"), "Password Text Box");
        }

        public void PopulateConfirmPasswordTextBox(string password)
        {
            LoggingService.WriteLogOnMethodEntry(password);
            ConfirmPasswordTextBox.SendKeys(password.Equals("@@@@@") ? Helper.Password : password);
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password,
                GetTextBoxValue("ConfirmPasswordTextBox"), "Confirm Password Text Box");
        }

        public void PopulateNiNumberTextBox(string numeroDni)
        {
            LoggingService.WriteLogOnMethodEntry(numeroDni);
            NiNumberTextBox.SendKeys(numeroDni);
        }

        public void PopulateTaxNumberTextBox(string codiceFiscale)
        {
            LoggingService.WriteLogOnMethodEntry(codiceFiscale);
            TaxNumberTextBox.SendKeys(codiceFiscale);
        }

        public void PopulatePersonalNiNumberPortugalTextBox(string númerodeContribuinte)
        {
            LoggingService.WriteLogOnMethodEntry(númerodeContribuinte);
            PersonalNiNumberPortugalTextBox.SendKeys(númerodeContribuinte);
        }

        public void PopulateInvalidTaxNumberTextBox(string invalidTaxCode)
        {
            LoggingService.WriteLogOnMethodEntry(invalidTaxCode);
            TaxNumberTextBox.SendKeys(invalidTaxCode);
        }

        public void PopulateInvalidItalyVatNumber(string invalidVatNumber)
        {
            LoggingService.WriteLogOnMethodEntry(invalidVatNumber);
            VatNumberTextBox.SendKeys(invalidVatNumber);
            VatNumberTextBox.SendKeys(Keys.Tab);
        }

        public void ErrorMessageDisplayedForUsingSameVATNumber()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, WarningMessageSameVATNumber.Displayed, "Is Warning message displayed");
        }

        public void ErrorMessageDisplayedMissingVatNumber()
        {
            TestCheck.AssertIsEqual(true, VatNumberRequiredErrorMessage.Displayed, "Vat Number Required");
        }
        public void DoNotHaveAnAccountOption()
        {
            LoggingService.WriteLogOnMethodEntry();
            Driver.FindElement(By.CssSelector("#CreateNewAccountRadioButton"));
            DoNotHaveAnAccountOptionButton.Click();
            TestCheck.AssertIsEqual(true, DoNotHaveAnAccountOptionButton.Selected, "Do Not Have An Account Button");
        }

        public void PopulateEmployeeCountDropDown(string numEmployees)
        {
            LoggingService.WriteLogOnMethodEntry(numEmployees);
            SelectFromDropdown(EmployeeCountDropDownList, numEmployees);
            AssertItemIsSelected(EmployeeCountDropDownList, numEmployees, "Number of Employees Drop Down List");
        }

        public void PopulateBusinessSectorDropDown(string businessSector)
        {
            LoggingService.WriteLogOnMethodEntry(businessSector);
            SelectFromDropdown(BusinessSectorDropDownList, businessSector);
            AssertItemIsSelected(BusinessSectorDropDownList, businessSector, "Business Sector Drop Down List");
        }

        public void DoHaveAnAccountOption()
        {
            LoggingService.WriteLogOnMethodEntry();
            DoHaveAnAccountOptionButton.Click();
            TestCheck.AssertIsEqual("True", DoHaveAnAccountOptionButton.Selected.ToString(), "Do Have An Account Button");
        }

        public void DoNotUseAccountForBusiness()
        {
            LoggingService.WriteLogOnMethodEntry();
            DoNotUseMyAccountForBusinessCheckbox.Click();
            TestCheck.AssertIsEqual("True", DoNotUseMyAccountForBusinessCheckbox.Selected.ToString(),
                "Do Not Use Account For Business Button");
        }

        public void UseAccountForBusiness()
        {
            LoggingService.WriteLogOnMethodEntry();
            UseMyAccountForBusinessCheckbox.Click();
            TestCheck.AssertIsEqual("True", UseMyAccountForBusinessCheckbox.Selected.ToString(),
                "Use Account For Business Button");
        }

        public void CheckTermsAndConditions()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(AgreeToTermsAndConditions);
            AgreeToTermsAndConditions.Click();
            TestCheck.AssertIsEqual("True", AgreeToTermsAndConditions.Selected.ToString(),
                "Accept Terms and Conditions Button");
        }

        public void CheckTermsAndConditionsForItaly()
        {
            LoggingService.WriteLogOnMethodEntry();
            ScrollTo(AgreeToTermsAndConditions);
            AgreeToTermsAndConditions.Click();
        }

        public void PopulatePassword(string password)
        {
            LoggingService.WriteLogOnMethodEntry(password);
            Password.SendKeys(password.Equals("@@@@@") ? Helper.Password : password);
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password, GetTextBoxValue("Password"),
                "Password");
        }

        public void PopulateMaxPassword()
        {
            LoggingService.WriteLogOnMethodEntry();
            Password.SendKeys("Max30CharacterPasswooooooooord");
        }

        public void PopulateEmailAddressTextBox(string emailAddress)
        {
            LoggingService.WriteLogOnMethodEntry(emailAddress);
            //TestCheck.AssertIsEqual(false, EmailAddressErrorMessage.Displayed, "Is Email Error message displayed");

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
            LoggingService.WriteLogOnMethodEntry(emailAddress);
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

        public void PopulateEmailAddress1TextBox(string emailAddress)
        {
            LoggingService.WriteLogOnMethodEntry(emailAddress);
            EmailAddress1TextBox.SendKeys(emailAddress);
            EmailAddress1TextBox.SendKeys(Keys.Tab);
        }

        public void PopulatePassword1TextBox(string password)
        {
            LoggingService.WriteLogOnMethodEntry(password);
            Password1TextBox.SendKeys(password);
            Password1TextBox.SendKeys(Keys.Tab);
        }

        public void EmptyEmailAddressTextBox()
        {
            LoggingService.WriteLogOnMethodEntry();
            EmailAddressTextBox.Clear();
            EmailAddressTextBox.SendKeys(Keys.Tab);
        }

        public void EmptyPasswordTextBox()
        {
            LoggingService.WriteLogOnMethodEntry();
            PasswordTextBox.Clear();
            PasswordTextBox.SendKeys(Keys.Tab);
        }

        public void EmptyFirstNameTextBox()
        {
            LoggingService.WriteLogOnMethodEntry();
            FirstNameTextBox.Clear();
            FirstNameTextBox.SendKeys(Keys.Tab);
        }

        public void EmptyLastNameTextBox()
        {
            LoggingService.WriteLogOnMethodEntry();
            LastNameTextBox.Clear();
            LastNameTextBox.SendKeys(Keys.Tab);
        }

        public void EmptyCompanyNameTextBox()
        {
            LoggingService.WriteLogOnMethodEntry();
            CompanyNameTextBox.Clear();
            CompanyNameTextBox.SendKeys(Keys.Tab);
        }

        public void EmptyBusinessSectorTextBox()
        {
            LoggingService.WriteLogOnMethodEntry();
            BusinessSectorDropDownList.SendKeys(Keys.Tab);
        }

        public void IsErrorMessageDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, EmailAddressErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void PasswordErrorMessageDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            PasswordTextBox.SendKeys(Keys.Tab);
            TestCheck.AssertIsEqual(true, PasswordErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void FirstNameErrorMessage()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, FirstNameErrorMessageDisplayed.Displayed, "Is Error Message Displayed");
        }

        public void LastNameErrorMessage()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, LastNameErrorMessageDisplayed.Displayed, "Is Error Message Displayed");
        }

        public void CompanyNameErrorMessage()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, CompanyNameErrorMessageDisplayed.Displayed, "Is Error Message Displayed");
        }

        public void BusinessSectorErrorMessage()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, BusinessSectorErrorMessageDisplayed.Displayed, "Is Error Message Displayed");
        }

        public void ConfirmPasswordErrorMessageDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, ConfirmPasswordErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void TermsAndConditionsErrorMessageDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, TermsAndConditionsErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void DuplicateEmailErrorMessageDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, DuplicateEmailErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void InvalidCredentialsErrorMessageDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            TestCheck.AssertIsEqual(true, InvalidCredentialsErrorMessage.Displayed, "Is Error Message Displayed");
        }

        public void NavigateToMyAccountPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            MyAccountNavigationButton.Click();
        }
    }
}
