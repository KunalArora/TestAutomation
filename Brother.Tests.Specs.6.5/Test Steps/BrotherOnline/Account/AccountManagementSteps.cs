using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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

        [Then(@"I can navigate back to Brother Online home page with my creative center account")]
        public void ThenICanNavigateBackToBrotherOnlineHomePageWithCcAcc()
        {      
            CurrentPage.As<WelcomeBackPage>().BroOnlineHomeClick();    
        }


        [Then(@"If I go to My Account")]
        [Then(@"If I navigate back to the Brother Online My Account page")]
        public void ThenIfINavigateBackToTheBrotherOnlineMyAccountPage()
        {
            var menu = GlobalNavigationModule.GetPrimaryNavigationMenuItem("MyAccount");
            NextPage = GlobalNavigationModule.MyAccountMenuItemClick(CurrentDriver, menu);
            //NextPage = GlobalNavigationModule.MyAccountMenuItemClick(CurrentDriver);
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
            var menuMyAccount = GlobalNavigationModule.GetProductNavigationMenu("MyAccount");
            menuMyAccount.Click();
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
            //var paymentMethodsButton = GlobalNavigationModule.GetMyAccountMenuItem("PaymentMethods");
            //NextPage = GlobalNavigationModule.PaymentMethodsMenuClick(CurrentDriver, paymentMethodsButton);
            NextPage = GlobalNavigationModule.PaymentMethodsMenuClick(CurrentDriver);
        }

        [Then(@"I can click on Orders")]
        public void ThenICanClickOnOrders()
        {
           // var ordersButton = GlobalNavigationModule.GetMyAccountMenuItem("Orders");
            var ordersButton = CurrentPage.As<MyAccountPage>().GetMyOrdersMenuItem();
            NextPage = GlobalNavigationModule.OrdersMenuClick(CurrentDriver, ordersButton);
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
        [When(@"I clicked on Business Details")]
        public void WhenIClickedOnBusinessDetails()
        {
            var businessDetailsButton = GlobalNavigationModule.GetMyAccountMenuItem("BusinessDetails");
            NextPage = GlobalNavigationModule.BusinessDetailsMenuClick(CurrentDriver, businessDetailsButton);
        }

        [When(@"I clicked on Business Details whilst logged in with my creative center account")]
        public void WhenIClickedOnBusinessDetailsWhilstUsingCcAcc()
        {
            CurrentPage.As<WelcomeBackPage>().BusinessDetailsClick();
        }

        [When(@"I click on My Address")]
        public void WhenIClickOnMyAddress()
        {
            var myaddressdetailsButton = GlobalNavigationModule.GetMyAccountMenuItem("AddressDetails");
            NextPage = GlobalNavigationModule.MyAdressDetailsMenuOptionClick(CurrentDriver, myaddressdetailsButton);
        }

        [When(@"I am redirected to the Business Details Page")]
        public void WhenIAmRedirectedToTheBusinessDetailsPage()
        {
            CurrentPage.As<BusinessDetailsPage>().IsUpdateButtonAvailable();
        }

        [Then(@"I am redirected to the Business Details Page for my creative center account")]
        public void WhenIAmRedirectedToTheBusinessDetailsPageForCcAcc()
        {
            CurrentPage.As<WelcomeBackPage>().IsBusinessUpdateButtonAvailable();
        }

        [Then(@"I can see that use account for business is selected")]
        public void UseAccountForBusinessIsSelected()
        {
            CurrentPage.As<BusinessDetailsPage>().UseAccountForBusinessIsSelected();
        }

        [Then(@"I can see that use account for business is selected for creative center details")]
        public void UseAccountForBusinessIsSelectedForcc()
        {
            CurrentPage.As<WelcomeBackPage>().UseAccountForBusinessIsSelectedForCc();
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
            var newEmailAddress = string.Format("{0}{1}", emailAddressPrefix, Email.RegistrationEmailAddress);
            CurrentPage.As<MySignInDetailsPage>().EnterEmailAddress(newEmailAddress);
            Email.RegistrationEmailAddress = newEmailAddress;
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
        [When(@"I click on Update details on business details page")]
        public void WhenIClickOnUpdateDetailsOnBusinessDetailsPage()
        {
            CurrentPage.As<BusinessDetailsPage>().ClickUpdateButton();
        }
        [When(@"I click on Add a New Address Button")]
        public void WhenIClickOnAddANewAddressButton()
        {
            CurrentPage.As<MyAddressDetailsPage>().ClickonAddanewaddressButton();
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
        [Then(@"I can verify successfull update message appeared at the top")]
        public void ThenICanVerifySuccessfullUpdateMessageAppearedAtTheTop()
        {
            CurrentPage.As<BusinessDetailsPage>().ValidateInformationMessageBarStatus(true);
        }
        [When(@"I enter First Name containing (.*)")]
        public void WhenIEnterFirstNameContaining(string firstname)
        {
            CurrentPage.As<MyAccountPage>().PopulateFirstNameTextBox(firstname);
        }
        [When(@"I clear the first name field")]
        public void WhenIClearTheFirstNameField()
        {
            CurrentPage.As<MyAccountPage>().ClearFirstNameTextBox();
        }
        [Then(@"error message should appear on the first name field")]
        public void ThenErrorMessageShouldAppearOnTheFirstNameField()
        {
            CurrentPage.As<MyAccountPage>().FirstNameErrorMessageDisplayed();
        }
        [Then(@"I clear the last name field")]
        public void ThenIClearTheLastNameField()
        {
            CurrentPage.As<MyAccountPage>().ClearLastNameTextBox();
        }
        [Then(@"error mesage should appear on the last name field")]
        public void ThenErrorMesageShouldAppearOnTheLastNameField()
        {
            CurrentPage.As<MyAccountPage>().LastNameErrorMessageDisplayed();
        }
        [When(@"I enter the Last Name containing (.*)")]
        public void WhenIEnterTheLastNameContaining(string lastname)
        {
            CurrentPage.As<MyAccountPage>().PopulateLastNameTextBox(lastname);
        }
        [When(@"I click on update details")]
        public void WhenIClickOnUpdateDetails()
        {
            CurrentPage.As<MyAccountPage>().ClickUpdateDetailsButton();
        }
        [Then(@"my personal details should get updated")]
        public void ThenMyPersonalDetailsShouldGetUpdated()
        {
            CurrentPage.As<MyAccountPage>().ValidateInformationMessageBarStatus(true);
        }
        [When(@"I enter all the mandatory fields")]
        public void WhenIEnterAllTheMandatoryFields(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<MyAddressDetailsPage>().PopulateFirstNameTextBox(form.FirstName);
            CurrentPage.As<MyAddressDetailsPage>().PopulateLastNameTextBox(form.LastName);
            CurrentPage.As<MyAddressDetailsPage>().PopulatePostcodeTextBox(form.Postcode);
            CurrentPage.As<MyAddressDetailsPage>().PopulateHouseNumberTextBox(form.HouseNumber);
            CurrentPage.As<MyAddressDetailsPage>().PopulateHouseNameTextBox(form.HouseName);
            CurrentPage.As<MyAddressDetailsPage>().PopulateAddressLine1TextBox(form.Addressline1);
            CurrentPage.As<MyAddressDetailsPage>().PopulateAddressLine2TextBox(form.Addressline2);
            CurrentPage.As<MyAddressDetailsPage>().PopulateCityTownTextBox(form.City);
            CurrentPage.As<MyAddressDetailsPage>().PopulatePhoneTextBox(form.PhoneNumber); 
        }
        [When(@"I click on the save address button")]
        public void WhenIClickOnTheSaveAddressButton()
        {
            CurrentPage.As<MyAddressDetailsPage>().ClickOnSaveAddress();
        }
        [When(@"I click on Edit link")]
        public void WhenIClickOnEditLink()
        {
            CurrentPage.As<MyAddressDetailsPage>().ClickOnEditLink();
        }
        [When(@"I edit the ""(.*)""")]
        public void WhenIEditThe(string housenumber)
        {
            CurrentPage.As<MyAddressDetailsPage>().EditHouseNumberField(housenumber);
        }
        [When(@"I enter tab on the first name field")]
        public void WhenIEnterTabOnTheFirstNameField()
        {
            CurrentPage.As<MyAddressDetailsPage>().EmptyFirstNameTextBox(); 
        }
       [Then(@"I should see an error message on the first name field on my address page")]
       public void ThenIShouldSeeAnErrorMessageOnTheFirstNameFieldOnMyAddressPage()
       {
           CurrentPage.As<MyAddressDetailsPage>().FirstNameErrorMessageDisplayed();
       }
       [Then(@"I enter tab on last name field")]
       public void ThenIEnterTabOnLastNameField()
       {
           CurrentPage.As<MyAddressDetailsPage>().EmptyLastNameTextBox(); 
       }
       [Then(@"I should see an error message on Last name field on my address page")]
       public void ThenIShouldSeeAnErrorMessageOnLastNameFieldOnMyAddressPage()
       {
           CurrentPage.As<MyAddressDetailsPage>().LastNameErrorMessageDisplayed();
       }
       [Then(@"I enter tab on postcode field")]
       public void ThenIEnterTabOnPostcodeField()
       {
           CurrentPage.As<MyAddressDetailsPage>().EmptyPostcodeField();
       }
      [Then(@"I should see an error message on postcode field on my address page")]
       public void ThenIShouldSeeAnErrorMessageOnPostcodeFieldOnMyAddressPage()
       {
           CurrentPage.As<MyAddressDetailsPage>().PostcodeErrorMessageDisplayed();
       }
      [Then(@"I enter tab on House number")]
      public void ThenIEnterTabOnHouseNumber()
      {
          CurrentPage.As<MyAddressDetailsPage>().EmptyHouseNumberTextBox();
      }
      [Then(@"I should an error message on house number field on my address page")]
      public void ThenIShouldAnErrorMessageOnHouseNumberFieldOnMyAddressPage()
      {
          CurrentPage.As<MyAddressDetailsPage>().HouseNumberErrorMessageDisplayed();
      }
      [Then(@"I enter tab on address line one")]
      public void ThenIEnterTabOnAddressLineOne()
      {
          CurrentPage.As<MyAddressDetailsPage>().EmptyAddressLineTextBox();
      }
      [Then(@"I should see an error message on Address Line one field on my address page")]
      public void ThenIShouldSeeAnErrorMessageOnAddressLineOneFieldOnMyAddressPage()
      {
          CurrentPage.As<MyAddressDetailsPage>().AddressLine1ErrorMessageDisplayed();
      }
      [Then(@"I enter tab on City/Town field")]
      public void ThenIEnterTabOnCityTownField()
      {
          CurrentPage.As<MyAddressDetailsPage>().EmptyCityTextBox();
      }
      [Then(@"I should see an error message on City/town field on my address page")]
      public void ThenIShouldSeeAnErrorMessageOnCityTownFieldOnMyAddressPage()
      {
          CurrentPage.As<MyAddressDetailsPage>().CityTownErrorMessageDisplayed(); 
      }
      [Then(@"I enter tab on Phone number field")]
      public void ThenIEnterTabOnPhoneNumberField()
      {
          CurrentPage.As<MyAddressDetailsPage>().EmptyPhoneNumberTextBox();
      }
      [Then(@"I should see an error message on phone number field on my address page")]
      public void ThenIShouldSeeAnErrorMessageOnPhoneNumberFieldOnMyAddressPage()
      {
         CurrentPage.As<MyAddressDetailsPage>().PhoneNumberErrorMessageDisplayed();
      }
      [When(@"I click on Social Login Radio button")]
      public void WhenIClickOnSocialLoginRadioButton()
      {
          CurrentPage.As<MySignInDetailsPage>().ClickRadioButtonSocialLogin();
      }
      [Then(@"I should be able to see social login buttons")]
      public void ThenIShouldBeAbleToSeeSocialLoginButtons()
      {
          CurrentPage.As<MySignInDetailsPage>().VerifySocialButtonsExist(true);
      }
      [Then(@"I get the error message displayed on your company name field")]
      public void ThenIGetTheErrorMessageDisplayedOnYourCompanyNameField()
      {
          CurrentPage.As<BusinessDetailsPage>().CompanyNameErrorMessageDisplayed();
      }
      [Then(@"I get the error message displayed on Business sector field")]
      public void ThenIGetTheErrorMessageDisplayedOnBusinessSectorField()
      {
          CurrentPage.As<BusinessDetailsPage>().BusinessSectorErrorMessageDisplayed();
      }      
      
    }
}
