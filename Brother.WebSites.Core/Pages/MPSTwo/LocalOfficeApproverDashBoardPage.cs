using System;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverDashBoardPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/proposals'] .media-body")]
        private IWebElement ProposalLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/contracts'] .media-body")]
        private IWebElement ContractLinkElement;

        public void IsProposalsLinkAvailable()
        {
            if (ProposalLinkElement == null) 
                throw new Exception("Unable to locate Proposals link on dashboard page");

            AssertElementPresent(ProposalLinkElement, "Create New Proposals Link");
        }

        public void IsContractsLinkAvailable()
        {
            if (ContractLinkElement == null)
                throw new Exception("Unable to locate Contracts link on dashboard page");

            AssertElementPresent(ContractLinkElement, "Create Contracts Link");
        }

        public LocalOfficeApproverProposalsPage NavigateToProposalsPage()
        {
            IsProposalsLinkAvailable();
            ProposalLinkElement.Click();
            return GetTabInstance<LocalOfficeApproverProposalsPage>(Driver, BaseURL, true);
        }

        public LocalOfficeApproverContractsPage NavigateToContractsPage()
        {
            IsContractsLinkAvailable();
            ContractLinkElement.Click();
            return GetTabInstance<LocalOfficeApproverContractsPage>(Driver, BaseURL, true);
        }
    }
}
