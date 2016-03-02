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
    public class DealerClosedProposalPage : BasePage
    {

        public static string URL = "/mps/dealer/proposals/closed";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/proposals/closed\"] span")]
        public IWebElement ClosedProposalTab;
        [FindsBy(How = How.CssSelector, Using = ".open .js-mps-view-summary")]
        public IWebElement ClosedProposalOpenSummaryButton;
        
        
        
        

        public void IsClosedProposalTabOpened()
        {
            if (ClosedProposalTab == null)
                throw new Exception("Closed Proposal tab is not displayed");

            AssertElementPresent(ClosedProposalTab, "Closed proposal page");
        }

        public void IsClosedProposalDisplayed()
        {
            ActionsModule.IsNewlyCreatedItemDisplayed(Driver);
        }

        public void ClickOnClosedProposal()
        {
            ActionsModule.ClickOnSpecificActionsElement(Driver);
        }

        public DealerClosedProposalSummaryPage OpenClosedProposalSummary()
        {
            ClosedProposalOpenSummaryButton.Click();
            return GetInstance<DealerClosedProposalSummaryPage>();
        }

        

        


    }
}
