using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
{
    public class DealerAgreementDevicesPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".mps-dataTables-footer"; // Device data table footer
        private const string _url = "/mps/dealer/agreement/{agreementId}/devices"; // TODO: Replace agreementId with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        // Selectors
        private const string DeviceModelNameSelector = "[id*=content_1_Devices_ModelCell_]";
        private const string PreloaderSelector = ".js-mps-preloader";
        private const string SuccessAlertSelector = ".alert.alert-success.mps-alert.js-mps-alert";

        // Action button selectors
        private const string ActionsButtonSelector = "button.btn.btn-primary.btn-xs.dropdown-toggle";
        private const string EditDeviceDataButtonSelector = ".js-mps-edit-device-data";
        private const string SendInstallationRequestActionsButtonSelector = ".js-mps-send-installation-request";
        private const string ShowPrintCountsActionsButtonSelector = ".js-mps-view-print-count";
        private const string ShowConsumableOrdersActionsButtonSelector = ".js-mps-view-consumable-orders";
        private const string RaiseConsumableOrderActionsButtonSelector = ".js-mps-raise-consumable-order";
        private const string RaiseServiceRequestActionsButtonSelector = ".js-mps-raise-service-request";
        private const string ShowDeviceDetailsActionsButtonSelector = ".js-mps-view-device-location";
        private const string SwapDeviceActionsButtonSelector = ".js-mps-swap-device";
        private const string ReInstallDeviceActionsButtonSelector = ".js-mps-re-install-device";
        private const string ShowServiceRequestsActionsButtonSelector = ".js-mps-view-service-requests";

        private const string StatusToolTipSelector = ".js-mps-tooltip";
        private const string StatusIconSelector = "[id*=content_1_Devices_StatusIconCell_]";
        private const string StatusDataAttributeSelector = "data-original-title";
        private const string DeviceCheckboxSelector = ".js-mps-row-action";
        private const string InputEmailSelector = "#InputEmail";
        private const string ModalAlertSuccessSelector = ".modal-content.alert-success";

        // Show Print Counts modal selectors
        private const string PrintCountsModalTableBodySelector = ".js-mps-print-counts-list > .modal-body > .table > tbody";
        private const string PrintCountsModalCloseButtonSelector = ".js-mps-print-counts-list > .modal-header > .close";
        private const string PrintCountsModalDateTimeSelector = ".mps-print-count-date";
        private const string ColourPrintCountSelector = ".mps-print-count-colour";
        private const string MonoPrintCountSelector = ".mps-print-count-mono";
        private const string TotalPrintCountSelector = ".mps-print-count-total";

        // Show Device Details modal selectors
        private const string DeviceDetailsModalDeviceContainerSelector = ".mps-device-container > .row";

        // Tab link selectors
        private const string MpsTabsSelector = ".mps-tabs-main";
        private const string MpsTabsAgreementSelector = " a[href=\"/mps/dealer/agreement/";

        // Swap Request Modal Selectors
        private const string SwapRequestModalDeviceDetailsSelector = ".js-mps-send-swap-request-modal-body > div:nth-child(2) > div.panel-body > table > tbody > tr";
        private const string SwapTypeDataAttributeSelector = "swap-type-enum-id";
        private const string SelectModelDropdownSelector = ".js-mps-replacement-model-list";
        private const string SwapDifferentConfirmationSelector = ".js-mps-swap-different-confirmation";
        private const string SwapSameConfirmationSelector = ".js-mps-swap-same-confirmation";
        private const string SwapPcbConfirmationSelector = ".js-mps-swap-pcb-confirmation";
        private const string SendSwapRequestButtonSelector = ".js-mps-send-swap-request-modal-select";

        // ReInstall Device Modal Selectors
        private const string SendReInstallationRequestSelector = ".js-mps-send-re-installation-request-modal-select";
        private const string ReInstallDeviceModalBodySelector = ".js-mps-send-re-installation-request-modal-body";
        private const string ReInstallDeviceModalDeviceDetailsSelector = ".panel > .panel-body > .table > tbody";

        // Status Icon Selectors
        public readonly string CloudStatusIconSelector = ".glyphicon-cloud";
        public readonly string EmailStatusIconSelector = ".glyphicon-email";
        public readonly string ReInstallStatusIconSelector = ".glyphicon-ok-circle";
        public readonly string SwapBeingReplaceStatusIconSelector = ".glyphicon-transfer";
        public readonly string SwapReplacedStatusIconSelector = ".glyphicon-ban-circle";

        private const string DevicesContainerValidationSelector = ".mps-dataTables-footer";

        // Web Elements
        // Alerts
        [FindsBy(How = How.CssSelector, Using = ".alert.alert-warning.mps-alert.js-mps-alert")]
        public IWebElement WarningAlertElement;

        // Buttons
        [FindsBy(How = How.CssSelector, Using = "button.btn.btn-primary.btn-xs.dropdown-toggle")]
        public IWebElement ActionsButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-edit-device-data")]
        public IWebElement EditDeviceDataButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement DeviceContainerElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-paging-dt-select-all")]
        public IWebElement CheckboxSelectAllElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-ribbon-edit-device-data")]
        public IWebElement EditDeviceDataBulkElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-ribbon-export-all-device-data")]
        public IWebElement ExportAllElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-ribbon-import-device-data")]
        public IWebElement ImportDataElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-ribbon-export-device-data")]
        public IWebElement ExportDataElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-ribbon-send-installation-request")]
        public IWebElement SendInstallationRequestElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-send-installation-request-modal-select")]
        public IWebElement SendInstallationRequestModalElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-raise-consumable-order")]
        public IWebElement RaiseConsumableOrderActionsButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-device-location > .modal-header > .close")]
        public IWebElement DeviceDetailsModalCloseButtonElement;
        [FindsBy(How = How.CssSelector, Using = "a[href*=\"mps/dealer/reports\"]")]
        public IWebElement ReportTabElement;

        // TABs
        [FindsBy(How = How.CssSelector, Using = "a[href$='/summary']")] // ex. /mps/dealer/agreement/173259/summary
        public IWebElement SummaryTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/details']")]
        public IWebElement DetailsTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/devices']")]
        public IWebElement DevicesTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/billing']")]
        public IWebElement BillingTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/consumables']")]
        public IWebElement ConsumablesTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/service-requests']")]
        public IWebElement ServiceRequestsTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/history']")]
        public IWebElement HistoryTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/silent-devices']")]
        public IWebElement SilentDevicesTabElement;


        // Click on Edit Device Data button for this particular model
        public void ClickOnEditDeviceData(string modelName)
        {
            LoggingService.WriteLogOnMethodEntry(modelName);
            var elements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var element in elements)
            {
                var DeviceModelNameElement = SeleniumHelper.FindElementByCssSelector(element, DeviceModelNameSelector);
                if (DeviceModelNameElement.Text.Equals(modelName))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(element, ActionsButtonSelector);
                    ActionsButtonElement.Click();
                    var EditDeviceDataButtonElement = SeleniumHelper.FindElementByCssSelector(element, EditDeviceDataButtonSelector);
                    EditDeviceDataButtonElement.Click();
                    break;
                }
            }
        }

        // Click on Edit Device Data button for this particular row index
        public void ClickOnEditDeviceData(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], ActionsButtonSelector);
            SeleniumHelper.ClickSafety(ActionsButtonElement);
            var EditDeviceDataButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], EditDeviceDataButtonSelector);
            SeleniumHelper.ClickSafety(EditDeviceDataButtonElement);
        }

        public void VerifyTheStatusOfAllDevices(string expectedStatus)
        {
            LoggingService.WriteLogOnMethodEntry(expectedStatus);
            var elements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach(var element in elements)
            {
                var StatusToolTipElement = SeleniumHelper.FindElementByCssSelector(element, StatusToolTipSelector);
                string displayedStatus = StatusToolTipElement.GetAttribute(StatusDataAttributeSelector);

                TestCheck.AssertTextContains(
                    expectedStatus, displayedStatus, "Status of the device could not be verified");
            }
        }


        // Click on Checkbox for this particular device row index
        public void ClickOnDeviceCheckbox(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], DeviceCheckboxSelector);
            SeleniumHelper.ClickSafety(CheckboxElement);
        }

        // Verify address of the edited device given the row index & expected address
        public void VerifyAddressOfEditedDevice(int rowIndex, string expectedAddress)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex,expectedAddress);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);

            // TODO: Replace this with the conventional element finding method after ID/Class of the Address Element has been fixed
            string displayedAddress = deviceRowElements[rowIndex].FindElements(By.TagName("td")).ToList()[4].Text;

            TestCheck.AssertIsEqual(expectedAddress, displayedAddress, "Address of the edited device could not be verified");
        }


        // Get total number of rows of the device table
        public int DeviceTableRowsCount()
        {
            LoggingService.WriteLogOnMethodEntry();
            return SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement).Count;
        }

        // Validate address of the device given the device id & expected address string
        public void ValidateDeviceAddress(string mpsDeviceId, string expectedAddress)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId, expectedAddress);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot verify device address for a device with Device Id null");
            }

            string displayedDeviceId, displayedAddress;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    // TODO: Replace this with the conventional element finding method after ID/Class of the Address Element has been fixed
                    displayedAddress = deviceRowElement.FindElements(By.TagName("td")).ToList()[4].Text;
                    TestCheck.AssertIsEqual(expectedAddress, displayedAddress, "Address of the edited device could not be verified");
                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }

        // Get model name of the device given the row index
        public string DeviceModelName(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var deviceRowElement = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement)[rowIndex];
            return SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceModelNameSelector).Text;
        }

        public void SendInstallationRequest(string installerEmail)
        {
            LoggingService.WriteLogOnMethodEntry(installerEmail);

            // Input Email ID
            SeleniumHelper.FindElementByCssSelector(InputEmailSelector).SendKeys(installerEmail);
            
            // Click Send Installation Request button on modal
            SeleniumHelper.ClickSafety(SendInstallationRequestModalElement);

            // Verify success & close modal alert
            try
            {
                var modalSuccessElement = SeleniumHelper.FindElementByCssSelector(ModalAlertSuccessSelector);
                SeleniumHelper.ClickSafety(modalSuccessElement.FindElement(By.ClassName("close")));
            }
            catch(Exception e)
            {
                TestCheck.AssertFailTest("Error occurred while sending the installation request (error alert popped up). Error details:" + e);
            }
        }

        // Click on Send Installation Request in Actions for this particular device row index
        public void ClickSendInstallationRequestInActions(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);

            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                deviceRowElements[rowIndex], ActionsButtonSelector);
            SeleniumHelper.ClickSafety(ActionsButtonElement);

            var SendInstallationRequestButtonElement = SeleniumHelper.FindElementByCssSelector(
                deviceRowElements[rowIndex], SendInstallationRequestActionsButtonSelector);
            SeleniumHelper.ClickSafety(SendInstallationRequestButtonElement);
        }

        public void ClickCheckboxSelectAll(bool select)
        {
            LoggingService.WriteLogOnMethodEntry(select);
            SeleniumHelper.SetCheckBox(CheckboxSelectAllElement, select);
        }

        public void ClickOnBulkActionsEditDeviceData()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(EditDeviceDataBulkElement,IsUntilUrlChanges:true);
        }

        public void VerifySerialNumberOfDevice(string mpsDeviceId, string expectedSerialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId,expectedSerialNumber);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot verify serial number for a device with Device Id null");
            }

            string displayedDeviceId, displayedSerialNumber;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    // TODO: Replace this with the conventional element finding method after ID/Class of the Serial Number Element has been fixed
                    displayedSerialNumber = deviceRowElement.FindElements(By.TagName("td")).ToList()[2].Text;
                    TestCheck.AssertIsEqual(expectedSerialNumber, displayedSerialNumber, "Serial number of the installed device could not be verified");
                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }

        // Returns true if print count values have been updated in the UI for all devices, otherwise, returns false
        public bool IsPrintCountsUpdated()
        {
            LoggingService.WriteLogOnMethodEntry();

            bool isUpdated = false;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);

            foreach(var deviceRowElement in deviceRowElements)
            {
                var PrintCountsRowElement = ClickShowPrintCounts(deviceRowElement);
                var displayedTotalPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElement, TotalPrintCountSelector);

                if (!displayedTotalPrintCount.Text.Equals("-"))
                {
                    isUpdated = true;
                }
                else
                {
                    isUpdated = false;
                    // Close Modal
                    SeleniumHelper.ClickSafety(
                        SeleniumHelper.FindElementByCssSelector(
                        PrintCountsModalCloseButtonSelector));
                    break;
                }

                // Close Modal
                SeleniumHelper.ClickSafety(
                    SeleniumHelper.FindElementByCssSelector(
                    PrintCountsModalCloseButtonSelector));
            }

            return isUpdated;
        }

        // Verify the Total print count, Mono print count and Colour print count of the device given the mpsDeviceId
        public void VerifyPrintCountsOfDevice(
            string mpsDeviceId, int colourPrintCount, int monoPrintCount, int totalPrintCount)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId, colourPrintCount, monoPrintCount, totalPrintCount);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot verify print counts for a device with Device Id null");
            }

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    var PrintCountsRowElement = ClickShowPrintCounts(deviceRowElement);
                    var displayedDateTime = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElement, PrintCountsModalDateTimeSelector);
                    var displayedTotalPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElement, TotalPrintCountSelector);
                    var displayedColourPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElement, ColourPrintCountSelector);
                    var displayedMonoPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElement, MonoPrintCountSelector);

                    // Verify that date time is valid
                    TestCheck.AssertIsNotEqual("-", displayedDateTime.Text, string.Format("Date Timestamp for print counts could not be verified for the device with device id = {0}", mpsDeviceId));

                    // Verify print count values
                    TestCheck.AssertIsEqual(
                        totalPrintCount.ToString(), displayedTotalPrintCount.Text, string.Format("Total Print Count could not be verified for the device with device id = {0}", mpsDeviceId));

                    TestCheck.AssertIsEqual(
                        monoPrintCount.ToString(), displayedMonoPrintCount.Text, string.Format("Mono Print Count could not be verified for the device with device id = {0}", mpsDeviceId));

                    if (displayedColourPrintCount.Text != "-")
                    {
                        TestCheck.AssertIsEqual(
                        colourPrintCount.ToString(), displayedColourPrintCount.Text, string.Format("Colour Print Count could not be verified for the device with device id = {0}", mpsDeviceId));
                    }

                    // Close Modal
                    SeleniumHelper.ClickSafety(
                        SeleniumHelper.FindElementByCssSelector(
                        PrintCountsModalCloseButtonSelector));

                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }

        // Click Show Consumable Orders in Actions given the MPS device Id
        public void ClickShowConsumableOrders(string mpsDeviceId)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot click Show Consumable Orders for a device with Device Id null");
            }

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector);
                    SeleniumHelper.ClickSafety(ActionsButtonElement);

                    var ShowConsumableOrdersElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ShowConsumableOrdersActionsButtonSelector);
                    ScrollTo(ShowConsumableOrdersElement);
                    SeleniumHelper.ClickSafety(ShowConsumableOrdersElement);

                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }

        // Click Raise Consumable Orders in Actions given the MPS device Id
        public void ClickRaiseConsumableOrder(string mpsDeviceId)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot click Raise Consumable Order for a device with Device Id null");
            }

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector);
                    SeleniumHelper.ClickSafety(ActionsButtonElement);

                    var RaiseConsumableOrderElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, RaiseConsumableOrderActionsButtonSelector);
                    ScrollTo(RaiseConsumableOrderElement);
                    SeleniumHelper.ClickSafety(RaiseConsumableOrderElement);

                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }

        public bool IsManualRaiseConsumableOptionEnabled()
        {
            LoggingService.WriteLogOnMethodEntry();
            bool enabled = false;

            var deviceFirstRowElement = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement)[0];

            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceFirstRowElement, ActionsButtonSelector);
            SeleniumHelper.ClickSafety(ActionsButtonElement);

            if(SeleniumHelper.IsElementDisplayed(RaiseConsumableOrderActionsButtonElement))
            {
                enabled = true;
            }

            return enabled;
        }

        public void ClickRaiseServiceRequest(string mpsDeviceId)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot click Raise Service Request for a device with Device Id null");
            }

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector);
                    SeleniumHelper.ClickSafety(ActionsButtonElement);

                    var RaiseServiceRequestElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, RaiseServiceRequestActionsButtonSelector);
                    ScrollTo(RaiseServiceRequestElement);
                    SeleniumHelper.ClickSafety(RaiseServiceRequestElement);
                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }

        public void ClickShowDeviceDetails(string mpsDeviceId)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot click Show Device Details for a device with Device Id null");
            }

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);

            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector);
                    SeleniumHelper.ClickSafety(ActionsButtonElement);

                    var ShowDeviceDetailsElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ShowDeviceDetailsActionsButtonSelector);
                    ScrollTo(ShowDeviceDetailsElement);
                    SeleniumHelper.ClickSafety(ShowDeviceDetailsElement);
                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }

        public void VerifyDeviceDetails(AdditionalDeviceProperties device, string agreementType, string agreementLength, string usageType)
        {
            LoggingService.WriteLogOnMethodEntry(device,agreementType,agreementLength,usageType);
            var DeviceDetailsContainerElement = SeleniumHelper.FindElementByCssSelector(
                DeviceDetailsModalDeviceContainerSelector);

            // TODO: Replace this method after Id/class of the elements is fixed
            var detailColumnElements = SeleniumHelper.FindElementsByCssSelector(DeviceDetailsContainerElement, ".col-sm-4");

            var CustomerSite = detailColumnElements[0].Text;
            var DeviceLocation = detailColumnElements[1].Text;
            var AdditionalData = detailColumnElements[2].Text;

            string agreementLengthInMonths = string.Format(Int32.Parse(agreementLength[0].ToString())*12 + " Months");

            TestCheck.AssertTextContains(
                    device.CustomerName, CustomerSite, string.Format("Customer Name = {0} of the device could not be verified", device.CustomerName));
            TestCheck.AssertTextContains(
                    device.AddressNumber, CustomerSite, string.Format("Address Number = {0} of the device could not be verified", device.AddressNumber));
            TestCheck.AssertTextContains(
                    device.AddressStreet, CustomerSite, string.Format("Address Street = {0} of the device could not be verified", device.AddressStreet));
            TestCheck.AssertTextContains(
                    device.AddressTown, CustomerSite, string.Format("Address Town = {0} of the device could not be verified", device.AddressTown));
            TestCheck.AssertTextContains(
                    device.AddressPostCode, CustomerSite, string.Format("Address Post Code = {0} of the device could not be verified", device.AddressPostCode));

            TestCheck.AssertTextContains(
                    device.DeviceLocation, DeviceLocation, string.Format("Device Location = {0} of the device could not be verified", device.DeviceLocation));

            TestCheck.AssertTextContains(
                    device.AgreementId, AdditionalData, string.Format("Agreement ID = {0} of the device could not be verified", device.AgreementId));
            TestCheck.AssertTextContains(
                    agreementType, AdditionalData, string.Format("Agreement Type = {0} of the device could not be verified", agreementType));
            TestCheck.AssertTextContains(
                    agreementLengthInMonths, AdditionalData, string.Format("Agreement Length = {0} of the device could not be verified", agreementLengthInMonths));
            TestCheck.AssertTextContains(
                    usageType, AdditionalData, string.Format("Usage Type = {0} of the device could not be verified", usageType));
            TestCheck.AssertTextContains(
                    device.CostCentre, AdditionalData, string.Format("CostCentre = {0} of the device could not be verified", device.CostCentre));

            SeleniumHelper.ClickSafety(DeviceDetailsModalCloseButtonElement);
        }

        public void ClickSwapDeviceInActions(string mpsDeviceId)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot click Swap Device actions for a device with Device Id null");
            }

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector);
                    SeleniumHelper.ClickSafety(ActionsButtonElement);

                    var SwapDeviceElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, SwapDeviceActionsButtonSelector);
                    ScrollTo(SwapDeviceElement);
                    SeleniumHelper.ClickSafety(SwapDeviceElement);

                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }

        public string VerifySwapModalAndFillDetails(AdditionalDeviceProperties device, string swapDeviceType, string culture, string installerEmail)
        {
            LoggingService.WriteLogOnMethodEntry(device, swapDeviceType, culture, installerEmail);

            ExpectedTranslationService translationService = new ExpectedTranslationService();

            string resourceSwapDeviceType = translationService.GetSwapTypeText(swapDeviceType, culture);

            if (!SeleniumHelper.IsElementNotPresent(PreloaderSelector))
            {
                SeleniumHelper.WaitUntil(d => !SeleniumHelper.FindElementByCssSelector(PreloaderSelector).Displayed);
            }

            SeleniumHelper.FindElementByCssSelector(SwapRequestModalDeviceDetailsSelector);
            var DeviceDetails = SeleniumHelper.FindElementsByCssSelector(SwapRequestModalDeviceDetailsSelector)[0];

            string addressString = null;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(device.MpsDeviceId))
                {
                    // TODO: Replace this with the conventional element finding method after ID/Class of the Address Element has been fixed
                    addressString = deviceRowElement.FindElements(By.TagName("td")).ToList()[4].Text;
                    break;
                }
            }

            // Verify Device Details

            TestCheck.AssertTextContains(
                    device.Model, DeviceDetails.Text, string.Format(
                    "Device Model of the device could not be verified on Swap Request Modal for device with device ID: {0}", device.MpsDeviceId));
            TestCheck.AssertTextContains(
                    device.SerialNumber, DeviceDetails.Text, string.Format(
                    "Serial Number of the device could not be verified on Swap Request Modal for device with device ID: {0}", device.MpsDeviceId));
            TestCheck.AssertTextContains(
                    addressString, DeviceDetails.Text, string.Format(
                    "Location of the device could not be verified on Swap Request Modal for device with device ID: {0}", device.MpsDeviceId));


            var swapTypeElement = SeleniumHelper.FindElementByDataAttributeValue(SwapTypeDataAttributeSelector, resourceSwapDeviceType);
            SeleniumHelper.ClickSafety(swapTypeElement);

            string newModel = null;

            if (resourceSwapDeviceType.Equals(translationService.GetSwapTypeText(TranslationKeys.SwapType.ReplaceWithDifferentModel, culture)))
            {
                var SelectDifferentModelDropdownElement = SeleniumHelper.FindElementByCssSelector(SelectModelDropdownSelector);
                var selectedModel = SelectFromDropDownByIndexAndReturnValue(SelectDifferentModelDropdownElement, 2); // Choose the 2nd model on the dropdown list as replacement model
                newModel = selectedModel;
                var ConfirmationText = SeleniumHelper.FindElementByCssSelector(SwapDifferentConfirmationSelector).Text;
                TestCheck.AssertTextContains(selectedModel, ConfirmationText, string.Format(
                    "Confirmation Text of the the device (Replace with Different Model) could not be verified on Swap Request Modal for device with device ID: {0}", device.MpsDeviceId));

            }
            else if (resourceSwapDeviceType.Equals(translationService.GetSwapTypeText(TranslationKeys.SwapType.ReplaceWithSameModel, culture)))
            {
                newModel = device.Model;
                var ConfirmationText = SeleniumHelper.FindElementByCssSelector(SwapSameConfirmationSelector).Text;
                TestCheck.AssertTextContains(device.Model, ConfirmationText, string.Format(
                    "Confirmation Text of the the device (Replace with Same Model) could not be verified on Swap Request Modal for device with device ID: {0}", device.MpsDeviceId));
            }
            else if (resourceSwapDeviceType.Equals(translationService.GetSwapTypeText(TranslationKeys.SwapType.ReplaceThePcb, culture)))
            {
                newModel = device.Model;
                var ConfirmationText = SeleniumHelper.FindElementByCssSelector(SwapPcbConfirmationSelector).Text;
                TestCheck.AssertTextContains("PCB", ConfirmationText, string.Format(
                    "Confirmation Text of the the device (Replace PCB) could not be verified on Swap Request Modal for device with device ID: {0}", device.MpsDeviceId));
            }

            // Input Email ID
            SeleniumHelper.FindElementByCssSelector(InputEmailSelector).SendKeys(installerEmail);

            return newModel;
        }

        public void ClickSendSwapRequestAndVerify()
        {
            LoggingService.WriteLogOnMethodEntry();

            var sendSwapButton = SeleniumHelper.FindElementByCssSelector(SendSwapRequestButtonSelector);
            SeleniumHelper.WaitUntil(d => sendSwapButton.Enabled);
            SeleniumHelper.ClickSafety(sendSwapButton);
            SeleniumHelper.WaitUntil(d => ExpectedConditions.StalenessOf(sendSwapButton));
            VerifySwapRequestHasBeenSentSuccessfully(isCloseWhenSuccess: true);
        }

        // Verify the status of the device & return the device ID
        public string VerifyStatusOfDevice(AdditionalDeviceProperties device, string expectedInstalledPrinterStatus, string expectedBalloonType=null, string expectedballoonStatus=null)
        {
            LoggingService.WriteLogOnMethodEntry(device, expectedInstalledPrinterStatus);
            if (device.SerialNumber == null)
            {
                throw new Exception("Cannot verify device address for a device with Serial Number null");
            }

            // Wait for Devices container content to be loaded
            SeleniumHelper.FindElementByCssSelector(DevicesContainerValidationSelector);

            // Note: Check by serial number as deviceId changes for the device being replaced
            string displayedSerialNumber;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                // TODO: Replace this with the conventional element finding method after ID/Class of the Serial Number Element has been fixed
                displayedSerialNumber = deviceRowElement.FindElements(By.TagName("td")).ToList()[2].Text;
                if (displayedSerialNumber.Equals(device.SerialNumber))
                {
                    var StatusToolTipElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, StatusToolTipSelector);
                    string displayedStatus = StatusToolTipElement.GetAttribute(StatusDataAttributeSelector);

                    TestCheck.AssertTextContains(
                        expectedInstalledPrinterStatus, displayedStatus, "Status could not be verified for the device with serial number: " + device.SerialNumber);
                    if(expectedBalloonType != null)
                    {
                        TestCheck.AssertTextContains(
                            expectedBalloonType, displayedStatus, "Balloon 'Type' could not be verified for the device with serial number: " + device.SerialNumber);
                    }
                    if(expectedballoonStatus != null)
                    {
                        TestCheck.AssertTextContains(
                            expectedballoonStatus, displayedStatus, "Balloon 'Status' could not be verified for the device with serial number: " + device.SerialNumber);
                    }

                    var ModelElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceModelNameSelector);
                    var filterString = ModelElement.GetAttribute("data-filter");
                    // example:
                    // 161306 (swapped-by: 161310) DCP-8110DN Status: Responding =>161310
                    // 161306,,swapped-by:,161310,,DCP-8110DN,Status:,Responding,
                    // 161306 DCP-8110DN Status: Responding =>161306
                    // 161306,DCP-8110DN,Status:,Responding
                    var filterStringArr = filterString.Split(new char[] { ' ', '(', ')' });
                    var deviceId = filterString.Contains("swapped-by:") ? filterStringArr[3] : filterStringArr[0];
                    return deviceId;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with serial number = {0}", device.SerialNumber));
            return null;
        }

        public void SaveAddressString(AdditionalDeviceProperties device)
        {
            LoggingService.WriteLogOnMethodEntry(device);
            string displayedDeviceId, displayedAddress;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(device.MpsDeviceId))
                {
                    // TODO: Replace this with the conventional element finding method after ID/Class of the Address Element has been fixed
                    displayedAddress = deviceRowElement.FindElements(By.TagName("td")).ToList()[4].Text;

                    // Save
                    device.AddressString = displayedAddress;
                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", device.MpsDeviceId));
        }

        public void VerifySwappedInDeviceAddressString(AdditionalDeviceProperties swappedOutDevice, AdditionalDeviceProperties swappedInDevice)
        {
            LoggingService.WriteLogOnMethodEntry(swappedOutDevice, swappedInDevice);
            string swappedInDeviceDisplayedSerialNumber, swappedInDeviceAddress;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);

            foreach (var deviceRowElement in deviceRowElements)
            {
                // TODO: Replace this with the conventional element finding method after ID/Class of the Serial Number Element has been fixed
                swappedInDeviceDisplayedSerialNumber = deviceRowElement.FindElements(By.TagName("td")).ToList()[2].Text;
                if (swappedInDeviceDisplayedSerialNumber.Equals(swappedInDevice.SerialNumber))
                {
                    // TODO: Replace this with the conventional element finding method after ID/Class of the Address Element has been fixed
                    swappedInDeviceAddress = deviceRowElement.FindElements(By.TagName("td")).ToList()[4].Text;

                    // Verify
                    TestCheck.AssertIsEqual(swappedOutDevice.AddressString, swappedInDeviceAddress, "Address of the Swapped In device did not match that of the Swapped Out device");
                    swappedInDevice.AddressString = swappedInDeviceAddress;
                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", swappedInDevice.MpsDeviceId));
        }

        public void ClickReInstallDeviceAction(AdditionalDeviceProperties device)
        {
            LoggingService.WriteLogOnMethodEntry(device);
            if (device.MpsDeviceId == null)
            {
                throw new Exception("Cannot click ReInstall Device action for a device with Device Id null");
            }

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(device.MpsDeviceId))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector);
                    SeleniumHelper.ClickSafety(ActionsButtonElement);

                    var ReInstallDeviceElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ReInstallDeviceActionsButtonSelector);
                    ScrollTo(ReInstallDeviceElement);
                    SeleniumHelper.ClickSafety(ReInstallDeviceElement);

                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", device.MpsDeviceId));
        }

        public void SendReInstallationRequest(AdditionalDeviceProperties device, string installerEmail)
        {
            LoggingService.WriteLogOnMethodEntry(device, installerEmail);

            var ModalBodyElement = SeleniumHelper.FindElementByCssSelector(ReInstallDeviceModalBodySelector);
            var DeviceDetails = SeleniumHelper.FindElementByCssSelector(ModalBodyElement, ReInstallDeviceModalDeviceDetailsSelector).Text;

            // Verify device details
            TestCheck.AssertTextContains(
                    device.Model, DeviceDetails, string.Format("Device Model name = {0} of the device could not be verified on ReInstall device Modal", device.Model));

            TestCheck.AssertTextContains(
                    device.SerialNumber, DeviceDetails, string.Format("Device Serial Number = {0} of the device could not be verified on ReInstall device Modal", device.SerialNumber));

            TestCheck.AssertTextContains(
                    device.AddressString, DeviceDetails, string.Format("Device Location = {0} of the device could not be verified on ReInstall device Modal", device.AddressString));

            // Input Email ID
            SeleniumHelper.FindElementByCssSelector(ModalBodyElement, InputEmailSelector).SendKeys(installerEmail);

            // Click Send Installation Request button on modal
            SeleniumHelper.ClickSafety(SeleniumHelper.FindElementByCssSelector(SendReInstallationRequestSelector));

            // Verify success & close success alert
            try
            {
                var alertSuccessElement = SeleniumHelper.FindElementByCssSelector(SuccessAlertSelector);
                SeleniumHelper.ClickSafety(alertSuccessElement.FindElement(By.ClassName("close")));
            }
            catch (Exception e)
            {
                TestCheck.AssertFailTest("Error occurred while sending the Re-Installation request (error alert popped up). Error details:" + e);
            }
        }


        public void VerifyDeviceStatusAfterReInstallRequestSent(AdditionalDeviceProperties device, string culture)
        {
            LoggingService.WriteLogOnMethodEntry(device);

            ExpectedTranslationService _translationService = new ExpectedTranslationService();

            if (device.MpsDeviceId == null)
            {
                throw new Exception("Cannot verify device status for a device with Device Id null after Reinstall request has been raised");
            }

            string displayedDeviceId, displayedSerialNumber;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(device.MpsDeviceId))
                {
                    // Verify that serial number is cleared
                    // TODO: Replace this with the conventional element finding method after ID/Class of the Serial Number Element has been fixed
                    displayedSerialNumber = deviceRowElement.FindElements(By.TagName("td")).ToList()[2].Text;
                    TestCheck.AssertIsEqual("-", displayedSerialNumber, "Serial Number of the ready for re-installation device could not be verified");

                    var StatusToolTipElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, StatusToolTipSelector);
                    string displayedStatus = StatusToolTipElement.GetAttribute(StatusDataAttributeSelector);

                    VerifyStatusIcon(deviceRowElement, ReInstallStatusIconSelector);

                    TestCheck.AssertTextContains(
                        _translationService.GetInstalledPrinterStatusText(TranslationKeys.InstalledPrinterStatus.ReadyForReInstallType3, culture), displayedStatus, "Status of the device could not be verified");

                    TestCheck.AssertTextContains(
                        _translationService.GetDeviceConnectionStatusText(TranslationKeys.DeviceConnectionStatus.NotConnected, culture).ToLower(), displayedStatus.ToLower().Replace(" ", string.Empty), "Status of the device could not be verified");

                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", device.MpsDeviceId));
        }

        public void VerifyStatusIconOfAllDevices(string iconSelector)
        {
            LoggingService.WriteLogOnMethodEntry(iconSelector);

            var elements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var element in elements)
            {
                VerifyStatusIcon(element, iconSelector);
            }
        }

        public void VerifyStatusIconUsingDeviceId(string mpsDeviceId, string expectedIconSelector)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId, expectedIconSelector);

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    VerifyStatusIcon(deviceRowElement, expectedIconSelector);
                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }


        public void VerifyStatusIconUsingSerialNumber(string serialNumber, string expectedIconSelector)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber, expectedIconSelector);

            string displayedSerialNumber;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                // TODO: Replace this with the conventional element finding method after ID/Class of the Serial Number Element has been fixed
                displayedSerialNumber = deviceRowElement.FindElements(By.TagName("td")).ToList()[2].Text;
                if (displayedSerialNumber.Equals(serialNumber))
                {
                    VerifyStatusIcon(deviceRowElement, expectedIconSelector);
                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with serial number = {0}", serialNumber));
        }

        // Click Show Print Counts in Actions and return the print counts table row element which contains the print count values
        private IWebElement ClickShowPrintCounts(IWebElement deviceRowElement)
        {
            LoggingService.WriteLogOnMethodEntry(deviceRowElement);
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector);
            SeleniumHelper.ClickSafety(ActionsButtonElement);

            var ShowPrintCountsElement = SeleniumHelper.FindElementByCssSelector(
                deviceRowElement, ShowPrintCountsActionsButtonSelector);
            SeleniumHelper.ClickSafety(ShowPrintCountsElement);

            var PrintCountsTableElement = SeleniumHelper.FindElementByCssSelector(PrintCountsModalTableBodySelector);
            var PrintCountsRowElements = SeleniumHelper.FindRowElementsWithinTable(PrintCountsTableElement);

            foreach(var rowElement in PrintCountsRowElements)
            {
                var TotalPrintCountElement = SeleniumHelper.FindElementByCssSelector(rowElement, TotalPrintCountSelector);
                if (!TotalPrintCountElement.Text.Equals("-"))
                {
                    return rowElement;
                }
            }

            return PrintCountsRowElements[0];
        }

        private void VerifyStatusIcon(IWebElement deviceElement, string expectedIconSelector)
        {
            LoggingService.WriteLogOnMethodEntry(deviceElement, expectedIconSelector);

            try
            {
                var StatusIconElement = SeleniumHelper.FindElementByCssSelector(deviceElement, StatusIconSelector);
                var icon = SeleniumHelper.FindElementByCssSelector(StatusIconElement, expectedIconSelector);
            }
            catch(Exception e)
            {
                TestCheck.AssertFailTest(
                    string.Format(
                    "Status Icon of the device could not be verified. Expected icon selector = {0} could not be found. Error details = {1}", expectedIconSelector, e));
            }
        }

        public void VerifySwapRequestHasBeenSentSuccessfully(bool isCloseWhenSuccess=true)
        {
            LoggingService.WriteLogOnMethodEntry(isCloseWhenSuccess);
            // Verify success & close success alert
            var step = 0;
            try
            {
                step = 1;
                var alertSuccessElement = SeleniumHelper.FindElementByCssSelector(SuccessAlertSelector);
                step = 2;
                if (isCloseWhenSuccess) { SeleniumHelper.ClickSafety(alertSuccessElement.FindElement(By.ClassName("close"))); };
            }
            catch (Exception e)
            {
                TestCheck.AssertFailTest("Success Dialog not found after swap request is sent. step="+step+" Error details:" + e);
            }
        }

        public void AssertActionsAvailableForADealerOnADevice(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], ActionsButtonSelector);
            SeleniumHelper.ClickSafety(ActionsButtonElement);

            SeleniumHelper.WaitUntil(d => SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], ShowPrintCountsActionsButtonSelector).Displayed);
            SeleniumHelper.WaitUntil(d => SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], ShowDeviceDetailsActionsButtonSelector).Displayed);
            SeleniumHelper.WaitUntil(d => SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], ShowConsumableOrdersActionsButtonSelector).Displayed);
            SeleniumHelper.WaitUntil(d => SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], ShowServiceRequestsActionsButtonSelector).Displayed);
            SeleniumHelper.WaitUntil(d => SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], EditDeviceDataButtonSelector).Displayed);

            SeleniumHelper.ClickSafety(ActionsButtonElement);   // for closing action menu
        }
    }
}
