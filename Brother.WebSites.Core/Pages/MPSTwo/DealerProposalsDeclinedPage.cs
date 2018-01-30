using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsDeclinedPage : CloudExistingProposalPage, IPageObject
    {
        private const string _url = "/mps/dealer/proposals/declined";
        private const string _validationElementSelector = ".active a[href=\"/mps/dealer/proposals/declined\"]";// list Next 

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

        [FindsBy(How = How.CssSelector, Using = ".js-mps-download-proposal-pdf")]
        public IList<IWebElement> AttachedProposalId;
        [FindsBy(How = How.Id, Using = "content_1_ProposalListFilter_InputFilterBy")]
        public IWebElement InputFilterByElement;
        // ex. content_1_SimpleProposalList_List_ProposalNameRow_25
        [FindsBy(How = How.CssSelector, Using = "[id*=_SimpleProposalList_List_ProposalNameRow_]")]
        public IList<IWebElement> NameRowElementList;

        private const string actionsButtonSelector = @".js-mps-filter-ignore .dropdown-toggle";
        private const string copyWithCustomerSelector = @".js-mps-copy-with-customer";

        public void ClickOnCopyWithCustomerActionItem(int proposalId, IWebDriver driver)
        {
            LoggingService.WriteLogOnMethodEntry(proposalId, driver);
            
            ClearAndType(ProposalFilter, proposalId.ToString());
            SeleniumHelper.WaitUntil(d => ProposalListProposalNameRowElement.Count == 1);
            var actionsButtonElement = SeleniumHelper.FindElementByCssSelector(actionsButtonSelector);
            actionsButtonElement.Click();
            var copyWithCustomerElement = SeleniumHelper.FindElementByCssSelector(copyWithCustomerSelector);
            copyWithCustomerElement.Click();
        }


        public void IsDuplicateProposalDisplayed()
        {
            LoggingService.WriteLogOnMethodEntry();
            var container = new List<string>();
            var noOfProposalId = AttachedProposalId.Count;


            for (var i = 0; i < AttachedProposalId.Count; i++)
            {
                ActionsModule.ClickOnTheActionsDropdown(i, Driver);
                var proposalId = AttachedProposalId.ElementAt(i).GetAttribute("data-proposal-id");

                container.Add(proposalId);

                ActionsModule.ClickOnTheActionsDropdown(i, Driver);
            }

            var numberOfDistinct = container.Distinct().Count();

            TestCheck.AssertIsEqual(true, noOfProposalId == (numberOfDistinct), "");
        }

    }
}
