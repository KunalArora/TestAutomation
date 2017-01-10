
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Brother.Tests.Selenium.Lib;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.BrotherOnline.ThirdParty;
using TechTalk.SpecFlow;
using Brother.Online.TestSpecs._80.Test_Steps;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Online.TestSpecs._80.Test_Steps
{
    [Binding]
    public class ProductRegistrationSteps : BaseSteps
    {
        [Given(@"I navigate to ""(.*)"" in order to validate the landing page")]
        [Given(@"I navigate to ""(.*)"" in order to validate a Product Registration page when I want to create a new account or existing account with Brother Online")]
        public void GivenINavigateToInOrderToValidateAProductRegistrationPageWhenIWantToCreateANewAccountOrExistingAccountWithBrotherOnline(string url)
        {
            CurrentPage = BasePage.LoadProductRegistrationPage(CurrentDriver, null);
            CurrentPage.As<ProductRegistrationPage>().GetProductRegistrationPage(url);
        }
        [Given(@"I navigate to ""(.*)"" Brother Online landing page")]
        public void GivenINavigateToBrotherOnlineLandingPage(string country)
        {
            CurrentPage = BasePage.LoadBrotherOnlineHomePage(CurrentDriver, country);
        }

        [Given(@"I browse to the ""(.*)"" product registration page")]
        public void GivenIBrowseToTheProductRegistrationPage(string url)
        {
            CurrentPage = BasePage.LoadProductRegistrationPage(CurrentDriver, url);
        }

        [Given(@"I deregister the serial number using the ""(.*)""")]
        public void GivenIDeregisterTheSerialNumberUsingThe(string productid)
        {
            CurrentPage.As<SignInPage>().DeregisterSerialNumber(productid);
        }
        [Given(@"I deregister the serial number using the ""(.*)"" on Product Registration page")]
        public void GivenIDeregisterTheSerialNumberUsingTheOnProductRegistrationPage(string productid)
        {
            CurrentPage.As<ProductRegistrationPage>().DeregisterSerialNumber(productid);
        }

        [Given(@"I have entered my product SerialNumber reading from the environmental variable")]
        public void GivenIHaveEnteredMyProductSerialNumberReadingFromTheEnvironmentalVariable()
        {
            var productCode = Helper.GetDeviceCodeSeed();
            GivenIHaveEnteredMyProductSerialCode(productCode);
        }

        [Given(@"I have entered my Product Serial Code ""(.*)""")]
        public void GivenIHaveEnteredMyProductSerialCode(string productSerialCode)
        {
            CurrentPage.As<ProductRegistrationPage>().EnterProductSerialCode(productSerialCode);
        }

       [Then(@"I should see the Header and the Footer appearing on the landing Page")]
        public void ThenIShouldSeeTheHeaderAndTheFooterAppearingOnTheLandingPage()
        {
            CurrentPage.As<HomePage>().CheckForHeaderAndFooter();
        }
        
        [Given(@"I have entered my product ""(.*)""")]
        public void GivenIHaveEnteredMyProduct(string serialnumber)
        {
            CurrentPage.As<ProductRegistrationPage>().PopulateSerialNumberTextBox(serialnumber);
        }
       [Given(@"clicked on Find Product Button")]
        public void GivenClickedOnFindProductButton()
        {
            CurrentPage.As<ProductRegistrationPage>().ClickFindProductButton();
        }
       [Given(@"I retreive data product id from Product Page")]
       public void GivenIRetreiveDataProductIdFromProductPage()
       {
           CurrentPage.As<ProductRegistrationPage>().RetreiveDataProductId();
       }

       [Given(@"I have entered ""(.*)""")]
       public void GivenIHaveEntered(string date)
       {
           CurrentPage.As<ProductRegistrationPage>().EnterProductDate(date);
       }
       [Given(@"I entered apply button")]
       public void GivenIEnteredApplyButton()
       {
           CurrentPage.As<ProductRegistrationPage>().ClickApplyButton();
       }
       [Given(@"I enter ""(.*)""")]
       public void GivenIEnter(string promocode)
       {
           CurrentPage.As<ProductRegistrationPage>().EnterPromoCode(promocode);
       }
       [Given(@"I click on add code button")]
       public void GivenIClickOnAddCodeButton()
       {
           CurrentPage.As<ProductRegistrationPage>().ClickAddCodeButton();
       }

       [Given(@"I click on continue button on brother product page")]
       public void GivenIClickOnContinueButtonOnBrotherProductPage()
       {
           Thread.Sleep(TimeSpan.FromSeconds(3));
           NextPage = CurrentPage.As<ProductRegistrationPage>().ClickContinueButton();
       }

       [Then(@"I click on continue button on address details page")]
       public void ThenIClickOnContinueButtonOnAddressDetailsPage()
       {
           CurrentPage.As<AddressDetailsPage>().ClickContinueButtonOnAdPage();
       }
        [Then(@"I enter ""(.*)"" and ""(.*)"" and ""(.*)"" on address details page")]
       public void ThenIEnterAndAndOnAddressDetailsPage(string accountholdersname, string sortcode, string accountnumber)
        {
            CurrentPage.As<AddressDetailsPage>().EnterAccountDetails(accountholdersname, sortcode, accountnumber);
        }
       [Then(@"I can register my Email on user details page")]
       public void ThenICanRegisterMyEmailOnUserDetailsPage()
       {
           CurrentPage.As<UserDetailsPage>().EnterEmailId(string.Empty);
       }
       [Then(@"I enter ""(.*)""  and ""(.*)"" on  user details page")]
       public void ThenIEnterAndOnUserDetailsPage(string firstname, string lastname)
       {
           CurrentPage.As<UserDetailsPage>().EnterNames(firstname, lastname);
       }
       [Then(@"I click on continue button on user details page")]
       public void ThenIClickOnContinueButtonOnUserDetailsPage()
       {
           Thread.Sleep(TimeSpan.FromSeconds(10));
           NextPage = CurrentPage.As<UserDetailsPage>().ClickContinueButtonOnUdPage();
       }
       [Then(@"I can register my ""(.*)"" on the address details page")]
       public void ThenICanRegisterMyOnTheAddressDetailsPage(string postcode)
       {
           CurrentPage.As<AddressDetailsPage>().EnterPostcode(postcode);
       }
       [Then(@"I click on Find Address Button")]
       public void ThenIClickOnFindAddressButton()
       {
           CurrentPage.As<AddressDetailsPage>().ClickOnFindAddressButton();
       }
       [Then(@"I enter ""(.*)"" on address page")]
       public void ThenIEnterOnAddressPage(string housenumber)
       {
           CurrentPage.As<AddressDetailsPage>().EnterHouseNumber(housenumber);
       }
        [Then(@"I tick on terms and conditions checkbox")]
       public void ThenITickOnTermsAndConditionsCheckbox()
       {
           CurrentPage.As<UserDetailsPage>().ClickAcceptCheckbox();
       }
       [Then(@"I tick on terms and conditions checkbox on Address details Page")]
       public void ThenITickOnTermsAndConditionsCheckboxOnAddressDetailsPage()
       {
           CurrentPage.As<AddressDetailsPage>().ClickAcceptCheckbox();
       }
       [Then(@"I click on tickbox to confirm I will send my proof of purchase")]
       public void ThenIClickOnTickboxToConfirmIWillSendMyProofOfPurchase()
       {
           CurrentPage.As<AddressDetailsPage>().ClickAcceptProofOfPurchase();
       }
       [Then(@"I can complete my product registration by clicking on complete registration button")]
       public void ThenICanCompleteMyProductRegistrationByClickingOnCompleteRegistrationButton()
       {
           NextPage = CurrentPage.As<UserDetailsPage>().ClickCompleteRegistrationButton(); 
       }
       [Then(@"I can complete my product registration by clicking on complete registration button and I can deregister the ""(.*)""")]
       public void ThenICanCompleteMyProductRegistrationByClickingOnCompleteRegistrationButtonAndICanDeregisterThe(string serialnumber)
       {
           NextPage = CurrentPage.As<UserDetailsPage>().ClickCompleteRegistrationButton();
       }
       [Then(@"Once I have Validated ""(.*)"" was received and verified my account for Product Registration Email")]
       public void ThenOnceIHaveValidatedWasReceivedAndVerifiedMyAccountForProductRegistrationEmail(string emailAddress)
       {
           Thread.Sleep(new TimeSpan(0, 0, 0, 10)); //  deliberate wait for account to finalise before validation
           ValidateAccountEmail(emailAddress);
       }

       private void ValidateAccountEmail(string emailID)
       {
           if (Email.CheckEmailPackage("GuerrillaEmail"))
           {
               LaunchGuerrillaEmail(emailID);
               CurrentPage.As<GuerillaEmailConfirmationPage>().SelectEmail("Product Registration");
               //  CurrentPage.As<GuerillaEmailConfirmationPage>().CheckAllEmailLinks();
               //NextPage = CurrentPage.As<GuerillaEmailConfirmationPage>().ValidateForgottenPasswordEmail();
           }
       }
       private void LaunchGuerrillaEmail(string inBox)
       {
           inBox = @"testemailidinputfield@guerrillamail.com";
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
    
       [Then(@"I can complete my product registration by clicking on complete registration button on Address Details Page and I can  deregister the ""(.*)""")]
       public void ThenICanCompleteMyProductRegistrationByClickingOnCompleteRegistrationButtonOnAddressDetailsPageAndICanDeregisterThe(string serialnumber)
       {
           NextPage = CurrentPage.As<AddressDetailsPage>().ClickCompleteRegistrationButton();
       }
       [Then(@"I can complete my product registration by clicking on continue button and I can  deregister the ""(.*)""")]
       public void ThenICanCompleteMyProductRegistrationByClickingOnContinueButtonAndICanDeregisterThe(string p0)
       {
           NextPage = CurrentPage.As<ProductRegistrationPage>().ClickContinueButtonMyPrinterandDevicePage();
       }

       [Then(@"I can verify registration confirmaiton message is present")]
       public void ThenICanVerifyRegistrationConfirmaitonMessageIsPresent()
       {
           CurrentPage.As<MyPrintersAndDevicesPage>().IsDeviceRegistrationConfirmationMessagePresent();
       }

      [Then(@"I can confirm device registration message is displayed on My printer and devices screen")]
       public void ThenICanConfirmDeviceRegistrationMessageIsDisplayedOnMyPrinterAndDevicesScreen()
       {
           CurrentPage.As<ConfirmationPage>().CheckConfirmationMessage();
       }


    }

}
