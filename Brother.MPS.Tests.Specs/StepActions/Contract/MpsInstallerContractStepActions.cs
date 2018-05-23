using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Linq;

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
            ILoggingService loggingService,
            MpsSignInStepActions mpsSignIn,
            DeviceSimulatorService deviceSimulatorService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _contextData = contextData;
            _installerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Installer);
            _deviceSimulatorService = deviceSimulatorService;
        }

        public InstallerContractReferenceInstallationPage NavigateToWebInstallationPage(string url)
        {
            LoggingService.WriteLogOnMethodEntry(url);
           return _mpsSignIn.LoadInstallationPage(url);
        }

        public InstallerDeviceInstallationPage PopluateContractReferenceAndProceed(InstallerContractReferenceInstallationPage _installerContractReferenceInstallationPage, int proposalId)
        {
            LoggingService.WriteLogOnMethodEntry(_installerContractReferenceInstallationPage, proposalId);
            _installerContractReferenceInstallationPage.PopulateContractReference(proposalId);
            _installerContractReferenceInstallationPage.ProceedOnInstaller();
            return PageService.GetPageObject<InstallerDeviceInstallationPage>(RuntimeSettings.DefaultPageLoadTimeout, _installerWebDriver);
        }

        public void PopulateSerialNumberAndCompleteInstallation(InstallerDeviceInstallationPage _installerDeviceInstallationPage, IWebDriver installerDriver)
        {
            LoggingService.WriteLogOnMethodEntry(_installerDeviceInstallationPage, installerDriver);
            var installationPin = _installerDeviceInstallationPage.RetrieveInstallationPin();
            var products = _contextData.PrintersProperties;

            foreach(var product in products)
            {
                string serialNumber = SerialNumberCalculationHelper(product.SerialNumber);
                product.SerialNumber = serialNumber;
                RegisterDeviceOnBOC(product, installationPin, product.SerialNumber);
                _installerDeviceInstallationPage.EnterSerialNumber(product.Model, serialNumber, installerDriver);
                RetryRefreshHelper(_installerDeviceInstallationPage, product.Model, product.SerialNumber, installerDriver);
            }
            if (!_installerDeviceInstallationPage.CompleteCloudButton())
            {
                int completeRetries = 0;
                _installerWebDriver.Navigate().Refresh();
                _installerDeviceInstallationPage = PageService.GetPageObject<InstallerDeviceInstallationPage>(RuntimeSettings.DefaultPageLoadTimeout, _installerWebDriver);

                completeRetries++;
                if(completeRetries > RuntimeSettings.DefaultRetryCount)
                {
                    TestCheck.AssertFailTest("Complete Confirmation button not found even after default retry count exceeded");
                }
            }
            _installerDeviceInstallationPage.ConfirmInstallationComplete();
        }

        public void PopulateSerialNumberAndCompleteEmailInstallation(InstallerDeviceInstallationPage _installerDeviceInstallationPage, IWebDriver installerDriver)
        {
            LoggingService.WriteLogOnMethodEntry(_installerDeviceInstallationPage, installerDriver);
            var installerWindowHandle = _contextData.WindowHandles[UserType.Installer];
            var products = _contextData.PrintersProperties;

            foreach (var product in products)
            {
                string serialNumber = SerialNumberCalculationHelper(product.SerialNumber);
                product.SerialNumber = serialNumber;
                _installerDeviceInstallationPage.EnterSerialNumber(product.Model, serialNumber, installerDriver);
                _installerDeviceInstallationPage.SeleniumHelper.CloseBrowserTabsExceptMainWindow(installerWindowHandle);
            }
            _installerDeviceInstallationPage.CompleteEmailButton();
            _installerDeviceInstallationPage.ConfirmInstallationComplete();
            var browserTabs = installerDriver.WindowHandles.ToList();
            if (browserTabs.Count > 1)
            {
                _installerDeviceInstallationPage.SeleniumHelper.CloseBrowserTabsExceptMainWindow(installerWindowHandle);
            }
        }

        public void PopulateSwapSerialNumber(InstallerDeviceInstallationPage _installerDeviceInstallationPage, IWebDriver installerDriver, string swapNewDeviceSerialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(_installerDeviceInstallationPage, installerDriver, swapNewDeviceSerialNumber);
            var swapOldDeviceSerialNumber = _contextData.SwapOldDeviceSerialNumber;
            var installationPin = _installerDeviceInstallationPage.RetrieveInstallationPin();
            var products = _contextData.PrintersProperties;

            foreach(var product in products)
            {
                if(product.SerialNumber.Equals(swapOldDeviceSerialNumber))
                {
                    string serialNumber = SerialNumberCalculationHelper(swapNewDeviceSerialNumber);
                    _contextData.SwapNewDeviceSerialNumber = serialNumber;
                    RegisterDeviceOnBOC(product, installationPin, serialNumber);
                    _installerDeviceInstallationPage.EnterSerialNumber(product.Model, serialNumber, installerDriver);
                    RetryRefreshHelper(_installerDeviceInstallationPage, product.Model, serialNumber, installerDriver);
                }
            }
        }

        public void EnterSwapPrintCountAndCompleteInstallation(InstallerDeviceInstallationPage _installerDeviceInstallationPage, string swapNewDeviceSerialNumber, int swapNewDeviceMonoPrintcount, int swapNewDeviceColorPrintcount)
        {
            LoggingService.WriteLogOnMethodEntry(_installerDeviceInstallationPage, swapNewDeviceSerialNumber, swapNewDeviceSerialNumber);
            var products = _contextData.PrintersProperties;
            foreach(var product in products)
            {
                if(product.IsSwap)
                {
                    _installerDeviceInstallationPage.EnterSwapPrintCount(product.SerialNumber, product.MonoPrintCount, product.ColorPrintCount, swapNewDeviceSerialNumber, swapNewDeviceMonoPrintcount, swapNewDeviceColorPrintcount);
                }
            }
            _installerDeviceInstallationPage.SeleniumHelper.ClickSafety(_installerDeviceInstallationPage.CompleteCloudInstallationComfirmationElement);
            _installerDeviceInstallationPage.ConfirmInstallationComplete();
        }

        public void RetryRefresh(InstallerDeviceInstallationPage _installerDeviceInstallationPage, IWebDriver installerDriver) 
        {
            LoggingService.WriteLogOnMethodEntry(_installerDeviceInstallationPage, installerDriver);
            foreach (var product in _contextData.PrintersProperties)
            {
                if (product.IsSwap)
                {
                    _contextData.SwapNewDeviceSerialNumber = product.SerialNumber;
                    RetryRefreshHelper(_installerDeviceInstallationPage, product.Model, product.SerialNumber, installerDriver);
                }
            }
        }

        private void RegisterDeviceOnBOC(PrinterProperties product, string installationPin, string serialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(product, installationPin, serialNumber);
            var deviceId = _deviceSimulatorService.CreateNewDevice(product.Model, serialNumber);
            _deviceSimulatorService.RegisterNewDevice(deviceId, installationPin);
            _deviceSimulatorService.ChangeDeviceStatus(deviceId, true, true);
            _deviceSimulatorService.NotifyBocOfDeviceChanges(deviceId);
            product.DeviceId = deviceId;
        }

        private void RetryRefreshHelper(InstallerDeviceInstallationPage _installerDeviceInstallationPage, string model, string serialNumber, IWebDriver installerDriver)
        {
            LoggingService.WriteLogOnMethodEntry(_installerDeviceInstallationPage, model, serialNumber, installerDriver);
            int serialEnterRetry = 0;
            int retries = 0;
            var installerWindowHandle = _contextData.WindowHandles[UserType.Installer];

            while (!(_installerDeviceInstallationPage.RetryResetClickingHelper(model, serialNumber, installerWindowHandle, installerDriver, serialEnterRetry)))
            {
                _installerDeviceInstallationPage.ClickOnRefreshButton();
                _installerWebDriver.Navigate().Refresh();
                _installerDeviceInstallationPage = PageService.GetPageObject<InstallerDeviceInstallationPage>(RuntimeSettings.DefaultPageLoadTimeout, _installerWebDriver);

                serialEnterRetry++;
                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    TestCheck.AssertFailTest("Error while installing the device=" + serialNumber + "Retry count exceeded the default value" + retries);
                }
                continue;
            }

        }

        private string SerialNumberCalculationHelper(string serialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber);
            string serialNumberResponse;
            string lastValue;
            int defaultSerialOffsetLength = RuntimeSettings.DefaultSerialNumberOffset.ToString().Length;
            string zeroLeadingString = new string('0', defaultSerialOffsetLength);
            int lastSerialNumbervalue = Int32.Parse(serialNumber.Substring(serialNumber.Length - defaultSerialOffsetLength));

            lastSerialNumbervalue = lastSerialNumbervalue + RuntimeSettings.DefaultSerialNumberOffset;
            lastValue = lastSerialNumbervalue.ToString(zeroLeadingString);
            serialNumberResponse = serialNumber.Remove(serialNumber.Length - defaultSerialOffsetLength, defaultSerialOffsetLength) + lastValue;

            return serialNumberResponse;
        }
    }
}
