using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class CreateAProposalThatHasMoreThanOneDevicesSteps : BaseSteps
    {
        
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
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickSelectExistingCustomerButtonAndProceed();

            //Choose an existing contact
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().SelectARandomExistingContact();
            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
        }

      
    }
}
