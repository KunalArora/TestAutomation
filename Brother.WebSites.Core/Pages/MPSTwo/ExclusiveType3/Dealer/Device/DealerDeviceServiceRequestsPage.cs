using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Device
{
    public class DealerDeviceServiceRequestsPage : BasePage, IPageObject
    {
        private string _validationElementSelector = "#DataTables_Table_0_paginate";
        private const string _url = "/mps/dealer/device/{reportingId}/service-requests";

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        // TABs
        [FindsBy(How = How.CssSelector, Using = "a[href$='/overview']")] // ex. /mps/dealer/agreement/173259/overview
        public IWebElement OverviewTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/print-detail']")]
        public IWebElement PrintDetailTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/consumable-orders']")]
        public IWebElement ConsumableOrdersTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/silent']")]
        public IWebElement SilentTabElement;

        private const string ServiceRequestsTableBodySelector = ".mps-row-select";

        public void VerifyServiceRequets(AdditionalDeviceProperties device)
        {
            LoggingService.WriteLogOnMethodEntry(device);

            var serviceRequestsTableBodyElement = SeleniumHelper.FindElementByCssSelector(ServiceRequestsTableBodySelector);
            var serviceRequestsRowElements = SeleniumHelper.FindRowElementsWithinTable(serviceRequestsTableBodyElement);

            TestCheck.AssertIsEqual(serviceRequestsRowElements.ToArray().Length.ToString(), device.TotalServiceRequest.ToString(), "Total count of service requets does not match");

            foreach(var rowElement in serviceRequestsRowElements)
            {
                TestCheck.AssertTextContains(device.Model, rowElement.Text, "Model mismatch while validating service requests");
                TestCheck.AssertTextContains(device.SerialNumber, rowElement.Text, "Serial number mismatch while validating service requests");
            }
        }


    }
}