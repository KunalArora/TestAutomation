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

        // Selectos
        private const string ActionsButtonSelector = "button.btn.btn-primary.btn-xs.dropdown-toggle";
        private const string DownloadClickRateBillSelector = ".js-mps-download-click-rate-invoice";

        // Web Elements
        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement BillingDatesContainerElement;

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
                 );
            }
            catch
            {
                return false;
            }
        }
    }
}
