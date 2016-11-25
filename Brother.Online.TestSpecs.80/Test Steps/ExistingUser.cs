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
        public void GivenIBrowseToTheForExistingUserSigninPage(string url)
        {
            CurrentPage = BasePage.LoadSignPage(CurrentDriver, url);
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
               CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail("ForgottenPassword");
               //  CurrentPage.As<GuerillaEmailConfirmationPage>().CheckAllEmailLinks();
               NextPage = CurrentPage.As<GuerillaEmailConfirmationPage>().ValidateForgottenPasswordEmail();
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



