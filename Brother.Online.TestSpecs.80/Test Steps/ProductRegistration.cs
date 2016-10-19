
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

        [Given(@"I have entered my product information")]
        public void GivenIHaveEnteredMyProductInformation(Table table)
        {
            //dynamic form = table.CreateInstance<Table>();
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
       [Given(@"I click on continue button")]
       public void GivenIClickOnContinueButton()
       {
           Thread.Sleep(TimeSpan.FromSeconds(3));
           NextPage = CurrentPage.As<ProductRegistrationPage>().ClickContinueButton();
       }
       [Then(@"I can register my ""(.*)"" on  user details page")]
       public void ThenICanRegisterMyOnUserDetailsPage(string emailid)
       {
           CurrentPage.As<UserDetailsPage>().EnterEmailId(emailid);
       }
       [Then(@"I enter ""(.*)""  and ""(.*)"" on  user details page")]
       public void ThenIEnterAndOnUserDetailsPage(string firstname, string lastname)
       {
           CurrentPage.As<UserDetailsPage>().EnterNames(firstname, lastname);
       }
       [Then(@"I tick on terms and conditions checkbox")]
       public void ThenITickOnTermsAndConditionsCheckbox()
       {
           //Thread.Sleep(TimeSpan.FromSeconds(3));
           //var temp = CurrentPage.As<UserDetailsPage>().GetElementByCssSelector("#Terms");
           CurrentPage.As<UserDetailsPage>().ClickAcceptCheckbox();
       }
       [Then(@"I can complete my product registration by clicking on complete registration button")]
       public void ThenICanCompleteMyProductRegistrationByClickingOnCompleteRegistrationButton()
       {
           NextPage = CurrentPage.As<UserDetailsPage>().ClickCompleteRegistrationButton();
       }


    }

}
