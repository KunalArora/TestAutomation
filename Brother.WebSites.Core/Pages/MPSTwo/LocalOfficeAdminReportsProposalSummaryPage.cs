using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeAdminReportsProposalSummaryPage : LocalOfficeApproverReportsProposalSummaryPage
    {

        [FindsBy(How = How.CssSelector, Using = "#content_0_BillingDatesList_BillingDates_CellActions_0 > div > button")]
        public IWebElement BillingDatesActionsButtonTop;
        [FindsBy(How = How.CssSelector, Using = "#content_0_BillingDatesList_BillingDates_Actions_0_ActionLink_0")]
        public IWebElement ActionsViewBillButtonTop;

    }
}
