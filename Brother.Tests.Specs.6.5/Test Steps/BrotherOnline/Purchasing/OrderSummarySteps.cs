using BrotherWebSitesCore.Pages.Base;
using BrotherWebSitesCore.Pages.BrotherOnline.Checkout;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline.Purchasing
{
    [Binding]
    public class OrderSummarySteps : BaseSteps
    {
        [Then(@"I should see the Order Summary page")]
        public void ThenIShouldSeeTheOrderSummaryPage()
        {
            CurrentPage.As<OrderSummaryPage>().IsPlaceYourOrderButtonAvailable();
        }

        [Then(@"I click Place Your Order")]
        public void ThenICanProcessMyOrder()
        {
            CurrentPage.As<OrderSummaryPage>().IsPlaceYourOrderButtonAvailable();
            CurrentPage.As<OrderSummaryPage>().CheckTermsAndConditions();
            CurrentPage.As<OrderSummaryPage>().PlaceYourOrderButtonClick();
        }

        [Then(@"I can validate the order details")]
        [Then(@"I can validate the order details ""(.*)"" of ""(.*)"" @ ""(.*)"" ")]
        public void ThenICanValidateTheOrderDetails(int itemQty)
        {
            Then("I should see the Order Summary page");

            var itemDetails = CurrentPage.As<OrderSummaryPage>().GetProductInfo();
            Assert.AreEqual(itemDetails.Contains("Quantity: " + itemQty), true, "Incorrect itenm quantity");
        }
    }
}
