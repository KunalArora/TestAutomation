using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
{
    public class DealerAgreementBillingPage: BasePage, IPageObject
    {
        private string _validationElementSelector = ".js-mps-billing-dates-container";
        private const string _url = "/mps/dealer/agreement/{agreementId}/billing"; // TODO: Replace agreementId with dynamic parameter

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

        // Selectors
        private const string ActionsButtonSelector = "button.btn.btn-primary.btn-xs.dropdown-toggle";
        private const string DownloadClickRateBillSelector = ".js-mps-download-click-rate-invoice";
        private const string DownloadServiceInstallationBillSelector = ".js-mps-download-service-installation-invoice";

        // Web Elements
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement BillingDatesContainerElement;

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

        public void ClickDownloadClickRateBill(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var billingDatesRowElements = SeleniumHelper.FindRowElementsWithinTable(BillingDatesContainerElement);
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(billingDatesRowElements[rowIndex], ActionsButtonSelector);
            SeleniumHelper.ClickSafety(ActionsButtonElement);
            var DownloadClickRateBillButtonElement = SeleniumHelper.FindElementByCssSelector(billingDatesRowElements[rowIndex], DownloadClickRateBillSelector);
            SeleniumHelper.ClickSafety(DownloadClickRateBillButtonElement);
        }

        public string GetBillingStartDate(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var billingDatesRowElements = SeleniumHelper.FindRowElementsWithinTable(BillingDatesContainerElement);
            return billingDatesRowElements[rowIndex].FindElements(By.TagName("td")).ToList()[1].Text; // TODO: Use conventional approach to find element once id/class is fixed
        }

        public string GetBillingEndDate(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var billingDatesRowElements = SeleniumHelper.FindRowElementsWithinTable(BillingDatesContainerElement);
            return billingDatesRowElements[rowIndex].FindElements(By.TagName("td")).ToList()[2].Text; // TODO: Use conventional approach to find element once id/class is fixed
        }

        public string GetBillingClickRateTotal(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var billingDatesRowElements = SeleniumHelper.FindRowElementsWithinTable(BillingDatesContainerElement);
            return billingDatesRowElements[rowIndex].FindElements(By.TagName("td")).ToList()[3].Text; // TODO: Use conventional approach to find element once id/class is fixed
        }

        public bool IsClickRateTotalPopulated(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var billingDatesRowElements = SeleniumHelper.FindRowElementsWithinTable(BillingDatesContainerElement);
            try
            {
                return SeleniumHelper.WaitUntil(
                    d => (billingDatesRowElements[rowIndex].FindElements(By.TagName("td")).ToList()[3].Text != "-") // TODO: Use conventional approach to find element once id/class is fixed
                 , RuntimeSettings.DefaultInvoiceGenerationTimeout);
            }
            catch
            {
                return false;
            }
        }

        public bool IsServiceInstallationTotalPopulated(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var billingDatesRowElements = SeleniumHelper.FindRowElementsWithinTable(BillingDatesContainerElement);
            try
            {
                return SeleniumHelper.WaitUntil(
                    d => (billingDatesRowElements[rowIndex].FindElements(By.TagName("td")).ToList()[5].Text != "-") // TODO: Use conventional approach to find element once id/class is fixed
                 , RuntimeSettings.DefaultInvoiceGenerationTimeout);
            }
            catch
            {
                return false;
            }
        }

        public void ClickDownloadServiceInstallationBill(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var billingDatesRowElements = SeleniumHelper.FindRowElementsWithinTable(BillingDatesContainerElement);
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(billingDatesRowElements[rowIndex], ActionsButtonSelector);
            SeleniumHelper.ClickSafety(ActionsButtonElement);
            var DownloadServiceInstallationBillButtonElement = SeleniumHelper.FindElementByCssSelector(billingDatesRowElements[rowIndex], DownloadServiceInstallationBillSelector);
            SeleniumHelper.ClickSafety(DownloadServiceInstallationBillButtonElement);
        }

        public string GetServiceInstallationTotal(int rowIndex)
        {
            LoggingService.WriteLogOnMethodEntry(rowIndex);
            var billingDatesRowElements = SeleniumHelper.FindRowElementsWithinTable(BillingDatesContainerElement);
            return billingDatesRowElements[rowIndex].FindElements(By.TagName("td")).ToList()[5].Text; // TODO: Use conventional approach to find element once id/class is fixed
        }
    }
}
