using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Common
{
    public class MpsLocalOfficeStepActions: StepActionBase
    {
        private readonly IContextData _contextData;

        public MpsLocalOfficeStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _contextData = contextData;
        }
      
        public LocalOfficeAgreementDevicesPage NavigateToAgreementDevicesPage(DataQueryPage dataQueryPage, IWebDriver webDriver)
        {
            dataQueryPage.FilterAndClickAgreement(_contextData.AgreementId, RuntimeSettings.DefaultFindElementTimeout);
            var localOfficeAgreementSummaryPage = PageService.GetPageObject<LocalOfficeAgreementSummaryPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
            ClickSafety(localOfficeAgreementSummaryPage.DevicesTabElement(
                _contextData.AgreementId, RuntimeSettings.DefaultFindElementTimeout), localOfficeAgreementSummaryPage);
            return PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
        }

        public LocalOfficeAgreementDevicesPage SendBulkInstallationRequest(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, IWebDriver webDriver)
        {
            var deviceRowCount = localOfficeAgreementDevicesPage.DeviceTableRowsCount();
            int devicesInstallingCount = 0;

            // Tick checkboxes of devices which are to be installed according to feature file configuration
            for (int rowIndex = 0; rowIndex < deviceRowCount; rowIndex++)
            {
                string displayedModelName = localOfficeAgreementDevicesPage.DeviceModelName(rowIndex, RuntimeSettings.DefaultFindElementTimeout);
                foreach (var product in _contextData.PrintersProperties)
                {
                    if (displayedModelName.Equals(product.Model) && product.SendInstallationRequest.ToLower().Equals("yes"))
                    {
                        localOfficeAgreementDevicesPage.ClickOnDeviceCheckbox(rowIndex, RuntimeSettings.DefaultFindElementTimeout);
                        devicesInstallingCount++;
                        break;
                    }
                }
            }

            switch (devicesInstallingCount)
            {
                case 0: // No devices will be installed
                    break;

                case 1: // Only 1 device will be installed, hence, cannot click bulk Send Installation Request button
                    localOfficeAgreementDevicesPage = SendSingleInstallationRequests(
                        localOfficeAgreementDevicesPage, webDriver);
                    break;

                default: // For Bulk installation request
                    // Click Send Installation Request button (used for bulk)
                    ClickSafety(localOfficeAgreementDevicesPage.SendInstallationRequestElement, localOfficeAgreementDevicesPage);
                    localOfficeAgreementDevicesPage.SendInstallationRequest(RuntimeSettings.DefaultFindElementTimeout);
                    break;
            }

            return localOfficeAgreementDevicesPage;
        }

        public LocalOfficeAgreementDevicesPage SendSingleInstallationRequests(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, IWebDriver webDriver)
        {
            var deviceRowCount = localOfficeAgreementDevicesPage.DeviceTableRowsCount();

            // Tick checkboxes of devices which are to be installed according to feature file configuration
            for (int rowIndex = 0; rowIndex < deviceRowCount; rowIndex++)
            {
                string displayedModelName = localOfficeAgreementDevicesPage.DeviceModelName(rowIndex, RuntimeSettings.DefaultFindElementTimeout);
                foreach (var product in _contextData.PrintersProperties)
                {
                    if (displayedModelName.Equals(product.Model) && product.SendInstallationRequest.ToLower().Equals("yes"))
                    {
                        // Click Send Installation Request button in Actions dropdown
                        localOfficeAgreementDevicesPage.ClickSendInstallationRequestInActions(rowIndex, RuntimeSettings.DefaultFindElementTimeout);
                        
                        // Handle Send Installation Request modal
                        localOfficeAgreementDevicesPage.SendInstallationRequest(RuntimeSettings.DefaultFindElementTimeout);
                        break;
                    }
                }

                if (rowIndex != (deviceRowCount - 1))
                {
                    // Note: This refresh is done due to the introduction of stale elements in Send Installation Request modal after every successful send
                    // Note: Don't refresh if its the last device in the table
                    webDriver.Navigate().Refresh();
                    localOfficeAgreementDevicesPage = PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, webDriver);
                }
            }

            return localOfficeAgreementDevicesPage;
        }

        public void EnableInstallationOption(
            LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, string installationType, string communicationMethod)
        {
            // Click Customise button element
            ClickSafety(localOfficeAgreementDevicesPage.CustomiseButtonElement, localOfficeAgreementDevicesPage);

            // Enable installation option
            localOfficeAgreementDevicesPage.EnableInstallationOption(
                communicationMethod, installationType, RuntimeSettings.DefaultFindElementTimeout);

            // Click Save Button
            ClickSafety(localOfficeAgreementDevicesPage.InstallationOptionSaveButtonElement, localOfficeAgreementDevicesPage);
        }

        public LocalOfficeAgreementDevicesPage VerifyUpdatedPrintCounts(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage, IWebDriver webDriver)
        {
            // Refresh page until print counts are updated
            int retries = 0;
            while (!localOfficeAgreementDevicesPage.IsPrintCountsUpdated(RuntimeSettings.DefaultFindElementTimeout))
            {
                webDriver.Navigate().Refresh();
                localOfficeAgreementDevicesPage = PageService.GetPageObject<LocalOfficeAgreementDevicesPage>(
                    RuntimeSettings.DefaultPageObjectTimeout, webDriver);

                retries++;
                if (retries > RuntimeSettings.DefaultRetryCount)
                {
                    throw new Exception(
                        string.Format("Number of retries exceeded the default limit during verification of print counts for agreement {0}", _contextData.AgreementId));
                }
            }

            // Verify print count values for all devices one by one
            foreach (var device in _contextData.AdditionalDeviceProperties)
            {
                localOfficeAgreementDevicesPage.VerifyPrintCountsOfDevice(
                    device.MpsDeviceId, device.ColorPrintCount, device.MonoPrintCount, device.TotalPrintCount, RuntimeSettings.DefaultFindElementTimeout);
            }

            return localOfficeAgreementDevicesPage;
        }

        public void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }
    }
}
