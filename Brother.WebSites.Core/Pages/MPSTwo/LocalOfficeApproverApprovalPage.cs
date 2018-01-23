using Brother.Tests.Selenium.Lib.Helpers;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverApprovalPage : BasePage, IPageObject
    {
        public static string Url = "/";

        private const string _validationElementSelector = "a[href=\"/mps/local-office/approval/proposals\"] .media-heading";
        private const string _url = "/mps/local-office/approval/dashboard";

        public string ValidationElementSelector
        {
            get
            {
                return _validationElementSelector;
            }
        }

        public string PageUrl
        {
            get
            {
                return _url;
            }
        }

        public ISeleniumHelper SeleniumHelper { get; set; }

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/approval/proposals\"] .media-heading")]
        public IWebElement ProposalLinkElement;
        [FindsBy(How = How.CssSelector, Using = "a[href=\"/mps/local-office/approval/contracts\"] .media-heading")]
        public IWebElement ContractLinkElement;




        public void IsProposalsLinkAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ProposalLinkElement == null)
                throw new Exception("Unable to locate Proposals link on dashboard page");

            AssertElementPresent(ProposalLinkElement, "Create New Proposals Link");
        }

        public void IsContractsLinkAvailable()
        {
            LoggingService.WriteLogOnMethodEntry();
            if (ContractLinkElement == null)
                throw new Exception("Unable to locate Contracts link on dashboard page");

            AssertElementPresent(ContractLinkElement, "Create Contracts Link");
        }


        public LocalOfficeApproverProposalsPage NavigateToProposalsPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsProposalsLinkAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ProposalLinkElement);
            return GetTabInstance<LocalOfficeApproverProposalsPage>(Driver);
        }

        public LocalOfficeApproverContractsPage NavigateToContractsPage()
        {
            LoggingService.WriteLogOnMethodEntry();
            IsContractsLinkAvailable();
            MpsUtil.ClickButtonThenNavigateToOtherUrl(Driver, ContractLinkElement);
            return GetTabInstance<LocalOfficeApproverContractsPage>(Driver);
        }

    }
}
