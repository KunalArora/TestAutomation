using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Proposal
{
    public class MpsDealerProposalStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IContextData _contextData;
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
            _contextData = contextData;
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

        public DealerProposalsCreateProductsPage PopulateProposalTermAndTypeAndProceed(DealerProposalsCreateTermAndTypePage dealerProposalsCreateTermAndTypePage,
            string usageType,
            string contractLength,
            string billingType,
            string servicePackOption)
        {
            // Populate Term and Type page for Type 1
            dealerProposalsCreateTermAndTypePage.PopulateTermAndTypeForType1(usageType, contractLength, billingType, servicePackOption, RuntimeSettings.DefaultFindElementTimeout);
            dealerProposalsCreateTermAndTypePage.NextButton.Click();
            return PageService.GetPageObject<DealerProposalsCreateProductsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateClickPricePage AddPrinterToProposalAndProceed(DealerProposalsCreateProductsPage dealerProposalsCreateProductsPage,
            IEnumerable<PrinterProperties> products)
        {
            foreach (var product in products)
            {
                PopulatePrinterDetails(dealerProposalsCreateProductsPage, product.Model, product.Price, product.Installation, product.IncludeDelivery);
            }
            dealerProposalsCreateProductsPage.NextButtonClick();
            return PageService.GetPageObject<DealerProposalsCreateClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerProposalsCreateSummaryPage CalculateClickPriceAndProceed(DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage,
            IEnumerable<PrinterProperties> products)
        {
            foreach (var product in products)
            {
                PopulatePrinterCoverageAndVolume(dealerProposalsCreateClickPricePage, product.Model, product.CoverageMono, product.CoverageColour, product.VolumeMono, product.VolumeColour);
            }
            dealerProposalsCreateClickPricePage.CalculateClickPriceElement.Click();
            
            if(VerifyClickPriceValues(dealerProposalsCreateClickPricePage))
            {
                dealerProposalsCreateClickPricePage.ProceedOnClickPricePageElement.Click();
                return PageService.GetPageObject<DealerProposalsCreateSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            }
             
            return null;
        }

        public CloudExistingProposalPage SaveTheProposalAndProceed(DealerProposalsCreateSummaryPage dealerProposalsCreateSummaryPage)
        {
            int proposalId = dealerProposalsCreateSummaryPage.SaveProposalAndReturnContractId();
            _contextData.ProposalId = proposalId;
            return PageService.GetPageObject<CloudExistingProposalPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifySavedProposalInOpenProposalsList(CloudExistingProposalPage cloudExistingProposalPage, int proposalId, string proposalName)
        {
            bool exists = cloudExistingProposalPage.VerifySavedProposalInOpenProposalsList( proposalId, proposalName, RuntimeSettings.DefaultFindElementTimeout);
            if (exists)
            {
                return;
            }
            else
            {
                new NullReferenceException(string.Format("Proposal = {0} not found ", proposalId));
            }             
        }

        #region private methods

        private void PopulateProposalDescription(DealerProposalsCreateDescriptionPage dealerProposalsCreateDescriptionPage,
            string proposalName,
            string leadCodeReference,
            string contractType)
        {
            dealerProposalsCreateDescriptionPage.PopulateProposalName(proposalName);
        }

        private void PopulatePrinterDetails(DealerProposalsCreateProductsPage dealerProposalsCreateProductsPage,
            string printerName,
            string printerPrice,
            string installationPack,
            bool delivery)
        {
            dealerProposalsCreateProductsPage.PopulatePrinterDetails(printerName, printerPrice, installationPack, delivery, RuntimeSettings.DefaultFindElementTimeout);
        }

        private void PopulatePrinterCoverageAndVolume( DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage,
            string printerName, int coverageMono, int coverageColour, int volumeMono, int volumeColour)
        {
            dealerProposalsCreateClickPricePage.PopulatePrinterCoverageAndVolume( 
                printerName, 
                coverageMono, 
                coverageColour, 
                volumeMono, 
                volumeColour, 
                RuntimeSettings.DefaultFindElementTimeout );
        }

        private bool VerifyClickPriceValues(DealerProposalsCreateClickPricePage dealerProposalsCreateClickPricePage)
        {
            return dealerProposalsCreateClickPricePage.VerifyClickPriceValues(RuntimeSettings.DefaultPageObjectTimeout);
        }


        #endregion
    }
}
