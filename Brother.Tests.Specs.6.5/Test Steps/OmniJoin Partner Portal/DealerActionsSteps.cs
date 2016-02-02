using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.OmniJoin.PartnerPortal;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs
{
    [Binding]
    public class DealerActionsSteps : BaseSteps
    {
        [Then(@"when I click Manage Customers and Orders")]
        public void ThenWhenIClickManageCustomersAndOrders()
        {
            NextPage = CurrentPage.As<PartnerPortalPage>().ManageCustomersAndOrdersButtonClick();
        }

        [Then(@"I can navigate back to the Partner Portal Home Page using breadcrumbs")]
        public void ThenICanNavigateBackToThePartnerPortalHomePageUsingBreadcrumbs()
        {
            NextPage = NavigationModule.PartnerPortalBreadcrumbClick(TestController.CurrentDriver);
        }

        [Then(@"I can navigate back to my account from Partner Portal Home Page")]
        public void ThenICanNavigateBackToMyAccountFromPartnerPortalHomePage()
        {
            NextPage = NavigationModule.PartnerPortalReturnToMyAccount(TestController.CurrentDriver);
        }

        [When(@"I Click Add New Customer")]
        public void WhenIClickAddNewCustomer()
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().AddNewCustomerButtonClick();
        }

        [When(@"I enter a new Customer Email Address As ""(.*)""")]
        public void WhenIEnterANewCustomerEmailAddressAs(string emailAddress)
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().AddNewCustomerEmailAddress(emailAddress);
            Helper.OrpCustomerEmailAddress = emailAddress;
        }

        [When(@"I click Next")]
        public void WhenIClickNext()
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().NextButtonClick();
        }

        [Then(@"I can click Add Customer")]
        public void ThenICanClickAddCustomer()
        {
            NextPage = CurrentPage.As<ManageCustomersAndOrdersPage>().AddCustomerButtonClick();
        }

        [Then(@"I can enter further customer information such as First Name as ""(.*)"", Last Name as ""(.*)"", Company Name as ""(.*)""")]
        public void ThenICanEnterFurtherCustomerInformationSuchAsFirstNameAsLastNameAsCompanyNameAs(string firstName, string lastName, string companyName)
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().AddFirstName(firstName);
            CurrentPage.As<ManageCustomersAndOrdersPage>().AddLastName(lastName);
            CurrentPage.As<ManageCustomersAndOrdersPage>().AddCompanyName(companyName);
        }

        [Then(@"I can see the Partner Portal Home Page")]
        public void ThenICanSeeThePartnerPortalHomePage()
        {
            CurrentPage.As<PartnerPortalPage>().IsHomeButtonAvailable();
        }

        [When(@"I click on Manage Services")]
        public void WhenIClickOnManageServices()
        {
            NextPage = CurrentPage.As<PartnerPortalPage>().ManageServicesButtonClick();
        }

        [Then(@"I should see the OmniJoin Services page")]
        public void ThenIShouldSeeTheOmniJoinServicesPage()
        {
            CurrentPage.As<ManageServicePage>().IsPurchaseActivateCodesButtonAvailable();
        }

        [When(@"I click on Purchase Activation Codes")]
        public void WhenIClickOnPurchaseActivationCodes()
        {
          NextPage = CurrentPage.As<ManageServicePage>().PurchaseCodesButtonClick();
        }

        [Then(@"I should see the Activation Codes creation page")]
        public void ThenIShouldSeeTheActivationCodesCreationPage()
        {
            CurrentPage.As<CreateActivationCodesPage>().IsPurchaseCodesButtonAvailable();
        }

        [When(@"I enter the following information")]
        public void WhenIEnterTheFollowingInformation(Table table)
        {
            dynamic form = table.CreateDynamicInstance();
            CurrentPage.As<CreateActivationCodesPage>().SelectProductPlan(form.OJProductPlan);
            CurrentPage.As<CreateActivationCodesPage>().SelectLicenseType(form.LicenseType);
            CurrentPage.As<CreateActivationCodesPage>().SelectPaymentMethod(form.Term);
            var term = form.Term.Equals("Annual") ? 12 : 1;
            Helper.OrpLicenseTerm = term;
            CurrentPage.As<CreateActivationCodesPage>().SelectNumberLicenses(form.Qty);
            Helper.OrpNumLicenses = Convert.ToInt32(form.Qty);
            var commentField = string.Empty;
            if (form.Comment.Equals("@@@@@"))
            {
                // Auto Generate Date for Comment field
                commentField = DateTime.Now.ToShortDateString();
            }
            CurrentPage.As<CreateActivationCodesPage>().AddComment(commentField);
            Helper.OrpComment = commentField;
        }

        [Then(@"I click Create Activation Codes")]
        public void ThenIClickCreateActivationCodes()
        {
            NextPage = CurrentPage.As<CreateActivationCodesPage>().PurchaseCodesButtonClick();
        }

        [Then(@"I review the order information")]
        public void ThenIReviewTheOrderInformation()
        {
            CurrentPage.As<CreateActivationCodesPage>().IsConfirmButtonAvailable();
        }

        [When(@"I click Confirm")]
        public void WhenIClickConfirm()
        {
            CurrentPage.As<CreateActivationCodesPage>().ConfirmButtonClick();
        }

        [Then(@"I should see the order success screen")]
        public void ThenIShouldSeeTheOrderSuccessScreen()
        {
            NextPage = CurrentPage.As<CreateActivationCodesPage>().IsSuccessAvailable();
        }

        [Then(@"I can store the Order Details for ""(.*)"" as they are required later")]
        public void ThenICanStoreTheOrderDetailsForAsTheyAreRequiredLater(string dealerEmailAddress)
        {
            Helper.OrpDealerEmail = dealerEmailAddress;
            Email.CurrentEmailInUseForTest = dealerEmailAddress;
            Helper.OrpActivationCode = Sql.GetOrpActivationCode(Sql.GetOrpDealerId(Helper.OrpDealerEmail));
                //Helper.OrpLicenseTerm, Helper.OrpNumLicenses, Helper.OrpComment);
        }
        [Then(@"I should see manage userlist page")]
        public void ThenIShouldSeeManageUserlistPage()
        {
            CurrentPage.As<PartnerPortalPage>().IsMaintainaListofUsersButonDisplayed();
        }
        [Then(@"I click on Manage a list of closed area")]
        public void ThenIClickOnManageAListOfClosedArea()
        {
            NextPage = CurrentPage.As<PartnerPortalPage>().MaintainaListofUsersButtonClick();
        }
        [When(@"I click on Edit your personal info page")]
        public void WhenIClickOnEditYourPersonalInfoPage()
        {
            NextPage = CurrentPage.As<PartnerPortalPage>().ClickEditYourPersonalInfoPage();
        }
        [When(@"I click on Edit address button")]
        public void WhenIClickOnEditAddressButton()
        {
            NextPage = CurrentPage.As<PartnerPortalPage>().ClickEditAddressButton();
        }

        [When(@"I see Edit address page")]
        public void WhenISeeEditAddressPage()
        {
           CurrentPage.As<EditAddressPage>().IsSaveButtonDisplayed();
        }

        [When(@"I enter tab on HouseName field")]
        public void WhenIEnterTabOnHouseNameField()
        {
            CurrentPage.As<EditAddressPage>().EmptyHouseNameTextBox();
        }

        [Then(@"I should see an error message on the HouseName field")]
        public void ThenIShouldSeeAnErrorMessageOnTheHouseNameField()
        {
            CurrentPage.As<EditAddressPage>().IsHouseNameTextBoxErrorMessageDisplayed();
        }

        [When(@"I enter tab on AddressLine name field")]
        public void WhenIEnterTabOnAddressLineNameField()
        {
            CurrentPage.As<EditAddressPage>().EmptyAddressLine1TextBox();
        }

        [Then(@"I should see an error message on the address field")]
        public void ThenIShouldSeeAnErrorMessageOnTheAddressField()
        {
            CurrentPage.As<EditAddressPage>().IsAddressLine1TextBoxErrorMessageDisplayed();
        }

        [When(@"I enter tab on HouseNumber field")]
        public void WhenIEnterTabOnHouseNumberField()
        {
            CurrentPage.As<EditAddressPage>().EmptyHouseNumberTextBox();
        }
        [When(@"I enter tab on Postcode")]
        public void WhenIEnterTabOnPostcode()
        {
         CurrentPage.As<EditAddressPage>().PopulatePostCodeTextBox();
        }

        [When(@"I enter tab on CityorTown field")]
        public void WhenIEnterTabOnCityorTownField()
        {
           CurrentPage.As<EditAddressPage>().PopulateCityorTownTextBox();
        }

        [Then(@"I should see an error message on CityorTown field")]
        public void ThenIShouldSeeAnErrorMessageOnCityorTownField()
        {
          CurrentPage.As<EditAddressPage>().IsCityTownTextBoxErrorMessageDisplayed();
        }

        [Then(@"I should see an error message on house number field")]
        public void ThenIShouldSeeAnErrorMessageOnHouseNumberField()
        {
            CurrentPage.As<EditAddressPage>().IsHouseNumberTextBoxErrorMessageDisplayed();
        }
        [When(@"I enter tab on code postal")]
        public void WhenIEnterTabOnCodePostal()
        {
           CurrentPage.As<EditAddressPage>().EmptyPostCodeTextBox();
        }

        [Then(@"I should see error message on codepostal field")]
        public void ThenIShouldSeeErrorMessageOnCodepostalField()
        {
            CurrentPage.As<EditAddressPage>().IsPostCodeTextBoxErrorMessageDisplayed();
        }

        [When(@"I enter tab on phoneNumber field")]
        public void WhenIEnterTabOnPhoneNumberField()
        {
           CurrentPage.As<EditAddressPage>().EmptyPhoneNumberTextBox();
        }

        [Then(@"I should see error message on PhoneNumber field")]
        public void ThenIShouldSeeErrorMessageOnPhoneNumberField()
        {
           CurrentPage.As<EditAddressPage>().IsPhoneNumberTextBoxErrorMessageDisplayed();
        }
        [When(@"I click Save")]
        public void WhenIClickSave()
        {
            CurrentPage.As<EditAddressPage>().ClickSaveButton();
        }
        [Then(@"I should see the validation error message on missing fields")]
        public void ThenIShouldSeeTheValidationErrorMessageOnMissingFields()
        {
            CurrentPage.As<EditAddressPage>().IsMandatoryFieldValidationErrorMessageDisplayed();
        }

        [Then(@"I should see ManageCustomersandOrdersPage")]
        public void ThenIShouldSeeManageCustomersandOrdersPage()
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().IsAddNewCustomerButtonDisplayed();
        }
        [Then(@"I click on ADD a colleague")]
        public void ThenIClickOnAddaColleague()
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().AddNewColleagueButtonClick();
        }
        [Then(@"I click on AddUser")]
        public void ThenIClickOnAddUser()
        {
            CurrentPage.As<EditUsersPage>().AdduserButtonClick();
        }

        [Then(@"I should see enter email address field")]
        public void ThenIShouldSeeEnterEmailAddressField()
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().IsAddNewColleagueEmailAddressTxtBoxDisplayed();
        }
        [Then(@"I enter email address as ""(.*)""")]
        public void ThenIEnterEmailAddressAs(string emailAddress)
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().PopulateAddNewColleagueEmailAddressTxtBox(emailAddress);
        }
        [Then(@"I click on submit")]
        public void ThenIClickOnSubmit()
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().ClickFollowingButton();
        }

        [Then(@"I should see FirstName and LastName fields")]
        public void ThenIShouldSeeFirstNameAndLastNameFields()
        {
           CurrentPage.As<ManageCustomersAndOrdersPage>().IsSubmitButtonDisplayed();
        }
        [Then(@"I fill in FirstName as """"(.*)""""")]
        public void ThenIFillInFirstNameAs(string firstName)
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().EnterFirstNameTextBox(firstName);
        }
        [Then(@"I enter Email as ""(.*)""")]
        public void ThenIEnterEmailAs(string emailAddress)
        {
            CurrentPage.As<EditUsersPage>().PopulateAddNewUserEmailAddressTxtBox(emailAddress); 
        }
        [Then(@"I click next")]
        public void ThenIClickNext()
        {
            CurrentPage.As<EditUsersPage>().ClickNextButton();
        }

        [When(@"I fill in FirstName as ""(.*)""")]
        public void WhenIFillInFirstNameAs(string firstName)
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().EnterFirstNameTextBox(firstName);
        }
        [When(@"I enter FirstName as ""(.*)""")]
        public void WhenIEnterFirstNameAs(string firstName)
        {
            CurrentPage.As<EditUsersPage>().EnterFirstNameTextBox(firstName);
        }
        [When(@"I enter LastName as ""(.*)""")]
        public void WhenIEnterLastNameAs(string lastName)
        {
            CurrentPage.As<EditUsersPage>().EnterLastNameTextBox(lastName);
        }

        [When(@"I fill in LastName as ""(.*)""")]
        public void WhenIFillInLastNameAs(string lastName)
        {
           CurrentPage.As<ManageCustomersAndOrdersPage>().EnterLastNameTxtBox(lastName);
        }
        [When(@"I fill in companyName as ""(.*)""")]
        public void WhenIFillInCompanyNameAs(string companyName)
        {
          CurrentPage.As<ManageCustomersAndOrdersPage>().EnterCompanyNameTextBox(companyName);
        }

        [Then(@"I fill in LastName as ""(.*)""")]
        public void ThenIFillInLastNameAs(string lastName)
        {
          CurrentPage.As<ManageCustomersAndOrdersPage>().EnterLastNameTextBox(lastName);  
        }
        [Then(@"I click submit")]
        public void ThenIClickSubmit()
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().ClickSubmitButton();
        }
        [When(@"I click submit")]
        public void WhenIClickSubmit()
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().ClickSubmitButton(); 
        }
        [When(@"I click on submit")]
        public void WhenIClickOnSubmit()
        {
            CurrentPage.As<EditUsersPage>().ClickSubmitButton(); 
        }

        [Then(@"I should see success message on the page")]
        public void ThenIShouldSeeSuccessMessageOnThePage()
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().IsSuccessMessageDisplayed();
        }
        [Then(@"I should see success message")]
        public void ThenIShouldSeeSuccessMessage()
        {
            CurrentPage.As<EditUsersPage>().IsSuccessMessageDisplayed();
        }

        [Then(@"I close the message")]
        public void ThenICloseTheMessage()
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().PopUpMessageClose();
        }
        [Then(@"I close the message pop-up")]
        public void ThenICloseTheMessagePop_Up()
        {
            CurrentPage.As<EditUsersPage>().PopUpMessageClose();
        }

        [When(@"I close the message")]
        public void WhenICloseTheMessage()
        {
            CurrentPage.As<ManageCustomersAndOrdersPage>().PopUpMessageClose();
        }

        [Then(@"I should see created user in the user list page")]
        public void ThenIShouldSeeCreatedUserInTheUserListPage()
        {
           CurrentPage.As<ManageCustomersAndOrdersPage>().IsCreatedUsersListDisplayed();
        }
        [Then(@"I should see added user in the list")]
        public void ThenIShouldSeeAddedUserInTheList()
        {
            CurrentPage.As<EditUsersPage>().IsCreatedUsersinListDisplayed();
        }

        [Then(@"I should see added customer in the Managecustomersandorderspage")]
        public void ThenIShouldSeeAddedCustomerInTheManagecustomersandorderspage()
        {
           CurrentPage.As<ManageCustomersAndOrdersPage>().IsAddedCustomerListDisplayed();
        }

        [Then(@"I click on ManageCustomersandOrders button")]
        public void ThenIClickOnManageCustomersandOrdersButton()
        {
            NextPage = CurrentPage.As<PartnerPortalPage>().ClickManageCustomersAndOrdersPageButton();
        }

        [Then(@"I click on EditUsers role")]
        public void ThenIClickOnEditUsersRole()
        {
            NextPage = CurrentPage.As<PartnerPortalPage>().ClickEditUserButton();
        }

        [Then(@"I should see EditUsersPage")]
        public void ThenIShouldSeeEditUsersPage()
        {
          CurrentPage.As<EditUsersPage>().IsAddUserButtonDisplayed();
        }     

    }
}
