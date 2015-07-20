using System.Threading;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs.BrotherOnline.Account
{
    [Binding]
    public class CreateNewAccountSteps : BaseSteps
    {
        [Given(@"I am logged into Brother Online ""(.*)"" using ""(.*)""")]
        public void GivenIAmLoggedIntoBrotherOnlineUsing(string country, string emailAddress)
        {
            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BaseUrl, "");
            WhenIClickOnSignInCreateAnAccount(country);
            WhenIAmRedirectedToTheBrotherLoginRegisterPage();
            DoHaveAnAccountCheckbox();
            WhenIEnterAValidEmailAddress(emailAddress);
            CurrentPage.As<RegistrationPage>().PopulatePassword(Helper.Password);
            WhenIClickOnSignIn(country);
            CurrentPage.As<WelcomeBackPage>().IsRegisterDeviceLinkAvailable();
        }

        [Given(@"I am logged onto ""(.*)"" BOL with ""(.*)"" username and ""(.*)"" password")]
        public void GivenIAmLoggedOntoBOLWithUsernameAndPassword(string country, string username, string pwd)
        {
            {
                Helper.SetCountry(country);
                CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BaseUrl, "");
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
            When(string.Format("Enter Email Address as \"{0}\"", emailAddress));
        }

        [Then(@"I enter an email address with too many allowed characters as ""(.*)""")]
        public void ThenIEnterAnEmailAddressWithTooManyAllowedCharactersAs(string emailAddress)
        {
            When(string.Format("Enter Email Address as \"{0}\"", emailAddress));
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
            CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BaseUrl, "");
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
            CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BaseUrl, "");
            GivenINeedABrotherOnlineAccountInOrderToUseBrotherOnlineServices(country);
        }
		
		[Given(@"I launch Brother Online for ""(.*)""")]
        public void GivenILaunchBrotherOnlineFor(string country)
        {
            // Set locale to direct to Brother Online Ireland
            Helper.SetCountry(country);
            var title = HomePage.WelcomePageCountryTitle(country);
            CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BaseUrl, title);
           
        }

        [When(@"I return to Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [When(@"I sign back into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [Then(@"I sign back into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [Given(@"I sign back into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [Given(@"I sign into Cloud MPS as a ""(.*)"" from ""(.*)""")]
        [Given(@"I sign into MPS as a ""(.*)"" from ""(.*)""")]
        public void GivenISignIntoMpsasAFrom(string role, string country)
        {
            GivenILaunchBrotherOnlineFor(country);
            WhenIClickOnSignInCreateAnAccount(country);
            WhenISignInAsA(role, country);
            
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
            NextPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BaseUrl, "");
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
        [When(@"I fill in the registration information excluding email address")]
        public void WhenIFillInTheRegistrationInformationExcludingEmailAddress(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<RegistrationPage>().PopulateFirstNameTextBox(form.FirstName);
            CurrentPage.As<RegistrationPage>().PopulateLastNameTextBox(form.LastName);
            CurrentPage.As<RegistrationPage>().PopulatePasswordTextBox(form.Password);
            CurrentPage.As<RegistrationPage>().PopulateConfirmPasswordTextBox(form.Password);
        }
        [When(@"I press tab in the email address field")]
        public void WhenIPressTabInTheEmailAddressField()
        {
            CurrentPage.As<RegistrationPage>().EmptyEmailAddressTextBox();
        }
        
        [When(@"I press tab in the password field")]
        public void WhenIPressTabInThePasswordField()
        {
            CurrentPage.As<RegistrationPage>().EmptyPasswordTextBox();
        }

        [When(@"I press tab in the first name field")]
        public void WhenIPressTabInTheFirstNameField()
        {
            CurrentPage.As<RegistrationPage>().EmptyFirstNameTextBox();
        }

        [When(@"I press tab in the last name field")]
        public void WhenIPressTabInTheLastNameField()
        {
            CurrentPage.As<RegistrationPage>().EmptyLastNameTextBox();
        }

        [When(@"I press tab in the company name field")]
        public void WhenIPressTabInTheCompanyNameField()
        {
            CurrentPage.As<RegistrationPage>().EmptyCompanyNameTextBox();
        }

        [When(@"I press tab in the business sector field")]
        public void WhenIPressTabInTheBusinessSectorField()
        {
            CurrentPage.As<RegistrationPage>().EmptyBusinessSectorTextBox();
        }

        [Then(@"If I sign back into Brother Online ""(.*)"" using the same credentials")]
        [When(@"I sign back into Brother Online ""(.*)"" using the same credentials")]
        public void ThenIfISignBackIntoBrotherOnlineUsingTheSameCredentials(string country)
        {
            NextPage = CurrentPage.As<HomePage>().ClickSignInCreateAccountButton(country);
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

        [When(@"I add my company name as ""(.*)""")]
        public void WhenIAddMyCompanyNameAs(string companyName)
        {
            CurrentPage.As<RegistrationPage>().PopulateCompanyNameTextBox(companyName);
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

        [When(@"I select my Business Sector as ""(.*)""")]
        public void WhenISelectMyBusinessSectorAs(string businessSector)
        {
            CurrentPage.As<RegistrationPage>().PopulateBusinessSectorDropDown(businessSector);
        }
        [When(@"I select my Business Sector as ""(.*)"" on Business Details Page")]
        public void WhenISelectMyBusinessSectorAsOnBusinessDetailsPage(string businessSector)
        {
            CurrentPage.As<BusinessDetailsPage>().PopulateBusinessSectorDropDown(businessSector);
        }

        [When(@"I select number of Employees as ""(.*)""")]
        public void WhenISelectNumberOfEmployeesAs(string numberOfEmployees)
        {
            CurrentPage.As<RegistrationPage>().PopulateEmployeeCountDropDown(numberOfEmployees);
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
            TestCheck.AssertIsNotEqual(true, CurrentPage.As<RegistrationPage>().IsWarningBarPresent(0, 5), "Warning Bar - account validation");

            WhenIAmRedirectedToTheBrotherLoginRegisterPage();
            WhenIEnterAValidEmailAddress(Email.RegistrationEmailAddress);
            WhenIEnterAValidPassword(Helper.Password);
            WhenIClickOnSignIn(country);
        }

        [Given(@"I already have a set of Brother Online ""(.*)"" account credentials")]
        public void GivenIAlreadyHaveASetOfBrotherOnlineAccountCredentials(string country)
        {
            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadBolHomePage(CurrentDriver, BasePage.BaseUrl, "");
        }

        [When(@"I click on Create Account for ""(.*)""")]
        [When(@"I click on Sign In / Create An Account for ""(.*)""")]
        public void WhenIClickOnSignInCreateAnAccount(string country)
        {
            CurrentPage.As<HomePage>().IsSignInCreateAccountButtonAvailable();
            NextPage = CurrentPage.As<HomePage>().ClickSignInCreateAccountButton(country);
        }

        [When(@"I click on ""(.*)"" Sign In")]
        public void WhenIClickOnSignIn(string country)
        {
            NextPage = CurrentPage.As<RegistrationPage>().ClickSignInButton(country);
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
        [Then(@"I should refresh the current page to clear all error messages")]
        public void ThenIShouldRefreshTheCurrentPageToClearAllErrorMessages()
        {
            CurrentDriver.Navigate().Refresh();
        }
        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            CurrentPage.As<RegistrationPage>().IsErrorMessageDisplayed();
        }
        [Then(@"I should see an error message on the password field")]
        public void ThenIShouldSeeAnErrorMessageOnThePasswordField()
        {
            CurrentPage.As<RegistrationPage>().PasswordErrorMessageDisplayed();
        }
        [Then(@"I should see an error message on the first name field")]
        public void ThenIShouldSeeAnErrorMessageOnTheFirstnameField()
        {
            CurrentPage.As<RegistrationPage>().FirstNameErrorMessage();
        }
        [Then(@"I should see an error message on the last name field")]
        public void ThenIShouldSeeAnErrorMessageOnTheLastnameField()
        {
            CurrentPage.As<RegistrationPage>().LastNameErrorMessage();
        }
        [Then(@"I should see an error message on the company name field")]
        public void ThenIShouldSeeAnErrorMessageOnTheCompanynameField()
        {
            CurrentPage.As<RegistrationPage>().CompanyNameErrorMessage();
        }
        [Then(@"I should see an error message on the business sector field")]
        public void ThenIShouldSeeAnErrorMessageOnTheBusinessSectorField()
        {
            CurrentPage.As<RegistrationPage>().BusinessSectorErrorMessage();
        }
       [Then(@"I should get an error message displayed on the Terms and Conditions")]
        public void ThenIShouldGetAnErrorMessageDisplayedOnTheTermsAndConditions()
        {
            CurrentPage.As<RegistrationPage>().TermsAndConditionsErrorMessageDisplayed();
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

        [When(@"I enter a valid Email Address ""(.*)""")]
        public void WhenIEnterAValidEmailAddress(string validEmailAddress)
        {
            CurrentPage.As<RegistrationPage>().PopulateEmailAddressTextBox(validEmailAddress);
        }

        [When(@"I enter a valid Password ""(.*)""")]
        public void WhenIEnterAValidPassword(string validPassword)
        {
            CurrentPage.As<RegistrationPage>().PopulatePassword(validPassword);
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
            SignInButtonToAsARoleType(role, country);
        }

        private void SignInButtonToAsARoleType(string role, string country)
        {
            switch (role)
            {
                case "Cloud MPS Dealer":
                {
                    NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToDealerDashboard(country);
                    break;
                }
                case "Cloud MPS Local Office":
                {
                    NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToLocalOfficeDashboard(country);
                    break;
                }
                case "Cloud MPS Bank":
                {
                    NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToBankUser(country);
                    break;
                }
                case "Cloud MPS Local Office Approver":
                {
                    NextPage = CurrentPage.As<RegistrationPage>().SignInButtonToLocalOfficeApproverDashboard(country);
                    break;
                }
            }
        }

        private void SignInAsARoleType(string role, string country)
        {
            switch (role)
            {
                case  "Dealer" :
                {
                    WhenIEnterAValidEmailAddress("laies_es_qas@mailinator.com");
                    WhenIEnterAValidPassword("Welcome1");
                    break;
                        
                }
                case "Customer" :
                {
                    WhenIEnterAValidEmailAddress("esqacustomer2nd0604@mailinator.com");
                    WhenIEnterAValidPassword("Lucasis3");
                    break;
                }
                case "Sales Dealer":
                {
                    WhenIEnterAValidEmailAddress("es.sales.dealer@mailinator.com");
                    WhenIEnterAValidPassword("Rishav13");
                    break;
                }
                case "Cloud MPS Dealer":
                {
                    switch (country)
                    {
                        case "United Kingdom":
                            WhenIEnterAValidEmailAddress("mpsdealer_uk_automation@mailinator.com");
                            WhenIEnterAValidPassword("P@$$w0rd");
                            break;
                        case "Germany":
                            WhenIEnterAValidEmailAddress("mpsdealer_de_automation@mailinator.com");
                            WhenIEnterAValidPassword("P@$$w0rd");
                            break;
                    }
                    break;
                }
                case "Cloud MPS Bank":
                {
                    switch (country)
                    {
                        case "United Kingdom":
                            WhenIEnterAValidEmailAddress("MPS-BUK-UAT-Bank@brother.co.uk");
                            WhenIEnterAValidPassword("UKleasingbank1");
                            break;
                        case "Germany":
                            WhenIEnterAValidEmailAddress("MPS-BIG-UAT-Bank@brother.co.uk");
                            WhenIEnterAValidPassword("DEleasingbank1");
                            break;
                    }
                    break;
                }
                case "Cloud MPS Customer":
                {
                    switch (country)
                    {
                        case "United Kingdom":
                            WhenIEnterAValidEmailAddress("mpscustomerDE@brother.co.uk");
                            WhenIEnterAValidPassword("P@$$w0rd");
                            break;
                        case "Germany":
                            break;
                    }
                    break;
                }
                case "Cloud MPS Local Office":
                {
                    switch (country)
                    {
                        case "United Kingdom":
                            WhenIEnterAValidEmailAddress("mpslocalofficeadminuk@mailinator.com");
                            WhenIEnterAValidPassword("P@$$w0rd");
                            break;
                        case "Germany":
                            WhenIEnterAValidEmailAddress("mpslocalofficeadminde@mailinator.com");
                            WhenIEnterAValidPassword("P@$$w0rd");
                            break;
                    }
                    break;
                }
                case "Cloud MPS Local Office Approver":
                {
                    switch (country)
                    {
                        case "United Kingdom":
                            WhenIEnterAValidEmailAddress("MPS-BUK-UAT-LOApprover@brother.co.uk");
                            WhenIEnterAValidPassword("UKloapprover1");
                            break;
                        case "Germany":
                            WhenIEnterAValidEmailAddress("MPS-BIG-UAT-LOApprover@brother.co.uk");
                            WhenIEnterAValidPassword("DEloapprover1");
                            break;
                    }
                    break;
                }
            }
        }
    }
}
