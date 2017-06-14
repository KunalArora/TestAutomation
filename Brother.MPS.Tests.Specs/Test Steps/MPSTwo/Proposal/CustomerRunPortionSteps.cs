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
        [Then(@"I navigate to customer dashboard page")]
        public void WhenINavigateToCustomerDashboardPage()
        {
            NextPage = CurrentPage.As<WelcomeBackPage>().NavigateToCustomerDashboardPage();
            CurrentPage.As<CustomerPortalDashboardPage>().IsCustomerDashboardPageDisplayed();
            
        }

        [Given(@"I navigate to consumable ordering page")]
        [When(@"I navigate to consumable ordering page")]
        public void WhenINavigateToConsumableOrderingPage()
        {
            NextPage = CurrentPage.As<CustomerPortalDashboardPage>().NavigateToCustomerConsummablePage();
            CurrentPage.As<CustomerPortalConsummablePage>().IsConsumableScreenDisplayed();
            CurrentPage.As<CustomerPortalConsummablePage>().RemoveExistingConsumableOrderBySerialNumber();
            CurrentPage.As<CustomerPortalConsummablePage>().IsCorrectDeviceSerialNumberDisplayed();
            NextPage = CurrentPage.As<CustomerPortalConsummablePage>().NavigateToConsumableRaiseOrderPage();
        }


        [Then(@"I navigate to consumable ordering page for multiple devices")]
        [Given(@"I navigate to consumable ordering page for multiple devices")]
        [When(@"I navigate to consumable ordering page for multiple devices")]
        public void WhenINavigateToConsumableOrderingPageForMultipleDevices()
        {
            NextPage = CurrentPage.As<CustomerPortalDashboardPage>().NavigateToCustomerConsummablePage();
            CurrentPage.As<CustomerPortalConsummablePage>().IsConsumableScreenDisplayed();
           // CurrentPage.As<CustomerPortalConsummablePage>().RemoveExistingConsumableOrderBySerialNumber();
            //CurrentPage.As<CustomerPortalConsummablePage>().IsCorrectDeviceSerialNumberDisplayed();
            NextPage = CurrentPage.As<CustomerPortalConsummablePage>().NavigateToConsumableExistingOrderListPage();
        }


        [Given(@"I navigate to consumable ordering page for ""(.*)""")]
        [When(@"I navigate to consumable ordering page for ""(.*)""")]
        public void WhenINavigateToConsumableOrderingPageFor(string serialNumber)
        {
            WhenINavigateToConsumableDevicePage(serialNumber);
        }


        public void WhenINavigateToConsumableDevicePage(string serialNumber)
        {
            NextPage = CurrentPage.As<CustomerPortalDashboardPage>().NavigateToCustomerConsummablePage();
            CurrentPage.As<CustomerPortalConsummablePage>().IsConsumableScreenDisplayed();
            CurrentPage.As<CustomerPortalConsummablePage>().IsCorrectDeviceSerialNumberDisplayed(serialNumber);
           // NextPage = CurrentPage.As<CustomerPortalConsummablePage>().NavigateToConsumableRaiseOrderPage();
        }

        [When(@"I navigate to Print Count page")]
        public void WhenINavigateToPrintCountPage()
        {
            NextPage = CurrentPage.As<CustomerPortalDashboardPage>().NavigateToCustomerPortalPrintCountPage();
            CurrentPage.As<CustomerPortalPrintCountPage>().IsCustomerPrintCountDisplayed();
        }

        [Then(@"the print counts attached to the device are correct")]
        public void ThenThePrintCountsAttachedToTheDeviceAreCorrect()
        {
            CurrentPage.As<CustomerPortalPrintCountPage>().VerifyPrintCountTotalDisplayedIsCorrect();
            CurrentPage.As<CustomerPortalPrintCountPage>().VerifyPrintCountColourDisplayedIsCorrect();
            CurrentPage.As<CustomerPortalPrintCountPage>().VerifyPrintCountMonoDisplayedIsCorrect();

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

            //CurrentPage.As<ConsumableExistingOrderListPage>().OpenOrderDetailModal();
            //CurrentPage.As<ConsumableExistingOrderListPage>().IsSapOrderIdInPopUpModal();
            //CurrentPage.As<ConsumableExistingOrderListPage>().IsSerialNumberinOrderDetailDisplayed();

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

        [Given(@"I change the ordering procedure to automatic")]
        [When(@"I change the ordering procedure to automatic")]
        public void WhenIChangeTheOrderingProcedureToAutomatic()
        {
            CurrentPage.As<CustomerPortalConsummablePage>().ChangeConsumableOrderToAutomaticOrdering();
            CurrentPage.As<CustomerPortalConsummablePage>().IsReplenishModeAutomation();
        }

        [Given(@"I create a consumable order for ""(.*)""")]
        [When(@"I create a consumable order for ""(.*)""")]
        public void WhenICreateAConsumableOrderFor(string toner)
        {
            CurrentPage.As<CustomerPortalConsummablePage>().ChangeTonerInkStatus(toner);
            CurrentPage.As<CustomerPortalConsummablePage>().RunConsumableOrderCreationJobs();
        }

        [When(@"I create a consumable order for ink life status for ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void WhenICreateAConsumableOrderForInkLifeStatusForAndAnd(string toner, string life, string number)
        {
            WhenICreateAConsumableOrderForLifeStatus(toner, life, number);
        }


        public void WhenICreateAConsumableOrderForLifeStatus(string toner, string life, string number)
        {
            CurrentPage.As<ConsumableExistingOrderListPage>().ChangeInkLifeStatus(toner, life, number);
            CurrentPage.As<ConsumableExistingOrderListPage>().RunConsumableOrderCreationJobs();
        }


        [Given(@"the newly created order is displayed")]
        [When(@"the newly created order is displayed")]
        [Then(@"the newly created order is displayed")]
        public void ThenTheNewlyCreatedOrderIsDisplayed()
        {
            CurrentPage.As<CustomerPortalConsummablePage>().IsCyanTonerCountDisplayed();
            NextPage = CurrentPage.As<CustomerPortalConsummablePage>().NavigateToConsumableExistingOrderListPage();
        }

        [Given(@"initial SAP order number is not created")]
        [When(@"initial SAP order number is not created")]
        [Then(@"initial SAP order number is not created")]
        public void ThenInitialSapOrderNumberIsNotCreated()
        {
            CurrentPage.As<ConsumableExistingOrderListPage>().IsCyanTonerDisplayed();
            CurrentPage.As<ConsumableExistingOrderListPage>().VerifyInitialSapOrderNumber();
        }

        [Given(@"SAP order number is created only after relevant job is ran")]
        [When(@"SAP order number is created only after relevant job is ran")]
        [Then(@"SAP order number is created only after relevant job is ran")]
        public void ThenSapOrderNumberIsCreatedOnlyAfterRelevantJobIsRan()
        {
            CurrentPage.As<ConsumableExistingOrderListPage>().RunSapOrderCreationJob();
            CurrentPage.As<ConsumableExistingOrderListPage>().VerifySapOrderNumberStartWithZero();
            CurrentPage.As<ConsumableExistingOrderListPage>().VerifySapOrderValueIsANumber();
        }

        [Given(@"order progress status is correct")]
        [When(@"order progress status is correct")]
        [Then(@"order progress status is correct")]
        public void ThenOrderProgressStatusIsCorrect()
        {
            CurrentPage.As<ConsumableExistingOrderListPage>().CyanOrderProgress();
        }


    }
}
