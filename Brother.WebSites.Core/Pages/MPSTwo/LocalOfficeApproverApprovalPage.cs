using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class LocalOfficeApproverApprovalPage : BasePage
    {
        public static string Url = "/";

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
