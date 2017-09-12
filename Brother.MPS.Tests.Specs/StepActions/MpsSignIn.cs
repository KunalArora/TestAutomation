using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            LoadAtYourSideSignInPage(url).IsSignInButtonAvailable();
            return new DealerDashBoardPage();
        }

        public SignInAtYourSidePage LoadAtYourSideSignInPage(string url)
        {
            var signInPage = PageService.LoadAtYourSideSignInPage();
            ScenarioContext.SetCurrentPage(signInPage);
            return new SignInAtYourSidePage();
        }

        private TPage SignInAs<TPage>(SignInAtYourSidePage signInAtYourSidePage, string email, string password) where TPage : BasePage, new()
        {
                       
        }
    }
}
