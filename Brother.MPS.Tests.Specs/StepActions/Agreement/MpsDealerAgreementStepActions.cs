using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Helpers.ExcelHelpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Device;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TechTalk.SpecFlow;


namespace Brother.Tests.Specs.StepActions.Agreement
{
    public class MpsDealerAgreementStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IWebDriver _dealerWebDriver;
        private readonly ITranslationService _translationService;
        private readonly IContextData _contextData;
        private readonly IDevicesExcelHelper _devicesExcelHelper;
        private readonly IClickBillExcelHelper _clickBillExcelHelper;
        private readonly IServiceInstallationBillExcelHelper _serviceInstallationBillExcelHelper;
        private readonly ICalculationService _calculationService;
        private readonly IRunCommandService _runCommandService;
        private readonly MpsLocalOfficeAdminAgreementStepActions _mpsLocalOfficeAdmin;
        private readonly IPageParseHelper _pageParseHelper;
        private readonly IUserResolver _userResolver;
        private readonly ICPPAgreementExcelHelper _cppAgreementHelper;
        private readonly ICppAgreementDevicesExcelHelper _cppAgreementDevicesExcelHelper;
        private readonly IDeviceSimulatorService _deviceSimulatorService;
        private readonly MpsApiCallStepActions _mpsApiStepActions;
        private readonly IContractShiftService _contractShiftService;
        private readonly IMpsWebToolsService _mpsWebToolsService;

        public MpsDealerAgreementStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ITranslationService translationService,
            IRuntimeSettings runtimeSettings,
            MpsSignInStepActions mpsSignIn,
            IDevicesExcelHelper devicesExcelHelper,
            IClickBillExcelHelper clickBillExcelHelper,
            IServiceInstallationBillExcelHelper serviceInstallationBillExcelHelper,
            ICalculationService calculationService,
            ILoggingService loggingService,
            IRunCommandService runCommandService,
            IPageParseHelper pageParseHelper,
            MpsLocalOfficeAdminAgreementStepActions mpsLocalOfficeAdmin,
            ICppAgreementDevicesExcelHelper cppAgreementDevicesExcelHelper,
            IUserResolver userResolver,
            IDeviceSimulatorService deviceSimulatorService,
            IContractShiftService contractShiftService,
            ICPPAgreementExcelHelper cppAgreementHelper,
            MpsApiCallStepActions mpsApiStepActions,
            IMpsWebToolsService mpsWebToolsService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _translationService = translationService;
            _contextData = contextData;
            _devicesExcelHelper = devicesExcelHelper;
            _calculationService = calculationService;
            _runCommandService = runCommandService;
            _mpsLocalOfficeAdmin = mpsLocalOfficeAdmin;
            _clickBillExcelHelper = clickBillExcelHelper;
            _serviceInstallationBillExcelHelper = serviceInstallationBillExcelHelper;
            _pageParseHelper = pageParseHelper;
            _userResolver = userResolver;
            _cppAgreementDevicesExcelHelper = cppAgreementDevicesExcelHelper;
            _cppAgreementHelper = cppAgreementHelper;
            _deviceSimulatorService = deviceSimulatorService;
            _mpsApiStepActions = mpsApiStepActions;
            _contractShiftService = contractShiftService;
            _mpsWebToolsService = mpsWebToolsService;
        }

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
            ClickSafety(dealerAgreementCreateProductsPage.NextButton, dealerAgreementCreateProductsPage, true);
            return PageService.GetPageObject<DealerAgreementCreateClickPricePage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementCreateSummaryPage PopulateCoverageAndVolumeAndProceed(DealerAgreementCreateClickPricePage dealerAgreementCreateClickPricePage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateClickPricePage);
            var products = _contextData.PrintersProperties;
            foreach (var product in products)
            {
                PopulatePrinterCoverageAndVolume(dealerAgreementCreateClickPricePage, product);
            }

            // Click Next button until the URL of the driver changes
            while(_dealerWebDriver.Url.Contains(dealerAgreementCreateClickPricePage.PageUrl))
            {
                ClickSafety(dealerAgreementCreateClickPricePage.NextButton, dealerAgreementCreateClickPricePage);
            }

            var summaryPage =  PageService.GetPageObject<DealerAgreementCreateSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            var summaryPageValues = _pageParseHelper.ParseSummaryPageValues(summaryPage.SeleniumHelper);
            _contextData.SnapValues[typeof(DealerAgreementCreateSummaryPage)] = summaryPageValues;
            return summaryPage;
        }

        public void SnapAgreementPagesValues(DealerAgreementBillingPage dealerAgreementBillingPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementBillingPage);

            ClickSafety(dealerAgreementBillingPage.DevicesTabElement, dealerAgreementBillingPage, IsUntilUrlChanges: true);
            var dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            var devicesPagesValues = _pageParseHelper.ParseDealerAgreementDevicesPage(dealerAgreementDevicesPage);
            _contextData.SnapValues[typeof(DealerAgreementDevicesPage)] = devicesPagesValues;

            ClickSafety(dealerAgreementDevicesPage.ServiceRequestsTabElement, dealerAgreementDevicesPage, IsUntilUrlChanges: true);
            var dealerAgreementServiceRequestsPage = PageService.GetPageObject<DealerAgreementServiceRequestsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            var serviceRequestValues = _pageParseHelper.ParseDealerAgreementServiceRequestsPage(dealerAgreementServiceRequestsPage);
            _contextData.SnapValues[typeof(DealerAgreementServiceRequestsPage)] = serviceRequestValues;

            ClickSafety(dealerAgreementServiceRequestsPage.ConsumablesTabElement, dealerAgreementServiceRequestsPage, IsUntilUrlChanges: true);
            var dealerAgreementConsumablesPage = PageService.GetPageObject<DealerAgreementConsumablesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            // note: Processing time is uneven. min:<10s max:5min (in debugging)
            _runCommandService.RunCreateConsumableOrderCommand();
            var consumablesPageValues = LoggingService.WriteLogWhenWarningTimeoutExceeds(ls => 
                dealerAgreementConsumablesPage.SeleniumHelper.WaitUntil(d =>
                {
                    // wait for visible Order Date. 
                    var values = _pageParseHelper.ParseDealerAgreementConsumablesPage(dealerAgreementConsumablesPage);
                    if (values["Consumables.Count"] == "0") { return values; }
                    if (values["Consumables.0.OrderDate-data-sort"] != null) { return values; }  // sampling check.
                    this.Refresh(dealerAgreementConsumablesPage);
                    return null;
                }, RuntimeSettings.DefaultWaitForItemTimeout * 10, "SnapAgreementPagesValues()>ParseDealerAgreementConsumablesPage() Order Date visible T/O. "),
            RuntimeSettings.DefaultWaitForItemTimeout , "SnapAgreementPagesValues()>ParseDealerAgreementConsumablesPage() Order Date visible Too Slow. ");
            _contextData.SnapValues[typeof(DealerAgreementConsumablesPage)] = consumablesPageValues;

            // restore current tab
            ClickSafety(dealerAgreementConsumablesPage.BillingTabElement, dealerAgreementServiceRequestsPage, IsUntilUrlChanges: true);
        }

        public DealerReportsDashboardPage NavigateToReportsDashboardPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            ClickSafety(dealerDashboardPage.DealerReportLinkElement, dealerDashboardPage, IsUntilUrlChanges: true);
            return PageService.GetPageObject<DealerReportsDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public string DownloadCPPAgreementDevicesReport(DealerReportsDashboardPage dealerReportsDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerReportsDashboardPage);
            var xlsxfile = _cppAgreementDevicesExcelHelper.Download(() => { ClickSafety(dealerReportsDashboardPage.CppAgreementDevicesReportElement, dealerReportsDashboardPage); return true; });
            return xlsxfile;
        }

        public void VerifyCheckDataInTheCPPAgreementDeviceReport(string excelFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(excelFilePath);
            var actualProps = _cppAgreementDevicesExcelHelper.Parse(excelFilePath);

            _cppAgreementDevicesExcelHelper.AssertAreEqualProperties(
                _contextData.SnapValues[typeof(DealerAgreementCreateSummaryPage)],
                _contextData.SnapValues[typeof(DealerAgreementDevicesPage)],
                _contextData.SnapValues[typeof(DealerAgreementServiceRequestsPage)],
                _contextData.SnapValues[typeof(DealerAgreementConsumablesPage)],
                actualProps, _contextData.AgreementId, _contextData.Country, 
                "wrong params file=" + excelFilePath);
        }

        public void AssertAreEqualServiceInstallation(DealerAgreementCreateSummaryPage dealerAgreementCreateSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateSummaryPage);
            var pageValues = _pageParseHelper.ParseSummaryPageValues(dealerAgreementCreateSummaryPage.SeleniumHelper);
            var printersProperties = _contextData.PrintersProperties;
            foreach( var prop in printersProperties)
            {
                var model = prop.Model;
                var keySp = model + ".ServicePackSku";
                var exceptServicePack = "Yes".Equals(prop.ServicePack, StringComparison.OrdinalIgnoreCase); ;
                var actualServicePack = pageValues.ContainsKey(keySp) && string.IsNullOrWhiteSpace(pageValues[keySp]) == false ;
                Assert.AreEqual(exceptServicePack, actualServicePack, "Wrong Service Pack status for device with model = " + model);

                var keyIp = model + ".InstallationPackSku";
                var exceptInstallationPack = "Yes".Equals(prop.InstallationPack, StringComparison.OrdinalIgnoreCase);
                var actualInstallationPack = pageValues.ContainsKey(keyIp) && string.IsNullOrWhiteSpace(pageValues[keyIp]) == false ;
                Assert.AreEqual(exceptInstallationPack, actualInstallationPack, "Wrong Installation Pack status for device with model = " + model);
            }
        }

        public DealerAgreementsListPage ValidateSummaryPageAndCompleteSetup(DealerAgreementCreateSummaryPage dealerAgreementCreateSummaryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateSummaryPage);

            var numberStyles = NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            var cultureInfo = _contextData.CultureInfo == null ? new CultureInfo(_contextData.Culture) : _contextData.CultureInfo;
            _contextData.AgreementId = dealerAgreementCreateSummaryPage.AgreementId();
            _contextData.AgreementDateCreated = MpsUtil.DateTimeString(DateTime.Now, _contextData.Country.CountryIso);

            // Save these details for later verification
            _contextData.ClickRateTotal = dealerAgreementCreateSummaryPage.ClickRateTotal(numberStyles);
            _contextData.InstallationPackTotal = dealerAgreementCreateSummaryPage.InstallationPackTotal(numberStyles);
            _contextData.ServicePackTotal = dealerAgreementCreateSummaryPage.ServicePackTotal(numberStyles);

            // Validate calculations/content on summary page
            ValidateCalculationOnSummaryPage(dealerAgreementCreateSummaryPage);

            // Save click prices in context data to use in verification later
            foreach (var product in _contextData.PrintersProperties)
            {
                product.MonoClickPrice = _calculationService.ConvertCultureNumericStringToInvariantNumericString(dealerAgreementCreateSummaryPage.GetMonoClickPrice(product.Model));
                if (!product.IsMonochrome)
                {
                    product.ColourClickPrice = _calculationService.ConvertCultureNumericStringToInvariantNumericString(dealerAgreementCreateSummaryPage.GetColourClickPrice(product.Model));
                }
            }

            ClickSafety(dealerAgreementCreateSummaryPage.CompleteSetupButton, dealerAgreementCreateSummaryPage);
            dealerAgreementCreateSummaryPage.AcceptJavascriptPopupOnCompleteSetup();
            return PageService.GetPageObject<DealerAgreementsListPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAgreementsListPage NavigateToAgreementsListPage()
        {
            return PageService.LoadUrl<DealerAgreementsListPage>(string.Format("{0}/mps/dealer/agreements/list", UrlResolver.BaseUrl), RuntimeSettings.DefaultPageLoadTimeout, ".mps-dataTables-footer", false, _dealerWebDriver);
        }

        public void ContractShiftBeforeSwapDeviceInstallationRequest(int days)
        {
            LoggingService.WriteLogOnMethodEntry(days);
            // note: run ConstractTimeShiftCommand before PrintCount > 0. 
            // see https://brother-bie.atlassian.net/browse/MPS-5923?focusedCommentId=147451&page=com.atlassian.jira.plugin.system.issuetabpanels:comment-tabpanel#comment-147451
            foreach (var prop in _contextData.AdditionalDeviceProperties)
            {
                prop.MonoPrintCount++;
                _deviceSimulatorService.SetPrintCounts(prop.BocDeviceId, prop.MonoPrintCount, prop.ColorPrintCount); 
                _deviceSimulatorService.NotifyBocOfDeviceChanges(prop.BocDeviceId);
            }
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId, _contextData.Country.CountryIso);
            _runCommandService.RunStartContractCommand();

            _contractShiftService.ContractTimeShiftCommand(_contextData.AgreementId, days, "d", false, false, "Any");

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

        public DealerAgreementsListPage DeleteAgreement(DealerAgreementsListPage dealerAgreementsListPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementsListPage);

            if (dealerAgreementsListPage.VerifyCreatedAgreement(_contextData.AgreementId, _contextData.AgreementName))
            {
                dealerAgreementsListPage.ClickOnDeleteAgreementButton(_contextData.AgreementId);
            }
            else
            {
                throw new Exception(string.Format("Agreement = {0} not found ", _contextData.AgreementId));
            }

            return dealerAgreementsListPage;
        }

        public void VerifyAgreementIsRemoved(DealerAgreementsListPage dealerAgreementsListPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementsListPage);

            dealerAgreementsListPage.VerifyAgreementNotPresent(_contextData.AgreementId);
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

        public DealerAgreementDevicesPage EditDeviceDataBulk(DealerAgreementDevicesPage dealerAgreementDevicesPage, string optionalFields, out string validationExpression)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, optionalFields);
            dealerAgreementDevicesPage.ClickCheckboxSelectAll(true);
            dealerAgreementDevicesPage.ClickOnBulkActionsEditDeviceData();
            dealerAgreementDevicesPage = EditDeviceDataHelper(optionalFields, out validationExpression);

            return dealerAgreementDevicesPage;
        }

        public void VerifyStatusOfDevices(DealerAgreementDevicesPage dealerAgreementDevicesPage, string resourceInstalledPrinterStatus)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, resourceInstalledPrinterStatus);

            // Verify that all devices are in "resourceInstalledPrinterStatus" status
            dealerAgreementDevicesPage.VerifyTheStatusOfAllDevices(resourceInstalledPrinterStatus);
        }

        public void VerifyAddressOfEditedDevice(DealerAgreementDevicesPage dealerAgreementDevicesPage, string validationExpression)
        {
            dealerAgreementDevicesPage.VerifyAddressOfEditedDevice(0, validationExpression); // Verify address of 1st row edited device
            dealerAgreementDevicesPage.VerifyAddressOfEditedDevice(1, validationExpression); // Verify address of 2nd row edited device
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

                if (retries > RuntimeSettings.DefaultRetryCount/2)
                {
                    LoggingService.WriteLog(LoggingLevel.WARNING, string.Format("BOC server is responding slow with respect to BOC PIN generation for agreement {0}", _contextData.AgreementId));
                }

                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    TestCheck.AssertFailTest(
                        string.Format("Number of retries exceeded the default limit during verification of boc pin codes generation for agreement {0}. BOC server may be slow in responding.", _contextData.AgreementId));
                }
            }

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage EditDeviceDataUsingExcelEditOption(DealerAgreementDevicesPage dealerAgreementDevicesPage, string optionalFields)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, optionalFields);
            var excelFilePath = _devicesExcelHelper.Download(() =>
            {
                ClickSafety(dealerAgreementDevicesPage.ExportAllElement, dealerAgreementDevicesPage);
                return true;
            });
            return ProcessExcelEdit(dealerAgreementDevicesPage, excelFilePath, optionalFields);
        }

        public DealerAgreementDevicesPage ProcessExcelEdit(DealerAgreementDevicesPage dealerAgreementDevicesPage, string excelFilePath,  string isOptionalFields)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, excelFilePath, isOptionalFields);

            // 1. Edit Excel
            int rows = _devicesExcelHelper.GetNumberOfRows(excelFilePath);
            _devicesExcelHelper.VerifyTotalNumberOfColumns(excelFilePath); // Verify the total number of columns in excel
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
                device_id = _devicesExcelHelper.EditExcelCustomerInformation(excelFilePath, row, mandatoryFields, nonMandatoryFields);

                // Get the validation expression, i.e., the address string
                validationExpression = dealerAgreementDevicesEditPage.ValidationExpression(LoggingService,
                    mandatoryFields, nonMandatoryFields);

                // Create a tuple of device_id & address string (& add to a list) for a later verification
                validationTupleList.Add(new Tuple<string, string>(device_id, validationExpression));
            }

            // 2. Import Excel
            ImportExcelFile(dealerAgreementDevicesPage, excelFilePath);

            // 3. Call BOC Pin retrieval backend job
            _runCommandService.RunSetupInstalledPrintersCommand();

            // 4. Delete Excel
            _devicesExcelHelper.DeleteExcelFile(excelFilePath);

            dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            // 5. Validation of imported data
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
            var excelFilePath = _devicesExcelHelper.Download(() =>
            {
                ClickSafety(dealerAgreementDevicesPage.ExportDataElement, dealerAgreementDevicesPage);
                return true;
            });
            dealerAgreementDevicesPage = ProcessExcelEdit(dealerAgreementDevicesPage, excelFilePath, optionalFields);

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
                    dealerAgreementDevicesPage.SendInstallationRequest(_userResolver.InstallerUsername);
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
                        dealerAgreementDevicesPage.SendInstallationRequest(_userResolver.InstallerUsername);
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

            // 2. Get Downloaded file path

            string excelFilePath = _devicesExcelHelper.Download(() =>
            {
                // 1. Click Export All button
                ClickSafety(dealerAgreementDevicesPage.ExportAllElement, dealerAgreementDevicesPage);
                return true;
            });

            // 3. Read Excel to retrieve installation details

            int rows = _devicesExcelHelper.GetNumberOfRows(excelFilePath);
            // Set initial value of row = 2 as 1st row is table header information

            List<AdditionalDeviceProperties> additionalDeviceProperties = new List<AdditionalDeviceProperties>();
            for (int row = 2; row <= rows; row++)
            {
                additionalDeviceProperties.Add(_devicesExcelHelper.GetDeviceDetails(excelFilePath, row));
            }

            // Save to context data for later use
            _contextData.AdditionalDeviceProperties = additionalDeviceProperties;
            SavePrinterPropertiesToAdditionalDeviceProperties();

            // 4. Delete Excel
            _devicesExcelHelper.DeleteExcelFile(excelFilePath);
        }

        public void SavePrinterPropertiesToAdditionalDeviceProperties()
        {
            LoggingService.WriteLogOnMethodEntry();
            // Save printer properties to device properties for future validation
            foreach (var product in _contextData.PrintersProperties)
            {
                foreach (var device in _contextData.AdditionalDeviceProperties)
                {
                    if (device.Model.Equals(product.Model))
                    {
                        device.MonoClickPrice = product.MonoClickPrice;
                        device.ColourClickPrice = product.ColourClickPrice;
                        device.VolumeMono = product.VolumeMono;
                        device.VolumeColour = product.VolumeColour;
                        device.IsMonochrome = product.IsMonochrome;
                        device.ServicePack = product.ServicePack;
                        device.InstallationPack = product.InstallationPack;
                        device.ResetDevice = product.ResetDevice;
                        device.IsSwap = product.IsSwap;
                        device.ReInstallDevice = product.ReInstallDevice;
                        device.CoverageMono = product.CoverageMono;
                        device.CoverageColour = product.CoverageColour;
                        device.MonoThresholdValue = product.MonoThresholdValue;
                        device.ColourThresholdValue = product.ColourThresholdValue;
                    }
                }
            }
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

            // Verify status icon
            if(_contextData.CommunicationMethod.ToLower().Equals("cloud"))
            {
                dealerAgreementDevicesPage.VerifyStatusIconOfAllDevices(dealerAgreementDevicesPage.CloudStatusIconSelector);
            }
            else if (_contextData.CommunicationMethod.ToLower().Equals("email"))
            {
                dealerAgreementDevicesPage.VerifyStatusIconOfAllDevices(dealerAgreementDevicesPage.EmailStatusIconSelector);
            }

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

                // Save Address string of the devices into context data
                dealerAgreementDevicesPage.SaveAddressString(device);
            }

            // Verify updated devices' data in excel sheet
            VerifyUpdatedDeviceDataInExcelSheet(
                dealerAgreementDevicesPage, resourceDeviceConnectionStatusResponding, resourceInstalledPrinterStatusInstalled);


            // Save service pack & installation prices for all devices used for later verification
            ClickSafety(dealerAgreementDevicesPage.DetailsTabElement, dealerAgreementDevicesPage);
            var dealerAgreementDetailsPage = PageService.GetPageObject<DealerAgreementDetailsPage>(
                RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                device.InstallationPackPrice = _calculationService.ConvertCultureNumericStringToInvariantNumericString(dealerAgreementDetailsPage.GetInstallationPackPrice(device.Model));
                device.ServicePackPrice = _calculationService.ConvertCultureNumericStringToInvariantNumericString(dealerAgreementDetailsPage.GetServicePackPrice(device.Model));
            }

            ClickSafety(dealerAgreementDetailsPage.DevicesTabElement, dealerAgreementDetailsPage);
            dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(
                RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage VerifyUpdatedPrintCounts(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            // Refreshes the print counts on MPS portal (after synchronizing BOC values)
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId, _contextData.Country.CountryIso);

            // Switch back to Dealer window
            _dealerWebDriver.SwitchTo().Window(_contextData.WindowHandles[UserType.Dealer]);

            // Refresh page until print counts are updated
            int retries = 0;
            while(!dealerAgreementDevicesPage.IsPrintCountsUpdated())
            {
                _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId, _contextData.Country.CountryIso);
                
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
                            ClickSafety(dealerAgreementConsumablesCreatePage.BackButtonElement, dealerAgreementConsumablesCreatePage, true);

                            dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                        }
                    }
                }
            }

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage VerifyConsumableOrders(DealerAgreementDevicesPage dealerAgreementDevicesPage, string resourceConsumableOrderMethod)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, resourceConsumableOrderMethod);
            string resourceConsumableOrderStatusInProgress = _translationService.GetConsumableOrderStatusText(TranslationKeys.ConsumableOrderStatus.InProgress, _contextData.Culture);

            // Verify consumable order information one by one
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                // In order to be able to use the same function for checking either automatic or manual consumable order this logic is implemented to check the 
                // order method is manual or automatic explicitly
                if ((resourceConsumableOrderMethod.ToLower().Equals("manual") && device.hasEmptyInkToner) ||
                    (resourceConsumableOrderMethod.ToLower().Equals("automatic") && device.hasLowRemLifeInkToner))
                {
                    dealerAgreementDevicesPage.ClickShowConsumableOrders(device.MpsDeviceId);
                    var dealerAgreementDeviceConsumablesPage = PageService.GetPageObject<DealerAgreementDeviceConsumablesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                    int retries = 0;

                    while(dealerAgreementDeviceConsumablesPage.IsNoConsumablesFound())
                    {
                        _mpsApiStepActions.UpdateMPSForConsumableOrder();

                        // Refresh page
                        _dealerWebDriver.Navigate().Refresh();
                        dealerAgreementDeviceConsumablesPage = PageService.GetPageObject<DealerAgreementDeviceConsumablesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                        retries++;
                        if (retries > RuntimeSettings.DefaultRetryCount)
                        {
                            throw new Exception(
                                string.Format("Number of retries exceeded the default limit during verification of consumable order generation for agreement {0}", _contextData.AgreementId));
                        }
                    }

                    dealerAgreementDeviceConsumablesPage.VerifyConsumableOrderInformation(device.SerialNumber, resourceConsumableOrderStatusInProgress, resourceConsumableOrderMethod);

                    ClickSafety(dealerAgreementDeviceConsumablesPage.BackButtonElement, dealerAgreementDeviceConsumablesPage, true);
                    dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                }
            }

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage RaiseServiceRequestsManually(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            string resourceServiceRequestStatusNew = _translationService.GetServiceRequestStatusText(TranslationKeys.ServiceRequestStatus.New, _contextData.Culture);

            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                device.OpenServiceRequest = device.OpenServiceRequest + 1;
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
                    dealerAgreementServiceRequestsPage.DevicesTabElement, dealerAgreementServiceRequestsPage, IsUntilUrlChanges: true);

                _dealerWebDriver.Navigate().Refresh();

                dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            }

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage VerifyServiceRequestStatus(DealerAgreementDevicesPage dealerAgreementDevicesPage, string resourceServiceRequestStatus)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, resourceServiceRequestStatus);
            ClickSafety(dealerAgreementDevicesPage.ServiceRequestsTabElement, dealerAgreementDevicesPage);

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

            ClickSafety(dealerAgreementServiceRequestsPage.DevicesTabElement, dealerAgreementServiceRequestsPage);
            return PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifyDeviceDetails(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                dealerAgreementDevicesPage.ClickShowDeviceDetails(device.MpsDeviceId);
                dealerAgreementDevicesPage.VerifyDeviceDetails(device, _contextData.AgreementType, _contextData.ContractTerm, _contextData.UsageType);

                _dealerWebDriver.Navigate().Refresh();
                dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            }
        }

        public void VerifyDeviceDetailsOnDashboard(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);

            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                dealerAgreementDevicesPage.ClickShowDeviceDetails(device.MpsDeviceId);
                var dealerDeviceOverviewPage = PageService.GetPageObject<DealerDeviceOverviewPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                dealerDeviceOverviewPage.VerifyDeviceDetails(device, _contextData.AgreementType, _contextData.ContractTerm, _contextData.UsageType);

                ClickSafety(dealerDeviceOverviewPage.ButtonBackElement, dealerDeviceOverviewPage, true);
                dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            }
        }

        public void VerifyDeviceAndGraphDetails(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);

            foreach ( var device in _contextData.AdditionalDeviceProperties)
            {
                dealerAgreementDevicesPage.ClickShowDeviceDetails(device.MpsDeviceId);
                var dealerDeviceOverviewPage = PageService.GetPageObject<DealerDeviceOverviewPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                //Verify the print count details
                dealerDeviceOverviewPage.VerifyPrintCount(device);

                //Verify the consumable details
                var bocSupplyItems = _deviceSimulatorService.GetSupply(device.BocDeviceId);
                var consumableTextContent = dealerDeviceOverviewPage.ConsumablesGraphDataElement.GetAttribute("textContent");
                var consumableJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(consumableTextContent);

                //Black consumable order  
                var bocTonerInkReplaceCount = GetBocSimValue(bocSupplyItems, "TonerInk_ReplaceCount_Black");
                var bocTonerInkLife = GetBocSimValue(bocSupplyItems, "TonerInk_Life_Black");
                var latestDate = (_contextData.AgreementStartDate != "0") ? _contextData.AgreementStartDate : "";
                dealerDeviceOverviewPage.VerifyConsumableBlack(device, consumableJson, bocTonerInkReplaceCount, bocTonerInkLife, latestDate);

                if (device.IsMonochrome == false)
                {
                    //Cyan consumable order
                    bocTonerInkReplaceCount = GetBocSimValue(bocSupplyItems, "TonerInk_ReplaceCount_Cyan");
                    bocTonerInkLife = GetBocSimValue(bocSupplyItems, "TonerInk_Life_Cyan");
                    dealerDeviceOverviewPage.VerifyConsumableCyan(device, consumableJson, bocTonerInkReplaceCount, bocTonerInkLife, latestDate);

                    //Magenta consumable order
                    bocTonerInkReplaceCount = GetBocSimValue(bocSupplyItems, "TonerInk_ReplaceCount_Magenta");
                    bocTonerInkLife = GetBocSimValue(bocSupplyItems, "TonerInk_Life_Magenta");
                    dealerDeviceOverviewPage.VerifyConsumableMagenta(device, consumableJson, bocTonerInkReplaceCount, bocTonerInkLife, latestDate);

                    //Yellow consumable order
                    bocTonerInkReplaceCount = GetBocSimValue(bocSupplyItems, "TonerInk_ReplaceCount_Yellow");
                    bocTonerInkLife = GetBocSimValue(bocSupplyItems, "TonerInk_Life_Yellow");
                    dealerDeviceOverviewPage.VerifyConsumableYellow(device, consumableJson, bocTonerInkReplaceCount, bocTonerInkLife, latestDate);
                }

                //Verify the service request details
                var serviceRequestTextContent = dealerDeviceOverviewPage.ServiceRequestGraphDataElement.GetAttribute("textContent");
                var serviceRequestJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(serviceRequestTextContent);
                dealerDeviceOverviewPage.VerifyServiceRequest(device, serviceRequestJson, latestDate);

                //Verify the silent device details
                var silentTextContent = dealerDeviceOverviewPage.SilentGraphDataElement.GetAttribute("textContent");
                var silentJson = JsonConvert.DeserializeObject<Dictionary<string, object>>(silentTextContent);
                dealerDeviceOverviewPage.VerifySilentDetails(device, silentJson, _contextData.AgreementShiftDays);

                ClickSafety(dealerDeviceOverviewPage.ButtonBackElement, dealerDeviceOverviewPage, true);
                dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            }
        }

        public void VerifyInformationOtherThanOverviewOnDeviceDetails(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);

            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                dealerAgreementDevicesPage.ClickShowDeviceDetails(device.MpsDeviceId);
                var dealerDeviceOverviewPage = PageService.GetPageObject<DealerDeviceOverviewPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                //Verify print detail page
                dealerDeviceOverviewPage.SeleniumHelper.ClickSafety(dealerDeviceOverviewPage.PrintDetailTabElement);
                var dealerDevicePrintDetailPage = PageService.GetPageObject<DealerDevicePrintDetailPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                dealerDevicePrintDetailPage.VerifyChartDisplayed();
                ClickSafety(dealerDeviceOverviewPage.ButtonBackElement, dealerDeviceOverviewPage, true);
                dealerDeviceOverviewPage = PageService.GetPageObject<DealerDeviceOverviewPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                //Verify consumable orders page
                dealerDeviceOverviewPage.SeleniumHelper.ClickSafety(dealerDeviceOverviewPage.ConsumableOrdersTabElement);
                var dealerDeviceConsumableOrdersPage = PageService.GetPageObject<DealerDeviceConsumableOrdersPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                var resourceConsumableOrderMethodManual = _translationService.GetConsumableOrderMethodText(TranslationKeys.ConsumableOrderMethod.Manual, _contextData.Culture);
                var resourceConsumableOrderMethodAutomatic = _translationService.GetConsumableOrderMethodText(TranslationKeys.ConsumableOrderMethod.Automatic, _contextData.Culture);
                dealerDeviceConsumableOrdersPage.VerifyManualConsumableOrder(device, resourceConsumableOrderMethodManual, _contextData.AgreementStartDate);
                dealerDeviceConsumableOrdersPage.VerifyAutomaticConsumableOrder(device, resourceConsumableOrderMethodAutomatic, _contextData.AgreementStartDate);
                ClickSafety(dealerDeviceOverviewPage.ButtonBackElement, dealerDeviceOverviewPage, true);
                dealerDeviceOverviewPage = PageService.GetPageObject<DealerDeviceOverviewPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                //Verify Service request page
                dealerDeviceOverviewPage.SeleniumHelper.ClickSafety(dealerDeviceOverviewPage.ServiceRequestsTabElement);
                var dealerDeviceServiceRequestsPage = PageService.GetPageObject<DealerDeviceServiceRequestsPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                dealerDeviceServiceRequestsPage.VerifyServiceRequets(device);
                ClickSafety(dealerDeviceOverviewPage.ButtonBackElement, dealerDeviceOverviewPage, true);
                dealerDeviceOverviewPage = PageService.GetPageObject<DealerDeviceOverviewPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                //Verify Silent page
                dealerDeviceOverviewPage.SeleniumHelper.ClickSafety(dealerDeviceOverviewPage.SilentTabElement);
                var dealerDeviceSilentPage = PageService.GetPageObject<DealerDeviceSilentPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                dealerDeviceSilentPage.VerifySilentInfo(_contextData.AgreementStartDate, _contextData.AgreementShiftDays);
                ClickSafety(dealerDeviceOverviewPage.ButtonBackElement, dealerDeviceOverviewPage, true);
                dealerDeviceOverviewPage = PageService.GetPageObject<DealerDeviceOverviewPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                //Go back to agreement devices page
                ClickSafety(dealerDeviceOverviewPage.ButtonBackElement, dealerDeviceOverviewPage, true);
                dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
            }
        }

        private string GetBocSimValue(IEnumerable<BocSupplyItem> bocSupplyItems, string kw)
        {
            var item = bocSupplyItems.FirstOrDefault(itm => itm.item == kw);
            Assert.NotNull(item, "VerifyConsumables get value not found. BOCSim.key={0}", kw);
            Assert.True(item.success, "VerifyConsumables get value error. BOCSim.key={0}", kw);
            return item.value.ToString();
        }

        public DealerAgreementBillingPage VerifyClickRateInvoice(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            ClickSafety(dealerAgreementDevicesPage.BillingTabElement, dealerAgreementDevicesPage);
            var dealerAgreementBillingPage = PageService.GetPageObject<DealerAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            int rowIndex = 0;
            int retries = 0;


            // Refresh the billing page if the click rate total for first billing period is not already populated
            while (!dealerAgreementBillingPage.IsClickRateTotalPopulated(rowIndex))
            {
                _dealerWebDriver.Navigate().Refresh();
                dealerAgreementBillingPage = PageService.GetPageObject<DealerAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    TestCheck.AssertFailTest(
                        "Number of retries exceeded the default limit during verification of click rate billing (invoice not generated) for agreement {0}" + _contextData.AgreementId);
                }
            }

            retries = 0;

            // Verify Click rate invoice
            while (true) // As don't know how many invoices will be generated (it depends on the time the agreement is shifted backwards)
            {
                if (dealerAgreementBillingPage.IsClickRateTotalPopulated(rowIndex))
                {
                    // 1. Download click rate invoice excel
                    string excelFilePath = _clickBillExcelHelper.Download(() =>
                        {
                            dealerAgreementBillingPage.ClickDownloadClickRateBill(rowIndex);
                            return true;
                        });

                    // Get expected values
                    string startDate = dealerAgreementBillingPage.GetBillingStartDate(rowIndex);
                    string endDate = dealerAgreementBillingPage.GetBillingEndDate(rowIndex);
                    string expectedClickRateTotal = dealerAgreementBillingPage.GetBillingClickRateTotal(rowIndex);
                    bool isFirstBillingPeriod = false;

                    if (rowIndex == 0)
                    {
                        isFirstBillingPeriod = true;
                    }

                    // 2. Verify click rate invoice excel
                    _clickBillExcelHelper.VerifySummaryWorksheet(excelFilePath, startDate, endDate, _calculationService.ConvertCultureNumericStringToInvariantNumericString(expectedClickRateTotal));
                    _clickBillExcelHelper.VerifyClickChargesWorksheet(excelFilePath, startDate, endDate, isFirstBillingPeriod);

                    // 3. Delete excel file
                    _clickBillExcelHelper.DeleteExcelFile(excelFilePath);

                    // Refresh page to load any unloaded invoices onto billing page
                    _dealerWebDriver.Navigate().Refresh();
                    dealerAgreementBillingPage = PageService.GetPageObject<DealerAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                    rowIndex++;
                    retries = 0; // Reset retries count
                }
                else
                {
                    // Refresh page to load any unloaded invoices onto billing page
                    _dealerWebDriver.Navigate().Refresh();
                    dealerAgreementBillingPage = PageService.GetPageObject<DealerAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                    retries++;
                    if (retries >= 2)
                    {
                        break;
                    }
                }
            }

            return dealerAgreementBillingPage;
        }

        public DealerAgreementBillingPage VerifyServiceInstallationInvoice(DealerAgreementBillingPage dealerAgreementBillingPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementBillingPage);

            // Verify that no invoice is generated if installation packs/service packs (for all devices) are not selected

            bool shouldGenerateInvoice = false;
            foreach(var product in _contextData.PrintersProperties)
            {
                if (product.ServicePack.ToLower().Equals("yes") || product.InstallationPack.ToLower().Equals("yes"))
                {
                    shouldGenerateInvoice = true;
                }
            }

            int retries = 0;
            if (!shouldGenerateInvoice)
            {
                // Verify that no invoice is generated and make sure by retrying a few times
                while (retries < 2)
                {
                    TestCheck.AssertIsEqual(
                        false, dealerAgreementBillingPage.IsServiceInstallationTotalPopulated(0), string.Format("Service/Installation invoice is generated even when no service pack/installation pack was selected for any device for agreement {0}", _contextData.AgreementId));

                    _dealerWebDriver.Navigate().Refresh();
                    dealerAgreementBillingPage = PageService.GetPageObject<DealerAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                    retries++;
                }
            }
            else
            {
                // Verify the invoice details

                // Refresh the billing page if the service/installation total for first billing period is not already populated
                while (!dealerAgreementBillingPage.IsServiceInstallationTotalPopulated(0))
                {
                    _dealerWebDriver.Navigate().Refresh();
                    dealerAgreementBillingPage = PageService.GetPageObject<DealerAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
                    retries++;
                    if (retries > RuntimeSettings.DefaultRetryCount)
                    {
                        TestCheck.AssertFailTest(
                            "Number of retries exceeded the default limit during verification of service installation billing (invoice not generated) for agreement {0}" + _contextData.AgreementId);
                    }
                }

                int rowIndex = 0;

                // 1. Download service installation invoice excel
                string excelFilePath = _serviceInstallationBillExcelHelper.Download(() =>
                    {
                        dealerAgreementBillingPage.ClickDownloadServiceInstallationBill(rowIndex);
                        return true;
                    }
                    );

                // Get expected values
                string startDate = dealerAgreementBillingPage.GetBillingStartDate(rowIndex);
                string endDate = dealerAgreementBillingPage.GetBillingEndDate(rowIndex);
                string expectedServiceInstallationTotal = dealerAgreementBillingPage.GetServiceInstallationTotal(rowIndex);

                // 2. Verify service installation invoice excel
                _serviceInstallationBillExcelHelper.VerifyDetailWorksheet(excelFilePath, startDate, endDate, _calculationService.ConvertCultureNumericStringToInvariantNumericString(expectedServiceInstallationTotal));

                // 3. Delete excel file
                _serviceInstallationBillExcelHelper.DeleteExcelFile(excelFilePath);
            }


            return dealerAgreementBillingPage;
        }

        public DealerAgreementDevicesPage SendSwapDeviceInstallationRequest(DealerAgreementDevicesPage dealerAgreementDevicesPage, string swapDeviceType)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, swapDeviceType);

            string resourceInstalledPrinterBeingReplacedStatus = _translationService.GetInstalledPrinterStatusText(
                TranslationKeys.InstalledPrinterStatus.BeingReplaced, _contextData.Culture);
            string resourceInstalledPrinterTypeCloud = _translationService.GetCommunicationMethodText(
                TranslationKeys.CommunicationMethod.Cloud, _contextData.Culture); //"Cloud" 
            string resourceDeviceConnectionStatusResponding = _translationService.GetDeviceConnectionStatusText(
                TranslationKeys.DeviceConnectionStatus.Responding, _contextData.Culture);

            // Switch back to Dealer window
            _dealerWebDriver.SwitchTo().Window(_contextData.WindowHandles[UserType.Dealer]);

            // Refresh once to reflect any changes if present
            _dealerWebDriver.Navigate().Refresh();
            dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(
                RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            List<AdditionalDeviceProperties> newDevices = new List<AdditionalDeviceProperties>();

            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                if (device.IsSwap)
                {
                    dealerAgreementDevicesPage.ClickSwapDeviceInActions(device.MpsDeviceId);

                    var newModel = dealerAgreementDevicesPage.VerifySwapModalAndFillDetails(
                        device, swapDeviceType, _contextData.Culture, _userResolver.InstallerUsername);
                    dealerAgreementDevicesPage.ClickSendSwapRequestAndVerify();

                    dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(
                        RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

                    // Verify "Being Replaced" status for this device
                    var newDeviceId = dealerAgreementDevicesPage.VerifyStatusOfDevice(device, resourceInstalledPrinterBeingReplacedStatus, resourceInstalledPrinterTypeCloud, resourceDeviceConnectionStatusResponding);
                    dealerAgreementDevicesPage.VerifyStatusIconUsingDeviceId(newDeviceId, dealerAgreementDevicesPage.SwapBeingReplaceStatusIconSelector);

                    // Save info for new device to context data
                    device.SwappedDeviceID = newDeviceId;
                    var swapProp = new AdditionalDeviceProperties() { Model = newModel, MpsDeviceId = newDeviceId, IsMonochrome = true, IsSwappedInDevice = true };
                    dealerAgreementDevicesPage.SaveAddressString(swapProp);
                    newDevices.Add(swapProp); // Handle only monochrome (swapped in) devices for now
                }
            }

            _contextData.AdditionalDeviceProperties.AddRange(newDevices);

            return dealerAgreementDevicesPage;
        }

        public DealerAgreementDevicesPage VerifyStatusOfSwappedInAndSwappedOutDevices(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);

            // Switch back to Dealer window
            _dealerWebDriver.SwitchTo().Window(_contextData.WindowHandles[UserType.Dealer]);

            // Refresh so that device statuses are updated after swap installation
            _dealerWebDriver.Navigate().Refresh();
            dealerAgreementDevicesPage = PageService.GetPageObject<DealerAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            string resourceInstalledPrinterReplacedStatus = _translationService.GetInstalledPrinterStatusText(
                TranslationKeys.InstalledPrinterStatus.Replaced, _contextData.Culture);
            string resourceDeviceConnectionStatusSwapped = _translationService.GetDeviceConnectionStatusText(
                TranslationKeys.DeviceConnectionStatus.Swapped, _contextData.Culture);
            string resourceInstalledPrinterStatusInstalled = _translationService.GetInstalledPrinterStatusText(
                TranslationKeys.InstalledPrinterStatus.InstalledType3, _contextData.Culture);
            string resourceDeviceConnectionStatusResponding = _translationService.GetDeviceConnectionStatusText(
                TranslationKeys.DeviceConnectionStatus.Responding, _contextData.Culture);

            foreach(var device in _contextData.AdditionalDeviceProperties)
            {
                if(device.IsSwap) //Swapped out device (old device)
                {
                    dealerAgreementDevicesPage.VerifyStatusIconUsingSerialNumber(device.SerialNumber, dealerAgreementDevicesPage.SwapReplacedStatusIconSelector);
                    dealerAgreementDevicesPage.VerifyStatusOfDevice(device, resourceInstalledPrinterReplacedStatus);
                    dealerAgreementDevicesPage.VerifyStatusOfDevice(device, resourceDeviceConnectionStatusSwapped);
                }
                else // Swapped in device (new device) plus remaining devices
                {
                    if (_contextData.CommunicationMethod.ToLower().Equals("cloud"))
                    {
                        dealerAgreementDevicesPage.VerifyStatusIconUsingSerialNumber(device.SerialNumber, dealerAgreementDevicesPage.CloudStatusIconSelector);
                    }
                    else if (_contextData.CommunicationMethod.ToLower().Equals("email"))
                    {
                        dealerAgreementDevicesPage.VerifyStatusIconUsingSerialNumber(device.SerialNumber, dealerAgreementDevicesPage.EmailStatusIconSelector);
                    }

                    dealerAgreementDevicesPage.VerifyStatusOfDevice(device, resourceInstalledPrinterStatusInstalled);
                    dealerAgreementDevicesPage.VerifyStatusOfDevice(device, resourceDeviceConnectionStatusResponding);

                    if(device.IsSwappedInDevice)
                    {
                        foreach(var oldDevice in _contextData.AdditionalDeviceProperties)
                        {
                            if(device.MpsDeviceId.Equals(oldDevice.SwappedDeviceID))
                            {
                                dealerAgreementDevicesPage.VerifySwappedInDeviceAddressString(oldDevice, device);
                                break;
                            }
                        }
                    }
                }
            }

            return dealerAgreementDevicesPage;
        }

        public DealerReportsDashboardPage NavigateToReports(DealerAgreementDevicesPage dealerAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage);
            ClickSafety(dealerAgreementDevicesPage.ReportTabElement, dealerAgreementDevicesPage);
            return PageService.GetPageObject<DealerReportsDashboardPage>(
                        RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void DownloadCPPAgreementReportAndVerify(DealerReportsDashboardPage dealerReportsDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerReportsDashboardPage);

            // Download excel
            string excelFilePath = _cppAgreementHelper.Download(() =>
            {
                ClickSafety(dealerReportsDashboardPage.CppAgreementReportElement, dealerReportsDashboardPage);
                return true;
            });

            // Verify agreement details
            _cppAgreementHelper.VerifyAgreementDetails(excelFilePath);
            
            // Delete excel
            _cppAgreementHelper.DeleteExcelFile(excelFilePath);
        }

        public DealerAgreementDevicesPage VerifyThatDevicesAreSilent(DealerAgreementDevicesPage dealerAgreementDevicesPage,
            string resourceInstalledPrinterStatusInstalled, string resourceDeviceConnectionStatusSilent)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, resourceInstalledPrinterStatusInstalled, resourceDeviceConnectionStatusSilent);
            // Switch back to Dealer window
            _dealerWebDriver.SwitchTo().Window(_contextData.WindowHandles[UserType.Dealer]);

            // Refresh to reflect the device status changes
            dealerAgreementDevicesPage = Refresh(dealerAgreementDevicesPage);

            // Verify status icon
            if (_contextData.CommunicationMethod.ToLower().Equals("cloud"))
            {
                dealerAgreementDevicesPage.VerifyStatusIconOfAllDevices(dealerAgreementDevicesPage.CloudStatusIconSelector);
            }
            else if (_contextData.CommunicationMethod.ToLower().Equals("email"))
            {
                dealerAgreementDevicesPage.VerifyStatusIconOfAllDevices(dealerAgreementDevicesPage.EmailStatusIconSelector);
            }

            // Verify that devices are installed
            VerifyStatusOfDevices(dealerAgreementDevicesPage, resourceInstalledPrinterStatusInstalled);

            // Verify that devices are responding
            VerifyStatusOfDevices(dealerAgreementDevicesPage, resourceDeviceConnectionStatusSilent);

            return dealerAgreementDevicesPage;
        }

        public void RunSendSilentDevicesReportsCommand()
        {
            LoggingService.WriteLogOnMethodEntry();

            _runCommandService.RunSendSilentDevicesReportsCommand();
        }

        public void DownloadSilentDeviceReportAndVerifyDevices()
        {
            LoggingService.WriteLogOnMethodEntry();

            string silentDeviceCsvData = _mpsWebToolsService.DownloadSilentDeviceReport();
            var splitSilentDeviceCsvData = silentDeviceCsvData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach(var device in _contextData.AdditionalDeviceProperties)
            {
                var IsPresent = false;
                foreach (var line in splitSilentDeviceCsvData)
                {
                    try
                    {
                        string[] parts = line.Split(',');
                        var checkString = string.Join(" ", parts);
                        if (checkString.Contains(device.SerialNumber))
                        {
                            IsPresent = true;
                            break;
                        }
                    }
                    catch { }
                }
                if(IsPresent == false)
                {
                    throw new Exception(string.Format("Serial Number = {0} not present in the silent device report", device.SerialNumber));
                }
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

        private void PopulatePrinterCoverageAndVolume(DealerAgreementCreateClickPricePage dealerAgreementCreateClickPricePage, PrinterProperties product)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementCreateClickPricePage, product);
            string resourceUsageTypePayAsYouGo = _translationService.GetUsageTypeText(
                TranslationKeys.UsageType.PayAsYouGo, _contextData.Culture);
            product.IsMonochrome = dealerAgreementCreateClickPricePage.PopulatePrinterCoverageAndVolume(
                product.Model, product.CoverageMono, product.VolumeMono, product.CoverageColour, product.VolumeColour, _contextData.UsageType, resourceUsageTypePayAsYouGo);
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
            _calculationService.VerifyMultiplication(installationPackQuantity, installationPackUnitPrice, _calculationService.ConvertCultureNumericStringToInvariantNumericString(installationPackTotalPrice));
            _calculationService.VerifyMultiplication(servicePackQuantity, servicePackUnitPrice, _calculationService.ConvertCultureNumericStringToInvariantNumericString(servicePackTotalPrice));
            _calculationService.VerifySum(new List<string> {
                _calculationService.ConvertCultureNumericStringToInvariantNumericString(installationPackTotalPrice),
                _calculationService.ConvertCultureNumericStringToInvariantNumericString(servicePackTotalPrice)},
                _calculationService.ConvertCultureNumericStringToInvariantNumericString(totalLinePrice));
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
            _calculationService.VerifyGrossPrice(_calculationService.ConvertCultureNumericStringToInvariantNumericString(dealerAgreementCreateSummaryPage.AgreementGrandTotalPriceNetElement.Text),
                _calculationService.ConvertCultureNumericStringToInvariantNumericString(dealerAgreementCreateSummaryPage.AgreementGrandTotalPriceGrossElement.Text));
        }

        private void VerifyUpdatedDeviceDataInExcelSheet(
            DealerAgreementDevicesPage dealerAgreementDevicesPage, string resourceDeviceConnectionStatusResponding, string resourceInstalledPrinterStatusInstalled)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAgreementDevicesPage, resourceDeviceConnectionStatusResponding, resourceInstalledPrinterStatusInstalled);

            // 2. Get Downloaded file path

            string excelFilePath = _devicesExcelHelper.Download(() =>
            {
                // 1. Click Export All button
                ClickSafety(dealerAgreementDevicesPage.ExportAllElement, dealerAgreementDevicesPage);
                return true;
            });

            // 3. Verify Device status & Connection status mentioned in excel
            int rows = _devicesExcelHelper.GetNumberOfRows(excelFilePath);
            // Set initial value of row = 2 as 1st row is table header information
            for (int row = 2; row <= rows; row++)
            {
                _devicesExcelHelper.VerifyDeviceStatusAndConnectionStatus(
                    excelFilePath, row, resourceInstalledPrinterStatusInstalled, resourceDeviceConnectionStatusResponding);
            }

            // 4. Delete Excel
            _devicesExcelHelper.DeleteExcelFile(excelFilePath);
        }
        #endregion

    }
}
