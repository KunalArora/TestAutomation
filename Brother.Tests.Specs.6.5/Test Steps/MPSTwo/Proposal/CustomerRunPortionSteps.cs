using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class CustomerRunPortionSteps : BaseSteps
    {
        [When(@"I navigate to customer dashboard page")]
        public void WhenINavigateToCustomerDashboardPage()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToCustomerDashboardPage();
            CurrentPage.As<CustomerDashboardPage>().IsCustomerDashboardPageDisplayed();
            NextPage = CurrentPage.As<CustomerDashboardPage>().NavigateToCustomerConsummablePage();
        }

        [When(@"I navigate to consumable ordering page")]
        public void WhenINavigateToConsumableOrderingPage()
        {
            CurrentPage.As<CustomerConsummablePage>().IsConsumableScreenDisplayed();
            CurrentPage.As<CustomerConsummablePage>().IsCorrectContractIdDisplayed();
            CurrentPage.As<CustomerConsummablePage>().IsCorrectDeviceSerialNumberDisplayed();
            NextPage = CurrentPage.As<CustomerConsummablePage>().NavigateToConsumableOrderingPage();
        }

        [Then(@"it is not possible to order a consumable")]
        public void ThenItIsNotPossibleToOrderAConsumable()
        {
            CurrentPage.As<ConsumableOrderingPage>().IsOrderingScreenDisplayed();
            CurrentPage.As<ConsumableOrderingPage>().IsCorrectSerialNumberDisplayed();
            CurrentPage.As<ConsumableOrderingPage>().IsOrderButtonDisabled();
        }



    }
}
