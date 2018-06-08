using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
{
    public class DealerAgreementDetailsPage: BasePage, IPageObject
    {
        private string _validationElementSelector = ".mps-qa-printer";
        private const string _url = "/mps/dealer/agreement/{agreementId}/details"; // TODO: Replace agreementId with dynamic parameter

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

        // Page Selectors
        private const string MpsQaPrinterSelector = ".mps-qa-printer-";
        private const string InstallationPackUnitPriceSelector = "[id*=InstallationPackUnitPrice]";
        private const string ServicePackUnitPriceSelector = "[id*=ServicePackUnitPrice]";


        // Tab link selectors
        private const string MpsTabsSelector = ".mps-tabs-main";
        private const string MpsTabsAgreementSelector = " a[href=\"/mps/dealer/agreement/";

        // TABs
        [FindsBy(How = How.CssSelector, Using = "a[href$='/summary']")] // ex. /mps/dealer/agreement/173259/summary
        public IWebElement SummaryTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/details']")]
        public IWebElement DetailsTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/devices']")]
        public IWebElement DevicesTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/billing']")]
        public IWebElement BillingTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/consumables']")]
        public IWebElement ConsumablesTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/service-requests']")]
        public IWebElement ServiceRequestsTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/history']")]
        public IWebElement HistoryTabElement;
        [FindsBy(How = How.CssSelector, Using = "a[href$='/silent-devices']")]
        public IWebElement SilentDevicesTabElement;


        public IWebElement GetPrinterContainer(string deviceModel)
        {
            LoggingService.WriteLogOnMethodEntry(deviceModel);
            
            return SeleniumHelper.FindElementByCssSelector(MpsQaPrinterSelector + deviceModel);
        }

        public string GetInstallationPackPrice(string deviceModel)
        {
            LoggingService.WriteLogOnMethodEntry(deviceModel);
            var printerContainer = GetPrinterContainer(deviceModel);
            try
            {
                return printerContainer.FindElement(By.CssSelector(InstallationPackUnitPriceSelector)).Text;
            }
            catch
            {
                return "0.00";
            }
        }

        public string GetServicePackPrice(string deviceModel)
        {
            LoggingService.WriteLogOnMethodEntry(deviceModel);
            var printerContainer = GetPrinterContainer(deviceModel);
            try
            {
                return printerContainer.FindElement(By.CssSelector(ServicePackUnitPriceSelector)).Text;
            }
            catch
            {
                return "0.00";
            }
        }
    }
}