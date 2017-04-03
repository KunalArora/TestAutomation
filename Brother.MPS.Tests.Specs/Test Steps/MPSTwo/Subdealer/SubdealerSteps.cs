﻿using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Subdealer
{
    [Binding]
    public class SubdealerSteps : BaseSteps
    {
        [When(@"I navigate to Dealership Users page")]
        [Given(@"I navigate to Dealership Users page")]
        public void GivenINavigateToDealershipUsersPage()
        {
            NextPage = CurrentPage.As<DealerAdminDashBoardPage>().NavigateToDealerAdminDealershipUsersPage();

        }

        [Then(@"the list of existing subdealer is displayed")]
        public void ThenTheListOfExistingSubdealerIsDisplayed()
        {
            CurrentPage.As<DealerAdminDealershipUsersPage>().IsDealershipUserPageDisplayed();
        }

        [When(@"I begin subdealer creation process")]
        public void WhenIBeginSubdealerCreationProcess()
        {
            NextPage = CurrentPage.As<DealerAdminDealershipUsersPage>().StartSubDealerCreation();
        }

        [When(@"I enter all details with ""(.*)"" as the permission")]
        public void WhenIEnterAllDetailsWithAsThePermission(string permission)
        {
            CurrentPage.As<DealerAdminDealershipUsersCreationPage>().FillSubDealerDetails(permission);
        }

        [When(@"I submit the detail for creation")]
        public void WhenISubmitTheDetailForCreation()
        {
            NextPage = CurrentPage.As<DealerAdminDealershipUsersCreationPage>().SaveSubdealerDetails();
        }

        [Then(@"the subdealer created is shown on the list of subdealers")]
        public void ThenTheSubdealerCreatedIsShownOnTheListOfSubdealers()
        {
            CurrentPage.As<DealerAdminDealershipUsersPage>().IsSubdealerCreated();
        }

        [Given(@"I navigate to LO Admin Administration page using tab")]
        public void GivenINavigateToLoAdminAdministrationPageUsingTab()
        {
           NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToAdministrationPagePage();
        }

        [When(@"I navigate to LO Admin Dealership Users page")]
        public void WhenINavigateToLoAdminDealershipUsersPage()
        {
            CurrentPage.As<LocalOfficeAdminAdministrationDashboardPage>().IsAdministrationPageDisplayed();

            NextPage =
                CurrentPage.As<LocalOfficeAdminAdministrationDashboardPage>().NavigateToAdministrationDealerPage();
        }

        [When(@"I search for dealership ""(.*)"" on LO dealership page")]
        public void WhenISearchForDealershipOnLoDealershipPage(string dealer)
        {
            CurrentPage.As<LocalOfficeAdminAdministrationDealerPage>().NavigateToDealership();
            CurrentPage.As<LocalOfficeAdminAdministrationDealerPage>().SearchForDealership(dealer);
           
        }

        [When(@"I proceed to dealership users page for that dealer")]
        public void WhenIProceedToDealershipUsersPageForThatDealer()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminAdministrationDealerPage>().NavigateToDealershipUsersPage();
            
        }

        [Then(@"the list of existing subdealer is displayed for that dealer")]
        public void ThenTheListOfExistingSubdealerIsDisplayedForThatDealer()
        {
            CurrentPage.As<LocalOfficeAdminExistingDealershipUsersPage>().IsDealershipUserPageDisplayed();
        }


        [When(@"I begin subdealer creation for the dealer")]
        public void WhenIBeginSubdealerCreationForTheDealer()
        {
            CurrentPage.As<LocalOfficeAdminExistingDealershipUsersPage>().IsDealershipUserPageDisplayed();
            NextPage = CurrentPage.As<LocalOfficeAdminExistingDealershipUsersPage>().StartSubDealerCreation();
        }

        [When(@"I enter all details with ""(.*)"" for new subdealer")]
        public void WhenIEnterAllDetailsWithForNewSubdealer(string permission)
        {
            CurrentPage.As<LocalOfficeAdminDealershipUsersCreationPage>().IsDealershipUserCreationPageDisplayed();
            CurrentPage.As<LocalOfficeAdminDealershipUsersCreationPage>().FillSubDealerDetails(permission);
            
        }

        [When(@"I submit the detail for creation of the new subdealer")]
        public void WhenISubmitTheDetailForCreationOfTheNewSubdealer()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDealershipUsersCreationPage>().SaveSubdealerDetails();
        }

        [Then(@"the subdealer created is shown on the dealer list of subdealers")]
        public void ThenTheSubdealerCreatedIsShownOnTheDealerListOfSubdealers()
        {
            CurrentPage.As<LocalOfficeAdminExistingDealershipUsersPage>().IsSubdealerCreated();
        }


    }
}
