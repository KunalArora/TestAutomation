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

namespace Brother.Tests.Specs.StepActions.Customer
{
    public class MpsDealerCustomerStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IContextData _contextData;
        private readonly IWebDriver _dealerWebDriver;

        public MpsDealerCustomerStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            ILoggingService loggingService,
            MpsSignInStepActions mpsSignIn)
             : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _contextData = contextData;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
        }

        public DealerCustomersExistingPage NavigateToCustomerContractPage(DealerDashBoardPage dealerDashboardPage)
        {
            LoggingService.WriteLogOnMethodEntry(dealerDashboardPage);
            dealerDashboardPage.ExistingCustomerLinkElement.Click();
            var nextPage = PageService.GetPageObject<DealerCustomersExistingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            return nextPage;
        }

        public DealerCustomersExistingPage ProceedCreateAndSaveANewCustomer(DealerCustomersManagePage dealerCustomersManagePage, out string customerName, out string eMailName, Country country, string payment = "Invoice")
        {
            LoggingService.WriteLogOnMethodEntry(dealerCustomersManagePage, country, payment);
            dealerCustomersManagePage.FillCustomerDetails(payment, country.Name);
            customerName = dealerCustomersManagePage.GetCompanyName();
            eMailName = dealerCustomersManagePage.GetEmail();

            dealerCustomersManagePage.saveButtonElement.Click();
            var nextPage = PageService.GetPageObject<DealerCustomersExistingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            return nextPage;
        }

        public void ThenICanSeeTheCustomerCreatedAboveInTheCustomersContactsList(DealerCustomersExistingPage _dealerCustomersExistingPage, string customerInformationName, string customerEmail)
        {
            LoggingService.WriteLogOnMethodEntry(_dealerCustomersExistingPage, customerInformationName, customerEmail);
            bool exists = _dealerCustomersExistingPage.VerifyItemByName(customerInformationName, customerEmail);
            if (exists)
            {
                return;
            }
            else
            {
                new Exception(string.Format("Customer = {0} not found ", customerInformationName));
            }
        }
    }
}
