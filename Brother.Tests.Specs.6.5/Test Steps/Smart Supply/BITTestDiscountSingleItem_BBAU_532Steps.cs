using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.Smart_Supply;
using TechTalk.SpecFlow;
using Brother.Tests.Selenium.Lib.Pages.BrotherMainSite.Smart_Supply;


namespace Brother.Tests.Specs.Test_Steps.Smart_Supply
{
    [Binding]
    public class BITTestDiscountSingleItem_BBAU_532Steps : BaseSteps
    {
        [When(@"I  click the smart supply basket icon")]
        public void WhenIClickTheSmartSupplyBasketIcon()
        {
            CurrentPage.As<SmartSupplyProductPage>().ClickBasketIcon();
        }

        [When(@"I click the checkout button")]
        public void WhenIClickTheCheckoutButton()
        {
            CurrentPage.As<SmartSupplyProductPage>().ClickCheckOutButtonSmartSupply();
        }

        [When(@"I can see brother supply club benefits checkbox in the basket page")]
        public void WhenICanSeeBrotherSupplyClubBenefitsCheckboxInTheBasketPage()
        {
            NextPage = SmartSupplyBasketPage.Basketpageload(CurrentDriver);
            CurrentPage.As<SmartSupplyBasketPage>().IsBSCOptincheckboxAvailable();
        }

        [When(@"I can see the Brother Club discounts offers on basket page")]
        public void WhenICanSeeTheBrotherClubDiscountsOffersOnBasketPage()
        {
            CurrentPage.As<SmartSupplyBasketPage>().IsBCDiscountElementsAvailableInBasketPage();
        }

        [When(@"I can see the product discount ""(.*)"" before opting in to Brother Supply Club")]
        public void WhenICanSeeTheProductDiscountBeforeOptingInToBrotherSupplyClub(string normaluserdiscount)
        {
            CurrentPage.As<SmartSupplyBasketPage>().CheckForDiscountAmount(normaluserdiscount);
        }

    }
}
