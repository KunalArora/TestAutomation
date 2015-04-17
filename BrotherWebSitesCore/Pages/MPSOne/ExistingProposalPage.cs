using System;
using BrotherWebSitesCore.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BrotherWebSitesCore.Pages.MPSOne
{
    public class ExistingProposalPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.Id, Using = "proposal-search")]
        public IWebElement ProposalHeader;

        public void IsProposalHeaderAvailable()
        {
            if (ProposalHeader == null)
            {
                throw new Exception("Unable to locate Proposal Header on page");
            }
            AssertElementPresent(ProposalHeader, "Proposal Header");
        }
    }
}
