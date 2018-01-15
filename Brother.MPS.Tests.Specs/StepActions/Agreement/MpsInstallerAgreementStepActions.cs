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

namespace Brother.Tests.Specs.StepActions.Agreement
{
    public class MpsInstallerAgreementStepActions: StepActionBase
    {
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

                // 4. Register the device on BOC using the Registration PIN
                RegisterDeviceOnBOC(
                    device.Model, installationCloudToolPage.InstallationPinElement.Text, device.DeviceIndex, out deviceId, out serialNumber);

                // 5. Refresh until device is connected
                while(!installationCloudToolPage.IsDeviceConnected(device.MpsDeviceId))
                {
                    ClickSafety(installationCloudToolPage.RefreshButtonElement, installationCloudToolPage);
                    installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
                    RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);
                }

                // 6. Save details to contextData
                device.BocDeviceId = deviceId;
                device.SerialNumber = serialNumber;
            }
        }

        public void BulkInstallDevicesForCloudBor()
        {
            // 1. Navigate to advanced installation URL
            var installationManageInstallationsPage = _mpsSignIn.LoadInstallationManageInstallationsPageType3(
                _contextData.AdditionalDeviceProperties[0].AdvancedInstallationLink);

            // 2. Bulk Select all devices & Navigate to Select method Page
            ClickSafety(
                installationManageInstallationsPage.BulkSelectAllDevicesCheckboxElement, installationManageInstallationsPage);
            ClickSafety(
                installationManageInstallationsPage.BulkInstallDevicesButton, installationManageInstallationsPage);
            var installationSelectMethodPage = PageService.GetPageObject<InstallationSelectMethodPage>(
                    RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);
            
            // 3. Select installation method as BOR & Navigate to installation page
            ClickSafety(
                    installationSelectMethodPage.BORInstallationButton(RuntimeSettings.DefaultFindElementTimeout),
                    installationSelectMethodPage);
            var installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);

            // 3. Register devices on BOC
            ClickSafety(installationCloudToolPage.GetPinButtonElement, installationCloudToolPage);
            string pin = installationCloudToolPage.GetPin(RuntimeSettings.DefaultFindElementTimeout);

            string bocDeviceId, serialNumber;
            foreach(var device in _contextData.AdditionalDeviceProperties)
            {
                RegisterDeviceOnBOC(device.Model, pin, device.DeviceIndex, out bocDeviceId, out serialNumber);
                
                // Save device details to Context Data
                device.BocDeviceId = bocDeviceId;
                device.SerialNumber = serialNumber;
            }

            // 4. Refresh until all devices serial numbers are detected
            while (!installationCloudToolPage.IsSerialNumberForAllDevicesDetected(RuntimeSettings.DefaultFindElementTimeout))
            {
                ClickSafety(installationCloudToolPage.RefreshButtonElement, installationCloudToolPage);
                installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);
            }
            
            // 5. Select serial numbers of devices wherever possible
            installationCloudToolPage = SelectSerialNumbersHelper(installationCloudToolPage);

            // 6. Refresh until all devices are connected
            while (!installationCloudToolPage.AreAllDevicesConnected(RuntimeSettings.DefaultFindElementTimeout))
            {
                ClickSafety(installationCloudToolPage.RefreshButtonElement, installationCloudToolPage);
                installationCloudToolPage = PageService.GetPageObject<InstallationCloudToolPage>(
                RuntimeSettings.DefaultFindElementTimeout, _installerWebDriver);
            }
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
        
        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }

        #endregion
    }
}
