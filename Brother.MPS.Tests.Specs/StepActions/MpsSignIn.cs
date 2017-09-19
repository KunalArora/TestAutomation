using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Extensions;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
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
            ScenarioContext context,
            IUrlResolver urlResolver) : base(driver, contextData, pageService, context, urlResolver)
        {
            
        }

        public DealerDashBoardPage SignInAsDealer(string email, string password, string url)
        {
            var signInPage = LoadAtYourSideSignInPage(url);
            return SignInToMpsDashboardAs<DealerDashBoardPage>(signInPage, email, password, string.Format("{0}/mps/dealer/dashboard", UrlResolver.BaseUrl));
        }

        public SignInAtYourSidePage LoadAtYourSideSignInPage(string url)
        {
            var signInPage = PageService.LoadAtYourSideSignInPage();
            ScenarioContext.SetCurrentPage(signInPage);
            return signInPage;
        }

        private TPage SignInToMpsDashboardAs<TPage>(SignInAtYourSidePage signInAtYourSidePage, string email, string password, string dashboardUrl) where TPage : BasePage, IPageObject, new()
        {
            //TODO: form dashboard url from context data base url and TPage.url
            signInAtYourSidePage.PopulateEmailAddressTextBox(email);
            signInAtYourSidePage.PopulatePassword(password);
            signInAtYourSidePage.SignInButton.Click();
            var myAccountPage = PageService.GetPageObject<MyAccountAtYourSidePage>(10);
            return PageService.LoadUrl<TPage>(dashboardUrl, 60, "div.mps-dashboard", true);
        }
    }
}
