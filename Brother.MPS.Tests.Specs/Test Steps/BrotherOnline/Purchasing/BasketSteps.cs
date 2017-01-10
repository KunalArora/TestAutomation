using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherOnline.Purchasing
{
    [Binding]
    public class BasketSteps : BaseSteps
    {
        [Then(@"I should see the item ""(.*)"" in the Basket")]
        public void ThenIShouldSeeTheItemInTheBasket(string productItem)
        {
            var basketItem = BasketModule.GetBasketInformationItem(CurrentDriver);
            TestCheck.AssertIsEqual(basketItem.Contains(productItem), true, "Basket Product Comparison");
        }

        [Then(@"I should see the item with ""(.*)"" in the Basket")]
        public void ThenIShouldSeeTheItemWithInTheBasket(string productItem)
        {
            var basketItem = BasketModule.GetBasketInformationItem(CurrentDriver);
            TestCheck.AssertIsEqual(basketItem.Contains(productItem), true, "Basket Product Comparison");
        }


        [Then(@"I should see the Basket item count change to ""(.*)""")]
        public void ThenIShouldSeeTheBasketItemCountChangeTo(int itemCount)
        {
            TestCheck.AssertIsEqual(itemCount, BasketModule.GetBasketItemsCount(CurrentDriver), "Basket Count Comparison");
        }

        [When(@"I click on Go to Basket")]
        public void WhenIClickOnGoToBasket()
        {
            NextPage = BasketModule.GoToBasketButtonClick(CurrentDriver);
        }

        [Then(@"I should see the item ""(.*)"" in the item list")]
        public void ThenIShouldSeeTheItemInTheItemList(string productItem)
        {
            CurrentPage.As<BasketPage>().IsCheckoutButtonAvailable();
            TestCheck.AssertIsEqual(CurrentPage.As<BasketPage>().GetItemInBasket(), productItem, "Product Comparison");
        }

        [Then(@"I should see the Basket items count is ""(.*)""")]
        public void ThenIShouldSeeTheBasketItemsCountIs(int itemCount)
        {
            CurrentPage.As<BasketPage>().IsCheckoutButtonAvailable();
            TestCheck.AssertIsEqual(itemCount, CurrentPage.As<BasketPage>().GetItemQuantity(), "Basket Count Comparison");
        }

        [When(@"I click Checkout")]
        public void WhenIClickCheckout()
        {
            NextPage = CurrentPage.As<BasketPage>().CheckOutButtonClick();
        }

        [When(@"I click on Basket")]
        public void WhenIClickOnBasket()
        {
            NextPage = BasketModule.BasketIconClick(CurrentDriver);
        }

        [Then(@"I should see Basket page")]
        public void ThenIShouldSeeBasketPage()
        {
            CurrentPage.As<BasketPage>().IsBasketPageCheckoutButtonDisplayed();
        }
        [When(@"I click Checkout on BasketPage")]
        public void WhenIClickCheckoutOnBasketPage()
        {
            NextPage = CurrentPage.As<BasketPage>().BasketPageCheckOutButtonClick();
        }

        [When(@"I click Checkout before loging")]
        public void WhenIClickCheckoutBeforeLoging()
        {
            NextPage = CurrentPage.As<BasketPage>().CheckOutButtonClickBeforeLogin();
        }

    }
}
