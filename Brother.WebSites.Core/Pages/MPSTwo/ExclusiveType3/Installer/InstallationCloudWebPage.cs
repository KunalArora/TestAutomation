﻿using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Installer
{
    public class InstallationCloudWebPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".mps-device-container.js-mps-device";
        private const string _url = "/mps/installation/cloud-web?t={token}"; // TODO: Replace token with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }



        private const string IPAddress1Selector = "[id*=content_0_List_InputIp1_]";
        private const string IPAddress2Selector = "[id*=content_0_List_InputIp2_]";
        private const string IPAddress3Selector = "[id*=content_0_List_InputIp3_]";
        private const string IPAddress4Selector = "[id*=content_0_List_InputIp4_]";
        private const string DeviceLocationSelector = "[id*=content_0_List_InputDeviceLocation_]";
        private const string CostCentreSelector = "[id*=content_0_List_InputCostCentre_]";
        private const string ConnectButtonSelector = ".js-mps-button-connect";
        private const string IsConnectedSelector = ".responding";
        private const string ResetButtonSelector = ".js-mps-button-reset";
        private const string NotConnectedSelector = ".glyphicon-remove";
        private const string DangerAlertSelector = ".alert-danger";
        private const string SerialNumberSelector = "[id*=content_0_List_SerialNumber_]";

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
        [FindsBy(How = How.CssSelector, Using = ".js-mps-button-refresh")]
        public IWebElement RefreshButtonElement;
        [FindsBy(How = How.CssSelector, Using = ".panel-body > .table.table-striped > tbody")]
        public IWebElement DeviceTableContainerElement;

        // Fill device details & hit connect for this device
        public void FillDeviceDetailsAndClickConnect(AdditionalDeviceProperties device, string windowHandle)
        {
            LoggingService.WriteLogOnMethodEntry(device, windowHandle);
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(DeviceTableContainerElement);
            foreach(var element in deviceRowElements)
            {
                if (element.GetAttribute("data-id").Equals(device.MpsDeviceId))
                {
                    ClearAndType(element.FindElement(By.CssSelector(IPAddress1Selector)), "1");
                    ClearAndType(element.FindElement(By.CssSelector(IPAddress2Selector)), "1");
                    ClearAndType(element.FindElement(By.CssSelector(IPAddress3Selector)), "1");
                    ClearAndType(element.FindElement(By.CssSelector(IPAddress4Selector)), "1");

                    device.DeviceLocation = MpsUtil.DeviceLocation();
                    device.CostCentre = MpsUtil.CostCentre();

                    ClearAndType(element.FindElement(By.CssSelector(DeviceLocationSelector)), device.DeviceLocation);

                    if(!SeleniumHelper.IsElementNotPresent(DangerAlertSelector))
                    {
                        TestCheck.AssertFailTest(string.Format("Error occurred while typing device location into field for device {0}", device.MpsDeviceId));
                    }

                    ClearAndType(element.FindElement(By.CssSelector(CostCentreSelector)), device.CostCentre);

                    if (!SeleniumHelper.IsElementNotPresent(DangerAlertSelector))
                    {
                        TestCheck.AssertFailTest(string.Format("Error occurred while typing cost centre into field for device {0}", device.MpsDeviceId));
                    }

                    SeleniumHelper.ClickSafety(
                        SeleniumHelper.FindElementByCssSelector(
                        element, ConnectButtonSelector));

                    SeleniumHelper.CloseBrowserTabsExceptMainWindow(windowHandle);
                }
            }
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
                // Verify the serial number is assigned and displayed against the device
                var snElement = SeleniumHelper.FindElementByCssSelector(element, SerialNumberSelector);
                if( string.IsNullOrWhiteSpace(snElement.Text))
                {
                    return false;
                }
            }
            return true;
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
                    break;
                }
            }
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
                        break;
                    }
                    catch
                    {
                        TestCheck.AssertFailTest(string.Format("Not connected status of the device {0} could not be verified after reset of device", mpsDeviceId));
                    }
                }
            }
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

            if (!SeleniumHelper.IsElementNotPresent(NewPrintCountColourSelector))
            {
                int colourPrintCount = 100; //Fill any value
                ClearAndType(SeleniumHelper.FindElementByCssSelector(NewPrintCountColourSelector), colourPrintCount.ToString());
                newDevice.ColorPrintCount = colourPrintCount;
            }

            SeleniumHelper.ClickSafety(SeleniumHelper.FindElementByCssSelector(CompleteInstallationButtonSelector));

            SeleniumHelper.WaitUntil(d => SeleniumHelper.FindElementByCssSelector(CompleteSwapSuccessSelector).Displayed);
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
    }
}
