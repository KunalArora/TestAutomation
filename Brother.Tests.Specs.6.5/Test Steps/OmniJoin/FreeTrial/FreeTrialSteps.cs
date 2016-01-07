﻿using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.OmniJoin;
using Brother.WebSites.Core.Pages.OmniJoin.Trial;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.OmniJoin.FreeTrial
{
    [Binding]
    public class FreeTrialSteps : BaseSteps
    {
        [When(@"If I click on Start Free Trial")]
        [Then(@"If I click on Start Free Trial")]
        [Given(@"If I click on Start Free Trial")]
        public void GivenIfIClickOnStartFreeTrial()
        {
            NextPage = CurrentPage.As<WebConferencingHomePage>().GettingStartedButtonClick();
        }

        [Given(@"I click on Try Now")]
        public void GivenIClickOnTryNow()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().OmniJoinTryNowButtonClick();
        }

        [Then(@"I should be directed to the OmniJoin Free Trial page")]
        public void ThenIShouldBeDirectedToTheOmniJoinFreeTrialPage()
        {
            CurrentPage.As<FreeTrialPage>().IsSubmitButtonAvailable();
        }

        [When(@"I have entered a valid First and Last name, ""(.*)"", ""(.*)""")]
        public void WhenIHaveEnteredAValidFirstAndLastName(string firstName, string lastName)
        {
            CurrentPage.As<FreeTrialPage>().PopulateFirstNameTextBox(firstName);
            CurrentPage.As<FreeTrialPage>().PopulateLastNameTextBox(lastName);
        }
        [Then(@"I enter an invalid email address as ""(.*)"" for omnijoin free trial")]
        public void ThenIEnterAnInvalidEmailAddressAsForOmnijoinFreeTrial(string invalidemailaddress)
        {
            CurrentPage.As<FreeTrialPage>().PopulateInvalidEmailAddressTextBox(invalidemailaddress);
            
        }
        [Then(@"I should see the Error Message displayed on the Email Address field")]
        public void ThenIShouldSeeTheErrorMessageDisplayedOnTheEmailAddressField()
        {
            CurrentPage.As<FreeTrialPage>().ValidationErrorMessageDisplayed();
        }
        [Then(@"I should see the Error Message displayed on the Email Address field for omnijoin free trail page")]
        public void ThenIShouldSeeTheErrorMessageDisplayedOnTheEmailAddressFieldForOmnijoinFreeTrailPage()
        {
         CurrentPage.As<FreeTrialPage>().ValidationErrorMessageDisplayed();
        }

        [Then(@"I should see an error message on the first name and last name field")]
        public void ThenIShouldSeeAnErrorMessageOnTheFirstNameAndLastNameField()
        {
            CurrentPage.As<FreeTrialPage>().ValidationErrorMessageDisplayed();
        }
        [Then(@"I should see an error message on Terms and Conditions field")]
        public void ThenIShouldSeeAnErrorMessageOnTermsAndConditionsField()
        {
            CurrentPage.As<FreeTrialPage>().ErrorMessageDisplayedTermsConditionsField();
        }
        [Then(@"I should see an error message on Password Confirmation field")]
        public void ThenIShouldSeeAnErrorMessageOnPasswordConfirmationField()
        {
           CurrentPage.As<FreeTrialPage>().ErrorMessageDisplayedPasswordConfirmationField();
        }
        [Then(@"I should see an error message on Password field")]
        public void ThenIShouldSeeAnErrorMessageOnPasswordField()
        {
            CurrentPage.As<FreeTrialPage>().ErrorMessageDisplayedPasswordFields();
        }
        [When(@"I have entered a Free Trial AutoGenerated email address")]
        public void WhenIHaveEnteredAFreeTrialAutoGeneratedEmailAddress()
        {
            CurrentPage.As<FreeTrialPage>().PopulateEmailAddressTextBox(string.Empty);
        }

        [When(@"I have entered a valid email address")]
        public void WhenIHaveEnteredAValidEmailAddress()
        {
            CurrentPage.As<FreeTrialPage>().PopulateEmailAddressTextBox(Email.RegistrationEmailAddress);
        }

        [When(@"I have entered a valid phone number ""(.*)""")]
        public void WhenIHaveEnteredAValidPhoneNumber(string phoneNumber)
        {
            CurrentPage.As<FreeTrialPage>().PopulatePhoneNumberTextBox(phoneNumber);
        }

        [When(@"I have Agreed to the Free Trial Terms and Conditions")]
        public void WhenIHaveAgreedToTheFreeTrialTermsAndConditions()
        {
            CurrentPage.As<FreeTrialPage>().AgreeToTermsAndConditions();
        }

        [When(@"if I click Submit")]
        public void WhenIfIClickSubmit()
        {
            NextPage = CurrentPage.As<FreeTrialPage>().SubmitButtonClick();
        }
        [When(@"I click Submit without ticking the terms and conditions field")]
        public void WhenIClickSubmitWithoutTickingTheTermsAndConditionsField()
        {
            CurrentPage.As<FreeTrialPage>().SubmitButtonClickBeforeTAndC();
        }

        [Then(@"I should be directed to the download page indicating I have (.*) days Free trial")]
        public void ThenIShouldBeDirectedToTheDownloadPageIndicatingIHaveDaysFreeTrial(int freeTrialPeriod)
        {
            var expiryDate = CurrentPage.As<FreeTrialDownloadPage>().GetTrialExpiryDate();
            var currentDate = DateTime.Today.AddDays(freeTrialPeriod).ToString("dd MMMM yyyy");
            TestCheck.AssertIsEqual(currentDate, expiryDate, "OmniJoin Free Trial - Invalid expiry Date");
        }

        [When(@"I enter a Free Trial Password of ""(.*)""")]
        public void WhenIEnterAFreeTrialPasswordOf(string password)
        {
            CurrentPage.As<FreeTrialPage>().PopulatePasswordTextBox(password);
        }

        [When(@"I enter a Free Trial Password confirmation of ""(.*)""")]
        public void WhenIEnterAFreeTrialPasswordConfirmationOf(string confirmedPassword)
        {
            CurrentPage.As<FreeTrialPage>().PopulateConfirmPasswordTextBox(confirmedPassword);
        }


    #region "Production ("Live") test. DO NOT add Credit Card details steps to the method below
        [Then(@"Create an OmniJoin Free Trial")]
        public void ThenCreateAnOmniJoinFreeTrial()
        {
            ThenIShouldBeDirectedToTheOmniJoinFreeTrialPage();
            WhenIHaveEnteredAValidFirstAndLastName("AutoTest", "AutoTest");
            WhenIHaveEnteredAValidEmailAddress();
            WhenIHaveEnteredAValidPhoneNumber("01555 555555");
            WhenIHaveAgreedToTheFreeTrialTermsAndConditions();
            WhenIfIClickSubmit();
            ThenIShouldBeDirectedToTheDownloadPageIndicatingIHaveDaysFreeTrial(14);
        }
#endregion
      //ADDED NEW STEP METHODS FOR 0JFreeTrailSignUp with BOL Account on Germany Site
        [Then(@"I click on Try Now")]
        public void ThenIClickOnTryNow()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().TryNowOmniJoinFreeTrailButtonClick();
        }

        [Then(@"I should see OmniJOin Free trail page")]
        public void ThenIShouldSeeOmniJOinFreeTrailPage()
        {
            CurrentPage.As<FreeTrialPage>().IsStartFreeTrailOmniJoinButtonAvailable();
        }

        [When(@"I have entered a valid FirstName as ""(.*)""")]
        public void WhenIHaveEnteredAValidFirstNameAs(string firstName)
        {
           CurrentPage.As<FreeTrialPage>().PopulateStartFreeTrailOmniJoinFirstNameTxtBox(firstName);
        }

        [When(@"I have  entered a valid LastName as ""(.*)""")]
        public void WhenIHaveEnteredAValidLastNameAs(string lastName)
        {
         CurrentPage.As<FreeTrialPage>().PopulateStartFreeTrailOmniJoinLastNameTxtBox(lastName);
        }
        [When(@"I have entered a valid company name as ""(.*)""")]
        public void WhenIHaveEnteredAValidCompanyNameAs(string companyName)
        {
         CurrentPage.As<FreeTrialPage>().PopulateStartFreeTrailCompanyNameTxtBox(companyName);   
        }
        [When(@"I have entered a valid phone number as ""(.*)""")]
        public void WhenIHaveEnteredAValidPhoneNumberAs(string phoneNumber)
        {
        CurrentPage.As<FreeTrialPage>().PopulateStartFreeTrailOmniJoinPhoneNumberTxtBox(phoneNumber);
        }
        [When(@"I agreed to the free trail terms and services")]
        public void WhenIAgreedToTheFreeTrailTermsAndServices()
        {
          CurrentPage.As<FreeTrialPage>().AgreeToStartFreeTrailOmniJoinTermsofServices();
        }

        [When(@"I click start free trail button")]
        public void WhenIClickStartFreeTrailButton()
        {
            NextPage = CurrentPage.As<FreeTrialPage>().StartFreeTrailSignUpOmniJoinButtonClick();
        }

        [Then(@"I should be on download page")]
        public void ThenIShouldBeOnDownloadPage()
        {
            CurrentPage.As<FreeTrialDownloadPage>().StartFreeTrail30DaysSignUpTextDisplayed();
        }

    }
}
