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
    public class DealerClosedProposalSummaryPage : BasePage
    {

        public static string URL = "/mps/dealer/proposals/closed";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#content_1_ButtonBack")]
        public IWebElement ClosedProposalSummaryBackButton;
        [FindsBy(How = How.CssSelector, Using = ".mps-qa-printer")]
        public IWebElement ClosedProposalSummaryPrinter;


        public DealerClosedProposalPage ReturnToClosedProposalList()
        {
            ScrollTo(ClosedProposalSummaryBackButton);
            ClosedProposalSummaryBackButton.Click();

            return GetInstance<DealerClosedProposalPage>();
        }


        public void IsClosedProposalSummaryPageDisplayed()
        {
            if (ClosedProposalSummaryPrinter == null)
                throw new Exception("Summary page printer not displayed");

            TestCheck.AssertIsEqual(true, ClosedProposalSummaryPrinter.Displayed, "Summary page not displayed");
        }


    }
}
