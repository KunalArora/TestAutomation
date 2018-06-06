using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BieAdminEnhancedUsageMonitoringNewPrinterEnginePage: BasePage, IPageObject
    {
        private string _validationElementSelector = "#content_1_DropDownListCountry";
        private const string _url = "/mps/bie-admin/enhanced-usage-monitoring-new/printer-engine";

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

        private const string SuccessAlertSelector = ".alert.alert-success.mps-alert.js-mps-alert";

        // TABs
        [FindsBy(How = How.CssSelector, Using = "a[href$='/enhanced-usage-monitoring-new/installed-printer']")]
        public IWebElement InstalledPrinterTabElement;

        [FindsBy(How = How.CssSelector, Using = "#content_1_DropDownListCountry")]
        public IWebElement SelectCountryDropdownElement;
        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonSave")]
        public IWebElement SaveButtonElement;


        public void SelectCountryFromDropdownMenu(string country)
        {
            LoggingService.WriteLogOnMethodEntry(country);
            SeleniumHelper.SelectFromDropdownByText(SelectCountryDropdownElement, country);
        }

        public void EditPrinterEngineThresholdDetails(PrinterEngineThresholdDetails printerEngineThresholdDetails)
        {
            LoggingService.WriteLogOnMethodEntry(printerEngineThresholdDetails);

            var printerEngineRowElements = SeleniumHelper.FindElementsByCssSelector(".js-mps-printer-engine-row");
            var targetPrinterEngineElement = printerEngineRowElements.Find(
                d => d.FindElement(By.CssSelector("[id*=content_1_PrinterEngineRepeater_CellPrinterEngine_]")).Text == printerEngineThresholdDetails.PrinterEngine
                && d.FindElement(By.CssSelector("[id*=content_1_PrinterEngineRepeater_CellSupplyItemType_]")).Text == printerEngineThresholdDetails.SupplyItemType);

            var thresholdInputElement = SeleniumHelper.FindElementByCssSelector(targetPrinterEngineElement, ".js-mps-printer-engine-threshold");
            ClearAndType(thresholdInputElement, printerEngineThresholdDetails.Threshold);

            var enabledCheckBoxElement = SeleniumHelper.FindElementByCssSelector(targetPrinterEngineElement, "[id*=content_1_PrinterEngineRepeater_InputEnabled_]");
            if(printerEngineThresholdDetails.Enabled && !enabledCheckBoxElement.Selected)
            {
                SeleniumHelper.ClickSafety(enabledCheckBoxElement);
            }
        }

        public void CloseSuccessElementIfPresent()
        {
            LoggingService.WriteLogOnMethodEntry();
            if(SeleniumHelper.IsElementPresent(SuccessAlertSelector))
            {
                var successElement = SeleniumHelper.FindElementByCssSelector(SuccessAlertSelector);
                SeleniumHelper.ClickSafety(successElement.FindElement(By.ClassName("close")));
            }     
        }
    }
}
