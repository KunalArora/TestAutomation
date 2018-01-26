﻿using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
        
        // Action button selectors
        private const string ActionsButtonSelector = "button.btn.btn-primary.btn-xs.dropdown-toggle";
        private const string EditDeviceDataButtonSelector = ".js-mps-edit-device-data";
        private const string SendInstallationRequestActionsButtonSelector = ".js-mps-send-installation-request";
        private const string ShowPrintCountsActionsButtonSelector = ".js-mps-view-print-count";
        private const string ShowConsumableOrdersActionsButtonSelector = ".js-mps-view-consumable-orders";
        private const string RaiseConsumableOrderActionsButtonSelector = ".js-mps-raise-consumable-order";
        private const string RaiseServiceRequestActionsButtonSelector = ".js-mps-raise-service-request";
        private const string ShowDeviceDetailsActionsButtonSelector = ".js-mps-view-device-location";

        private const string StatusToolTipSelector = ".js-mps-tooltip";
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


        // Click on Edit Device Data button for this particular model
        public void ClickOnEditDeviceData(string modelName, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(modelName,findElementTimeout);
            var elements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var element in elements)
            {
                var DeviceModelNameElement = SeleniumHelper.FindElementByCssSelector(element, DeviceModelNameSelector, findElementTimeout);
                if (DeviceModelNameElement.Text.Equals(modelName))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(element, ActionsButtonSelector, findElementTimeout);
                    ActionsButtonElement.Click();
                    var EditDeviceDataButtonElement = SeleniumHelper.FindElementByCssSelector(element, EditDeviceDataButtonSelector, findElementTimeout);
                    EditDeviceDataButtonElement.Click();
                    break;
                }
            }
        }

        // Click on Edit Device Data button for this particular row index
        public void ClickOnEditDeviceData(int rowIndex, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex, findElementTimeout);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], ActionsButtonSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(ActionsButtonElement, findElementTimeout);
            var EditDeviceDataButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], EditDeviceDataButtonSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(EditDeviceDataButtonElement, findElementTimeout);
        }

        public void VerifyTheStatusOfAllDevices(int findElementTimeout, string expectedStatus)
        {
            LoggingService.WriteLogOnMethodEntry(findElementTimeout,expectedStatus);
            var elements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach(var element in elements)
            {
                var StatusToolTipElement = SeleniumHelper.FindElementByCssSelector(element, StatusToolTipSelector, findElementTimeout);
                string displayedStatus = StatusToolTipElement.GetAttribute(StatusDataAttributeSelector);

                TestCheck.AssertTextContains(
                    expectedStatus, displayedStatus, "Status of the device could not be verified");
            }
        }


        // Click on Checkbox for this particular device row index
        public void ClickOnDeviceCheckbox(int rowIndex, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex,findElementTimeout);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], DeviceCheckboxSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(CheckboxElement, findElementTimeout);
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
        public void ValidateDeviceAddress(string mpsDeviceId, string expectedAddress, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId, expectedAddress,findElementTimeout);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot verify device address for a device with Device Id null");
            }

            string displayedDeviceId, displayedAddress;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector, findElementTimeout);
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
        public string DeviceModelName(int rowIndex, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex,findElementTimeout);
            var deviceRowElement = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement)[rowIndex];
            return SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceModelNameSelector, findElementTimeout).Text;
        }

        public void SendInstallationRequest(int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(findElementTimeout);
            // Input Email ID
            SeleniumHelper.FindElementByCssSelector(InputEmailSelector, findElementTimeout).SendKeys(MpsUtil.GenerateUniqueEmail());
            
            // Click Send Installation Request button on modal
            SeleniumHelper.ClickSafety(SendInstallationRequestModalElement, findElementTimeout);

            // Verify success & close modal alert
            var modalSuccessElement = SeleniumHelper.FindElementByCssSelector(ModalAlertSuccessSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(modalSuccessElement.FindElement(By.ClassName("close")), findElementTimeout);
        }

        // Click on Send Installation Request in Actions for this particular device row index
        public void ClickSendInstallationRequestInActions(int rowIndex, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex,findElementTimeout);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);

            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                deviceRowElements[rowIndex], ActionsButtonSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(ActionsButtonElement, findElementTimeout);

            var SendInstallationRequestButtonElement = SeleniumHelper.FindElementByCssSelector(
                deviceRowElements[rowIndex], SendInstallationRequestActionsButtonSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(SendInstallationRequestButtonElement, findElementTimeout);
        }

        public void VerifySerialNumberOfDevice(string mpsDeviceId, string expectedSerialNumber, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId,expectedSerialNumber,findElementTimeout);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot verify serial number for a device with Device Id null");
            }

            string displayedDeviceId, displayedSerialNumber;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector, findElementTimeout);
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
        public bool IsPrintCountsUpdated(int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(findElementTimeout);
            bool isUpdated = false;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);

            foreach(var deviceRowElement in deviceRowElements)
            {
                var PrintCountsRowElement = ClickShowPrintCounts(deviceRowElement, findElementTimeout);
                var displayedTotalPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElement, TotalPrintCountSelector, findElementTimeout);

                if (!displayedTotalPrintCount.Text.Equals("-"))
                {
                    isUpdated = true;
                }
                else
                {
                    isUpdated = false;
                }

                // Close Modal
                SeleniumHelper.ClickSafety(
                    SeleniumHelper.FindElementByCssSelector(
                    PrintCountsModalCloseButtonSelector, findElementTimeout), findElementTimeout);
            }

            return isUpdated;
        }

        // Verify the Total print count, Mono print count and Colour print count of the device given the mpsDeviceId
        public void VerifyPrintCountsOfDevice(
            string mpsDeviceId, int colourPrintCount, int monoPrintCount, int totalPrintCount, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId,colourPrintCount,monoPrintCount,totalPrintCount,findElementTimeout);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot verify print counts for a device with Device Id null");
            }

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector, findElementTimeout);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    var PrintCountsRowElement = ClickShowPrintCounts(deviceRowElement, findElementTimeout);
                    var displayedDateTime = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElement, PrintCountsModalDateTimeSelector, findElementTimeout);
                    var displayedTotalPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElement, TotalPrintCountSelector, findElementTimeout);
                    var displayedColourPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElement, ColourPrintCountSelector, findElementTimeout);
                    var displayedMonoPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElement, MonoPrintCountSelector, findElementTimeout);
                    
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
                        PrintCountsModalCloseButtonSelector, findElementTimeout), findElementTimeout);

                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }

        public IWebElement ConsumablesTabElement(int agreementId)
        {
            LoggingService.WriteLogOnMethodEntry(agreementId);
            return SeleniumHelper.FindElementByCssSelector(
                string.Format(MpsTabsSelector + MpsTabsAgreementSelector + "{0}/consumables\"]", agreementId.ToString()), RuntimeSettings.DefaultFindElementTimeout);
        }

        public IWebElement ServiceRequestsTabElement(int agreementId)
        {
            LoggingService.WriteLogOnMethodEntry(agreementId);
            return SeleniumHelper.FindElementByCssSelector(
                string.Format(MpsTabsSelector + MpsTabsAgreementSelector + "{0}/service-requests\"]", agreementId.ToString()), RuntimeSettings.DefaultFindElementTimeout);
        }

        // Click Show Consumable Orders in Actions given the MPS device Id
        public void ClickShowConsumableOrders(string mpsDeviceId, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId,findElementTimeout);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot click Show Consumable Orders for a device with Device Id null");
            }

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector, findElementTimeout);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector, findElementTimeout);
                    SeleniumHelper.ClickSafety(ActionsButtonElement, findElementTimeout);

                    var ShowConsumableOrdersElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ShowConsumableOrdersActionsButtonSelector, findElementTimeout);
                    ScrollTo(ShowConsumableOrdersElement);
                    SeleniumHelper.ClickSafety(ShowConsumableOrdersElement, findElementTimeout);
                    
                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }

        // Click Raise Consumable Orders in Actions given the MPS device Id
        public void ClickRaiseConsumableOrder(string mpsDeviceId, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId,findElementTimeout);
            if (mpsDeviceId == null)
            {
                throw new Exception("Cannot click Raise Consumable Order for a device with Device Id null");
            }

            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector, findElementTimeout);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector, findElementTimeout);
                    SeleniumHelper.ClickSafety(ActionsButtonElement, findElementTimeout);

                    var RaiseConsumableOrderElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, RaiseConsumableOrderActionsButtonSelector, findElementTimeout);
                    ScrollTo(RaiseConsumableOrderElement);
                    SeleniumHelper.ClickSafety(RaiseConsumableOrderElement, findElementTimeout);

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
                        deviceFirstRowElement, ActionsButtonSelector, RuntimeSettings.DefaultFindElementTimeout);
            SeleniumHelper.ClickSafety(ActionsButtonElement, RuntimeSettings.DefaultFindElementTimeout);

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

            int findElementTimeout = RuntimeSettings.DefaultFindElementTimeout;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector, findElementTimeout);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector, findElementTimeout);
                    SeleniumHelper.ClickSafety(ActionsButtonElement, findElementTimeout);

                    var RaiseServiceRequestElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, RaiseServiceRequestActionsButtonSelector, findElementTimeout);
                    ScrollTo(RaiseServiceRequestElement);
                    SeleniumHelper.ClickSafety(RaiseServiceRequestElement, findElementTimeout);
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
            
            int findElementTimeout = RuntimeSettings.DefaultFindElementTimeout;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
         
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector, findElementTimeout);
                string displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(mpsDeviceId))
                {
                    var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector, findElementTimeout);
                    SeleniumHelper.ClickSafety(ActionsButtonElement, findElementTimeout);

                    var ShowDeviceDetailsElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ShowDeviceDetailsActionsButtonSelector, findElementTimeout);
                    ScrollTo(ShowDeviceDetailsElement);
                    SeleniumHelper.ClickSafety(ShowDeviceDetailsElement, findElementTimeout);
                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", mpsDeviceId));
        }

        public void VerifyDeviceDetails(AdditionalDeviceProperties device, string agreementType, string agreementLength, string usageType)
        {
            LoggingService.WriteLogOnMethodEntry(device,agreementType,agreementLength,usageType);
            var DeviceDetailsContainerElement = SeleniumHelper.FindElementByCssSelector(
                DeviceDetailsModalDeviceContainerSelector, RuntimeSettings.DefaultFindElementTimeout);

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

            SeleniumHelper.ClickSafety(DeviceDetailsModalCloseButtonElement, RuntimeSettings.DefaultFindElementTimeout);
        }


        // Click Show Print Counts in Actions and return the print counts table row element which contains the print count values
        private IWebElement ClickShowPrintCounts(IWebElement deviceRowElement, int findElementTimeout)
        {
            LoggingService.WriteLogOnMethodEntry(deviceRowElement,findElementTimeout);
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                        deviceRowElement, ActionsButtonSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(ActionsButtonElement, findElementTimeout);

            var ShowPrintCountsElement = SeleniumHelper.FindElementByCssSelector(
                deviceRowElement, ShowPrintCountsActionsButtonSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(ShowPrintCountsElement, findElementTimeout);

            var PrintCountsTableElement = SeleniumHelper.FindElementByCssSelector(PrintCountsModalTableBodySelector, findElementTimeout);
            var PrintCountsRowElements = SeleniumHelper.FindRowElementsWithinTable(PrintCountsTableElement); 
            
            foreach(var rowElement in PrintCountsRowElements)
            {
                var TotalPrintCountElement = SeleniumHelper.FindElementByCssSelector(rowElement, TotalPrintCountSelector, findElementTimeout);
                if (!TotalPrintCountElement.Text.Equals("-"))
                {
                    return rowElement;
                }
            }

            return PrintCountsRowElements[0];
        }
    }
}
