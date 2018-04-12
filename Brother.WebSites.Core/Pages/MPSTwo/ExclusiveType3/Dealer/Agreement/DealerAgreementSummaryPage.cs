using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement
{
    public class DealerAgreementSummaryPage: BasePage, IPageObject
    {
        private const string _validationElementSelector = ".mps-table-dealer-details";
        private const string _url = "/mps/dealer/agreement/{agreementId}/summary"; // TODO: Replace agreementId with dynamic parameters

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
        private const string MpsTabsSelector = ".mps-tabs-main";
        private const string MpsTabsAgreementSelector = " a[href=\"/mps/dealer/agreement/";

        public IWebElement DevicesTabElement(int agreementId)
        {
            LoggingService.WriteLogOnMethodEntry(agreementId);
            return SeleniumHelper.FindElementByCssSelector(
                string.Format(
                MpsTabsSelector + MpsTabsAgreementSelector + "{0}/devices\"]", agreementId.ToString()));
        }
    }
}
