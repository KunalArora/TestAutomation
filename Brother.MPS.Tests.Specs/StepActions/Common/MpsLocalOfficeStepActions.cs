using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers.ExcelHelpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Common
{
    public class MpsLocalOfficeStepActions: StepActionBase
    {
        private readonly IContextData _contextData;
        private readonly ITranslationService _translationService;
        private readonly IRunCommandService _runCommandService;
        private readonly IClickBillExcelHelper _clickBillExcelHelper;

        public MpsLocalOfficeStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ILoggingService loggingService,
            IRuntimeSettings runtimeSettings,
            ITranslationService translationService,
            IRunCommandService runCommandService,
            IClickBillExcelHelper clickBillExcelHelper)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _contextData = contextData;
            _translationService = translationService;
            _runCommandService = runCommandService;
            _clickBillExcelHelper = clickBillExcelHelper;
        }

        public LocalOfficeApproverReportsProposalSummaryPage NavigateToContractsSummaryPage(DataQueryPage dataQueryPage, IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage, webDriver);
            dataQueryPage.FilterAndClickAgreement(_contextData.ProposalId);
            return PageService.GetPageObject<LocalOfficeApproverReportsProposalSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
        }
      
        public LocalOfficeAgreementDevicesPage NavigateToAgreementDevicesPage(DataQueryPage dataQueryPage, IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage, webDriver);

            dataQueryPage.FilterAndClickAgreement(_contextData.AgreementId);
            var localOfficeAgreementSummaryPage = PageService.GetPageObject<LocalOfficeAgreementSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

            // Save dealer details for future validation
            _contextData.DealerName = localOfficeAgreementSummaryPage.DealershipNameElement.Text;
            _contextData.DealerSAPAccountNumber = localOfficeAgreementSummaryPage.DealershipSapNumberElement.Text;

            ClickSafety(localOfficeAgreementSummaryPage.DevicesTabElement(_contextData.AgreementId), localOfficeAgreementSummaryPage, isUntilUrlChanges:true);
            return PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
        }

        public LocalOfficeAgreementDevicesPage SendBulkInstallationRequest(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage, webDriver);
            var deviceRowCount = localOfficeAgreementDevicesPage.DeviceTableRowsCount();
            int devicesInstallingCount = 0;

            // Tick checkboxes of devices which are to be installed according to feature file configuration
            for (int rowIndex = 0; rowIndex < deviceRowCount; rowIndex++)
            {
                string displayedModelName = localOfficeAgreementDevicesPage.DeviceModelName(rowIndex);
                foreach (var product in _contextData.PrintersProperties)
                {
                    if (displayedModelName.Equals(product.Model) && product.SendInstallationRequest.ToLower().Equals("yes"))
                    {
                        localOfficeAgreementDevicesPage.ClickOnDeviceCheckbox(rowIndex);
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
                    localOfficeAgreementDevicesPage = SendSingleInstallationRequests(
                        localOfficeAgreementDevicesPage, webDriver);
                    break;

                default: // For Bulk installation request
                    // Click Send Installation Request button (used for bulk)
                    ClickSafety(localOfficeAgreementDevicesPage.SendInstallationRequestElement, localOfficeAgreementDevicesPage);
                    localOfficeAgreementDevicesPage.SendInstallationRequest();
                    break;
            }

            return localOfficeAgreementDevicesPage;
        }

        public LocalOfficeAgreementDevicesPage SendSingleInstallationRequests(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage, webDriver);
            var deviceRowCount = localOfficeAgreementDevicesPage.DeviceTableRowsCount();

            // Tick checkboxes of devices which are to be installed according to feature file configuration
            for (int rowIndex = 0; rowIndex < deviceRowCount; rowIndex++)
            {
                string displayedModelName = localOfficeAgreementDevicesPage.DeviceModelName(rowIndex);
                foreach (var product in _contextData.PrintersProperties)
                {
                    if (displayedModelName.Equals(product.Model) && product.SendInstallationRequest.ToLower().Equals("yes"))
                    {
                        // Click Send Installation Request button in Actions dropdown
                        localOfficeAgreementDevicesPage.ClickSendInstallationRequestInActions(rowIndex);
                        
                        // Handle Send Installation Request modal
                        localOfficeAgreementDevicesPage.SendInstallationRequest();
                        break;
                    }
                }

                if (rowIndex != (deviceRowCount - 1))
                {
                    // Note: This refresh is done due to the introduction of stale elements in Send Installation Request modal after every successful send
                    // Note: Don't refresh if its the last device in the table
                    webDriver.Navigate().Refresh();
                    localOfficeAgreementDevicesPage = PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
                }
            }

            return localOfficeAgreementDevicesPage;
        }

        public void EnableInstallationOption(
            LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, string installationType, string communicationMethod)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage, installationType,communicationMethod);

            // Click Customise button element
            ClickSafety(localOfficeAgreementDevicesPage.CustomiseButtonElement, localOfficeAgreementDevicesPage);

            // Enable installation option
            localOfficeAgreementDevicesPage.EnableInstallationOption(communicationMethod, installationType);

            // Click Save Button
            ClickSafety(localOfficeAgreementDevicesPage.InstallationOptionSaveButtonElement, localOfficeAgreementDevicesPage);
        }

        public LocalOfficeAgreementDevicesPage VerifyUpdatedPrintCounts(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage, webDriver);
            // Refreshes the print counts on MPS portal (after synchronizing BOC values)
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId);

            // Refresh page until print counts are updated
            int retries = 0;
            while (!localOfficeAgreementDevicesPage.IsPrintCountsUpdated())
            {
                // Try print counts synchronization again
                _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId);
                
                webDriver.Navigate().Refresh();
                localOfficeAgreementDevicesPage = PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(
                    RuntimeSettings.DefaultPageObjectTimeout, webDriver);

                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    throw new Exception(
                        string.Format("Number of retries exceeded the default limit during verification of print counts for agreement {0}", _contextData.AgreementId));
                }
            }

            // Verify print count values for all devices one by one
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                localOfficeAgreementDevicesPage.VerifyPrintCountsOfDevice(
                    device.MpsDeviceId, device.ColorPrintCount, device.MonoPrintCount, device.TotalPrintCount);
            }

            // Sets the agreement status to "Running"
            _runCommandService.RunStartContractCommand();

            return localOfficeAgreementDevicesPage;
        }

        public LocalOfficeAgreementDevicesPage VerifyGenerationOfConsumableOrders(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage, webDriver);
            // Run Jobs for synchronizing log data, raising consumable order & registering order in SAP
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId);
            _runCommandService.RunConsumableOrderRequestsCommand();
            _runCommandService.RunCreateConsumableOrderCommand();

            // Try refreshing until consumable order information is updated on UI
            int retries = 0;
            string resourceConsumableOrderStatusInProgress = _translationService.GetConsumableOrderStatusText(TranslationKeys.ConsumableOrderStatus.InProgress, _contextData.Culture);

            ClickSafety(
                localOfficeAgreementDevicesPage.ConsumablesTabElement(_contextData.AgreementId), localOfficeAgreementDevicesPage);

            var localOfficeAgreementConsumablesPage = PageService.GetPageObject<LocalOfficeAgreementConsumablesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

            while(localOfficeAgreementConsumablesPage.IsNoConsumablesFound())
            {
                _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId);
                _runCommandService.RunConsumableOrderRequestsCommand();
                _runCommandService.RunCreateConsumableOrderCommand();

                // Refresh page
                webDriver.Navigate().Refresh();
                localOfficeAgreementConsumablesPage = PageService.GetPageObject<LocalOfficeAgreementConsumablesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    throw new Exception(
                        string.Format("Number of retries exceeded the default limit during verification of consumable order generation for agreement {0}", _contextData.AgreementId));
                }
            }

            ClickSafety(localOfficeAgreementConsumablesPage.BackButtonElement, localOfficeAgreementConsumablesPage);
            localOfficeAgreementDevicesPage = PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

            // Verify consumable order information one by one
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                if(device.hasEmptyInkToner)
                {
                    localOfficeAgreementDevicesPage.ClickShowConsumableOrders(device.MpsDeviceId);
                    var localOfficeAgreementDeviceConsumablesPage = PageService.GetPageObject<LocalOfficeAgreementDeviceConsumablesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

                    localOfficeAgreementDeviceConsumablesPage.VerifyConsumableOrderInformation(device.SerialNumber, resourceConsumableOrderStatusInProgress);

                    ClickSafety(localOfficeAgreementDeviceConsumablesPage.BackButtonElement, localOfficeAgreementDeviceConsumablesPage);
                    localOfficeAgreementDevicesPage = PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
                }
            }

            return localOfficeAgreementDevicesPage;
        }

        public LocalOfficeAgreementBillingPage VerifyClickRateInvoice(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage, webDriver);
            ClickSafety(localOfficeAgreementDevicesPage.BillingTabElement(_contextData.AgreementId), localOfficeAgreementDevicesPage);
            var localOfficeAgreementBillingPage = PageService.GetPageObject<LocalOfficeAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

            int rowIndex = 0;
            int retries = 0;


            // Refresh the billing page if the click rate total for first billing period is not already populated
            while (!localOfficeAgreementBillingPage.IsClickRateTotalPopulated(rowIndex))
            {
                webDriver.Navigate().Refresh();
                localOfficeAgreementBillingPage = PageService.GetPageObject<LocalOfficeAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    throw new Exception(
                        string.Format("Number of retries exceeded the default limit during verification of billing (invoice not generated) for agreement {0}", _contextData.AgreementId));
                }
            }

            retries = 0;

            // Verify Click rate invoice
            while(true) // As don't know how many invoices will be generated (it depends on the time the agreement is shifted backwards)
            {
                if (localOfficeAgreementBillingPage.IsClickRateTotalPopulated(rowIndex))
                {
                    // 1. Download click rate invoice excel
                    string excelFilePath = _clickBillExcelHelper.Download(() =>
                        {
                            localOfficeAgreementBillingPage.ClickDownloadClickRateBill(rowIndex);
                            return true;
                        });

                    // Get expected values
                    string startDate = localOfficeAgreementBillingPage.GetBillingStartDate(rowIndex);
                    string endDate = localOfficeAgreementBillingPage.GetBillingEndDate(rowIndex);
                    string expectedClickRateTotal = localOfficeAgreementBillingPage.GetBillingClickRateTotal(rowIndex);
                    bool isFirstBillingPeriod = false;

                    if (rowIndex == 0)
                    {
                        isFirstBillingPeriod = true;
                    }

                    // 2. Verify click rate invoice excel
                    _clickBillExcelHelper.VerifySummaryWorksheet(excelFilePath, startDate, endDate, RemoveCurrencySymbol(expectedClickRateTotal));
                    _clickBillExcelHelper.VerifyClickChargesWorksheet(excelFilePath, startDate, endDate, isFirstBillingPeriod);

                    // 3. Delete excel file
                    _clickBillExcelHelper.DeleteExcelFile(excelFilePath);

                    // Refresh page to load any unloaded invoices onto billing page
                    webDriver.Navigate().Refresh();
                    localOfficeAgreementBillingPage = PageService.GetPageObject<LocalOfficeAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

                    rowIndex++;
                    retries = 0; // Reset retries count
                }
                else
                {
                    // Refresh page to load any unloaded invoices onto billing page
                    webDriver.Navigate().Refresh();
                    localOfficeAgreementBillingPage = PageService.GetPageObject<LocalOfficeAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
                    retries++;
                    if (retries >= 2)
                    {
                        break;
                    }
                }
            }

            return localOfficeAgreementBillingPage;
        }

        public void ClickSafety(IWebElement element, IPageObject pageObject, bool isUntilUrlChanges = false)
        {
            LoggingService.WriteLogOnMethodEntry(element, pageObject, isUntilUrlChanges);
            pageObject.SeleniumHelper.ClickSafety(element, IsUntilUrlChanges: isUntilUrlChanges);
        }
    }
}