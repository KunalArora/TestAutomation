using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.MPSTwo
{
    public class DealerProposalsAwaitingApproval : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        //[FindsBy(How = How.CssSelector, Using = "#content_1_InputSendToLeasingBank_Label")]
        //private IWebElement ThirdPartyApproval;


        private static string CreatedProposal()
        {
            var createdProposal = SpecFlow.GetContext("GeneratedProposalName");
            return createdProposal;
        }

        public void IsProposalSentToDealerAwaitingProposalPage()
        {
            var createdProposal = CreatedProposal();

            ActionsModule.SearchForNewlyProposalItem(Driver, createdProposal);

            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

        public DealerProposalsCreateSummaryPage NavigateToViewSummary()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
            ActionsModule.NavigateToSummaryPageUsingActionButton(Driver);

            return GetTabInstance<DealerProposalsCreateSummaryPage>(Driver);
        }
    }
}
