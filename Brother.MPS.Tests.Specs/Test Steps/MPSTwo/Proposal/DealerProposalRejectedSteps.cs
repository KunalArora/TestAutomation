using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class DealerProposalRejectedSteps : BaseSteps
    {
        [When(@"I navigate to dealer proposal rejected page")]
        public void WhenINavigateToDealerProposalRejectedPage()
        {
            NextPage = CurrentPage.As<CloudExistingProposalPage>().NavigateToDeclinedProposalPage();
        }

        [Then(@"there is no duplicate proposal on the page")]
        public void ThenThereIsNoDuplicateProposalOnThePage()
        {
            CurrentPage.As<DealerProposalsDeclinedPage>().IsDuplicateProposalDisplayed();
        }

    }
}
