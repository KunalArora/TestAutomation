using Brother.Tests.Specs.Configuration;
using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Installer;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;

namespace Brother.Tests.Specs.StepActions.Agreement
{
    public class MpsInstallerAgreementStepActions: StepActionBase
    {
        private const string EXPECTED_SOFTWARE_DOWNLOAD_LINK = "/mps/web-installation/download-tools";

        private readonly IWebDriver _installerWebDriver;
        private readonly IContextData _contextData;
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IDeviceSimulatorService _deviceSimulatorService;
        private readonly IAgreementHelper _agreementHelper;

        public MpsInstallerAgreementStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            MpsSignInStepActions mpsSignIn,
            IDeviceSimulatorService deviceSimulatorService,
            IAgreementHelper agreementHelper)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _installerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Installer);
            _contextData = contextData;
            _mpsSignIn = mpsSignIn;
            _deviceSimulatorService = deviceSimulatorService;
            _agreementHelper = agreementHelper;
        }

        public void InstallDevicesOneByOneForCloudBor()
        {
            string deviceId, serialNumber;

            foreach(var device in _contextData.AdditionalDeviceProperties)
            {
                // 1. Navigate to installation URL
                var installationSelectMethodPage = _mpsSignIn.LoadInstallationSelectMethodPageType3(device.InstallationLink);

                // 2. Verify device details on InstallationSelectMethodPage
                installationSelectMethodPage.VerifyDeviceDetails(device.AgreementId, 1, device.Model); // Note: 1 is the number of devices (always 1 in case of one by one installation)

                // 3. Select installation method as "BOR"
                ClickSafety(
                    installationSelectMethodPage.BORInstallationButton(RuntimeSettings.DefaultFindElementTimeout), 
                    installationSelectMethodPage);
                var installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
                    RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);

                // Verify that Software download link is correct
                installationCloudToolPage.VerifySoftwareDownloadLink(EXPECTED_SOFTWARE_DOWNLOAD_LINK);

                // 4. Register the device on BOC using the Registration PIN
                // Already Registered on BOC?
                if (!device.IsRegisteredOnBoc)
                {
                    RegisterDeviceOnBOC(
                        device.Model, installationCloudToolPage.InstallationPinElement.Text, device.DeviceIndex, out deviceId, out serialNumber);
                    device.IsRegisteredOnBoc = true;

                    // Save details to contextData
                    device.BocDeviceId = deviceId;
                    device.SerialNumber = serialNumber;
                }
          
                // 5. Refresh until device is connected
                RefreshUntilConnectedForCloudBor(installationCloudToolPage);
            }
        }

        public void BulkInstallDevicesForCloudBor()
        {
            // 1. Navigate to Select method page & verify device details
            var installationSelectMethodPage = NavigateToSelectMethodPageForBulk();
            
            // 2. Select installation method as BOR & Navigate to installation page
            ClickSafety(
                    installationSelectMethodPage.BORInstallationButton(RuntimeSettings.DefaultFindElementTimeout),
                    installationSelectMethodPage);
            var installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);

            // Verify that Software download link is correct
            installationCloudToolPage.VerifySoftwareDownloadLink(EXPECTED_SOFTWARE_DOWNLOAD_LINK);

            // 3. Register devices on BOC
            ClickSafety(installationCloudToolPage.GetPinButtonElement, installationCloudToolPage);
            string pin = installationCloudToolPage.GetPin(RuntimeSettings.DefaultFindElementTimeout);

            string bocDeviceId, serialNumber;
            foreach(var device in _contextData.AdditionalDeviceProperties)
            {
                // Already Registered on BOC?
                if (!device.IsRegisteredOnBoc)
                {
                    RegisterDeviceOnBOC(device.Model, pin, device.DeviceIndex, out bocDeviceId, out serialNumber);
                    device.IsRegisteredOnBoc = true;

                    // Save device details to Context Data
                    device.BocDeviceId = bocDeviceId;
                    device.SerialNumber = serialNumber;
                }
            }

            // 4. Refresh until all devices serial numbers are detected
            int retries = 0;
            while (!installationCloudToolPage.IsSerialNumberForAllDevicesDetected(RuntimeSettings.DefaultFindElementTimeout))
            {
                ClickSafety(installationCloudToolPage.RefreshButtonElement, installationCloudToolPage);
                installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);
                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    throw new Exception(
                        string.Format("Number of retries exceeded the default limit during device installation for agreement {0}", _contextData.AgreementId));
                }
            }
            
            // 5. Select serial numbers of devices wherever possible
            installationCloudToolPage = SelectSerialNumbersHelper(installationCloudToolPage);

            // 6. Refresh until all devices are connected
            RefreshUntilConnectedForCloudBor(installationCloudToolPage);
        }

        public void BulkInstallDevicesForCloudWeb()
        {
            // 1. Navigate to Select method page & verify device details
            var installationSelectMethodPage = NavigateToSelectMethodPageForBulk();

            // 2. Select installation method as Web & Navigate to installation page
            ClickSafety(
                    installationSelectMethodPage.WebInstallationButton(RuntimeSettings.DefaultFindElementTimeout),
                    installationSelectMethodPage);
            var installationCloudWebPage = PageService.GetPageObject<InstallationCloudWebPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);

            string bocDeviceId, serialNumber;

            // Steps 3 & 4 are done for all devices one by one
            foreach(var device in _contextData.AdditionalDeviceProperties)
            {
                // 3. Fill in the device details and hit connect
                installationCloudWebPage.FillDeviceDetailsAndClickConnect(
                    device.MpsDeviceId, RuntimeSettings.DefaultFindElementTimeout, _contextData.WindowHandles[UserType.Installer]);

                // 4. Register devices on BOC
                
                // Already Registered on BOC?
                if (!device.IsRegisteredOnBoc)
                {
                    RegisterDeviceOnBOC(device.Model, device.RegistrationPin, device.DeviceIndex, out bocDeviceId, out serialNumber);
                    device.IsRegisteredOnBoc = true;

                    // Save details to context data
                    device.BocDeviceId = bocDeviceId;
                    device.SerialNumber = serialNumber;
                }           
            }
            
            // 5. Hit Refresh until all devices are connected
            int retries = 0;
            while (!installationCloudWebPage.AreAllDevicesConnected(RuntimeSettings.DefaultFindElementTimeout))
            {
                ClickSafety(installationCloudWebPage.RefreshButtonElement, installationCloudWebPage);
                installationCloudWebPage = PageService.GetPageObject<InstallationCloudWebPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);
                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    throw new Exception(
                        string.Format("Number of retries exceeded the default limit during device installation for agreement {0}", _contextData.AgreementId));
                }
            }
        }

        public void SingleDeviceInstallationForCloudUsb(AdditionalDeviceProperties device)
        {
            string bocDeviceId, serialNumber;

            // 1. Navigate to installation URL
            var installationSelectMethodPage = _mpsSignIn.LoadInstallationSelectMethodPageType3(device.InstallationLink);

            // 2. Verify device details on InstallationSelectMethodPage
            installationSelectMethodPage.VerifyDeviceDetails(device.AgreementId, 1, device.Model); // Note: 1 is the number of devices (always 1 in case of one by one installation)

            // 3. Select installation method as "USB"
            ClickSafety(installationSelectMethodPage.MoreInstallationOptionsButtonElement, installationSelectMethodPage);
            ClickSafety(
                installationSelectMethodPage.USBInstallationButton(RuntimeSettings.DefaultFindElementTimeout),
                installationSelectMethodPage);
            var installationCloudUsbPage = PageService.GetPageObject<InstallationCloudUsbPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);

            // Verify that Software download link is correct
            installationCloudUsbPage.VerifySoftwareDownloadLink(EXPECTED_SOFTWARE_DOWNLOAD_LINK);

            // 4. Register the device on BOC using the Registration PIN
            // Already Registered on BOC?
            if (!device.IsRegisteredOnBoc)
            {
                RegisterDeviceOnBOC(
                    device.Model, installationCloudUsbPage.InstallationPinElement.Text, device.DeviceIndex, out bocDeviceId, out serialNumber);
                device.IsRegisteredOnBoc = true;

                // Save details to context data
                device.BocDeviceId = bocDeviceId;
                device.SerialNumber = serialNumber;
            }           
            
            // 5. Refresh until device is connected
            RefreshUntilConnectedForCloudUsb(installationCloudUsbPage);
        }

        public void BulkInstallDevicesForCloudUsb()
        {
            // 1. Navigate to Select method page & verify device details
            var installationSelectMethodPage = NavigateToSelectMethodPageForBulk();

            // 2. Select installation method as USB & Navigate to installation page
            ClickSafety(installationSelectMethodPage.MoreInstallationOptionsButtonElement, installationSelectMethodPage);
            ClickSafety(
                installationSelectMethodPage.USBInstallationButton(RuntimeSettings.DefaultFindElementTimeout),
                installationSelectMethodPage);
            var installationCloudUsbPage = PageService.GetPageObject<InstallationCloudUsbPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);

            // Verify that Software download link is correct
            installationCloudUsbPage.VerifySoftwareDownloadLink(EXPECTED_SOFTWARE_DOWNLOAD_LINK);

            // 3. Register devices on BOC
            ClickSafety(installationCloudUsbPage.GetPinButtonElement, installationCloudUsbPage);
            string pin = installationCloudUsbPage.GetPin(RuntimeSettings.DefaultFindElementTimeout);

            string bocDeviceId, serialNumber;
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                // Already Registered on BOC?
                if(!device.IsRegisteredOnBoc)
                {
                    RegisterDeviceOnBOC(device.Model, pin, device.DeviceIndex, out bocDeviceId, out serialNumber);

                    device.IsRegisteredOnBoc = true;
                    // Save device details to Context Data
                    device.BocDeviceId = bocDeviceId;
                    device.SerialNumber = serialNumber;
                }
            }

            // 4. Refresh until all devices serial numbers are detected
            int retries = 0;
            while (!installationCloudUsbPage.IsSerialNumberForAllDevicesDetected(RuntimeSettings.DefaultFindElementTimeout))
            {
                ClickSafety(installationCloudUsbPage.RefreshButtonElement, installationCloudUsbPage);
                installationCloudUsbPage = PageService.GetPageObject<InstallationCloudUsbPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);
                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    throw new Exception(
                        string.Format("Number of retries exceeded the default limit during device installation for agreement {0}", _contextData.AgreementId));
                }
            }

            // 5. Select serial numbers of devices wherever possible
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                var deviceRowElements = installationCloudUsbPage.SeleniumHelper.FindRowElementsWithinTable(
                    installationCloudUsbPage.DeviceTableContainerElement);

                foreach (var element in deviceRowElements)
                {
                    bool isSuccess = installationCloudUsbPage.SelectSerialNumber(
                        element, device.MpsDeviceId, device.SerialNumber, RuntimeSettings.DefaultFindElementTimeout);
                    if (isSuccess)
                    {
                        ClickSafety(installationCloudUsbPage.RefreshButtonElement, installationCloudUsbPage);
                        installationCloudUsbPage = PageService.GetPageObject<InstallationCloudUsbPage>(
                            RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);
                        break;
                    }
                }
            }

            // 6. Refresh until all devices are connected
            RefreshUntilConnectedForCloudUsb(installationCloudUsbPage);
        }

        #region private methods

        private void RegisterDeviceOnBOC(string deviceModel, string installationPin, int deviceIndex, out string deviceId, out string serialNumber)
        {
            // 1. Create new device
            serialNumber = _agreementHelper.GenerateSerialNumber(deviceIndex);
            deviceId = _deviceSimulatorService.CreateNewDevice(deviceModel, serialNumber);

            // 2. Enter Pin & register
            _deviceSimulatorService.RegisterNewDevice(deviceId, installationPin);

            // 3. Subscribe device & change status to online
            _deviceSimulatorService.ChangeDeviceStatus(deviceId, true, true);

            // 4. Notify BOC of the changes
            _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
        }

        private InstallationSelectMethodPage NavigateToSelectMethodPageForBulk()
        {
            // Navigate to advanced installation URL
            var installationManageInstallationsPage = _mpsSignIn.LoadInstallationManageInstallationsPageType3(
                _contextData.AdditionalDeviceProperties[0].AdvancedInstallationLink);
            int deviceCount = installationManageInstallationsPage.NumberOfDevices();

            // Bulk Select all devices & Navigate to Select method Page
            ClickSafety(
                installationManageInstallationsPage.BulkSelectAllDevicesCheckboxElement, installationManageInstallationsPage);
            ClickSafety(
                installationManageInstallationsPage.BulkInstallDevicesButton, installationManageInstallationsPage);
            var installationSelectMethodPage = PageService.GetPageObject<InstallationSelectMethodPage>(
                    RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);

            // Verify Agreement Reference & Device Count
            installationSelectMethodPage.VerifyDeviceDetails(_contextData.AgreementId.ToString(), deviceCount);

            return installationSelectMethodPage;
        }

        private InstallationCloudToolPage SelectSerialNumbersHelper(InstallationCloudToolPage installationCloudToolPage)
        {
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                var deviceRowElements = installationCloudToolPage.SeleniumHelper.FindRowElementsWithinTable(
                    installationCloudToolPage.DeviceTableContainerElement);

                foreach (var element in deviceRowElements)
                {
                    bool isSuccess = installationCloudToolPage.SelectSerialNumber(
                        element, device.MpsDeviceId, device.SerialNumber, RuntimeSettings.DefaultFindElementTimeout);
                    if (isSuccess)
                    {
                        ClickSafety(installationCloudToolPage.RefreshButtonElement, installationCloudToolPage);
                        installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
                            RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);
                        break;
                    }
                }
            }

            return installationCloudToolPage;
        }

        private void RefreshUntilConnectedForCloudBor(InstallationCloudToolPage installationCloudToolPage)
        {
            int retries = 0;
            while (!installationCloudToolPage.AreAllDevicesConnected(RuntimeSettings.DefaultFindElementTimeout))
            {
                ClickSafety(installationCloudToolPage.RefreshButtonElement, installationCloudToolPage);
                installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);
                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    throw new Exception(
                        string.Format("Number of retries exceeded the default limit during device installation for agreement {0}", _contextData.AgreementId));
                }
            }
        }

        private void RefreshUntilConnectedForCloudUsb(InstallationCloudUsbPage installationCloudUsbPage)
        {
            int retries = 0;
            while (!installationCloudUsbPage.AreAllDevicesConnected(RuntimeSettings.DefaultFindElementTimeout))
            {
                ClickSafety(installationCloudUsbPage.RefreshButtonElement, installationCloudUsbPage);
                installationCloudUsbPage = PageService.GetPageObject<InstallationCloudUsbPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);
                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    throw new Exception(
                        string.Format("Number of retries exceeded the default limit during device installation for agreement {0}", _contextData.AgreementId));
                }
            }
        }
        
        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }

        #endregion
    }
}
