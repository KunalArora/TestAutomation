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

        private void WhenISignTheContractAsADealer()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            NextPage = CurrentPage.As<DealerContractsPage>().NavigateToViewOfferOnApprovedProposalsTab();
            NextPage = CurrentPage.As<DealerContractsSummaryPage>().ClickSignButton();
        }

        private void GivenIHaveCreatedLeasingAndClickProposal(string UsageType)
        {
            if (UsageType.Equals(string.Empty))
                UsageType = "Minimum Volume";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType("Lease & Click with Service");
            WhenISelectButtonForCustomerDataCapture("Create new customer");
            WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails
                (UsageType, "3 years", "Quarterly", "Quarterly");

            ProductsPageStep instance = new ProductsPageStep();
            instance.WhenIDisplayDeviceScreen("HLL8350CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();
            WhenIEnterClickPriceVolumeOf("2000", "2000");
        }

        [Given(@"I have created Leasing and Click proposal")]
        public void GivenIHaveCreatedLeasingAndClickProposal()
        {
            GivenIHaveCreatedLeasingAndClickProposal("Minimum Volume");
        }

        private void GivenIHaveCreatedPurchaseAndClickProposal(string UsageType)
        {
            if (UsageType.Equals(string.Empty))
                UsageType = "Minimum Volume";
            GivenIamOnMpsNewProposalPage();
            WhenIFillProposalDescriptionForContractType("Purchase & Click with Service");
            WhenISelectButtonForCustomerDataCapture("Create new customer");
            WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails
                (UsageType, "3 years", "Quarterly");
            WhenIPriceHardwareRadioButton("Tick");

            ProductsPageStep instance = new ProductsPageStep();
            instance.WhenIDisplayDeviceScreen("MFCL8650CDW");
            instance.WhenIAcceptTheDefaultValuesOfTheDevice();
            WhenIEnterClickPriceVolumeOf("800", "800");  
        }

        [Given(@"I have created Purchase and Click proposal")]
        public void GivenIHaveCreatedPurchaseAndClickProposal()
        {
            GivenIHaveCreatedPurchaseAndClickProposal("Minimum Volume");
        }


        [When(@"I fill Proposal Description for ""(.*)"" Contract type")]
        public void WhenIFillProposalDescriptionForContractType(string contract)
        {
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().IsPromptTextDisplayed();
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().SelectingContractType(contract);
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().EnterProposalName("");
            CurrentPage.As<DealerProposalsCreateDescriptionPage>().EnterLeadCodeRef("");
            NextPage = CurrentPage.As<DealerProposalsCreateDescriptionPage>().ClickNextButton();
        }

        [When(@"I Enter ""(.*)"" contract terms and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterContractTermsAndBillingOnTermAndTypeDetails(string contract, string billing)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsTermAndTypeTextDisplayed();

            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectContractLength(contract);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectPayPerClickBillingCycle(billing);
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
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickSelectExistingCustomerButtonAndProceed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().SelectARandomExistingContact();
            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
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
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickSelectExistingCustomerButtonAndProceed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().SelectARandomExistingContact();
            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
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


        [Given(@"I skip Customer Information Screen")]
        public void GivenISkipCustomerInformationScreen()
        {
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickSkipCustomerButtonAndProceed();
        }

        [When(@"I enter Customer Information Detail for new customer")]
        public void WhenIEnterCustomerInformationDetailForNewCustomer()
        {
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickCreateNewCustomerButtonAndProceed();

            // CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNewOrganisationButton();

            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().FillOrganisationDetails();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().FillOrganisationContactDetail();
            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
        }

        [When(@"I select ""(.*)"" button for customer data capture")]
        public void WhenISelectButtonForCustomerDataCapture(string customerOption)
        {
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().CustomerCreationOptions(customerOption);
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().FillOrganisationContactDetail();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().FillOrganisationDetails();
            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
        }

        [When(@"I select next button for customer data capture on editing")]
        public void WhenISelectNextButtonForCustomerDataCaptureOnEditing()
        {
            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();

        }

        [When(@"I ""(.*)"" Private Liable for Company Info")]
        public void WhenIPrivateLiableForCompanyInfo(string liable)
        {
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().FillOrganisationDetails();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().CheckPrivateLiableBox(liable);
        }

        [Given(@"I Enter ""(.*)"" usage type ""(.*)"" contract length and ""(.*)"" billing on Term and Type details")]
        [When(@"I Enter ""(.*)"" usage type ""(.*)"" contract length and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails(string usage, string contract,
            string billing)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsTermAndTypeTextDisplayed();
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectUsageType(usage);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectContractLength(contract);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectPayPerClickBillingCycle(billing);
        }

        [When(@"I choose to pay Service Packs ""(.*)""")]
        public void WhenIChooseToPayServicePacks(string pay)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().PayServicePackMethod(pay);
        }
        
        private void WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetails(string contract, string leasing,
            string billing)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsTermAndTypeTextDisplayed();

            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectContractLength(contract);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectLeaseBillingCycle(leasing);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectPayPerClickBillingCycle(billing);
        }

        [Given(@"I Enter ""(.*)"" contract terms ""(.*)"" leasing and ""(.*)"" billing on Term and Type details")]
        [When(@"I Enter ""(.*)"" contract terms ""(.*)"" leasing and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetailsAndClick(string contract, string leasing,
            string billing)
        {
            WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetails(contract, leasing, billing);

            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
        }

        

        [When(@"I Enter ""(.*)"" contract terms ""(.*)"" leasing and ""(.*)"" billing on Term and Type details\(only input\)")]
        public void WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetailsOnlyInput(string contract, string leasing,
            string billing)
        {
            WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetails(contract, leasing, billing);
        }


        [When(@"I Enter usage type of ""(.*)"" and ""(.*)"" contract terms ""(.*)"" leasing and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterUsageTypeOfAndContractTermsLeasingAndBillingOnTermAndTypeDetails(string usage, string contract, string leasing, string billing)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsTermAndTypeTextDisplayed();
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectUsageType(usage);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectContractLength(contract);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectLeaseBillingCycle(leasing);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectPayPerClickBillingCycle(billing);

            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
        }

        [When(@"I tick Price Hardware radio button")]
        public void WhenITickPriceHardwareRadioButton()
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().TickPriceHardware();

            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
        }

        [When(@"I untick Price Hardware radio button")]
        public void WhenIUntickPriceHardwareRadioButton()
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().UntickPriceHardware();

            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
        }
        
        [Then(@"I should not see Price Hardware radio button on Term and Type screen")]
        public void ThenIShouldNotSeePriceHardwareRadioButtonOnTermAndTypeScreen()
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsNotPriceHardwareElement();
            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
        }

        [When(@"I enter ""(.*)"" into Mono Coverage field")]
        public void WhenIEnterIntoMonoCoverageField(string coverage)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterMonoCoverage(coverage);
        }

        [When(@"I enter ""(.*)"" into Mono Volume field")]
        public void WhenIEnterIntoMonoVolumeField(string volume)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterMonoVolume(volume, "0");
        }

        [When(@"I enter ""(.*)"" into Colour Coverage field")]
        public void WhenIEnterIntoColourCoverageField(string coverage)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterColourCoverage(coverage);
        }

        [When(@"I enter ""(.*)"" into Colour Volume field")]
        public void WhenIEnterIntoColourVolumeField(string volume)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterColourVolume(volume, "0");
        }

        [When(@"I select ""(.*)"" from Mono Volume field")]
        public void WhenISelectFromMonoVolumeField(string volume)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().SelectMonoVolume(volume, "0");
        }

        [When(@"I select ""(.*)"" from Mono Volume field by indicating row(.*)")]
        public void WhenISelectFromMonoVolumeFieldByIndicatingRow(string volume, string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().SelectMonoVolume(volume, row);
        }

        [When(@"I select ""(.*)"" from Colour Volume field by indicating row(.*)")]
        public void WhenISelectFromColourVolumeFieldByIndicatingRow(string volume, string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().SelectColorVolume(volume, row);
        }

        [When(@"I enter ""(.*)"" from Colour Volume field by indicating row(.*)")]
        public void WhenIEnterFromColourVolumeFieldByIndicatingRow(string volume, string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterColourVolume(volume, row);
        }
        
        [When(@"I enter ""(.*)"" from Mono Volume field by indicating row(.*)")]
        public void WhenIEnterFromMonoVolumeFieldByIndicatingRow(string volume, string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().EnterMonoVolume(volume, row);
        }

        [When(@"Service Pack payment method is not displayed")]
        [Then(@"Service Pack payment method is not displayed")]
        public void WhenServicePackPaymentMethodIsNotDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyPaymentMethodIsNotDisplayed();
        }

        [Then(@"the coverage error is displayed")]
        public void ThenTheCoverageErrorIsDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().IsCoverageErrorDisplayed();
        }


        [When(@"I ""(.*)"" Price Hardware radio button")]
        public void WhenIPriceHardwareRadioButton(string option)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().TickPriceHardware(option);
            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
        }

        [When(@"Service Pack payment method is displayed")]
        [Then(@"Service Pack payment method is displayed")]
        public void WhenServicePackPaymentMethodIsDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyPaymentMethodIsDisplayed();
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

        [When(@"I enter click price volume of ""(.*)"" and ""(.*)""")]
        public void WhenIEnterClickPriceVolumeOf(string clickprice, string colour)
        {
            NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateClickPriceAndProceed(clickprice, colour);
        }

        [When(@"I type in click price volume of ""(.*)""")]
        public void WhenITypeInClickPriceVolumeOf(string monoVol)
        {
            NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredClickPriceAndProceed(monoVol);
        }


        [When(@"I calculate click price for the printer")]
        public void WhenICalculateClickPriceForThePrinter()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateClickPrice();
        }

        [Then(@"the click price displayed for the Colour is changed accordingly")]
        public void ThenTheClickPriceDisplayedForTheColourIsChangedAccordingly()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceDisplayedForTheColourIsChangedAccordingly();
        }

        [Then(@"the click price displayed for the Mono is changed accordingly")]
        public void ThenTheClickPriceDisplayedForTheMonoIsChangedAccordingly()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceDisplayedForTheMonoIsChangedAccordingly();
        }

        [Then(@"the click price for Mono is not changed")]
        public void ThenTheClickPriceForMonoIsNotChanged()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceForMonoIsNotChanged("0");
        }

        [Then(@"the click price for Mono field(.*) is changed")]
        public void ThenTheClickPriceForMonoFieldIsChanged(string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceForMonoIsChanged(row);
        }

        [Then(@"the click price for Mono field(.*) is not changed")]
        public void ThenTheClickPriceForMonoFieldIsNotChanged(string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceForMonoIsNotChanged(row);
        }

        [Then(@"the click price for Colour field(.*) is changed")]
        public void ThenTheClickPriceForColourFieldIsChanged(string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceForColourIsChanged(row);
        }

        [Then(@"the click price for Colour field(.*) is not changed")]
        public void ThenTheClickPriceForColourFieldIsNotChanged(string row)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceForColourIsNotChanged(row);
        }


        [Then(@"the Click Price value for Volume value become smaller and smaller")]
        public void ThenTheClickPriceValueForVolumeValueBecomeSmallerAndSmaller()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyThatClickPriceValueForVolumeValueBecomeSmallerAndSmaller();
        }

        [Then(@"the Click Price value for Volume value is all equal")]
        public void ThenTheClickPriceValueForVolumeValueIsAllEqual()
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().VerifyClickPriceValueForVolumeValueIsAllEqual();
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

        [When(@"I click the back button on Customer Information Screen")]
        public void WhenIClickTheBackButtonOnCustomerInformationScreen()
        {
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickBackButtonDuringProposalProcess();

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
