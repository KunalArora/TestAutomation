using System;
using Brother.Tests.Specs.StepActions;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Extensions;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement;
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

        public DealerAgreementCreateDescriptionPage NavigateToCreateAgreementPage(DealerDashBoardPage dealerDashboardPage)
        {
            dealerDashboardPage.CreateAgreementLinkElement.Click();
            return PageService.GetPageObject<DealerAgreementCreateDescriptionPage>(10);
        }

        public DealerAgreementCreateTermAndTypePage PopulateAgreementDescriptionAndProceed(DealerAgreementCreateDescriptionPage dealerAgreementCreateDescriptionPage,
            string agreementName,
            string leadCodeReference,
            string dealerReference,
            string leasingReference)
        {
            PopulateAgreementDescription(dealerAgreementCreateDescriptionPage, agreementName, leadCodeReference, dealerReference, leasingReference);

            dealerAgreementCreateDescriptionPage.NextButton.Click();
            return PageService.GetPageObject<DealerAgreementCreateTermAndTypePage>(10);
        }

        public DealerAgreementCreateProductsPage PopulateAgreementTermAndTypeAndProceed(DealerAgreementCreateTermAndTypePage dealerAgreementCreateTermAndTypePage,
            string usageType,
            string contractLength,
            string servicePackOption)
        {
            dealerAgreementCreateTermAndTypePage.SelectUsageType(usageType);
            dealerAgreementCreateTermAndTypePage.SelectContractLength(contractLength);
            
            dealerAgreementCreateTermAndTypePage.NextButton.Click();
            return PageService.GetPageObject<DealerAgreementCreateProductsPage>(10);
        }

        private void PopulateAgreementDescription(DealerAgreementCreateDescriptionPage dealerAgreementCreateDescriptionPage,
            string agreementName,
            string leadCodeReference,
            string dealerReference,
            string leasingReference)
        {
            dealerAgreementCreateDescriptionPage.AgreementNameField.Clear();
            dealerAgreementCreateDescriptionPage.AgreementNameField.SendKeys(agreementName);
        }
    }
}
