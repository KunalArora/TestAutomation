using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Proposal
{
    public class MpsDealerProposalStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IWebDriver _dealerWebDriver;

        public MpsDealerProposalStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            RuntimeSettings runtimeSettings,
            MpsSignInStepActions mpsSignIn)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
        }
        
        public DealerDashBoardPage SignInAsDealerAndNavigateToDashboard(string email, string password, string url)
        {
            return _mpsSignIn.SignInAsDealer(email, password, url);
        }

        public DealerProposalsCreateDescriptionPage NavigateToCreateAgreementPage(DealerDashBoardPage dealerDashboardPage)
        {
            dealerDashboardPage.CreateAgreementLinkElement.Click();
            return PageService.GetPageObject<DealerProposalsCreateDescriptionPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateTermAndTypePage PopulateAgreementDescriptionAndProceed(DealerProposalsCreateDescriptionPage dealerProposalsCreateDescriptionPage,
            string agreementName,
            string leadCodeReference,
            string dealerReference,
            string leasingReference)
        {
            //PopulateProposalDescription(dealerProposalsCreateDescriptionPage, agreementName, leadCodeReference, dealerReference, leasingReference);

            dealerProposalsCreateDescriptionPage.NextButton.Click();
            return PageService.GetPageObject<DealerProposalsCreateTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateProductsPage PopulateAgreementTermAndTypeAndProceed(DealerProposalsCreateTermAndTypePage dealerProposalsCreateTermAndTypePage,
            string usageType,
            string contractLength,
            string servicePackOption)
        {
            dealerProposalsCreateTermAndTypePage.SelectUsageType(usageType);
            dealerProposalsCreateTermAndTypePage.SelectContractLength(contractLength);

            dealerProposalsCreateTermAndTypePage.NextButton.Click();
            return PageService.GetPageObject<DealerProposalsCreateProductsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateClickPricePage AddPrinterToAgreementAndProceed(DealerProposalsCreateProductsPage dealerProposalsCreateProductsPage,
            string printerName,
            int quantity,
            string installationPack,
            string servicePack)
        {
            //PopulatePrinterDetails(dealerProposalsCreateProductsPage, printerName, quantity, installationPack, servicePack, true);
            return PageService.GetPageObject<DealerProposalsCreateClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateSummaryPage CalculateClickPriceAndProceed(DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage)
        {
            PopulatePrinterCoverageAndVolume(5,500);
            dealerProposalsCreateClickPricePage.CalculateClickPriceElement.Click();
            if(VerifyClickPriceValues())
            {
                dealerProposalsCreateClickPricePage.ProceedOnClickPricePageElement.Click();
                return PageService.GetPageObject<DealerProposalsCreateSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            }
            return null;
        }

        #region private methods

        private void PopulateAgreementDescription(DealerProposalsCreateDescriptionPage dealerProposalsCreateDescriptionPage,
            string agreementName,
            string leadCodeReference,
            string dealerReference,
            string leasingReference)
        {
            dealerProposalsCreateDescriptionPage.ProposalNameField.Clear();
            dealerProposalsCreateDescriptionPage.ProposalNameField.SendKeys(agreementName);
        }

        private void PopulatePrinterDetails(DealerProposalsCreateProductsPage dealerProposalsCreateProductsPage,
            string printerName,
            int quantity,
            string installationPack,
            string servicePack,
            bool continueToClickPrice)
        {
            //dealerProposalsCreateProductsPage.PopulatePrinterDetails(printerName, quantity, installationPack, servicePack, continueToClickPrice);
        }

        private void PopulatePrinterCoverageAndVolume(int coverage, int volume)
        {

        }

        private bool VerifyClickPriceValues()
        {
            return false;
        }

        #endregion
    }
}
