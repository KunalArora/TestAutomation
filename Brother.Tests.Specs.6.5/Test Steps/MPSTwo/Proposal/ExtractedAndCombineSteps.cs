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
        public void ThenCanDeclineAwaitingApprovalProposalOfWith(string role, string country, string contractType,
            string usageType, string reason)
        {
            CanDeclinedroposalAsAFromAndApprovedBy(role, country, contractType, usageType, reason);
        }

        [Then(@"""(.*)"" can decline ""(.*)"" Leasing Awaiting Approval ""(.*)"" proposal of ""(.*)""")]
        public void ThenCanDeclineLeasingAwaitingApprovalProposalOf(string role, string country, string contractType,
            string usageType)
        {
            BankCanDeclineProposalAsAFromAndApprovedBy(role, country, contractType, usageType);
        }

        [Given(
            @"""(.*)"" Dealer has created ""(.*)"" awaiting acceptance ""(.*)"" contract of ""(.*)"" and ""(.*)"" and ""(.*)"""
            )]
        public void GivenDealerHasCreatedAwaitingAcceptanceContractOfAndAnd(string country, string language,
            string contractType, string usageType, string length, string billing)
        {
            var instance = new CreateATemplateSteps();

            contractType = instance.ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance.GivenDealerHaveCreatedProposalOfOpen(country, language, contractType, usageType, length,
                    billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                    instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                    instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                instance.WhenDealerSignAndNavigateToAwaitingAcceptance();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance.GivenDealerHaveCreatedProposalWithLanguageOfAwaitingApproval(country, language, contractType,
                    usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                    instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                    instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                instance.WhenDealerSignAndNavigateToAwaitingAcceptance();
            }
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

        [Then(@"""(.*)"" can cancel ""(.*)"" Awaiting Approval proposal")]
        public void ThenCanCancelAwaitingApprovalProposal(string role, string country)
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
                instance5.GivenIHaveCreatedPurchaseAndClickProposal();
                instance2.GivenIAmOnProposalListPage();
                instance3.GivenISendTheCreatedProposalForApproval();
                instance3.WhenINavigateToTheSummaryPageOfTheProposalAwaitingApproval();
                instance6.ThenICanCloseTheProposalOnTheSummaryPage();
                instance6.ThenTheClosedProposalSummaryPageHasNoErrorMessage();
                instance4.ThenIfISignOutOfBrotherOnline();
            }

        }


        [Then(@"""(.*)"" can decline ""(.*)"" Awaiting Approval ""(.*)"" and ""(.*)""")]
        public void ThenCanDeclineAwaitingApprovalAnd(string role, string country, string contractType, string usageType)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance3 = new ApproverSteps();
                var instance4 = new AccountManagementSteps();
                var instance5 = new CreateATemplateSteps();

                instance5.GivenDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType);
                instance1.GivenISignIntoMpsasAFrom(role, country);
                instance3.WhenApproverNavigateToOfferPage();
                instance3.GivenApproverNavigateToAwaitingApprovalScreenUnderProposalsPage();
                instance3.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance3.ThenApproverShouldBeAbleToDeclineThatProposal();
                instance3.ThenTheDeclineProposalShouldBeDisplayedUnderDeclinedTabByApprover();
                instance4.ThenIfISignOutOfBrotherOnline();
            }

        }



        [Then(@"I can close a purchase and click awaiting proposal without error on summary page as ""(.*)"" ""(.*)""")]
        public void ThenICanCloseAPurchaseAndClickAwaitingProposalWithoutErrorOnSummaryPageAs(string country,
            string role)
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


        [Then(
            @"""(.*)"" can decline Awaiting Approval ""(.*)"" ""(.*)"" proposal with ""(.*)"" and ""(.*)"" and ""(.*)"""
            )]
        public void ThenCanDeclineAwaitingApprovalProposalWithAndAnd(string role, string country, string contractType,
            string usageType, string length, string billing)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateATemplateSteps();
                var instance4 = new AccountManagementSteps();
                var instance2 = new CreateNewAccountSteps();
                var instance3 = new ApproverSteps();

                instance1.GivenDealerHasCreatedProposalOfAwaitingProposalWithAndAnd(country, contractType, usageType,
                    length, billing);
                instance2.GivenISignIntoMpsasAFrom(role, country);
                instance3.WhenApproverNavigateToOfferPage();
                instance3.GivenApproverNavigateToAwaitingApprovalScreenUnderProposalsPage();
                instance3.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance3.ThenApproverShouldBeAbleToDeclineThatProposal();
                instance3.ThenTheDeclineProposalShouldBeDisplayedUnderDeclinedTabByApprover();
                instance4.ThenIfISignOutOfBrotherOnline();
            }
        }

        [Then(
            @"I can copy the declined English proposal without customer detail as a ""(.*)"" from ""(.*)"" and approved by ""(.*)"""
            )]
        public void ThenICanCopyTheDeclinedEnglishProposalWithoutCustomerDetailAsAFromAndApprovedBy(string role,
            string country, string role2)
        {
            CanCopyDeclinedPurchaseAndClickProposal(role, country, role2, "Without");
        }

        [Then(@"I can copy the declined English proposal as a ""(.*)"" from ""(.*)"" and approved by ""(.*)""")]
        public void ThenICanCopyTheDeclinedEnglishProposalAsAFromAndApprovedBy(string role, string country, string role2)
        {
            CanCopyDeclinedPurchaseAndClickProposal(role, country, role2, "With");
        }


        private void CanCopyDeclinedPurchaseAndClickProposal(string role, string country, string role2,
            string copyOption)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance2 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                var instance3 = new SendProposalToApprover();
                var instance4 = new AccountManagementSteps();
                var instance5 = new LocalOfficeApproverSteps();
                var instance6 = new CreateATemplateSteps();

                instance1.GivenISignIntoMpsasAFrom(role, country);
                instance6.GivenIHaveCreatedPurchaseAndClickProposal();
                instance2.GivenIAmOnProposalListPage();
                instance3.GivenISendTheCreatedProposalToLocalOfficeApproverForApproval();
                instance4.ThenIfISignOutOfBrotherOnline();
                instance1.GivenISignIntoMpsasAFrom(role2, country);
                instance5.WhenIDeclineTheProposalCreatedAboveAsALocalOfficeApprover();
                instance4.ThenIfISignOutOfBrotherOnline();
                instance1.GivenISignIntoMpsasAFrom(role, country);
                instance3.WhenINavigateToDeclineProposalListPage();
                switch (copyOption)
                {
                    case "Without":
                        instance3.ThenICanCopyTheDeclinedProposalWithoutCustomer();
                        break;
                    case "With":
                        instance3.ThenICanCopyTheDeclinedProposalWithCustomer();
                        break;
                }
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

        [Given(
            @"""(.*)"" Dealer with ""(.*)"" have created ""(.*)"" contract choosing ""(.*)"" with ""(.*)"" and ""(.*)"" and ""(.*)"""
            )]
        public void GivenDealerWithHaveCreatedContractChoosingWithAndAnd(string country, string langauge,
            string contractType, string existingCustomer,
            string usageType, string length, string billing)
        {
            ScenarioContext.Current.Pending();
        }



        public void GivenDealerWithLanguageHaveCreatedAContractWithAndAnd(string country, string language, string contractType, string usageType, string length, string billing)
        {
            var instance = new CreateATemplateSteps();
            
            contractType = instance.ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance.GivenDealerHaveCreatedProposalWithLanguageOfAwaitingApproval(country, language, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                    instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                    instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                instance.WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance.GivenDealerHaveCreatedProposalWithLanguageOfAwaitingApproval(country, language, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                    instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                    instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                instance.WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }

        public void GivenDealerHaveCreatedAContractWithAndAnd(string country, string contractType, string customer,
            string usageType, string length, string billing)
        {
            var instance = new CreateATemplateSteps();

            contractType = instance.ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance.GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, customer, usageType,
                    length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                    instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                    instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                instance.WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance.GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, customer, usageType,
                    length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                    instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                    instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                instance.WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }

        }
    }
}
