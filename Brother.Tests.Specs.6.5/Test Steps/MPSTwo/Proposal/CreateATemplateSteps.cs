using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.Tests.Specs.BrotherOnline.Account;
using Brother.Tests.Specs.MPSTwo.Approver;
using Brother.Tests.Specs.MPSTwo.SendToBank;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;
using SpecFlow = Brother.Tests.Selenium.Lib.Support.HelperClasses.SpecFlow;


namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class CreateATemplateSteps : BaseSteps
    {
        [When(@"I am on MPS New Proposal Page")]
        [Given(@"I am on MPS New Proposal Page")]
        public void GivenIamOnMpsNewProposalPage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToCreateNewProposalPage();
        }

        [Given(@"Dealer have created a Open proposal of ""(.*)"" and ""(.*)""")]
        public void GivenDealerHaveCreatedProposalOfOpen(string ContractType, string UsageType)
        {
            if (ContractType.Equals("Lease & Click with Service"))
            {
                var instance4 = new CreateNewAccountSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                GivenIHaveCreatedLeasingAndClickProposal(UsageType);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (ContractType.Equals("Purchase & Click with Service"))
            {
                var instance4 = new CreateNewAccountSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                GivenIHaveCreatedPurchaseAndClickProposal(UsageType);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }


        public void GivenDealerHaveCreatedProposalOfOpen(string country, string contractType, string usageType)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                var instance4 = new CreateNewAccountSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposal(usageType);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                var instance4 = new CreateNewAccountSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposal(usageType);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        

        public void GivenDealerHaveCreatedProposalOfOpen(string country, string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                var instance4 = new CreateNewAccountSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposal(contractType, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                var instance4 = new CreateNewAccountSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposal(contractType, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        public void GivenDealerHaveCreatedProposalOfOpenWithLanguage(string country, string language, string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                var instance4 = new CreateNewAccountSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposalWithLanguage(contractType, language, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                var instance4 = new CreateNewAccountSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposalWithLanguage(contractType, language, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        public void GivenDealerHaveCreatedProposalOfOpen(string country, string contractType, string customer, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                var instance4 = new CreateNewAccountSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposal(contractType, customer, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                var instance4 = new CreateNewAccountSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposal(contractType, customer, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        [Given(@"Dealer have created a Awaiting Approval proposal of ""(.*)"" and ""(.*)""")]
        public void GivenDealerHaveCreatedProposalOfAwaitingApproval(string ContractType, string UsageType)
        {
            if (ContractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpen(ContractType, UsageType);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();
                instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (ContractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpen(ContractType, UsageType);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();
                instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        public void GivenDealerHaveCreatedProposalOfAwaitingApproval(string country, string contractType, string usageType)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpen(country, contractType, usageType);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();
                instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpen(country, contractType, usageType);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();
                instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }



        [Given(@"""(.*)"" dealer has created ""(.*)"" proposal of awaiting proposal with ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenDealerHasCreatedProposalOfAwaitingProposalWithAndAnd(string country, string contractType, string usageType, string length, string billing)
        {
            GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, usageType, length, billing);
        }

        public void GivenDealerHaveCreatedProposalOfAwaitingApproval(string country, string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpen(country, contractType, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();
                instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpen(country, contractType, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();
                instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }

        public void GivenDealerHaveCreatedProposalWithLanguageOfAwaitingApproval(string country, string language, string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpenWithLanguage(country, language, contractType, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();
                instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpenWithLanguage(country, language, contractType, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();
                instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }

        public void GivenDealerHaveCreatedProposalOfAwaitingApproval(string country, string contractType, string customer, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpen(country, contractType, customer, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonToNavigateToConvertSummaryPage();
                //instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();
                instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpen(country, contractType, customer, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonToNavigateToConvertSummaryPage();
                //instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                instance2.ThenIAmTakenToTheProposalSummaryWhereICanEnterEnvisageContractStartDate();
                instance2.ThenICanSuccessfullyConvertTheProposalToContract();
                instance2.ThenTheNewlyConvertedContractIsAvailableUnderAwaitingApprovalTab();
                instance2.ThenINavigateToProposalSummaryPageUnderAwaitingApprovalTab();
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        [Given(@"Dealer have created an Awaiting Approval proposal of ""(.*)"" and ""(.*)"" from ""(.*)""")]
        public void GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(string ContractType, string UsageType, string Country)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", Country);

            if (ContractType.Equals("Leasing & Service"))
            {
                
                GivenIHaveCreatedGermanLeasingAndClickProposal(UsageType);

                var instance1 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance1.GivenIAmOnProposalListPage();

                var instance2 = new SendProposalToApprover();
                instance2.GivenISendTheCreatedGermanProposalForApproval();

                
                
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (ContractType.Equals("Easy Print Pro & Service"))
            {
                GivenIHaveCreatedGermanPurchaseAndClickProposal(UsageType);

                var instance1 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance1.GivenIAmOnProposalListPage();

                var instance2 = new SendProposalToApprover();
                instance2.GivenISendTheCreatedGermanProposalForApproval();

                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        public void GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(string ContractType, string UsageType, string Country, string customer)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", Country);

            if (ContractType.Equals("Leasing & Service"))
            {

                GivenIHaveCreatedGermanLeasingAndClickProposal(UsageType);

                var instance1 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance1.GivenIAmOnProposalListPage();

                var instance2 = new SendProposalToApprover();
                instance2.GivenISendTheCreatedGermanProposalForApproval(customer);



                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (ContractType.Equals("Easy Print Pro & Service"))
            {
                GivenIHaveCreatedGermanPurchaseAndClickProposal(UsageType);

                var instance1 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance1.GivenIAmOnProposalListPage();

                var instance2 = new SendProposalToApprover();
                instance2.GivenISendTheCreatedGermanProposalForApproval(customer);

                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }

        private string ContractType(string type)
        {
            if (type == "Acquisto + Consumo con assistenza" || type == "Buy & Click"
                || type == "Purchase & Click con Service" || type == "Kjøp og klikk med service" || type == "Purchase & click inklusive service")
            {
                type = "Purchase & Click with Service";
            }

            return type;
        }


        [Given(@"""(.*)"" Dealer has created an awaiting acceptance ""(.*)"" contract of ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenDealerHasCreatedAnAwaitingAcceptanceContractOfAndAnd(string country, string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpen(country, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                WhenDealerSignAndNavigateToAwaitingAcceptance();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                WhenDealerSignAndNavigateToAwaitingAcceptance();
            }
        }

        [Given(@"""(.*)"" Dealer have created ""(.*)"" contract choosing ""(.*)"" with ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenDealerHaveCreatedContractChoosingWithAndAnd(string country, string contractType, string customer, string usageType, string length, string billing)
        {
            GivenDealerHaveCreatedAContractWithAndAnd(country, contractType, customer, usageType, length, billing);
        }
        
        public void GivenDealerHaveCreatedAContractWithAndAnd(string country, string contractType, string customer, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, customer, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, customer, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        [Given(@"""(.*)"" Dealer with ""(.*)"" language have created a ""(.*)"" contract with ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenDealerWithLanguageHaveCreatedAContractWithAndAnd(string country, string language, string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalWithLanguageOfAwaitingApproval(country, language, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalWithLanguageOfAwaitingApproval(country, language, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }



        [Given(@"""(.*)"" Dealer have created a ""(.*)"" contract with ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenDealerHaveCreatedAContractWithAndAnd(string country, string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            
            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }
        

        [Given(@"Dealer have created a contract of ""(.*)"" and ""(.*)""")]
        public void GivenDealerHaveCreatedAContractOfAnd(string ContractType, string UsageType)
        {
            if (ContractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", "United Kingdom");
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (ContractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", "United Kingdom");
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        public void GivenDealerHaveCreatedAContractWithExistingCustomerOfAnd(string customer, string ContractType, string UsageType)
        {
            if (ContractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", "United Kingdom");
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (ContractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", "United Kingdom");
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        [Given(@"Dealer has created an awaiting acceptance contract of ""(.*)"" and ""(.*)""")]
        public void GivenDealerHasCreatedAnAwaitingAcceptanceContractOfAnd(string ContractType, string UsageType)
        {
            if (ContractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", "United Kingdom");
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenDealerSignAndNavigateToAwaitingAcceptance();
            }
            else if (ContractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", "United Kingdom");
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenDealerSignAndNavigateToAwaitingAcceptance();
            }
        }


        [Given(@"German Dealer have created a ""(.*)"" awating acceptance contract of ""(.*)"" and ""(.*)""")]
        public void GivenGermanDealerHaveCreatedAAwatingAcceptanceContractOfAnd(string Country, string ContractType, string UsageType)
        {
            if (ContractType.Equals("Leasing & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType, Country);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", Country);
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", Country);
                WhenISignTheContractToNavigateToAwaitingAcceptance();
            }
            else if (ContractType.Equals("Easy Print Pro & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType, Country);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", Country);
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", Country);
                WhenISignTheContractToNavigateToAwaitingAcceptance();
            }
        }


        [Given(@"""(.*)"" Dealer have created a ""(.*)"" contract choosing ""(.*)"" with ""(.*)""")]
        public void GivenGermanDealerHaveCreatedAAwatingAcceptanceContractOfAnd(string country, string contractType, string usageType, string customer)
        {
            if (contractType.Equals("Leasing & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country, customer);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                WhenISignTheContractToNavigateToAwaitingAcceptance();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Easy Print Pro & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country, customer);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                WhenISignTheContractToNavigateToAwaitingAcceptance();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        [Given(@"German Dealer have created a ""(.*)"" contract of ""(.*)"" and ""(.*)""")]
        public void GivenGermanDealerHaveCreatedAContractOfAnd(string Country, string ContractType, string UsageType)
        {
            if (ContractType.Equals("Leasing & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType, Country);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", Country);
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", Country);
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (ContractType.Equals("Easy Print Pro & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType, Country);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", Country);
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", Country);
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }

        [Given(@"German Dealer have created a signed ""(.*)"" contract of ""(.*)"" and ""(.*)""")]
        public void GivenGermanDealerHaveCreatedASignedContractOfAnd(string Country, string ContractType, string UsageType)
        {
            if (ContractType.Equals("Leasing & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType, Country);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", Country);
                instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", Country);
                WhenISignTheContractToNavigateToAwaitingAcceptance();
                //instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (ContractType.Equals("Easy Print Pro & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType, Country);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", Country);
                instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                var instance5 = new ApproverSteps();
                instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                instance5.ThenIShouldBeAbleToApproveThatProposal();
                instance3.ThenIfISignOutOfBrotherOnline();
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", Country);
                WhenISignTheContractToNavigateToAwaitingAcceptance();
                //instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        private void WhenISignTheContractAsADealer()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            NextPage = CurrentPage.As<DealerContractsPage>().NavigateToViewOfferOnApprovedProposalsTab();
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().ClickSignButtonToNavigateToAwaitingAcceptance();
        }

        private void WhenDealerSignAndNavigateToAwaitingAcceptance()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            NextPage = CurrentPage.As<DealerContractsPage>().NavigateToViewOfferOnApprovedProposalsTab();
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().ClickSignButtonToNavigateToAwaitingAcceptance();
        }

        private void WhenISignTheContractToNavigateToAwaitingAcceptance()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            NextPage = CurrentPage.As<DealerContractsPage>().NavigateToViewOfferOnApprovedProposalsTab();
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().DealerSignsApprovedProposalTAwaitingAcceptancePage();
        }

        private void GivenIHaveCreatedLeasingAndClickProposal(string UsageType)
        {
            if (UsageType.Equals(string.Empty))
                UsageType = "Minimum Volume";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType("Lease & Click with Service");
            DealerProposalsCreateCustomerInformationStep customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            DealerProposalsCreateTermAndTypeStep termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (UsageType, "3 years", "Quarterly in Advance", "Quarterly in Arrears");

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }


        private void GivenIHaveCreatedLeasingAndClickProposal(string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            DealerProposalsCreateCustomerInformationStep customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            DealerProposalsCreateTermAndTypeStep termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (usageType, length, "Quarterly in Advance", billing);

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }

        private void GivenIHaveCreatedLeasingAndClickProposal(string contractType, string customer, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            DealerProposalsCreateCustomerInformationStep customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.SelectASpecificExistingCustomer(customer);
            DealerProposalsCreateTermAndTypeStep termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (usageType, length, "Quarterly in Advance", billing);

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }
        private void GivenIHaveCreatedLeasingAndClickProposalWithLanguage(string contractType, string language, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIChangeTheLanguageDisplayed(language);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            DealerProposalsCreateCustomerInformationStep customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.SelectASpecificExistingCustomer("Create new customer");
            DealerProposalsCreateTermAndTypeStep termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (usageType, length, "Quarterly in Advance", billing);

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }


        private void GivenIHaveCreatedGermanLeasingAndClickProposal(string UsageType)
        {
            if (UsageType.Equals(string.Empty))
                UsageType = "Mindestvolumen";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType("Leasing & Service");
            DealerProposalsCreateTermAndTypeStep termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (UsageType, "3 Jahre", "Monatlich", "Halbjährlich");

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }


        [Given(@"I have created German Leasing and Click proposal")]
        public void GivenIHaveCreatedGermanLeasingAndClickProposal()
        {
            GivenIHaveCreatedGermanLeasingAndClickProposal("Mindestvolumen");
        }


        [Given(@"I have created Leasing and Click proposal")]
        public void GivenIHaveCreatedLeasingAndClickProposal()
        {
            GivenIHaveCreatedLeasingAndClickProposal("Minimum Volume");
        }

        [Given(@"I have created Leasing and Click proposal for ""(.*)""")]
        public void GivenIHaveCreatedLeasingAndClickProposalFor(string refs)
        {
            GivenIamOnMpsNewProposalPage();
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().SetServerName(refs);
            WhenIFillProposalDescriptionForContractType("Lease & Click with Service");

            DealerProposalsCreateCustomerInformationStep customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");

            DealerProposalsCreateTermAndTypeStep termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                ("Minimum Volume", "3 years", "Quarterly in Advance", "Quarterly in Arrears");

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }

        [Given(@"I have created Purchase and Click proposal for ""(.*)""")]
        public void GivenIHaveCreatedPurchaseAndClickProposalFor(string refs)
        {
            GivenIamOnMpsNewProposalPage();
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().SetServerName(refs);

            WhenIFillProposalDescriptionForContractType("Purchase & Click with Service");

            DealerProposalsCreateCustomerInformationStep customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            DealerProposalsCreateTermAndTypeStep stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                ("Minimum Volume", "3 years", "Quarterly in Arrears");
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800"); 
        }


        private void GivenIHaveCreatedPurchaseAndClickProposal(string UsageType)
        {
            if (UsageType.Equals(string.Empty))
                UsageType = "Minimum Volume";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType("Purchase & Click with Service");
            DealerProposalsCreateCustomerInformationStep customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            DealerProposalsCreateTermAndTypeStep stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (UsageType, "3 years", "Quarterly in Arrears");
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800"); 
            
        }


        private void GivenIHaveCreatedPurchaseAndClickProposal(string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            DealerProposalsCreateCustomerInformationStep customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            DealerProposalsCreateTermAndTypeStep stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");

        }

        private void GivenIChangeTheLanguageDisplayed(string language)
        {
            CurrentPage.As<DealerDashBoardPage>().SwitchBetweenMultipleLanguages(language);
        }

        private void GivenIHaveCreatedPurchaseAndClickProposalWithLanguage(string contractType, string language, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIChangeTheLanguageDisplayed(language);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            DealerProposalsCreateCustomerInformationStep customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            DealerProposalsCreateTermAndTypeStep stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");

        }

        private void GivenIHaveCreatedPurchaseAndClickProposal(string contractType, string customer, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            DealerProposalsCreateCustomerInformationStep customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.SelectASpecificExistingCustomer(customer);
            DealerProposalsCreateTermAndTypeStep stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");

        }


        [Given(@"I have created a ""(.*)"" proposal with ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenIHaveCreatedAProposalWithAndAnd(string contractType, string usageType, string length, string billing)
        {
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            DealerProposalsCreateCustomerInformationStep customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            DealerProposalsCreateTermAndTypeStep stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");

        }

        [When(@"I download the generated proposal PDF")]
        public void WhenIDownloadTheGeneratedProposalPDF()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().DownloadProposalPdf();
        }

        [Then(@"the PDF is downloaded")]
        public void ThenThePDFIsDownloaded()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the contents of the PDF are correct")]
        public void ThenTheContentsOfThePDFAreCorrect()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().DoesPdfContentContainSomeText();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsDeviceTotalPresentInPdf();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsCustomerNamePresentInPdf();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSummaryColourClickRatePresentInPdf();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSummaryContractTermPresentInPdf();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().DoesPdfContentContainContractId();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSummaryMonoClickRatePresentInPdf();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsCorrectLanguagePdfDownloaded();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsConsumableTotalNetPresentInPdf();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().PurgeDownloadsDirectory();
        }


        [Given(@"I have created Purchase and Click proposal")]
        public void GivenIHaveCreatedPurchaseAndClickProposal()
        {
            GivenIHaveCreatedPurchaseAndClickProposal("Minimum Volume");
        }

        [Given(@"I have created German Purchase and Click proposal")]
        public void GivenIHaveCreatedGermanPurchaseAndClickProposal()
        {
            GivenIHaveCreatedGermanPurchaseAndClickProposal("Mindestvolumen");
        }

        private void GivenIHaveCreatedGermanPurchaseAndClickProposal(string UsageType)
        {
            if (UsageType.Equals(string.Empty))
                UsageType = "Mindestvolumen";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType("Easy Print Pro & Service");
            
            DealerProposalsCreateTermAndTypeStep stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.EditTermAndTypeTabForPurchaseOffer(UsageType, "3 Jahre", "Halbjährlich");

            DealerProposalsCreateProductsStep instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            DealerProposalsCreateClickPriceStep clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }


        [When(@"I fill Proposal Description for ""(.*)"" Contract type")]
        public void WhenIFillProposalDescriptionForContractType(string contract)
        {
            //var refs = CurrentPage.As<DealerProposalsCreateDescriptionPage>().GetServerName();
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().IsPromptTextDisplayed();
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().SelectingContractType(contract);
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().EnterProposalName("");
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().EnterLeadCodeRef("");
            if (CurrentPage.As<DealerProposalsCreateDescriptionPage>().IsBigAtSystem())
            {
                NextPage = CurrentPage.As<DealerProposalsCreateDescriptionPage>().ClickNextButtonGermany();
            }
            else
            {
                NextPage = CurrentPage.As<DealerProposalsCreateDescriptionPage>().ClickNextButton(); 
            }
                
        }

        [Given(@"Customer Information tab is not displayed")]
        [When(@"Customer Information tab is not displayed")]
        public void WhenCustomerInformationTabIsNotDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().CustomerTabNotDisplayed();
        }


        [When(@"I begin the proposal creation process for Purchase \+ Click Service")]
        public void WhenIBeginTheProposalCreationProcessForPurchaseClickService()
        {
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().IsPromptTextDisplayed();
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().SelectingContractType("Purchase & Click with Service");
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().EnterProposalName("");
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().EnterLeadCodeRef("");
            NextPage = CurrentPage.As<DealerProposalsCreateDescriptionPage>().ClickNextButton();

//            When(@"I enter Customer Information Detail for new customer");
            //@TODO: Choose an existing contact until the creating new customer sequence is fixed
            DealerProposalsCreateCustomerInformationStep stepInstance =
                new DealerProposalsCreateCustomerInformationStep();
            stepInstance.GivenISkipCustomerInformationScreen();
        }

        [When(@"I begin the proposal creation process for Lease \+ Click Service")]
        public void WhenIBeginTheProposalCreationProcessForLeaseClickService()
        {
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().IsPromptTextDisplayed();
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().SelectingContractType("Lease & Click with Service");
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().EnterProposalName("");
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().EnterLeadCodeRef("");
            NextPage = CurrentPage.As<DealerProposalsCreateDescriptionPage>().ClickNextButton();
            //@TODO: Choose an existing contact until the creating new customer sequence is fixed
            DealerProposalsCreateCustomerInformationStep stepInstance =
                new DealerProposalsCreateCustomerInformationStep(); 
            stepInstance.SelectExistingCustmerByRandomly();
            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
        }

        
        [Given(@"I navigate to Admin page using tab")]
        public void GivenINavigateToAdminPageUsingTab()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToAdminPageUsingTab();
        }

        [Given(@"I navigate to Dealership Profile page")]
        public void GivenINavigateToDealershipProfilePage()
        {
            NextPage = CurrentPage.As<DealerAdminDashBoardPage>().NavigateToDealerAdminDealershipProfilePage();
        }


        [When(@"I navigate to Dealer Admin Default Margin page")]
        public void WhenINavigateToDealerAdminDefaultMarginPage()
        {
            NextPage = CurrentPage.As<DealerAdminDashBoardPage>().NavigateToDealerAdminDefaultMarginsPage();
        }

        [When(@"I can change the dealer margin for use of the dealer")]
        public void WhenICanChangeTheDealerMarginForUseOfTheDealer()
        {
            CurrentPage.As<DealerAdminDefaultMarginsPage>().EnterHardwareDefaultMarginInAutomatically();
            CurrentPage.As<DealerAdminDefaultMarginsPage>().EnterAccesoriesDefaultMarginInAutomatically();
            CurrentPage.As<DealerAdminDefaultMarginsPage>().EnterDeliveryDefaultMarginInAutomatically();
            CurrentPage.As<DealerAdminDefaultMarginsPage>().EnterInstallationDefaultMarginInAutomatically();
            CurrentPage.As<DealerAdminDefaultMarginsPage>().EnterMonoClickDefaultMarginInAutomatically();
            CurrentPage.As<DealerAdminDefaultMarginsPage>().EnterColourClickDefaultMarginInAutomatically();
            CurrentPage.As<DealerAdminDefaultMarginsPage>().EnterServicePackDefaultMarginInAutomatically();
            CurrentPage.As<DealerAdminDefaultMarginsPage>().ClickNextButton();
            CurrentPage.As<DealerAdminDefaultMarginsPage>().StoreMarginConfiguration();
        }

        [Then(@"I can generate dealer PDF for the proposal")]
        public void ThenICanGenerateDealerPDFForTheProposal()
        {
            //It is assumed that if pdf downloads normally then one is able to save the proposal
            CurrentPage.As<DealerProposalsCreateSummaryPage>().DownloadDealersProposalDocument();
        }

        [Then(@"I can generate customer PDF for the proposal")]
        public void ThenICanGenerateCustomerPDFForTheProposal()
        {
            //It is assumed that if pdf downloads normally then one is able to save the proposal
            CurrentPage.As<DealerProposalsCreateSummaryPage>().DownloadCustomersProposalDocument();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().GetDownloadedPdfPath();
        }
        
        [Then(@"I am directed to Templates screen of Proposal List page")]
        public void ThenIAmDirectedToTemplatesScreenOfProposalListPage()
        {
            CurrentPage.As<CloudExistingProposalPage>().IsProposalListTemplateScreenDiplayed();
        }

        [Then(@"the newly created template is displayed on the list")]
        public void ThenTheNewlyCreatedTemplateIsDisplayedOnTheList()
        {
            CurrentPage.As<CloudExistingProposalPage>().IsNewProposalTemplateCreated();
        }

        [When(@"I navigate to Dealer proposal Awaiting Approval screen")]
        public void WhenINavigateToDealerProposalAwaitingApprovalScreen()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the contents of the PDF is correct including correct ""(.*)""")]
        public void ThenTheContentsOfThePDFIsCorrectIncludingCorrect(string contractType)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().DoesPdfContentContainContractId();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsDeviceTotalPresentInPdf();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsCustomerNamePresentInPdf();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSummaryColourClickRatePresentInPdf();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSummaryContractTermPresentInPdf();
            //CurrentPage.As<DealerProposalsCreateSummaryPage>().DoesPdfContentContractItems(contractType);
            CurrentPage.As<DealerProposalsCreateSummaryPage>().IsSummaryMonoClickRatePresentInPdf();
            //CurrentPage.As<DealerProposalsCreateSummaryPage>().IsCorrectLanguagePdfDownloaded();
           // CurrentPage.As<DealerProposalsCreateSummaryPage>().IsConsumableTotalNetPresentInPdf();
            CurrentPage.As<DealerProposalsCreateSummaryPage>().PurgeDownloadsDirectory();
        }


        [When(@"I navigate to Dealer Dashboard page")]
        [Given(@"I navigate to Dealer Dashboard page")]
        public void GivenINavigateToDealerDashboardPage()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToDealerDashboard();
        }

        [When(@"I navigated to Term and Type page")]
        public void WhenINavigatedToTermAndTypePage()
        {
            
            When(@"I navigate to Dealer Dashboard page");
            When(@"I am on MPS New Proposal Page");
            When(@"I fill Proposal Description");
            When(@"I enter Customer Information Detail for new customer");

        }

        [Then(@"the selected devices (.*) above are displayed on Summary Screen")]
        public void ThenTheSelectedDevicesAboveAreDisplayedOnSummaryScreen(string model)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifySelectedDeviceIsDisplayed(model);
        }

        [Then(@"the entered margins on Product Screen are displayed on Summary Screen")]
        public void ThenTheEnteredMarginsOnProductScreenAreDisplayedOnSummaryScreen()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifyEnteredMarginsAreDisplayed();
        }

        [When(@"I navigate to dealer contract Approved Acceptance page")]
        public void WhenINavigateToDealerContractApprovedAcceptancePage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            CurrentPage.As<DealerContractsPage>().IsContractScreenDisplayed();
        }

        [When(@"I navigate to dealer contract Awaiting Acceptance page")]
        public void WhenINavigateToDealerContractAwaitingAcceptancePage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            CurrentPage.As<DealerContractsPage>().NavigateToAwaitingAcceptance();
        }

        [When(@"I navigate to dealer contract Rejected page")]
        public void WhenINavigateToDealerContractRejectedPage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            CurrentPage.As<DealerContractsPage>().NavigateToRejectedContract();

        }


        [Then(@"I can successfully download a dealer Contract PDF")]
        public void ThenICanSuccessfullyDownloadADealerContractPDF()
        {
            CurrentPage.As<DealerContractsPage>().DownloadAContractPDF();
        }

        [Then(@"I can successfully download a dealer Contract Invoice PDF")]
        public void ThenICanSuccessfullyDownloadADealerContractInvoicePDF()
        {
            CurrentPage.As<DealerContractsPage>().DownloadAContractInvoicePDF();
        }



    }
}
