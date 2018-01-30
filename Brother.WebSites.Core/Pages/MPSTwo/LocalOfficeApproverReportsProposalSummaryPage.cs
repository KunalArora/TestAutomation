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


    }
}
