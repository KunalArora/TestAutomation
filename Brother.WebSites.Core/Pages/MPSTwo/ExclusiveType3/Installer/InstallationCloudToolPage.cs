using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

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


        // Selectors
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
        private const string SerialNumberSelector = "span[id*=content_0_DeviceListForTool_List_SerialNumber_]";

        // Swap Complete installation selectors
        private const string OldModelSelector = "#content_0_CompleteSwap_ModelOld";
        private const string NewModelSelector = "#content_0_CompleteSwap_ModelNew";
        private const string OldSerialNumberSelector = "#content_0_CompleteSwap_SerialNumberOld";
        private const string NewSerialNumberSelector = "#content_0_CompleteSwap_SerialNumberNew";
        private const string OldPrintCountMonoSelector = "#content_0_CompleteSwap_InputPrintCountMonoOld";
        private const string NewPrintCountMonoSelector = "#content_0_CompleteSwap_InputPrintCountMonoNew";
        private const string NewPrintCountColourSelector = "#content_0_CompleteSwap_InputPrintCountColourNew";
        private const string CompleteInstallationButtonSelector = "#content_0_ButtonCompleteInstallation";
        private const string CompleteSwapSuccessSelector = "#content_0_CompleteSwap_ComponentSuccess";


        // Web Elements
        [FindsBy(How = How.CssSelector, Using = ".js-mps-boc-pin")]
        public IWebElement InstallationPinElement;
        [FindsBy(How = How.CssSelector, Using = ".panel-body > .table.table-striped > tbody")]
        public IWebElement DeviceTableContainerElement;
        [FindsBy(How = How.CssSelector, Using = ".responding")]
        public IWebElement IsConnectedElement;
        [FindsBy(How = How.CssSelector, Using = ".js-mps-button-refresh:not(.hidden)")]
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

        public bool SelectSerialNumber(IWebElement element, string mpsDeviceId, string serialNumber, bool isUnmatchDevice)
        {
            LoggingService.WriteLogOnMethodEntry(element, mpsDeviceId, serialNumber);
            var dataId = element.GetAttribute("data-id");
            if ((dataId == mpsDeviceId) && SeleniumHelper.IsElementDisplayed(
                element, SelectSerialLinkSelector))
            {
                SeleniumHelper.ClickSafety(element.FindElement(By.CssSelector(SelectSerialLinkSelector)));
                SelectSerialNumberHelper(serialNumber, isUnmatchDevice);
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

        private void SelectSerialNumberHelper(string serialNumber, bool isUnmatchDevice)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber);
            var divPanel = SeleniumHelper.FindElementByCssSelector(".js-mps-panel:not(.hidden)");
            var serialNumberTableElement = divPanel.FindElement(By.CssSelector(SelectSerialTableSelector));
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
            if (isUnmatchDevice)
            {
                var alert = SeleniumHelper.FindAlertDialog();
                var expectedMessage = TranslationService.GetDisplayMessageText(TranslationKeys.DisplayMessage.AreYouSureUnmatch, Culture);
                TestCheck.AssertIsEqual(expectedMessage, alert.Text, "invalid alert message");
                alert.Accept();
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

        public void VerifyDeviceDetailsAreNotCleared(AdditionalDeviceProperties device)
        {
            LoggingService.WriteLogOnMethodEntry(device);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceTableContainerElement);
            foreach (var element in deviceRowElements)
            {
                if (element.GetAttribute("data-id").Equals(device.MpsDeviceId))
                {
                    TestCheck.AssertIsNotNullOrEmpty(SeleniumHelper.FindElementByCssSelector(element, DeviceLocationSelector).Text,
                        string.Format("Error occured as Device Location was cleared after resetting device with deviceId: {0}", device.MpsDeviceId));

                    TestCheck.AssertIsNotNullOrEmpty(SeleniumHelper.FindElementByCssSelector(element, CostCentreSelector).Text,
                        string.Format("Error occured as Cost Centre was cleared after resetting device with deviceId: {0}", device.MpsDeviceId));

                    return;
                }
            }

            TestCheck.AssertFailTest(string.Format("Could not find the device with deviceId = {0}", device.MpsDeviceId));
        }

        public void CompleteSwapInstallation(AdditionalDeviceProperties oldDevice, AdditionalDeviceProperties newDevice)
        {
            LoggingService.WriteLogOnMethodEntry(oldDevice, newDevice);

            TestCheck.AssertIsEqual(
                oldDevice.Model, SeleniumHelper.FindElementByCssSelector(OldModelSelector).Text, "Model Name for the old device could not be verified during swap installation");

            TestCheck.AssertIsEqual(
                newDevice.Model, SeleniumHelper.FindElementByCssSelector(NewModelSelector).Text, "Model Name for the new device could not be verified during swap installation");

            TestCheck.AssertIsEqual(
                oldDevice.SerialNumber, SeleniumHelper.FindElementByCssSelector(OldSerialNumberSelector).Text, "Serial Number for the old device could not be verified during swap installation");

            TestCheck.AssertIsEqual(
                newDevice.SerialNumber, SeleniumHelper.FindElementByCssSelector(NewSerialNumberSelector).Text, "Serial Number for the new device could not be verified during swap installation");

            int monoPrintCount = 100; //Fill any value
            ClearAndType(SeleniumHelper.FindElementByCssSelector(NewPrintCountMonoSelector), monoPrintCount.ToString());
            newDevice.MonoPrintCount = monoPrintCount;

            if(!SeleniumHelper.IsElementNotPresent(NewPrintCountColourSelector))
            {
                int colourPrintCount = 100; //Fill any value
                ClearAndType(SeleniumHelper.FindElementByCssSelector(NewPrintCountColourSelector), colourPrintCount.ToString());
                newDevice.ColorPrintCount = colourPrintCount;
            }

            SeleniumHelper.ClickSafety(SeleniumHelper.FindElementByCssSelector(CompleteInstallationButtonSelector));

            SeleniumHelper.WaitUntil(d => SeleniumHelper.FindElementByCssSelector(CompleteSwapSuccessSelector).Displayed);
        }

        public void AssertSerialNumberIsDisplayed(IWebElement element, string mpsDeviceId, string serialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(element, mpsDeviceId, serialNumber);
            var snElement = SeleniumHelper.WaitUntil(d =>
            {
                var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceTableContainerElement);
                var trElement = deviceRowElements.FirstOrDefault(el => SeleniumHelper.IsElementDisplayed(el) && el.GetAttribute("data-id") == mpsDeviceId);
                if( trElement == null) { return null; }
                if(SeleniumHelper.IsElementDisplayed(trElement, SelectSerialLinkSelector)) { return null; }
                var td =  trElement.FindElement(By.CssSelector(SerialNumberSelector));
                return string.IsNullOrWhiteSpace(td.Text) ? null : td;
            });

            TestCheck.AssertIsEqual(serialNumber, snElement.Text, "assigned SerialNumber not equals mpdDeviceId=" + mpsDeviceId);
        }
    }
}
