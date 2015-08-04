using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherOnline.Account
{
    public class HomePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".content.cf .wrapper .hero .hero-buttons .button")]
        public IWebElement SignInCreateAccountButton;

        public void IsSignInCreateAccountButtonAvailable()
        {
            if (SignInCreateAccountButton == null)
            {
                throw new NullReferenceException("Unable to locate button on page");
            }
            AssertElementPresent(SignInCreateAccountButton, "Sign in / Create an account");
        }

        public RegistrationPage ClickSignInCreateAccountButton()
        {
            MoveToElement(SignInCreateAccountButton);
            SignInCreateAccountButton.Click();
            return GetInstance<RegistrationPage>(Driver);
        }

        [FindsBy(How = How.CssSelector, Using = "#AcceptCookieLawHyperLink")]
        public IWebElement AcceptCookiesButton;

        [FindsBy(How = How.CssSelector, Using = "#cookieLawBar > div > p")]
        public IWebElement CookiesInformationBar;

        [FindsBy(How = How.CssSelector, Using = "#cookieLawBar > div > a.button-grey")]
        public IWebElement FindOutMoreCookiesButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div > p:nth-child(3) > a")]
        public IWebElement PrivacyPolicyLink;

        //[FindsBy(How = How.CssSelector, Using = "#main > div > div.content-box.article-page.cf > div > p:nth-child(4) > a")]
        [FindsBy(How = How.CssSelector, Using = ".content-unit.six>p>a")]
        public IWebElement TermsAndConditionsLink;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div > p:nth-child(3) > a")]
        public IWebElement ContactUsLink;

        [FindsBy(How = How.CssSelector, Using = "#services > div.carousel-outer > div > div > div:nth-child(2) > p > strong > span > a")]
        public IWebElement CreativeCenterLink;

        [FindsBy(How = How.CssSelector, Using = "#cccontent_0_landingpagecontent_1_CenterRepeater_CenterOptionLink_1")]
        public IWebElement CreativeCenterFamilyLink;

        [FindsBy(How = How.CssSelector, Using = "#cccontent_0_landingpagecontent_1_CenterRepeater_CenterOptionLink_0")]
        public IWebElement CreativeCenterBusinessLink;

        [FindsBy(How = How.CssSelector, Using = "#cccontent_1_pagetop_0_RegisterLink")]
        public IWebElement CreativeCenterRegisterLoginLink;

        [FindsBy(How = How.CssSelector, Using = "#cccontent_1_singlecolumnform_1_SignUpButton")]
        public IWebElement CreativeCenterCreateAccountLink;

        [FindsBy(How = How.Id, Using = "cccontent_1_pagetop_0_Logout")]
        public IWebElement CreativeCenterLogoutLink;

        //[FindsBy(How = How.Id, Using = "hide")]
        //public IWebElement NoToCreativeCenterSurveyButton;

        [FindsBy(How = How.CssSelector, Using = "#hide")]
        public IWebElement NoToCreativeCenterSurveyButton;

        [FindsBy(How = How.Id, Using = "FirstNameTextBox")]
        public IWebElement FirstNameCCTextBox;

        [FindsBy(How = How.Id, Using = "LastNameTextBox")]
        public IWebElement LastNameCCTextBox;

        // Note: there are Three password fields, one for Sign In, Two for Sign Up
        [FindsBy(How = How.Id, Using = "Password")]
        public new IWebElement Password;

        [FindsBy(How = How.Id, Using = "PasswordTextBox")]
        public IWebElement PasswordCCTextBox;

        [FindsBy(How = How.Id, Using = "ConfirmPasswordTextBox")]
        public IWebElement ConfirmPasswordCCTextBox;

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement EmailAddressCCTextBox;

        [FindsBy(How = How.CssSelector, Using = ".error")]
        public IWebElement EmailAddressCCErrorMessage;

        [FindsBy(How = How.Id, Using = "CCCreateNewAccountRadioButton")]
        public IWebElement NoToCreativeCenterAccount;

        [FindsBy(How = How.Id, Using = "TermsAndConditionsCheckbox")]
        public IWebElement CCTermsAgreedCheckbox;

        [FindsBy(How = How.Id, Using = "BusinessAccountNoRadioButton")]
        public IWebElement NoToCreativeCenterBusinessAccount;

        [FindsBy(How = How.Id, Using = "BusinessAccountYesRadioButton")]
        public IWebElement YesToCreativeCenterBusinessAccount;

        [FindsBy(How = How.CssSelector, Using = ".content.cf .content-box.login-register.cf .box-out.regular-sign-in.cf .generic-form #form-sign-in .button-blue")]
        public IWebElement SignInButton;

        [FindsBy(How = How.CssSelector, Using = ".add-device")]
        public IWebElement RegisterDeviceLink;

        [FindsBy(How = How.CssSelector, Using = "#content_2_innercontent_2_Row1_txtSerial")]
        public IWebElement SerialCodeTextBox;

        [FindsBy(How = How.CssSelector, Using = "#registered-products > table > tbody > tr.row01 > td.model > div > p > div > span > span")]
        public IWebElement ModelNumberTextBox;

        [FindsBy(How = How.Id, Using = "CompanyNameTextBox")]
        public IWebElement CcCompanyNameTextBox;

        [FindsBy(How = How.Id, Using = "BusinessDropDown")]
        public IWebElement CcBusinessSectorDropDownList;

        [FindsBy(How = How.Id, Using = "CompanyDropDown")]
        public IWebElement CcEmployeeCountDropDownList;

        public IWebElement MyAccountNavigationButton;
        //[FindsBy(How = How.CssSelector, Using = "a.button-blue[href=\"/print-smart/my-services/consumables\"]")]
        [FindsBy(How = How.CssSelector, Using = "#content_2_ProductsTabRepeater_ProductLinkButton_4 > p:nth-child(2)")]
        
        private static readonly Dictionary<string, string> _pageTitle = new Dictionary<string, string>
        {
            {"Spain", "Inicio de sesión / Cree una cuenta"},
	        {"Poland", "Zaloguj się / Utwórz konto"},    
	        {"United Kingdom", "Sign in / Create an account"},  
	        {"Ireland", "Sign in / Create an account"},
            {"Denmark", "Min konto / Create an account"},
            {"Portugal", "Minha Conta / Create an account"},
            {"Finland", "Oma tili / Create an account"},
        };

        private static readonly Dictionary<string, string> _welcomePageTitle = new Dictionary<string, string>
        {
            {"Spain", "Inicio de Brother Online"},
	        {"Poland", "Strona główna serwisu Brother Online"},    
	        {"United Kingdom", "Brother Online Home"},
	        {"Ireland", "Brother Online Home"},
            {"Denmark", "Log på, eller registrer"},
            {"Portugal", "Brother Online Home"},
            {"Finland", "Kirjaudu sisään tai rekisteröi"},
        };

        public static String WelcomePageCountryTitle(string country)
        {
            string title;
            return _welcomePageTitle.TryGetValue(country, out title) ? title : string.Empty;
        }

        public void IsCreativeCenterLinkAvailable()
        {
            if (CreativeCenterLink == null)
            {
                throw new NullReferenceException("Unable to locate creative center link on page");
            }
            AssertElementPresent(CreativeCenterLink, "creative center link", 80);
        }


        public void IsCreativeCenterFamilyLinkAvailable()
        {
            if (CreativeCenterFamilyLink == null)
            {
                throw new NullReferenceException("Unable to locate creative center family link on page");
            }
            AssertElementPresent(CreativeCenterFamilyLink, "creative center family link", 80);
        }

        public void IsCreativeCenterBusinessLinkAvailable()
        {
            if (CreativeCenterBusinessLink == null)
            {
                throw new NullReferenceException("Unable to locate creative center business link on page");
            }
            AssertElementPresent(CreativeCenterBusinessLink, "creative center business link", 80);
        }

        public void IsCreativeCenterRegisterLoginLinkAvailable()
        {
            if (CreativeCenterRegisterLoginLink == null)
            {
                throw new NullReferenceException("Unable to locate creative center register login link on page");
            }
            AssertElementPresent(CreativeCenterRegisterLoginLink, "creative center register login link", 80);
        }

        public void IsCreativeCenterLogoutLinkAvailable()
        {
            if (CreativeCenterLogoutLink == null)
            {
                throw new NullReferenceException("Unable to locate creative center logout button on page");
            }
            AssertElementPresent(CreativeCenterLogoutLink, "creative center logout link", 80);
        }
        
        public void DoNotWantToParticipateInCreativeCenterSurvey()
         // Method doesnt work on Pahntom JS   
         //{
           //if (!WaitForElementToExistById("hide"))
           //{
            //TestCheck.AssertFailTest("Unable to locate survey no button");
           //}
           //NoToCreativeCenterSurveyButton = Driver.FindElement(By.Id("hide"));
           //ScrollTo(NoToCreativeCenterSurveyButton);
           //NoToCreativeCenterSurveyButton.Click();
         //}
        
         // Method doesnt work on Pahntom JS   
         //IWebElement NoToCreativeCenterSurveyButton = null;
         //   if (WaitForElementToExistByCssSelector("#hide", 5, 5))
         //   {
         //       NoToCreativeCenterSurveyButton = GetElementByCssSelector("#hide");
         //   }
         //   AssertElementPresent(NoToCreativeCenterSurveyButton, "Creative center no button");
        {    
            WebDriver.Wait(DurationType.Millisecond, 5000);
            //ScrollTo(NoToCreativeCenterSurveyButton);
            NoToCreativeCenterSurveyButton.Click();
        }

        public void DissmissTheJsAlert(IWebDriver driver)
        {

            ClickAcceptOnJsAlert(driver);

        }

        public void NagivetdToCreativeCenterLoginPage()
        {
            if (EmailAddressCCTextBox == null)
            {
                throw new NullReferenceException("Not on creative center login page");
            }
            AssertElementPresent(EmailAddressCCTextBox, "Problem loading login page for creative center", 80);
        }


        public void ClickDismissOnConfrimation(IWebDriver driver)
        {
            WebDriver.Wait(DurationType.Millisecond, 100);
            ClickDismissOnJsAlert(driver);
        }

        public void DoNotHaveCreativeCenterAccount()
        {
            WebDriver.Wait(DurationType.Millisecond, 3000);
            if (NoToCreativeCenterAccount == null)
            {
                throw new NullReferenceException("Unable to locate creative center acc no radio button");
            }
            AssertElementPresent(NoToCreativeCenterAccount, "creative center account no", 80);

            ScrollTo(NoToCreativeCenterAccount);
            NoToCreativeCenterAccount.Click();
        }

        public void DoNotUseCreativeCenterAccForBusiness()
        {
            if (NoToCreativeCenterBusinessAccount == null)
            {
                throw new NullReferenceException("Unable to locate creative center business no radio button");
            }
            AssertElementPresent(NoToCreativeCenterBusinessAccount, "creative center business no", 80);

            ScrollTo(NoToCreativeCenterBusinessAccount);
            NoToCreativeCenterBusinessAccount.Click();
        }

        public void UseCreativeCenterAccForBusiness()
        {
            if (YesToCreativeCenterBusinessAccount == null)
            {
                throw new NullReferenceException("Unable to locate creative center business yes radio button");
            }
            AssertElementPresent(YesToCreativeCenterBusinessAccount, "creative center business yes", 80);

            ScrollTo(YesToCreativeCenterBusinessAccount);
            YesToCreativeCenterBusinessAccount.Click();
        }

        public void AgreedToCreativeCenterTerms()
        {
            if (CCTermsAgreedCheckbox == null)
            {
                throw new NullReferenceException("Unable to locate creative center terms check box");
            }
            AssertElementPresent(CCTermsAgreedCheckbox, "creative center terms check box", 80);

            ScrollTo(CCTermsAgreedCheckbox);
            CCTermsAgreedCheckbox.Click();
        }

        
        public void SwitchToNewlyOpenedWindow(IWebDriver driver)
        {
            SwitchToNewWindow(driver);
        }

        public void IsAcceptCookieButtonAvailable()
        {
            TestCheck.AssertIsNotEqual("False", AcceptCookiesButton.Displayed.ToString(), "Cookie button incorrectly displayed");
        }

        public void IsAcceptCookieButtonNotAvailable()
        {
            TestCheck.AssertIsNotEqual("True", AcceptCookiesButton.Displayed.ToString(), "Cookie button incorrectly displayed");
        }

        public void AcceptCookiesButtonClick()
        {
            ScrollTo(AcceptCookiesButton);
            AcceptCookiesButton.Click();
        }

        public void IsFindOutMoreCookiesButtonAvailable()
        {
            if (FindOutMoreCookiesButton == null)
            {
                throw new NullReferenceException("Unable to locate accept cookies button on page");
            }
            AssertElementPresent(FindOutMoreCookiesButton, "Accept Cookies Button", 80);
        }

        public void FindOutMoreCookiesButtonClick()
        {
            ScrollTo(FindOutMoreCookiesButton);
            FindOutMoreCookiesButton.Click();
        }

        public void IsCookiesInformationBarAvailable()
        {
            if (CookiesInformationBar == null)
            {
                throw new NullReferenceException("Unable to locate accept cookies button on page");
            }
            AssertElementPresent(CookiesInformationBar, "Accept Cookies Button", 80);
        }

        public void IsPrivacyPolicyLinkAvailable()
        {
            if (PrivacyPolicyLink == null)
            {
                throw new NullReferenceException("Unable to locate privacy policy link on page");
            }
            AssertElementPresent(PrivacyPolicyLink, "Privacy policy link", 80);
        }

        public void PrivacyPolicyLinkClick()
        {
            ScrollTo(PrivacyPolicyLink);
            PrivacyPolicyLink.Click();
        }

        public void IsCompanyTermsAndConditionsLinkAvailable()
        {
            if (TermsAndConditionsLink == null)
            {
                throw new NullReferenceException("Unable to locate terms and conditions link on page");
            }
            AssertElementPresent(TermsAndConditionsLink, "Terms and conditions link", 80);
        }

        public void CompanyTermsAndConditionsLinkClick()
        {
            ScrollTo(TermsAndConditionsLink);
            TermsAndConditionsLink.Click();
        }


        public void IsContactUsLinkAvailable()
        {
            if (ContactUsLink == null)
            {
                throw new NullReferenceException("Unable to locate contact us link on page");
            }
            AssertElementPresent(ContactUsLink, "Contact us link", 80);
        }

        public void ContactUsLinkClick()
        {
            ScrollTo(ContactUsLink);
            ContactUsLink.Click();
        }

        public void CreativeCenterLinkClick()
        {
            ScrollTo(CreativeCenterLink);
            CreativeCenterLink.Click();
        }

        public void CreativeCenterFamilyLinkClick()
        {
            ScrollTo(CreativeCenterFamilyLink);
            CreativeCenterFamilyLink.Click();
        }

        public void CreativeCenterBusinessLinkClick()
        {
            ScrollTo(CreativeCenterBusinessLink);
            CreativeCenterBusinessLink.Click();
        }

        public void CreativeCenterRegisterLoginLinkClick()
        {
            ScrollTo(CreativeCenterRegisterLoginLink);
            CreativeCenterRegisterLoginLink.Click();
        }

        public void CreativeCenterCreateAccountClick()
        {
            ScrollTo(CreativeCenterCreateAccountLink);
            CreativeCenterCreateAccountLink.Click();
        }

        public void PopulateCCFirstNameTextBox(string firstName)
        {
            FirstNameCCTextBox.SendKeys(firstName);
            TestCheck.AssertIsEqual(firstName, GetTextBoxValue("FirstNameTextBox"), "FirstName Text Box");
        }

        public void PopulateCCLastNameTextBox(string lastName)
        {
            LastNameCCTextBox.SendKeys(lastName);
            TestCheck.AssertIsEqual(lastName, GetTextBoxValue("LastNameTextBox"), "LastName Text Box");
        }

        public void PopulateCCPasswordTextBox(string password)
        {
            PasswordCCTextBox.SendKeys(password.Equals("@@@@@") ? Helper.Password : password);
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password, GetTextBoxValue("PasswordTextBox"), "Password Text Box");
        }

        public void PopulateCCConfirmPasswordTextBox(string password)
        {
            ConfirmPasswordCCTextBox.SendKeys(password.Equals("@@@@@") ? Helper.Password : password);
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password, GetTextBoxValue("ConfirmPasswordTextBox"), "Confirm Password Text Box");
        }



        public void PopulateEmailAddressTextBoxWithValidCCEmail(string emailAddress)
        {
            TestCheck.AssertIsEqual(false, EmailAddressCCErrorMessage.Displayed, "Is Email Error message displayed");
            if (emailAddress.Equals(string.Empty))
            {
                emailAddress = Email.GenerateUniqueCCEmailAddress();
            }

            EmailAddressCCTextBox.Clear();
            EmailAddressCCTextBox.SendKeys(emailAddress);
            EmailAddressCCTextBox.SendKeys(Keys.Tab);
            TestCheck.AssertIsEqual(emailAddress, GetTextBoxValue("Email"), "Email Text Box");
        }

        public void PopulatePasswordWithCCCredentials(string password)
        {
            Password.SendKeys(password.Equals("@@@@@") ? Helper.Password : password);
            TestCheck.AssertIsEqual(password.Equals("@@@@@") ? Helper.Password : password, GetTextBoxValue("Password"), "Password");
        }

        public void ClickSignInButtonWithCCCredentials()
        {
            ScrollTo(SignInButton);
            SignInButton.Click();
        }

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

        public void ClickRegisterDeviceLink()
        {
            if (!WaitForElementToExistByCssSelector(".add-device"))
            {
                TestCheck.AssertFailTest("Unable to locate the Add Device button");
            }
            RegisterDeviceLink = Driver.FindElement(By.CssSelector(".add-device"));
            ScrollTo(RegisterDeviceLink);
            RegisterDeviceLink.Click();
            //return GetInstance<RegisterDevicePage>(Driver);
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

        public void IsProductSerialCodeTextBoxAvailable()
        {
            if (SerialCodeTextBox == null)
            {
                throw new Exception("Unable to locate TextBox on page");
            }
            AssertElementPresent(SerialCodeTextBox, "Serial Code Text Box");
        }

        private void StoreModelNumber()
        {
            WebDriver.Wait(DurationType.Second, 6); // pause for element to be populated. Explicit wait can cause StaleElement exception
            CurrentDeviceModelNumber = ModelNumberTextBox.Text;
        }

        public bool IsErrorIconPresent()
        {
            // override current time outs
            WebDriver.SetPageLoadTimeout(new TimeSpan(0, 0, 0, 10));
            WebDriver.SetWebDriverImplicitTimeout(new TimeSpan(0, 0, 0, 10));

            var errorIcon = GetElementByCssSelector(".error");

            // revert to default
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.PageLoad);
            WebDriver.SetWebDriverDefaultTimeOuts(WebDriver.DefaultTimeOut.Implicit);

            return errorIcon != null;
        }

        public void CreativeCenterLogoutLinkClick()
        {
            ScrollTo(CreativeCenterLogoutLink);
            CreativeCenterLogoutLink.Click();
        }

        public void PopulateCcCompanyNameTextBox(string companyName)
        {
            ScrollTo(CcCompanyNameTextBox);
            CcCompanyNameTextBox.SendKeys(companyName);
            //TestCheck.AssertIsEqual(companyName, GetTextBoxValue("CcCompanyNameTextBox"), "Creative Center CompanyName Text Box");
        }

        public void PopulateCcBusinessSectorDropDown(string ccbusinessSector)
        {  
            SelectFromDropdown(CcBusinessSectorDropDownList, ccbusinessSector);
            AssertItemIsSelected(CcBusinessSectorDropDownList, ccbusinessSector, "Creative Center Business Sector Drop Down List");
        }

        public void PopulateCcEmployeeCountDropDown(string numEmployees)
        {
            SelectFromDropdown(CcEmployeeCountDropDownList, numEmployees);
            AssertItemIsSelected(CcEmployeeCountDropDownList, numEmployees, "Number of Employees creative center Drop Down List");
        }


        public void NavigateToMyAccountPageWithCcCredentials()
        {
            //ScrollTo(MyAccountNavigationButton);
            MyAccountNavigationButton.Click();
        }


    }

}
