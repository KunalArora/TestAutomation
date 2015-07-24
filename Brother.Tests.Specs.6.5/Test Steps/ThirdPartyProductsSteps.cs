using System;
using System.Threading;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.ThirdParty;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs
{
    [Binding]
    public class ThirdParty : BaseSteps
    {
        [Then(@"I can validate the correct order emails were received for ""(.*)"" as ""(.*)"" and as ""(.*)""")]
        public void ThenICanValidateTheCorrectOrderEmailsWereReceivedAsWasReceivedQty(string dealerEmailAddress, string orderEmail, string activationCodeEmail)
        {
            if (Email.CheckEmailPackage("GuerrillaEmail"))
            {
                LaunchGuerrillaEmail(dealerEmailAddress);

                CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail2(orderEmail);
                CurrentPage.As<GuerillaEmailConfirmationPage>().BackToInboxButtonClick();
                CurrentPage.As<GuerillaEmailConfirmationPage>().DeleteEmail("codes");
                CurrentPage.As<GuerillaEmailConfirmationPage>().BackToInboxButtonClick();
                CurrentPage.As<GuerillaEmailConfirmationPage>().DeleteEmailButtonClick();
                CurrentPage.As<GuerillaEmailConfirmationPage>().DeleteEmailButtonClick();
            }
            else
            {
                Helper.MsgOutput("Skipping Email Validation for this step");
            }
        }

        [When(@"I can validate an Order Confirmation email was received")]
        [Then(@"I can validate an Order Confirmation email was received")]
        [Given(@"I can validate an Order Confirmation email was received")]
        public void ThenICanValidateAnOrderConfirmationEmailWasReceived()
        {
            if (Email.CheckEmailPackage("GuerrillaEmail"))
            {
                LaunchGuerrillaEmail(string.Empty);
                CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail("order");
                CurrentPage.As<GuerillaEmailConfirmationPage>().CheckAllEmailLinks();
                CurrentPage.As<GuerillaEmailConfirmationPage>().DeleteEmail();
            }
            else
            {
                Helper.MsgOutput("Skipping Email Validation for this step");
            }
        }

        [When(@"I validate the new Customer Email changes via email")]
        [Then(@"I validate the new Customer Email changes via email")]
        public void WhenIValidateTheNewCustomerEmailChangesViaEmail()
        {
            if (Email.CheckEmailPackage("GuerrillaEmail"))
            {
                LaunchGuerrillaEmail(string.Empty);
                CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail("Update");
                CurrentPage.As<GuerillaEmailConfirmationPage>().CheckAllEmailLinks();
                NextPage = CurrentPage.As<GuerillaEmailConfirmationPage>().ValidateCustomerAccountDetailsChangeEmail();
            }
        }

        [When(@"I validate the new Business Email changes via email")]
        [Then(@"I validate the new Business Email changes via email")]
        public void WhenIValidateTheNewBusinessEmailChangesViaEmail()
        {
            if (Email.CheckEmailPackage("GuerrillaEmail"))
            {
                LaunchGuerrillaEmail(string.Empty);
                CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail("Update");
                CurrentPage.As<GuerillaEmailConfirmationPage>().CheckAllEmailLinks();
                NextPage = CurrentPage.As<GuerillaEmailConfirmationPage>().ValidateBusinessAccountDetailsChangeEmail();
            }
        }

        [Then(@"If I validate the new changes via email")]
        public void ThenIfIValidateTheNewChangesViaEmail()
        {
            if (Email.CheckEmailPackage("GuerrillaEmail"))
            {
                LaunchGuerrillaEmail(string.Empty);
                CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail("Update");
                CurrentPage.As<GuerillaEmailConfirmationPage>().CheckAllEmailLinks();
                NextPage = CurrentPage.As<GuerillaEmailConfirmationPage>().ValidateCustomerAccountDetailsChangeEmail();
            }
        }

        [Then(@"I can validate that an OmniJoin Plan Change email was received")]
        public void TheICanValidateThatAnOmniJoinPlanChangeEmailWasReceived()
        {
            if (Email.CheckEmailPackage("GuerrillaEmail"))
            {
                LaunchGuerrillaEmail(string.Empty);
                CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail("Important");
                CurrentPage.As<GuerillaEmailConfirmationPage>().CheckAllEmailLinks();
                NextPage = CurrentPage.As<GuerillaEmailConfirmationPage>().ValidateOmniJoinMyAccountPlanChangeEmail();
            }
        }

        [Then(@"If I Click the Reset Password Email Link")]
        public void ThenIfIClickTheResetPasswordEmailLink()
        {
            if (Email.CheckEmailPackage("GuerrillaEmail"))
            {
                LaunchGuerrillaEmail(string.Empty);
                CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail("Password");
                CurrentPage.As<GuerillaEmailConfirmationPage>().CheckAllEmailLinks();
                NextPage = CurrentPage.As<GuerillaEmailConfirmationPage>().ValidatePasswordResetEmail();
            }
            //else
            //{
            //    OnceIHaveValidatedAnEmailToken();
            //}
        }

        [Then(@"Once I have Validated a Free Trial confirmation Email was received")]
        public void ThenOnceIHaveValidatedAFreeTrialConfirmationEmailWasReceived()
        {
            if (Email.CheckEmailPackage("GuerrillaEmail"))
            {
                LaunchGuerrillaEmail(string.Empty);
                CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail("trial");
                CurrentPage.As<GuerillaEmailConfirmationPage>().CheckAllEmailLinks();
            }
            else
            {
                Helper.MsgOutput("Skipping Email Validation for this step");
            }
        }

        [Then(@"Once I have Validated an Email was received and verified my account")]
        public void ThenOnceIHaveValidatedAnEmailWasReceivedAndVerifiedMyAccount()
        {
            // NEED TO REMOVE THIS AND REPLACE WITH A DYNAMIC WAIT
            Thread.Sleep(new TimeSpan(0, 0, 0, 30)); //  deliberate wait for account to finalise before validation
            ValidateAccountEmail();
        }

        private void LaunchGuerrillaEmail(string inBox)
        {
            if (inBox == string.Empty)
            {
                CurrentPage = BasePage.LoadGuerrillaEmailInboxPage(CurrentDriver, "");
                CurrentPage.As<GuerillaEmailConfirmationPage>().ForgetMeButtonClick();
                CurrentPage.As<GuerillaEmailConfirmationPage>()
                    .SelectEmailDomain(Email.RegistrationEmailDomain.ToLower().Replace("@", string.Empty));
                CurrentPage.As<GuerillaEmailConfirmationPage>().SetEmailText(Email.RegistrationEmailAddress);
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

        private void ValidateAccountEmail()
        {
           if (Email.CheckEmailPackage("GuerrillaEmail"))
           {
                LaunchGuerrillaEmail(string.Empty);
                CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail("registration");
              //  CurrentPage.As<GuerillaEmailConfirmationPage>().CheckAllEmailLinks();
                NextPage = CurrentPage.As<GuerillaEmailConfirmationPage>().ValidateRegistrationEmail();
                TestCheck.AssertIsNotEqual(true, CurrentPage.As<RegistrationPage>().IsWarningBarPresent(2,5), "Warning Bar detected - Account could not be validated");
           }
        }

        [Then(@"Once I have Validated an Email Token")]
        public void OnceIHaveValidatedAnEmailToken()
        {
            CurrentPage = BasePage.LoadEmailConfirmationPage(CurrentDriver, BasePage.BaseUrl);
            CurrentPage.As<BrotherEmailConfirmationPage>().IsGetRegistrationLinkButtonAvailable();
            CurrentPage.As<BrotherEmailConfirmationPage>().EnterEmailToValidate(Email.RegistrationEmailAddress);
            CurrentPage.As<BrotherEmailConfirmationPage>().SelectLanguage(Helper.Locale);
            CurrentPage.As<BrotherEmailConfirmationPage>().ClickGetRegistrationLinkButton();
            CurrentPage.As<BrotherEmailConfirmationPage>().IsConfirmAccountHyperlinkAvailable();
            NextPage = CurrentPage.As<BrotherEmailConfirmationPage>().GetConfirmAccountHyperLink();
        }
    }
}
