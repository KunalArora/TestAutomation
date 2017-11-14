using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
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
            RuntimeSettings runtimeSettings,
            MpsSignInStepActions mpsSignIn)
             : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _contextData = contextData;
            _dealerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Dealer);
        }

        public DealerCustomersExistingPage NavigateToCustomerContractPage(DealerDashBoardPage dealerDashboardPage)
        {
            dealerDashboardPage.ExistingCustomerLinkElement.Click();
            var nextPage = PageService.GetPageObject<DealerCustomersExistingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            return nextPage;
        }

        public DealerCustomersExistingPage ProceedCreateAndSaveANewCustomer(DealerCustomersManagePage dealerCustomersManagePage, out string customerName, out string eMailName, Country country, string payment = "Invoice")
        {
            dealerCustomersManagePage.FillCustomerDetails(payment, country.Name);
            customerName = dealerCustomersManagePage.GetCompanyName();
            eMailName = dealerCustomersManagePage.GetEmail();

            dealerCustomersManagePage.saveButtonElement.Click();
            var nextPage = PageService.GetPageObject<DealerCustomersExistingPage>(RuntimeSettings.DefaultPageObjectTimeout, _dealerWebDriver);

            return nextPage;
        }

        public void ThenICanSeeTheCustomerCreatedAboveInTheCustomersContactsList(DealerCustomersExistingPage _dealerCustomersExistingPage, string customerInformationName, string customerEmail)
        {
            bool exists = _dealerCustomersExistingPage.VerifyItemByName(customerInformationName, customerEmail, RuntimeSettings.DefaultFindElementTimeout);
            if (exists)
            {
                return;
            }
            else
            {
                new NullReferenceException(string.Format("Customer = {0} not found ", customerInformationName));
            }
        }
    }
}
