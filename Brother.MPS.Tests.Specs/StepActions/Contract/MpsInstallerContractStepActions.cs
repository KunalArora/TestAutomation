using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
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
            var installerWindowHandle = _contextData.WindowHandles[UserType.Installer];

            foreach(var product in products)
            {
                int retries = 0;
                int serialEnterRetry = 0;
                string serialNumber;
                string lastValue;
                int last2SerialNumbervalue = Int32.Parse(product.SerialNumber.Substring(product.SerialNumber.Length - 2));
                last2SerialNumbervalue = last2SerialNumbervalue + RuntimeSettings.DefaultSerialNumberOffset;
                if (last2SerialNumbervalue < 9)
                {
                    lastValue = '0' + last2SerialNumbervalue.ToString();
                }
                else
                {
                    lastValue = last2SerialNumbervalue.ToString();
                }
                serialNumber = product.SerialNumber.Remove(product.SerialNumber.Length - 2, 2) + lastValue;               
                product.SerialNumber = serialNumber;
                RegisterDeviceOnBOC(product, installationPin, product.SerialNumber);
                _installerDeviceInstallationPage.TryClosePopup();
                _installerDeviceInstallationPage.EnterSerialNumber(product.Model, serialNumber, installerWindowHandle, installerDriver);
                while(!(_installerDeviceInstallationPage.RetryResetClickingHelper(product.Model, product.SerialNumber, installerWindowHandle, installerDriver, serialEnterRetry)))
                {
//                    _installerWebDriver.Navigate().Refresh();
                    _installerDeviceInstallationPage.ClickOnRefreshButton();
                    _installerWebDriver.Navigate().Refresh();
                    _installerDeviceInstallationPage = PageService.GetPageObject<InstallerDeviceInstallationPage>(RuntimeSettings.DefaultPageLoadTimeout, _installerWebDriver);

                    serialEnterRetry = serialEnterRetry + 1;

                    retries++;
                    if (retries > RuntimeSettings.DefaultRetryCount)
                    {
                        throw new Exception("Error while installing the device=" + product.SerialNumber + "Retry count exceeded the default value" + retries);
                    }
                    continue;
                }
            }
//            _installerDeviceInstallationPage.CloudInstallationRefresh();
            _installerDeviceInstallationPage.SeleniumHelper.ClickSafety(_installerDeviceInstallationPage.CompleteCloudInstallationComfirmationElement);
            _installerDeviceInstallationPage.ConfirmInstallationComplete();
        }

        public void PopulateSwapSerialNumber(InstallerDeviceInstallationPage _installerDeviceInstallationPage, IWebDriver installerDriver, string swapNewDeviceSerialNumber)
        {
            LoggingService.WriteLogOnMethodEntry(_installerDeviceInstallationPage, installerDriver, swapNewDeviceSerialNumber);
            var swapOldDeviceSerialNumber = _contextData.SwapOldDeviceSerialNumber;
            var installationPin = _installerDeviceInstallationPage.RetrieveInstallationPin();
            var installerWindowHandle = _contextData.WindowHandles[UserType.Installer];
            var products = _contextData.PrintersProperties;

            foreach(var product in products)
            {
                if(product.SerialNumber.Equals(swapOldDeviceSerialNumber))
                {
                    string serialNumber;
                    string lastValue;
                    int last2SerialNumbervalue = Int32.Parse(product.SerialNumber.Substring(swapNewDeviceSerialNumber.Length - 2));
                    last2SerialNumbervalue = last2SerialNumbervalue + RuntimeSettings.DefaultSerialNumberOffset;
                    if (last2SerialNumbervalue < 9)
                    {
                        lastValue = '0' + last2SerialNumbervalue.ToString();
                    }
                    else
                    {
                        lastValue = last2SerialNumbervalue.ToString();
                    }
                    serialNumber = swapNewDeviceSerialNumber.Remove(swapNewDeviceSerialNumber.Length - 2, 2) + lastValue;
                    _contextData.SwapNewDeviceSerialNumber = serialNumber;
                    RegisterDeviceOnBOC(product, installationPin, serialNumber);
                    _installerDeviceInstallationPage.EnterSerialNumber(product.Model, serialNumber, installerWindowHandle, installerDriver);
                }
            }
        }

        public void CloudInstallationRefresh(InstallerDeviceInstallationPage installerDeviceInstallationPage)
        {
            LoggingService.WriteLogOnMethodEntry(installerDeviceInstallationPage);
            installerDeviceInstallationPage.CloudInstallationRefresh();
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
            _installerDeviceInstallationPage.CompleteCloudInstallationComfirmationElement.Click();
            _installerDeviceInstallationPage.ConfirmInstallationComplete();
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

    }
}
