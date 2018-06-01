using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage: BasePage, IPageObject
    {
        private string _validationElementSelector = "#content_1_InputContractNumber_Input";
        private const string _url = "/mps/bie-admin/enhanced-usage-monitoring-new/installed-printer";

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
        [FindsBy(How = How.CssSelector, Using = "a[href$='/enhanced-usage-monitoring-new/printer-engine']")]
        public IWebElement PrinterEngineTabElement;
    }
}
