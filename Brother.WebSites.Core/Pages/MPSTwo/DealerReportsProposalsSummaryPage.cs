using Brother.Tests.Common.Domain.SpecFlowTableMappings;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerReportsProposalsSummaryPage : BasePage, IPageObject
    {
        private const string _validationElementSelector = "#content_0_ButtonBack";
        private const string _url = "/mps/dealer/reports/proposal-summary";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        [FindsBy(How = How.CssSelector, Using = ".js-mps-searchable")]
        public IWebElement PrintersContainerElement;

        private const string DeviceSerialNumberSelector = "[id*=content_0_ContractDevicesList_Contracts_List_0_CellSerialNo_]";
        private const string ActionsButtonSelector = "button.btn.btn-primary.btn-xs.dropdown-toggle";
        private const string PrintCountsModalSelector = ".js-mps-print-counts-list";
        private const string PrintCountsModalTableBodySelector = ".js-mps-print-counts-list > .modal-body > .table > tbody";
        private const string ColorPrintCountSelector = ".mps-print-count-colour";
        private const string MonoPrintCountSelector = ".mps-print-count-mono";
        private const string PrintCountsModalCloseButtonSelector = ".js-mps-print-counts-list > .modal-header > .close";
        private const string ShowPrintCountsActionsButtonSelector = ".js-mps-view-print-count";

        private const string ShowConsumableOrderActionsButtonSelector = ".js-mps-view-consumable-orders";
        private const string ConsumableOrderModalSelector = ".js-mps-consumable-orders-list";
        private const string ConsumableOrderModalTableBodySelector = ".js-mps-consumable-orders-list > .modal-body > .table > tbody";
        private const string ConsumableOrderModalCloseButtonSelector = ".js-mps-consumable-orders-list > .modal-header > .close";


        public bool VerifyPrintCountsOfDevice(string serialNumber, int monoPrintCount, int colorPrintCount)
        {
            LoggingService.WriteLogOnMethodEntry(serialNumber, monoPrintCount, colorPrintCount);

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
                        var PrintCountsTableElement = SeleniumHelper.FindElementByCssSelector(PrintCountsElement, PrintCountsModalTableBodySelector, 10);
                        var PrintCountsRowElements = SeleniumHelper.FindRowElementsWithinTable(PrintCountsTableElement);

                        var displayedMonoPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElements[0], MonoPrintCountSelector, 10);
                        var displayedColorPrintCount = SeleniumHelper.FindElementByCssSelector(PrintCountsRowElements[0], ColorPrintCountSelector, 10);

                        if (!(displayedMonoPrintCount.Text.Equals(monoPrintCount.ToString()) || displayedColorPrintCount.Text.Equals(colorPrintCount.ToString())))
                        {
                            isUpdated = false;
                        }

                        // Close Modal
                        SeleniumHelper.ClickSafety(
                            SeleniumHelper.FindElementByCssSelector(
                            PrintCountsElement, PrintCountsModalCloseButtonSelector, 3), 3);
                    }
                    catch
                    {
                        return false;
                    }

                }
            }
            return isUpdated;           
        }

        public bool VerifyConsumableOrderOfDevice(PrinterProperties product, string orderedConsumable, string orderStatus)
        {
            LoggingService.WriteLogOnMethodEntry(product, orderedConsumable);

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
                if (displayedSerialNumber.Equals(product.SerialNumber))
                {
                    var ShowConsumableOrderElement = ShowConsumableOrderActionElement(row);
                    SeleniumHelper.ClickSafety(ShowConsumableOrderElement, 10);
                    try
                    {
                        var ConsumableOrderElement = SeleniumHelper.FindElementByCssSelector(ConsumableOrderModalSelector, 10);
                        var ConsumableOrderTableElement = SeleniumHelper.FindElementByCssSelector(ConsumableOrderElement, ConsumableOrderModalTableBodySelector, 10);
                        var ConsumableOrderRowElements = SeleniumHelper.FindRowElementsWithinTable(ConsumableOrderTableElement);


                        TestCheck.AssertTextContains(product.ConsumableCreatedDate, ConsumableOrderRowElements[1].Text, string.Format("Consumable Date = {0} cannot be verified", product.ConsumableCreatedDate));
                        TestCheck.AssertTextContains(orderedConsumable, ConsumableOrderRowElements[1].Text, string.Format("Ordered cosumable name = {0} cannot be verified", orderedConsumable));
                        TestCheck.AssertTextContains(orderStatus, ConsumableOrderRowElements[1].Text, string.Format("Order Status is not in processing state for consumable = {0}", product.Model));

                        // Close Modal
                        SeleniumHelper.ClickSafety(
                            SeleniumHelper.FindElementByCssSelector(
                            ConsumableOrderElement, ConsumableOrderModalCloseButtonSelector, 3), 3);
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

        private IWebElement ShowConsumableOrderActionElement(IWebElement deviceRowElement)
        {
            LoggingService.WriteLogOnMethodEntry(deviceRowElement);
            var ActionsButtonElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, ActionsButtonSelector);
            SeleniumHelper.ClickSafety(ActionsButtonElement);

            var ShowConsumableOrderElement = SeleniumHelper.FindElementByCssSelector(deviceRowElement, ShowConsumableOrderActionsButtonSelector);

            return ShowConsumableOrderElement;
        }
    }
}
