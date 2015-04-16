using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Checkout;
using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.BrotherMainSite.Basket;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline.Purchasing
{
    [Binding]
    public class OrderConfirmationSteps : BaseSteps
    {
        [When(@"I should see the Order Confirmation page")]
        [Then(@"I should see the Order Confirmation page")]
        public void ThenIShouldSeeTheOrderConfirmationPage()
        {
            CurrentPage.As<OrderConfirmationPage>().IsMyAccountButtonAvailable();
            // store order confirmation number
            ScenarioContext.Current.Add("OrderConfirmationNumber", CurrentPage.As<OrderConfirmationPage>().GetOrderConfirmationNumber());
            ScenarioContext.Current.Add("ProductInfo", CurrentPage.As<OrderConfirmationPage>().GetProductInfo());
        }

        [When(@"The purchased plan billing type is correct ""(.*)""")]
        [Then(@"The purchased plan billing type is correct ""(.*)""")]
        public void ThenThePurchasedPlanBillingTypeIsCorrect(string billingType)
        {
            Assert.AreEqual(billingType, CurrentPage.As<OrderConfirmationPage>().GetBillingType(), "Incorrect Billing Type");
        }


        [Then(@"I can validate I have ordered ""(.*)"" of ""(.*)"" @ ""(.*)""")]
        public void ThenICanValidateIHaveOrderedItemsOfThisPrice(int itemQuantity, string productItem, string itemPrice)
        {
            var price = BasketModule.GetItemPrice(CurrentDriver);
            Assert.AreEqual(itemPrice, price, "Incorrect Price");

            var item = CurrentPage.As<OrderConfirmationPage>().GetProductInfo();
            Assert.AreEqual(item.Contains("Quantity: " + itemQuantity), true, "Incorrect order quantity");
        }

        [When(@"If I click on My Account")]
        [Then(@"If I click on My Account")]
        public void ThenIfIClickOnMyAccount()
        {
            NextPage = CurrentPage.As<OrderConfirmationPage>().MyAccountButtonClick();
        }

    }
}
