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



        [Given(@"German Dealer have created a Awaiting Approval proposal of ""(.*)"" and ""(.*)""")]
        public void GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(string ContractType, string UsageType)
        {
            var instance4 = new CreateNewAccountSteps();
            instance4.GivenISignIntoMpsasAFrom("Cloud MPS Dealer", "Germany");

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

        [Given(@"Dealer have created a contract of ""(.*)"" and ""(.*)""")]
        public void GivenDealerHaveCreatedAContractOfAnd(string ContractType, string UsageType)
        {
            if (ContractType.Equals("Lease & Click with Service"))
            {
                GivenDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType);
                var instance4 = new CreateNewAccountSteps();
                var instance2 = new SendProposalToApprover();
                var instance3 = new AccountManagementSteps();
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
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
                var instance = new ProposalCreateAProposalThatWillBeUsedForContractSteps();
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

        [Given(@"German Dealer have created a ""(.*)"" contract of ""(.*)"" and ""(.*)""")]
        public void GivenGermanDealerHaveCreatedAContractOfAnd(string Country, string ContractType, string UsageType)
        {
            if (ContractType.Equals("Leasing & Service"))
            {
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType);
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
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType);
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
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType);
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
                GivenGermanDealerHaveCreatedProposalOfAwaitingApproval(ContractType, UsageType);
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
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().ClickSignButton();
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


        private void GivenIHaveCreatedGermanLeasingAndClickProposal(string UsageType)
        {
            if (UsageType.Equals(string.Empty))
                UsageType = "Minimum Volume";
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
            GivenIHaveCreatedGermanLeasingAndClickProposal("Minimum Volume");
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

        [Given(@"I have created Purchase and Click proposal")]
        public void GivenIHaveCreatedPurchaseAndClickProposal()
        {
            GivenIHaveCreatedPurchaseAndClickProposal("Minimum Volume");
        }

        [Given(@"I have created German Purchase and Click proposal")]
        public void GivenIHaveCreatedGermanPurchaseAndClickProposal()
        {
            GivenIHaveCreatedGermanPurchaseAndClickProposal("Minimum Volume");
        }

        private void GivenIHaveCreatedGermanPurchaseAndClickProposal(string UsageType)
        {
            if (UsageType.Equals(string.Empty))
                UsageType = "Minimum Volume";
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
            if (CurrentPage.As<DealerProposalsCreateDescriptionPage>().IsGermanSystem())
            {
                NextPage = CurrentPage.As<DealerProposalsCreateDescriptionPage>().ClickNextButtonGermany();
            }
            else
                NextPage = CurrentPage.As<DealerProposalsCreateDescriptionPage>().ClickNextButton();
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
