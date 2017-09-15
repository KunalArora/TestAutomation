using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Extensions;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions
{
    public class MpsSignIn : StepActionBase
    {
        public MpsSignIn (IWebDriver driver,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context) : base(driver, contextData, pageService, context)
        {
            
        }

        public DealerDashBoardPage SignInAsDealer(string email, string password, string url)
        {
            var signInPage = LoadAtYourSideSignInPage(url);
            return SignInToMpsDashboardAs<DealerDashBoardPage>(signInPage, email, password, "https://online65.co.uk.cds.uat.brother.eu.com/mps/dealer/dashboard");
        }

        public SignInAtYourSidePage LoadAtYourSideSignInPage(string url)
        {
            var signInPage = PageService.LoadAtYourSideSignInPage();
            ScenarioContext.SetCurrentPage(signInPage);
            return signInPage;
        }

        private TPage SignInToMpsDashboardAs<TPage>(SignInAtYourSidePage signInAtYourSidePage, string email, string password, string dashboardUrl) where TPage : BasePage, new()
        {
            //TODO: form dashboard url from context data base url and TPage.url
            signInAtYourSidePage.PopulateEmailAddressTextBox(email);
            signInAtYourSidePage.PopulatePassword(password);
            signInAtYourSidePage.SignInButton.Click();
            var myAccountPage = PageService.GetPageObject<MyAccountAtYourSidePage>();
            return PageService.LoadUrl<TPage>(dashboardUrl, 10, "div.mps-dashboard", true);
        }
    }
}
