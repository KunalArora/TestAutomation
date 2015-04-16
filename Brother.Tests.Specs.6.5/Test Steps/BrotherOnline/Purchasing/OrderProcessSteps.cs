using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Basket;
using Brother.Tests.Selenium.Lib.Pages.BrotherOnline.Checkout;
using Brother.Tests.Selenium.Lib.Support;
using BrotherWebSitesCore.Pages.Base;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Brother.Tests.Specs.BrotherOnline.Purchasing
{
    [Binding]
    public class OrderProcessSteps : BaseSteps
    {
        OrderSummarySteps _orderSummary = new OrderSummarySteps();

        [Then(@"I can go through the order process for Country ""(.*)"" with order info ""(.*)""")]
        public void ThenICanGoThroughTheOrderProcessForCountryWithOrderInfo(string country, int quantity)
        {
            _orderSummary.ThenICanValidateTheOrderDetails(quantity);
            _orderSummary = null;
            // Order Summary page
            Then("I click Place Your Order");
            // Credit Card details page
            Then("I can enter a valid set of Credit Card details");
        }
        
        // Cancels at the point of credit card details entry
        [Then(@"I can go through a dummy order process for Country ""(.*)"" with order info ""(.*)""")]
        public void ThenICanGoThroughADummyOrderProcessForCountryWithOrderInfo(string country, int quantity)
        {
            _orderSummary.ThenICanValidateTheOrderDetails(quantity);
            _orderSummary = null;
            // Order Summary page
            Then("I click Place Your Order");
            // Credit Card details page
            When("I enter valid credit card details for a Visa Credit Card");
            When("I click Cancel I should return to the Order Summary page");
        }
    }
}
