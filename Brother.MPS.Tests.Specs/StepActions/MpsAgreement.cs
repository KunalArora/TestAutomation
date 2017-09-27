using System;
using Brother.Tests.Specs.StepActions;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Extensions;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions
{
    public class MpsAgreement : StepActionBase
    {
        private readonly MpsSignIn _mpsSignIn;

        public MpsAgreement(IWebDriver driver,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            MpsSignIn mpsSignIn)
            : base(driver, contextData, pageService, context, urlResolver)
        {
            _mpsSignIn = mpsSignIn;
        }

        public DealerDashBoardPage SignInAsDealerAndNavigateToDashboard(string email, string password, string url)
        {
            return _mpsSignIn.SignInAsDealer(email, password, url);
        }

        public DealerAgreementsCreateDescriptionPage NavigateToCreateAgreementPage(DealerDashBoardPage dealerDashboardPage)
        {
            dealerDashboardPage.CreateAgreementLinkElement.Click();
            return PageService.GetPageObject<DealerAgreementsCreateDescriptionPage>(10);
        }

        public void PopulateAgreementDescription(DealerAgreementsCreateDescriptionPage dealerAgreementsCreateDescriptionPage,
            string agreementName,
            string leadCodeReference,
            string dealerReference,
            string leasingReference)
        {
            dealerAgreementsCreateDescriptionPage.AgreementNameField.Clear();
            dealerAgreementsCreateDescriptionPage.AgreementNameField.SendKeys(agreementName);
        }
    }
}
