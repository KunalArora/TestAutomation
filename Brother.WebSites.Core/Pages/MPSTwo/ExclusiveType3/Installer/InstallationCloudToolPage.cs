﻿using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Installer
{
    public class InstallationCloudToolPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".mps-device-container.js-mps-device";
        private const string _url = "/mps/installation/cloud-tool?t={token}"; // TODO: Replace token with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }



        private const string InstallationPinSelector = ".js-mps-boc-pin";
        private const string IsConnectedSelector = ".responding";
        private const string DeviceModelNameSelector = "[id*=content_0_DeviceListForTool_List_CellModel_]";
        private const string SelectSerialLinkSelector = ".js-mps-select-serial-link";
        private const string SerialNumberWarningIconSelector = ".js-mps-icon-serial.glyphicon.glyphicon-warning-sign";
        private const string SerialNumberRefreshIconSelector = ".js-mps-icon-serial.glyphicon.glyphicon-refresh";
        private const string SelectSerialTableSelector = ".js-mps-serials-select-table > tbody";
        private const string SerialNumberTableRowElementSelector = ".js-mps-boc-device";
        private const string SelectDeviceRadioButtonSelector = ".js-mps-select-boc-device";
        private const string ResetButtonSelector = ".js-mps-button-reset";
        private const string NotConnectedSelector = ".glyphicon-remove";
        private const string DeviceLocationSelector = ".js-mps-input-device-location";
        private const string CostCentreSelector = ".js-mps-input-device-costcentre";
        private const string DangerAlertSelector = ".alert-danger";
        

        // Web Elements
        [FindsBy(How = How.CssSelector, Using = ".js-mps-boc-pin")]
        public IWebElement InstallationPinElement;
        [FindsBy(How = How.CssSelector, Using = ".panel-body > .table.table-striped > tbody")]
        public IWebElement DeviceTableContainerElement;
        [FindsBy(How = How.CssSelector, Using = ".responding")]
        public IWebElement IsConnectedElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-button-refresh")]
        public IWebElement RefreshButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-button-get-pin")]
        public IWebElement GetPinButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-btn-set-serial")]
        public IWebElement SetSerialButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#serialModal > .modal-dialog > .modal-content > .modal-header > button.close")]
        public IWebElement CloseSetSerialNumberModalButtonElement;
        [FindsBy(How = How.Id, Using = "content_0_Software_LinkDownloadSoftware")]
        public IWebElement LinkDownloadSoftwareElement;       


        public bool IsDeviceConnected(string mpsDeviceId)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceTableContainerElement);
            foreach(var element in deviceRowElements)
            {
                if (element.GetAttribute("data-id").Equals(mpsDeviceId) && SeleniumHelper.IsElementDisplayed(IsConnectedElement))
                {
                    return true;
                }
            }
            return false;
        }

        public string GetPin()
        {
            LoggingService.WriteLogOnMethodEntry();
            
            int start_time, elapsed_time;
            start_time = DateTime.Now.Second;

            SeleniumHelper.WaitUntil(d => InstallationPinElement.Text != "", RuntimeSettings.DefaultAPIResponseTimeout); // BOC Pin API is being called here, hence larger timeout value
            
            elapsed_time = DateTime.Now.Second - start_time;
            if (elapsed_time > 10) 
            {
                LoggingService.WriteLog(LoggingLevel.WARNING, string.Format("BOC pin generator API has a slow response. Time taken = {0}", elapsed_time));
            }

            return InstallationPinElement.Text;
        }

        public bool IsSerialNumberForAllDevicesDetected()
        {
            LoggingService.WriteLogOnMethodEntry();
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceTableContainerElement);
            foreach (var element in deviceRowElements)
            {
                if (SeleniumHelper.IsElementDisplayed(element, SerialNumberWarningIconSelector))
                {
                    return false;
                }
            }
            return true;
        }

        public bool SelectSerialNumber(IWebElement element, string mpsDeviceId, string serialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(element, mpsDeviceId, serialNumber);
            var dataId = element.GetAttribute("data-id");
            if ((dataId == mpsDeviceId) && SeleniumHelper.IsElementDisplayed(
                element, SelectSerialLinkSelector))
            {
                SeleniumHelper.ClickSafety(
                    element.FindElement(By.CssSelector(SelectSerialLinkSelector)));
                SelectSerialNumberHelper(
                    serialNumber);
                return true;
            }
            return false;           
        }

        public bool AreAllDevicesConnected()
        {
            LoggingService.WriteLogOnMethodEntry();
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceTableContainerElement);
            foreach (var element in deviceRowElements)
            {
                if (!SeleniumHelper.IsElementDisplayed(element, IsConnectedSelector))
                {
                    return false;
                }
            }
            return true;
        }

        public void VerifySoftwareDownloadLink(string expectedSoftwareDownloadLink)
        {
            LoggingService.WriteLogOnMethodEntry(expectedSoftwareDownloadLink);
            TestCheck.AssertTextContains(expectedSoftwareDownloadLink, LinkDownloadSoftwareElement.GetAttribute("href"), "Software Download link verification failed");
        }

        private void SelectSerialNumberHelper(string serialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber);
            var serialNumberTableElement = SeleniumHelper.FindElementByCssSelector(SelectSerialTableSelector);
            var rowElements = SeleniumHelper.FindElementsByCssSelector(serialNumberTableElement, SerialNumberTableRowElementSelector);
            
            foreach(var element in rowElements)
            {
                if (element.GetAttribute("data-serial-number").Equals(serialNumber))
                {
                    var radioButton = SeleniumHelper.FindElementByCssSelector(element, SelectDeviceRadioButtonSelector);
                    SeleniumHelper.ClickRadioButtonSafely(radioButton);
                }
            }

            if(SetSerialButtonElement.Enabled)
            {
                SeleniumHelper.ClickSafety(SetSerialButtonElement);
            }
            else
            {
                SeleniumHelper.ClickSafety(CloseSetSerialNumberModalButtonElement);
            }
        }

        public void ClickReset(string mpsDeviceId)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceTableContainerElement);
            foreach (var element in deviceRowElements)
            {
                if (element.GetAttribute("data-id").Equals(mpsDeviceId))
                {
                    var ResetButtonElement = SeleniumHelper.FindElementByCssSelector(element, ResetButtonSelector);
                    SeleniumHelper.ClickSafety(ResetButtonElement);

                    SeleniumHelper.AcceptJavascriptAlert();

                    // Check if the red alert pops up & if yes fail the test
                    if (!SeleniumHelper.IsElementNotPresent(DangerAlertSelector))
                    {
                        TestCheck.AssertFailTest(string.Format("Error occurred while resetting the device (alert popped up) {0} during installation", mpsDeviceId));
                    }

                    // Page gets refreshed few seconds after clicking reset button. We need to wait those few seconds.
                    SeleniumHelper.WaitUntil(d => ExpectedConditions.StalenessOf(ResetButtonElement));
                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0} while clicking the reset button", mpsDeviceId));
        }

        public void VerifyNotConnectedStatus(string mpsDeviceId)
        {
            LoggingService.WriteLogOnMethodEntry(mpsDeviceId);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceTableContainerElement);
            foreach (var element in deviceRowElements)
            {
                if (element.GetAttribute("data-id").Equals(mpsDeviceId))
                {
                    try
                    {
                        SeleniumHelper.WaitUntil(d => SeleniumHelper.IsElementDisplayed(element, NotConnectedSelector));
                        return;
                    }
                    catch
                    {
                        TestCheck.AssertFailTest(string.Format("Not connected status of the device {0} could not be verified after reset of device", mpsDeviceId));
                    }
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0} while verifying the Not Connected device status after resetting", mpsDeviceId));
        }

        public void FillDeviceDetails(AdditionalDeviceProperties device)
        {
            LoggingService.WriteLogOnMethodEntry(device);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceTableContainerElement);
            foreach (var element in deviceRowElements)
            {
                if (element.GetAttribute("data-id").Equals(device.MpsDeviceId))
                {
                    device.DeviceLocation = MpsUtil.DeviceLocation();
                    device.CostCentre = MpsUtil.CostCentre();

                    ClearAndType(SeleniumHelper.FindElementByCssSelector(element, DeviceLocationSelector), device.DeviceLocation);

                    if (!SeleniumHelper.IsElementNotPresent(DangerAlertSelector))
                    {
                        TestCheck.AssertFailTest(string.Format("Error occurred while typing device location into field for device {0}", device.MpsDeviceId));
                    }
                    
                    ClearAndType(SeleniumHelper.FindElementByCssSelector(element, CostCentreSelector), device.CostCentre);

                    if (!SeleniumHelper.IsElementNotPresent(DangerAlertSelector))
                    {
                        TestCheck.AssertFailTest(string.Format("Error occurred while typing cost centre into field for device {0}", device.MpsDeviceId));
                    }

                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", device.MpsDeviceId));
        }
    }
}
