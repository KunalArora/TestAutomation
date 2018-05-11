using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
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

        public MpsDealerDealershipStepActions(
            IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService)
            : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _contextData = contextData;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
            _loggingService = loggingService;
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
            string subDealerEmail = dealerAdminDealershipUsersCreationPage.EnterSubDealerDetails();

            _contextData.SubDealerEmail = subDealerEmail;

            dealerAdminDealershipUsersCreationPage.ClickOnCreate();
            return PageService.GetPageObject<DealerAdminDealershipUsersPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);
        }

        public void VerifySubDealer(DealerAdminDealershipUsersPage dealerAdminDealershipUsersPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerAdminDealershipUsersPage);
            dealerAdminDealershipUsersPage.VerifySubDealer(_contextData.SubDealerEmail);
        }
    }
}
