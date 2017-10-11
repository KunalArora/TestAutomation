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

        public DealerProposalsCreateDescriptionPage NavigateToCreateProposalPage(DealerDashBoardPage dealerDashboardPage)
        {
            dealerDashboardPage.CreateProposalLinkElement.Click();
            return PageService.GetPageObject<DealerProposalsCreateDescriptionPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateCustomerInformationPage PopulateProposalDescriptionAndProceed(DealerProposalsCreateDescriptionPage dealerProposalsCreateDescriptionPage,
            string proposalName,
            string leadCodeReference,
            string contractType)
        {
            PopulateProposalDescription(dealerProposalsCreateDescriptionPage, proposalName, leadCodeReference, contractType);

            dealerProposalsCreateDescriptionPage.NextButton.Click();
            return PageService.GetPageObject<DealerProposalsCreateCustomerInformationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateTermAndTypePage PopulateProposalCustomerInformationAndProceed(DealerProposalsCreateCustomerInformationPage dealerProposalsCreateCustomerInformationPage, CustomerInformationOption customerInformationOption)
        {
            switch (customerInformationOption)
            {
                    case CustomerInformationOption.Existing:
                        //SelectExistingCustomer()
                        break;
                    case CustomerInformationOption.New:
                        //CreateNewCustomer();
                        break;
                    case CustomerInformationOption.Skip:
                        dealerProposalsCreateCustomerInformationPage.SkipCustomerElement.Click();
                        dealerProposalsCreateCustomerInformationPage.NextButton.Click();
                    break;
            }
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

        private void PopulateProposalDescription(DealerProposalsCreateDescriptionPage dealerProposalsCreateDescriptionPage,
            string proposalName,
            string leadCodeReference,
            string contractType)
        {
            dealerProposalsCreateDescriptionPage.ProposalNameField.Clear();
            dealerProposalsCreateDescriptionPage.ProposalNameField.SendKeys(proposalName);
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
