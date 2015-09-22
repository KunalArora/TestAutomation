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
    public class DealerApprovedProposalPage : BasePage
    {
        public static string URL = "/mps/proposals/in-progress";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }


        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/proposals/approved\"]")]
        private IWebElement ApprovedProposalOpenedTab;


        public void IsApprovedProposalTabOpened()
        {
            if(ApprovedProposalOpenedTab == null)
                throw new Exception("Approved proposals tab is not displayed");
            AssertElementPresent(ApprovedProposalOpenedTab, "Approved proposal tab");
        }


        public DealerProposalsCreateSummaryPage NavigateToDealerContractSummaryPage()
        {
            ActionsModule.ClickOnSpecificActionsElement();
            WebDriver.Wait(DurationType.Second, 3);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);
            return GetInstance<DealerProposalsCreateSummaryPage>(Driver);
        }

    }
}
