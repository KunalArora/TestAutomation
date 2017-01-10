using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class DealerProposalsCreateCustomerInformationStep : BaseSteps
    {
        [When(@"I click the back button on Customer Information Screen")]
        public void WhenIClickTheBackButtonOnCustomerInformationScreen()
        {
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickBackButtonDuringProposalProcess();

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
            if (!customerOption.Equals("Skip customer creation"))
            {
                CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().CustomerCreationOptions(customerOption);
                CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().FillOrganisationContactDetail();
                CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().FillOrganisationDetails();
                NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
            }
            else
            {
                NextPage =
                 CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickSkipCustomerButtonAndProceed(); 
            }
            
        }

       public void SelectExistingCustmerByRandomly()
        {
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickSelectExistingCustomerButtonAndProceed();
            CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().SelectARandomExistingContact();
            NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
        }

       public void SelectASpecificExistingCustomer(string customer)
       {
           CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().IsCustomerInfoTextDisplayed();
           CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickSelectExistingCustomerButtonAndProceed();
           CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().SelectASpecificExistingContact(customer);
           NextPage = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>().ClickNextButton();
       }

        public void EditCustomerInformationTab()
        {
            var page = CurrentPage.As<DealerProposalsCreateCustomerInformationPage>();
            page.EditProposalCustomerInformation(CurrentDriver);
            NextPage = page.ClickNextButton();
        }
    }
}
