using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Contract
{
    [Binding]
    public sealed class MpsInstallerContractStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IContextData _contextData;
        private readonly IWebDriver _installerWebDriver;
        private readonly DeviceSimulatorService _deviceSimulatorService;

        public MpsInstallerContractStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            MpsSignInStepActions mpsSignIn,
            DeviceSimulatorService deviceSimulatorService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _contextData = contextData;
            _installerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Installer);
            _deviceSimulatorService = deviceSimulatorService;
        }

        public InstallerContractReferenceInstallationPage NavigateToWebInstallationPage(string url)
        {
            return _mpsSignIn.LoadInstallationPage(url);
        }

        public InstallerDeviceInstallationPage PopluateContractReferenceAndProceed(InstallerContractReferenceInstallationPage _installerContractReferenceInstallationPage, int proposalId)
        {
            _installerContractReferenceInstallationPage.PopulateContractReference(proposalId, RuntimeSettings.DefaultFindElementTimeout);
            _installerContractReferenceInstallationPage.ProceedOnInstaller(RuntimeSettings.DefaultFindElementTimeout);
            return PageService.GetPageObject<InstallerDeviceInstallationPage>(RuntimeSettings.DefaultPageLoadTimeout, _installerWebDriver);
        }

        public void PopulateSerialNumberAndCompleteInstallation(InstallerDeviceInstallationPage _installerDeviceInstallationPage, IEnumerable<PrinterProperties> products, IWebDriver installerDriver, string installerWindowHandle)
        {
            var installationPin = _installerDeviceInstallationPage.RetrieveInstallationPin(RuntimeSettings.DefaultFindElementTimeout);
            foreach(var product in products)
            {
                RegisterDeviceOnBOC(product, installationPin);
                _installerDeviceInstallationPage.EnterSerialNumber(product.Model, product.SerialNumber, RuntimeSettings.DefaultFindElementTimeout, installerDriver, installerWindowHandle);
            }
            _installerDeviceInstallationPage.CloudInstallationRefresh(RuntimeSettings.DefaultRetryCount, RuntimeSettings.DefaultFindElementTimeout);
            _installerDeviceInstallationPage.CompleteCloudInstallationComfirmationElement.Click();
            _installerDeviceInstallationPage.ConfirmInstallationComplete(RuntimeSettings.DefaultFindElementTimeout);
        }

        private void RegisterDeviceOnBOC(PrinterProperties product, string installationPin)
        {
                var deviceId = _deviceSimulatorService.CreateNewDevice(product.Model, product.SerialNumber);
                _deviceSimulatorService.RegisterNewDevice(deviceId, installationPin);
                _deviceSimulatorService.ChangeDeviceStatus(deviceId, true, true);
                _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
                product.DeviceId = deviceId;
        }
    }
}
