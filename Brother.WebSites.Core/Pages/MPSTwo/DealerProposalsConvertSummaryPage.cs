using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsConvertSummaryPage : BaseSummaryPage, IPageObject
    {
        private const string _url = "/mps/dealer/proposals/convert/summary";
        private const string _validationElementSelector = ".js-mps-proposal-process-summary-save-contract"; 

        public string ValidationElementSelector
        {
            get {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get { return _url; }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        [FindsBy(How = How.Id, Using = "content_1_InputEnvisagedStartDate_Input")]
        public IWebElement ProposedStartDate;
        [FindsBy(How = How.CssSelector, Using = "#content_1_InputSendToLeasingBank_Label")]
        public IWebElement ThirdPartyApproval;
        [FindsBy(How = How.Id, Using = "content_1_InputSendToBrother_Input")]
        public IWebElement SendToBrotherElement;
        [FindsBy(How = How.Id, Using = "content_1_ButtonSaveAsContract")]
        public IWebElement SaveAsContractButton;

        public void FillSubmitForApprovalField()
        {
            EnterProposedStartDateForContract();
        }

        public void EnterProposedStartDateForContract()
        {
            if (ProposedStartDate == null)
                throw new NullReferenceException("Contract start date field not displayed");
            ProposedStartDate.SendKeys(MpsUtil.SomeDaysFromToday());

        }

        public void GiveThirdPartyCheckApproval()
        {
            IWebElement element = GetElementByCssSelector("#content_1_InputSendToLeasingBank_Label", 5);
            if (element != null)
                ThirdPartyApproval.Click();
            element = GetElementByCssSelector("#content_1_InputSendToBrother_Input", 5);
            if (element != null)
                SendToBrotherElement.Click();
        }


    }
}
