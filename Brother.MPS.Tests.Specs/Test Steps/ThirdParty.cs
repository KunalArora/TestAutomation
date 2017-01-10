using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.ThirdParty;
using Brother.Tests.Selenium.Lib.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs
{
    [Binding]
    public class ThirdParty : BaseSteps
    {
        [Then(@"I can validate an Order Confirmation email was received")]
        public void ThenICanValidateAnOrderConfirmationEmailWasReceived()
        {
            var currentWindow = CurrentDriver.CurrentWindowHandle;
            if (Email.CheckEmailPackage("MailinatorEmail"))
            {
                LaunchMailinator("order");
                CurrentPage.As<MailinatorEmailConfirmationPage>().DeleteEmailButtonClick();
                // Close driver used for mailinator
                WebDriver.ClearWebDriverPackage();
                // Switch back to original browser
                CurrentDriver.SwitchTo().Window(currentWindow);
            }
            else
            {
                Helper.MsgOutput("Skipping Email Validation for this step");
            }
        }

        [Then(@"Once I have Validated a Free Trial confirmation Email was received")]
        public void ThenOnceIHaveValidatedAFreeTrialConfirmationEmailWasReceived()
        {
            var currentWindow = CurrentDriver.CurrentWindowHandle;
            if (Email.CheckEmailPackage("MailinatorEmail"))
            {
                LaunchMailinator("trial");
                CurrentPage.As<MailinatorEmailConfirmationPage>().DeleteEmailButtonClick();

                // Close driver used for mailinator
                WebDriver.ClearWebDriverPackage();

                // Switch back to original browser
                CurrentDriver.SwitchTo().Window(currentWindow);
            }
            else
            {
                Helper.MsgOutput("Skipping Email Validation for this step");
            }
        }

        [Then(@"Once I have Validated an Email was received and verified my account")]
        public void ThenOnceIHaveValidatedAnEmailWasReceivedAndVerifiedMyAccount()
        {
            ValidateAccountEmail();
        }

        private void LaunchMailinator(string emailSubjectString)
        {
            //var newDriver = Helper.LaunchNewDriverWindow();

            // Validate the email was sent via Mailinator
            //CurrentPage = BasePage.LoadMailinatorEmailConfirmationPage(newDriver, "");
            CurrentPage = BasePage.LoadMailinatorEmailConfirmationPage(CurrentDriver, "");
            CurrentPage.As<MailinatorEmailConfirmationPage>().IsEmailItemlinkAvailable();
            CurrentPage.As<MailinatorEmailConfirmationPage>().ValidateEmailIsCorrect(emailSubjectString);
            CurrentPage.As<MailinatorEmailConfirmationPage>().ClickEmailLink();
            CurrentPage.As<MailinatorEmailConfirmationPage>().IsDeleteEmailButtonAvailable();
        }

        private void ValidateAccountEmail()
        {
            if (Email.CheckEmailPackage("MailinatorEmail"))
            {
                var currentWindow = CurrentDriver.CurrentWindowHandle;
                LaunchMailinator("registration");
                
                var verifyUrl = CurrentPage.As<MailinatorEmailConfirmationPage>().GetVerifyBolAccountUrl();
                CurrentPage.As<MailinatorEmailConfirmationPage>().DeleteEmailButtonClick();

                // Close driver used for mailinator
                WebDriver.ClearWebDriverPackage();

                // Switch back to original browser
                CurrentDriver.SwitchTo().Window(currentWindow);

                // Using the returned verification link, validate via Current Browser
                NextPage = BasePage.ValidateBrotherOnlineEmailConfirmationUrl(CurrentDriver, verifyUrl);
            }
            else
            {
                OnceIHaveValidatedAnEmailToken();
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
            NextPage = CurrentPage.As<BrotherEmailConfirmationPage>().ClickConfirmAccountHyperLink();
        }
    }
}
