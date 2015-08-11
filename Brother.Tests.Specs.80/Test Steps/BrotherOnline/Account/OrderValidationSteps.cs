using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs._80.BrotherOnline.Account
{
    [Binding]
    public class OrderValidationSteps : BaseSteps
    {
        [Then(@"I can validate the order was processed via SAP for  ""(.*)")]
        public void ThenICanValidateTheOrderWasProcessedViaSap(string orderNumber)
        {
            TestCheck.AssertIsEqual(true, Utils.ConfirmSapOrder(orderNumber, 10), "SAP Order Validation");
        }

        [Then(@"I can validate the order ""(.*)"" of ""(.*)"" @ ""(.*)"" on the My Orders page")]
        public void ThenICanValidateTheOrderOnTheMyOrdersPage(int itemQty, string item, string itemPrice)
        {
            CheckIAmOnTheMyOrdersPage();
            TestCheck.AssertIsEqual(0, BasketModule.GetBasketItemsCount(CurrentDriver), "Basket Count Comparison");
            NextPage = CurrentPage.As<MyOrdersPage>().ViewOrderDetailsButtonClick();
        }

        [When(@"I can validate the order ""(.*)"" of ""(.*)"" @ ""(.*)"" on My Account page")]
        [Then(@"I can validate the order ""(.*)"" of ""(.*)"" @ ""(.*)"" on My Account page")]
        public void ThenICanValidateTheOrderOfOnMyAccountPage(int itemQty, string item, string itemPrice)
        {
            var orderNumber = ScenarioContext.Current["OrderConfirmationNumber"].ToString();
            ThenICanValidateTheOrderWasProcessedViaSap(orderNumber);
            ThenICanValidateTheOrderOnTheMyOrdersPage(itemQty, item, itemPrice);
            ThenICanValidateTheOrderDetails(itemQty, item, itemPrice, orderNumber);
        }

        private void ThenICanValidateTheOrderDetails(int itemQty, string item, string itemPrice, string orderNumber)
        {
            CurrentPage.As<OrderDetailsPage>().IsBackToOrderButtonAvailable();
            TestCheck.AssertIsEqual(0, BasketModule.GetBasketItemsCount(CurrentDriver), "Basket Count Comparison");
            NextPage = CurrentPage.As<OrderDetailsPage>().BackToOrderButtonClick();
            CheckIAmOnTheMyOrdersPage();
        }

        private void CheckIAmOnTheMyOrdersPage()
        {
            CurrentPage.As<MyOrdersPage>().IsViewOrderDetailsButtonAvailable();
        }
    }
}
