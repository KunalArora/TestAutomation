using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverReportsProposalSummaryPage : ReportProposalSummaryPage, IPageObject
    {
        private const string _url = "/mps/local-office/reports/proposal-summary";
        private const string _validationElementSelector = "#content_0_ButtonBack"; // back
        
        public string PageUrl
        {
            get
            {
                return _url;
            }
        }
        
        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }
       
        [FindsBy(How = How.CssSelector, Using = "#content_0_ButtonSpecialPricing")]
        public IWebElement ButtonSpecialPricing;

        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement PrintersContainerElement;

        private const string billingDatesSelector =  ".mps-billing-dates-container";
        private const string billingDatesRowSelector = "#content_0_BillingDatesList_BillingDates_CellActions_2";
        private const string actionButtonSelector = ".btn-xs.dropdown-toggle";
        private const string billSelector = ".js-mps-download-invoice-pdf";

        private const string PrintCountsModalDateTimeSelector = ".mps-print-count-date";
        private const string ColorPrintCountSelector = ".mps-print-count-colour";
        private const string MonoPrintCountSelector = ".mps-print-count-mono";
        private const string TotalPrintCountSelector = ".mps-print-count-total";

        private const string PrintCountsModalCloseButtonSelector = ".js-mps-print-counts-list > .modal-header > .close";
        private const string ShowPrintCountsActionsButtonSelector = ".js-mps-view-print-count";
        private const string PrintCountsModalTableBodySelector = ".js-mps-print-counts-list > .modal-body > .table > tbody";
        private const string DeviceSerialNumberSelector = "[id*=content_0_ContractDevicesList_Contracts_List_0_CellSerialNo_]";

        private const string ActionsButtonSelector = "button.btn.btn-primary.btn-xs.dropdown-toggle";
        private const string PrintCountsModalSelector = ".js-mps-print-counts-list";

        public void ClickOnBillAction()
        {
            LoggingService.WriteLogOnMethodEntry();
            var billingDatesContainer = SeleniumHelper.FindElementByCssSelector(billingDatesSelector);
            ScrollTo(billingDatesContainer);
            var billingDatesRow2Container = SeleniumHelper.FindElementByCssSelector(billingDatesContainer, billingDatesRowSelector);
            var actionButtonContainer = SeleniumHelper.FindElementByCssSelector(billingDatesRow2Container, actionButtonSelector);
            actionButtonContainer.Click();
            var billContainer = SeleniumHelper.FindElementByCssSelector(billingDatesRow2Container, billSelector);
            billContainer.Click();
        }

        public bool VerifyPrintCountsOfDevice( string serialNumber, int monoPrintCount, int colorPrintCount, int totalPrintCount)
        {
            LoggingService.WriteLogOnMethodEntry();

            bool isUpdated = true;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(PrintersContainerElement);
            foreach (var row in deviceRowElements)
            {   
                var SerialNumberElement = SeleniumHelper.FindElementByCssSelector(row, DeviceSerialNumberSelector);
                string displayedSerialNumber = SerialNumberElement.Text;
                if(displayedSerialNumber.Equals(serialNumber)) 
                {
                    var PrintCountsElement = ClickShowPrintCounts(row);
                    var PrintCountsTableElement = SeleniumHelper.FindElementByCssSelector(PrintCountsElement, PrintCountsModalTableBodySelector);
                    var PrintCountsRowElements = SeleniumHelper.FindRowElementsWithinTable(PrintCountsTableElement);

                    var displayedDateTime = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElements[0], PrintCountsModalDateTimeSelector);
                    var displayedTotalPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElements[0], TotalPrintCountSelector);
                    var displayedColorPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElements[0], ColorPrintCountSelector);
                    var displayedMonoPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElements[0], MonoPrintCountSelector);

                    if(!(displayedTotalPrintCount.Text.Equals(totalPrintCount.ToString())))
                    {
                        isUpdated = false;
                    }

                    // Close Modal
                    SeleniumHelper.ClickSafety(
                        SeleniumHelper.FindElementByCssSelector(
                        PrintCountsElement, PrintCountsModalCloseButtonSelector));

                }
            }
            return isUpdated;           
        }


        private IWebElement ClickShowPrintCounts(IWebElement deviceRowElement)
        {
            LoggingService.WriteLogOnMethodEntry(deviceRowElement);
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, ActionsButtonSelector);
            SeleniumHelper.ClickSafety(ActionsButtonElement);

            var ShowPrintCountsElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, ShowPrintCountsActionsButtonSelector);
            SeleniumHelper.ClickSafety(ShowPrintCountsElement);

            var PrintCountsModalElement = SeleniumHelper.FindElementByCssSelector(PrintCountsModalSelector);
            return PrintCountsModalElement;
        }        
    }
}
