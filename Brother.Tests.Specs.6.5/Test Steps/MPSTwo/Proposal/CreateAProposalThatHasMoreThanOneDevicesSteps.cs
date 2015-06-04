using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class CreateAProposalThatHasMoreThanOneDevicesSteps : BaseSteps
    {
        [When(@"I choose three devices from Products screen")]
        public void WhenIChooseThreeDevicesFromProductsScreen()
        {
            CurrentPage.As<CreateNewProposalPage>().ChooseADeviceFromProductSelectionScreen("HL-5470DW", "80", "100");
            CurrentPage.As<CreateNewProposalPage>().ChooseADeviceFromProductSelectionScreen("DCP-L8450CDW", "100", "120");
            CurrentPage.As<CreateNewProposalPage>().ChooseADeviceFromProductSelectionScreen("MFC-8520DN", "120", "140");

            CurrentPage.As<CreateNewProposalPage>().VerifyProductAdditionConfirmationMessage();
            CurrentPage.As<CreateNewProposalPage>().VerifyHowManyPrinterWasAddedOnProductScreen(3);
           
        }

        
        
        [Then(@"the three devices selected above are displayed on Summary Screen")]
        public void ThenTheThreeDevicesSelectedAboveAreDisplayedOnSummaryScreen()
        {
            CurrentPage.As<CreateNewProposalPage>().MoveToProposalSummaryScreen();
            CurrentPage.As<CreateNewProposalPage>().VerifyTheNumberOfPrintersOnSummaryPage(3);

            NextPage = CurrentPage.As<CreateNewProposalPage>().SaveProposal();

            CurrentPage.As<CloudExistingProposalPage>().IsProposalListProposalScreenDiplayed();
        }

        [When(@"I choose an existing contact from the list of available contacts")]
        public void WhenIChooseAnExistingContactFromTheListOfAvailableContacts()
        {
            CurrentPage.As<CreateNewProposalPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<CreateNewProposalPage>().ClickSelectExistingCustomerRadioButton();
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton_old();

            //Choose an existing contact
            CurrentPage.As<CreateNewProposalPage>().SelectARandomExistingContact();
            CurrentPage.As<CreateNewProposalPage>().ClickNextButton_old();
//            CurrentPage.As<CreateNewProposalPage>().TickOrderConsumables();

            //NextPage = CurrentPage.As<CreateNewProposalPage>().ClickNextButton();
        }

      
    }
}
