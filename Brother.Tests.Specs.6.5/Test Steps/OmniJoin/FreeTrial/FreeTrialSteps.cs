using System;
using Brother.Tests.Selenium.Lib.Pages.Base;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.AccountManagement;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.ThirdParty;
using Brother.Tests.Selenium.Lib.Pages.OmniJoin;
using Brother.Tests.Selenium.Lib.Pages.OmniJoin.Trial;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.OmniJoin.FreeTrial
{
    [Binding]
    public class FreeTrialSteps : BaseSteps
    {
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

        [Then(@"I should be directed to the download page indicating I have (.*) days Free trial")]
        public void ThenIShouldBeDirectedToTheDownloadPageIndicatingIHaveDaysFreeTrial(int freeTrialPeriod)
        {
            var expiryDate = CurrentPage.As<FreeTrialDownloadPage>().GetTrialExpiryDate();
            var currentDate = DateTime.Today.AddDays(freeTrialPeriod).ToString("dd MMMM yyyy");
            Assert.AreEqual(currentDate, expiryDate, "OmniJoin Free Trial - Invalid expiry Date");
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

    }
}
