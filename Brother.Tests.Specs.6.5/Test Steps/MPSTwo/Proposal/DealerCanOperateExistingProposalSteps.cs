using System;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPSTwo.Proposal
{
    [Binding]
    public class DealerCanOperateProposalOffersSteps : BaseSteps
    {
        [Given(@"I navigate to existing proposal screen")]
        public void GivenINavigateToExistingProposalScreen()
        {
            CurrentPage = CurrentPage.As<DealerDashBoardPage>().NavigateToExistingProposalPage();
        }

        [Then(@"I can see the Existing Proposal table")]
        public void ThenICanSeeTheExistingProposalTable()
        {
            CurrentPage.As<CloudExistingProposalPage>().FindExistingPoposalList();
        }

    }
}
