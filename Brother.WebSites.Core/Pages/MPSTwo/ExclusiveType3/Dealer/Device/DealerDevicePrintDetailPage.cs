using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Device
{
    public class DealerDevicePrintDetailPage : BasePage, IPageObject
    {
        private string _validationElementSelector = ".js-mps-alert";
        private const string _url = "/mps/dealer/device/{reportingId}/print-detail";

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
        [FindsBy(How = How.CssSelector, Using = "a[href$='/consumable-orders']")]
        public IWebElement ConsumableOrdersTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/service-requests']")]
        public IWebElement ServiceRequestsTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/silent']")]
        public IWebElement SilentTabElement;

        private const string ChartPrintVolumeDailySelector = "#canvas_chart_pv_daily";
        private const string ChartPrintVolumeMonthlySelector = "#canvas_chart_pv_monthly";

        public void VerifyChartDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();

            var ChartPrintVolumeDailyElement = SeleniumHelper.FindElementByCssSelector(ChartPrintVolumeDailySelector);
            var ChartPrintVolumeMonthlyElement = SeleniumHelper.FindElementByCssSelector(ChartPrintVolumeMonthlySelector);

            TestCheck.AssertIsEqual(SeleniumHelper.IsElementDisplayed(ChartPrintVolumeDailyElement), true, "Print volume daily chart is not displayed");
            TestCheck.AssertIsEqual(SeleniumHelper.IsElementDisplayed(ChartPrintVolumeMonthlyElement), true, "Print volume monthly chart is not displayed");
        }
    }
}
