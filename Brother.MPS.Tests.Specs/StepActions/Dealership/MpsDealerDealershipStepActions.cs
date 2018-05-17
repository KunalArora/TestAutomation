using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Common.Services;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Dealership
{
    [Binding]
    public class MpsDealerDealershipStepActions : StepActionBase
    {

        private readonly ILoggingService _loggingService;
        private readonly IContextData _contextData;
        private readonly IUrlResolver _urlResolver;
        private readonly IWebDriver _dealerWebDriver;
        private readonly IMpsWebToolsService _webToolService;
        private readonly IRunCommandService _runCommandService;
        private readonly ITranslationService _translationService;

        public MpsDealerDealershipStepActions(
            IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService,
            IMpsWebToolsService webToolService,
            IRunCommandService runCommandService,
            ITranslationService translationService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _contextData = contextData;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _loggingService = loggingService;
            _webToolService = webToolService;
            _runCommandService = runCommandService;
            _translationService = translationService;
        }

        public DealerAdminDashBoardPage NavigateToDealerAdminDashboardPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            dealerDashboardPage.NavigateToDealerAdminDashboardPage();

            return PageService.GetPageObject<DealerAdminDashBoardPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAdminDealershipUsersPage NavigateToDealershipUsersPage(DealerAdminDashBoardPage dealerAdminDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDashBoardPage);
            dealerAdminDashBoardPage.NavigateToDealershipUsersPage();

            return PageService.GetPageObject<DealerAdminDealershipUsersPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAdminDealershipUsersCreationPage ClickOnAddStaffMember(DealerAdminDealershipUsersPage dealerAdminDealershipUsersPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDealershipUsersPage);
            dealerAdminDealershipUsersPage.ClickOnAddButton();

            return PageService.GetPageObject<DealerAdminDealershipUsersCreationPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public DealerAdminDealershipUsersPage EnterSubDealerDetailsAndSave(DealerAdminDealershipUsersCreationPage dealerAdminDealershipUsersCreationPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDealershipUsersCreationPage);
            dealerAdminDealershipUsersCreationPage.EnterSubDealerDetails();

            _contextData.SubDealerEmail = dealerAdminDealershipUsersCreationPage.GetEmail();
            _contextData.SubDealerFirstName = dealerAdminDealershipUsersCreationPage.GetFirstName();
            _contextData.SubDealerLastName = dealerAdminDealershipUsersCreationPage.GetLastName();

            _webToolService.RegisterCustomer(_contextData.SubDealerEmail, _contextData.SubDealerPassword, _contextData.SubDealerFirstName, _contextData.SubDealerLastName, _contextData.Country.CountryIso);

            dealerAdminDealershipUsersCreationPage.ClickOnCreate();
            return PageService.GetPageObject<DealerAdminDealershipUsersPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifySubDealer(DealerAdminDealershipUsersPage dealerAdminDealershipUsersPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDealershipUsersPage);

            var resourceStaffAccessPermissionRestricted = _translationService.GetStaffAccessPermission(TranslationKeys.StaffAccessPermission.Restricted, _contextData.Culture);
            dealerAdminDealershipUsersPage.VerifySubDealer(_contextData.SubDealerEmail, resourceStaffAccessPermissionRestricted);
        }
    }
}
