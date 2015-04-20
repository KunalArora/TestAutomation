using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.MPSOne;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSOne
{
    [Binding]
    public class ExistingContractSteps : BaseSteps
    {
        [When(@"I search for a contract element '(.*)'")]
        public void WhenISearchForAContractElement(string value)
        {
            CurrentPage.As<ExistingContractPage>().SearchForContractElement(value);
        }

       
        [Then(@"that contract '(.*)' of '(.*)' should be displayed")]
        public void ThenThatContractShouldBeDisplayed(string element, string value)
        {
            CurrentPage.As<ExistingContractPage>().VerifyContractsAreDisplayed();
            CurrentPage.As<ExistingContractPage>().VerifyTheCorrectContractElementIsReturned(element, element);
        }


        [When(@"I filter contracts using contract status '(.*)'")]
        public void WhenIFilterContractsUsingContractStatus(string status)
        {
            CurrentPage.As<ExistingContractPage>().ClearAndSelectStatus(status);

        }

        [When(@"the result for the contract status '(.*)' is displayed")]
        public void WhenTheResultForTheContractStatusIsDisplayed(string status)
        {
            CurrentPage.As<ExistingContractPage>().VerifyTheCorrectStatusIsReturned(status);
        }

        [When(@"I filter those contracts above using organisation '(.*)'")]
        public void WhenIFilterThoseContractsAboveUsingOrganisation(string organisation)
        {
            CurrentPage.As<ExistingContractPage>().SearchForContractElement(organisation);
        }

        [Then(@"the result is filtered more to only show organisation '(.*)' with contract status '(.*)'")]
        public void ThenTheResultIsFilteredMoreToOnlyShowOrganisationWithContractStatus(string organisation, string status)
        {
            CurrentPage.As<ExistingContractPage>().VerifyContractsAreDisplayed();
            CurrentPage.As<ExistingContractPage>().VerifyMultipleCriteriaResult(organisation, status);
        }

    }
}
