using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using TechTalk.SpecFlow;

namespace Brother.Online.TestSpecs._80.Test_Steps
{  
    [Binding]
    public class ExistingUser : BaseSteps
    {
        [Given(@"I browse to the ""(.*)"" for existing user signin page")]
        public void GivenIBrowseToTheForExistingUserSigninPage(string url)
        {
            CurrentPage = BasePage.LoadSignPage(CurrentDriver, url);
        }

        [Given(@"I click on existing customer log in option")]
        public void GivenIClickOnExistingCustomerLogInOption()
        {
           CurrentPage.As<SignInPage>().ClickExistingUserTab();
        }
        [When(@"I click on Forgot Password")]
        public void WhenIClickOnForgotPassword()
        {
            CurrentPage.As<SignInPage>().ClickForgottenPasswordLink();
        }


    }
}



