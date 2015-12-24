using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherMainSite.SuppliesAndAccessories
{
    [Binding]
    public class PurchaseANewInkCartridgeSteps : BaseSteps
    {
        [Given(@"I have clicked on Supplies")]
        public void GivenIHaveClickedOnSupplies()
        {
            CurrentPage.As<MainSiteHomePage>().IsSuppliesLinkAvailable();
            NextPage = CurrentPage.As<MainSiteHomePage>().ClickSuppliesLink();
        }

    
        [Given(@"I have entered supply code ""(.*)""")]
        public void GivenIHaveEnteredSupplyCode(string supplyNumber)
        {
           
            CurrentPage.As<SuppliesPage>().AddSupplyCode(supplyNumber);
        }

        [Given(@"I have entered supply code as ""(.*)""")]
        public void GivenIHaveEnteredSupplyCodeAs(string supplyNumber)
        {
            CurrentPage.As<SuppliesPage>().AddSupplyCode(supplyNumber);
        }


        [Given(@"I have entered my valid device code for an InkJet printer ""(.*)""")]
        public void GivenIHaveEnteredMyValidDeviceCodeForAnInkJetPrinter(string modelNumber)
        {
            CurrentPage.As<SuppliesPage>().AddModelCode(modelNumber);
        }

        [Given(@"I have entered my valid supplies code for an InkJet cartridge ""(.*)""")]
        public void GivenIHaveEnteredMyValidSuppliesCodeForAnInkJetCartridge(string supplyCode)
        {
            CurrentPage.As<SuppliesPage>().AddSupplyCode(supplyCode);
        }

        [When(@"I click on search for model ""(.*)""")]
        public void WhenIClickOnSearchForModel(string modelNumber)
        {
            NextPage = CurrentPage.As<SuppliesPage>().SearchModelSuppliesButtonClick();
        }

   
        [When(@"I click on search for""(.*)""")]
        public void WhenIClickOnSearchFor(string p0)
        {
            NextPage = CurrentPage.As<SuppliesPage>().SearchSuppliesButtonClick();
        }

        [When(@"I click on search for supply code as ""(.*)""")]
        public void WhenIClickOnSearchForSupplyCodeAs(string p0)
        {
            NextPage = CurrentPage.As<SuppliesPage>().SearchSuppliesButtonClick();
        }

        [Then(@"I should be on Basket page of ""(.*)""")]
        public void ThenIShouldBeOnBasketPageOf(string supplyCode)
        {
           
           //CurrentPage.As<BasketPage>().GetBasketInformationItem();
          //  CurrentPage.As<BasketPage>().GetItemInBasket();
            InkJetCartridgePage.SetExtraPageTitle = supplyCode; // sets the supply page title based on supply item
            NextPage = CurrentPage.As<SuppliesPage>().SearchSuppliesButtonClick();
        }

        [Then(@"I should see the selected item information page priced at ""(.*)"" inc vat")]
        public void ThenIShouldSeeTheSelectedItemInformationPagePricedAtIncVat(string productItem)
        {
            CurrentPage.As<InkJetCartridgePage>().IsAddToBasketButtonAvailable();
            TestCheck.AssertIsEqual(BasketModule.GetItemPrice(TestController.CurrentDriver).Contains(productItem), true, "Invalid price for item");
        }
      
        [Then(@"I should see the selected item information page priced at ""(.*)"" inc vat on basket page")]
        public void ThenIShouldSeeTheSelectedItemInformationPagePricedAtIncVatOnBasketPage(string productItem)
        {
            CurrentPage.As<InkJetCartridgePage>().IsAddToBasketButtonAvailable();
            TestCheck.AssertIsEqual(BasketModule.GetItemPrice(TestController.CurrentDriver).Contains(productItem), true, "Invalid price for item");
        }

        [Then(@"I should see the selected item information page")]
        public void ThenIShouldSeeTheSelectedItemInformationPage()
        {
            CurrentPage.As<InkJetCartridgePage>().IsAddToBasketButtonAvailable();
        }

        [When(@"I click on search for supply ""(.*)""")]
        public void WhenIClickOnSearchForSupply(string supplyCode)
        {
            InkJetCartridgePage.SetExtraPageTitle = supplyCode; // sets the supply page title based on supply item
            NextPage = CurrentPage.As<SuppliesPage>().SearchSuppliesButtonClick();
        }

        [Then(@"I should see an a list of associated items for model ""(.*)""")]
        public void ThenIShouldSeeAnAListOfAssociatedItems(string productName)
        {
            CurrentPage.As<OriginalSuppliesPage>().IsSuppliesCategoryListAvailable();
        }

     
        [Then(@"I should see an a list of associated items for entered supply code")]
        public void ThenIShouldSeeAnAListOfAssociatedItemsForEnteredSupplyCode()
        {
            CurrentPage.As<SuppliesPage>().IsSuppliesSearchButtonAvailable();
        }

        [Then(@"If I click on the item ""(.*)""")]
        public void ThenIfIClickOnTheItem(string productItem)
        {
            InkJetCartridgePage.SetExtraPageTitle = productItem;
            NextPage = CurrentPage.As<OriginalSuppliesPage>().InkJetCartridgeItemClick(productItem);
        }

        [When(@"I click on Add To Basket")]
        public void WhenIClickOnAddToBasket()
        {
           TestCheck.AssertIsEqual(0, BasketModule.GetBasketItemsCount(CurrentDriver), "Invalid Basket item count");
            CurrentPage.As<InkJetCartridgePage>().AddToBasketButtonClick();
      
        }
    }
}

