using System;
using Brother.Tests.Selenium.Lib.Support;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverDashBoardPage : BasePage
    {
        public static string Url = "/mps/local-office/dashboard";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/proposals'] .media-body")]
        public IWebElement ProposalLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href='/mps/local-office/contracts'] .media-body")]
        public IWebElement ContractLinkElement;

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
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ProposalLinkElement);
            return GetTabInstance<LocalOfficeApproverProposalsPage>(Driver);
        }

        public LocalOfficeApproverContractsPage NavigateToContractsPage()
        {
            IsContractsLinkAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ContractLinkElement);
            return GetTabInstance<LocalOfficeApproverContractsPage>(Driver);
        }
    }
}
