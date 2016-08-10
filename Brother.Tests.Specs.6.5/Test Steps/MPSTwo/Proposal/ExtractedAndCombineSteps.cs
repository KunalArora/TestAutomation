using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.MPS;
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

        [Then(@"""(.*)"" can decline Awaiting ""(.*)"" Approval ""(.*)"" ""(.*)"" proposal with ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void ThenCanDeclineAwaitingApprovalProposalWithAndAnd(string role, string language, string country, string contractType, 
            string usageType, string length, string billing)
        {
            ThenCanDeclineAwaitingApprovalProposalWithLanguageAndAnd(role, language, country, 
                contractType, usageType, length, billing);
        }

        [Given(@"I have created a ""(.*)"" ""(.*)""proposal with ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenIHaveCreatedAProposalWithAndAnd(string contractType, string language, string usageType, string length,
            string billing)
        {
            GivenIHaveCreatedAProposalWithLanguageAndAnd(contractType, language, usageType, length, billing);
        }


        public void GivenIHaveCreatedAProposalWithLanguageAndAnd(string contractType, string language, string usageType, string length,
            string billing)
        {
            var instance = new CreateATemplateSteps();
            contractType = instance.ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance.GivenIHaveCreatedLeasingAndClickProposalWithLanguage(contractType, language, usageType, length, billing);
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance.GivenIHaveCreatedPurchaseAndClickProposalWithLanguage(contractType, language, usageType, length,
                    billing);
            }

        }



        public void ThenCanDeclineAwaitingApprovalProposalWithLanguageAndAnd(string role, string language, string country, string contractType,
            string usageType, string length, string billing)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateATemplateSteps();
                var instance4 = new AccountManagementSteps();
                var instance2 = new CreateNewAccountSteps();
                var instance3 = new ApproverSteps();

                instance1.GivenDealerHaveCreatedProposalWithLanguageOfAwaitingApproval(country, language, contractType, usageType,
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
            GivenDealerWithLanguageHaveCreatedAContractWithAndAnd(country, langauge, contractType, existingCustomer, usageType, length, billing);
        }


        public void GivenDealerHaveCreatedProposalWithLanguageOfAwaitingApproval(string country, string language, string contractType, string existingCustomer, 
            string usageType, string length, string billing)
        {
            var instance = new CreateATemplateSteps();

            contractType = instance.ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpenWithLanguageWithExistingCustomer(country, language, contractType, existingCustomer, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonToNavigateToConvertSummaryPage();
                //instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                    instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                }

                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpenWithLanguageWithExistingCustomer(country, language, contractType, existingCustomer, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonToNavigateToConvertSummaryPage();
                //instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                    instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                }

                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        public void GivenDealerWithLanguageHaveCreatedAContractWithAndAnd(string country, string language, string contractType, string existingCustomer, string usageType, string length, string billing)
        {
            var instance = new CreateATemplateSteps();
            
            contractType = instance.ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalWithLanguageOfAwaitingApproval(country, language, contractType, existingCustomer,usageType, length, billing);
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
                GivenDealerHaveCreatedProposalWithLanguageOfAwaitingApproval(country, language, contractType, existingCustomer, usageType, length, billing);
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


        public void GivenDealerHaveCreatedProposalOfOpenWithLanguageWithExistingCustomer(string country, string language, string contractType, string customer,
            string usageType, string length, string billing)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);

            var instance2 = new CreateATemplateSteps();

            contractType = instance2.ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposalWithLanguageAndCustomer(contractType, language, customer, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposalWithLanguageAndCustomer(contractType, language, customer, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        public void GivenIHaveCreatedLeasingAndClickProposalWithLanguageAndCustomer(string contractType, string language, 
            string customer, string usageType, string length, string billing)
        {

            var instance2 = new CreateATemplateSteps();

            contractType = instance2.ContractType(contractType);
            instance2.GivenIChangeTheLanguageDisplayed(language);
            instance2.GivenIamOnMpsNewProposalPage();
            instance2.WhenIFillProposalDescriptionForContractType(contractType);
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.SelectASpecificExistingCustomer(customer); 
            var termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (usageType, length, "Quarterly in Advance", billing);

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }

        
        private void GivenIHaveCreatedPurchaseAndClickProposalWithLanguageAndCustomer(string contractType, string language, string customer, 
            string usageType, string length, string billing)
        {
            var instance2 = new CreateATemplateSteps();

            contractType = instance2.ContractType(contractType);

            
            instance2.GivenIChangeTheLanguageDisplayed(language);
            instance2.GivenIamOnMpsNewProposalPage();
            instance2.WhenIFillProposalDescriptionForContractType(contractType);
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.SelectASpecificExistingCustomer(customer);
            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");

        }
    }
}
