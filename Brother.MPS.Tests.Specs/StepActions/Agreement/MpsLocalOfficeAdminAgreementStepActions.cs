using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Helpers;
using Brother.Tests.Specs.Helpers.ExcelHelpers;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages.MPSTwo;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice;
using OpenQA.Selenium;
using System.Globalization;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Agreement
{
    public class MpsLocalOfficeAdminAgreementStepActions: MpsLocalOfficeStepActions
    {
        private readonly IWebDriver _loAdminWebDriver;
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IUserResolver _userResolver;
        private readonly IUrlResolver _urlResolver;
        private readonly ICPPAgreementExcelHelper _cppAgreementHelper;
        private readonly IContextData _contextData;
        private IMpsWebToolsService _mpsWebToolsService;

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
            IDevicesExcelHelper devicesExcelHelper,
            IClickBillExcelHelper clickBillExcelHelper,
            IServiceInstallationBillExcelHelper serviceInstallationBillExcelHelper,
            ICPPAgreementExcelHelper cppAgreementHelper,
            ICalculationService calculationService,
            IMpsWebToolsService mpsWebToolsService)
            : base(
            webDriverFactory, 
            contextData, 
            pageService, 
            context, 
            urlResolver, 
            loggingService, 
            runtimeSettings, 
            translationService, 
            runCommandService, 
            devicesExcelHelper, 
            clickBillExcelHelper, 
            serviceInstallationBillExcelHelper, 
            userResolver,
            calculationService)
        {
            _loAdminWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.LocalOfficeAdmin);
            _mpsSignIn = mpsSignIn;
            _urlResolver = urlResolver;
            _userResolver = userResolver;
            _cppAgreementHelper = cppAgreementHelper;
            _contextData = contextData;
            _mpsWebToolsService = mpsWebToolsService;
        }

        public DataQueryPage NavigateToReportsDataQuery(LocalOfficeAdminDashBoardPage localOfficeAdminDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminDashBoardPage);
            ClickSafety(localOfficeAdminDashBoardPage.LOAdminReportElement, localOfficeAdminDashBoardPage);
            var reportingDashboardPage = PageService.GetPageObject<LocalOfficeReportsDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
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

        public LocalOfficeAgreementBillingPage VerifyServiceInstallationInvoice(LocalOfficeAgreementBillingPage localOfficeAgreementBillingPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAgreementBillingPage);
            return VerifyServiceInstallationInvoice(localOfficeAgreementBillingPage, _loAdminWebDriver);
        }

        public void DownloadAndVerifyCPPAgreementReport(LocalOfficeAdminDashBoardPage localOfficeAdminDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminDashboardPage);
            ClickSafety(localOfficeAdminDashboardPage.LOAdminReportElement, localOfficeAdminDashboardPage);
            var reportingDashboardPage = PageService.GetPageObject<LocalOfficeReportsDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);

            // Download excel
            string excelFilePath = _cppAgreementHelper.Download(() =>
            {
                ClickSafety(reportingDashboardPage.CppAgreementReportElement, reportingDashboardPage);
                return true;
            });

            // Verify agreement details
            _cppAgreementHelper.VerifyAgreementDetails(excelFilePath);

            // Delete excel
            _cppAgreementHelper.DeleteExcelFile(excelFilePath);            
        }

        public LocalOfficeAdminDashBoardPage SelectLanguageGivenCulture(LocalOfficeAdminDashBoardPage localOfficeAdminDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminDashboardPage);

            if (_contextData.Country.CountryIso.Equals(CountryIso.Switzerland))
            {
                _contextData.Language = localOfficeAdminDashboardPage.ClickLanguageLink();
                localOfficeAdminDashboardPage = PageService.GetPageObject<LocalOfficeAdminDashBoardPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
            }

            return localOfficeAdminDashboardPage; 
        }

        public void SetCultureInfoAndRegionInfo()
        {
            LoggingService.WriteLogOnMethodEntry();

            _contextData.CultureInfo = new CultureInfo(_contextData.Culture);
            _contextData.RegionInfo = new RegionInfo(_contextData.Culture);

            switch (_contextData.Country.CountryIso)
            {
                case CountryIso.Switzerland:
                    // This is done as currency symbol for Switzerland set in culture settings of Windows 7 & Windows 10 are different
                    _contextData.CultureInfo.NumberFormat.CurrencySymbol = MpsUtil.GetCurrencySymbol(_contextData.Country.CountryIso);

                    // This is done as decimal separator for Switzerland set in culture settings of Windows 7 & Windows 10 are different
                    _contextData.CultureInfo.NumberFormat.NumberDecimalSeparator = ".";

                    break;
                default:
                    break;
            }
        }

        public LocalOfficeAdminAdministrationDashboardPage NavigateToAdministrationPage(LocalOfficeAdminDashBoardPage localOfficeAdminDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminDashboardPage);
            localOfficeAdminDashboardPage.SeleniumHelper.ClickSafety(localOfficeAdminDashboardPage.LOAdminAdministrationLinkElement);
            return PageService.GetPageObject<LocalOfficeAdminAdministrationDashboardPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAdminAdministrationDealerPage NavigateToAdministrationDealerPage(LocalOfficeAdminAdministrationDashboardPage localOfficeAdminAdministrationDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminAdministrationDashboardPage);
            localOfficeAdminAdministrationDashboardPage.SeleniumHelper.ClickSafety(localOfficeAdminAdministrationDashboardPage.LOAdminDealerLinkElement);
            return PageService.GetPageObject<LocalOfficeAdminAdministrationDealerPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public LocalOfficeAdminDealersCreateDealershipPage ClickOnAddDealerButton(LocalOfficeAdminAdministrationDealerPage localOfficeAdminAdministrationDealerPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminAdministrationDealerPage);
            localOfficeAdminAdministrationDealerPage.SeleniumHelper.ClickSafety(localOfficeAdminAdministrationDealerPage.CreateDealerButtonElement);
            return PageService.GetPageObject<LocalOfficeAdminDealersCreateDealershipPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public void SelectBusinessType(LocalOfficeAdminDealersCreateDealershipPage localOfficeAdminDealersCreateDealershipPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminDealersCreateDealershipPage);
            localOfficeAdminDealersCreateDealershipPage.InputBusinessTypeDetails();
        }

        public LocalOfficeAdminAdministrationDealerPage IputDealerDetails(LocalOfficeAdminDealersCreateDealershipPage localOfficeAdminDealersCreateDealershipPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminDealersCreateDealershipPage);
            localOfficeAdminDealersCreateDealershipPage.InputDealerDetails();

            _contextData.CreatedDealerEmail = localOfficeAdminDealersCreateDealershipPage.GetEmail();
            _contextData.CreatedDealerFirstName = localOfficeAdminDealersCreateDealershipPage.GetFirstName();
            _contextData.CreatedDealerLastName = localOfficeAdminDealersCreateDealershipPage.GetLastName();

            _mpsWebToolsService.RegisterCustomer(_contextData.CreatedDealerEmail, _contextData.CreatedDealerPassword, _contextData.CreatedDealerFirstName, _contextData.CreatedDealerLastName, _contextData.Country.CountryIso);
            _mpsWebToolsService.RegisterRole(_contextData.CreatedDealerEmail, MpsRoles.Dealer);
            localOfficeAdminDealersCreateDealershipPage.SeleniumHelper.ClickSafety(localOfficeAdminDealersCreateDealershipPage.SaveButtonElement);
            return PageService.GetPageObject<LocalOfficeAdminAdministrationDealerPage>(RuntimeSettings.DefaultPageObjectTimeout, _loAdminWebDriver);
        }

        public void VerifyDealerCreation(LocalOfficeAdminAdministrationDealerPage localOfficeAdminAdministrationDealerPage)
        {
            LoggingService.WriteLogOnMethodEntry(localOfficeAdminAdministrationDealerPage);
            localOfficeAdminAdministrationDealerPage.VerifyDealerCreation();
        }
    }
}
