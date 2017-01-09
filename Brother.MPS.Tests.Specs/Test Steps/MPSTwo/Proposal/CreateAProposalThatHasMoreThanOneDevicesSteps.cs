using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class CreateAProposalThatHasMoreThanOneDevicesSteps : BaseSteps
    {
        
        [When(@"I choose an existing contact from the list of available contacts")]
        public void WhenIChooseAnExistingContactFromTheListOfAvailableContacts()
        {
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickSelectExistingCustomerButtonAndProceed();

            //Choose an existing contact
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().SelectARandomExistingContact();
            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
        }

        [When(@"I skip contact creation process")]
        public void WhenISkipContactsCreationProcess()
        {
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickSkipCustomerButtonAndProceed();
        }

      
    }
}
