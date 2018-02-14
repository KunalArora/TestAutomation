using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsInprogressPage : CloudExistingProposalPage, IPageObject
    {
        public static string _url = "/mps/dealer/proposals/in-progress";
        private const string _validationElementSelector = "input#content_1_InProgressListActions_ActionList_Button_0"; //CreateProposal button

        public new string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public new string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        [FindsBy(How = How.CssSelector, Using = "[href='/mps/dealer/proposals/in-progress']")]
        public IWebElement InProgressTabElement; // same as Open

        [FindsBy(How = How.CssSelector, Using = "[href='/mps/dealer/proposals/awaiting-approval']")]
        public IWebElement OpenTabElement;

        [FindsBy(How = How.CssSelector, Using = "[href='/mps/dealer/proposals/approved']")]
        public IWebElement ApprovedTabElement;

        [FindsBy(How = How.CssSelector, Using = "[href='/mps/dealer/proposals/declined']")]
        public IWebElement DeclinedTabElement;

        [FindsBy(How = How.CssSelector, Using = "[href='/mps/dealer/proposals/closed']")]
        public IWebElement ClosedTabElement;


        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";

        public void ClickOnSubmitForApproval(int proposalId, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, driver);
            SeleniumHelper.SetListFilter(ProposalFilter, proposalId.ToString(), ProposalListProposalNameRowElement);
            SeleniumHelper.ActionsDropdownElement(actionsButton).Last().Click();
            ActionsModule.StartConvertToContractProcess(driver); // = Submit for Approval
        }

        public void SetListFilter(string filterString)
        {
            LoggingService.WriteLogOnMethodEntry(filterString);
            SeleniumHelper.SetListFilter(ProposalFilter, filterString, ProposalListProposalNameRowElement);
        }
    }
}
