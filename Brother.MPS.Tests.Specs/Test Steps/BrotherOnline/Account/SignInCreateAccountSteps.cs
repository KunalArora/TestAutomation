﻿using System;
using System.Collections.Generic;
using System.Threading;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlow = Brother.Tests.Selenium.Lib.Support.HelperClasses.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline.Account
{
    [Binding]
    public class CreateNewAccountSteps : BaseSteps
    {
        [Given(@"I am logged into Brother Online ""(.*)"" using ""(.*)""")]
        public void GivenIAmLoggedIntoBrotherOnlineUsing(string country, string emailAddress)
        {
            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BrotherOnlineBaseUrl, "");
            WhenIClickOnSignInCreateAnAccount(country);
            WhenIAmRedirectedToTheBrotherLoginRegisterPage();
            DoHaveAnAccountCheckbox();
            WhenIEnterAValidEmailAddress(emailAddress);
            CurrentPage.As<RegistrationPage>().PopulatePassword(Helper.Password);
            WhenIClickOnSignIn(country);
            CurrentPage.As<WelcomeBackPage>().IsRegisterDeviceLinkAvailable();
        }

        [Obsolete("No usages of step definition")]
        [Given(@"I am logged onto ""(.*)"" BOL with ""(.*)"" username and ""(.*)"" password")]
        public void GivenIAmLoggedOntoBOLWithUsernameAndPassword(string country, string username, string pwd)
        {
            {
                Helper.SetCountry(country);
                CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BrotherOnlineBaseUrl, "");
                WhenIClickOnSignInCreateAnAccount(country);
                WhenIAmRedirectedToTheBrotherLoginRegisterPage();
                WhenIEnterAValidEmailAddress(username);
                WhenIEnterAValidPassword(pwd);
                WhenIClickOnSignIn(country);
            }
        }

        [Then(@"I reset my password with ""(.*)""")]
        public void ThenIResetMyPasswordWith(string newPassword)
        {
            CurrentPage.As<RegistrationPage>().IsResetYourPasswordButtonAvailable(5, 10);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(newPassword);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(newPassword);
            // Set new password so we can sign in again using the updated password
            Helper.Password = newPassword;
        }

        [Then(@"I delete all page cookies")]
        public void DeleteAllPageCookies()
        {
            WebDriver.DeleteAllCookies();
        }

        [Then(@"I can see and click the accept cookies button")]
        public void CanSeeAndClickTheAcceptCookiesButton()
        {
            CurrentPage.As<HomePage>().AcceptCookiesButtonClick();
        }

        [Then(@"I can see the cookies information bar")]
        [Then(@"I continue to see the cookies information bar")]
        public void CanSeeTheCookiesInformationBar()
        {
            CurrentPage.As<HomePage>().IsCookiesInformationBarAvailable();
        }

        [Then(@"I can see and click the find out more button on the cookies information bar")]
        public void CanSeeAndClickTheFindOutMoreCookiesButton()
        {
            CurrentPage.As<HomePage>().IsFindOutMoreCookiesButtonAvailable();
            CurrentPage.As<HomePage>().FindOutMoreCookiesButtonClick();
        }

        [Then(@"I click to view the company terms and conditions")]
        public void CanSeeAndClickTheCompanyTermsAndConditionsLink()
        {
            CurrentPage.As<HomePage>().IsCompanyTermsAndConditionsLinkAvailable();
            CurrentPage.As<HomePage>().CompanyTermsAndConditionsLinkClick();
        }

        [Then(@"I am navigated to the company terms and conditions page")]
        public void IsNavigatedToTheCompanyTermsAndConditionsPage()
        {
            CurrentPage.As<HomePage>().IsContactUsLinkAvailable();
        }

        [Then(@"I am navigated to the privacy policy for cookies")]
        public void IsNavigatedToThePrivacyPolicyPage()
        {
            CurrentPage.As<HomePage>().SwitchToNewlyOpenedWindow(CurrentDriver);
            CurrentPage.As<HomePage>().IsCompanyTermsAndConditionsLinkAvailable();
        }

        [Then(@"I can no longer see the accept cookies button")]
        public void CannotSeeTheAcceptCookiesButton()
        {
            CurrentPage.As<HomePage>().IsAcceptCookieButtonNotAvailable();
        }

        [When(@"I navigate to and click the creative center link")]
        public void CanSeeAndClickCreativeCenterLink()
        {
            CurrentPage.As<HomePage>().IsCreativeCenterLinkAvailable();
            CurrentPage.As<HomePage>().CreativeCenterLinkClick();
        }

        [Then(@"I am taken to the creative center landing page")]
        public void AmTakenToCreativeCenterLandingPage()
        {
            CurrentPage.As<HomePage>().IsCreativeCenterFamilyLinkAvailable();
            CurrentPage.As<HomePage>().IsCreativeCenterBusinessLinkAvailable();
        }

        [Then(@"I click the family center link")]
        public void ClickTheFamilyCenterLink()
        {
            CurrentPage.As<HomePage>().IsCreativeCenterFamilyLinkAvailable();
            CurrentPage.As<HomePage>().CreativeCenterFamilyLinkClick();
        }

        [Then(@"I click the business center link")]
        public void ClickTheBusinessCenterLink()
        {
            CurrentPage.As<HomePage>().IsCreativeCenterBusinessLinkAvailable();
            CurrentPage.As<HomePage>().CreativeCenterBusinessLinkClick();
        }
        [When(@"I click the business center link")]
        public void WhenIClickTheBusinessCenterLink()
        {
            CurrentPage.As<HomePage>().CreativeCenterBusinessLinkClick();
        }

        [Then(@"I am taken to the creative center home page")]
        public void TakenToCreativeCenterHomepage()
        {
            CurrentPage.As<HomePage>().IsCreativeCenterRegisterLoginLinkAvailable();
        }

        [Then(@"I click the creative center register/login link")]
        public void ClickTheCreativeCenterFamilyLink()
        {
            CurrentPage.As<HomePage>().CreativeCenterRegisterLoginLinkClick();
        }

        [Then(@"I am navigated to the creative center login page")]
        public void NavigatedToCreativeCenterLoginPage()
        {
            CurrentPage.As<HomePage>().NagiveteToCreativeCenterLoginPage();

        }

        [Then(@"I click the creative center create your account button")]
        public void ClickCreateCreativeCenterAccount()
        {
            CurrentPage.As<HomePage>().CreativeCenterCreateAccountClick();
        }

        [Then(@"I am logged into creative center")]
        public void AmLoggedIntoCreativeCenter()
        {
            CurrentPage.As<HomePage>().IsCreativeCenterLogoutLinkAvailable();
        }

        [Then(@"I sign out of creative center")]
        public void AmSignedOutOfCreativeCenter()
        {
            CurrentPage.As<HomePage>().IsCreativeCenterLogoutLinkAvailable();
            CurrentPage.As<HomePage>().CreativeCenterLogoutLinkClick();
            //CurrentPage.As<HomePage>().DissmissTheJsAlert(CurrentDriver);
            CurrentPage.As<HomePage>().IsCreativeCenterFamilyLinkAvailable();
            CurrentPage.As<HomePage>().IsCreativeCenterBusinessLinkAvailable();
        }
        [Then(@"I click sign out of creative center")]
        public void ThenIClickSignOutOfCreativeCenter()
        {
            CurrentPage.As<HomePage>().CreativeCenterLogoutLinkClick(); 
        }
        // This is a phantom JS workaround for the method below
        [Then(@"I click to not participate in the survey")]
        public void ClickNoToCreativeCenterSurvey()
        {
            CurrentPage.As<HomePage>().DoNotWantToParticipateInCreativeCenterSurvey();
        }

        // Currently not working for creative center alert pop up in Phantom JS
        [Then(@"I click to remove browser confirmation dialogue")]
        public void WhenIClickToRemoveBrowserConfirmationDialog()
        {
            CurrentPage.As<HomePage>().ClickDismissOnConfrimation();
        }

        [Then(@"I have checked no to having a creative center account")]
        public void ClickNoToCreativeCenterAccount()
        {
            CurrentPage.As<HomePage>().DoNotHaveCreativeCenterAccount();
        }

        [Then(@"I declare that I do not use this creative center account for business")]
        public void ClickNoToCreativeCenterBusiness()
        {
            CurrentPage.As<HomePage>().DoNotUseCreativeCenterAccForBusiness();
        }

        [Then(@"I declare that I do use this creative center account for business")]
        public void ClickYesToCreativeCenterBusiness()
        {
            CurrentPage.As<HomePage>().UseCreativeCenterAccForBusiness();
        }

        [Then(@"I have Agreed to the creative center Terms and Conditions")]
        public void ClickYesToCreativeCenterTerms()
        {
            CurrentPage.As<HomePage>().AgreedToCreativeCenterTerms();
        }

        [When(@"I click on Reset Your Password")]
        [Then(@"I click on Reset Your Password")]
        public void ThenIClickOnResetYourPassword()
        {
            CurrentPage.As<RegistrationPage>().ResetYourPasswordButtonClick();
        }

        [Then(@"If I click on Forgot Password")]
        [When(@"I click on Forgot Password")]
        public void WhenIClickOnForgotPassword()
        {
            CurrentPage.As<RegistrationPage>().IsResetPasswordLinkAvailable();
            CurrentPage.As<RegistrationPage>().ResetPasswordLinkClick();
        }

        [Then(@"I enter an invalid email address as ""(.*)""")]
        public void ThenIEnterAnInvalidEmailAddressAs(string emailAddress)
        {
            When(string.Format("Enter Email Address as \"{0}\"", emailAddress));
        }

        [Then(@"I enter an email address with leading spaces as ""(.*)""")]
        public void ThenIEnterAnEmailAddressWithLeadingSpacesAs(string emailAddress)
        {
            When(string.Format("Enter Email Address as \"{0}\"", emailAddress));
        }

        [Then(@"I enter an email address with an invalid user password as ""(.*)""")]
        public void ThenIEnterAnEmailAddressWithAnInvalidUserPasswordAs(string emailAddress)
        {
            When(string.Format("Enter Email Address as \"{0}\"", emailAddress));
        }

        [Then(@"I enter an email address with an invalid formed password as ""(.*)""")]
        public void ThenIEnterAnEmailAddressWithAnInvalidFormedPasswordAs(string emailAddress)
        {
            WhenEnterEmailAddressAs(emailAddress);
        }

        [Then(@"I enter an email address with too many allowed characters as ""(.*)""")]
        public void ThenIEnterAnEmailAddressWithTooManyAllowedCharactersAs(string emailAddress)
        {
            WhenEnterEmailAddressAs(emailAddress);
        }

        [When(@"Enter Email Address as ""(.*)""")]
        public void WhenEnterEmailAddressAs(string emailAddress)
        {
            CurrentPage.As<RegistrationPage>().IsEmailResetTextBoxAvailable();
            CurrentPage.As<RegistrationPage>().PopulateEmailAdressForChangeOfPassword(emailAddress);
        }

        [Then(@"I enter my current email address")]
        public void ThenIEnterMyCurrentEmailAddress()
        {
            CurrentPage.As<RegistrationPage>().IsEmailResetTextBoxAvailable();
            CurrentPage.As<RegistrationPage>().PopulateEmailAdressForChangeOfPassword(Email.RegistrationEmailAddress);
        }

        [Then(@"I can navigate to the Brother Online Home Page ""(.*)""")]
        [Given(@"I want to create a new account with Brother Online ""(.*)""")]
        public void GivenIWantToCreateANewAccountWithBrotherOnline(string country)
        {
            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BrotherOnlineBaseUrl, "");
        }

        [Given(@"I Need A Brother Online ""(.*)"" Account In Order To Use Brother Online Services")]
        public void GivenINeedABrotherOnlineAccountInOrderToUseBrotherOnlineServices(string country)
        {
            Helper.SetCountry(country);
            GivenIWantToCreateANewAccountWithBrotherOnline(country);
            WhenIClickOnSignInCreateAnAccount(country);
            WhenIAmRedirectedToTheBrotherLoginRegisterPage();
            DoNotHaveAnAccountCheckbox();

            CurrentPage.As<RegistrationPage>().PopulateFirstNameTextBox(Helper.DefaultFirstName);
            CurrentPage.As<RegistrationPage>().PopulateLastNameTextBox(Helper.DefaultLastName);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(Helper.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(Helper.Password);
            WhenIEnterAValidEmailAddress(string.Empty);

            WhenIHaveAgreedToTheTermsAndConditions();
            WhenIDeclareThatIDoNotUseThisAccountForBusiness();
            WhenIPressCreateYourAccount();
            ThenIShouldSeeMyAccountConfirmationScreen();
            ThenWhenIClickGoBack();
            ThenOnceIHaveConfirmedMyAccount();
            ThenIShouldBeAbleToLogIntoBrotherOnlineUsingMyAccountDetails(country);
        }
      
        [Then(@"Once I have confirmed my account by clicking on the email link")]
        public void ThenOnceIHaveConfirmedMyAccount()
        {
            // Called from ThirdParty library
            Then("Once I have Validated an Email was received and verified my account");
        }

        [Given(@"I am logged onto Brother Online ""(.*)"" using valid credentials")]
        public void GivenIAmLoggedOntoBrotherOnlineUsingValidCredentials(string country)
        {
            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BrotherOnlineBaseUrl, "");
            GivenINeedABrotherOnlineAccountInOrderToUseBrotherOnlineServices(country);
        }
        
        [Given(@"I launch Brother Online for ""(.*)""")]
        public void GivenILaunchBrotherOnlineFor(string country)
        {
            // Set locale to direct to Brother Online Ireland
            Helper.SetCountry(country);
            var title = HomePage.WelcomePageCountryTitle(country);
            if (Helper.CountryIsUsingAtYourSideLogin(country))
            {
                CurrentPage = BasePage.LoadAtYourSideHomePage(CurrentDriver);
            }
            else
            {
                CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BrotherOnlineBaseUrl, title);
            }
            //CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, @"http://online.co.uk.cds.uat65.brother.eu.com", title);
        }

        [Then(@"I click on the sign in / create account button")]
        public void ClickOnBrotherOnlineSigninCreateAccountButton()
        {
            CurrentPage.As<HomePage>().IsSignInCreateAccountButtonAvailable();
            CurrentPage.As<HomePage>().ClickSignInCreateAccountButton();
        }

        [Then(@"I have navigated to the Brother online ""(.*)""")]
        public void ThenIHaveNavigatedToTheBrotherOnline(string country)
        {

            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BrotherOnlineBaseUrl, "");         
        }

        [When(@"I sign into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [When(@"I return to Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [When(@"I sign back into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [Then(@"I sign back into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [Then(@"I sign into MPS as a ""(.*)"" from ""(.*)""")]
        [Then(@"I sign into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [Given(@"I sign back into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [Given(@"I sign into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [Given(@"I sign into MPS as a ""(.*)"" from ""(.*)""")]
        public void GivenISignIntoMpsasAFrom(string role, string country)
        {
            if (Helper.CountryIsUsingAtYourSideLogin(country))
            {
                Helper.SetCountry(country);
                Given(string.Format(@"I sign into Cloud MPS bypassing the home page as a ""{0}"" from ""{1}""", role, country));
                //WhenISignInAsA(role, country);
                return;
            }

            GivenILaunchBrotherOnlineFor(country);
            WhenIClickOnSignInCreateAnAccount(country);
            WhenISignInAsA(role, country);

        }
        
        [Given(@"I verify and store ""(.*)"" purchase and click proposal bypass status")]
        public void GivenIVerifyAndStorePurchaseAndClickProposalBypassStatus(string country)
        {
            SetProposalByPassValue(country, "Easy Print Pro & Service");
        }

        [Given(@"I verify and store ""(.*)"" Lease and click proposal bypass status")]
        public void GivenIVerifyAndStoreLeaseAndClickProposalBypassStatus(string country)
        {
            SetProposalByPassValue(country, "Leasing & Service");

        }

        
        public void SetProposalByPassValue(string country, string contractType)
        {
            GivenILaunchBrotherOnlineFor(country);
            WhenIClickOnSignInCreateAnAccount(country);
            WhenISignInAsA("Cloud MPS Local Office", country);
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToLoProgramPage();
            if (contractType.Equals("Lease & Click with Service") || contractType.Equals("Leasing & Service"))
            {
                NextPage = CurrentPage.As<LocalOfficeAdminProgramsDashboardPage>().NavigateToLeaseAndClickPage();
            }
            else if (contractType.Equals("Purchase & Click with Service") || contractType.Equals("Easy Print Pro & Service") ||
                contractType.Equals("Buy + Click"))
            {
                NextPage = CurrentPage.As<LocalOfficeAdminProgramsDashboardPage>().NavigateToPurchaseAndClickPage();
            }
            
            CurrentPage.As<LocalOfficeAdminProgramSettingPage>().SetProposalByPassOption();
            CurrentPage.As<LocalOfficeAdminProgramSettingPage>().SetInstallationPointOption();
            CurrentPage.As<LocalOfficeAdminProgramSettingPage>().SetCustomerCreationPointOption();
            GlobalNavigationModule.ClickSignOutLink(CurrentDriver);
        }

        [When(@"I sign back into ""(.*)"" Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [Given(@"I sign back into ""(.*)"" Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [Then(@"I sign back into ""(.*)"" Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [When(@"I sign as ""(.*)"" into ""(.*)"" for ""(.*)""")]
        [Given(@"I sign as ""(.*)"" into ""(.*)"" for ""(.*)""")]
        public void GivenISignAsIntoFor(string role, string web, string country)
        {
            Helper.SetCountry(country);
            var title = HomePage.WelcomePageCountryTitle(country);

            if (Helper.CountryIsUsingAtYourSideLogin(country))
            {
                Helper.SetCountry(country);
                Given(string.Format(@"I sign into Cloud MPS using the At Your Side journey as a ""{0}"" from ""{1}"" on server ""{2}""", role, country, web));
                WhenISignInAsA(role, country);
                return;
            }

            CurrentPage = BasePage.LoadWebBoxes(CurrentDriver, web, title);
            NextPage = CurrentPage.As<HomePage>().ClickSignInCreateAccountButton();
            SignInAsARoleType(role, country);
            SignInButtonToAsARoleType(role);
        }


        // Sign in Scenario using all steps - useful for calling from other Scenarios
        [Given(@"I sign into Brother Online ""(.*)"" using valid credentials")]
        public void GivenISignIntoBrotherOnlineUsingValidCredentials(string country)
        {
            // Home Page
            GivenINeedABrotherOnlineAccountInOrderToUseBrotherOnlineServices(country);
        }

        [Then(@"If I go back to Brother Online Home Page")]
        public void ThenIfIGoBackToBrotherOnlineHomePage()
        {
            // Used to navigate back the home page (temporary) whilst
            // logged into BOL. Should navigate to the WelcomeBack page
            NextPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BrotherOnlineBaseUrl, "");
        }
        [Then(@"If I go back to Brother Site home page on ""(.*)"" and ""(.*)""")]
        public void ThenIfIGoBackToBrotherSiteHomePageOnAnd(string web, string country)
        {
            Helper.SetCountry(country);
            var title = HomePage.WelcomePageCountryTitle(country);
            CurrentPage = BasePage.LoadWebBoxes(CurrentDriver, web, title);
  
        }
        // Placeholder - called via other pages
        [Then(@"I am redirected to the Brother Home Page")]
        public void ThenIAmRedirectedToTheBrotherHomePage()
        {
            CurrentPage.As<HomePage>().IsSignInCreateAccountButtonAvailable();
        }

        [Then(@"I am redirected to the Brother Login/Register page")]
        public void ThenIAmRedirectedToTheBrotherLoginRegisterPage()
        {
            WhenIAmRedirectedToTheBrotherLoginRegisterPage();
        }

        [When(@"I am redirected to the Brother Login/Register page")]
        public void WhenIAmRedirectedToTheBrotherLoginRegisterPage()
        {
            CurrentPage.As<RegistrationPage>().IsSignInButtonAvailable();
        }
        [When(@"I have Checked Yes I Do Have An Account Checkbox")]
        public void DoHaveAnAccountCheckbox()
        {
            CurrentPage.As<RegistrationPage>().DoHaveAnAccountOption();
        }

        [When(@"I have Checked No I Do Not Have An Account Checkbox")]
        public void DoNotHaveAnAccountCheckbox()
        {
            CurrentPage.As<RegistrationPage>().DoNotHaveAnAccountOption();
        }

        [When(@"I fill in the registration information using a valid email address")]
        public void WhenIFillInTheRegistrationInformationUsingAValidEmailAddress(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<RegistrationPage>().PopulateFirstNameTextBox(form.FirstName);
            CurrentPage.As<RegistrationPage>().PopulateLastNameTextBox(form.LastName);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(form.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(form.Password);
            WhenIEnterAValidEmailAddress(string.Empty); // Auto Generates with an empty string
        }
        [When(@"I fill in the registration information using a valid email address and ID number")]
        public void WhenIFillInTheRegistrationInformationUsingAValidEmailAddressAndIDNumber(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<RegistrationPage>().PopulateFirstNameTextBox(form.FirstName);
            CurrentPage.As<RegistrationPage>().PopulateLastNameTextBox(form.LastName);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(form.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(form.Password);
            WhenIEnterAValidEmailAddress(string.Empty); // Auto Generates with an empty string
            CurrentPage.As<RegistrationPage>().PopulateNiNumberTextBox(form.NumeroDNI); //tax number for Spain
            //CurrentPage.As<RegistrationPage>().PopulateTaxNumberTextBox(form.CodiceFiscale);//tax number for Italy
        }

        [When(@"I fill in the registration information using a valid email address on Portugal signin page")]
        public void WhenIFillInTheRegistrationInformationUsingAValidEmailAddressOnPortugalSigninPage(Table table)
        {
           
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<RegistrationPage>().PopulateFirstNameTextBox(form.FirstName);
            CurrentPage.As<RegistrationPage>().PopulateLastNameTextBox(form.LastName);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(form.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(form.Password);
            WhenIEnterAValidEmailAddress(string.Empty); // Auto Generates with an empty string
            
        }

        [When(@"I fill in personal tax number as ""(.*)""")]
        public void WhenIFillInPersonalTaxNumberAs(string númerodeContribuinte)
        {

            CurrentPage.As<RegistrationPage>().PopulatePersonalNiNumberPortugalTextBox(númerodeContribuinte);
        }

        [When(@"I fill in the registration information using a valid email address and ID number for italy")]
        public void WhenIFillInTheRegistrationInformationUsingAValidEmailAddressAndIdNumberForItaly(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<RegistrationPage>().PopulateFirstNameTextBox(form.FirstName);
            CurrentPage.As<RegistrationPage>().PopulateLastNameTextBox(form.LastName);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(form.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(form.Password);
            WhenIEnterAValidEmailAddress(string.Empty); // Auto Generates with an empty string
            CurrentPage.As<RegistrationPage>().PopulateTaxNumberTextBox(form.CodiceFiscale); //tax number for Italy
            //CurrentPage.As<RegistrationPage>().PopulateTaxNumberTextBox(form.CodiceFiscale); //tax number for Portugal
        }

        [When(@"I fill in the registration information using a valid email address and excluding ID number for italy")]
        [When(@"I fill in the Italy registration information using a valid email address")]
        [When(@"I fill in the Italy registration information using a valid email address and excluding ID number for italy")]
        [When(@"I fill in the Portugal registration information using a valid email address and excluding the VAT number")
        ]
        
        public void WhenIFillInTheItalyRegistrationInformationUsingAValidEmailAddressAndExcludingIdNumberForItaly(
            Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<RegistrationPage>().PopulateFirstNameTextBox(form.FirstName);
            CurrentPage.As<RegistrationPage>().PopulateLastNameTextBox(form.LastName);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(form.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(form.Password);
            WhenIEnterAValidEmailAddress(string.Empty); // Auto Generates with an empty string
        }

        [When(@"I enter an invalid ""(.*)"" for Italy")]
        public void WhenIEnterAnInvalidForItaly(string invalidTaxCode)
        {
            CurrentPage.As<RegistrationPage>().PopulateInvalidTaxNumberTextBox(invalidTaxCode); //tax number for Italy
        }

        [When(@"I enter an valid (.*)")]
        public void WhenIEnterAnValid(string validTaxCode)
        {
            CurrentPage.As<RegistrationPage>().PopulateTaxNumberTextBox(validTaxCode);
        }
        [When(@"I enter an invalid VAT Number as ""(.*)""")]
        [When(@"I enter an invalid Italy VAT Number as ""(.*)""")]
        [When(@"I enter a valid VAT number as ""(.*)"" for Portugal")]
        public void WhenIEnterAnInvalidItalyVatNumberAs(string vatNumber)
        {
            CurrentPage.As<RegistrationPage>().PopulateInvalidItalyVatNumber(vatNumber); //tax number for Italy
        }

        [When(@"I can see a warning message for using already used VAT number")]
        public void WhenICanSeeAWarningMessageForUsingAlreadyUsedVatNumber()
        {
            CurrentPage.As<RegistrationPage>().ErrorMessageDisplayedForUsingSameVATNumber();
        }


        [Then(@"I should see an error message due to an invalid tax code")]
        [Then(@"I should see an error message due to an invalid tax code or codice fiscale")]
        public void ThenIShouldSeeAnErrorMessageOnTheCodiceFiscaleField()
        {
            CurrentPage.As<RegistrationConfirmationPage>().InvalidTaxCodeErrorMessageDisplayed();
        }
        [Then(@"I should see an error message  due to missing mandatory tax code field")]
        public void ThenIShouldSeeAnErrorMessageDueToMissingMandatoryTaxCodeField()
        {
            CurrentPage.As<RegistrationPage>().ErrorMessageDisplayedMissingVatNumber();
        }
        [Then(@"I should see an error message due to an invalid VAT number or Numero partita IVA")]
        public void ThenIShouldSeeAnErrorMessageOnTheNumeroPartitaIvaField()
        {
            CurrentPage.As<RegistrationConfirmationPage>().InvalidTaxCodeErrorMessageDisplayed();
        }


        [When(@"I fill in the registration information using a maximum length email address")]
        public void WhenIFillInTheRegistrationInformationUsingAMaxLengthEmailAddress(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<RegistrationPage>().PopulateFirstNameTextBox(form.FirstName);
            CurrentPage.As<RegistrationPage>().PopulateLastNameTextBox(form.LastName);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(form.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(form.Password);
            WhenIEnterAValidMaxLengthEmailAddress(string.Empty); // Auto Generates with an empty string
        }

        [Then(@"I fill in the creative center registration information using a valid email address")]
        public void WhenIFillInTheCcRegistrationInformationUsingAValidEmailAddress(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<HomePage>().PopulateCCFirstNameTextBox(form.FirstName);
            CurrentPage.As<HomePage>().PopulateCCLastNameTextBox(form.LastName);
            CurrentPage.As<HomePage>().PopulateCCPasswordTextBox(form.Password);
            CurrentPage.As<HomePage>().PopulateCCConfirmPasswordTextBox(form.Password);
            WhenIEnterAValidCCEmailAddress(string.Empty); // Auto Generates with an empty string
        }

        [When(@"I fill in the registration information excluding email address")]
        public void WhenIFillInTheRegistrationInformationExcludingEmailAddress(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<RegistrationPage>().PopulateFirstNameTextBox(form.FirstName);
            CurrentPage.As<RegistrationPage>().PopulateLastNameTextBox(form.LastName);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(form.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(form.Password);
        }

        [When(@"I fill in the creative center registration information excluding email address")]
        public void WhenIFillInTheCcRegistrationInformationExcludingEmailAddress(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<HomePage>().PopulateCCFirstNameTextBox(form.FirstName);
            CurrentPage.As<HomePage>().PopulateCCLastNameTextBox(form.LastName);
            CurrentPage.As<HomePage>().PopulateCCPasswordTextBox(form.Password);
            CurrentPage.As<HomePage>().PopulateCCConfirmPasswordTextBox(form.Password);
        }

        [When(@"I press tab in the email address field")]
        public void WhenIPressTabInTheEmailAddressField()
        {
            CurrentPage.As<RegistrationPage>().EmptyEmailAddressTextBox();
        }

        [When(@"I press tab in the creative center email address field")]
        public void WhenIPressTabInTheCcEmailAddressField()
        {
            CurrentPage.As<HomePage>().EmptyCcEmailAddressTextBox();
        }

        [When(@"I press tab in the password field")]
        public void WhenIPressTabInThePasswordField()
        {
            CurrentPage.As<RegistrationPage>().EmptyPasswordTextBox();
        }

        [When(@"I press tab in the creative center password field")]
        public void WhenIPressTabInCcThePasswordField()
        {
            CurrentPage.As<HomePage>().EmptyCcPasswordTextBox();
        }

        [When(@"I press tab in the first name field")]
        public void WhenIPressTabInTheFirstNameField()
        {
            CurrentPage.As<RegistrationPage>().EmptyFirstNameTextBox();
        }

        [When(@"I press tab in the creative center first name field")]
        public void WhenIPressTabInCcTheFirstNameField()
        {
            CurrentPage.As<HomePage>().EmptyCcFirstNameTextBox();
        }

        [When(@"I press tab in the last name field")]
        public void WhenIPressTabInTheLastNameField()
        {
            CurrentPage.As<RegistrationPage>().EmptyLastNameTextBox();
        }

        [When(@"I press tab in the creative center last name field")]
        public void WhenIPressTabInTheCcLastNameField()
        {
            CurrentPage.As<HomePage>().EmptyCcLastNameTextBox();
        }

        [When(@"I press tab in the company name field")]
        public void WhenIPressTabInTheCompanyNameField()
        {
            CurrentPage.As<RegistrationPage>().EmptyCompanyNameTextBox();
        }

        [When(@"I press tab in the creative center company name field")]
        public void WhenIPressTabInTheCcCompanyNameField()
        {
            CurrentPage.As<HomePage>().EmptyCcCompanyNameTextBox();
        }

        [When(@"I press tab in the business sector field")]
        public void WhenIPressTabInTheBusinessSectorField()
        {
            CurrentPage.As<RegistrationPage>().EmptyBusinessSectorTextBox();
        }

        [When(@"I press tab in the creative center business sector field")]
        public void WhenIPressTabInTheCcBusinessSectorField()
        {
            CurrentPage.As<HomePage>().EmptyCcBusinessSectorTextBox();
        }

        [Then(@"If I sign back into Brother Online ""(.*)"" using the same credentials")]
        [When(@"I sign back into Brother Online ""(.*)"" using the same credentials")]
        public void ThenIfISignBackIntoBrotherOnlineUsingTheSameCredentials(string country)
        {
            NextPage = CurrentPage.As<HomePage>().ClickSignInCreateAccountButton();
            CurrentPage.As<RegistrationPage>().DoHaveAnAccountOption();
            CurrentPage.As<RegistrationPage>().PopulateEmailAddressTextBox(Email.RegistrationEmailAddress);
            CurrentPage.As<RegistrationPage>().PopulatePassword(Helper.Password);
            WhenIClickOnSignIn(country);
        }

        [Then(@"I can sign back into Brother Online ""(.*)"" using the updated credentials")]
        public void ThenICanThenSignBackIntoBrotherOnlineUsingTheUpdatedCredentials(string country)
        {
            CurrentPage.As<RegistrationPage>().DoHaveAnAccountOption();
            CurrentPage.As<RegistrationPage>().PopulateEmailAddressTextBox(Email.RegistrationEmailAddress);
            CurrentPage.As<RegistrationPage>().PopulatePassword(Helper.Password);
            WhenIClickOnSignIn(country);
        }

        [When(@"I declare that I do not use this account for business")]
        public void WhenIDeclareThatIDoNotUseThisAccountForBusiness()
        {
            CurrentPage.As<RegistrationPage>().DoNotUseAccountForBusiness();
        }

        [When(@"I declare that I do not use this account for business on my account page")]
        public void WhenIDeclareThatIDoNotUseThisAccountForBusinessOnMyAccountPage()
        {
            CurrentPage.As<BusinessDetailsPage>().DoNotUseAccountForBusiness();
        }

        [When(@"I add my ""(.*)""")]
        [When(@"I add my company name as ""(.*)""")]
        public void WhenIAddMyCompanyNameAs(string companyName)
        {
            CurrentPage.As<RegistrationPage>().PopulateCompanyNameTextBox(companyName);
        }

        [Then(@"I add my company name into creative center as ""(.*)""")]
        public void WhenIAddMyCompanyNameIntoCcAs(string companyName)
        {
            CurrentPage.As<HomePage>().PopulateCcCompanyNameTextBox(companyName);
        }

        [When(@"I add my company name as ""(.*)"" on Business Details page")]
        public void WhenIAddMyCompanyNameAsOnBusinessDetailsPage(string companyName)
        {
            CurrentPage.As<BusinessDetailsPage>().PopulateCompanyNameTextBox(companyName);
        }

        [When(@"I add my company VAT number as ""(.*)""")]
        public void WhenIAddMyCompanyVatNumberAs(string vatNumber)
        {
            CurrentPage.As<RegistrationPage>().PopulateVatNumberTextBox(vatNumber);
        }

        [When(@"I add my company VAT number as ""(.*)"" on Business Details Page")]
        public void WhenIAddMyCompanyVatNumberAsOnBusinessDetailsPage(string vatNumber)
        {
            CurrentPage.As<BusinessDetailsPage>().PopulateVatNumberTextBox(vatNumber);
        }

        [When(@"I select my ""(.*)""")]
        [When(@"I select my Business Sector as ""(.*)""")]
        public void WhenISelectMyBusinessSectorAs(string businessSector)
        {
            CurrentPage.As<RegistrationPage>().PopulateBusinessSectorDropDown(businessSector);
        }
        [When(@"I add my company name ""(.*)"" on Business Details page")]
        public void WhenIAddMyCompanyNameOnBusinessDetailsPage(string companyName)
        {
            CurrentPage.As<BusinessDetailsPage>().PopulateCompanyNameTxtBox(companyName);
        }

        [When(@"I add my company VAT number ""(.*)"" on Business Details Page")]
        public void WhenIAddMyCompanyVATNumberOnBusinessDetailsPage(string vatNumber)
        {
           CurrentPage.As<BusinessDetailsPage>().PopulateVatNumberTxtBox(vatNumber);
        }

        [When(@"I select my Business Sector ""(.*)"" on Business Details Page")]
        public void WhenISelectMyBusinessSectorOnBusinessDetailsPage(string businessSector)
        {
            CurrentPage.As<BusinessDetailsPage>().PopulateBusinessSectorDropDownList(businessSector);
        }

        [When(@"I select number of Employees ""(.*)"" on Business Details Page")]
        public void WhenISelectNumberOfEmployeesOnBusinessDetailsPage(string numberEmployees)
        {
           CurrentPage.As<BusinessDetailsPage>().PopulateEmployeeCountDropDownList(numberEmployees);
        }

        [Then(@"I select my Business Sector on creative center as ""(.*)""")]
        public void WhenISelectMyBusinessSectorOnCcAs(string ccbusinessSector)
        {
            CurrentPage.As<HomePage>().PopulateCcBusinessSectorDropDown(ccbusinessSector);
        }

        [When(@"I select my Business Sector as ""(.*)"" on Business Details Page")]
        public void WhenISelectMyBusinessSectorAsOnBusinessDetailsPage(string businessSector)
        {
            CurrentPage.As<BusinessDetailsPage>().PopulateBusinessSectorDropDown(businessSector);
        }

        [When(@"I select (.*) - (.*)")]
        [When(@"I select number of Employees as ""(.*)""")]
        public void WhenISelectNumberOfEmployeesAs(string numberOfEmployees)
        {
            CurrentPage.As<RegistrationPage>().PopulateEmployeeCountDropDown(numberOfEmployees);
        }

        [Then(@"I select number of Employees on creative center as ""(.*)""")]
        public void WhenISelectNumberOfCcEmployeesAs(string numberOfEmployees)
        {
            CurrentPage.As<HomePage>().PopulateCcEmployeeCountDropDown(numberOfEmployees);
        }

        [When(@"I select number of Employees as ""(.*)"" on Business Details Page")]
        public void WhenISelectNumberOfEmployeesAsOnBusinessDetailsPage(string numberOfEmployees)
        {
            CurrentPage.As<BusinessDetailsPage>().PopulateEmployeeCountDropDown(numberOfEmployees);
        }

        [When(@"I declare that I do use this account for business")]
        public void WhenIDeclareThatIDoUseThisAccountForBusiness()
        {
            CurrentPage.As<RegistrationPage>().UseAccountForBusiness();
        }

        [When(@"I declare that I do use this account for business on my account page")]
        public void WhenIDeclareThatIDoUseThisAccountForBusinessOnMyAccountPage()
        {
            CurrentPage.As<BusinessDetailsPage>().UseAccountForBusiness();
        }

        [When(@"I have Agreed to the Terms and Conditions")]
        public void WhenIHaveAgreedToTheTermsAndConditions()
        {
            CurrentPage.As<RegistrationPage>().CheckTermsAndConditions();
        }

        [When(@"I have Agreed to the Terms and Conditions for Italy")]
        public void WhenIHaveAgreedToTheTermsAndConditionsForItaly()
        {
            CurrentPage.As<RegistrationPage>().CheckTermsAndConditionsForItaly();
        }

        [When(@"I press Create Your Account")]
        public void WhenIPressCreateYourAccount()
        {
            NextPage = CurrentPage.As<RegistrationPage>().ClickCreateAccountButton();
        }

        [When(@"I press create account button")]
        public void WhenIPressCreateAccountButton()
        {
            CurrentPage.As<RegistrationPage>().ClickCreateAccountButton();
        }

        [When(@"I press create account button to continue checkout")]
        public void WhenIPressCreateAccountButtonToContinueCheckout()
        {
            NextPage = CurrentPage.As<RegistrationPage>().ClickCreateAccountButtonToCheckout();
        }

        [Then(@"I should see my account confirmation page")]
        public void ThenIShouldSeeMyAccountConfirmationScreen()
        {
            CurrentPage.As<RegistrationConfirmationPage>().IsGoBackButtonAvailable();
        }

        [Then(@"I should be able to log into ""(.*)"" Brother Online using my account details")]
        public void ThenIShouldBeAbleToLogIntoBrotherOnlineUsingMyAccountDetails(string country)
        {
            // Check for validation warning or confirmation message 
            //***NOTE: For some reason on Team City, PhantomJS surpresses (or appears to surpress) the validation message
//            TestCheck.AssertIsEqual(true, CurrentPage.As<RegistrationPage>().IsAccountValidationSuccessMessagePresent(5, 5),
//                "Account validation success message");
            TestCheck.AssertIsNotEqual(true, CurrentPage.As<RegistrationPage>().IsWarningBarPresent(0, 5),
                "Warning Bar - account validation");

            WhenIAmRedirectedToTheBrotherLoginRegisterPage();
            WhenIEnterAValidEmailAddress(Email.RegistrationEmailAddress);
            WhenIEnterAValidPassword(Helper.Password);
            WhenIClickOnSignIn(country);
        }
        // Added steps
        [Then(@"I should be able to log into ""(.*)"" and ""(.*)"" Brother site using my account details")]
        public void ThenIShouldBeAbleToLogIntoAndBrotherSiteUsingMyAccountDetails(string web, string country)
        {
            TestCheck.AssertIsNotEqual(true, CurrentPage.As<RegistrationPage>().IsWarningBarPresent(0, 5),
              "Warning Bar - account validation");

            WhenIAmRedirectedToTheBrotherLoginRegisterPage();
            WhenIEnterAValidEmailAddress(Email.RegistrationEmailAddress);
            WhenIEnterAValidPassword(Helper.Password);
            WhenIClickOnSignIn(country);
        }

        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            CurrentPage.As<WelcomeBackPage>().IsSignOutButtonDisplayed();
        } 
        [Then(@"I should be able to log into ""(.*)"" Brother Online using my creative center account details")]
        public void ThenIShouldBeAbleToLogIntoBrotherOnlineUsingMyCreativeCenterAccountDetails(string country)
        {

            //WhenIAmRedirectedToTheBrotherLoginRegisterPage();
            WhenIEnterAValidCCAccountEmailAddress(Email.RegistrationEmailAddress);
            WhenIEnterAValidCcPassword(Helper.Password);
            WhenIClickOnSignInWithCCCredentials(country);
        }

        [Then(
            @"I should be able to log into ""(.*)"" Brother Online using my max length username and password account details"
            )]
        public void ThenIShouldBeAbleToLogIntoBrotherOnlineUsingMyMaxUsernameAndPasswordAccountDetails(string country)
        {

            //WhenIAmRedirectedToTheBrotherLoginRegisterPage();
            WhenIEnterAValidEmailAddress(Email.RegistrationEmailAddress);
            WhenIEnterAValidMaxPassword();
            WhenIClickOnSignIn(country);
        }

        [Then(@"I should be able to successfully log into brother online")]
        public void ThenIShouldBeAbleToSuccessfullyLogIntoBrotherOnline()
        {
            TestCheck.AssertIsNotEqual(true, CurrentPage.As<RegistrationPage>().IsWarningBarPresent(0, 5),
                "Warning Bar - account validation");
        }

        [Given(@"I already have a set of Brother Online ""(.*)"" account credentials")]
        public void GivenIAlreadyHaveASetOfBrotherOnlineAccountCredentials(string country)
        {
            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BrotherOnlineBaseUrl, "");
        }

        [When(@"I click on Create Account for ""(.*)""")]
        [When(@"I click on Sign In / Create An Account for ""(.*)""")]
        public void WhenIClickOnSignInCreateAnAccount(string country)
        {
            if (Helper.CountryIsUsingAtYourSideLogin(country))
            {
                CurrentPage.As<AtYourSideHomePage>().IsMyAccountLinkAvailable();
                NextPage = CurrentPage.As<AtYourSideHomePage>().ClickMyAccountLink();
            }
            else
            {
                CurrentPage.As<HomePage>().IsSignInCreateAccountButtonAvailable();
                NextPage = CurrentPage.As<HomePage>().ClickSignInCreateAccountButton();                
            }

        }
        
        //Web1-Steps

        [Given(@"I navigate to BOL ""(.*)"" for ""(.*)""")]
        public void GivenINavigateToBOLFor(string web, string country)
        {
            Helper.SetCountry(country);
            var title = HomePage.WelcomePageCountryTitle(country);
            CurrentPage = BasePage.LoadWebBoxes(CurrentDriver, web, title);
            NextPage = CurrentPage.As<HomePage>().ClickSignInCreateAccountButton();
           
        }
        [Given(@"I navigate to  ""(.*)"" for ""(.*)""")]
        public void GivenINavigateToFor(string web, string country)
        {
            Helper.SetCountry(country);
            var title = HomePage.WelcomePageCountryTitle(country);
            CurrentPage = BasePage.LoadWebBoxes(CurrentDriver, web, title);
            
        }

        [When(@"I click on ""(.*)"" Sign In")]
        public void WhenIClickOnSignIn(string country)
        {
            NextPage = CurrentPage.As<RegistrationPage>().ClickSignInButton();
        }

        [When(@"I press sign in with invalid details")]
        public void WhenIPressSignInWithInvalidDetails()
        {
            NextPage = CurrentPage.As<RegistrationPage>().ClickSignInWithInvalidDetails();
        }

        [When(@"I press sign in")]
        public void WhenIPressSignIn()
        {
            NextPage = CurrentPage.As<RegistrationPage>().ClickSignInButton();
        }

        [When(@"I press the creative center sign in with invalid details")]
        [When(@"I press the creative center sign in")]
        public void WhenIPressCcSignInWithInvalidDetails()
        {
            CurrentPage.As<HomePage>().ClickCcSignInWithInvalidDetails();
        }

        [When(@"I have entered a valid AutoGenerated email address")]
        public void WhenIHaveEnteredAValidAutoGeneratedEmailAddress()
        {
            CurrentPage.As<RegistrationPage>().PopulateEmailAddressTextBox(string.Empty);
        }

        [When(@"I enter an email address containing ""(.*)""")]
        public void WhenIEnterAnEmailAddressContaining(string emailAddress)
        {
            CurrentPage.As<RegistrationPage>().PopulateEmailAddressTextBox(emailAddress);
        }
        [When(@"I fill in email as ""(.*)""")]
        public void WhenIFillInEmailAs(string emailAddress)
        {
        
        CurrentPage.As<RegistrationPage>().PopulateEmailAddress1TextBox(emailAddress);
        
        }
        [When(@"I fill in password as ""(.*)""")]
        public void WhenIFillInPasswordAs(string password)
        {
            CurrentPage.As<RegistrationPage>().PopulatePassword1TextBox(password);
        }


        [When(@"I enter a creative center email address containing ""(.*)""")]
        public void WhenIEnterCcEmailAddressContaining(string emailAddress)
        {
            CurrentPage.As<HomePage>().PopulateCcEmailAddressTextBox(emailAddress);
        }

        [When(@"I enter the password containing ""(.*)""")]
        public void WhenIEnterThePasswordContaining(string password)
        {
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(password);
        }

        [When(@"I enter the different password in the confirm password field containing ""(.*)"" and press tab")]
        public void WhenIEnterTheDifferentPasswordInTheConfirmPasswordFieldContainingAndPressTab(string confirmpassword)
        {
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(confirmpassword);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(Keys.Tab);
        }
      
        [When(@"I enter the different confirmed password ""(.*)""")]
        public void WhenIEnterTheDifferentConfirmedPassword(string confirmpassword)
        {
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(confirmpassword);
        }

        [When(
            @"I enter the different password in the creative center confirm password field containing ""(.*)"" and press tab"
            )]
        public void WhenIEnterTheDifferentPasswordInTheCcConfirmPasswordFieldContainingAndPressTab(
            string confirmpassword)
        {
            CurrentPage.As<HomePage>().PopulateConfirmPasswordCcTextBox(confirmpassword);
            CurrentPage.As<HomePage>().PopulateConfirmPasswordCcTextBox(Keys.Tab);
        }

        [Then(@"I should refresh the current page to clear all error messages")]
        [Then(@"I refresh the current page")]
        [Then(@"I refresh the current page again")]
        public void ThenIShouldRefreshTheCurrentPageToClearAllErrorMessages()
        {

            CurrentDriver.Navigate().Refresh();
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            CurrentPage.As<RegistrationPage>().IsErrorMessageDisplayed();
        }

        [Then(@"I should see an error message on the creative center email field")]
        public void ThenIShouldSeeAnErrorMessageOnCcEmail()
        {
            CurrentPage.As<HomePage>().IsCcEmailErrorMessageDisplayed();
        }

        [Then(@"I should see an error message on the password field")]
        public void ThenIShouldSeeAnErrorMessageOnThePasswordField()
        {
            CurrentPage.As<RegistrationPage>().PasswordErrorMessageDisplayed();
        }

        [Then(@"I should see an error message on the creative center password field")]
        public void ThenIShouldSeeAnErrorMessageOnCcThePasswordField()
        {
            CurrentPage.As<HomePage>().PasswordCcErrorMessageDisplayed();
        }

        [Then(@"I should see an error message on the first name field")]
        public void ThenIShouldSeeAnErrorMessageOnTheFirstnameField()
        {
            CurrentPage.As<RegistrationPage>().FirstNameErrorMessage();
        }

        [Then(@"I should see an error message on the creative center first name field")]
        public void ThenIShouldSeeAnErrorMessageOnTheCcFirstnameField()
        {
            CurrentPage.As<HomePage>().FirstNameCcErrorMessageDisplayed();
        }

        [Then(@"I should see an error message on the last name field")]
        public void ThenIShouldSeeAnErrorMessageOnTheLastnameField()
        {
            CurrentPage.As<RegistrationPage>().LastNameErrorMessage();
        }

        [Then(@"I should see an error message on the creative center last name field")]
        public void ThenIShouldSeeAnErrorMessageOnCcTheLastnameField()
        {
            CurrentPage.As<HomePage>().LastNameCcErrorMessageDisplayed();
        }

        [Then(@"I should see an error message on the company name field")]
        public void ThenIShouldSeeAnErrorMessageOnTheCompanynameField()
        {
            CurrentPage.As<RegistrationPage>().CompanyNameErrorMessage();
        }

        [Then(@"I should see an error message on the creative center company name field")]
        public void ThenIShouldSeeAnErrorMessageOnTheCcCompanynameField()
        {
            CurrentPage.As<HomePage>().CompanyNameCcErrorMessage();
        }

        [Then(@"I should see an error message on the business sector field")]
        public void ThenIShouldSeeAnErrorMessageOnTheBusinessSectorField()
        {
            CurrentPage.As<RegistrationPage>().BusinessSectorErrorMessage();
        }

        [Then(@"I should see an error message on the creative center business sector field")]
        public void ThenIShouldSeeAnErrorMessageOnTheCcBusinessSectorField()
        {
            CurrentPage.As<HomePage>().BusinessSectorCcErrorMessage();
        }

        [Then(@"I should get an error message displayed on the Terms and Conditions")]
        public void ThenIShouldGetAnErrorMessageDisplayedOnTheTermsAndConditions()
        {
            CurrentPage.As<RegistrationPage>().TermsAndConditionsErrorMessageDisplayed();
        }

        [Then(@"I should get an error message displayed on the creative center Terms and Conditions")]
        public void ThenIShouldGetAnErrorMessageDisplayedOnTheCcTermsAndConditions()
        {
            CurrentPage.As<HomePage>().TermsAndConditionsCcErrorMessageDisplayed();
        }

        [Then(@"I should get an error message displayed on the creative center confirm password field")]
        public void ThenIShouldGetAnErrorMessageDisplayedOnTheCcConfirmPwField()
        {
            CurrentPage.As<HomePage>().ConfirmPWCcErrorMessageDisplayed();
        }

        [Then(@"I should see an error message on the Confirm password field")]
        public void ThenIShouldSeeAnErrorMessageOnTheConfirmPasswordField()
        {
            CurrentPage.As<RegistrationPage>().ConfirmPasswordErrorMessageDisplayed();
        }

        [Then(@"I should see the duplicate email error message preventing account creation")]
        public void ThenIShouldSeeDuplicateEmailErrorMessage()
        {
            CurrentPage.As<RegistrationPage>().DuplicateEmailErrorMessageDisplayed();
        }

        [Then(@"I should see the creative center duplicate email error message preventing account creation")]
        public void ThenIShouldSeeCcDuplicateEmailErrorMessage()
        {
            CurrentPage.As<HomePage>().DuplicateCcEmailErrorMessageDisplayed();
        }

        [Then(@"I should see the invalid credentials error message preventing login to brother online")]
        public void ThenIShouldSeeInvalidCredentialsErrorMessage()
        {
            CurrentPage.As<RegistrationPage>().InvalidCredentialsErrorMessageDisplayed();
        }

        [Then(@"I should see the invalid credentials error message preventing login to creative center")]
        public void ThenIShouldSeeInvalidCredentialsCcErrorMessage()
        {
            CurrentPage.As<HomePage>().InvalidCredentialsCcErrorMessageDisplayed();
        }

        [When(@"I enter a valid Email Address ""(.*)""")]
        public void WhenIEnterAValidEmailAddress(string validEmailAddress)
        {
            if (Helper.CurrentCountryIsUsingAtYourSideLogin())
            {
                CurrentPage.As<SignInAtYourSidePage>().PopulateEmailAddressTextBox(validEmailAddress);
                return;
            }
            CurrentPage.As<RegistrationPage>().PopulateEmailAddressTextBox(validEmailAddress);
        }
        [When(@"I enter a valid creative center Email Address ""(.*)""")]
        public void WhenIEnterAValidCCAccountEmailAddress(string validEmailAddress)
        {
            CurrentPage.As<HomePage>().PopulateEmailAddressTextBoxWithValidCCEmail(validEmailAddress);
        }
        [When(@"I fill in  valid NumerodeContribuinte as ""(.*)""")]
        public void WhenIFillInValidNumerodeContribuinteAs(string numerodeContribuinte)
        {

            CurrentPage.As<RegistrationPage>().PopulatePersonalNiNumberPortugalTextBox(numerodeContribuinte);

        }

        [When(@"I enter a valid creative center Password ""(.*)""")]
        public void WhenIEnterAValidCCPassword(string validPassword)
        {
            CurrentPage.As<HomePage>().PopulatePasswordWithCCCredentials(validPassword);
        }

        [When(@"I click on ""(.*)"" Sign In")]
        public void WhenIClickOnSignInWithCCCredentials(string country)
        {
            CurrentPage.As<HomePage>().ClickSignInButtonWithCCCredentials();
        }

        [When(@"I enter a valid maximum length Email Address ""(.*)""")]
        public void WhenIEnterAValidMaxLengthEmailAddress(string validEmailAddress)
        {
            CurrentPage.As<RegistrationPage>().PopulateEmailAddressTextBoxWithMaxLengthEmail(validEmailAddress);
        }

        [When(@"I enter a valid Email Address for creative center ""(.*)""")]
        public void WhenIEnterAValidCCEmailAddress(string validEmailAddress)
        {
            CurrentPage.As<HomePage>().PopulateEmailAddressTextBoxWithValidCCEmail(validEmailAddress);
        }

        [When(@"I enter a valid Password ""(.*)""")]
        public void WhenIEnterAValidPassword(string validPassword)
        {
            if (Helper.CurrentCountryIsUsingAtYourSideLogin())
            {
                CurrentPage.As<SignInAtYourSidePage>().PopulatePassword(validPassword);
                return;
            }
            CurrentPage.As<RegistrationPage>().PopulatePassword(validPassword);
        }

        [When(@"I enter a valid Password for creative center ""(.*)""")]
        public void WhenIEnterAValidCcPassword(string validPassword)
        {
            CurrentPage.As<HomePage>().PopulateWithCcPassword(validPassword);
        }

        [When(@"I enter a new Password for creative center ""(.*)""")]
        public void WhenIEnterANewCcPassword(string newPassword)
        {
            CurrentPage.As<HomePage>().PopulateWithNewCcPassword(newPassword);
        }

        [When(@"I enter a valid max Password ""(.*)""")]
        public void WhenIEnterAValidMaxPassword()
        {
            CurrentPage.As<RegistrationPage>().PopulateMaxPassword();
        }
        [Then(@"When I Click Go Back")]
        public void ThenWhenIClickGoBack()
        {
            NextPage = CurrentPage.As<RegistrationConfirmationPage>().ClickGoBackButton();
        }

        [When(@"I sign in as a ""(.*)"" from ""(.*)""")]
        public void WhenISignInAsA(string role, string country)
        {
            SignInAsARoleType(role, country);
            SignInButtonToAsARoleType(role);
        }

        private void SignInButtonToAsARoleType(string role)
        {
            if (!role.StartsWith("Cloud MPS"))
            {
                NextPage = CurrentPage.As<RegistrationPage>().ClickSignInButton();
                //NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToDealerDashboard();
            }
            else
            {
                if (Helper.CurrentCountryIsUsingAtYourSideLogin())
                {
                    NextPage = CurrentPage.As<SignInAtYourSidePage>().SignInButtonToMyAccount();
                    string contextBaseUrl;

                    try{
                        contextBaseUrl = ScenarioContext.Current["ContextBaseUrl"].ToString();
                    } catch(Exception ex)
                    {
                        contextBaseUrl = BasePage.BrotherOnlineBaseUrl;
                    }

                    switch (role)
                    {
                        case "Cloud MPS Dealer":
                            NextPage = CurrentPage.As<MyAccountAtYourSidePage>().RedirectToMpsDashboard<DealerDashBoardPage>(contextBaseUrl + DealerDashBoardPage.Url);
                            break;

                        case "Cloud MPS Local Office":
                            NextPage = CurrentPage.As<MyAccountAtYourSidePage>().RedirectToMpsDashboard<LocalOfficeAdminDashBoardPage>(contextBaseUrl + LocalOfficeAdminDashBoardPage.Url);
                            break;

                        case "Cloud MPS Bank":
                            NextPage = CurrentPage.As<MyAccountAtYourSidePage>().ClickAccessMpsDashboardButtonToDashboard<BankDashBoardPage>();
                            break;

                        case "Cloud MPS Local Office Approver":
                            NextPage = CurrentPage.As<MyAccountAtYourSidePage>().RedirectToMpsDashboard<LocalOfficeApproverDashBoardPage>(contextBaseUrl + LocalOfficeAdminDashBoardPage.Url);
                            break;

                        case "Cloud MPS Service Desk":
                            NextPage = CurrentPage.As<MyAccountAtYourSidePage>().ClickAccessMpsDashboardButtonToDashboard<ServiceDeskDashBoardPage>();
                            break;

                        case "Cloud MPS BIE Admin":
                            NextPage = CurrentPage.As<MyAccountAtYourSidePage>().ClickAccessMpsDashboardButtonToDashboard<BieAdminDashboardPage>();
                            break;
                        case "Cloud MPS Finance":
                            NextPage = CurrentPage.As<MyAccountAtYourSidePage>().ClickAccessMpsDashboardButtonToDashboard<FinanceDashboardPage>();
                            break;
                    }

                    return;
                }

                switch (role)
                {
                    case "Cloud MPS Dealer":
                        NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToDealerDashboard();
                        break;

                    case "Cloud MPS Local Office":
                        NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToLocalOfficeDashboard();
                        break;

                    case "Cloud MPS Bank":
                        NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToBankUser();
                        break;

                    case "Cloud MPS Local Office Approver":
                        NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToLocalOfficeApproverDashboard();
                        break;

                    case "Cloud MPS Service Desk Customer":
                    case "Cloud MPS Customer":
                        NextPage = CurrentPage.As<RegistrationPage>().ClickSignInButton();
                        break;

                    case "Cloud MPS Service Desk":
                        NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToServiceDeskDashBoardPage();
                        break;

                    case "Cloud MPS BIE Admin":
                        NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToBieAdminDashboardPage();
                        break;
                    case "Cloud MPS Finance":
                        NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToFinanceDashboardPage();
                        break;
                        

                }
            }
            
        }

        private void SignInAsARoleType(string role, string country)
        {
            string language = null;

            try
            {
                language = Selenium.Lib.Support.HelperClasses.SpecFlow.GetContext("BelgianLanguage");
            }
            catch (KeyNotFoundException)
            {
                
                //Do nothing
            }
            
            var pageUrl = CurrentDriver.Url;

            var username = role.Contains("Cloud") ? MpsUserLogins.Username(country, role, CurrentDriver) : role;
            var password = role.Contains("Cloud") ? MpsUserLogins.Password(role) : "P@$$w0rd"; //TestBUK1 P@$$w0rd

            if (role.StartsWith("MPS One"))
            {
                SignInAsMpsOneUser(role);
            }
            else if (language != null && (pageUrl.Contains("online65.be") && language.Contains("French") && username.Contains("Dealer3")))
            {
                WhenIEnterAValidEmailAddress("MPS-BBE-UAT-Dealer3@brother.co.uk");
                WhenIEnterAValidPassword("BEdealer3");
            }
            else if (language != null && (pageUrl.Contains("online65.ch") && language.Contains("Français") && username.Contains("Dealer3")))
            {
                WhenIEnterAValidEmailAddress("MPS-BSW-UAT-Dealer3@brother.co.uk");
                WhenIEnterAValidPassword("CHdealer3");
            }
            else
            {
                WhenIEnterAValidEmailAddress(username);
                WhenIEnterAValidPassword(password);
            }
            
        }


        private void SignInAsMpsOneUser(string role)
        {
            switch (role)
            {
                case "MPS One Dealer":
                {
                    WhenIEnterAValidEmailAddress("laies_es_qas@mailinator.com");
                    WhenIEnterAValidPassword("Welcome1");
                    break;

                }
                case "MPS One Customer":
                {
                    WhenIEnterAValidEmailAddress("esqacustomer2nd0604@mailinator.com");
                    WhenIEnterAValidPassword("Lucasis3");
                    break;
                }
                case "MPS One Sales Dealer":
                {
                    WhenIEnterAValidEmailAddress("es.sales.dealer@mailinator.com");
                    WhenIEnterAValidPassword("Rishav13");
                    break;
                }
            }
        }
    }
}
