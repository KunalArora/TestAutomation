using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Specs.BrotherOnline.Account;
using Brother.Tests.Specs.MPSTwo.Approver;
using Brother.Tests.Specs.MPSTwo.SendToBank;
using Brother.WebSites.Core.Pages.Base;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class ExtractedAndCombineSteps : BaseSteps
    {


        [Given(@"I verify and store proposal bypass status")]
        public void GivenIVerifyAndStoreProposalBypassStatus()
        {
            // Do nothing really for now
        }


        [Then(@"""(.*)"" can decline ""(.*)"" Awaiting Approval ""(.*)"" proposal of ""(.*)"" with ""(.*)""")]
        public void ThenCanDeclineAwaitingApprovalProposalOfWith(string role, string country, string contractType, string usageType, string reason)
        {
            CanDeclinedroposalAsAFromAndApprovedBy(role,country, contractType, usageType, reason);
        }

        [Then(@"""(.*)"" can decline ""(.*)"" Leasing Awaiting Approval ""(.*)"" proposal of ""(.*)""")]
        public void ThenCanDeclineLeasingAwaitingApprovalProposalOf(string role, string country, string contractType, string usageType)
        {
            BankCanDeclineProposalAsAFromAndApprovedBy(role, country, contractType, usageType);
        }


        [Then(@"I can close an awaiting proposal without error on summary page as ""(.*)"" ""(.*)""")]
        public void ThenICanCloseAnAwaitingProposalWithoutErrorOnSummaryPageAs(string country, string role)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance2 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                var instance3 = new SendProposalToApprover();
                var instance4 = new AccountManagementSteps();
                var instance5 = new CreateATemplateSteps();
                var instance6 = new ProposalSummaryPageSteps();

                instance1.GivenISignIntoMpsasAFrom(role, country);
                instance5.GivenIHaveCreatedGermanLeasingAndClickProposal();
                instance2.GivenIAmOnProposalListPage();
                instance3.GivenISendTheCreatedGermanProposalForApproval();
                instance3.WhenINavigateToTheSummaryPageOfTheProposalAwaitingApproval();
                instance6.ThenICanCloseTheProposalOnTheSummaryPage();
                instance6.ThenTheClosedProposalSummaryPageHasNoErrorMessage();
                instance4.ThenIfISignOutOfBrotherOnline();


            }
        }


        [Then(@"I can close a purchase and click awaiting proposal without error on summary page as ""(.*)"" ""(.*)""")]
        public void ThenICanCloseAPurchaseAndClickAwaitingProposalWithoutErrorOnSummaryPageAs(string country, string role)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance2 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                var instance3 = new SendProposalToApprover();
                var instance4 = new AccountManagementSteps();
                var instance5 = new CreateATemplateSteps();
                var instance6 = new ProposalSummaryPageSteps();

                instance1.GivenISignIntoMpsasAFrom(role, country);
                instance5.GivenIHaveCreatedGermanPurchaseAndClickProposal();
                instance2.GivenIAmOnProposalListPage();
                instance3.GivenISendTheCreatedGermanProposalForApproval();
                instance3.GivenISendTheCreatedGermanProposalForApproval();
                instance3.WhenINavigateToTheSummaryPageOfTheProposalAwaitingApproval();
                instance6.ThenICanCloseTheProposalOnTheSummaryPage();
                instance6.ThenTheClosedProposalSummaryPageHasNoErrorMessage();
                instance4.ThenIfISignOutOfBrotherOnline();

            }
        }

        [Given(@"I approve Leasing and Click proposal as a ""(.*)"" from ""(.*)""")]
        public void GivenIApproveLeasingAndClickProposalAsAFrom(string role, string country)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance2 = new BankSteps();
                var instance4 = new AccountManagementSteps();

                instance1.GivenISignIntoMpsasAFrom(role, country);
                instance2.GivenIApproveTheProposalCreatedAbove();
                instance4.ThenIfISignOutOfBrotherOnline();
            }
        }

        [Given(@"I approve purchase and click proposal as a ""(.*)"" from ""(.*)""")]
        public void GivenIApprovePurchaseAndClickProposalAsAFrom(string role, string country)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance4 = new AccountManagementSteps();
                var instance2 = new Approver.LocalOfficeApproverSteps();

                instance1.GivenISignIntoMpsasAFrom(role, country);
                instance2.GivenIApproveThepurchaseAndClickProposalCreatedAbove();
                instance4.ThenIfISignOutOfBrotherOnline();

            }
        }


        private void CanDeclinedroposalAsAFromAndApprovedBy(string role, string country,
           string contractType, string usageType, string reason)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance2 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                var instance3 = new ApproverSteps();
                var instance4 = new AccountManagementSteps();
                var instance5 = new CreateATemplateSteps();

                instance5.GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country);
                instance1.GivenISignIntoMpsasAFrom(role, country);
                instance3.WhenApproverNavigateToOfferPage();
                instance3.GivenApproverNavigateToAwaitingApprovalScreenUnderProposalsPage();
                instance3.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance3.ThenApproverShouldBeAbleToDeclineThatProposalWith(reason);
                instance3.ThenTheDeclineProposalShouldBeDisplayedUnderDeclinedTabByApprover();
                instance4.ThenIfISignOutOfBrotherOnline();
            }

        }

        private void BankCanDeclineProposalAsAFromAndApprovedBy(string role, string country,
           string contractType, string usageType)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance2 = new BankSteps();
                var instance3 = new ApproverSteps();
                var instance4 = new AccountManagementSteps();
                var instance5 = new CreateATemplateSteps();

                instance5.GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country);
                instance1.GivenISignIntoMpsasAFrom(role, country);
                instance2.GivenIApproveTheProposalCreatedAbove();
                instance4.ThenIfISignOutOfBrotherOnline();
            }

        }
    }
}
