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

        [When(@"I navigate to Local Office Approver Reporting page")]
        public void WhenINavigateToLocalOfficeApproverReportingPage()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToLocalOfficeApproverReportingPage();

        }

        [When(@"I navigate to Local Office Admin Reporting page")]
        public void WhenINavigateToLocalOfficeAdminReportingPage()
        {
            NextPage = CurrentPage.As<LocalOfficeAdminDashBoardPage>().NavigateToReportPage();
        }

        [When(@"I navigate to Service Desk Reporting page")]
        public void WhenINavigateToServiceDeskReportingPage()
        {
             NextPage = CurrentPage.As<ServiceDeskDashBoardPage>().NavigateToServiceDeskReportPage();
        }

        [When(@"I navigate to Dealer Reporting page")]
        public void WhenINavigateToDealerReportingPage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToReportPage();
            
        }



        [When(@"I click on the first proposal link displayed")]
        public void WhenIClickOnTheFirstProposalLinkDisplayed()
        {
            NextPage = CurrentPage.As<DataQueryPage>().ClickOnTheFirstProposal();
        }


        [When(@"I click on Edit Comment button on summary page")]
        public void WhenIClickOnEditCommentButtonOnSummaryPage()
        {
            NextPage = CurrentPage.As<ReportProposalSummaryPage>().NavigateToProposalNotePage();
        }

        [Then(@"Comment button is not displayed on Summary page")]
        public void ThenCommentButtonIsNotDisplayedOnSummaryPage()
        {
            CurrentPage.As<ReportProposalSummaryPage>().ProposalNoteButtonIsNotDisplayed();
        }


        [When(@"I enter some comment in the comment box")]
        public void WhenIEnterSomeCommentInTheCommentBox()
        {
            CurrentPage.As<DataQueryProposalNotePage>().EnterSomeNoteToTextArea();
            NextPage = CurrentPage.As<DataQueryProposalNotePage>().SaveTheNoteAdded();
        }

        [When(@"I enter ""(.*)"" in the comment box")]
        public void WhenIEnterInTheCommentBox(string text)
        {
            CurrentPage.As<DataQueryProposalNotePage>().EnterSomeNoteToTextArea(text);
            NextPage = CurrentPage.As<DataQueryProposalNotePage>().SaveTheNoteAdded();
        }


        [Then(@"the text added to the comment box is displayed on summary page")]
        public void ThenTheTextAddedToTheCommentBoxIsDisplayedOnSummaryPage()
        {
           CurrentPage.As<ReportProposalSummaryPage>().IsCommentSectionDisplayed();
        }

        [Then(@"the ""(.*)"" added to the comment box is displayed on summary page")]
        public void ThenTheAddedToTheCommentBoxIsDisplayedOnSummaryPage(string text)
        {
            CurrentPage.As<ReportProposalSummaryPage>().IsCommentTextDisplayed(text);
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
