using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using Brother.WebSites.Core.Pages.MPSTwo;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.MPSTwo.Proposal
{
    [Binding]
    public class CustomerRunPortionSteps : BaseSteps
    {
        [Given(@"I navigate to customer dashboard page")]
        [When(@"I navigate to customer dashboard page")]
        public void WhenINavigateToCustomerDashboardPage()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToCustomerDashboardPage();
            CurrentPage.As<CustomerDashboardPage>().IsCustomerDashboardPageDisplayed();
            NextPage = CurrentPage.As<CustomerDashboardPage>().NavigateToCustomerConsummablePage();
        }

        [Given(@"I navigate to consumable ordering page")]
        [When(@"I navigate to consumable ordering page")]
        public void WhenINavigateToConsumableOrderingPage()
        {
            CurrentPage.As<CustomerConsummablePage>().IsConsumableScreenDisplayed();
            //CurrentPage.As<CustomerConsummablePage>().IsCorrectContractIdDisplayed();
            CurrentPage.As<CustomerConsummablePage>().IsCorrectDeviceSerialNumberDisplayed();
            NextPage = CurrentPage.As<CustomerConsummablePage>().NavigateToConsumableRaiseOrderPage();
        }

        [Then(@"it is not possible to order a consumable")]
        public void ThenItIsNotPossibleToOrderAConsumable()
        {
            CurrentPage.As<ConsumableRaiseOrderPage>().IsOrderingScreenDisplayed();
            CurrentPage.As<ConsumableRaiseOrderPage>().IsCorrectSerialNumberDisplayed();
            CurrentPage.As<ConsumableRaiseOrderPage>().IsOrderButtonDisabled();
        }


        [When(@"I order consumables for the device")]
        [Then(@"I order consumables for the device")]
        [When(@"I can order consumables for the device")]
        [Then(@"I can order consumables for the device")]
        public void ThenICanOrderConsumablesForTheDevice()
        {
            CurrentPage.As<ConsumableRaiseOrderPage>().IsOrderingScreenDisplayed();
            CurrentPage.As<ConsumableRaiseOrderPage>().SelectBlackToner();
            CurrentPage.As<ConsumableRaiseOrderPage>().SubmitConsumableForOrder();
            CurrentPage.As<ConsumableRaiseOrderPage>().IsConsumableOrderSubmitted();
            NextPage = CurrentPage.As<ConsumableRaiseOrderPage>().NavigateToConsumableExistingOrderListPage();

        }


        [Then(@"the newly ordered consumable order has correct details")]
        public void ThenTheNewlyOrderedConsumableOrderHasCorrectDetails()
        {
            CurrentPage.As<ConsumableExistingOrderListPage>().IsBlackTonerDisplayed();
            CurrentPage.As<ConsumableExistingOrderListPage>().IsSerialNumberDisplayedOnOrderListPage();
            CurrentPage.As<ConsumableExistingOrderListPage>().InitialOrderProgress();
            CurrentPage.As<ConsumableExistingOrderListPage>().StoreOrderDetails();

            CurrentPage.As<ConsumableExistingOrderListPage>().OpenOrderDetailModal();
            CurrentPage.As<ConsumableExistingOrderListPage>().IsSapOrderIdInPopUpModal();
            CurrentPage.As<ConsumableExistingOrderListPage>().IsSerialNumberinOrderDetailDisplayed();

        }

        [Then(@"the newly created consumable order has correct details in pop up information")]
        public void ThenTheNewlyCreatedConsumableOrderHasCorrectDetailsInPopUpInformation()
        {
            CurrentPage.As<ConsumableExistingOrderListPage>().OpenOrderDetailModal();
            CurrentPage.As<ConsumableExistingOrderListPage>().IsSapOrderIdInPopUpModal();
            CurrentPage.As<ConsumableExistingOrderListPage>().IsSerialNumberinOrderDetailDisplayed();

        }


        [Then(@"the consumable ordered can be successfully progressed")]
        public void ThenTheConsumableOrderedCanBeSuccessfullyProgressed()
        {
           CurrentPage.As<ConsumableExistingOrderListPage>().ClosedConsumableOrder();
            CurrentPage.As<ConsumableExistingOrderListPage>().ReloadExistingOrderScreen();
            CurrentPage.As<ConsumableExistingOrderListPage>().ClosedOrderProgress();
        }




    }
}
