using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using Brother.WebSites.Core.Pages.BrotherOnline.Checkout;
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
            Helper.MsgOutput(string.Format("Page Source = [{0}]", CurrentDriver.PageSource));
            CurrentPage.As<OrderConfirmationPage>().IsMyAccountButtonAvailable();
            var pageSource = SeleniumHelper.RunScript("$('body').html();");
            Helper.MsgOutput(string.Format("Page Source = [{0}]", pageSource));
            // store order confirmation number
            ScenarioContext.Current.Add("OrderConfirmationNumber", CurrentPage.As<OrderConfirmationPage>().GetOrderConfirmationNumber());
            ScenarioContext.Current.Add("ProductInfo", CurrentPage.As<OrderConfirmationPage>().GetProductInfo());
        }

        [When(@"The purchased plan billing type is correct ""(.*)""")]
        [Then(@"The purchased plan billing type is correct ""(.*)""")]
        public void ThenThePurchasedPlanBillingTypeIsCorrect(string billingType)
        {
            TestCheck.AssertIsEqual(billingType, CurrentPage.As<OrderConfirmationPage>().GetBillingType(), "Incorrect Billing Type");
        }


        [Then(@"I can validate I have ordered ""(.*)"" of ""(.*)"" @ ""(.*)""")]
        public void ThenICanValidateIHaveOrderedItemsOfThisPrice(int itemQuantity, string productItem, string itemPrice)
        {
            var price = BasketModule.GetItemPrice(CurrentDriver);
            TestCheck.AssertIsEqual(itemPrice, price, "Incorrect Price");

            var item = CurrentPage.As<OrderConfirmationPage>().GetProductInfo();
            TestCheck.AssertIsEqual(item.Contains("Quantity: " + itemQuantity), true, "Incorrect order quantity");
        }

        [When(@"If I click on My Account")]
        [Then(@"If I click on My Account")]
        public void ThenIfIClickOnMyAccount()
        {
            NextPage = CurrentPage.As<OrderConfirmationPage>().MyAccountButtonClick();
        }

    }
}
