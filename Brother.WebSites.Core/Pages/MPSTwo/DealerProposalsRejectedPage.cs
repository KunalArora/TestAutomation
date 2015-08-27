using System;
using System.Collections;
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


    public class DealerProposalsRejectedPage : BasePage
    {

        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }


        [FindsBy(How = How.CssSelector, Using = ".js-mps-download-proposal-pdf")]
        public IList<IWebElement> AttachedProposalId;



        public void IsDuplicateProposalDisplayed()
        {
            var container = new List<string>();
            var noOfProposalId = AttachedProposalId.Count;
            

            for(var i=0; i<AttachedProposalId.Count; i++)
            {
                ActionsModule.ClickOnTheActionsDropdown(i, Driver);
                var proposalId = AttachedProposalId.ElementAt(i).GetAttribute("data-proposal-id");

                container.Add(proposalId);
                
                ActionsModule.ClickOnTheActionsDropdown(i, Driver);
            }

            var numberOfDistinct = container.Distinct().Count();

            TestCheck.AssertIsEqual(true, noOfProposalId == (numberOfDistinct), "");
        }
        


    }
}
