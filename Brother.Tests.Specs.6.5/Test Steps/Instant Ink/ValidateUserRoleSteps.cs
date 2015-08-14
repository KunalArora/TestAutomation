using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace Brother.Tests.Specs
{
    [Binding]
    public class ValidateUserRoleSteps : BaseSteps
    {

        [Given(@"I have been granted the user account with the ""(.*)"" role")]
        public void GivenIHaveBeenGrantedTheUserAccountWithTheRole(string userRole)
        {
            Utils.GrantUserRole(Email.RegistrationEmailAddress, userRole);
        }

        [Given(@"I can see the Ink Supply menu option from the Bol home page")]
        [Then(@"I can see the Ink Supply menu option from the Bol home page")]
        public void ThenICanSeeTheInkSupplyMenuOptionFromTheBolHomePage()
        {
            CurrentPage.As<WelcomeBackPage>().IsInkSupplyMenuItemAvailable();
        }

        [When(@"I click Ink Supply button")]
        [Given(@"Ink Supply is clicked")]
        [Then(@"Ink Supply is clicked")]
        public void ThenIfInkSupplyIsClicked()
        {
            CurrentPage.As<WelcomeBackPage>().InkSupplyMenuItemClick();
        }


        [When(@"I can see the Ink Supply header with name ""(.*)""")]
        public void WhenICanSeeTheInkSupplyHeaderWithName(string title)
        {
            CurrentPage.As<WelcomeBackPage>().VerifyContainerheader(title);
        }

        [Then(@"device name ""(.*)""should be displayed")]
        public void ThenDeviceNameShouldBeDisplayed(string devicename)
        {
            if (CurrentPage != null) CurrentPage.As<WelcomeBackPage>().VerifyInkDeviceName(devicename);
        }

        [Then(@"device serial number ""(.*)"" should be displayed")]
        public void ThenDeviceSerialNumberShouldBeDisplayed(string serialnumber)
        {
            if (CurrentPage != null) CurrentPage.As<WelcomeBackPage>().VerifyInkDeviceSerialNumber(serialnumber);
        }
    }
}
