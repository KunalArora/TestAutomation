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

        [When(@"I can see brother supply club benefits checkbox in the basket page")]
        public void WhenICanSeeBrotherSupplyClubBenefitsCheckboxInTheBasketPage()
        {
            CurrentPage.As<SmartSupplyBasketPage>().IsBSCOptincheckboxAvailable();
        }
    }
}
