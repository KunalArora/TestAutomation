using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DataQueryPage : BasePage
    {

        private const string SelectedProposal = @"#proposal-{0} .js-mps-proposal-link";


        [FindsBy(How = How.CssSelector, Using = "#content_0_txtInputSearch")]
        public IWebElement DataQuerySearchField;
        [FindsBy(How = How.CssSelector, Using = "#content_0_ButtonSpecialPricing")]
        public IWebElement SpecialPricingButton;
        [FindsBy(How = How.CssSelector, Using = "#TableProposalAudit")]
        public IWebElement SpecialPricingAuditConfirmationTable;
        
        


        public void SearchForNewlyCreatedProposal()
        {
            var proposal = MpsUtil.CreatedProposal();
            DataQuerySearchField.Clear();
            DataQuerySearchField.SendKeys(proposal);
        }

        public void ClickOnSearchedProposal()
        {
            var contractid = SpecFlow.GetContext("SummaryPageContractId");
            var displayedProposal = string.Format(SelectedProposal, contractid);
            var proposalElement = Driver.FindElement(By.CssSelector(displayedProposal));

            proposalElement.Click();
        }

        public ProposalSpecialPricingPage NavigateToProposalSpecialPricingPage()
        {
            SpecialPricingButton.Click();

            return new ProposalSpecialPricingPage();
        }
    }
}
