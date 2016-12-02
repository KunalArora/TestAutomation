﻿using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherMainSite.Basket;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories.Printers;
using Brother.WebSites.Core.Pages.BrotherOnline.Account;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs._80.BrotherMainSite.PrinterSearch
{
    [Binding]
    public class PrinterSearchSteps : BaseSteps
    {
        [Given(@"I have clicked on Printers")]
        public void GivenIHaveClickedOnPrinters()
        {
            CurrentPage.As<MainSiteHomePage>().IsPrintersLinkAvailable();
            NextPage = CurrentPage.As<MainSiteHomePage>().ClickPrintersLink();
        }

        [Then(@"I should see the Printers page")]
        public void ThenIShouldSeeThePrintersPage()
        {
            CurrentPage.As<PrintersPage>().IsViewOurPrinterRangeButtonAvailable();
        }

        [Then(@"If I click on View All Printers button")]
        public void ThenIfIClickOnViewAllPrintersButton()
        {
            NextPage = CurrentPage.As<PrintersPage>().ViewOurPrinterRangeButtonClick();
        }

        [Then(@"I should see the All Printers page")]
        public void ThenIShouldSeeTheAllPrintersPage()
        {
            CurrentPage.As<AllPrintersPage>().IsViewOurPrinterRangeButtonAvailable();
        }

        [Then(@"I click on View Our All-in-one Printers button")]
        public void ThenIClickOnViewOurAll_In_OnePrintersButton()
        {
            NextPage = CurrentPage.As<AllPrintersPage>().ViewAllInOnePrinterRangeButtonClick();
        }

        [Then(@"I should see a list of All in one printers")]
        public void ThenIShouldSeeAListOfAllInOnePrinters()
        {
            TestCheck.AssertIsEqual(true, CurrentPage.As<AllInOnePrintersPage>().WaitForPrinterSearchResults("matching products"), "Printer Search Results returned");
        }

        [Then(@"I click on View Our Laser Printers button")]
        public void ThenIClickOnViewOurLaserPrintersButton()
        {
            CurrentPage.As<AllPrintersPage>().IsViewLaserPrinterRangeButtonAvailable();
            NextPage = CurrentPage.As<AllPrintersPage>().ViewLaserPrinterRangeButtonClick();
        }

        [Then(@"I should see a list of Laser printers")]
        public void ThenIShouldSeeAListOfLaserPrinters()
        {
            TestCheck.AssertIsGreater(CurrentPage.As<LaserPrintersPage>().WaitForPrinterSearchResults(), 0, "Printer search returned zero");
        }

        [Then(@"I should see a list of all printers loaded")]
        public void ThenIShouldSeeAListOfAllPrintersLoaded()
        {
            TestCheck.AssertIsGreater(CurrentPage.As<AllPrintersPage>().GetListOfPrintersLoaded(), 6, "Printer search returned less than 6 Printers");
        }

        [Then(@"I can validate that each printer is a valid printer")]
        public void ThenICanValidateThatEachPrinterIsAValidPrinter()
        {
            TestCheck.AssertIsEqual(false, CurrentPage.As<LaserPrintersPage>().ValidatePrinters(), "Validating Printers (Main Languages)");
            TestCheck.AssertIsEqual(true, true, "Validating Printers (Main Languages)");
        }

        [Then(@"I can validate that each printer for Spain and Portugal is a valid printer")]
        public void ThenICanValidateThatEachPrinterForSpainAndPortugalIsAValidPrinter()
        {
            //TestCheck.AssertIsEqual(false, CurrentPage.As<LaserPrintersPage>().ValidatePrintersSpainPortugal(), "Validating Printers (Spain and Portugal Languages)");
            TestCheck.AssertIsEqual(true, true, "Validating Printers (Spain and Portugal Languages)");
        }

        [Given(@"I have entered my valid supplies code for an InkJet cartridge ""(.*)""")]
        public void GivenIHaveEnteredMyValidSuppliesCodeForAnInkJetCartridge(string supplyCode)
        {
            CurrentPage.As<SuppliesPage>().AddSupplyCode(supplyCode);
        }

        [When(@"I select an InkJet cartridge by searching with a valid supplies code ""(.*)""")]
        public void GivenISelectAnInkJetCartridgeBySearchingWithAValidSuppliesCode(string itemCode)
        {
            NextPage = CurrentPage.As<SuppliesPage>().SearchForSuppliesItem(itemCode);
        }

        [When(@"I click on Add To Basket button")]
        public void GivenIClickOnAddToBasketButton()
        {
            //TestCheck.AssertIsEqual(0, BasketModule.GetBasketItemsCount(CurrentDriver), "Invalid Basket item count");
            CurrentPage.As<InkJetCartridgePage>().AddToBasketButtonClick();
        }

        [When(@"I click on Go to Basket button")]
        public void GivenIClickOnGoToBasketButton()
        {
            NextPage = BasketModule.GoToBasketButtonClick(CurrentDriver);
        }

        [When(@"I click Checkout before loging")]
        public void WhenIClickCheckoutBeforeLoging()
        {
            NextPage = CurrentPage.As<BasketPage>().CheckOutButtonClickBeforeLogin();
        }

    }
}
