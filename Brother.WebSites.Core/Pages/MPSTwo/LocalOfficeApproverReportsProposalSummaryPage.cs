using Brother.Tests.Selenium.Lib.Helpers;
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

        private const string billingDatesSelector =  ".mps-billing-dates-container";
        private const string billingDatesRowSelector = "#content_0_BillingDatesList_BillingDates_CellActions_2";
        private const string actionButtonSelector = ".btn-xs.dropdown-toggle";
        private const string billSelector = ".js-mps-download-invoice-pdf";

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
    }
}
