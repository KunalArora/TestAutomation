using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.Dealer.Agreement;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo.ExclusiveType3.LocalOffice
{
    public class LocalOfficeAgreementSummaryPage: DealerAgreementSummaryPage, IPageObject
    {
        private const string _validationElementSelector = "#content_1_SummaryTable_ProposalDetailsContainer"; // Agreement Details Container
        private const string _url = "/mps/local-office/agreement/{agreementId}/summary"; // TODO: Replace agreementId with dynamic parameter

        public string ValidationElementSelector
        {
            get { return _validationElementSelector; }
        }

        public string PageUrl
        {
            get { return _url; }
        }


        // Selectors
        private const string MpsTabsSelector = ".mps-tabs-main";
        private const string MpsTabsAgreementSelector = " a[href=\"/mps/local-office/agreement/";
        private const string SpecialPricingButtonSelector = "#content_1_ButtonSpecialPricing";

        // Web elements
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DealershipName")]
        public IWebElement DealershipNameElement;
        [FindsBy(How = How.Id, Using = "content_1_SummaryTable_DealerSapNumber")]
        public IWebElement DealershipSapNumberElement;

 

        public IWebElement DevicesTabElement(int agreementId)
        {
            LoggingService.WriteLogOnMethodEntry(agreementId);
            return SeleniumHelper.FindElementByCssSelector(
                string.Format(
                MpsTabsSelector + MpsTabsAgreementSelector + "{0}/devices\"]", agreementId.ToString()));
        }

        public void ClickSpecialPricing()
        {
            LoggingService.WriteLogOnMethodEntry();
            SeleniumHelper.ClickSafety(
                SeleniumHelper.FindElementByCssSelector(SpecialPricingButtonSelector), IsUntilUrlChanges:true);
        }
    }
}