using System.Runtime.CompilerServices;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.MPS;
using Brother.Tests.Specs.BrotherOnline.Account;
using Brother.Tests.Specs.MPSTwo.Approver;
using Brother.Tests.Specs.MPSTwo.SendToBank;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;


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
        public void GivenDealerHaveCreatedProposalOfOpen(string contractType, string usageType)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue("United Kingdom", contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                GivenIHaveCreatedLeasingAndClickProposal(usageType);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                GivenIHaveCreatedPurchaseAndClickProposal(usageType);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }


        public void GivenDealerHaveCreatedProposalOfOpen(string country, string contractType, string usageType)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);

            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposal(usageType);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposal(usageType);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }


        [Given(@"""(.*)"" Dealer has created an Open proposal of ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)""")]
        public void GivenDealerHasCreatedAnOpenProposalOfAnd(string country, string contractType, string usageType, string length, string billing)
        {
            GivenDealerHaveCreatedProposalOfOpen(country, contractType, usageType, length, billing);
        }

        [Given(@"I changed the ""(.*)"" for ""(.*)""")]
        public void GivenIChangedTheFor(string language, string p1)
        {
            
        }

        [Given(@"I changed the language to ""(.*)""")]
        public void GivenIChangedTheLanguageTo(string language)
        {
            GivenIChangeTheLanguageDisplayed(language);
        }

        public void GivenDealerFromHaveCreatedProposalOfOpen(string role, string country, string contractType, string usageType, string length, string billing)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);

            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom(role, country);
                GivenIHaveCreatedLeasingAndClickProposal(contractType, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom(role, country);
                GivenIHaveCreatedPurchaseAndClickProposal(contractType, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        public void GivenDealerHaveCreatedProposalOfOpen(string country, string contractType, string usageType, string length, string billing)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);
            
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposal(contractType, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposal(contractType, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        public void GivenDealerHaveCreatedProposalOfOpenWithDevice(string country, string contractType, string usageType, string length, string billing, string device)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);

            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposal(contractType, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposalWithDevice(contractType, usageType, length, billing, device);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        public void GivenDealerHaveCreatedProposalOfOpenWithFourDevices(string country, string contractType, string usageType, string length, string billing)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);

            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposalWithFourDevices(contractType, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposalWithFourDevices(contractType, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        public void GivenDealerHaveCreatedProposalOfOpenWithLanguage(string country, string language, string contractType, string usageType, string length, string billing)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);
            
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposalWithLanguage(contractType, language, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposalWithLanguage(contractType, language, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        public void GivenDealerHaveCreatedProposalOfOpenWithLanguageWithExistingCustomer(string country, string language, string contractType, string customer,
            string usageType, string length, string billing)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);

            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposalWithLanguage(contractType, language, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposalWithLanguage(contractType, language, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        public void GivenDealerHaveCreatedProposalOfOpen(string country, string contractType, string customer, string usageType, string length, string billing)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);

            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedLeasingAndClickProposal(contractType, customer, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);
                GivenIHaveCreatedPurchaseAndClickProposal(contractType, customer, usageType, length, billing);
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance.GivenIAmOnProposalListPage();
            }
        }

        [Given(@"Dealer have created a Awaiting Approval proposal of ""(.*)"" and ""(.*)""")]
        public void GivenDealerHaveCreatedProposalOfAwaitingApproval(string contractType, string usageType)
        {
            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpen(contractType, usageType);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
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
                GivenDealerHaveCreatedProposalOfOpen(contractType, usageType);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
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
                GivenDealerHaveCreatedProposalOfOpen(country, contractType, usageType);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
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



        [Given(@"""(.*)"" dealer has created ""(.*)"" proposal of awaiting proposal with ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenDealerHasCreatedProposalOfAwaitingProposalWithAndAnd(string country, string contractType, string usageType, string length, string billing)
        {
            GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, usageType, length, billing);
        }

        public void GivenDealerHaveCreatedProposalOfAwaitingApprovalWithDevice(string country, string contractType, string usageType, string length, string billing, string device)
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
                GivenDealerHaveCreatedProposalOfOpenWithDevice(country, contractType, usageType, length, billing, device);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
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

        public void GivenDealerFromHaveCreatedProposalOfAwaitingApproval(string role, string country, string contractType, string usageType, string length, string billing)
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
                GivenDealerFromHaveCreatedProposalOfOpen(role, country, contractType, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
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
                GivenDealerHaveCreatedProposalOfOpen(country, contractType, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
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


        public void GivenDealerHaveCreatedProposalOfAwaitingApprovalWithFourDevices(string country, string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfOpenWithFourDevices(country, contractType, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
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
                GivenDealerHaveCreatedProposalOfOpenWithFourDevices(country, contractType, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
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
                GivenDealerHaveCreatedProposalOfOpenWithLanguage(country, language, contractType, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();
                instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
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
                GivenDealerHaveCreatedProposalOfOpen(country, contractType, customer, usageType, length, billing);
                var instance2 = new SendProposalToApprover();
                instance2.WhenIClickOnActionButtonAgainstTheProposalCreatedAbove();

                //if (CurrentDriver.Url.Contains("online.ch."))
                //{
                //    instance2.ThenICanClickOnConvertToContractButtonUnderTheActionButton();
                //    CurrentPage.As<DealerConvertProposalCustomerInfo>().ChooseExistingCustomerInConvertProcess();
                //    CurrentPage.As<DealerConvertProposalCustomerInfo>().SelectASpecificExistingContact(customer);
                //    NextPage = CurrentPage.As<DealerConvertProposalCustomerInfo>().ProceedToConvertProposalTermAndType();
                //    NextPage = CurrentPage.As<DealerConvertProposalTermAndType>().NavigateToSummaryPageUsingTab();
                //}
                //else
                //{
                //    instance2.ThenICanClickOnConvertToContractButtonToNavigateToConvertSummaryPage();
                //    //instance2.ThenIAmDirectedToCustomerDetailPageForMoreDataCapture();
                //}

                instance2.ThenICanClickOnConvertToContractButtonToNavigateToConvertSummaryPage();
                
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


        [Given(@"Dealer have created an Awaiting Approval proposal of ""(.*)"" and ""(.*)"" from ""(.*)""")]
        public void GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(string contractType, string usageType, string country)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);
            instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);

            if (contractType.Equals("Leasing & Service"))
            {
                
                GivenIHaveCreatedGermanLeasingAndClickProposal(usageType);

                var instance1 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance1.GivenIAmOnProposalListPage();

                var instance2 = new SendProposalToApprover();
                instance2.GivenISendTheCreatedGermanProposalForApproval();

                
                
                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Easy Print Pro & Service"))
            {
                GivenIHaveCreatedGermanPurchaseAndClickProposal(usageType);

                var instance1 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance1.GivenIAmOnProposalListPage();

                var instance2 = new SendProposalToApprover();
                instance2.GivenISendTheCreatedGermanProposalForApproval();

                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        public void GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(string contractType, string usageType, string country, string customer)
        {
            
            if (contractType.Equals("Leasing & Service"))
            {

                GivenIHaveCreatedGermanLeasingAndClickProposal(usageType);

                var instance1 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance1.GivenIAmOnProposalListPage();

                var instance2 = new SendProposalToApprover();
                instance2.GivenISendTheCreatedGermanProposalForApproval(customer);



                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Easy Print Pro & Service"))
            {
                GivenIHaveCreatedGermanPurchaseAndClickProposal(usageType);

                var instance1 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                instance1.GivenIAmOnProposalListPage();

                var instance2 = new SendProposalToApprover();
                instance2.GivenISendTheCreatedGermanProposalForApproval(customer);

                var instance3 = new AccountManagementSteps();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }

        public string ContractType(string type)
        {
            if (
                type == "Acquisto + Consumo con assistenza" 
                || type == "Buy & Click"
                || type == "Purchase & Click con Service" 
                || type == "Kjøp og klikk med service" 
                || type == "Purchase & click inklusive service" 
                || type == "Purchase + Click met Service"
                || type == "Køb & Klik med service" 
                || type == "Buy + Click" 
                || type == "Purchase & Click mit Service"
                || type == "Click tarvikesopimus")
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
                WhenDealerSignAndNavigateToAwaitingAcceptance();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, usageType, length, billing);
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
                WhenDealerSignAndNavigateToAwaitingAcceptance();
            }
        }


        [Given(@"""(.*)"" Dealer has created an approved ""(.*)"" proposal of ""(.*)"" and ""(.*)"" and ""(.*)"" with four devices")]
        public void GivenDealerHasCreatedAnApprovedProposalOfAndAndWithFourDevices(string country, string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApprovalWithFourDevices(country, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                    instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                    instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                }

            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApprovalWithFourDevices(country, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                    instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                    instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                }

            }
        }



        [Given(@"""(.*)"" Dealer has created an approved ""(.*)"" proposal of ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenDealerHasCreatedAnApprovedProposalOfAndAnd(string country, string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", country);
                    instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                    instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                }
                
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, usageType, length, billing);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", country);
                    instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                    instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                }
                
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
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, customer, usageType, length, billing);
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
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalWithLanguageOfAwaitingApproval(country, language, contractType, usageType, length, billing);
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
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }

        [Given(@"""(.*)"" Dealer have created a ""(.*)"" contract with ""(.*)"" and ""(.*)"" and ""(.*)"" using the device ""(.*)"" using Brother installation")]
        public void GivenDealerHaveCreatedAContractWithAndAndUsingTheDeviceUsingBrotherInstallation(string country, string contractType, string usageType, string length, string billing, string device)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, usageType, length, billing);
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
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApprovalWithDevice(country, contractType, usageType, length, billing, device);
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
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }

        }

        [Given(@"subdealer ""(.*)"" from ""(.*)"" have created a ""(.*)"" contract with ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenSubdealerFromHaveCreatedAContractWithAndAnd(string role, string country, string contractType, string usageType, string length, string billing)
        {
            GivenDealerFromHaveCreatedAContractWithAndAnd(role, country, contractType, usageType, length, billing);
        }


        public void GivenDealerFromHaveCreatedAContractWithAndAnd(string role, string country, string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, usageType, length, billing);
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
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerFromHaveCreatedProposalOfAwaitingApproval(role, country, contractType, usageType, length, billing);
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
                instance4.GivenISignIntoMpsasAFrom(role, country);
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
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(country, contractType, usageType, length, billing);
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
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }
        

        [Given(@"Dealer have created a contract of ""(.*)"" and ""(.*)""")]
        public void GivenDealerHaveCreatedAContractOfAnd(string contractType, string usageType)
        {
            
            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", "United Kingdom");
                    instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                    instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", "United Kingdom");
                    instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                    instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        public void GivenDealerHaveCreatedAContractWithExistingCustomerOfAnd(string customer, string contractType, string usageType)
        {
            

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", "United Kingdom");
                    instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                    instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", "United Kingdom");
                    instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                    instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        [Given(@"Dealer has created an awaiting acceptance contract of ""(.*)"" and ""(.*)""")]
        public void GivenDealerHasCreatedAnAwaitingAcceptanceContractOfAnd(string contractType, string usageType)
        {
            

            if (contractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();

                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Bank", "United Kingdom");
                    instance2.ThenINavigateToBankAwaitingApprovalScreenUnderOfferPage();
                    instance2.ThenTheConvertedLeasingAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenDealerSignAndNavigateToAwaitingAcceptance();
            }
            else if (contractType.Equals("Purchase & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();


                if (MpsUtil.GetProposalByPassValue() != "Ticked")
                {
                    instance4.GivenISignIntoMpsasAFrom("Cloud MPS Local Office Approver", "United Kingdom");
                    instance2.ThenINavigateToLOApproverAwaitingApprovalScreenUnderProposalsPage();
                    instance2.ThenTheConvertedPurchaseAndClickAndServiceProposalAboveIsDisplayedOnTheScreen();
                    var instance5 = new ApproverSteps();
                    instance5.ThenApproverSelectTheProposalOnAwaitingProposal();
                    instance5.ThenIShouldBeAbleToApproveThatProposal();
                    instance3.ThenIfISignOutOfBrotherOnline();
                }
                instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "United Kingdom");
                WhenDealerSignAndNavigateToAwaitingAcceptance();
            }
        }


        [Given(@"German Dealer have created a ""(.*)"" awating acceptance contract of ""(.*)"" and ""(.*)""")]
        public void GivenGermanDealerHaveCreatedAAwatingAcceptanceContractOfAnd(string country, string contractType, string usageType)
        {
            if (contractType.Equals("Leasing & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country);
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
                WhenISignTheContractToNavigateToAwaitingAcceptance();
            }
            else if (contractType.Equals("Easy Print Pro & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country);
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
                WhenISignTheContractToNavigateToAwaitingAcceptance();
            }
        }

        [Then(@"I can copy ""(.*)"" declined ""(.*)"" proposal with ""(.*)"" and ""(.*)"" and ""(.*)"" as a ""(.*)"" from ""(.*)"" and approved by ""(.*)""")]
        public void ThenICanCopyDeclinedProposalWithAndAndAsAFromAndApprovedBy(string language, string contractType, string usageType, string length, string billing,
            string role, string country, string role2)
        {
            CanCopyDeclinedProposal(language, contractType, usageType, length, billing, role, country, role2, "Without");
        }

        [Then(@"I can copy ""(.*)"" customer detail with the declined ""(.*)"" proposal with ""(.*)"" and ""(.*)"" and ""(.*)"" as a ""(.*)"" from ""(.*)"" and approved by ""(.*)""")]
        public void ThenICanCopyCustomerDetailWithTheDeclinedProposalWithAndAndAsAFromAndApprovedBy(string language, string contractType, string usageType, string length, string billing,
            string role, string country, string role2)
        {
            CanCopyDeclinedProposal(language, contractType, usageType, length, billing, role, country, role2, "With");
        }


        
        
        [Then(@"I can copy the declined ""(.*)"" proposal with ""(.*)"" and ""(.*)"" and ""(.*)"" as a ""(.*)"" from ""(.*)"" and approved by ""(.*)""")]
        public void ThenICanCopyTheDeclinedProposalWithAndAndAsAFromAndApprovedBy(string contractType, string usageType, string length, string billing, 
            string role, string country, string role2)
        {
            CanCopyDeclinedProposal(contractType, usageType, length, billing, role, country, role2, "Without");
        }

        [Then(@"I can copy the customer detail with the declined ""(.*)"" proposal with ""(.*)"" and ""(.*)"" and ""(.*)"" as a ""(.*)"" from ""(.*)"" and approved by ""(.*)""")]
        public void ThenICanCopyTheCustomerDetailWithTheDeclinedProposalWithAndAndAsAFromAndApprovedBy(string contractType, string usageType, string length, string billing,
            string role, string country, string role2)
        {
            CanCopyDeclinedProposal(contractType, usageType, length, billing, role, country, role2, "With");
        }



        private void CanCopyDeclinedProposal(string contractType, string usageType, string length, string billing, 
            string role, string country, string role2, string copyOption)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance2 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                var instance3 = new SendProposalToApprover();
                var instance4 = new AccountManagementSteps();
                var instance5 = new LocalOfficeApproverSteps();

                instance1.GivenISignIntoMpsasAFrom(role, country);
                GivenIHaveCreatedAProposalWithAndAnd(contractType, usageType, length, billing);
                instance2.GivenIAmOnProposalListPage();
                instance3.GivenISendTheCreatedGermanProposalForApproval();
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

        private void CanCopyDeclinedProposal(string language, string contractType, string usageType, string length, string billing,
            string role, string country, string role2, string copyOption)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance2 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                var instance3 = new SendProposalToApprover();
                var instance4 = new AccountManagementSteps();
                var instance5 = new LocalOfficeApproverSteps();

                instance1.GivenISignIntoMpsasAFrom(role, country);
                GivenIHaveCreatedPurchaseAndClickProposalWithLanguage(contractType, language, usageType, length, billing);
                instance2.GivenIAmOnProposalListPage();
                instance3.GivenISendTheCreatedGermanProposalForApproval();
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



        [Then(@"I can copy the declined proposal as a ""(.*)"" from ""(.*)"" and approved by ""(.*)""")]
        public void ThenICanCopyTheDeclinedProposalAsAFromAndApprovedBy(string role, string country, string role2)
        {
            CanCopyDeclinedPurchaseAndClickProposal(role, country, role2, "With");
        }

        [Then(@"I can copy the declined proposal without customer detail as a ""(.*)"" from ""(.*)"" and approved by ""(.*)""")]
        public void ThenICanCopyTheDeclinedProposalWithoutCustomerDetailAsAFromAndApprovedBy(string role, string country, string role2)
        {
            CanCopyDeclinedPurchaseAndClickProposal(role, country, role2, "Without");
        }


        private void CanCopyDeclinedPurchaseAndClickProposal(string role, string country, string role2, string copyOption)
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance2 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                var instance3 = new SendProposalToApprover();
                var instance4 = new AccountManagementSteps();
                var instance5 = new LocalOfficeApproverSteps();

                instance1.GivenISignIntoMpsasAFrom(role, country);
                GivenIHaveCreatedGermanPurchaseAndClickProposal();
                instance2.GivenIAmOnProposalListPage();
                instance3.GivenISendTheCreatedGermanProposalForApproval();
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


        [Then(@"I can copy the declined Lease and Click proposal as a ""(.*)"" from ""(.*)"" and approved by ""(.*)""")]
        public void ThenICanCopyTheDeclinedLeaseAndClickProposalAsAFromAndApprovedBy(string role, string country, string role2)
        {
            CanCopyTheDeclinedLeaseAndClickProposalAsAFromAndApprovedBy(role, country, role2, "With");
        }

        [Then(@"I can copy the declined Lease and Click proposal without customer detail as a ""(.*)"" from ""(.*)"" and approved by ""(.*)""")]
        public void ThenICanCopyTheDeclinedLeaseAndClickProposalWithoutCustomerDetailAsAFromAndApprovedBy(string role, string country, string role2)
        {
            CanCopyTheDeclinedLeaseAndClickProposalAsAFromAndApprovedBy(role, country, role2, "Without");
        }



        private void CanCopyTheDeclinedLeaseAndClickProposalAsAFromAndApprovedBy(string role, string country,
            string role2, string copyOption )
        {
            if (MpsUtil.GetProposalByPassValue() != "Ticked")
            {
                var instance1 = new CreateNewAccountSteps();
                var instance2 = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
                var instance3 = new SendProposalToApprover();
                var instance4 = new AccountManagementSteps();
                // var instance5 = new LocalOfficeApproverSteps();

                instance1.GivenISignIntoMpsasAFrom(role, country);
                GivenIHaveCreatedGermanLeasingAndClickProposal();
                instance2.GivenIAmOnProposalListPage();
                instance3.GivenISendTheCreatedGermanProposalForApproval();
                instance4.ThenIfISignOutOfBrotherOnline();
                instance1.GivenISignIntoMpsasAFrom(role2, country);
                instance3.WhenIDeclineTheProposalCreatedAbove();
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


        [Given(@"""(.*)"" Dealer have created a ""(.*)"" contract choosing ""(.*)"" with ""(.*)""")]
        public void GivenGermanDealerHaveCreatedAAwatingAcceptanceContractOfAnd(string country, string contractType, string usageType, string customer)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.SetProposalByPassValue(country, contractType);
            instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", country);

            if (contractType.Equals("Leasing & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country, customer);
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
                WhenISignTheContractToNavigateToAwaitingAcceptance();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Easy Print Pro & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country, customer);
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
                WhenISignTheContractToNavigateToAwaitingAcceptance();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        [Given(@"German Dealer have created a ""(.*)"" contract of ""(.*)"" and ""(.*)""")]
        public void GivenGermanDealerHaveCreatedAContractOfAnd(string country, string contractType, string usageType)
        {
            var instance4 = new CreateNewAccountSteps();

            if (contractType.Equals("Leasing & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country);
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
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Easy Print Pro & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country);
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
                WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
        }

        [Given(@"German Dealer have created a signed ""(.*)"" contract of ""(.*)"" and ""(.*)""")]
        public void GivenGermanDealerHaveCreatedASignedContractOfAnd(string country, string contractType, string usageType)
        {
            var instance4 = new CreateNewAccountSteps();
            //instance4.GivenISignIntoMpsasAFrom();
           
            if (contractType.Equals("Leasing & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country);
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
                WhenISignTheContractToNavigateToAwaitingAcceptance();
                //instance3.ThenIfISignOutOfBrotherOnline();
            }
            else if (contractType.Equals("Easy Print Pro & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(contractType, usageType, country);
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
                WhenISignTheContractToNavigateToAwaitingAcceptance();
                //instance3.ThenIfISignOutOfBrotherOnline();
            }
        }


        public void WhenISignTheContractAsADealer()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            NextPage = CurrentPage.As<DealerContractsPage>().NavigateToViewOfferOnApprovedProposalsTab();
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().ClickSignButtonToNavigateToAwaitingAcceptance();
        }

        public void WhenDealerSignAndNavigateToAwaitingAcceptance()
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

        private void GivenIHaveCreatedLeasingAndClickProposal(string usageType)
        {
            if (usageType.Equals(string.Empty))
                usageType = "Minimum Volume";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType("Lease & Click with Service");
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            var termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (usageType, "3 years", "Quarterly in Advance", "Quarterly in Arrears");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }


        private void GivenIHaveCreatedLeasingAndClickProposal(string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            var termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (usageType, length, "Quarterly in Advance", billing);

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }


        private void GivenIHaveCreatedLeasingAndClickProposalWithFourDevices(string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            var termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (usageType, length, "Quarterly in Advance", billing);

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            instance.WhenIDisplayDeviceScreen("DCP-L8400CDN");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            instance.WhenIDisplayDeviceScreen("DCP-L8450CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }

        

        private void GivenIHaveCreatedLeasingAndClickProposal(string contractType, string customer, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
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

        public void GivenIHaveCreatedLeasingAndClickProposalWithLanguage(string contractType, string language, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIChangeTheLanguageDisplayed(language);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.SelectASpecificExistingCustomer("Create new customer");
            var termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (usageType, length, "Quarterly in Advance", billing);

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
        }


        private void GivenIHaveCreatedGermanLeasingAndClickProposal(string usageType)
        {
            
            if (usageType.Equals(string.Empty))
                usageType = "Mindestvolumen";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType("Leasing & Service");
            var termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (usageType, "4 Jahre", "Monatlich", "Halbjährlich");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
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

            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");

            var termAndTypeStepInstance = new DealerProposalsCreateTermAndTypeStep();
            termAndTypeStepInstance.WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                ("Minimum Volume", "3 years", "Quarterly in Advance", "Quarterly in Arrears");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
            if (CurrentDriver.Url.Contains("online.ch") || CurrentDriver.Url.Contains("online.brother.ch.local"))
            {
                clickPricestepInstance.WhenITypeClickPriceVolumeOfAnd("2000", "2000");
            }
            else
            {
                clickPricestepInstance.WhenIEnterClickPriceVolumeOf("2000", "2000");
            }
        }


        [Given(@"I have created a ""(.*)"" proposal for ""(.*)"" with ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenIHaveCreatedAProposalWithAndAnd(string contractType, string serverName, string usageType, string length, string billing)
        {
            GivenIamOnMpsNewProposalPage();
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().SetServerName(serverName);

            WhenIFillProposalDescriptionForContractType(contractType);

            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            
            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            var instance = new DealerProposalsCreateProductsStep();

            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");

            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            if (CurrentDriver.Url.Contains("online.ch") || CurrentDriver.Url.Contains("online.brother.ch.local"))
            {
                clickPriceStepInstance.WhenITypeClickPriceVolumeOfAnd("800", "800");
            }
            else
            {
                clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");
            }

        }


        [Given(@"I have created Purchase and Click proposal for ""(.*)""")]
        public void GivenIHaveCreatedPurchaseAndClickProposalFor(string refs)
        {
            GivenIamOnMpsNewProposalPage();
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().SetServerName(refs);

            WhenIFillProposalDescriptionForContractType("Purchase & Click with Service");

            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                ("Minimum Volume", "3 years", "Quarterly in Arrears");
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            if (CurrentDriver.Url.Contains("online.ch") || CurrentDriver.Url.Contains("online.brother.ch.local"))
            {
                clickPriceStepInstance.WhenITypeClickPriceVolumeOfAnd("800", "800");
            }
            else
            {
                clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");
            } 
        }


        private void GivenIHaveCreatedPurchaseAndClickProposal(string usageType)
        {
            if (usageType.Equals(string.Empty))
                usageType = "Minimum Volume";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType("Purchase & Click with Service");
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, "3 years", "Quarterly in Arrears");
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            if (CurrentDriver.Url.Contains("online.ch") || CurrentDriver.Url.Contains("online.brother.ch.local"))
            {
                clickPriceStepInstance.WhenITypeClickPriceVolumeOfAnd("800", "800");
            }
            else
            {
                clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");
            }
            
        }


        private void GivenIHaveCreatedPurchaseAndClickProposalWithFourDevices(string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");

            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIChangeTheDefaultValuesOfTheDevice();

            instance.WhenIDisplayDeviceScreen("DCP-L8400CDN");
            instance.WhenIChangeTheDefaultValuesOfTheDevice();

            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIChangeTheDefaultValuesOfTheDevice();

            instance.WhenIDisplayDeviceScreen("DCP-L8450CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();

            clickPriceStepInstance.WhenISelectMultipleClickPrice("1000", "1000");
            



        }

        private void GivenIHaveCreatedPurchaseAndClickProposal(string contractType, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
             var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
             customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer"); 
            
            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            if (CurrentDriver.Url.Contains("online.ch") || CurrentDriver.Url.Contains("online.brother.ch.local"))
            {
                clickPriceStepInstance.WhenITypeClickPriceVolumeOfAnd("800", "800");
            }
            else
            {
                clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");
            }



        }

        private void GivenIHaveCreatedPurchaseAndClickProposalWithDevice(string contractType, string usageType, string length, string billing, string device)
        {
            contractType = ContractType(contractType);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");

            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen(device);
            instance.WhenIAcceptTheDefaultValuesOfTheDevice("", "Brother");

            var clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            if (CurrentDriver.Url.Contains("online.ch") || CurrentDriver.Url.Contains("online.brother.ch.local"))
            {
                clickPriceStepInstance.WhenITypeClickPriceVolumeOfAnd("800", "800");
            }
            else
            {
                clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");
            }



        }


        

        public void GivenIChangeTheLanguageDisplayed(string language)
        {
            CurrentPage.As<DealerDashBoardPage>().SwitchBetweenMultipleLanguages(language);
        }

        public void GivenIHaveCreatedPurchaseAndClickProposalWithLanguage(string contractType, string language, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIChangeTheLanguageDisplayed(language);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
           
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
          
            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            if (CurrentDriver.Url.Contains("online.ch") || CurrentDriver.Url.Contains("online.brother.ch.local"))
            {
                clickPriceStepInstance.WhenITypeClickPriceVolumeOfAnd("800", "800");
            }
            else
            {
                clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");
            }
            

        }

        private void GivenIHaveCreatedPurchaseAndClickProposal(string contractType, string customer, string usageType, string length, string billing)
        {
            contractType = ContractType(contractType);
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.SelectASpecificExistingCustomer(customer); ;
            
            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            if (CurrentDriver.Url.Contains("online.ch") || CurrentDriver.Url.Contains("online.brother.ch.local"))
            {
                clickPriceStepInstance.WhenITypeClickPriceVolumeOfAnd("800", "800");
            }
            else
            {
                clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");
            }

        }


        [Given(@"I have created a ""(.*)"" proposal with ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void GivenIHaveCreatedAProposalWithAndAnd(string contractType, string usageType, string length, string billing)
        {
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType(contractType);
            var customerInformationStepInstance = new DealerProposalsCreateCustomerInformationStep();
            customerInformationStepInstance.WhenISelectButtonForCustomerDataCapture("Create new customer");
            
            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (usageType, length, billing);
            stepInstance.WhenIPriceHardwareRadioButton("Tick");

            var instance = new DealerProposalsCreateProductsStep();

           instance.WhenIDisplayDeviceScreen("MFC-L8650CDW");
           
           instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPriceStepInstance = new DealerProposalsCreateClickPriceStep();
            if (CurrentDriver.Url.Contains("online.ch") || CurrentDriver.Url.Contains("online.brother.ch.local"))
            {
                clickPriceStepInstance.WhenITypeClickPriceVolumeOfAnd("800", "800");
            }
            else
            {
                clickPriceStepInstance.WhenIEnterClickPriceVolumeOf("800", "800");
            }

        }

       
        [When(@"I download the generated proposal PDF")]
        public void WhenIDownloadTheGeneratedProposalPdf()
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().DownloadProposalPdf();
        }

        [Then(@"the PDF is downloaded")]
        public void ThenThePdfIsDownloaded()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the contents of the PDF are correct")]
        public void ThenTheContentsOfThePdfAreCorrect()
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

        private void GivenIHaveCreatedGermanPurchaseAndClickProposal(string usageType)
        {
            if (usageType.Equals(string.Empty))
                usageType = "Mindestvolumen";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType("Easy Print Pro & Service");
            
            var stepInstance = new DealerProposalsCreateTermAndTypeStep();
            stepInstance.EditTermAndTypeTabForPurchaseOffer(usageType, "4 Jahre", "Halbjährlich");

            var instance = new DealerProposalsCreateProductsStep();
            instance.WhenIDisplayDeviceScreen("HL-L8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();

            var clickPricestepInstance = new DealerProposalsCreateClickPriceStep();
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
            var stepInstance =
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
            var stepInstance =
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
        public void ThenICanGenerateDealerPdfForTheProposal()
        {
            //It is assumed that if pdf downloads normally then one is able to save the proposal
            CurrentPage.As<DealerProposalsCreateSummaryPage>().DownloadDealersProposalDocument();
        }

        [Then(@"I can generate customer PDF for the proposal")]
        public void ThenICanGenerateCustomerPdfForTheProposal()
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
        public void ThenTheContentsOfThePdfIsCorrectIncludingCorrect(string contractType)
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
        public void ThenICanSuccessfullyDownloadADealerContractPdf()
        {
            CurrentPage.As<DealerContractsPage>().DownloadAContractPDF();
        }

        [Then(@"I can successfully download a dealer Contract Invoice PDF")]
        public void ThenICanSuccessfullyDownloadADealerContractInvoicePdf()
        {
            CurrentPage.As<DealerContractsPage>().DownloadAContractInvoicePDF();
        }



    }
}
