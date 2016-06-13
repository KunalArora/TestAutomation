using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class LocalOfficeApproverSteps : BaseSteps
    {
        [When(@"I navigate to Local Office Approver contract Awaiting Acceptance page")]
        public void WhenINavigateToLocalOfficeApproverContractAwaitingAcceptancePage()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
            NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToContractsPage();
            CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToAwaitingAcceptancePage();
        }

        [When(@"I navigate to Local Office Approver contract Rejected page")]
        public void WhenINavigateToLocalOfficeApproverContractRejectedPage()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
            NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToContractsPage();
            CurrentPage.As<LocalOfficeApproverContractsPage>().NavigateToRejectedPage();
        }

        [Then(@"I can successfully download a Local Approver Contract PDF")]
        public void ThenICanSuccessfullyDownloadALocalApproverContractPDF()
        {
            CurrentPage.As<LocalOfficeApproverContractsPage>().DownloadPDFOnBankContractPages();
        }

        [Then(@"I can successfully verify that Contract is downloaded")]
        public void ThenICanSuccessfullyVerifyThatContractIsDownloaded()
        {
            CurrentPage.As<LocalOfficeApproverContractsPage>().GetDownloadedPdfPath();
            CurrentPage.As<LocalOfficeApproverContractsPage>().DisplayDownloadedPdf();
            CurrentPage.As<LocalOfficeApproverContractsPage>().DoesPdfContentContainSomeText();
        }

        [When(@"I decline the proposal created above as a Local Office Approver")]
        public void WhenIDeclineTheProposalCreatedAboveAsALocalOfficeApprover()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToOfficeApproverApprovalPage();
            NextPage = CurrentPage.As<LocalOfficeApproverApprovalPage>().NavigateToProposalsPage();
            CurrentPage.As<LocalOfficeApproverProposalsPage>().ClickOnActionButtonAgainstRelevantProposal();
            CurrentPage.As<LocalOfficeApproverProposalsPage>().NavigateToAwaitingApprovalSummaryPage();
            CurrentPage.As<LocalOfficeApproverProposalsPage>().DeclineAnAwaitingApprovalProposal();
            CurrentPage.As<LocalOfficeApproverProposalsPage>().IsProposalDeclined();

        }



    }
}
