using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using TechTalk.SpecFlow;

namespace Brother.Tests.Specs.BrotherMainSite.HomePageNavigation
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

        [Given(@"I have navigated to the ""(.*)"" MainSite URL for country ""(.*)""")]
        public void GivenIHaveNavigatedToTheMainSiteUrlForCountry(string url, string country)
        {
            Helper.SetCountry(country);
            CurrentPage = GlobalNavigationModule.NavigateToLaserPrintersSite(CurrentDriver, url);
        }
        [Then(@"I have clicked the top products menu button")]
        public void ThenIHaveClickedTopProductsMenu()
        {
            //CurrentPage.As<MainSiteHomePage>().IsProductsButtonAvailable();
            NextPage = CurrentPage.As<MainSiteHomePage>().ProductsButtonClick();
        }

        [Then(@"I have clicked the terms and conditions link within the website information footer")]
        public void ThenIHaveClickedTermsAndConditionsWithinWebsiteInfoFooter()
        {
            NextPage = CurrentPage.As<MainSiteHomePage>().TermsAndConditionsFooterLinkClick();
        }

        [Then(@"I have clicked the brother network link within the website information footer")]
        public void ThenIHaveClickedBrotherNetworkWithinWebsiteInfoFooter()
        {
            NextPage = CurrentPage.As<MainSiteHomePage>().BrotherNetworkLinkClick();
        }    

        [Then(@"I am navigated to the products page")]
        public void ThenIAmNavigatedToProductsPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasProductsPageLoaded();
        }

        [Then(@"I am navigated to the terms and conditions page")]
        public void ThenIAmNavigatedToTheTermsAndConditionsPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasTermsAndConditionsPageLoaded();
        }

        [Then(@"I am navigated to the brother network page")]
        public void ThenIAmNavigatedToTheBrotherNetworkPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasBrotherNetworkPageLoaded();
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

        [Then(@"I hover and click the scanners option")]
        public void HoverAndClickScannersOption()
        {
            CurrentPage.As<MainSiteHomePage>().HoverAndClickScanners(CurrentDriver);
        }

        [Then(@"I am navigated to the printers page")]
        public void ThenIAmNavigatedToPrintersPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasPrintersPageLoaded();
        }

        [Then(@"I am navigated to the scanners page")]
        public void ThenIAmNavigatedToScannersPage()
        {
            CurrentPage.As<MainSiteHomePage>().HasScannersPageLoaded();
        }

        [Then(@"I click the colour laser menu option")]
        public void TheIClickTheColourLaserMenuOption()
        {
            CurrentPage.As<MainSiteHomePage>().ColourLaserMenuOptionClick();
        }

        [Then(@"I click the mono laser menu option")]
        public void TheIClickTheMonoLaserMenuOption()
        {
            CurrentPage.As<MainSiteHomePage>().MonoLaserMenuOptionClick();
        }

        [Then(@"I click the inkjet menu option")]
        public void TheIClickTheInkjetMenuOption()
        {
            CurrentPage.As<MainSiteHomePage>().InkjetMenuOptionClick();
        }

        [Then(@"I click the portable menu option")]
        public void TheIClickThePortableMenuOption()
        {
            CurrentPage.As<MainSiteHomePage>().PortableMenuOptionClick();
        }

        [Then(@"I click the workgroup menu option")]
        public void TheIClickTheWorkgroupMenuOption()
        {
            CurrentPage.As<MainSiteHomePage>().WorkgroupMenuOptionClick();
        }

        [Then(@"I click the all printers menu option")]
        public void TheIClickTheAllPrintersMenuOption()
        {
            CurrentPage.As<MainSiteHomePage>().AllPrintersMenuOptionClick();
        }

        [Then(@"I click to view the colour laser range")]
        public void TheIClickToViewTheColourLaserRange()
        {
            CurrentPage.As<MainSiteHomePage>().ViewColourLaserRange();
        }

        [Then(@"I click to view the mono laser range")]
        public void TheIClickToViewTheMonoLaserRange()
        {
            CurrentPage.As<MainSiteHomePage>().ViewMonoLaserRange();
        }

        [Then(@"I click to view the inkjet range")]
        public void TheIClickToViewTheInkjetRange()
        {
            CurrentPage.As<MainSiteHomePage>().ViewInkjetRange();
        }

        [Then(@"I click to view the portable range")]
        public void TheIClickToViewThePortableRange()
        {
            CurrentPage.As<MainSiteHomePage>().ViewPortableRange();
        }

        [Then(@"I click to view all colour lasers")]
        public void TheIClickToViewAllColourLasers()
        {
            CurrentPage.As<MainSiteHomePage>().ViewAllColourLasers();
        }

        [Then(@"I click to view all mono lasers")]
        public void TheIClickToViewAllMonoLasers()
        {
            CurrentPage.As<MainSiteHomePage>().ViewAllMonoLasers();
        }

        [Then(@"I click to view all inkjet printers")]
        public void TheIClickToViewAllInkjetPrinters()
        {
            CurrentPage.As<MainSiteHomePage>().ViewAllInkjetPrinters();
        }

        [Then(@"I click to view all portable printers")]
        public void TheIClickToViewAllPortablePrinters()
        {
            CurrentPage.As<MainSiteHomePage>().ViewAllPortablePrinters();
        }

        [Then(@"I click to view all the scanners")]
        public void ThenIClickToViewAllScanners()
        {
            CurrentPage.As<MainSiteHomePage>().ViewAllScanners();
        }

        [Then(@"I click to view portable scanners")]
        public void ThenIClickToViewPortableScanners()
        {
            CurrentPage.As<MainSiteHomePage>().ViewPortableScanners();
        }
        [Then(@"I click to view compact scanners")]
        public void ThenIClickToViewCompactScanners()
        {
            CurrentPage.As<MainSiteHomePage>().ViewCompactScanners();
        }

        [Then(@"I click to view the workgroup printer")]
        public void ThenIClickToViewWorkgroupPrinter()
        {
            CurrentPage.As<MainSiteHomePage>().ViewTheWorkgroupPrinter();
        }

        [Then(@"I click to view the full printer range")]
        public void ThenIClickToViewTheFullPrinterRange()
        {
            CurrentPage.As<MainSiteHomePage>().ViewTheFullPrinterRange();
        }

        [Then(@"I am navigated to view all colour laser printers")]
        public void ThenIAmNavigatedToAllColourLasersRangePage()
        {
            CurrentPage.As<MainSiteHomePage>().HasAllColourLasersPageLoaded();
        }

        [Then(@"I am navigated to view all mono laser printers")]
        public void ThenIAmNavigatedToAllMonoLasersRangePage()
        {
            CurrentPage.As<MainSiteHomePage>().HasAllMonoLasersPageLoaded();
        }

        [Then(@"I am navigated to view all inkjet printers")]
        public void ThenIAmNavigatedToAllInkjetRangePage()
        {
            CurrentPage.As<MainSiteHomePage>().HasAllInkjetPrintersPageLoaded();
        }

        [Then(@"I am navigated to view all portable printers")]
        public void ThenIAmNavigatedToAllPortableRangePage()
        {
            CurrentPage.As<MainSiteHomePage>().HasAllPortablePrintersPageLoaded();
        }

        [Then(@"I am navigated to view the workgroup printer")]
        public void ThenIAmNavigatedToAllWorkgroupRangePage()
        {
            CurrentPage.As<MainSiteHomePage>().HasAllWorkgroupPrintersPageLoaded();
        }

        [Then(@"I am navigated to view all the printers")]
        public void ThenIAmNavigatedToViewAllThePrinterRange()
        {
            CurrentPage.As<MainSiteHomePage>().HasAllPrinterRangePageLoaded();
        }

        [Then(@"I am navigated to view all the scanners")]
        public void ThenIAmNavigatedToViewAllTheScanners()
        {
            CurrentPage.As<MainSiteHomePage>().HasAllScannersPageLoaded();
        }

        [Then(@"I am navigated to view portable scanners")]
        public void ThenIAmNavigatedToViewPortableScanners()
        {
            CurrentPage.As<MainSiteHomePage>().HasPortableScannersPageLoaded();
        }

        [Then(@"I am navigated to view compact scanners")]
        public void ThenIAmNavigatedToViewCompactScanners()
        {
            CurrentPage.As<MainSiteHomePage>().HasCompactScannersPageLoaded();
        }

    }
}
