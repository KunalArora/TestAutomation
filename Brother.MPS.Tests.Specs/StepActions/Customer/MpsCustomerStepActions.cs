using Brother.Tests.Common.ContextData;
using Brother.Tests.Common.Domain.Constants;
using Brother.Tests.Common.Domain.Enums;
using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Common.Logging;
using Brother.Tests.Common.RuntimeSettings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.StepActions.Customer
{
    public class MpsCustomerStepActions : StepActionBase
    {
        private readonly MpsSignInStepActions _mpsSignIn;
        private readonly IContextData _contextData;
        private readonly IWebDriver _customerWebDriver;
        private readonly IMpsWebToolsService _webToolService;

        public MpsCustomerStepActions(IWebDriverFactory webDriverFactory,
            IContextData contextData,
            IPageService pageService,
            ScenarioContext context,
            IUrlResolver urlResolver,
            IRuntimeSettings runtimeSettings,
            IMpsWebToolsService webToolService,
            ILoggingService loggingService,
            MpsSignInStepActions mpsSignIn)
             : base(webDriverFactory, contextData, pageService, context, urlResolver, loggingService, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _contextData = contextData;
            _webToolService = webToolService;
            _customerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Customer);
        }

        public CustomerDashBoardPage SignInAsCustomerAndNavigateToDashboard(string url)
        {
            LoggingService.WriteLogOnMethodEntry(url);
            string email = _contextData.CustomerEmail;
            string password = _contextData.CustomerPassword;
            return _mpsSignIn.SignInAsCustomer(email, password, url);
        }

        public CustomerConsumablesDevicesPage ClickOnComsumablesTab(CustomerDashBoardPage customerDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(customerDashBoardPage);
            ClickSafety(customerDashBoardPage.CustomerConsumablesTabElement, customerDashBoardPage);
            return PageService.GetPageObject<CustomerConsumablesDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _customerWebDriver);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            LoggingService.WriteLogOnMethodEntry(element, pageObject);
            pageObject.SeleniumHelper.ClickSafety(element);
        }

        public void VerifyRaisedConsumableOrderStatus(CustomerConsumablesDevicesPage customerConsumablesDevicesPage)
        {
            LoggingService.WriteLogOnMethodEntry(customerConsumablesDevicesPage);
            var itemList = customerConsumablesDevicesPage.CreateElementValueList();
            var products = _contextData.PrintersProperties;
            foreach ( var product in products)
            {
                var pageItem = itemList.FirstOrDefault(d => d.CellSerialNo == product.SerialNumber);
                if (pageItem == null)
                {
                    throw new System.Exception("VerifyPrintersProperties: Item value record Not found SerialNumber=" + product.SerialNumber);
                }
                AssertNormalOrHasCount(product.TonerInkBlackStatus, pageItem.Cell_BW, "TonerInkBlackStatus", product);
                AssertNormalOrHasCount(product.TonerInkCyanStatus, pageItem.Cell_C, "TonerInkCyanStatus", product);
                AssertNormalOrHasCount(product.TonerInkMagentaStatus, pageItem.Cell_M, "TonerInkMagentaStatus", product);
                AssertNormalOrHasCount(product.TonerInkYellowStatus, pageItem.Cell_Y , "TonerInkYellowStatus", product);
            }

        }

        private void AssertNormalOrHasCount(string propTonerInkStatus, string pageCellValue, string messageTonerName, PrinterProperties propForMessage)
        {
            LoggingService.WriteLogOnMethodEntry(propTonerInkStatus, pageCellValue, messageTonerName, propForMessage);
            if (propTonerInkStatus != "Empty")
            {
                return;
            }
            int count = 0;
            if (int.TryParse(pageCellValue, out count) == false || count < 1 )
            {
                throw new Exception(string.Format("AssertNormalOrHasCount: {0} has wrong SerialNumber={1} Model={2} PageActual=[{3}]",
                    messageTonerName, propForMessage.SerialNumber, propForMessage.Model, pageCellValue ));
            }
        }

        public void VerifyHasRequestOnList(CustomerServiceRequestActivePage customerServiceRequestActivePage)
        {
            LoggingService.WriteLogOnMethodEntry(customerServiceRequestActivePage);
            var products = _contextData.PrintersProperties;

            // LaserUnit | FuserUnit | PaperFeedingKit1 | PaperFeedingKit2 | PaperFeedingKit3
            foreach ( var product in products)
            {
                var isUnitKitBroken = new string[] { product.LaserUnit, product.FuserUnit, product.PaperFeedingKit1, product.PaperFeedingKit2, product.PaperFeedingKit3 }.Any(d => d == "Empty");
                if(isUnitKitBroken == false)
                {
                    continue;
                }
                string filterText = string.Format("{0} {1}", product.SerialNumber, product.Model);
                customerServiceRequestActivePage.SeleniumHelper.SetListFilter(customerServiceRequestActivePage.FilterSearchFieldElement, filterText, customerServiceRequestActivePage.List_Row);
            }
        }

        public CustomerServiceRequestActivePage ClickOnServiceRequestsTab(CustomerDashBoardPage customerDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(customerDashBoardPage);
            ClickSafety(customerDashBoardPage.CustomerServiceRequestTabElement, customerDashBoardPage);
            return PageService.GetPageObject<CustomerServiceRequestActivePage>(RuntimeSettings.DefaultPageObjectTimeout, _customerWebDriver);
        }

        public CustomerDashBoardPage SelectLanguageGivenCulture(CustomerDashBoardPage customerDashBoardPage)
        {
            LoggingService.WriteLogOnMethodEntry(customerDashBoardPage);
            
            if (_contextData.Country.CountryIso.Equals(CountryIso.Switzerland))
            {
                _contextData.Language = customerDashBoardPage.ClickLanguageLink(_contextData.Culture);
                customerDashBoardPage = PageService.GetPageObject<CustomerDashBoardPage>(RuntimeSettings.DefaultPageObjectTimeout, _customerWebDriver);
            }

            return customerDashBoardPage; 
        }
    }
}
