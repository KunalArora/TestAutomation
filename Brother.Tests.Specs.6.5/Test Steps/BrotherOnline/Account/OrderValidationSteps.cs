using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Basket;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.AccountManagement;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.BrotherMainSite.Basket;
using BrotherWebSitesCore.Pages.BrotherOnline.AccountManagement;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline.Account
{
    [Binding]
    public class OrderValidationSteps : BaseSteps
    {
        [Then(@"I can validate the order was processed via SAP for  ""(.*)")]
        public void ThenICanValidateTheOrderWasProcessedViaSap(string orderNumber)
        {
            Assert.AreEqual(true, Utils.ConfirmSapOrder(orderNumber, 10), "SAP Order Validation");
        }

        [Then(@"I can validate the order ""(.*)"" of ""(.*)"" @ ""(.*)"" on the My Orders page")]
        public void ThenICanValidateTheOrderOnTheMyOrdersPage(int itemQty, string item, string itemPrice)
        {
            CheckIAmOnTheMyOrdersPage();
            Assert.AreEqual(0, BasketModule.GetBasketItemsCount(CurrentDriver), "Basket Count Comparison");
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
            Assert.AreEqual(0, BasketModule.GetBasketItemsCount(CurrentDriver), "Basket Count Comparison");
            NextPage = CurrentPage.As<OrderDetailsPage>().BackToOrderButtonClick();
            CheckIAmOnTheMyOrdersPage();
        }

        private void CheckIAmOnTheMyOrdersPage()
        {
            CurrentPage.As<MyOrdersPage>().IsViewOrderDetailsButtonAvailable();
        }
    }
}
