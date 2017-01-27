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

       

    }
}

