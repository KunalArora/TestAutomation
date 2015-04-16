using System;
using System.Collections.Generic;
using System.Linq;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Account;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.AccountManagement;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.BrotherOnline.AccountManagement;
using NUnit.Framework;
using OpenQA.Selenium;
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

        
       [Given(@"that I have an Ink Supply role to my Bol account")]
        public void GivenThatIHaveAnInkSupplyRoleToMyBolAccount()
        {
          var menuItem = GlobalNavigationModule.GetProductNavigationMenu("Ink Supply");
        }

        
        [Given(@"I can see the Ink Supply menu option from the Bol home page")]
        [Then(@"I can see the Ink Supply menu option from the Bol home page")]
        public void ThenICanSeeTheInkSupplyMenuOptionFromTheBolHomePage()
        {
            var menuItem = GlobalNavigationModule.GetProductNavigationMenu("InstantInk");
            Assert.AreNotEqual(null, menuItem);
        }


        [When(@"I click Ink Supply button")]
        [Given(@"Ink Supply is clicked")]
        [Then(@"Ink Supply is clicked")]
        
        public void ThenIfInkSupplyIsClicked()
        {
            var menuItem = GlobalNavigationModule.GetProductNavigationMenu("InstantInk");
            menuItem.Click();
            //CurrentPage.As<WelcomeBackPage>().IsInkDevicePropertiesContainerAvailable();
            //CurrentPage.As<WelcomeBackPage>().VerifyInkDeviceName("MFC-J5720DW");
            //IList<IWebElement> element = RegistrationPage.InkStatusSummaryListElementAvailable();
            //Console.WriteLine(element.First());
            //Console.WriteLine(element.ElementAt(2));
            //Console.WriteLine(element.ElementAt(3));
            //Console.WriteLine(element.Last());


        }


        [When(@"I can see the Ink Supply header with name ""(.*)""")]
        public void WhenICanSeeTheInkSupplyHeaderWithName(string title)
        {
            //IWebElement title = CurrentDriver.FindElement(By.ClassName());
            CurrentPage.As<WelcomeBackPage>().VerifyContainerheader(title);
        }


        /*
        [When(@"I click on the Status Monitor")]
        public void WhenIClickOnTheStatusMonitor()
        {
            //var statusMonitorButton = GlobalNavigationModule.GetInstantInkMenuButton("StatusMonitor");
            //NextPage = GlobalNavigationModule.StatusMonitorButtonClick(CurrentDriver, statusMonitorButton);
            //<RegistrationPage>.(Email.RegistrationEmailAddress, userRole);
        }

        [Then(@"I can see the Status Monitor page")]
        public void ThenICanSeeTheStatusMonitorPage()
        {
            ScenarioContext.Current.Pending();
   
        }
        */

        /*
        [Then(@"device name should be displayed")]
        public void ThenDeviceNameShouldBeDisplayed()
        {
            ScenarioContext.Current.Pending();
        }*/


        [Then(@"device name ""(.*)""should be displayed")]
        public void ThenDeviceNameShouldBeDisplayed(string devicename)
        {
            if (CurrentPage != null) CurrentPage.As<WelcomeBackPage>().VerifyInkDeviceName(devicename);
        }

        [Then(@"the device nw status should be shown as online")]
        public void ThenTheDeviceNwStatusShouldBeShownAsOnline()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"the device contract should be displayed\.")]
        public void ThenTheDeviceContractShouldBeDisplayed_()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the device status is shown as online")]
        public void ThenTheDeviceStatusIsShownAsOnline()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the device serial no\. should be displayed\.")]
        public void ThenTheDeviceSerialNo_ShouldBeDisplayed_()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the product title should be displayed\.")]
        public void ThenTheProductTitleShouldBeDisplayed_()
        {
            ScenarioContext.Current.Pending();
        }

        }
}
