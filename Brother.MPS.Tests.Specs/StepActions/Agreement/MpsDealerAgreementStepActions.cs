using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;


namespace Brother.Tests.Specs.StepActions.Agreement
{
    public class MpsDealerAgreementStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IWebDriver _dealerWebDriver;
        private readonly ITranslationService _translationService;
        private readonly IContextData _contextData;

        public MpsDealerAgreementStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ITranslationService translationService,
            IRuntimeSettings runtimeSettings,
            MpsSignInStepActions mpsSignIn)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _translationService = translationService;
            _contextData = contextData;
        }
        //TODO: make all of the calls which specify a timeout pull the timeout value from config / command line
        public DealerDashBoardPage SignInAsDealerAndNavigateToDashboard(string email, string password, string url)
        {
            return _mpsSignIn.SignInAsDealer(email, password, url);
        }

        public DealerAgreementCreateDescriptionPage NavigateToCreateAgreementPage(DealerDashBoardPage dealerDashboardPage)
        {
            dealerDashboardPage.CreateAgreementLinkElement.Click();
            return PageService.GetPageObject<DealerAgreementCreateDescriptionPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementCreateTermAndTypePage PopulateAgreementDescriptionAndProceed(DealerAgreementCreateDescriptionPage dealerAgreementCreateDescriptionPage,
            string agreementName,
            string leadCodeReference = "",
            string dealerReference = "",
            string leasingReference = "")
        {
            _contextData.AgreementName = agreementName;
            PopulateAgreementDescription(dealerAgreementCreateDescriptionPage, agreementName, leadCodeReference, dealerReference, leasingReference);

            dealerAgreementCreateDescriptionPage.NextButton.Click();
            return PageService.GetPageObject<DealerAgreementCreateTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementCreateProductsPage PopulateAgreementTermAndTypeAndProceed(DealerAgreementCreateTermAndTypePage dealerAgreementCreateTermAndTypePage,
            string usageType,
            string contractLength,
            string servicePackOption)
        {
            dealerAgreementCreateTermAndTypePage.SelectUsageType(usageType);
            dealerAgreementCreateTermAndTypePage.SelectContractLength(contractLength);
            dealerAgreementCreateTermAndTypePage.SelectService(servicePackOption);
            
            dealerAgreementCreateTermAndTypePage.NextButton.Click();
            return PageService.GetPageObject<DealerAgreementCreateProductsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        // TODO: Refactor this function
        public DealerAgreementCreateClickPricePage AddPrinterToAgreementAndProceed(DealerAgreementCreateProductsPage dealerAgreementCreateProductsPage, 
            string printerName,
            int quantity,
            string installationPack,
            string servicePack)
        {
            PopulatePrinterDetails(dealerAgreementCreateProductsPage, printerName, quantity, installationPack, servicePack);
            ClickSafety(dealerAgreementCreateProductsPage.NextButton, dealerAgreementCreateProductsPage);
            return PageService.GetPageObject<DealerAgreementCreateClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementCreateClickPricePage AddThesePrintersToAgreementAndProceed(DealerAgreementCreateProductsPage dealerAgreementCreateProductsPage,
            IEnumerable<PrinterProperties> products)
        {
            foreach (var product in products)
            {
                PopulatePrinterDetails(dealerAgreementCreateProductsPage, product.Model, product.Quantity, product.InstallationPack, product.ServicePack);
            }
            ClickSafety(dealerAgreementCreateProductsPage.NextButton, dealerAgreementCreateProductsPage);
            return PageService.GetPageObject<DealerAgreementCreateClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementCreateSummaryPage PopulateCoverageAndVolumeAndProceed(
            DealerAgreementCreateClickPricePage dealerAgreementCreateClickPricePage,
            IEnumerable<PrinterProperties> products)
        {
            foreach (var product in products)
            {
                PopulatePrinterCoverageAndVolume(dealerAgreementCreateClickPricePage, 
                    product.Model, product.CoverageMono, product.VolumeMono, product.CoverageColour, product.VolumeColour);
            }

            // Click Next button until the URL of the driver changes
            while(_dealerWebDriver.Url.Contains(dealerAgreementCreateClickPricePage.PageUrl))
            {
                ClickSafety(dealerAgreementCreateClickPricePage.NextButton, dealerAgreementCreateClickPricePage);
            }
            
            return PageService.GetPageObject<DealerAgreementCreateSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementsListPage ValidateSummaryPageAndCompleteSetup(DealerAgreementCreateSummaryPage dealerAgreementCreateSummaryPage)
        {
            _contextData.AgreementId = dealerAgreementCreateSummaryPage.AgreementId();
            ClickSafety(dealerAgreementCreateSummaryPage.CompleteSetupButton, dealerAgreementCreateSummaryPage);
            dealerAgreementCreateSummaryPage.AcceptJavascriptPopupOnCompleteSetup(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<DealerAgreementsListPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifyCreatedAgreement(DealerAgreementsListPage dealerAgreementsListPage)
        {
            bool exists = dealerAgreementsListPage.VerifyCreatedAgreement(_contextData.AgreementId, _contextData.AgreementName, RuntimeSettings.DefaultFindElementTimeout);
            if (!exists)
            {
                throw new Exception(string.Format("Agreement = {0} not found ", _contextData.AgreementId));
            }    
        }

        public DealerAgreementDevicesPage NavigateToManageDevicesPage(DealerAgreementsListPage dealerAgreementsListPage)
        {
            dealerAgreementsListPage.ClickOnManageDevicesButton(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementDevicesPage EditDeviceDataOneByOne(DealerAgreementDevicesPage dealerAgreementDevicesPage, string NonMandatory)
        {
            foreach(var product in _contextData.PrintersProperties)
            {
                dealerAgreementDevicesPage.ClickOnEditDeviceData(product.Model, RuntimeSettings.DefaultFindElementTimeout);
                var dealerAgreementDevicesEditPage = PageService.GetPageObject<DealerAgreementDevicesEditPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                dealerAgreementDevicesEditPage.EditDeviceData(NonMandatory);
                ClickSafety(dealerAgreementDevicesEditPage.SaveButtonElement, dealerAgreementDevicesEditPage);
                dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            }
            return dealerAgreementDevicesPage;
        }

        public void VerifyStatusOfDevices(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            dealerAgreementDevicesPage.VerifyThatDevicesAreReadyForInstallation(RuntimeSettings.DefaultFindElementTimeout);
        }

        public DealerAgreementDevicesPage EditDeviceDataUsingBulkEditOption(DealerAgreementDevicesPage dealerAgreementDevicesPage, string NonMandatory)
        {
            ClickSafety(dealerAgreementDevicesPage.CheckboxSelectAllElement, dealerAgreementDevicesPage);
            ClickSafety(dealerAgreementDevicesPage.EditDeviceDataBulkElement, dealerAgreementDevicesPage);
            var dealerAgreementDevicesEditPage = PageService.GetPageObject<DealerAgreementDevicesEditPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            dealerAgreementDevicesEditPage.EditDeviceData(NonMandatory);
            ClickSafety(dealerAgreementDevicesEditPage.SaveButtonElement, dealerAgreementDevicesEditPage);
            return PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
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

            dealerAgreementCreateDescriptionPage.LeadCodeReferenceField.Clear();
            dealerAgreementCreateDescriptionPage.LeadCodeReferenceField.SendKeys(leadCodeReference);

            dealerAgreementCreateDescriptionPage.DealerReferenceField.Clear();
            dealerAgreementCreateDescriptionPage.DealerReferenceField.SendKeys(dealerReference);

            dealerAgreementCreateDescriptionPage.LeasingFinanceReferenceField.Clear();
            dealerAgreementCreateDescriptionPage.LeasingFinanceReferenceField.SendKeys(leasingReference);
        }

        private void PopulatePrinterDetails(DealerAgreementCreateProductsPage dealerAgreementCreateProductsPage,
            string printerName,
            int quantity,
            string installationPack,
            string servicePack
            )
        {
            dealerAgreementCreateProductsPage.PopulatePrinterDetails(
                printerName, 
                quantity, 
                installationPack, 
                servicePack,
                RuntimeSettings.DefaultFindElementTimeout);
        }

        private void PopulatePrinterCoverageAndVolume(DealerAgreementCreateClickPricePage dealerAgreementCreateClickPricePage, string printerName, int monoCoverage, int monoVolume, int colorCoverage, int colorVolume)
        {
            dealerAgreementCreateClickPricePage.PopulatePrinterCoverageAndVolume(
                printerName, monoCoverage, monoVolume, colorCoverage, colorVolume, 
                RuntimeSettings.DefaultFindElementTimeout);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }

        #endregion
    }
}
