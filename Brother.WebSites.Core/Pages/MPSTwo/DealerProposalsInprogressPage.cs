using Brother.WebSites.Core.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Helpers;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

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

        private const string actionsButton = @".js-mps-filter-ignore .dropdown-toggle";

        public void ClickOnSubmitForApproval(int proposalId, int findElementTimeout, IWebDriver driver)
        {
            ClearAndType(ProposalFilter, proposalId.ToString());
            SeleniumHelper.WaitUntil(d => ProposalListProposalNameRowElement.Count == 1, findElementTimeout);
            SeleniumHelper.ActionsDropdownElement(actionsButton).Last().Click();
            ActionsModule.StartConvertToContractProcess(driver); // = Submit for Approval
        }

        private ReadOnlyCollection<IWebElement> ActionsDropdownElement(string actionsButton)
        {
            var actionsElement = Driver.FindElements(By.CssSelector(actionsButton));
            return actionsElement;
        }


    }
}
