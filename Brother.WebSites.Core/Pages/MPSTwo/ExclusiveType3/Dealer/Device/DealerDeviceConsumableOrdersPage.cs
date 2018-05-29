using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Device
{
    public class DealerDeviceConsumableOrdersPage : BasePage, IPageObject
    {
        private string _validationElementSelector = ".js-mps-alert";
        private const string _url = "/mps/dealer/device/{reportingId}/consumable-orders";

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
        [FindsBy(How = How.CssSelector, Using = "a[href$='/service-requests']")]
        public IWebElement ServiceRequestsTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/silent']")]
        public IWebElement SilentTabElement;

        private const string ConsumableOrderTableBodySelector = ".js-mps-searchable";

        public void VerifyManualConsumableOrder(AdditionalDeviceProperties device, string resourceConsumableOrderMethodManual, string agreementStartDate)
        {
            LoggingService.WriteLogOnMethodEntry(device, resourceConsumableOrderMethodManual, agreementStartDate);

            if(device.hasEmptyInkToner)
            {
                var ConsumableOrderTableBodyElement = SeleniumHelper.FindElementByCssSelector(ConsumableOrderTableBodySelector);
                var ConsumableOrderRowsElement = SeleniumHelper.FindRowElementsWithinTable(ConsumableOrderTableBodyElement);

                foreach (var rowElement in ConsumableOrderRowsElement)
                {
                    if(rowElement.Text.Contains(resourceConsumableOrderMethodManual))
                    {
                        TestCheck.AssertTextContains(resourceConsumableOrderMethodManual, rowElement.Text, "Consumable order method does not match");
                        TestCheck.AssertTextContains(agreementStartDate, rowElement.Text, "Order date does not match");
                    }
                }
            }
        }

        public void VerifyAutomaticConsumableOrder(AdditionalDeviceProperties device, string resourceConsumableOrderMethodAutomatic, string agreementStartDate)
        {
            LoggingService.WriteLogOnMethodEntry(device, resourceConsumableOrderMethodAutomatic, agreementStartDate);

            if (device.hasLowRemLifeInkToner)
            {
                var ConsumableOrderTableBodyElement = SeleniumHelper.FindElementByCssSelector(ConsumableOrderTableBodySelector);
                var ConsumableOrderRowsElement = SeleniumHelper.FindRowElementsWithinTable(ConsumableOrderTableBodyElement);

                foreach (var rowElement in ConsumableOrderRowsElement)
                {
                    if(rowElement.Text.Contains(resourceConsumableOrderMethodAutomatic))
                    {
                        TestCheck.AssertTextContains(resourceConsumableOrderMethodAutomatic, rowElement.Text, "Consumable order method does not match");
                        TestCheck.AssertTextContains(agreementStartDate, rowElement.Text, "Order date does not match");
                    }
                }
            }
        }
    }
}
