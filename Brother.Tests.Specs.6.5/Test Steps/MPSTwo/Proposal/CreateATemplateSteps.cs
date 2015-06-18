using Brother.Tests.Specs.BrotherOnline.Account;
using Brother.Tests.Specs.MPSTwo.Approver;
using Brother.Tests.Specs.MPSTwo.Bank;
using Brother.Tests.Specs.MPSTwo.LocalOfficeApprover;
using Brother.Tests.Specs.MPSTwo.SendToBank;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using NUnit.Framework.Constraints;
using OpenQA.Selenium.Remote;
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


        [When(@"I fill Proposal Description for ""(.*)"" program")]
        public void WhenIFillProposalDescriptionForProgram(string program)
        {
            CurrentPage.As<CreateNewProposalPage>().SelectingContractType(program);
            WhenIFillProposalDescription();
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
                instance.WhenISignTheContractAsADealer();
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
                instance.WhenISignTheContractAsADealer();
                instance3.ThenIfISignOutOfBrotherOnline();
            }
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
            WhenIDisplayDeviceScreen("HL-L8350CDW");
            WhenIAcceptTheDefaultValuesOfTheDevice();
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
            WhenIDisplayDeviceScreen("MFC-L8650CDW");
            WhenIAcceptTheDefaultValuesOfTheDevice();
            WhenIEnterClickPriceVolumeOf("800", "800");  
        }

        [Given(@"I have created Purchase and Click proposal")]
        public void GivenIHaveCreatedPurchaseAndClickProposal()
        {
            GivenIHaveCreatedPurchaseAndClickProposal("Minimum Volume");
        }


        [Given(@"I fill Proposal Description")]
        [When(@"I fill Proposal Description")]
        public void WhenIFillProposalDescription()
        {
            CurrentPage.As<CreateNewProposalPage>().IsPromptTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().EnterProposalName("");
            CurrentPage.As<CreateNewProposalPage>().EnterLeadCodeRef("");
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton_old();
        }

        [When(@"I fill Proposal Description for ""(.*)"" Contract type")]
        public void WhenIFillProposalDescriptionForContractType(string contract)
        {
            CurrentPage.As<CreateNewProposalPage>().IsPromptTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().SelectingContractType(contract);
            CurrentPage.As<CreateNewProposalPage>().EnterProposalName("");
            CurrentPage.As<CreateNewProposalPage>().EnterLeadCodeRef("");
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton_old();
        }

        [When(@"I begin the proposal creation process for Purchase \+ Click Service")]
        public void WhenIBeginTheProposalCreationProcessForPurchaseClickService()
        {
            CurrentPage.As<CreateNewProposalPage>().IsPromptTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().SelectingContractType("Purchase & Click with Service");
            CurrentPage.As<CreateNewProposalPage>().EnterProposalName("");
            CurrentPage.As<CreateNewProposalPage>().EnterLeadCodeRef("");
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton_old();

//            When(@"I enter Customer Information Detail for new customer");
            //@TODO: Choose an existing contact until the creating new customer sequence is fixed
            CurrentPage.As<CreateNewProposalPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().ClickSelectExistingCustomerRadioButton();
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton_old();

            CurrentPage.As<CreateNewProposalPage>().SelectARandomExistingContact();
            NextPage = CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
//            CurrentPage.As<CreateNewProposalPage>().TickOrderConsumables();

//            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
        }

        [When(@"I begin the proposal creation process for Lease \+ Click Service")]
        public void WhenIBeginTheProposalCreationProcessForLeaseClickService()
        {
            CurrentPage.As<CreateNewProposalPage>().IsPromptTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().SelectingContractType("Lease & Click with Service");
            CurrentPage.As<CreateNewProposalPage>().EnterProposalName("");
            CurrentPage.As<CreateNewProposalPage>().EnterLeadCodeRef("");
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton_old();
            //@TODO: Choose an existing contact until the creating new customer sequence is fixed
            CurrentPage.As<CreateNewProposalPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().ClickSelectExistingCustomerRadioButton();
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton_old();

            CurrentPage.As<CreateNewProposalPage>().SelectARandomExistingContact();
            NextPage = CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
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
            CurrentPage.As<CreateNewProposalPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().ClickSkipCustomerRadioButton();
            NextPage = CurrentPage.As<CreateNewProposalPage>().ClickNextButton();

        }

        [When(@"I enter Customer Information Detail for new customer")]
        public void WhenIEnterCustomerInformationDetailForNewCustomer()
        {
            CurrentPage.As<CreateNewProposalPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().ClickCreateNewCustomerRadioButton();
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton_old();

            // CurrentPage.As<CreateNewProposalPage>().ClickNewOrganisationButton();
//           CurrentPage.As<CreateNewProposalPage>().IsPrivateLiableCheckBoxDiplayed();

            CurrentPage.As<CreateNewProposalPage>().FillOrganisationDetails();
            CurrentPage.As<CreateNewProposalPage>().FillOrganisationContactDetail();
            //CurrentPage.As<CreateNewProposalPage>().TickOrderConsumables();

            NextPage = CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
        }

        [When(@"I select ""(.*)"" button for customer data capture")]
        public void WhenISelectButtonForCustomerDataCapture(string customerOption)
        {
            CurrentPage.As<CreateNewProposalPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().CustomerCreationOptions(customerOption);
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
            CurrentPage.As<CreateNewProposalPage>().FillOrganisationContactDetail();
            CurrentPage.As<CreateNewProposalPage>().FillOrganisationDetails();
            NextPage = CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
        }

        [When(@"I ""(.*)"" Private Liable for Company Info")]
        public void WhenIPrivateLiableForCompanyInfo(string liable)
        {
            CurrentPage.As<CreateNewProposalPage>().FillOrganisationDetails();
            CurrentPage.As<CreateNewProposalPage>().CheckPrivateLiableBox(liable);
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

            NextPage = CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
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
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectLeaseBillingCycle(leasing);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectPayPerClickBillingCycle(billing);

            NextPage = CurrentPage.As<DealerProposalsCreateTermAndTypePage>().ClickNextButton();
            
        }

        [When(@"I Enter ""(.*)"" contract terms and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterContractTermsAndBillingOnTermAndTypeDetails(string contract, string billing)
        {
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().IsTermAndTypeTextDisplayed();

            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectContractLength(contract);
            CurrentPage.As<DealerProposalsCreateTermAndTypePage>().SelectPayPerClickBillingCycle(billing);
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

        [When(@"""(.*)"" device screen is displayed")]
        public void WhenDeviceScreenIsDisplayed(string option)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyTypeOfDeviceScreenDisplayed(option);
        }

        [When(@"I choose ""(.*)"" from Products screen")]
        public void WhenIChooseFromProductsScreen(string printer)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsProductScreenTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().ChooseADeviceFromProductSelectionScreen(printer, "80", "90");
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyProductAdditionConfirmationMessage();

        }

        [When(@"I accept the default values of the device")]
        public void WhenIAcceptTheDefaultValuesOfTheDevice()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyProductAdditionConfirmationMessage();
            NextPage = CurrentPage.As<DealerProposalsCreateProductsPage>().MoveToClickPriceScreen();
        }

        [When(@"I display ""(.*)"" device screen")]
        [Then(@"I display ""(.*)"" device screen")]
        public void WhenIDisplayDeviceScreen(string printer)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsProductScreenTextDisplayed();
            CurrentPage.As<DealerProposalsCreateProductsPage>().ClickOnAPrinter(printer);
            CurrentPage.As<DealerProposalsCreateProductsPage>().StoreDefaultProductConfiguration();
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

        [When(@"I select ""(.*)"" from Colour Volume field")]
        public void WhenISelectFromColourVolumeField(string volume)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().SelectColorVolume(volume);
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


        [When(@"I change the Installation Pack Unit Cost displayed to a value lower than the displayed Unit Cost")]
        public void WhenIChangeTheInstallationPackUnitCostDisplayedToAValueLowerThanTheDisplayedUnitCost()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterInstallationPackCostPriceLessThanDefault();
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

        [When(@"I enter click price volume of ""(.*)"" and ""(.*)"" and do not proceed")]
        public void WhenIEnterClickPriceVolumeOfAndDoNotProceed(string clickprice, string colour)
        {
            CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateClickPrice(clickprice, colour);
        }

        [When(@"I type in click price volume of ""(.*)""")]
        public void WhenITypeInClickPriceVolumeOf(string monoVol)
        {
            NextPage = CurrentPage.As<DealerProposalsCreateClickPricePage>().CalculateEnteredClickPriceAndProceed(monoVol);
        }


        [When(@"I select click price volume of ""(.*)""")]
        public void WhenISelectClickPriceVolumeOf(string monoVol)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().CalculateEPPClickPriceAndProceed(monoVol);
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


        [When(@"I enter multiple click price volume of ""(.*)"" and ""(.*)""")]
        public void WhenIEnterMultipleClickPriceVolumeOfAnd(string clickprice, string colour)
        {
            CurrentPage.As<CreateNewProposalPage>().CalculateMultipleClickPriceAndProceed(clickprice, colour);
        }

        [When(@"I click Save as Template button on Summary screen")]
        public void WhenIClickSaveAsTemplateButtonOnSummaryScreen()
        {
            CurrentPage.As<CreateNewProposalPage>().MoveToProposalSummaryScreen();
            NextPage = CurrentPage.As<CreateNewProposalPage>().SaveProposalAsTemplate();
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
            CurrentPage.As<CreateNewProposalPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().ClickBackButtonDuringProposalProcess();

        }

        [Then(@"the information entered into the fields are still retained")]
        public void ThenTheInformationEnteredIntoTheFieldsAreStillRetained()
        {
            CurrentPage.As<CreateNewProposalPage>().VerifyProposalDescriptionValuesAreRetained();
        }

        [Given(@"I am on MPS New Proposal Summary Screen")]
        public void GivenIamOnMpsNewProposalSummaryScreen()
        {
            //GivenIamOnMpsNewProposalPage();
            //WhenIFillProposalDescription();
            // WhenIEnterCustomerInformationDetailForNewCustomer();
            //WhenIEnterTermAndTypeDetails();
            // WhenIChooseADeviceFromProductsScreen();

            Given("I am on MPS New Proposal Page");
            When("I fill Proposal Description");
            When("I enter Customer Information Detail for new customer");
            When("I Enter Term and Type details");
            When("I choose a device from Products screen");

            CurrentPage.As<CreateNewProposalPage>().MoveToProposalSummaryScreen();

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



        [When(@"I click the back button on Proposal Summary Screen")]
        public void WhenIClickTheBackButtonOnProposalSummaryScreen()
        {
            CurrentPage.As<CreateNewProposalPage>().ClickBackButtonDuringProposalProcess();
        }

        [Then(@"I am redirected to Products screen with earlier selected printer")]
        public void ThenIAmRedirectedToProductsScreenWithEarlierSelectedPrinter()
        {
            CurrentPage.As<CreateNewProposalPage>().IsProductScreenDisplayed();
            CurrentPage.As<CreateNewProposalPage>().VerifyEarlierSelectedPrinter();
            CurrentPage.As<CreateNewProposalPage>().ClickBackButtonDuringProposalProcess();
        }

        [Then(@"on product page all the device have full detail screen")]
        public void ThenOnProductPageAllTheDeviceHaveFullDetailScreen()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsFullDeviceScreenDisplayed();
        }

        [Then(@"on product page all the devices have reduced detail screen")]
        public void ThenOnProductPageAllTheDevicesHaveReducedDetailScreen()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsReducedDeviceScreenDisplayed();
        }

        [Then(@"on product page QTY for accessories are default to zero")]
        [When(@"on product page all the accessories all left with zero QTY")]
        public void ThenOnProductPageQTYForAccessoriesAreDefaultToZero()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsQTYForAccessoriesAreDefaultToZero();
        }

        [Then(@"the default total for all accessories are defaulted to zero")]
        public void ThenTheDefaultTotalForAllAccessoriesAreDefaultedToZero()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsTotalForAllAccessoriesAreDefaultToZero();
        }

        [When(@"enter a quantity value into an accessory field")]
        public void WhenEnterAQuantityValueIntoAnAccessoryField()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().FillProductDetails();
        }

        [When(@"I change the Unit Cost of an item")]
        public void WhenIChangeTheUnitCostOfAnItem()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductCostPrice("10");
        }

        [When(@"I change the Unit Price of an item")]
        public void WhenIChangeTheUnitPriceOfAnItem()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductSellPrice("10");
        }

        [When(@"I change the Margin of an item whose Unit Cost bigger than zero")]
        public void WhenIChangeTheMarginOfAnItemWhoseUnitCost()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductMargin("7");
        }

        [When(@"I change the Margin of an item whose Unit Cost is equal to zero")]
        public void WhenIChangeTheMarginOfAnItemWhoseUnitCostIsEqualToZero()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterDeliveryMargin("7");
        }

        [Then(@"the Unit Price changed accordingly")]
        public void ThenTheUnitPriceChangedAccordingly()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsProductUnitPriceChanged();
        }

        [Then(@"the Margin changes accordingly")]
        public void ThenTheMarginChangesAccordingly()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsProductMarginChanged();
        }

        [Then(@"the associated margin does not changed")]
        public void ThenProductdMarginDoesNotChanged()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotProductMarginChanged();
        }

        [Then(@"the associated Unit Cost dos not changed")]
        public void ThenTheAssociatedUnitCostDosNotChanged()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotProductUnitCostChanged();
        }

        [Then(@"the Unit Price and Unit Cost does not change")]
        public void ThenTheUnitPriceAndUnitCostDoesNotChange()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotDeliveryCostPriceChanged();
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotDeliverySellPriceChanged();
        }

        [Then(@"on product page the sum of the Total Price is equal to the Grand Total Price displayed")]
        public void ThenOnProductPageTheSumOfTheTotalPriceIsEqualToTheGrandTotalPriceDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsGrandTotalPriceCorrect();
        }

        [Then(@"on product page the Total Price is the product of QTY and Unit Price")]
        public void ThenOnProductPageTheTotalPriceIsTheProductOfQTYAndUnitPrice()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsTheTotalPriceTheProductOfQTYAndUnitPrice();
        }


        [When(@"I changed the Margin on any field to (.*)")]
        public void WhenIChangedTheMarginOnAnyFieldTo(string percent)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterDeliveryMargin(percent);
        }

        [When(@"I changed a Unit Price (.*) so that Margin is 100")]
        public void WhenIChangedAUnitPriceSoThatMarginIs(string percent)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterDeliverySellPrice(percent);
        }

        [When(@"I Click Add to Proposal button")]
        public void WhenIClickAddToProposalButton()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().AddAllDetailsToProposal();
        }

        [When(@"I Add the device to Proposal")]
        public void WhenIAddTheDeviceToProposal()
        {
            When(@"I Click Add to Proposal button");
            NextPage = CurrentPage.As<DealerProposalsCreateProductsPage>().NextButtonClick();
        }

        [Then(@"Add to proposal button become grayout")]
        public void ThenAddToProposalButtonBecomeGrayout()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAddToProposalButtonGrayout();
        }

        [Then(@"InstallationPackUnitCostLessThanError is displayed")]
        public void ThenInstallationPackUnitCostLessThanErrorIsDisplayed()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsInstallationPackUnitCostLessThanErrorDisplayed();
        }

        [Then(@"the product can not be added to the proposal")]
        public void ThenTheProductCanNotBeAddedToTheProposal()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotTheProductAddedToTheProposal();
        }


        [Then(@"the selected devices (.*) above are displayed on Summary Screen")]
        public void ThenTheSelectedDevicesAboveAreDisplayedOnSummaryScreen(string model)
        {
            CurrentPage.As<DealerProposalsCreateSummaryPage>().VerifySelectedDeviceIsDisplayed(model);
        }

        [Then(@"the three devices selected above are displayed on Summary Screen")]
        public void ThenTheThreeDevicesSelectedAboveAreDisplayedOnSummaryScreen()
        {
            CurrentPage.As<CreateNewProposalPage>().MoveToProposalSummaryScreen();
            CurrentPage.As<CreateNewProposalPage>().VerifyTheNumberOfPrintersOnSummaryPage(3);

            NextPage = CurrentPage.As<CreateNewProposalPage>().SaveProposal();

            CurrentPage.As<CloudExistingProposalPage>().IsProposalListProposalScreenDiplayed();
        }

        [Then(@"all the margin set above should be displayed in the right fields")]
        public void ThenPartOfMarginSetAboveShouldBeDisplayedInTheRightFields()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().StrictVerifyMarginFieldValues();
        }

        [When(@"I check Fax checkbox")]
        public void WhenICheckFaxCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchFax();
        }

        [Then(@"All printers that have Fax facility are returned")]
        public void ThenAllPrintersThatHaveFaxFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveFaxFacility();
        }

        [When(@"I check Scanner checkbox")]
        public void WhenICheckScannerCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchScanner();
        }

        [Then(@"All printers that have Scanner facility are returned")]
        public void ThenAllPrintersThatHaveScannerFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveScanFacility();
        }

        [When(@"I check Duplex checkbox")]
        public void WhenICheckDuplexCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchDuplex();
        }

        [Then(@"All printers that have Duplex facility are returned")]
        public void ThenAllPrintersThatHaveDuplexFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveDuplexFacility();
        }

        [When(@"I check Additional Tray checkbox")]
        public void WhenICheckAdditionalTrayCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchAdditionalTray();
        }

        [Then(@"All printers that have Additional Tray facility are returned")]
        public void ThenAllPrintersThatHaveAdditionalTrayFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveAdditionalTrayFacility();
        }

        [When(@"I check A4 checkbox")]
        public void WhenICheckA4Checkbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchA4();
        }

        [Then(@"All printers that have A4 facility are returned")]
        public void ThenAllPrintersThatHaveA4FacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveA4Facility();
        }

        [When(@"I check A3 checkbox")]
        public void WhenICheckA3Checkbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchA3();
        }

        [Then(@"All printers that have A3 facility are returned")]
        public void ThenAllPrintersThatHaveA3FacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveA3Facility();
        }

        [When(@"I check Mono checkbox")]
        public void WhenICheckMonoCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchMono();
        }

        [Then(@"All printers that have Mono facility are returned")]
        public void ThenAllPrintersThatHaveMonoFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveMonoFacility();
        }

        [When(@"I check Colour checkbox")]
        public void WhenICheckColourCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchColour();
        }

        [Then(@"All printers that have Colour facility are returned")]
        public void ThenAllPrintersThatHaveColourFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveColourFacility();
        }

        [When(@"I check Fax and Scanner checkbox")]
        public void WhenICheckFaxAndScannerCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchFax();
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchScanner();
        }

        [Then(@"All printers that have Fax and Scanner facility are returned")]
        public void ThenAllPrintersThatHaveFaxAndScannerFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveFaxFacility();
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveScanFacility();
        }

        [When(@"I check Duplex and Colour checkbox")]
        public void WhenICheckDuplexAndColourCheckbox()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchDuplex();
            CurrentPage.As<DealerProposalsCreateProductsPage>().TickRelineSearchColour();
        }

        [Then(@"All printers that have Duplex and Colour facility are returned")]
        public void ThenAllPrintersThatHaveDuplexAndColourFacilityAreReturned()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveDuplexFacility();
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersHaveColourFacility();
        }

        [When(@"I type in ""(.*)"" into the top RHS free-text filter")]
        public void WhenITypeInIntoTheTopRHSFree_TextFilter(string model)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().TypeIntoRHSFreeTextFilter(model);
        }

        [Then(@"All printers that contain ""(.*)"" is returned")]
        public void ThenAllPrintersThatContainIsReturned(string model)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllPrintersReturnedThatSearched(model);
        }

        [Then(@"all products are displayed as a flat list with no images")]
        [When(@"the products are displayed as Flat List")]
        public void ThenAllProductsAreDisplayedAsAFlatListWithNoImages()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyThatAllProductsDisplayedAsAFlatListWithNoImages();
        }

        [When(@"I changed the Product view to with images")]
        public void WhenIChangedTheProductViewToFlatList()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().ChangeProductViewToWithImages();
        }

        [Then(@"all products are displayed with images")]
        public void ThenAllProductsAreDisplayedWithImages()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyThatAllProductsDisplayedAsAWithImages();
        }

        [Then(@"this change to dealer margin is reverted to the original value")]
        public void ThenThisChangeToDealerMarginIsRevertedToTheOriginalValue()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsDealerMarginRevertedToTheOriginalValue();
        }

        [Then(@"this change to dealer margin is retained")]
        public void ThenThisChangeToDealerMarginIsRetained()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsDealerMarginRetainedByDealerAdminDefaultMargin();
        }

        [When(@"I change device installation type")]
        public void WhenIChangeDeviceInstallationType()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().ChangeDeviceInstallationType();
        }

        [Then(@"installation SRP value should change")]
        public void ThenInstallationSRPValueShouldChange()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyThatInstallationSRPValueChange();
        }

        [Then(@"the printers ""(.*)"" enabled in Local Office Admin are displayed on product screen")]
        public void ThenThePrintersEnabledInLocalOfficeAdminAreDisplayedOnProductScreen(string model)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsModelFound(model);
        }

        [Then(@"the printers ""(.*)"" disabled in Local Office Admin are not displayed on product screen")]
        public void ThenThePrintersDisabledInLocalOfficeAdminAreNotDisplayedOnProductScreen(string model)
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsNotModelFound(model);
        }

        [Then(@"all the SRP are not editable")]
        public void ThenAllTheSRPAreNotEditable()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsAllSRPNotEditable();
        }

        [Then(@"the QTY for Delivery Cost, Installation Cost and Service Pack are not editable")]
        public void ThenTheQTYForDeliveryCostInstallationCostAndServicePackAreNotEditable()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsDeliveryQuantityNotEditable();
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsInstallationQuantityNotEditable();
            CurrentPage.As<DealerProposalsCreateProductsPage>().IsServicepackQuantityNotEditable();
        }

        [Then(@"a change in product quantity affect the product TotalPrice")]
        public void ThenAChangeInProductQuantityAffectTheProductTotalPrice()
        {
            CurrentPage.As<DealerProposalsCreateProductsPage>().EnterProductQuantity("4");
            CurrentPage.As<DealerProposalsCreateProductsPage>().VerifyThatProductQuantityElementChanged();
        }

        [When(@"I navigate to dealer contract Approved Acceptance page")]
        public void WhenINavigateToDealerContractApprovedAcceptancePage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            CurrentPage.As<CloudContractPage>().IsContractScreenDisplayed();
        }

        [When(@"I navigate to dealer contract Awaiting Acceptance page")]
        public void WhenINavigateToDealerContractAwaitingAcceptancePage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            CurrentPage.As<CloudContractPage>().NavigateToAwaitingAcceptance();
        }

        [When(@"I navigate to dealer contract Rejected page")]
        public void WhenINavigateToDealerContractRejectedPage()
        {
            NextPage = CurrentPage.As<DealerDashBoardPage>().NavigateToContractScreenFromDealerDashboard();
            CurrentPage.As<CloudContractPage>().NavigateToRejectedContract();

        }


        [Then(@"I can successfully download a dealer Contract PDF")]
        public void ThenICanSuccessfullyDownloadADealerContractPDF()
        {
            CurrentPage.As<CloudContractPage>().DownloadAContractPDF();
        }

        [Then(@"I can successfully download a dealer Contract Invoice PDF")]
        public void ThenICanSuccessfullyDownloadADealerContractInvoicePDF()
        {
            CurrentPage.As<CloudContractPage>().DownloadAContractInvoicePDF();
        }



    }
}
