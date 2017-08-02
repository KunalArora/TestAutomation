using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.BrotherOnline.ThirdParty;
using TechTalk.SpecFlow;

namespace Brother.Online.TestSpecs._80.Test_Steps
{  
    [Binding]
    public class ExistingUser : BaseSteps
    {
        [Given(@"I browse to the ""(.*)"" for existing user signin page")]
        //public void GivenIBrowseToTheForExistingUserSigninPage(string url)
        //{
           // CurrentPage = BasePage.LoadSignPage(CurrentDriver, url);
        //}
        [Given(@"I browse to ""(.*)"" for existing user signin page atyourside")]
        public void GivenIBrowseToForExistingUserSigninPageAtyourside(string url)
        {
            CurrentPage = BasePage.LoadAtyousideHomePage(CurrentDriver, url);
        }
        
        [Given(@"I click on existing customer log in option")]
        public void GivenIClickOnExistingCustomerLogInOption()
        {
           CurrentPage.As<SignInPage>().ClickExistingUserTab();
        }
        [When(@"I click on Forgot Password")]
        public void WhenIClickOnForgotPassword()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            CurrentPage.As<SignInPage>().ClickForgottenPasswordLink();
        }
        [Then(@"I enter an invalid email address as (.*)")]
        public void ThenIEnterAnInvalidEmailAddressAs(string emailaddress)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            CurrentPage.As<SignInPage>().PopulateInvalidEmailAddress(emailaddress);
        }
        [Then(@"I should see the Error Message activated and displaying an Error message")]
        public void ThenIShouldSeeTheErrorMessageActivatedAndDisplayingAnErrorMessage()
        {
            CurrentPage.As<SignInPage>().VerifyErrorMessageExist();
        }
        [Then(@"I enter an email address as ""(.*)""")]
        public void ThenIEnterAnEmailAddressAs(string emailaddress)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            CurrentPage.As<SignInPage>().PopulateValidEmailAddress(emailaddress);
        }
        [Then(@"I enter an email address as ""(.*)"" on existing customer page")]
        public void ThenIEnterAnEmailAddressAsOnExistingCustomerPage(string emailaddress)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            CurrentPage.As<SignInPage>().PopulateValidEmailAddressOnExistingPage(emailaddress);
        }

        [Then(@"I enter valid passowrd for the account ""(.*)""")]
        public void ThenIEnterValidPassowrdForTheAccount(string password)
        {
            CurrentPage.As<SignInPage>().PopulatePassword(password);
        }
        [Then(@"I click on SignIn button")]
        public void ThenIClickOnSignInButton()
        {
            NextPage = CurrentPage.As<SignInPage>().ClickSignInButton();
        }
        [Then(@"I have entered my product ""(.*)""")]
        public void ThenIHaveEnteredMyProduct(string serialnumber)
        {
            CurrentPage.As<ProductRegistrationPage>().PopulateSerialNumberTextBox(serialnumber);
        }
        [Then(@"clicked on Find Product Button")]
        public void ThenClickedOnFindProductButton()
        {
            CurrentPage.As<ProductRegistrationPage>().ClickFindProductButton();
        }
        [Then(@"I retreive data product id from Product Page")]
        public void ThenIRetreiveDataProductIdFromProductPage()
        {
            CurrentPage.As<ProductRegistrationPage>().RetreiveDataProductId();
        }
        [Then(@"I have entered ""(.*)""")]
        public void ThenIHaveEntered(string date)
        {
            CurrentPage.As<ProductRegistrationPage>().EnterProductDate(date);
        }
        [Then(@"I entered apply button")]
        public void ThenIEnteredApplyButton()
        {
            CurrentPage.As<ProductRegistrationPage>().ClickApplyButton();
        }
        [Then(@"I enter ""(.*)""")]
        public void ThenIEnter(string promocode)
        {
            CurrentPage.As<ProductRegistrationPage>().EnterPromoCode(promocode);
        }
        [Then(@"I click on add code button")]
        public void ThenIClickOnAddCodeButton()
        {
            CurrentPage.As<ProductRegistrationPage>().ClickAddCodeButton();
        }
        [Then(@"I click on continue button on brother product page")]
        public void ThenIClickOnContinueButtonOnBrotherProductPage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            NextPage = CurrentPage.As<ProductRegistrationPage>().ClickContinueButton();
        }
        [Then(@"I click on continue button on brother product page to go to address details page")]
        public void ThenIClickOnContinueButtonOnBrotherProductPageToGoToAddressDetailsPage()
        {
            NextPage = CurrentPage.As<ProductRegistrationPage>().ClickContinueButtonAdPage(); ;
        }
        
       [Then(@"I press send email button")]
        public void ThenIPressSendEmailButton()
        {
            CurrentPage.As<SignInPage>().ClickSendButton();
        }

       [Then(@"Once I have Validated ""(.*)"" was received and verified my account")]
       public void ThenOnceIHaveValidatedWasReceivedAndVerifiedMyAccount(string emailAddress)
       {
           Thread.Sleep(new TimeSpan(0, 0, 0, 10)); //  deliberate wait for account to finalise before validation
           ValidateAccountEmail(emailAddress);
       }

       private void ValidateAccountEmail(string emailID)
       {
           if (Email.CheckEmailPackage("GuerrillaEmail"))
           {
               LaunchGuerrillaEmail(emailID);
               CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail("Reset your password");
               //  CurrentPage.As<GuerillaEmailConfirmationPage>().CheckAllEmailLinks();
               //NextPage = CurrentPage.As<GuerillaEmailConfirmationPage>().ValidateForgottenPasswordEmail();
           }
       }
       private void LaunchGuerrillaEmail(string inBox)
       {
           inBox = @"123orderplacedukaccount@guerrillamail.com";
           if (inBox == string.Empty)
           {
               CurrentPage = BasePage.LoadGuerrillaEmailInboxPage(CurrentDriver, "");
               CurrentPage.As<GuerillaEmailConfirmationPage>().ForgetMeButtonClick();
               CurrentPage.As<GuerillaEmailConfirmationPage>()
                   .SelectEmailDomain(Email.RegistrationEmailDomain.ToLower().Replace("@", string.Empty));
               CurrentPage.As<GuerillaEmailConfirmationPage>().SetEmailText(Email.ForgottenPasswordEmailAddress);
               TestCheck.AssertIsEqual(true, CurrentPage.As<GuerillaEmailConfirmationPage>().DeleteGuerrillaWelcomeMail(),
                   "Unable to delete the Guerrilla Mail Welcome Message");
           }
           else
           {
               CurrentPage = BasePage.LoadGuerrillaEmailInboxPage(CurrentDriver, "");
               CurrentPage.As<GuerillaEmailConfirmationPage>().ForgetMeButtonClick();
               CurrentPage.As<GuerillaEmailConfirmationPage>()
                  .SelectEmailDomain(Email.RegistrationEmailDomain.ToLower().Replace("@", string.Empty));
               CurrentPage.As<GuerillaEmailConfirmationPage>().SetEmailText(inBox);
               TestCheck.AssertIsEqual(true, CurrentPage.As<GuerillaEmailConfirmationPage>().DeleteGuerrillaWelcomeMail(),
   "Unable to delete the Guerrilla Mail Welcome Message");
           }
       }
    }
}



