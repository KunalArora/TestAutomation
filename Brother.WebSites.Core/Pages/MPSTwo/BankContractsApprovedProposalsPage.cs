using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class BankContractsApprovedProposalsPage : LocalOfficeApproverContractsPage, IPageObject
    {
        private const string _validationElementSelector = ".active a[href=\"/mps/bank/contracts/approved-proposals\"]"; // list Next as "#DataTables_Table_0_next"
        private const string _url = "/mps/bank/contracts/approved-proposals";

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

        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/approved-proposals']")]
        public IWebElement ApprovedOffersTabElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/awaiting-acceptance']")]
        public IWebElement SignatureExpectedTabElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/accepted']")]
        public IWebElement SignedTabElement;
        [FindsBy(How = How.CssSelector, Using = ".mps-tabs-main a[href='/mps/bank/contracts/rejected']")]
        public IWebElement DeclinedTabElement;

    }
}
