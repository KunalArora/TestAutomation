using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages8._0.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using TechTalk.SpecFlow;


namespace Brother.Tests.Specs._80.BrotherMainSite.HomePageNavigation
{
    [Binding]
    public class MainSiteHomePageNavigation : BaseSteps
    {
        [Given(@"I have navigated to the Brother Main Site ""(.*)"" products pages")]
        public void GivenIHaveNavigatedToTheBrotherMainSiteProductsPages(string country)
        {
            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadBrotherMainSiteHomePage(CurrentDriver, BasePage.BaseUrl);
        }
        [Given(@"I have navigated to the Brother Main Site ""(.*)"" footer pages")]
        public void GivenIHaveNavigatedToTheBrotherMainSiteFooterPages(string country)
        {
            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadFooterPage(CurrentDriver, BasePage.BaseUrl);
        }

        [Given(@"I have navigated to the ""(.*)"" MainSite URL for country ""(.*)""")]
        public void GivenIHaveNavigatedToTheMainSiteUrlForCountry(string url, string country)
        {
            Helper.SetCountry(country);
            CurrentPage = GlobalNavigationModule.NavigateToLaserPrintersSite(CurrentDriver, url);
        }
        [Given(@"I have navigated to the Brother Main Site ""(.*)"" products header pages")]
        public void GivenIHaveNavigatedToTheBrotherMainSiteProductsHeaderPages(string country)
        {
            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadHeaderPage(CurrentDriver, BasePage.BaseUrl);
        }
        [Then(@"I have clicked the top products menu button")]
        public void ThenIHaveClickedTopProductsMenu()
        {
            CurrentPage.As<MainSiteHomePage>().IsProductsButtonAvailable();
            NextPage = CurrentPage.As<MainSiteHomePage>().ProductsButtonClick();
        }

        [Then(@"I am navigated to the products page")]
        public void ThenIAmNavigatedToProductsPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasProductsPageLoaded();
        }

        [Then(@"I hover over the top products menu button")]
        public void HoverOverTopProductsMenu()
        {
            CurrentPage.As<MainSiteHomePage>().HoverProductsMenu(CurrentDriver);
        }

        [Then(@"I hover and click the printers option")]
        public void HoverAndClickPrintersOption()
        {
            CurrentPage.As<MainSiteHomePage>().HoverAndClickPrinters(CurrentDriver);
        }

        [Then(@"I am navigated to the printers page")]
        public void ThenIAmNavigatedToPrintersPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasPrintersPageLoaded();
        }
       
        

    }
}
