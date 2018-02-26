using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

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

        public bool VerifyPrintCountsOfDevice( string serialNumber, int totalPrintCount)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber, totalPrintCount);

            bool isUpdated = true;
            var deviceRowElements = SeleniumHelper.FindRowElementsWithinTable(PrintersContainerElement);
            foreach (var row in deviceRowElements)
            {
                var SerialNumberElement = SeleniumHelper.FindElementByCssSelector(row, DeviceSerialNumberSelector);
                string displayedSerialNumber = SerialNumberElement.Text;
                if (displayedSerialNumber.Equals("-"))
                {
                    TestCheck.AssertFailTest("The Serial Number is not displayed on the Summary page probably due to System Bug");
                }
                if(displayedSerialNumber.Equals(serialNumber)) 
                {
                    var ShowPrintCountElement = ShowPrintCountActionElement(row);
                    SeleniumHelper.ClickSafety(ShowPrintCountElement, 10);
                    
                    try
                    {
                        var PrintCountsElement = SeleniumHelper.FindElementByCssSelector(PrintCountsModalSelector, 10);
                        var PrintCountsTableElement = SeleniumHelper.FindElementByCssSelector(PrintCountsElement, PrintCountsModalTableBodySelector);
                        var PrintCountsRowElements = SeleniumHelper.FindRowElementsWithinTable(PrintCountsTableElement);

                        var displayedTotalPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElements[0], TotalPrintCountSelector);

                        if (!(displayedTotalPrintCount.Text.Equals(totalPrintCount.ToString())))
                        {
                            isUpdated = false;
                        }

                        // Close Modal
                        SeleniumHelper.ClickSafety(
                            SeleniumHelper.FindElementByCssSelector(
                            PrintCountsElement, PrintCountsModalCloseButtonSelector));
                    }
                    catch
                    {
                        return false;
                    }

                }
            }
            return isUpdated;           
        }


        private IWebElement ShowPrintCountActionElement(IWebElement deviceRowElement)
        {
            LoggingService.WriteLogOnMethodEntry(deviceRowElement);
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, ActionsButtonSelector);
            SeleniumHelper.ClickSafety(ActionsButtonElement);

            var ShowPrintCountsElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, ShowPrintCountsActionsButtonSelector);

            return ShowPrintCountsElement;
        }        
    }
}
