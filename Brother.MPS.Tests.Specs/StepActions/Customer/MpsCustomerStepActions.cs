using Brother.Tests.Specs.Configuration;
using Brother.Tests.Specs.ContextData;
using Brother.Tests.Specs.Domain.Enums;
using Brother.Tests.Specs.Domain.SpecFlowTableMappings;
using Brother.Tests.Specs.Factories;
using Brother.Tests.Specs.Resolvers;
using Brother.Tests.Specs.Services;
using Brother.Tests.Specs.StepActions.Common;
using Brother.WebSites.Core.Pages;
using Brother.WebSites.Core.Pages.MPSTwo;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
            MpsSignInStepActions mpsSignIn)
             : base(webDriverFactory, contextData, pageService, context, urlResolver, runtimeSettings)
        {
            _mpsSignIn = mpsSignIn;
            _contextData = contextData;
            _webToolService = webToolService;
            _customerWebDriver = WebDriverFactory.GetWebDriverInstance(UserType.Customer);
        }

        public CustomerDashBoardPage SignInAsCustomerAndNavigateToDashboard(string email, string password, string url)
        {
            return _mpsSignIn.SignInAsCustomer(email, password, url);
        }

        public CustomerConsumablesDevicesPage ClickOnComsumablesTab(CustomerDashBoardPage customerDashBoardPage)
        {
            ClickSafety(customerDashBoardPage.CustomerConsumablesTabElement, customerDashBoardPage);
            return PageService.GetPageObject<CustomerConsumablesDevicesPage>(RuntimeSettings.DefaultPageObjectTimeout, _customerWebDriver);
        }

        private void ClickSafety(IWebElement element, IPageObject pageObject)
        {
            pageObject.SeleniumHelper.ClickSafety(element, RuntimeSettings.DefaultFindElementTimeout);
        }

        public void VerifyRaisedConsumableOrderStatus(CustomerConsumablesDevicesPage customerConsumablesDevicesPage, IEnumerable<PrinterProperties> printersProperties)
        {
            var itemdic = customerConsumablesDevicesPage.CreateElementValueDictionary<CustomerConsumablesDeviceItem>();
            var contlastIdList = customerConsumablesDevicesPage.ContractReferenceElement.CollectDigitOnly().OrderBy(x => x).ToArray();
            foreach( var item in itemdic)
            {
                var contractIndex = int.Parse(item.Key[1]);
                item.Value.ContractId = contlastIdList[contractIndex];
            }
            var itemList = itemdic.Values.ToArray();
            foreach( var prop in printersProperties)
            {
                var pageItem = itemList.FirstOrDefault(d => d.CellSerialNo == prop.SerialNumber);
                if (pageItem == null)
                {
                    throw new System.Exception("VerifyPrintersProperties: Item value record Not found S/N=" + prop.SerialNumber);
                }
                AssertNormalOrHasCount(prop.TonerInkBlackStatus, pageItem.Cell_BW, "TonerInkBlackStatus", prop);
                AssertNormalOrHasCount(prop.TonerInkCyanStatus, pageItem.Cell_C, "TonerInkCyanStatus", prop);
                AssertNormalOrHasCount(prop.TonerInkMagentaStatus, pageItem.Cell_M, "TonerInkMagentaStatus", prop);
                AssertNormalOrHasCount(prop.TonerInkYellowStatus, pageItem.Cell_Y , "TonerInkYellowStatus", prop);
            }

        }

        private void AssertNormalOrHasCount(string propTonerInkStatus, string pageCellValue, string messageTonerName, PrinterProperties propForMessage)
        {
            if (propTonerInkStatus != "Empty")
            {
                return;
            }
            int count = 0;
            if (int.TryParse(pageCellValue, out count) == false || count < 1 )
            {
                throw new Exception(string.Format("AssertNormalOrHasCount: {0} has wrong S/N={1} Model={2} PageActual=[{3}]",
                    messageTonerName, propForMessage.SerialNumber, propForMessage.Model, pageCellValue ));
            }
        }

        public void VerifyHasRequestOnList(CustomerServiceRequestActivePage customerServiceRequestActivePage, IEnumerable<PrinterProperties> printersProperties)
        {
            // LaserUnit | FuserUnit | PaperFeedingKit1 | PaperFeedingKit2 | PaperFeedingKit3
            foreach ( var prop in printersProperties)
            {
                var isUnitKitBroken = new string[] { prop.LaserUnit, prop.FuserUnit, prop.PaperFeedingKit1, prop.PaperFeedingKit2, prop.PaperFeedingKit3 }.Any(d => d == "Empty");
                if(isUnitKitBroken == false)
                {
                    continue;
                }
                string filterText = string.Format("{0} {1}", prop.SerialNumber, prop.Model);
                customerServiceRequestActivePage.ClearAndType(customerServiceRequestActivePage.FilterSearchFieldElement, filterText);
                customerServiceRequestActivePage.SeleniumHelper.WaitUntil(d => customerServiceRequestActivePage.List_Row.Count == 1, RuntimeSettings.DefaultFindElementTimeout);
            }
        }

        public CustomerServiceRequestActivePage ClickOnServiceRequestsTab(CustomerDashBoardPage customerDashBoardPage)
        {
            ClickSafety(customerDashBoardPage.CustomerServiceRequestTabElement, customerDashBoardPage);
            return PageService.GetPageObject<CustomerServiceRequestActivePage>(RuntimeSettings.DefaultPageObjectTimeout, _customerWebDriver);
        }
    }
}
