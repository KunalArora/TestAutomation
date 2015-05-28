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


        [When(@"I fill Proposal Description for ""(.*)"" program")]
        public void WhenIFillProposalDescriptionForProgram(string program)
        {
            CurrentPage.As<CreateNewProposalPage>().SelectingContractType(program);
            WhenIFillProposalDescription();
        }


        [Given(@"I fill Proposal Description")]
        [When(@"I fill Proposal Description")]
        public void WhenIFillProposalDescription()
        {
            CurrentPage.As<CreateNewProposalPage>().IsPromptTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().EnterProposalName("");
            CurrentPage.As<CreateNewProposalPage>().EnterLeadCodeRef("");
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
        }

        [When(@"I fill Proposal Description for ""(.*)"" Contract type")]
        public void WhenIFillProposalDescriptionForContractType(string contract)
        {
            CurrentPage.As<CreateNewProposalPage>().IsPromptTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().SelectingContractType(contract);
            CurrentPage.As<CreateNewProposalPage>().EnterProposalName("");
            CurrentPage.As<CreateNewProposalPage>().EnterLeadCodeRef("");
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
        }

        
        [Given(@"I skip Customer Information Screen")]
        public void GivenISkipCustomerInformationScreen()
        {
            CurrentPage.As<CreateNewProposalPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().ClickSkipCustomerRadioButton();
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();

        }

        [When(@"I arrive at ""(.*)"" screen")]
        public void WhenIArriveAtScreen(string screenToVerify)
        {
            WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetails("", "", "");
            CurrentPage.As<CreateNewProposalPage>().VerifyProposalScreenAfterNavigation(screenToVerify);
        }

        
        [When(@"I enter Customer Information Detail for new customer")]
        public void WhenIEnterCustomerInformationDetailForNewCustomer()
        {
            CurrentPage.As<CreateNewProposalPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().ClickCreateNewCustomerRadioButton();
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();

           // CurrentPage.As<CreateNewProposalPage>().ClickNewOrganisationButton();
//            CurrentPage.As<CreateNewProposalPage>().IsPrivateLiableCheckBoxDiplayed();

            CurrentPage.As<CreateNewProposalPage>().FillOrganisationDetails();
            CurrentPage.As<CreateNewProposalPage>().FillOrganisationContactDetail();
            CurrentPage.As<CreateNewProposalPage>().TickOrderConsumables();

            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
        }

        [Given(@"I Enter ""(.*)"" usage type ""(.*)"" contract length and ""(.*)"" billing on Term and Type details")]
        [When(@"I Enter ""(.*)"" usage type ""(.*)"" contract length and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterUsageTypeContractLengthAndBillingOnTermAndTypeDetails(string usage, string contract, string billing)
        {
            CurrentPage.As<CreateNewProposalPage>().IsTermAndTypeTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().SelectUsageType(usage);
            CurrentPage.As<CreateNewProposalPage>().SelectContractLength(contract);
            CurrentPage.As<CreateNewProposalPage>().SelectPayPerClickBillingCycle(billing);

            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
        }


        [Given(@"I Enter ""(.*)"" contract terms ""(.*)"" leasing and ""(.*)"" billing on Term and Type details")]
        [When(@"I Enter ""(.*)"" contract terms ""(.*)"" leasing and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterContractTermsLeasingAndBillingOnTermAndTypeDetails(string contract, string leasing, string billing)
        {
            CurrentPage.As<CreateNewProposalPage>().IsTermAndTypeTextDisplayed();

            CurrentPage.As<CreateNewProposalPage>().SelectContractLength(contract);
            CurrentPage.As<CreateNewProposalPage>().SelectLeaseBillingCycle(leasing);
            CurrentPage.As<CreateNewProposalPage>().SelectPayPerClickBillingCycle(billing);

            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
        }

        [When(@"I Enter ""(.*)"" contract terms and ""(.*)"" billing on Term and Type details")]
        public void WhenIEnterContractTermsAndBillingOnTermAndTypeDetails(string contract, string billing)
        {
            CurrentPage.As<CreateNewProposalPage>().IsTermAndTypeTextDisplayed();

            CurrentPage.As<CreateNewProposalPage>().SelectContractLength(contract);
            CurrentPage.As<CreateNewProposalPage>().SelectPayPerClickBillingCycle(billing);
        }

        [When(@"I tick Price Hardware radio button")]
        public void WhenITickPriceHardwareRadioButton()
        {
            CurrentPage.As<CreateNewProposalPage>().TickPriceHardware();

            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
        }

        [When(@"I choose ""(.*)"" from Products screen")]
        public void WhenIChooseFromProductsScreen(string printer)
        {
            CurrentPage.As<CreateNewProposalPage>().IsProductScreenTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().ChooseADeviceFromProductSelectionScreen(printer, "80", "90");
            CurrentPage.As<CreateNewProposalPage>().VerifyProductAdditionConfirmationMessage();
        
        }


        [When(@"I display ""(.*)"" device screen")]
        public void WhenIDisplayDeviceScreen(string printer)
        {
            CurrentPage.As<CreateNewProposalPage>().IsProductScreenTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().ClickOnAPrinter(printer);
        }



        [When(@"I enter click price volume of ""(.*)"" and ""(.*)""")]
        public void WhenIEnterClickPriceVolumeOf(string clickprice, string colour)
        {
            CurrentPage.As<CreateNewProposalPage>().CalculateClickPriceAndProceed(clickprice, colour);
        }

        [When(@"I type in click price volume of ""(.*)""")]
        public void WhenITypeInClickPriceVolumeOf(string monoVol)
        {
            CurrentPage.As<CreateNewProposalPage>().CalculateEnteredClickPriceAndProceed(monoVol);
        }


        [When(@"I select click price volume of ""(.*)""")]
        public void WhenISelectClickPriceVolumeOf(string monoVol)
        {
            CurrentPage.As<CreateNewProposalPage>().CalculateEPPClickPriceAndProceed(monoVol);
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

        [Then(@"I can go back to ""(.*)"" screen which retain earlier selected values")]
        public void ThenICanGoBackToScreenWhichRetainEarlierSelectedValues(string screen)
        {
            CurrentPage.As<CreateNewProposalPage>().VerifyProposalScreensRetainValuesAfterbackNavigation(screen);

        }

        [Then(@"I can still create a proposal with the information above")]
        public void ThenICanStillCreateAProposalWithTheInformationAbove()
        {
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
            CurrentPage.As<CreateNewProposalPage>().SaveProposal();

            CurrentPage.As<CloudExistingProposalPage>().IsNewProposalTemplateCreated();
        }

        [Then(@"on product page all the device have full detail screen")]
        public void ThenOnProductPageAllTheDeviceHaveFullDetailScreen()
        {
            CurrentPage.As<CreateNewProposalPage>().IsFullDeviceScreenDisplayed();
        }

    }
}
