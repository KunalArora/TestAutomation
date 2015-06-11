using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerContractsApprovedProposalsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_ContractList_List_HeaderValidUntil")]
        private IWebElement ValidUntilLabelElement;



        public void IsApprovedProposalContractPageDisplayed()
        {
            if(ValidUntilLabelElement == null)
                throw new Exception("Contracts Approved Proposal page not opened");

            AssertElementPresent(ValidUntilLabelElement, "is Contracts Approved Proposal page?");
        }

        public DealerContractSummaryPage NavigateToDealerContractSummaryPage(IWebDriver driver)
        {
            ActionsModule.ClickOnSpecificContractApprovedProposalActionsDropdown(driver);
            WebDriver.Wait(DurationType.Second, 3);
            ActionsModule.NavigateToSummaryPageUsingActionButton(driver);
            return GetInstance<DealerContractSummaryPage>(Driver);
        }
    }
}
