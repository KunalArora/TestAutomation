using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Helpers.ExcelHelpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Finance
{
    public class MpsFinanceStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IWebDriver _financeWebDriver;
        private readonly ITranslationService _translationService;
        private readonly IContextData _contextData;
        private readonly ICalculationService _calculationService;
        private readonly IRunCommandService _runCommandService;
        private readonly IPageParseHelper _pageParseHelper;
        private readonly IUserResolver _userResolver;
        private readonly IAccrualsDetailExcelHelper _accrualsDetailExcelHelper;

        public MpsFinanceStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            ITranslationService translationService,
            IRuntimeSettings runtimeSettings,
            MpsSignInStepActions mpsSignIn,
            IDevicesExcelHelper devicesExcelHelper,
            IAccrualsDetailExcelHelper accrualsDetailExcelHelper,
            IServiceInstallationBillExcelHelper serviceInstallationBillExcelHelper,
            ICalculationService calculationService,
            ILoggingService loggingService,
            IRunCommandService runCommandService,
            IPageParseHelper pageParseHelper,
            IUserResolver userResolver)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _financeWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeFinance);//$$
            _translationService = translationService;
            _contextData = contextData;
            _calculationService = calculationService;
            _runCommandService = runCommandService;
            _pageParseHelper = pageParseHelper;
            _userResolver = userResolver;
            _accrualsDetailExcelHelper = accrualsDetailExcelHelper;
        }

        public LocalOfficeFinanceAccrualsReportPage NavigateToAccrualsPage(LocalOfficeFinanceDashBoardPage localOfficeFinanceDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeFinanceDashBoardPage);
            localOfficeFinanceDashBoardPage.SeleniumHelper.ClickSafety(localOfficeFinanceDashBoardPage.AccrualsElement, IsUntilUrlChanges: true);
            return PageService.GetPageObject<LocalOfficeFinanceAccrualsReportPage>(RuntimeSettings.DefaultPageLoadTimeout, _financeWebDriver);            
        }

        public string ClickOnRunReport(LocalOfficeFinanceAccrualsReportPage localOfficeFinanceAccrualsReportPage, DateTime dateTime)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeFinanceAccrualsReportPage, dateTime);
            localOfficeFinanceAccrualsReportPage.EnterRunAtDate(dateTime);
            var zipFilePath = LoggingService.WriteLogWhenWarningTimeoutExceeds(d => _accrualsDetailExcelHelper.Download(() =>
                {
                    localOfficeFinanceAccrualsReportPage.ClickOnRunReport();
                    return true;
                },
               downloadTimeout: RuntimeSettings.DefaultDownloadTimeout * 10, // very long time, about 3 minute.
               filter: "*.zip"
               ), RuntimeSettings.DefaultDownloadTimeout * 5, "ClickOnRunReport() Too Long. ");
            LoggingService.WriteLog(LoggingLevel.DEBUG, "RunReport={0}", zipFilePath);
            return zipFilePath;
        }

        public void DeleteFile(string zipFilePath)
        {
            LoggingService.WriteLogOnMethodEntry(zipFilePath);
            _accrualsDetailExcelHelper.DeleteExcelFile(zipFilePath);
        }

        public LocalOfficeFinanceDashBoardPage NavigateToDashBoardPage(LocalOfficeFinanceAccrualsReportPage localOfficeFinanceAccrualsReportPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeFinanceAccrualsReportPage);
            localOfficeFinanceAccrualsReportPage.ClickOnFinanceTab();
            return PageService.GetPageObject<LocalOfficeFinanceDashBoardPage>(RuntimeSettings.DefaultPageLoadTimeout, _financeWebDriver);
        }
    }
}
