using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
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
        private readonly IRunCommandService _runCommandService;
        private readonly MpsLocalOfficeAdminAgreementStepActions _mpsLocalOfficeAdmin;

        public MpsDealerAgreementStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ITranslationService translationService,
            IRuntimeSettings runtimeSettings,
            MpsSignInStepActions mpsSignIn,
            IExcelHelper excelHelper,
            ICalculationService calculationService,
            ILoggingService loggingService,
            IRunCommandService runCommandService,
            MpsLocalOfficeAdminAgreementStepActions mpsLocalOfficeAdmin)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _translationService = translationService;
            _contextData = contextData;
            _excelHelper = excelHelper;
            _calculationService = calculationService;
            _runCommandService = runCommandService;
            _mpsLocalOfficeAdmin = mpsLocalOfficeAdmin;
        }
        //TODO: make all of the calls which specify a timeout pull the timeout value from config / command line
        public DealerDashBoardPage SignInAsDealerAndNavigateToDashboard(string email, string password, string url)
        {
            LoggingService.WriteLogOnMethodEntry(email, password, url);
            return _mpsSignIn.SignInAsDealer(email, password, url);
        }

        public DealerAgreementCreateDescriptionPage NavigateToCreateAgreementPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            dealerDashboardPage.CreateAgreementLinkElement.Click();
            return PageService.GetPageObject<DealerAgreementCreateDescriptionPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementCreateTermAndTypePage PopulateAgreementDescriptionAndProceed(DealerAgreementCreateDescriptionPage dealerAgreementCreateDescriptionPage,
            string agreementName,
            string leadCodeReference = "",
            string dealerReference = "",
            string leasingReference = "")
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateDescriptionPage, agreementName, leadCodeReference, dealerReference, dealerReference, leasingReference);
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
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateTermAndTypePage, usageType, contractLength, servicePackOption);
            string resourceUsageTypePayAsYouGo = _translationService.GetUsageTypeText(
                TranslationKeys.UsageType.PayAsYouGo, _contextData.Culture);
            string resourceServiceTypeIncludedInClickPrice = _translationService.GetServicePackTypeText(
                TranslationKeys.ServicePackType.IncludedInClickPrice, _contextData.Culture);
            
            // Validate that Service Pack Option available to choose is only 'Pay upfront' in case of Usage type being 'Pay As You Go'
            dealerAgreementCreateTermAndTypePage.ValidateServicePackAvailableOptions(
                resourceUsageTypePayAsYouGo, resourceServiceTypeIncludedInClickPrice);

            _contextData.UsageType = usageType;
            _contextData.ContractTerm = contractLength;
            _contextData.ServicePackType = servicePackOption;

            dealerAgreementCreateTermAndTypePage.SelectUsageType(usageType);
            dealerAgreementCreateTermAndTypePage.SelectContractLength(contractLength);
            dealerAgreementCreateTermAndTypePage.SelectService(servicePackOption);

            ClickSafety(dealerAgreementCreateTermAndTypePage.NextButton, dealerAgreementCreateTermAndTypePage);
            return PageService.GetPageObject<DealerAgreementCreateProductsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementCreateClickPricePage AddThesePrintersToAgreementAndProceed(DealerAgreementCreateProductsPage dealerAgreementCreateProductsPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateProductsPage);
            int deviceCount = 0;
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                deviceCount = deviceCount + product.Quantity;
                PopulatePrinterDetails(dealerAgreementCreateProductsPage, product.Model, product.Quantity, product.InstallationPack, product.ServicePack);
            }
            _contextData.DeviceCount = deviceCount;
            ClickSafety(dealerAgreementCreateProductsPage.NextButton, dealerAgreementCreateProductsPage);
            return PageService.GetPageObject<DealerAgreementCreateClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementCreateSummaryPage PopulateCoverageAndVolumeAndProceed(DealerAgreementCreateClickPricePage dealerAgreementCreateClickPricePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateClickPricePage);
            var products = _contextData.PrintersProperties;
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
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateSummaryPage);
            _contextData.AgreementId = dealerAgreementCreateSummaryPage.AgreementId();
            
            // Validate calculations/content on summary page
            ValidateCalculationOnSummaryPage(dealerAgreementCreateSummaryPage);

            ClickSafety(dealerAgreementCreateSummaryPage.CompleteSetupButton, dealerAgreementCreateSummaryPage);
            dealerAgreementCreateSummaryPage.AcceptJavascriptPopupOnCompleteSetup();
            return PageService.GetPageObject<DealerAgreementsListPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifyCreatedAgreement(DealerAgreementsListPage dealerAgreementsListPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementsListPage);
            bool exists = dealerAgreementsListPage.VerifyCreatedAgreement(_contextData.AgreementId, _contextData.AgreementName);
            if (!exists)
            {
                throw new Exception(string.Format("Agreement = {0} not found ", _contextData.AgreementId));
            }    
        }

        public DealerAgreementDevicesPage NavigateToManageDevicesPage(DealerAgreementsListPage dealerAgreementsListPage, string resourceInstalledPrinterStatusAddressRequired)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementsListPage, resourceInstalledPrinterStatusAddressRequired);

            dealerAgreementsListPage.ClickOnManageDevicesButton();
            var dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            
            // Verify that all devices are in "address required" state
            dealerAgreementDevicesPage.VerifyTheStatusOfAllDevices(resourceInstalledPrinterStatusAddressRequired);

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage EditDeviceDataOneByOne(DealerAgreementDevicesPage dealerAgreementDevicesPage, string optionalFields)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, optionalFields);
            string validationExpression;
            var deviceRowCount = dealerAgreementDevicesPage.DeviceTableRowsCount();
            for (int rowIndex = 0; rowIndex < deviceRowCount; rowIndex++)
            {
                dealerAgreementDevicesPage.ClickOnEditDeviceData(rowIndex);
                dealerAgreementDevicesPage = EditDeviceDataHelper(optionalFields, out validationExpression);
                
                // Validate address field of edited device
                dealerAgreementDevicesPage.VerifyAddressOfEditedDevice(rowIndex, validationExpression);

            }

            return dealerAgreementDevicesPage;
        }

        public void VerifyStatusOfDevices(DealerAgreementDevicesPage dealerAgreementDevicesPage, string resourceInstalledPrinterStatus)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, resourceInstalledPrinterStatus);
            // Verify that all devices are in "resourceInstalledPrinterStatus" status
            dealerAgreementDevicesPage.VerifyTheStatusOfAllDevices(resourceInstalledPrinterStatus);
        }

        public DealerAgreementDevicesPage EditDeviceDataUsingBulkEditOption(DealerAgreementDevicesPage dealerAgreementDevicesPage, string optionalFields)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, optionalFields);
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
            LoggingService.WriteLogOnMethodEntry(optionalFields);
            var dealerAgreementDevicesEditPage = PageService.GetPageObject<DealerAgreementDevicesEditPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            validationExpression = dealerAgreementDevicesEditPage.EditDeviceData(optionalFields);

            ClickSafety(dealerAgreementDevicesEditPage.SaveButtonElement, dealerAgreementDevicesEditPage);

            // Run job for retrieving BOC pin per device
            _runCommandService.RunSetupInstalledPrintersCommand();

            var dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            int retries = 0;

            while(dealerAgreementDevicesPage.SeleniumHelper.IsElementDisplayed(dealerAgreementDevicesPage.WarningAlertElement))
            {
                _dealerWebDriver.Navigate().Refresh();
                dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    TestCheck.AssertFailTest(
                        string.Format("Number of retries exceeded the default limit during verification of boc pin codes generation for agreement {0}", _contextData.AgreementId));
                }
            }

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage EditDeviceDataUsingExcelEditOption(DealerAgreementDevicesPage dealerAgreementDevicesPage, string optionalFields)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, optionalFields);
            ClickSafety(dealerAgreementDevicesPage.ExportAllElement, dealerAgreementDevicesPage);
            return ProcessExcelEdit(dealerAgreementDevicesPage, optionalFields);
        }

        public DealerAgreementDevicesPage ProcessExcelEdit(DealerAgreementDevicesPage dealerAgreementDevicesPage, string isOptionalFields)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, isOptionalFields);
            // 1. Get Downloaded file path
            string excelFilePath = _excelHelper.GetDownloadedExcelFilePath();

            // 2. Edit Excel
            int rows = _excelHelper.GetNumberOfRows(excelFilePath);
            _excelHelper.VerifyTotalNumberOfColumns(excelFilePath); // Verify the total number of columns in excel
            DealerAgreementDevicesEditPage dealerAgreementDevicesEditPage = new DealerAgreementDevicesEditPage();

            string device_id, validationExpression;
            List<Tuple<string, string>> validationTupleList = new List<Tuple<string, string>>();

            // Set initial value of row = 2 as 1st row is table header information            
            for (int row = 2; row <= rows; row++)
            {
                CustomerInformationMandatoryFields mandatoryFields = new CustomerInformationMandatoryFields();
                CustomerInformationOptionalFields nonMandatoryFields = null;
                if (isOptionalFields.ToLower().Equals("true"))
                {
                    nonMandatoryFields = new CustomerInformationOptionalFields();
                }
                // Edit excel for this device & retrieve the device_id of the edited device
                device_id = _excelHelper.EditExcelCustomerInformation(excelFilePath, row, mandatoryFields, nonMandatoryFields);

                // Get the validation expression, i.e., the address string
                validationExpression = dealerAgreementDevicesEditPage.ValidationExpression(LoggingService,
                    mandatoryFields, nonMandatoryFields);

                // Create a tuple of device_id & address string (& add to a list) for a later verification
                validationTupleList.Add(new Tuple<string, string>(device_id, validationExpression));
            }

            // 3. Import Excel
            ImportExcelFile(dealerAgreementDevicesPage, excelFilePath);

            // 4. Call BOC Pin retrieval backend job
            _runCommandService.RunSetupInstalledPrintersCommand();

            // 5. Delete Excel
            _excelHelper.DeleteExcelFile(excelFilePath);
            dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            // 6. Validation of imported data
            // Validate only addresses of edited devices for now

            foreach (var tuple in validationTupleList)
            {
                dealerAgreementDevicesPage.ValidateDeviceAddress(tuple.Item1 /*device_id*/, tuple.Item2 /*expectedAddressString*/);
            }
      
            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage EditUsingCombinationOfAllEditOptions(DealerAgreementDevicesPage dealerAgreementDevicesPage, string optionalFields)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, optionalFields);
            string validationExpression;

            // Excel edit for first 2 devices
            dealerAgreementDevicesPage.ClickOnDeviceCheckbox(0);  // 1st device
            dealerAgreementDevicesPage.ClickOnDeviceCheckbox(1);  // 2nd device
            ClickSafety(dealerAgreementDevicesPage.ExportDataElement, dealerAgreementDevicesPage);
            dealerAgreementDevicesPage = ProcessExcelEdit(dealerAgreementDevicesPage, optionalFields);

            // Bulk edit for next 2 devices
            dealerAgreementDevicesPage.ClickOnDeviceCheckbox(2);  // 3rd device
            dealerAgreementDevicesPage.ClickOnDeviceCheckbox(3);  // 4th device
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
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, rowIndex, optionalFields);
            string validationExpression;
            dealerAgreementDevicesPage.ClickOnEditDeviceData(rowIndex);
            dealerAgreementDevicesPage = EditDeviceDataHelper(optionalFields, out validationExpression);
            dealerAgreementDevicesPage.VerifyAddressOfEditedDevice(rowIndex, validationExpression); // Verify address field of edited device
            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage SendBulkInstallationRequest(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            var deviceRowCount = dealerAgreementDevicesPage.DeviceTableRowsCount();
            int devicesInstallingCount = 0;

            // Tick checkboxes of devices which are to be installed according to feature file configuration
            for (int rowIndex = 0; rowIndex < deviceRowCount; rowIndex++)
            {
                string displayedModelName = dealerAgreementDevicesPage.DeviceModelName(rowIndex);
                foreach(var product in _contextData.PrintersProperties)
                {
                    if (displayedModelName.Equals(product.Model) && product.SendInstallationRequest.ToLower().Equals("yes"))
                    {
                        dealerAgreementDevicesPage.ClickOnDeviceCheckbox(rowIndex);
                        devicesInstallingCount++;
                        break;
                    }
                }
            }

            switch (devicesInstallingCount)
            {
                case 0: // No devices will be installed
                    break;

                case 1: // Only 1 device will be installed, hence, cannot click bulk Send Installation Request button
                    dealerAgreementDevicesPage = SendSingleInstallationRequests(
                        dealerAgreementDevicesPage);
                    break;

                default: // For Bulk installation request
                    // Click Send Installation Request button (used for bulk)
                    ClickSafety(dealerAgreementDevicesPage.SendInstallationRequestElement, dealerAgreementDevicesPage);
                    dealerAgreementDevicesPage.SendInstallationRequest();
                    break;
            }

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage SendSingleInstallationRequests(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            var deviceRowCount = dealerAgreementDevicesPage.DeviceTableRowsCount();

            // Tick checkboxes of devices which are to be installed according to feature file configuration
            for (int rowIndex = 0; rowIndex < deviceRowCount; rowIndex++)
            {
                string displayedModelName = dealerAgreementDevicesPage.DeviceModelName(rowIndex);
                foreach (var product in _contextData.PrintersProperties)
                {
                    if (displayedModelName.Equals(product.Model) && product.SendInstallationRequest.ToLower().Equals("yes"))
                    {
                        // Click Send Installation Request button in Actions dropdown
                        dealerAgreementDevicesPage.ClickSendInstallationRequestInActions(rowIndex);
                        
                        // Handle Send Installation Request modal
                        dealerAgreementDevicesPage.SendInstallationRequest();
                        break;
                    }
                }
                
                if (rowIndex!= (deviceRowCount - 1))
                {
                    // Note: This refresh is done due to the introduction of stale elements in Send Installation Request modal after every successful send
                    // Note: Don't refresh if its the last device in the table
                    _dealerWebDriver.Navigate().Refresh(); 
                    dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                }
            }

            return dealerAgreementDevicesPage;
        }

        public void ExportDeviceDetailsAndReadExcel(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            // Switch back to Dealer window
            _dealerWebDriver.SwitchTo().Window(_contextData.WindowHandles[UserType.Dealer]);

            // Refresh so that excel is updated (after the BOC Pin retrieval API is called)
            _dealerWebDriver.Navigate().Refresh();
            dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            // 1. Click Export All button
            ClickSafety(dealerAgreementDevicesPage.ExportAllElement, dealerAgreementDevicesPage);

            // 2. Get Downloaded file path
            string excelFilePath = _excelHelper.GetDownloadedExcelFilePath();

            // 3. Read Excel to retrieve installation details
            
            int rows = _excelHelper.GetNumberOfRows(excelFilePath);
            // Set initial value of row = 2 as 1st row is table header information

            List<AdditionalDeviceProperties> additionalDeviceProperties = new List<AdditionalDeviceProperties>();
            for (int row = 2; row <= rows; row++)
            {
                additionalDeviceProperties.Add(_excelHelper.GetDeviceDetails(excelFilePath, row));
            }

            // Save to context data for later use
            _contextData.AdditionalDeviceProperties = additionalDeviceProperties;

            // 4. Delete Excel
            _excelHelper.DeleteExcelFile(excelFilePath);
        }

        public DealerAgreementDevicesPage VerifyThatDevicesAreInstalled(DealerAgreementDevicesPage dealerAgreementDevicesPage,
            string resourceInstalledPrinterStatusInstalled, string resourceDeviceConnectionStatusResponding)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, resourceDeviceConnectionStatusResponding, resourceDeviceConnectionStatusResponding);
            // Switch back to Dealer window
            _dealerWebDriver.SwitchTo().Window(_contextData.WindowHandles[UserType.Dealer]);
            
            // Refresh to reflect the device status changes
            _dealerWebDriver.Navigate().Refresh();
            dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(
                RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            // Verify that devices are installed
            VerifyStatusOfDevices(dealerAgreementDevicesPage, resourceInstalledPrinterStatusInstalled);

            // Verify that devices are responding
            VerifyStatusOfDevices(dealerAgreementDevicesPage, resourceDeviceConnectionStatusResponding);
            
            
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                device.ConnectionStatus = resourceDeviceConnectionStatusResponding;
                device.DeviceStatus = resourceInstalledPrinterStatusInstalled;

                // Verify the serial number of all devices used during installation (pick up from context data)
                dealerAgreementDevicesPage.VerifySerialNumberOfDevice(device.MpsDeviceId, device.SerialNumber);
            }

            // Verify updated devices' data in excel sheet
            VerifyUpdatedDeviceDataInExcelSheet(
                dealerAgreementDevicesPage, resourceDeviceConnectionStatusResponding, resourceInstalledPrinterStatusInstalled);

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage VerifyUpdatedPrintCounts(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            // Refreshes the print counts on MPS portal (after synchronizing BOC values)
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId);

            // Switch back to Dealer window
            _dealerWebDriver.SwitchTo().Window(_contextData.WindowHandles[UserType.Dealer]);

            // Refresh page until print counts are updated
            int retries = 0;
            while(!dealerAgreementDevicesPage.IsPrintCountsUpdated())
            {
                _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId);
                
                _dealerWebDriver.Navigate().Refresh();
                dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(
                    RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    throw new Exception(
                        string.Format("Number of retries exceeded the default limit during verification of print counts for agreement {0}", _contextData.AgreementId));
                }
            }

            // Verify print count values for all devices one by one
            foreach(var device in _contextData.AdditionalDeviceProperties)
            {
                dealerAgreementDevicesPage.VerifyPrintCountsOfDevice(device.MpsDeviceId, device.ColorPrintCount, device.MonoPrintCount, device.TotalPrintCount);
            }

            // Sets the agreement status to "Running"
            _runCommandService.RunStartContractCommand();

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage RaiseConsumableOrdersManually(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            // Check if dealer can raise consumable orders manually
            bool enabled = dealerAgreementDevicesPage.IsManualRaiseConsumableOptionEnabled();

            if(!enabled)
            {
                _mpsLocalOfficeAdmin.EnableRaiseConsumableOrderOption();
            }

            _dealerWebDriver.Navigate().Refresh();
            dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(
                RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            // Raise consumable orders one by one
            foreach(var product in _contextData.PrintersProperties)
            {
                foreach (var device in _contextData.AdditionalDeviceProperties)
                {
                    if (device.Model.Equals(product.Model))
                    {
                        // Save consumable order status to Additional Device Properties as well for convenience
                        device.TonerInkBlackStatus = product.TonerInkBlackStatus;
                        device.TonerInkCyanStatus = product.TonerInkCyanStatus;
                        device.TonerInkMagentaStatus = product.TonerInkMagentaStatus;
                        device.TonerInkYellowStatus = product.TonerInkYellowStatus;


                        if (device.hasEmptyInkToner)
                        {
                            dealerAgreementDevicesPage.ClickRaiseConsumableOrder(device.MpsDeviceId);
                            var dealerAgreementConsumablesCreatePage = PageService.GetPageObject<DealerAgreementConsumablesCreatePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                            // Select consumables
                            dealerAgreementConsumablesCreatePage.SelectConsumables(
                                device.TonerInkBlackStatus, device.TonerInkCyanStatus, device.TonerInkMagentaStatus, device.TonerInkYellowStatus);

                            ClickSafety(
                                dealerAgreementConsumablesCreatePage.SubmitOrderButtonElement, dealerAgreementConsumablesCreatePage);
                            dealerAgreementConsumablesCreatePage.SeleniumHelper.AcceptJavascriptAlert();

                            // Verify success alert
                            dealerAgreementConsumablesCreatePage.VerifySuccessfulOrderCreation();
                            ClickSafety(dealerAgreementConsumablesCreatePage.BackButtonElement, dealerAgreementConsumablesCreatePage);

                            dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                        }
                    }
                }
            }
            
            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage VerifyConsumableOrders(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            string resourceConsumableOrderStatusInProgress = _translationService.GetConsumableOrderStatusText(TranslationKeys.ConsumableOrderStatus.InProgress, _contextData.Culture);

            // Verify consumable order information one by one
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                if (device.hasEmptyInkToner)
                {
                    dealerAgreementDevicesPage.ClickShowConsumableOrders(device.MpsDeviceId);
                    var dealerAgreementDeviceConsumablesPage = PageService.GetPageObject<DealerAgreementDeviceConsumablesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                    dealerAgreementDeviceConsumablesPage.VerifyConsumableOrderInformation(device.SerialNumber, resourceConsumableOrderStatusInProgress);

                    ClickSafety(dealerAgreementDeviceConsumablesPage.BackButtonElement, dealerAgreementDeviceConsumablesPage);
                    dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                }
            }

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage RaiseServiceRequestsManually(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            string resourceServiceRequestStatusNew = _translationService.GetServiceRequestStatusText(TranslationKeys.ServiceRequestStatus.New, _contextData.Culture);

            foreach (var device in _contextData.AdditionalDeviceProperties)
            {  
                dealerAgreementDevicesPage.ClickRaiseServiceRequest(device.MpsDeviceId);

                var dealerAgreementServiceRequestsCreatePage = PageService.GetPageObject<DealerAgreementServiceRequestsCreatePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                // Fill Problem Description & save Service Request type to context data for later verification
                device.ServiceRequestType = dealerAgreementServiceRequestsCreatePage.FillProblemDescription();

                ClickSafety(
                    dealerAgreementServiceRequestsCreatePage.RaiseServiceRequestButtonElement, dealerAgreementServiceRequestsCreatePage);

                dealerAgreementServiceRequestsCreatePage.SeleniumHelper.AcceptJavascriptAlert();

                var dealerAgreementServiceRequestsPage = PageService.GetPageObject<DealerAgreementServiceRequestsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                device.ServiceRequestId = dealerAgreementServiceRequestsPage.VerifyServiceRequestInformation(device.Model, device.SerialNumber, resourceServiceRequestStatusNew, device.ServiceRequestType);

                ClickSafety(
                    dealerAgreementServiceRequestsPage.DevicesTabElement(_contextData.AgreementId), dealerAgreementServiceRequestsPage);

                _dealerWebDriver.Navigate().Refresh();

                dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            }

            return dealerAgreementDevicesPage;
        }

        public void VerifyServiceRequestStatus(DealerAgreementDevicesPage dealerAgreementDevicesPage, string resourceServiceRequestStatus)
        {
            ClickSafety(dealerAgreementDevicesPage.ServiceRequestsTabElement(_contextData.AgreementId), dealerAgreementDevicesPage);

            var dealerAgreementServiceRequestsPage = PageService.GetPageObject<DealerAgreementServiceRequestsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            // Make sure that the service requests exist before verifying the information
            int retries = 0;
            foreach(var device in _contextData.AdditionalDeviceProperties)
            {
                while (!dealerAgreementServiceRequestsPage.DoesServiceRequestExist(device.SerialNumber))
                {
                    _dealerWebDriver.Navigate().Refresh();
                    dealerAgreementServiceRequestsPage = PageService.GetPageObject<DealerAgreementServiceRequestsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                    retries++;
                    if (retries > RuntimeSettings.DefaultRetryCount)
                    {
                        TestCheck.AssertFailTest(
                            string.Format("Number of retries exceeded the default limit during service request information verification for agreement {0}", _contextData.AgreementId));
                    }
                }
            }

            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                dealerAgreementServiceRequestsPage.VerifyServiceRequestInformation(device.Model, device.SerialNumber, resourceServiceRequestStatus, device.ServiceRequestType, true);
            }
        }

        public void VerifyDeviceDetails(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                dealerAgreementDevicesPage.ClickShowDeviceDetails(device.MpsDeviceId);
                dealerAgreementDevicesPage.VerifyDeviceDetails(device, _contextData.AgreementType, _contextData.ContractTerm, _contextData.UsageType);

                _dealerWebDriver.Navigate().Refresh();
                dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            }
        }

        #region private methods

        private void PopulateAgreementDescription(DealerAgreementCreateDescriptionPage dealerAgreementCreateDescriptionPage,
            string agreementName,
            string leadCodeReference,
            string dealerReference,
            string leasingReference)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateDescriptionPage,agreementName,leadCodeReference,dealerReference,leasingReference);
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
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateProductsPage, printerName,quantity,installationPack,servicePack);
            IWebElement printerContainer;
            var addToAgreementButton = dealerAgreementCreateProductsPage.PopulatePrinterDetails(
                printerName, 
                quantity, 
                installationPack, 
                servicePack,
                out printerContainer);

            // Validate calculations on products page
            ValidateCalculationOnProductsPage(dealerAgreementCreateProductsPage, printerContainer);

            dealerAgreementCreateProductsPage.ClickAddToAgreementButton(
                printerContainer, addToAgreementButton);
        }

        private void PopulatePrinterCoverageAndVolume(DealerAgreementCreateClickPricePage dealerAgreementCreateClickPricePage, string printerName, int monoCoverage, int monoVolume, int colorCoverage, int colorVolume)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateClickPricePage,printerName,monoCoverage,monoVolume,colorCoverage,colorVolume);
            string resourceUsageTypePayAsYouGo = _translationService.GetUsageTypeText(
                TranslationKeys.UsageType.PayAsYouGo, _contextData.Culture);
            dealerAgreementCreateClickPricePage.PopulatePrinterCoverageAndVolume(
                printerName, monoCoverage, monoVolume, colorCoverage, colorVolume, _contextData.UsageType, resourceUsageTypePayAsYouGo);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            LoggingService.WriteLogOnMethodEntry(element,pageObject);
            pageObject.SeleniumHelper.ClickSafety(element);
        }

        private void ImportExcelFile(DealerAgreementDevicesPage dealerAgreementDevicesPage, string excelFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage,excelFilePath);
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
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateProductsPage,printerContainer);

            var installationPackQuantity = dealerAgreementCreateProductsPage.InstallationPackQuantity(printerContainer);
            var installationPackUnitPrice = dealerAgreementCreateProductsPage.InstallationPackUnitPrice(printerContainer);
            var installationPackTotalPrice = dealerAgreementCreateProductsPage.InstallationPackTotalPrice(printerContainer);

            var servicePackQuantity = dealerAgreementCreateProductsPage.ServicePackQuantity(printerContainer);
            var servicePackUnitPrice = dealerAgreementCreateProductsPage.ServicePackUnitPrice(printerContainer);
            var servicePackTotalPrice = dealerAgreementCreateProductsPage.ServicePackTotalPrice(printerContainer);

            var totalLinePrice = dealerAgreementCreateProductsPage.TotalLinePrice(printerContainer);

            _calculationService.VerifyTheCorrectPositionOfCurrencySymbol(_contextData.Country.CountryIso, new List<string> { installationPackTotalPrice, servicePackTotalPrice, totalLinePrice });
            _calculationService.VerifyMultiplication(installationPackQuantity, installationPackUnitPrice, RemoveCurrencySymbol(installationPackTotalPrice));
            _calculationService.VerifyMultiplication(servicePackQuantity, servicePackUnitPrice, RemoveCurrencySymbol(servicePackTotalPrice));
            _calculationService.VerifySum(new List<string> { 
                RemoveCurrencySymbol(installationPackTotalPrice), RemoveCurrencySymbol(servicePackTotalPrice) }, 
                RemoveCurrencySymbol(totalLinePrice));
        }

        private void ValidateCalculationOnSummaryPage(DealerAgreementCreateSummaryPage dealerAgreementCreateSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateSummaryPage);
            // Validate Agreement Details on summary page are same as that saved during creating agreement (& saved in contextData)
            dealerAgreementCreateSummaryPage.VerifyContentOnSummaryPage(
                _contextData.AgreementName, 
                _contextData.ContractTerm,
                _contextData.LeadCodeReference,
                _contextData.LeasingFinanceReference,
                _contextData.AgreementType,
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
            LoggingService.WriteLogOnMethodEntry(value);
            return value.Substring(1); // Removes 1st character from string
        }

        private void VerifyUpdatedDeviceDataInExcelSheet(
            DealerAgreementDevicesPage dealerAgreementDevicesPage, string resourceDeviceConnectionStatusResponding, string resourceInstalledPrinterStatusInstalled)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, resourceDeviceConnectionStatusResponding, resourceInstalledPrinterStatusInstalled);
            // 1. Click Export All button
            ClickSafety(dealerAgreementDevicesPage.ExportAllElement, dealerAgreementDevicesPage);

            // 2. Get Downloaded file path
            string excelFilePath = _excelHelper.GetDownloadedExcelFilePath();

            // 3. Verify Device status & Connection status mentioned in excel
            int rows = _excelHelper.GetNumberOfRows(excelFilePath);
            // Set initial value of row = 2 as 1st row is table header information
            for (int row = 2; row <= rows; row++)
            {
                _excelHelper.VerifyDeviceStatusAndConnectionStatus(
                    excelFilePath, row, resourceInstalledPrinterStatusInstalled, resourceDeviceConnectionStatusResponding);
            }

            // 4. Delete Excel
            _excelHelper.DeleteExcelFile(excelFilePath);
        }
        #endregion
    }
}
