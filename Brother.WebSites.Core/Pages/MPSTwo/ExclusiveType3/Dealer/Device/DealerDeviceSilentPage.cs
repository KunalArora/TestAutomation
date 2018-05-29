using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Device
{
    public class DealerDeviceSilentPage : BasePage, IPageObject
    {
        private string _validationElementSelector = ".mps-dataTables-footer";
        private const string _url = "/mps/dealer/device/{reportingId}/silent";

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
        [FindsBy(How = How.CssSelector, Using = "a[href$='/service-requests']")]
        public IWebElement ServiceRequestsTabElement;

        private const string SilentTableBodySelector = ".js-mps-searchable";

        public void VerifySilentInfo(string agreementStartDate, int agreementShiftDays)
        {
            LoggingService.WriteLogOnMethodEntry(agreementStartDate, agreementShiftDays);

            var silentTableBodyElement = SeleniumHelper.FindElementByCssSelector(SilentTableBodySelector);
            var silentTableRowElements = SeleniumHelper.FindRowElementsWithinTable(silentTableBodyElement);

            foreach(var rowElement in silentTableRowElements)
            {
                TestCheck.AssertTextContains(agreementStartDate, rowElement.Text, "Silent date mismatch while validating silent information");
                TestCheck.AssertTextContains(agreementShiftDays.ToString(), rowElement.Text, "Number of days mismatch while validating silent information");
            }
        }
    }
}