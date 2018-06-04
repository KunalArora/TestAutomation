using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

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

            TestCheck.AssertTextContains(AgreementName, detailRows[0].Text, "Agreement Name validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");
            TestCheck.AssertTextContains(ContractType, detailRows[0].Text, "Contract Type validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");

            TestCheck.AssertTextContains(ContractTerm, detailRows[1].Text, "Contract Term validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");
            TestCheck.AssertTextContains(UsageType, detailRows[1].Text, "Usage Type validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");

            TestCheck.AssertTextContains(LeadCodeReference, detailRows[2].Text, "Lead code reference validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");
            TestCheck.AssertTextContains(DealerReference, detailRows[2].Text, "Dealer Reference validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");

            TestCheck.AssertTextContains(LeasingFinanceReference, detailRows[3].Text, "Leasing Finance Reference validation failed on BieAdminEnhancedUsageMonitoringNewInstalledPrinterPage");
        }

        public void VerifyPrinterDetails(IEnumerable<PrinterEngineThresholdDetails> printerEngineThresholdDetails)
        {
            LoggingService.WriteLogOnMethodEntry(printerEngineThresholdDetails);

            var eumRowElements = SeleniumHelper.FindElementsByCssSelector(".js-mps-installed-printer-eum-row");
            foreach(var thresholdDetails in printerEngineThresholdDetails)
            {
                TestCheck.AssertIsNotNull(eumRowElements.Find(
                    d =>
                        d.FindElement(By.CssSelector("[id*=content_1_InstalledPrinterRepeater_CellSupplyItemType_]")).Text == thresholdDetails.SupplyItemType &&
                        d.FindElement(By.CssSelector("[id*=content_1_InstalledPrinterRepeater_CellPrinterEngine_]")).Text == thresholdDetails.PrinterEngine &&
                        d.FindElement(By.CssSelector("[id*=content_1_InstalledPrinterRepeater_CellDefaultThresholdValue_]")).Text == thresholdDetails.Threshold), 
                        "Printer Engine Threshold details could not be verified. Expected threshold details = " + thresholdDetails);
            }
        }
    }
}
