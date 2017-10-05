using System;
using Brother.Tests.Specs.Factories;
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
            IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            MpsSignIn mpsSignIn)
            : base(driver, webDriverFactory, contextData, pageService, context, urlResolver)
        {
            _mpsSignIn = mpsSignIn;
        }
        //TODO: make all of the calls which specify a timeout pull the timeout value from config / command line
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

        public DealerAgreementCreateClickPricePage AddPrinterToAgreementAndProceed(DealerAgreementCreateProductsPage dealerAgreementCreateProductsPage, 
            string printerName,
            int quantity,
            string installationPack,
            string servicePack)
        {
            PopulatePrinterDetails(dealerAgreementCreateProductsPage, printerName, quantity, installationPack, servicePack, true);
            return PageService.GetPageObject<DealerAgreementCreateClickPricePage>(10);
        }

        public DealerAgreementCreateSummaryPage PopulateCoverageAndVolumeAndProceed(DealerAgreementCreateClickPricePage dealerAgreementCreateClickPricePage)
        {
            //TODO: initial values exist for T3, can proceed for now - need to add population of fields
            dealerAgreementCreateClickPricePage.NextButton.Click();
            return PageService.GetPageObject<DealerAgreementCreateSummaryPage>(10);
        }

        #region private methods

        private void PopulateAgreementDescription(DealerAgreementCreateDescriptionPage dealerAgreementCreateDescriptionPage,
            string agreementName,
            string leadCodeReference,
            string dealerReference,
            string leasingReference)
        {
            dealerAgreementCreateDescriptionPage.AgreementNameField.Clear();
            dealerAgreementCreateDescriptionPage.AgreementNameField.SendKeys(agreementName);
        }

        private void PopulatePrinterDetails(DealerAgreementCreateProductsPage dealerAgreementCreateProductsPage,
            string printerName,
            int quantity,
            string installationPack,
            string servicePack,
            bool continueToClickPrice)
        {
            dealerAgreementCreateProductsPage.PopulatePrinterDetails(printerName, quantity, installationPack, servicePack, continueToClickPrice);
        }

        #endregion
    }
}
