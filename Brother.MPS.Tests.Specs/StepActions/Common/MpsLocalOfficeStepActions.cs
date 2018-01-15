using Brother.Tests.Specs.Configuration;
using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Brother.Tests.Common.RuntimeSettings;

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
                    if (displayedModelName.Equals(product.Model) && product.Installation.ToLower().Equals("yes"))
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
                    if (displayedModelName.Equals(product.Model) && product.Installation.ToLower().Equals("yes"))
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

        public void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }
    }
}
