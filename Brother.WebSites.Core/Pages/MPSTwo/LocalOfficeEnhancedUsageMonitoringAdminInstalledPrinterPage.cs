﻿using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeEnhancedUsageMonitoringAdminInstalledPrinterPage: BasePage, IPageObject
    {
        private string _validationElementSelector = "#content_1_InputContractNumber_Input";
        private const string _url = "/mps/local-office/enhanced-usage-monitoring-admin/installed-printer";

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
        private const string EUMRowSelector = ".js-mps-installed-printer-eum-row";
        private const string EUMRowModelSelector = "[id*=content_1_InstalledPrinterRepeater_CellModel_]";
        private const string EUMRowSupplyItemTypeSelector = "[id*=content_1_InstalledPrinterRepeater_CellSupplyItemType_]";
        private const string EUMRowPrinterEngineSelector = "[id*=content_1_InstalledPrinterRepeater_CellPrinterEngine_]";
        private const string EUMRowDefaultThresholdSelector = "[id*=content_1_InstalledPrinterRepeater_CellDefaultThresholdValue_]";
        private const string EUMRowInputThresholdSelector = "[id*=content_1_InstalledPrinterRepeater_InputThreshold_]";
        private const string EUMRowInputEnabledCheckboxSelector = "[id*=content_1_InstalledPrinterRepeater_InputEnabled_]";
        private const string SuccessAlertSelector = ".alert.alert-success.mps-alert.js-mps-alert";


        // TABs
        [FindsBy(How = How.CssSelector, Using = "a[href$='/enhanced-usage-monitoring-admin/printer-engine']")]
        public IWebElement PrinterEngineTabElement;

        [FindsBy(How = How.CssSelector, Using = "#content_1_InputContractNumber_Input")]
        public IWebElement ContractNumberInputElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonGo")]
        public IWebElement GoButtonElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement SaveButtonElement;

        
        public void SearchAgreementAndLoadDetails(int agreementId) // Ok for proposalId as well
        {
            LoggingService.WriteLogOnMethodEntry(agreementId);

            try
            {
                ClearAndType(ContractNumberInputElement, agreementId.ToString(), true);
                SeleniumHelper.ClickSafety(GoButtonElement);

                SeleniumHelper.FindElementByCssSelector(".mps-table-proposal-details"); // Wait until proposal/agreement details are loaded
            }
            catch (Exception e)
            {
                TestCheck.AssertFailTest(
                    string.Format("Some problem occurred when searching for contract/agreement on LocalOfficeEnhancedUsageMonitoringAdminInstalledPrinterPage for agreement/contract ID = {0}. Error details  = {1}", agreementId, e));
            }
        }

        public void ValidateAgreementDetails(string AgreementName, string ContractTerm,
            string LeadCodeReference, string LeasingFinanceReference, string ContractType,
            string UsageType, string DealerReference)
        {
            LoggingService.WriteLogOnMethodEntry(AgreementName, ContractTerm, LeadCodeReference, LeasingFinanceReference, ContractType, UsageType, DealerReference);

            var detailRows = SeleniumHelper.FindRowElementsWithinTable(SeleniumHelper.FindElementByCssSelector(".mps-table-proposal-details > tbody"));
            
            // TODO: Search elements by Id/class when they are fixed

            TestCheck.AssertTextContains(AgreementName, detailRows[0].Text, "Agreement Name validation failed on LocalOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage");
            TestCheck.AssertTextContains(ContractType, detailRows[0].Text, "Contract Type validation failed on LocalOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage");

            TestCheck.AssertTextContains(ContractTerm, detailRows[1].Text, "Contract Term validation failed on LocalOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage");
            TestCheck.AssertTextContains(UsageType, detailRows[1].Text, "Usage Type validation failed on LocalOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage");

            TestCheck.AssertTextContains(LeadCodeReference, detailRows[2].Text, "Lead code reference validation failed on LocalOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage");
            TestCheck.AssertTextContains(DealerReference, detailRows[2].Text, "Dealer Reference validation failed on LocalOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage");

            TestCheck.AssertTextContains(LeasingFinanceReference, detailRows[3].Text, "Leasing Finance Reference validation failed on LocalOfficeAdminEnhancedUsageMonitoringAdminInstalledPrinterPage");
        }

        public void VerifyPrinterDetails(IEnumerable<PrinterEngineThresholdDetails> printerEngineThresholdDetails)
        {
            LoggingService.WriteLogOnMethodEntry(printerEngineThresholdDetails);

            var eumRowElements = SeleniumHelper.FindElementsByCssSelector(EUMRowSelector);
            foreach(var thresholdDetails in printerEngineThresholdDetails)
            {
                TestCheck.AssertIsNotNull(eumRowElements.Find(
                    d =>
                        d.FindElement(By.CssSelector(EUMRowSupplyItemTypeSelector)).Text == thresholdDetails.SupplyItemType &&
                        d.FindElement(By.CssSelector(EUMRowPrinterEngineSelector)).Text == thresholdDetails.PrinterEngine &&
                        d.FindElement(By.CssSelector(EUMRowDefaultThresholdSelector)).Text == thresholdDetails.Threshold), 
                        "Printer Engine Threshold details could not be verified. Expected threshold details = " + thresholdDetails);
            }
        }

        public void UpdateThresholdValuesAndSave(IEnumerable<PrinterProperties> printerProperties)
        {
            LoggingService.WriteLogOnMethodEntry(printerProperties);

            var eumRowElements = SeleniumHelper.FindElementsByCssSelector(EUMRowSelector);
            foreach(var printer in printerProperties)
            {
                var targetEumRow = eumRowElements.Find(
                    d =>
                        d.FindElement(By.CssSelector(EUMRowModelSelector)).Text == printer.Model &&
                        d.FindElement(By.CssSelector(EUMRowSupplyItemTypeSelector)).Text == "Mono");

                TestCheck.AssertIsNotNull(targetEumRow, "Printer engine mono threshold details not found for printer = " + printer.Model);

                ClearAndType(SeleniumHelper.FindElementByCssSelector(targetEumRow, EUMRowInputThresholdSelector), printer.MonoThresholdValue, true);
                var checkBox = SeleniumHelper.FindElementByCssSelector(targetEumRow, EUMRowInputEnabledCheckboxSelector);
                SeleniumHelper.SetCheckBox(checkBox, true);
                
                if(!printer.IsMonochrome)
                {
                    targetEumRow = eumRowElements.Find(
                    d =>
                        d.FindElement(By.CssSelector(EUMRowModelSelector)).Text == printer.Model &&
                        d.FindElement(By.CssSelector(EUMRowSupplyItemTypeSelector)).Text == "Colour");

                    TestCheck.AssertIsNotNull(targetEumRow, "Printer engine colour threshold details not found for printer = " + printer.Model);

                    ClearAndType(SeleniumHelper.FindElementByCssSelector(targetEumRow, EUMRowInputThresholdSelector), printer.ColourThresholdValue, true);
                    checkBox = SeleniumHelper.FindElementByCssSelector(targetEumRow, EUMRowInputEnabledCheckboxSelector);
                    SeleniumHelper.SetCheckBox(checkBox, true);
                }
            }

            SeleniumHelper.ClickSafety(SaveButtonElement);
        }

        public void CloseSuccessElementIfPresent()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (SeleniumHelper.IsElementPresent(SuccessAlertSelector))
            {
                var successElement = SeleniumHelper.FindElementByCssSelector(SuccessAlertSelector);
                SeleniumHelper.ClickSafety(successElement.FindElement(By.ClassName("close")));
            }
        }
    }
}