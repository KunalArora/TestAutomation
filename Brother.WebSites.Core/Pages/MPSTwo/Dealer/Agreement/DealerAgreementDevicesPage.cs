using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo.Dealer.Agreement
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

        public ISeleniumHelper SeleniumHelper { get; set; }

        // Selectors
        private const string DeviceModelNameSelector = "[id*=content_1_Devices_ModelCell_]";
        private const string ActionsButtonSelector = "button.btn.btn-primary.btn-xs.dropdown-toggle";
        private const string EditDeviceDataButtonSelector = ".js-mps-edit-device-data";
        private const string SendInstallationRequestActionsButtonSelector = ".js-mps-send-installation-request";
        private const string StatusToolTipSelector = ".js-mps-tooltip";
        private const string StatusDataAttributeSelector = "data-original-title";
        private const string DeviceCheckboxSelector = ".js-mps-row-action";
        private const string InputEmailSelector = "#InputEmail";
        private const string ModalAlertSuccessSelector = ".modal-content.alert-success";

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



        // Click on Edit Device Data button for this particular model
        public void ClickOnEditDeviceData(string modelName, int findElementTimeout)
        {
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
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], ActionsButtonSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(ActionsButtonElement, findElementTimeout);
            var EditDeviceDataButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], EditDeviceDataButtonSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(EditDeviceDataButtonElement, findElementTimeout);
        }

        public void VerifyTheStatusOfAllDevices(int findElementTimeout, string expectedStatus)
        {
            var elements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach(var element in elements)
            {
                var StatusToolTipElement = SeleniumHelper.FindElementByCssSelector(element, StatusToolTipSelector, findElementTimeout);
                string displayedStatus = StatusToolTipElement.GetAttribute(StatusDataAttributeSelector);

                TestCheck.AssertTextContains(
                    expectedStatus, displayedStatus.ToLower(), "Status of the device could not be verified");
            }
        }


        // Click on Checkbox for this particular device row index
        public void ClickOnDeviceCheckbox(int rowIndex, int findElementTimeout)
        {
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElements[rowIndex], DeviceCheckboxSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(CheckboxElement, findElementTimeout);
        }

        // Verify address of the edited device given the row index & expected address
        public void VerifyAddressOfEditedDevice(int rowIndex, string expectedAddress)
        {
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);

            // TODO: Replace this with the conventional element finding method after ID/Class of the Address Element has been fixed
            string displayedAddress = deviceRowElements[rowIndex].FindElements(By.TagName("td")).ToList()[4].Text;

            TestCheck.AssertIsEqual(expectedAddress, displayedAddress, "Address of the edited device could not be verified");
        }


        // Get total number of rows of the device table
        public int DeviceTableRowsCount()
        {
            return SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement).Count;
        }

        // Validate address of the device given the device id & expected address string
        public void ValidateDeviceAddress(string deviceId, string expectedAddress, int findElementTimeout)
        {
            string displayedDeviceId, displayedAddress;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach (var deviceRowElement in deviceRowElements)
            {
                var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector, findElementTimeout);
                displayedDeviceId = CheckboxElement.GetAttribute("value");
                if (displayedDeviceId.Equals(deviceId))
                {
                    // TODO: Replace this with the conventional element finding method after ID/Class of the Address Element has been fixed
                    displayedAddress = deviceRowElement.FindElements(By.TagName("td")).ToList()[4].Text;
                    TestCheck.AssertIsEqual(expectedAddress, displayedAddress, "Address of the edited device could not be verified");
                    break;
                }
            }
        }

        // Get model name of the device given the row index
        public string DeviceModelName(int rowIndex, int findElementTimeout)
        {
            var deviceRowElement = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement)[rowIndex];
            return SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceModelNameSelector, findElementTimeout).Text;
        }

        public void SendInstallationRequest(int findElementTimeout)
        {
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
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);

            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(
                deviceRowElements[rowIndex], ActionsButtonSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(ActionsButtonElement, findElementTimeout);

            var SendInstallationRequestButtonElement = SeleniumHelper.FindElementByCssSelector(
                deviceRowElements[rowIndex], SendInstallationRequestActionsButtonSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(SendInstallationRequestButtonElement, findElementTimeout);
        }
    }
}
