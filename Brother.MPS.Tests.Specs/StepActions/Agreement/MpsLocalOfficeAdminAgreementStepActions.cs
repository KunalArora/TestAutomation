using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers.ExcelHelpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Agreement
{
    public class MpsLocalOfficeAdminAgreementStepActions: MpsLocalOfficeStepActions
    {
        private readonly IWebDriver _loAdminWebDriver;
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;

        public MpsLocalOfficeAdminAgreementStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            ITranslationService translationService,
            MpsSignInStepActions mpsSignIn,
            IUserResolver userResolver,
            ILoggingService loggingService,
            IRunCommandService runCommandService,
            IClickBillExcelHelper clickBillExcelHelper)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings, translationService, runCommandService, clickBillExcelHelper)
        {
            _loAdminWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeAdmin);
            _mpsSignIn = mpsSignIn;
            _urlResolver = urlResolver;
            _userResolver = userResolver;
        }

        public DataQueryPage NavigateToReportsDataQuery(LocalOfficeAdminDashBoardPage localOfficeAdminDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminDashBoardPage);
            ClickSafety(localOfficeAdminDashBoardPage.LOAdminReportElement, localOfficeAdminDashBoardPage);
            var reportingDashboardPage = PageService.GetPageObject<ReportingDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
            ClickSafety(reportingDashboardPage.DataQueryElement, reportingDashboardPage);
            return PageService.GetPageObject<DataQueryPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAgreementDevicesPage NavigateToAgreementDevicesPage(DataQueryPage dataQueryPage)
        {
            LoggingService.WriteLogOnMethodEntry(dataQueryPage);
            return NavigateToAgreementDevicesPage(dataQueryPage, _loAdminWebDriver);
        }

        public LocalOfficeAgreementDevicesPage VerifyUpdatedPrintCounts(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);
            return VerifyUpdatedPrintCounts(localOfficeAgreementDevicesPage, _loAdminWebDriver);
        }

        public LocalOfficeAgreementDevicesPage VerifyGenerationOfConsumableOrders(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);
            return VerifyGenerationOfConsumableOrders(localOfficeAgreementDevicesPage, _loAdminWebDriver);
        }

        public void EnableRaiseConsumableOrderOption()
        {
            LoggingService.WriteLogOnMethodEntry();

            var localOfficeAdminDashboardPage = _mpsSignIn.SignInAsLocalOfficeAdmin(
                _userResolver.LocalOfficeAdminUsername, _userResolver.LocalOfficeAdminPassword, string.Format("{0}/sign-in", _urlResolver.BaseUrl));

            ClickSafety(localOfficeAdminDashboardPage.LOAdminAdministrationLinkElement, localOfficeAdminDashboardPage);

            var localOfficeAdminAdminDashboardPage = PageService.GetPageObject<LocalOfficeAdminAdministrationDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);

            ClickSafety(localOfficeAdminAdminDashboardPage.SystemSettingsElement, localOfficeAdminAdminDashboardPage);

            var localOfficeAdminSystemSettingsGeneralSettingsPage = PageService.GetPageObject<LocalOfficeAdminSystemSettingsGeneralSettingsPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);

            localOfficeAdminSystemSettingsGeneralSettingsPage.EnableConsumableOrderManualOrdering();
        }

        public LocalOfficeAgreementBillingPage VerifyClickRateInvoice(LocalOfficeAgreementDevicesPage localOfficeAgreementDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementDevicesPage);
            return VerifyClickRateInvoice(localOfficeAgreementDevicesPage, _loAdminWebDriver);
        }
    }
}
