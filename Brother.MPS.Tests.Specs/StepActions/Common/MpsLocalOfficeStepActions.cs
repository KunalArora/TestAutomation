﻿using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
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
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Common
{
    public class MpsLocalOfficeStepActions: StepActionBase
    {
        private readonly IContextData _contextData;
        private readonly ITranslationService _translationService;
        private readonly IRunCommandService _runCommandService;
        private readonly IDevicesExcelHelper _devicesExcelHelper;
        private readonly IClickBillExcelHelper _clickBillExcelHelper;
        private readonly IServiceInstallationBillExcelHelper _serviceInstallationBillExcelHelper;
        private readonly IUserResolver _userResolver;
        private readonly ICalculationService _calculationService;

        public MpsLocalOfficeStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ILoggingService loggingService,
            IRuntimeSettings runtimeSettings,
            ITranslationService translationService,
            IRunCommandService runCommandService,
            IDevicesExcelHelper devicesExcelHelper,
            IClickBillExcelHelper clickBillExcelHelper,
            IServiceInstallationBillExcelHelper serviceInstallationBillExcelHelper,
            IUserResolver userResolver,
            ICalculationService calculationService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _contextData = contextData;
            _translationService = translationService;
            _runCommandService = runCommandService;
            _devicesExcelHelper = devicesExcelHelper;
            _clickBillExcelHelper = clickBillExcelHelper;
            _serviceInstallationBillExcelHelper = serviceInstallationBillExcelHelper;
            _userResolver = userResolver;
            _calculationService = calculationService;
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

            ClickSafety(localOfficeAgreementSummaryPage.DevicesTabElement(_contextData.AgreementId), localOfficeAgreementSummaryPage, IsUntilUrlChanges: true);
            return PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
        }

        public LocalOfficeAgreementSummaryPage RefinePreInstallAgreementAndNavigateToSummaryPage(DataQueryPage dataQueryPage, IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage, webDriver);

            dataQueryPage.FilterPreInstallStatusAgreements();

            dataQueryPage.FilterAndClickAgreement(_contextData.AgreementId);
            var localOfficeAgreementSummaryPage = PageService.GetPageObject<LocalOfficeAgreementSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

            // Save dealer details for future validation
            _contextData.DealerName = localOfficeAgreementSummaryPage.DealershipNameElement.Text;
            _contextData.DealerSAPAccountNumber = localOfficeAgreementSummaryPage.DealershipSapNumberElement.Text;

            return localOfficeAgreementSummaryPage;
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
                    localOfficeAgreementDevicesPage.SendInstallationRequest(_userResolver.InstallerUsername);
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
                        localOfficeAgreementDevicesPage.SendInstallationRequest(_userResolver.InstallerUsername);
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
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId, _contextData.Country.CountryIso);

            // Refresh page until print counts are updated
            int retries = 0;
            while (!localOfficeAgreementDevicesPage.IsPrintCountsUpdated())
            {
                // Try print counts synchronization again
                _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId, _contextData.Country.CountryIso);
                
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
            _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId, _contextData.Country.CountryIso);
            _runCommandService.RunConsumableOrderRequestsCommand();
            _runCommandService.RunCreateConsumableOrderCommand();

            // Try refreshing until consumable order information is updated on UI
            int retries = 0;
            string resourceConsumableOrderStatusInProgress = _translationService.GetConsumableOrderStatusText(TranslationKeys.ConsumableOrderStatus.InProgress, _contextData.Culture);
            string resourceConsumableOrderMethodAutomatic = _translationService.GetConsumableOrderMethodText(TranslationKeys.ConsumableOrderMethod.Automatic, _contextData.Culture);

            ClickSafety(
                localOfficeAgreementDevicesPage.ConsumablesTabElement(_contextData.AgreementId), localOfficeAgreementDevicesPage);

            var localOfficeAgreementConsumablesPage = PageService.GetPageObject<LocalOfficeAgreementConsumablesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

            while(localOfficeAgreementConsumablesPage.IsNoConsumablesFound())
            {
                _runCommandService.RunMeterReadCloudSyncCommand(_contextData.AgreementId, _contextData.Country.CountryIso);
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

            ClickSafety(localOfficeAgreementConsumablesPage.BackButtonElement, localOfficeAgreementConsumablesPage, true);
            localOfficeAgreementDevicesPage = PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

            // Verify consumable order information one by one
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                if(device.hasEmptyInkToner)
                {
                    localOfficeAgreementDevicesPage.ClickShowConsumableOrders(device.MpsDeviceId);
                    var localOfficeAgreementDeviceConsumablesPage = PageService.GetPageObject<LocalOfficeAgreementDeviceConsumablesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

                    localOfficeAgreementDeviceConsumablesPage.VerifyConsumableOrderInformation(device.SerialNumber, resourceConsumableOrderStatusInProgress, resourceConsumableOrderMethodAutomatic);

                    ClickSafety(localOfficeAgreementDeviceConsumablesPage.BackButtonElement, localOfficeAgreementDeviceConsumablesPage, true);
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
                    TestCheck.AssertFailTest(
                        "Number of retries exceeded the default limit during verification of click rate billing (invoice not generated) for agreement {0}" + _contextData.AgreementId);
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
                    _clickBillExcelHelper.VerifySummaryWorksheet(excelFilePath, startDate, endDate, _calculationService.ConvertCultureNumericStringToInvariantNumericString(expectedClickRateTotal));
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

        public LocalOfficeAgreementBillingPage VerifyServiceInstallationInvoice(LocalOfficeAgreementBillingPage localOfficeAgreementBillingPage, IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementBillingPage);

            // Verify that no invoice is generated if installation packs/service packs (for all devices) are not selected

            bool shouldGenerateInvoice = false;
            foreach (var product in _contextData.PrintersProperties)
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
                        false, localOfficeAgreementBillingPage.IsServiceInstallationTotalPopulated(0), string.Format("Service/Installation invoice is generated even when no service pack/installation pack was selected for any device for agreement {0}", _contextData.AgreementId));

                    webDriver.Navigate().Refresh();
                    localOfficeAgreementBillingPage = PageService.GetPageObject<LocalOfficeAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
                    retries++;
                }
            }
            else
            {
                // Verify the invoice details

                // Refresh the billing page if the service/installation total for first billing period is not already populated
                while (!localOfficeAgreementBillingPage.IsServiceInstallationTotalPopulated(0))
                {
                    webDriver.Navigate().Refresh();
                    localOfficeAgreementBillingPage = PageService.GetPageObject<LocalOfficeAgreementBillingPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
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
                        localOfficeAgreementBillingPage.ClickDownloadServiceInstallationBill(rowIndex);
                        return true;
                    }
                    );

                // Get expected values
                string startDate = localOfficeAgreementBillingPage.GetBillingStartDate(rowIndex);
                string endDate = localOfficeAgreementBillingPage.GetBillingEndDate(rowIndex);
                string expectedServiceInstallationTotal = localOfficeAgreementBillingPage.GetServiceInstallationTotal(rowIndex);

                // 2. Verify service installation invoice excel
                _serviceInstallationBillExcelHelper.VerifyDetailWorksheet(excelFilePath, startDate, endDate, _calculationService.ConvertCultureNumericStringToInvariantNumericString(expectedServiceInstallationTotal));

                // 3. Delete excel file
                _serviceInstallationBillExcelHelper.DeleteExcelFile(excelFilePath);
            }

            return localOfficeAgreementBillingPage;
        }

        public LocalOfficeAgreementDevicesPage SendSwapDeviceInstallationRequest(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, string swapDeviceType, IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage, swapDeviceType, webDriver);

            string resourceInstalledPrinterBeingReplacedStatus = _translationService.GetInstalledPrinterStatusText(
                TranslationKeys.InstalledPrinterStatus.BeingReplaced, _contextData.Culture);

            // Refresh once to reflect any changes if present
            webDriver.Navigate().Refresh();
            localOfficeAgreementDevicesPage = PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(
                RuntimeSettings.DefaultPageObjectTimeout, webDriver);

            List<AdditionalDeviceProperties> newDevices = new List<AdditionalDeviceProperties>();

            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                if (device.IsSwap)
                {
                    localOfficeAgreementDevicesPage.ClickSwapDeviceInActions(device.MpsDeviceId);

                    var newModel = localOfficeAgreementDevicesPage.VerifySwapModalAndFillDetails(
                        device, swapDeviceType, _contextData.Culture, _userResolver.InstallerUsername);
                    localOfficeAgreementDevicesPage.ClickSendSwapRequestAndVerify();

                    localOfficeAgreementDevicesPage = PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(
                        RuntimeSettings.DefaultPageObjectTimeout, webDriver);

                    // Verify "Being Replaced" status for this device
                    var newDeviceId = localOfficeAgreementDevicesPage.VerifyStatusOfDevice(device, resourceInstalledPrinterBeingReplacedStatus);

                    // Save info for new device to context data
                    device.SwappedDeviceID = newDeviceId;
                    newDevices.Add(new AdditionalDeviceProperties() { Model = newModel, MpsDeviceId = newDeviceId, IsMonochrome = true, IsSwappedInDevice = true }); // Handle only monochrome (swapped in) devices for now
                }
            }

            _contextData.AdditionalDeviceProperties.AddRange(newDevices);

            return localOfficeAgreementDevicesPage;
        }

        public LocalOfficeAgreementDevicesPage VerifyStatusOfSwappedInAndSwappedOutDevices(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage, webDriver);

            // Refresh so that device statuses are updated after swap installation
            webDriver.Navigate().Refresh();
            localOfficeAgreementDevicesPage = PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);

            string resourceInstalledPrinterReplacedStatus = _translationService.GetInstalledPrinterStatusText(
                TranslationKeys.InstalledPrinterStatus.Replaced, _contextData.Culture);
            string resourceDeviceConnectionStatusSwapped = _translationService.GetDeviceConnectionStatusText(
                TranslationKeys.DeviceConnectionStatus.Swapped, _contextData.Culture);
            string resourceInstalledPrinterStatusInstalled = _translationService.GetInstalledPrinterStatusText(
                TranslationKeys.InstalledPrinterStatus.InstalledType3, _contextData.Culture);
            string resourceDeviceConnectionStatusResponding = _translationService.GetDeviceConnectionStatusText(
                TranslationKeys.DeviceConnectionStatus.Responding, _contextData.Culture);

            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                if (device.IsSwap) //Swapped out device (old device)
                {
                    localOfficeAgreementDevicesPage.VerifyStatusOfDevice(device, resourceInstalledPrinterReplacedStatus);
                    localOfficeAgreementDevicesPage.VerifyStatusOfDevice(device, resourceDeviceConnectionStatusSwapped);
                }
                else // Swapped in device (new device) plus remaining devices
                {
                    localOfficeAgreementDevicesPage.VerifyStatusOfDevice(device, resourceInstalledPrinterStatusInstalled);
                    localOfficeAgreementDevicesPage.VerifyStatusOfDevice(device, resourceDeviceConnectionStatusResponding);

                    // Verify swapped in device address string
                    if (device.IsSwappedInDevice)
                    {
                        foreach (var oldDevice in _contextData.AdditionalDeviceProperties)
                        {
                            if (device.MpsDeviceId.Equals(oldDevice.SwappedDeviceID))
                            {
                                localOfficeAgreementDevicesPage.VerifySwappedInDeviceAddressString(oldDevice, device);
                                break;
                            }
                        }
                    }
                }
            }

            return localOfficeAgreementDevicesPage;
        }

        public LocalOfficeAgreementDevicesPage SendReinstallDeviceRequest(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage,  IWebDriver webDriver)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage, webDriver);
            
            foreach(var device in _contextData.AdditionalDeviceProperties)
            {
                if(device.ReInstallDevice.ToLower().Equals("yes"))
                {
                    device.IsRegisteredOnBoc = false;

                    localOfficeAgreementDevicesPage.ClickReInstallDeviceAction(device);

                    localOfficeAgreementDevicesPage.SendReInstallationRequest(device, _userResolver.InstallerUsername); // Modal

                    localOfficeAgreementDevicesPage = PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(
                        RuntimeSettings.DefaultPageObjectTimeout, webDriver);

                    localOfficeAgreementDevicesPage.VerifyDeviceStatusAfterReInstallRequestSent(device, _contextData.Culture);

                }
            }

            // Save new installation details to context data

            // Get Downloaded file path
            string excelFilePath = _devicesExcelHelper.Download(() =>
            {
                // Click Export All button
                ClickSafety(localOfficeAgreementDevicesPage.ExportAllElement, localOfficeAgreementDevicesPage);
                return true;
            });

            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                if (device.ReInstallDevice.ToLower().Equals("yes"))
                {
                    // Save new installation details
                    _devicesExcelHelper.ExportAndSaveInstallationDetails(excelFilePath, device);
                }
            }

            // Delete Excel
            _devicesExcelHelper.DeleteExcelFile(excelFilePath);
            
            return localOfficeAgreementDevicesPage;
        }
    }
}