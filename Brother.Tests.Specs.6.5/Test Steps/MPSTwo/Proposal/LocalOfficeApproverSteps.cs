using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.Test_Steps.MPSTwo.Proposal
{
    [Binding]
    public class LocalOfficeApproverSteps : BaseSteps
    {
        [When(@"I navigate to Local Office Approver contract Awaiting Acceptance page")]
        public void WhenINavigateToLocalOfficeApproverContractAwaitingAcceptancePage()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToContractPage();
            CurrentPage.As<LocalOfficeApproverContractPage>().NavigateToAwaitingAcceptanceTab();
        }

        [When(@"I navigate to Local Office Approver contract Rejected page")]
        public void WhenINavigateToLocalOfficeApproverContractRejectedPage()
        {
            NextPage = CurrentPage.As<LocalOfficeApproverDashBoardPage>().NavigateToContractPage();
            CurrentPage.As<LocalOfficeApproverContractPage>().NavigateToRejectTab();
        }

        [Then(@"I can successfully download a Local Approver Contract PDF")]
        public void ThenICanSuccessfullyDownloadALocalApproverContractPDF()
        {
            CurrentPage.As<LocalOfficeApproverContractPage>().DownloadPDFOnBankContractPages();
        }

        [Then(@"I can successfully download a Local Approver Contract Invoice PDF")]
        public void ThenICanSuccessfullyDownloadALocalApproverContractInvoicePDF()
        {
            CurrentPage.As<LocalOfficeApproverContractPage>().DownloadInvoicePDFOnBankContractPages();
        }


    }
}
