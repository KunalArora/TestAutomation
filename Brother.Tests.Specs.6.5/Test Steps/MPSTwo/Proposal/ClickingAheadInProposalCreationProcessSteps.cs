using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class ClickingAheadInProposalCreationProcessSteps : BaseSteps
    {
        [When(@"I click on ""(.*)"" tab")]
        public void WhenIClickOnTab(string tabToClick)
        {
            CurrentPage.As<CreateNewProposalPage>().ClickOnProposalTabsTransform(tabToClick);
        }
        
        [Then(@"I am redirected to ""(.*)"" screen")]
        public void ThenIAmRedirectedToScreen(string screenToConfirm)
        {
            CurrentPage.As<CreateNewProposalPage>().VerifyProposalScreenAfterNavigation(screenToConfirm);
        }
    }
}
