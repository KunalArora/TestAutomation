using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline.Account
{
    [Binding]
    public class AccountManagementSteps : BaseSteps
    {
        [When(@"I click on OmniJoin home")]
        public void WhenIClickOnOmniJoinHome()
        {
            var menu = GlobalNavigationModule.GetProductNavigationMenu("OmniJoin");
            NextPage = GlobalNavigationModule.MyAccountMenuItemClick(CurrentDriver, menu);
        }

        [Given(@"I click on the Partner Portal menu option")]
        public void GivenIClickOnThePartnerPortalMenuOption()
        {
            var menu = GlobalNavigationModule.GetProductNavigationMenu("PartnerPortal");
            NextPage = GlobalNavigationModule.MyAccountMenuItemClick(CurrentDriver, menu);
        }

        [When(@"I click on the Partner Portal button")]
        public void WhenIClickOnThePartnerPortalButton()
        {
            var partnerPortalButton = GlobalNavigationModule.GetPartnerPortalInfoButton("OmniJoinDealerPortal", "PartnerPortal");
            NextPage = GlobalNavigationModule.PartnerPortalButtonClick(CurrentDriver, partnerPortalButton);
        }

        [Then(@"I can click on Manage Plan")]
        public void ThenICanClickOnManagePlan()
        {
            var managePlanButton = GlobalNavigationModule.GetMyAccountInfoButton("OmniJoin", "ManagePlan");
            NextPage = GlobalNavigationModule.ManageOmniJoinPlanButtonClick(CurrentDriver, managePlanButton);
        }


        [Given(@"I am logged into my Brother Online account")]
        [Then(@"I am redirected to the Welcome Back page")]
        [Given(@"I am redirected to the Welcome Back page")]
        public void GivenIAmRedirectedToTheWelcomeBackPage()
        {
            GlobalNavigationModule.IsSignOutLinkAvailable(CurrentDriver);
        }

        [Then(@"I can navigate back to Brother Online home page")]
        public void ThenICanNavigateBackToBrotherOnlineHomePage()
        {
            Then("If I navigate back to the Brother Online My Account page");
            NextPage = GlobalNavigationModule.BrotherOnlineGoHome(CurrentDriver);
        }

        [Then(@"If I navigate back to the Brother Online My Account page")]
        public void ThenIfINavigateBackToTheBrotherOnlineMyAccountPage()
        {
            var menu = GlobalNavigationModule.GetPrimaryNavigationMenuItem("MyAccount");
            NextPage = GlobalNavigationModule.MyAccountMenuItemClick(CurrentDriver, menu);
        }

		[When(@"I can sign out of Brother Online")]
        [When(@"I sign out of Cloud MPS")]
        [Given(@"I sign out of Cloud MPS")]
        [Then(@"I sign out of Cloud MPS")]
        [Then(@"I can sign out of Brother Online")]
        public void ThenIfISignOutOfBrotherOnline()
        {
            NextPage = GlobalNavigationModule.ClickSignOutLink(CurrentDriver);
        }

        [When(@"If I sign out of Brother Online")]
        [Then(@"If I sign out of Brother Online")]
        public void ThenICanSignOutOfBrotherOnline()
        {
            NextPage = GlobalNavigationModule.BrotherOnlineGoHome(CurrentDriver);
            GivenIAmRedirectedToTheWelcomeBackPage();
            NextPage = GlobalNavigationModule.ClickSignOutLink(CurrentDriver);
        }

        [Then(@"If I click on My Account menu")]
        public void ThenIfIClickOnMyAccountMenu()
        {
            GlobalNavigationModule.GetProductNavigationMenu("MyAccount").Click();
        }

        [Then(@"I click on My Personal Details")]
        public void ThenIClickOnMyPersonalDetails()
        {
            var personalDetailsButton = GlobalNavigationModule.GetMyAccountInfoButton("MyAccount", "PersonalDetails");
            NextPage = GlobalNavigationModule.PersonalDetailsButtonClick(CurrentDriver, personalDetailsButton);
        }

        [When(@"I click on Sign In Preferences")]
        public void WhenIClickOnSignInPreferences()
        {
            var signInDetailsButton = GlobalNavigationModule.GetMyAccountInfoButton("MyAccount", "Preferences");
            NextPage = GlobalNavigationModule.SignInPreferencesButtonClick(CurrentDriver, signInDetailsButton);
        }

        [When(@"I click on Sign In Details")]
        public void WhenIClickOnSignInDetails()
        {
            var signInDetailsMenu = GlobalNavigationModule.GetMyAccountMenuItem("SignInDetails");
            NextPage = GlobalNavigationModule.MySignInDetailsMenuOptionClick(CurrentDriver, signInDetailsMenu);
        }

        [Then(@"I can click on Payment Methods")]
        public void ThenICanClickOnPaymentMethods()
        {
            var paymentMethodsButton = GlobalNavigationModule.GetMyAccountMenuItem("PaymentMethods");
            NextPage = GlobalNavigationModule.PaymentMethodsMenuClick(CurrentDriver, paymentMethodsButton);
        }

        [Then(@"If I grant the user account the ""(.*)"" role")]
        public void ThenIfIGrantTheUserAccountTheRole(string userRole)
        {
            Utils.GrantUserRole(Email.RegistrationEmailAddress, userRole);
        }

        [When(@"I navigate to my account for ""(.*)""")]
        public void WhenINavigateToMyAccountFor(string country)
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToMyAccountPage(country);
        }

        [Then(@"If I enter the current password")]
        public void ThenIfIEnterTheCurrentPassword()
        {
            CurrentPage.As<MySignInDetailsPage>().EnterExistingPassword(Helper.Password);
        }

        [Then(@"I can validate the update was successful")]
        public void ThenICanValidateTheUpdateWasSuccessful()
        {
            CurrentPage.As<MySignInDetailsPage>().VerifyEmailAddressValue(Email.RegistrationEmailAddress);
        }

        [Then(@"If I enter a new email address ""(.*)""")]
        [When(@"If I enter a new email address ""(.*)""")]
        public void ThenIfIEnterANewEmailAddress(string emailAddressPrefix)
        {
            CurrentPage.As<MySignInDetailsPage>().EnterEmailAddress(string.Format("{0}{1}", emailAddressPrefix, Email.RegistrationEmailAddress));
        }

        [Then(@"If I enter the current password for email change")]
        [When(@"If I enter the current password for email change")]
        public void ThenIfIEnterTheCurrentPasswordForEmailChange()
        {
            CurrentPage.As<MySignInDetailsPage>().EnterExistingPasswordForEmailChange(Helper.Password);
        }
        
        [Then(@"I enter a new password of ""(.*)""")]
        public void ThenIEnterANewPasswordOf(string newPassword)
        {
            CurrentPage.As<MySignInDetailsPage>().EnterNewPassword(newPassword);
            CurrentPage.As<MySignInDetailsPage>().EnterNewPasswordToConfirm(newPassword);
            // Set new password so we can sign in again using the updated password
            Helper.Password = newPassword;
        }

        [Then(@"I click on Update Password")]
        [When(@"I click on Update Password")]
        public void ThenIClickOnUpdatePassword()
        {
            CurrentPage.As<MySignInDetailsPage>().ClickUpdatePasswordButton();
        }

        [Then(@"I click on Update details")]
        [When(@"I click on Update details")]
        public void ThenIClickOnUpdateDetails()
        {
            CurrentPage.As<MySignInDetailsPage>().ClickUpdateDetailsButton();
        }

        [Then(@"My password will be updated")]
        public void ThenMyPasswordWillBeUpdated()
        {
            CurrentPage.As<MySignInDetailsPage>().ValidateInformationMessageBarStatus(true);
        }

        [Then(@"I can verify the email change occurred")]
        public void CanVerifyTheEmailChangeOccurred()
        {
            CurrentPage.As<MySignInDetailsPage>().ValidateInformationMessageBarStatus(true);
        }
    }
}
