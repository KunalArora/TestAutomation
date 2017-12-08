using Brother.Tests.Selenium.Lib.Helpers;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

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
                // TODO: Uncomment below (& remove exception) after solving the dynamic parameter dependency problem in URL
                // return _url; 
                throw new Exception("Cannot determine Page URL due to presence of dynamic parameters");
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        // Selectors
        private const string DeviceModelNameSelector = "[id*=content_1_Devices_ModelCell_]";
        private const string ActionsButtonSelector = "button.btn.btn-primary.btn-xs.dropdown-toggle";
        private const string EditDeviceDataButtonSelector = ".js-mps-edit-device-data";
        private const string StatusToolTipSelector = ".js-mps-tooltip";
        private const string StatusDataAttributeSelector = "data-original-title";
        private const string DeviceCheckboxSelector = ".js-mps-row-action";


        // Web Elements
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

        // Click on Edit Device Data button for this particular row element
        public void ClickOnEditDeviceData(IWebElement deviceRowElement, int findElementTimeout)
        {
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, ActionsButtonSelector, findElementTimeout);
            ActionsButtonElement.Click();
            var EditDeviceDataButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, EditDeviceDataButtonSelector, findElementTimeout);
            EditDeviceDataButtonElement.Click();
        }

        public void VerifyThatDevicesAreReadyForInstallation(int findElementTimeout)
        {
            var elements = SeleniumHelper.FindRowElementsWithinTable(DeviceContainerElement);
            foreach(var element in elements)
            {
                var StatusToolTipElement = SeleniumHelper.FindElementByCssSelector(element, StatusToolTipSelector, findElementTimeout);
                string status = StatusToolTipElement.GetAttribute(StatusDataAttributeSelector);
                if(!status.ToLower().Contains("ready for install"))
                {
                    throw new Exception("Status of the device could not be verified");
                }
            }
        }


        // Click on Checkbox for this particular device row element
        public void ClickOnDeviceCheckbox(IWebElement deviceRowElement, int findElementTimeout)
        {
            var CheckboxElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, DeviceCheckboxSelector, findElementTimeout);
            SeleniumHelper.ClickSafety(CheckboxElement, findElementTimeout);
        }
    }
}
