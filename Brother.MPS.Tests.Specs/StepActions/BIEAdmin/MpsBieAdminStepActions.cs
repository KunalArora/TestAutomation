﻿using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.BIEAdmin
{
    public class MpsBieAdminStepActions : StepActionBase
    {
        private readonly IContextData _contextData;
        private readonly IWebDriver _bieAdminWebDriver;

        public MpsBieAdminStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _contextData = contextData;
            _bieAdminWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.BIEAdmin);
        }

        public BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage NavigateToEnhancedUsageMonitoringNewInstalledPrinterPage(BieAdminDashboardPage bieAdminDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(bieAdminDashboardPage);

            ClickSafety(bieAdminDashboardPage.ManageDeviceOrderThresholdLink, bieAdminDashboardPage, IsUntilUrlChanges: true);
            return PageService.GetPageObject<BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage>(RuntimeSettings.DefaultPageObjectTimeout, _bieAdminWebDriver);
        }

        public BieAdminEnhancedUsageMonitoringNewPrinterEnginePage NavigateToEnhancedUsageMonitoringNewPrinterEnginePage(BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage bieAdminEnhancedUsageMonitoringNewInstalledPrinterPage)
        {
            LoggingService.WriteLogOnMethodEntry(bieAdminEnhancedUsageMonitoringNewInstalledPrinterPage);

            ClickSafety(bieAdminEnhancedUsageMonitoringNewInstalledPrinterPage.PrinterEngineTabElement, bieAdminEnhancedUsageMonitoringNewInstalledPrinterPage, IsUntilUrlChanges: true);
            return PageService.GetPageObject<BieAdminEnhancedUsageMonitoringNewPrinterEnginePage>(RuntimeSettings.DefaultPageObjectTimeout, _bieAdminWebDriver);
        }
    }
}
