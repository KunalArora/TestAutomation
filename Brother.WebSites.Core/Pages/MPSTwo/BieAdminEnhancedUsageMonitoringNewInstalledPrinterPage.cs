using Brother.Tests.Selenium.Lib.Support.HelperClasses;
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

        [FindsBy(How = How.CssSelector, Using = "#content_1_InputContractNumber_Input")]
        public IWebElement ContractNumberInputElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonGo")]
        public IWebElement GoButtonElement;

        
        public void SearchAgreementAndLoadDetails(int agreementId) // Ok for proposalId as well
        {
            LoggingService.WriteLogOnMethodEntry(agreementId);

            ClearAndType(ContractNumberInputElement, agreementId.ToString(), true);
            SeleniumHelper.ClickSafety(GoButtonElement);

            SeleniumHelper.FindElementByCssSelector(".mps-table-proposal-details"); // Wait until proposal/agreement details are loaded
        }

        public void ValidateAgreementDetails(string AgreementName, string ContractTerm,
            string LeadCodeReference, string LeasingFinanceReference, string ContractType,
            string UsageType, string DealerReference)
        {
            LoggingService.WriteLogOnMethodEntry(AgreementName, ContractTerm, LeadCodeReference, LeasingFinanceReference, ContractType, UsageType, DealerReference);

            var detailRows = SeleniumHelper.FindRowElementsWithinTable(SeleniumHelper.FindElementByCssSelector(".mps-table-proposal-details > tbody"));
            
            // TODO: Search elements by Id/class when they are fixed

            TestCheck.AssertTextContains(detailRows[0].Text, AgreementName, "Agreement Name validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");
            TestCheck.AssertIsEqual(detailRows[0].Text, ContractType, "Contract Type validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");

            TestCheck.AssertIsEqual(detailRows[1].Text, ContractTerm, "Contract Term validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");
            TestCheck.AssertIsEqual(detailRows[1].Text, UsageType, "Usage Type validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");

            TestCheck.AssertIsEqual(detailRows[2].Text, LeadCodeReference, "Lead code reference validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");
            TestCheck.AssertIsEqual(detailRows[2].Text, DealerReference, "Dealer Reference validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");

            TestCheck.AssertIsEqual(detailRows[3].Text, LeasingFinanceReference, "Leasing Finance Reference validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");
        }
    }
}
