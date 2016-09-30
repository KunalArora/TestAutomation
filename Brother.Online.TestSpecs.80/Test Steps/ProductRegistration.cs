
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
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
        [Given(@"clicked on Find Product Butoon")]
        public void GivenClickedOnFindProductButoon()
        {
            CurrentPage.As<ProductRegistrationPage>().ClickFindProductButton();
        }

    }

}
