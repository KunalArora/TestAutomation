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
    public class DealerAwaitingAcceptanceContractsPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = ".active a[href=\"/mps/dealer/contracts/awaiting-acceptance\"]")]
        private IWebElement OpenedAwaitingAcceptanceTabElement;

        public void IsAwaitingAcceptanceContractDisplayed()
        {
            if(OpenedAwaitingAcceptanceTabElement == null)
                throw new Exception("Opened Awaiting Acceptance Tab not displayed");
            AssertElementPresent(OpenedAwaitingAcceptanceTabElement, "Is Opened Awaiting Acceptance Tab displayed?");
        }

        public void IsSignedContractDisplayed()
        {
           new CloudExistingProposalPage().IsNewProposalTemplateCreated();
        }


    }
}
