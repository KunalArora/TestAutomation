using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
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
        private readonly IExcelHelper _excelHelper;
        private readonly ICalculationService _calculationService;

        public MpsDealerAgreementStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ITranslationService translationService,
            IRuntimeSettings runtimeSettings,
            MpsSignInStepActions mpsSignIn,
            IExcelHelper excelHelper,
            ICalculationService calculationService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _translationService = translationService;
            _contextData = contextData;
            _excelHelper = excelHelper;
            _calculationService = calculationService;
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
            _contextData.LeadCodeReference = leadCodeReference;
            _contextData.DealerReference = dealerReference;
            _contextData.LeasingFinanceReference = leasingReference;

            PopulateAgreementDescription(dealerAgreementCreateDescriptionPage, agreementName, leadCodeReference, dealerReference, leasingReference);

            ClickSafety(dealerAgreementCreateDescriptionPage.NextButton, dealerAgreementCreateDescriptionPage);
            return PageService.GetPageObject<DealerAgreementCreateTermAndTypePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementCreateProductsPage PopulateAgreementTermAndTypeAndProceed(DealerAgreementCreateTermAndTypePage dealerAgreementCreateTermAndTypePage,
            string usageType,
            string contractLength,
            string servicePackOption)
        {
            // Validate that Service Pack Option available to choose is only 'Pay upfront' in case of Usage type being 'Pay As You Go'
            dealerAgreementCreateTermAndTypePage.ValidateServicePackAvailableOptions();

            _contextData.UsageType = usageType;
            _contextData.ContractTerm = contractLength;
            _contextData.ServicePackType = servicePackOption;

            dealerAgreementCreateTermAndTypePage.SelectUsageType(usageType);
            dealerAgreementCreateTermAndTypePage.SelectContractLength(contractLength);
            dealerAgreementCreateTermAndTypePage.SelectService(servicePackOption);

            ClickSafety(dealerAgreementCreateTermAndTypePage.NextButton, dealerAgreementCreateTermAndTypePage);
            return PageService.GetPageObject<DealerAgreementCreateProductsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
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
            
            // Validate calculations/content on summary page
            ValidateCalculationOnSummaryPage(dealerAgreementCreateSummaryPage);

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
            var dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            
            // Verify that all devices are in "address required" state
            dealerAgreementDevicesPage.VerifyTheStatusOfAllDevices(
                RuntimeSettings.DefaultFindElementTimeout, "address required"); // TODO: Translation

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage EditDeviceDataOneByOne(DealerAgreementDevicesPage dealerAgreementDevicesPage, string optionalFields)
        {
            string validationExpression;
            var deviceRowCount = dealerAgreementDevicesPage.DeviceTableRowsCount();
            for (int rowIndex = 0; rowIndex < deviceRowCount; rowIndex++)
            {
                dealerAgreementDevicesPage.ClickOnEditDeviceData(
                    rowIndex, RuntimeSettings.DefaultFindElementTimeout);
                dealerAgreementDevicesPage = EditDeviceDataHelper(optionalFields, out validationExpression);
                
                // Validate address field of edited device
                dealerAgreementDevicesPage.VerifyAddressOfEditedDevice(rowIndex, validationExpression);

            }
            return dealerAgreementDevicesPage;
        }

        public void VerifyStatusOfDevices(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            // Verify that all devices are in "ready for install" state
            dealerAgreementDevicesPage.VerifyTheStatusOfAllDevices(
                RuntimeSettings.DefaultFindElementTimeout, "ready for install"); // TODO: Translation
        }

        public DealerAgreementDevicesPage EditDeviceDataUsingBulkEditOption(DealerAgreementDevicesPage dealerAgreementDevicesPage, string optionalFields)
        {
            string validationExpression;
            
            // Click Checkbox all element
            ClickSafety(dealerAgreementDevicesPage.CheckboxSelectAllElement, dealerAgreementDevicesPage);
            
            // Click Edit device data (bulk) element
            ClickSafety(dealerAgreementDevicesPage.EditDeviceDataBulkElement, dealerAgreementDevicesPage);

            dealerAgreementDevicesPage = EditDeviceDataHelper(optionalFields, out validationExpression);
            dealerAgreementDevicesPage.VerifyAddressOfEditedDevice(0, validationExpression); // Verify address of 1st row edited device
            dealerAgreementDevicesPage.VerifyAddressOfEditedDevice(1, validationExpression); // Verify address of 2nd row edited device
            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage EditDeviceDataHelper(string optionalFields, out string validationExpression)
        {
            var dealerAgreementDevicesEditPage = PageService.GetPageObject<DealerAgreementDevicesEditPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            validationExpression = dealerAgreementDevicesEditPage.EditDeviceData(optionalFields);

            ClickSafety(dealerAgreementDevicesEditPage.SaveButtonElement, dealerAgreementDevicesEditPage);
            return PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementDevicesPage EditDeviceDataUsingExcelEditOption(DealerAgreementDevicesPage dealerAgreementDevicesPage, string optionalFields)
        {
            ClickSafety(dealerAgreementDevicesPage.ExportAllElement, dealerAgreementDevicesPage);
            return ProcessExcelEdit(dealerAgreementDevicesPage, optionalFields);
        }

        public DealerAgreementDevicesPage ProcessExcelEdit(DealerAgreementDevicesPage dealerAgreementDevicesPage, string optionalFields)
        {
            // 1. Get Downloaded file path
            string excelFilePath = _excelHelper.GetDownloadedExcelFilePath();

            // 2. Edit Excel
            int rows = _excelHelper.GetNumberOfRows(excelFilePath);
            DealerAgreementDevicesEditPage dealerAgreementDevicesEditPage = new DealerAgreementDevicesEditPage();

            string device_id, validationExpression;
            List<Tuple<string, string>> validationTupleList = new List<Tuple<string, string>>();

            // Set initial value of row = 2 as 1st row is table header information            
            for (int row = 2; row <= rows; row++)
            {
                CustomerInformationMandatoryFields mandatoryFields = new CustomerInformationMandatoryFields();
                CustomerInformationNonMandatoryFields nonMandatoryFields = null;
                if (optionalFields.ToLower().Equals("true"))
                {
                    nonMandatoryFields = new CustomerInformationNonMandatoryFields();
                }
                // Edit excel for this device & retrieve the device_id of the edited device
                device_id = _excelHelper.EditExcelCustomerInformation(excelFilePath, row, mandatoryFields, nonMandatoryFields);

                // Get the validation expression, i.e., the address string
                validationExpression = dealerAgreementDevicesEditPage.ValidationExpression(
                    mandatoryFields, nonMandatoryFields);

                // Create a tuple of device_id & address string (& add to a list) for a later verification
                validationTupleList.Add(new Tuple<string, string>(device_id, validationExpression));
            }

            // 3. Import Excel
            ImportExcelFile(dealerAgreementDevicesPage, excelFilePath);

            // 4. Delete Excel
            _excelHelper.DeleteExcelFile(excelFilePath);
            dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            // 5. Validation of imported data
            // Validate only addresses of edited devices for now

            foreach (var tuple in validationTupleList)
            {
                dealerAgreementDevicesPage.ValidateDeviceAddress(
                    tuple.Item1 /*device_id*/, tuple.Item2 /*expectedAddressString*/, RuntimeSettings.DefaultFindElementTimeout);
            }
      
            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage EditUsingCombinationOfAllEditOptions(DealerAgreementDevicesPage dealerAgreementDevicesPage, string optionalFields)
        {
            string validationExpression;

            // Excel edit for first 2 devices
            dealerAgreementDevicesPage.ClickOnDeviceCheckbox(0, RuntimeSettings.DefaultFindElementTimeout);  // 1st device
            dealerAgreementDevicesPage.ClickOnDeviceCheckbox(1, RuntimeSettings.DefaultFindElementTimeout);  // 2nd device
            ClickSafety(dealerAgreementDevicesPage.ExportDataElement, dealerAgreementDevicesPage);
            dealerAgreementDevicesPage = ProcessExcelEdit(dealerAgreementDevicesPage, optionalFields);

            // Bulk edit for next 2 devices
            dealerAgreementDevicesPage.ClickOnDeviceCheckbox(2, RuntimeSettings.DefaultFindElementTimeout);  // 3rd device
            dealerAgreementDevicesPage.ClickOnDeviceCheckbox(3, RuntimeSettings.DefaultFindElementTimeout);  // 4th device
            ClickSafety(dealerAgreementDevicesPage.EditDeviceDataBulkElement, dealerAgreementDevicesPage);
            dealerAgreementDevicesPage = EditDeviceDataHelper(optionalFields, out validationExpression);
            dealerAgreementDevicesPage.VerifyAddressOfEditedDevice(2, validationExpression); // Verify address of 3rd device
            dealerAgreementDevicesPage.VerifyAddressOfEditedDevice(3, validationExpression); // Verify address of 4th device

            // Single device edit for last device
            dealerAgreementDevicesPage = EditSingleDeviceDataOfThisRow(dealerAgreementDevicesPage, 4, optionalFields);  // 5th device

            // Re-Edit 1 device edited via Excel edit option
            dealerAgreementDevicesPage = EditSingleDeviceDataOfThisRow(dealerAgreementDevicesPage, 0, optionalFields);  // 1st device

            // Re-Edit 1 device edited via Bulk edit option
            dealerAgreementDevicesPage = EditSingleDeviceDataOfThisRow(dealerAgreementDevicesPage, 2, optionalFields);  // 3rd device

            return dealerAgreementDevicesPage;
        }

        // Edit device data of this row (element)
        public DealerAgreementDevicesPage EditSingleDeviceDataOfThisRow(
            DealerAgreementDevicesPage dealerAgreementDevicesPage, int rowIndex, string optionalFields)
        {
            string validationExpression;
            dealerAgreementDevicesPage.ClickOnEditDeviceData(rowIndex, RuntimeSettings.DefaultFindElementTimeout);
            dealerAgreementDevicesPage = EditDeviceDataHelper(optionalFields, out validationExpression);
            dealerAgreementDevicesPage.VerifyAddressOfEditedDevice(rowIndex, validationExpression); // Verify address field of edited device
            return dealerAgreementDevicesPage;
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
            IWebElement printerContainer;
            var addToAgreementButton = dealerAgreementCreateProductsPage.PopulatePrinterDetails(
                printerName, 
                quantity, 
                installationPack, 
                servicePack,
                RuntimeSettings.DefaultFindElementTimeout,
                out printerContainer);

            // Validate calculations on products page
            ValidateCalculationOnProductsPage(dealerAgreementCreateProductsPage, printerContainer);

            ClickSafety(addToAgreementButton, dealerAgreementCreateProductsPage);
        }

        private void PopulatePrinterCoverageAndVolume(DealerAgreementCreateClickPricePage dealerAgreementCreateClickPricePage, string printerName, int monoCoverage, int monoVolume, int colorCoverage, int colorVolume)
        {
            dealerAgreementCreateClickPricePage.PopulatePrinterCoverageAndVolume(
                printerName, monoCoverage, monoVolume, colorCoverage, colorVolume, _contextData.UsageType,
                RuntimeSettings.DefaultFindElementTimeout);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }

        private void ImportExcelFile(DealerAgreementDevicesPage dealerAgreementDevicesPage, string excelFilePath)
        {
            // Click on Import Data button
            ClickSafety(dealerAgreementDevicesPage.ImportDataElement, dealerAgreementDevicesPage);
            
            var dealerAgreementDevicesUploadPage = PageService.GetPageObject<DealerAgreementDevicesUploadPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            // Upload file
            dealerAgreementDevicesUploadPage.ChooseFileElement.SendKeys(excelFilePath);

            ClickSafety(
                dealerAgreementDevicesUploadPage.UploadButtonElement, dealerAgreementDevicesUploadPage);
            var dealerAgreementDevicesUploadConfirmationPage = PageService.GetPageObject<DealerAgreementDevicesUploadConfirmationPage>(
                RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            ClickSafety(
                dealerAgreementDevicesUploadConfirmationPage.ConfirmChangesButtonElement, dealerAgreementDevicesUploadConfirmationPage);
        }

        private void ValidateCalculationOnProductsPage(DealerAgreementCreateProductsPage dealerAgreementCreateProductsPage, IWebElement printerContainer)
        {
            var installationPackQuantity = dealerAgreementCreateProductsPage.InstallationPackQuantity(printerContainer, RuntimeSettings.DefaultFindElementTimeout);
            var installationPackUnitPrice = dealerAgreementCreateProductsPage.InstallationPackUnitPrice(printerContainer, RuntimeSettings.DefaultFindElementTimeout);
            var installationPackTotalPrice = dealerAgreementCreateProductsPage.InstallationPackTotalPrice(printerContainer, RuntimeSettings.DefaultFindElementTimeout);

            var servicePackQuantity = dealerAgreementCreateProductsPage.ServicePackQuantity(printerContainer, RuntimeSettings.DefaultFindElementTimeout);
            var servicePackUnitPrice = dealerAgreementCreateProductsPage.ServicePackUnitPrice(printerContainer, RuntimeSettings.DefaultFindElementTimeout);
            var servicePackTotalPrice = dealerAgreementCreateProductsPage.ServicePackTotalPrice(printerContainer, RuntimeSettings.DefaultFindElementTimeout);

            var totalLinePrice = dealerAgreementCreateProductsPage.TotalLinePrice(printerContainer, RuntimeSettings.DefaultFindElementTimeout);

            _calculationService.VerifyTheCorrectPositionOfCurrencySymbol(_contextData.Country.CountryIso, new List<string> { installationPackTotalPrice, servicePackTotalPrice, totalLinePrice });
            _calculationService.VerifyMultiplication(installationPackQuantity, installationPackUnitPrice, RemoveCurrencySymbol(installationPackTotalPrice));
            _calculationService.VerifyMultiplication(servicePackQuantity, servicePackUnitPrice, RemoveCurrencySymbol(servicePackTotalPrice));
            _calculationService.VerifySum(new List<string> { 
                RemoveCurrencySymbol(installationPackTotalPrice), RemoveCurrencySymbol(servicePackTotalPrice) }, 
                RemoveCurrencySymbol(totalLinePrice));
        }

        private void ValidateCalculationOnSummaryPage(DealerAgreementCreateSummaryPage dealerAgreementCreateSummaryPage)
        {
            // Validate Agreement Details on summary page
            dealerAgreementCreateSummaryPage.VerifyContentOnSummaryPage(
                _contextData.AgreementName, 
                _contextData.ContractTerm,
                _contextData.LeadCodeReference,
                _contextData.LeasingFinanceReference,
                _contextData.ContractType,
                _contextData.UsageType,
                _contextData.DealerReference);
            
            _calculationService.VerifyTheCorrectPositionOfCurrencySymbol(
                _contextData.Country.CountryIso, new List<string> { 
                    dealerAgreementCreateSummaryPage.AgreementGrandTotalPriceNetElement.Text, 
                    dealerAgreementCreateSummaryPage.AgreementGrandTotalPriceGrossElement.Text }
                    );
            _calculationService.VerifyGrossPrice(RemoveCurrencySymbol(dealerAgreementCreateSummaryPage.AgreementGrandTotalPriceNetElement.Text),
                RemoveCurrencySymbol(dealerAgreementCreateSummaryPage.AgreementGrandTotalPriceGrossElement.Text));
        }

        private string RemoveCurrencySymbol(string value) // TODO: Extend this function to handle currencies for other countries
        {
            return value.Substring(1); // Removes 1st character from string
        }
        #endregion
    }
}