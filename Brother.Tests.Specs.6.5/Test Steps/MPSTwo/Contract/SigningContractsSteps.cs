using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Contract
{
    [Binding]
    public class SigningContracts : BaseSteps
    {
        [When(@"I navigate to dealer contract approved proposal page")]
        public void WhenINavigateToDealerContractApprovedProposalPage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            CurrentPage.As<DealerContractsPage>().IsApprovedProposalContractPageDisplayed();
        }

        [Then(@"I can start the process of signing the contract")]
        public void ThenICanStartTheProcessOfSigningTheContract()
        {
            NextPage = CurrentPage.As<DealerContractsPage>().NavigateToDealerContractSummaryPage(CurrentDriver);
        }

        [Then(@"I can successfully sign the contract")]
        public void ThenICanSuccessfullySignTheContract()
        {
            CurrentPage.As<DealerContractsSummaryPage>().IsContractSummaryPageDisplayed();
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().DealerSignsApprovedProposal();
            CurrentPage.As<DealerContractsPage>().IsAwaitingAcceptanceContractDisplayed();
            CurrentPage.As<DealerContractsPage>().IsSignedContractDisplayed();

        }

    }
}
