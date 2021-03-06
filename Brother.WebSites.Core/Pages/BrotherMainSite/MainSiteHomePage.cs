﻿using System;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories.Printers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
    public class MainSiteHomePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "#superCarousel")]
        public IWebElement SlidesOnHomePage;

        [FindsBy(How = How.CssSelector, Using = ".common-global-footer")]
        public IWebElement PageFooter;

        [FindsBy(How = How.CssSelector, Using = "#loginuser")]
        public IWebElement UsernameInputField;

        //[FindsBy(How = How.CssSelector, Using = ".common--features-carousel--item [href='/supplies']")]
        //public IWebElement SuppliesLink;


        [FindsBy(How = How.CssSelector, Using = ".common-global-nav--sub-link[href=\"http://main.co.uk.cds.test.brother.eu.com/supplies\"]")]
        public IWebElement SuppliesLink;
        

         [FindsBy(How = How.CssSelector, Using = "a[href=\"http://main.co.uk.cds.test.brother.eu.com/products\"]")]
        public IWebElement ProductMenuElement;
        

        [FindsBy(How = How.CssSelector, Using = ".prev")]
        public IWebElement PreviousArrow;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div.feature-carousel > div > ul.feature-carousel-items > li:nth-child(1) > div > a")]
        public IWebElement PrintersLink;

        [FindsBy(How = How.Id, Using = "TopNavigationControl_rptPrimaryLevelNav_aSectionLink_0")]
        public IWebElement ProductsTopMenuButton;

        [FindsBy(How = How.CssSelector, Using = "#site-footer > div > section > article:nth-child(2) > ul > li:nth-child(4) > a")]
        public IWebElement TermsAndConditionsFooterLink;

        [FindsBy(How = How.CssSelector, Using = "#site-footer > div > section > article:nth-child(2) > ul > li:nth-child(5) > a")]
        public IWebElement BrotherNetworkFooterLink;

        [FindsBy(How = How.Id, Using = "lhnchatimg")]
        public IWebElement RequestSampleButton;

        [FindsBy(How = How.CssSelector, Using = "[href='/Business-Solutions/Print-Management/']")] 
        public IWebElement CreativeCentreLink;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > article > table > tbody > tr:nth-child(2) > td:nth-child(1) > a")]
        public IWebElement BrotherAdminTeamLink;

        [FindsBy(How = How.CssSelector, Using = "#login_form > table > tbody > tr > td:nth-child(2) > div:nth-child(1) > div > div:nth-child(7)")]
        public IWebElement BrotherNetworkLoginButton;
        

        [FindsBy(How = How.CssSelector, Using = "#TopNavigationControl_rptPrimaryLevelNav_liPrimaryNavItem_0 > ul > li:nth-child(1) > a:nth-child(1)")]
        public IWebElement PrintersOption;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(1) > div.left-content > p:nth-child(5) > a")]
        public IWebElement ViewColourLaserRangeButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div:nth-child(1) > div > p:nth-child(5) > a.button-blue")]
        public IWebElement ScannerSoftwareButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(2) > div.left-content > p:nth-child(4) > a")]
        public IWebElement ViewMonoLaserRangeButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(3) > div.left-content > p:nth-child(4) > a")]
        public IWebElement ViewInkjetRangeButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(4) > div.left-content > p:nth-child(4) > a")]
        public IWebElement ViewPortableRangeButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(1) > a")] 
        public IWebElement ColourLaserMenuOption;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(2) > a")]
        public IWebElement MonoLaserMenuOption;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(3) > a")]
        public IWebElement InkjetMenuOption;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(4) > a")]
        public IWebElement PortableMenuOption;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(5) > a")]
        public IWebElement WorkgroupMenuOption;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(6) > a")]
        public IWebElement AllPrintersMenuOption;

        [FindsBy(How = How.CssSelector, Using = "#content_0_ctl01_headercontent_1_li > article > h2")]
        public IWebElement ViewPortableScannersLink;

        [FindsBy(How = How.CssSelector, Using = "#content_0_ctl01_headercontent_2_li > article > h2")]
        public IWebElement ViewCompactScannersLink;

        [FindsBy(How = How.CssSelector, Using = "#content_0_ctl01_headercontent_3_li > article > h4:nth-child(3)")]
        public IWebElement ViewDesktopScannersLink;

        //[FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > div > p:nth-child(5) > a")]
        [FindsBy(How = How.ClassName, Using = "button-orange")]
        public IWebElement ViewAllProductsOrangeButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(5) > div.left-content > p:nth-child(4) > a")]
        public IWebElement ViewWorkgroupPrinterButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(6) > div.left-content > p:nth-child(4) > a")]
        public IWebElement ViewFullPrinterRangeButton;

        [FindsBy(How = How.Id, Using = "buybutton")]
        public IWebElement BuyOnlineButton;

        [FindsBy(How = How.CssSelector, Using = "#results > article:nth-child(1) > div.price-listings-info > p:nth-child(3) > a")]
        public IWebElement ViewDetailsLink;
      
        [FindsBy(How = How.CssSelector, Using = ".header-search>input")]
        public IWebElement SearchTextBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='header-search-autocomplete-results']/a[3]")]
        public IWebElement ResultLink;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='header-search-autocomplete-results']")]
        public IWebElement SearchResults;

        private const string CarouselItems = ".feature-carousel-items";

        private const string ProductsTopMenu = "TopNavigationControl_rptPrimaryLevelNav_aSectionLink_0";

        private const string TermsAndConditionsFooter = "#site-footer > div > section > article:nth-child(2) > ul > li:nth-child(4) > a";

        private const string BrotherNetworkFooter = "#site-footer > div > section > article:nth-child(2) > ul > li:nth-child(5) > a";

        private const string Printers = "#TopNavigationControl_rptPrimaryLevelNav_liPrimaryNavItem_0 > ul > li:nth-child(1) > a:nth-child(1)";

        private const string Scanners = "#TopNavigationControl_rptPrimaryLevelNav_liPrimaryNavItem_0 > ul > li:nth-child(1) > a:nth-child(2)";

        private const string ViewColourLaserRangeBtn = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(1) > div.left-content > p:nth-child(5) > a";

        private const string ColourLaserMenuOpt = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(1) > a";

        private const string AllProductsOrangeButton = "button-orange";

        private const string BuyOnlineBtn = "buybutton";

        private const string ViewDetails = "#results > article:nth-child(1) > div.price-listings-info > p:nth-child(3) > a";

        private const string MonoLaserMenuOpt = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(2) > a";

        private const string MonoLaserRangeBtn = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(2) > a";

        private const string InkJetMenuOpt = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(3) > a";

        private const string ViewInkjetRangeBtn = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(3) > div.left-content > p:nth-child(4) > a";

        private const string PortableMenuOpt = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(4) > a";

        private const string ViewPortableRangeBtn = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(4) > div.left-content > p:nth-child(4) > a";

        private const string AllPrintersMenuOpt = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(6) > a";

        private const string ViewFullPrinterRangeBtn = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(6) > div.left-content > p:nth-child(4) > a";

        private const string WorkgroupMenuOpt = "#main > div > div > div:nth-child(3) > div > ul.nav.cf > li:nth-child(5) > a";

        private const string ViewWorkgroupPrinterBtn = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(5) > div.left-content > p:nth-child(4) > a";

        private const string PortableScannersLink= "#content_0_ctl01_headercontent_1_li > article > h2";

        private const string CompactScannersLink = "#content_0_ctl01_headercontent_1_li > article > h2";

        private const string DesktopScannersLink = "#content_0_ctl01_headercontent_3_li > article > h4:nth-child(3)";

        private const string BrotherAdminTeam = "#main > div > div > div:nth-child(3) > article > table > tbody > tr:nth-child(2) > td:nth-child(1) > a";

        private const string BrotherNetworkLogin = "#login_form > table > tbody > tr > td:nth-child(2) > div:nth-child(1) > div > div:nth-child(7)";
       
        public void IsSuppliesLinkAvailable()

        {
            //SuppliesLink = Driver.FindElement(By.CssSelector(".common--features-carousel--items [href='/supplies']"));
            if (!SuppliesLink.Displayed)
            {
                while (!SuppliesLink.Displayed)
                {
                    WaitForElementToExistByCssSelector(".common--features-carousel--items [href='/supplies']", 1, 5);
                    //PreviousArrow.Click();
                    SuppliesLink = Driver.FindElement(By.CssSelector(".common--features-carousel--items [href='/supplies']"));
                }
            }
            AssertElementPresent(SuppliesLink, "Supplies Link");
        }

        public SuppliesPage ClickSuppliesLink()
        {
            MoveToElement(ProductMenuElement);
            WebDriver.Wait(DurationType.Second, 2);
            SuppliesLink.Click();
            
            return GetInstance<SuppliesPage>(Driver);
        }

        public void IsPrintersLinkAvailable()
        {
            if (PrintersLink == null)
            {
                throw new NullReferenceException("Unable to locate link on page");
            }
            AssertElementPresent(PrintersLink, "Printers Link");
        }

        public PrintersPage ClickPrintersLink()
        {
            MoveToElement(PrintersLink);
            PrintersLink.Click();
            return GetInstance<PrintersPage>(Driver);
        }

        public void IsProductsButtonAvailable()
        {
            if (ProductsTopMenuButton == null)
            {
                throw new NullReferenceException("Unable to locate products menu button");
            }
            AssertElementPresent(ProductsTopMenuButton, "Products button");
        }

        public MainSiteHomePage ProductsButtonClick()
        {
            WaitForElementToExistById(ProductsTopMenu, 5);
            MoveToElement(ProductsTopMenuButton);
            ProductsTopMenuButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage TermsAndConditionsFooterLinkClick()
        {
            WaitForElementToExistByCssSelector(TermsAndConditionsFooter);
            TermsAndConditionsFooterLink.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage BrotherNetworkLinkClick()
        {
            WaitForElementToExistByCssSelector(BrotherNetworkFooter);
            BrotherNetworkFooterLink.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public void HasProductsPageLoaded()
        {
            WaitForElementToExistById("lhnchatimg", 5);
            ScrollTo(RequestSampleButton);    
            if (RequestSampleButton == null)
            {
                throw new NullReferenceException("Products page not loaded");
            }
            AssertElementPresent(RequestSampleButton, "Request sample button");
        }

        public void HasTermsAndConditionsPageLoaded()
        {
            WaitForElementToExistByCssSelector(BrotherAdminTeam);
            ScrollTo(BrotherAdminTeamLink);
            if (BrotherAdminTeamLink == null)
            {
                throw new NullReferenceException("Terms and conditions page not loaded");
            }
            AssertElementPresent(BrotherAdminTeamLink, "Brother admin team link");
        }

        public void HasBrotherNetworkPageLoaded()
        {
            WaitForElementToExistByCssSelector(BrotherNetworkLogin);
            ScrollTo(BrotherNetworkLoginButton);
            if (BrotherNetworkLoginButton == null)
            {
                throw new NullReferenceException("Brother network page not loaded");
            }
            AssertElementPresent(BrotherNetworkLoginButton, "Brother network login button");
        }

        public void HoverProductsMenu(IWebDriver driver)
        {
            WaitForElementToExistById(ProductsTopMenu, 5);
            var builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.Id(ProductsTopMenu))).Build().Perform();
        }

        public void HoverAndClickPrinters(IWebDriver driver)
        {
            WaitForElementToExistByCssSelector(Printers);
            var builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.CssSelector(Printers))).Click().Build().Perform(); 
        }

        public void HoverAndClickScanners(IWebDriver driver)
        {
            WaitForElementToExistByCssSelector(Scanners);
            var builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.CssSelector(Scanners))).Click().Build().Perform();
        }

        public void HasPrintersPageLoaded()
        {
            WaitForElementToExistByCssSelector(ViewColourLaserRangeBtn);
            if (ViewColourLaserRangeButton == null)
            {
                throw new NullReferenceException("Printers page has not loaded");
            }
            AssertElementPresent(ViewColourLaserRangeButton, "Colour laser button");
        }

        public void HasScannersPageLoaded()
        {
            if (ViewAllProductsOrangeButton == null)
            {
                throw new NullReferenceException("Scanners page has not loaded");
            }
            AssertElementPresent(ViewAllProductsOrangeButton, "View all products orange button");
        }

        public void HasLabelPrintersPageLoaded()
        {
            if (ViewAllProductsOrangeButton == null)
            {
                throw new NullReferenceException("Label printers page has not loaded");
            }
            AssertElementPresent(ViewAllProductsOrangeButton, "View all products orange button");
        }

        public void HasFaxMachinesPageLoaded()
        {
            if (ViewAllProductsOrangeButton == null)
            {
                throw new NullReferenceException("Fax machines page has not loaded");
            }
            AssertElementPresent(ViewAllProductsOrangeButton, "View all products orange button");
        }

        public MainSiteHomePage ColourLaserMenuOptionClick()
        {
            WaitForElementToExistByCssSelector(ColourLaserMenuOpt);
            MoveToElement(ColourLaserMenuOption);
            ColourLaserMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage MonoLaserMenuOptionClick()
        {
            WaitForElementToExistByCssSelector(MonoLaserMenuOpt);
            MoveToElement(MonoLaserMenuOption);
            MonoLaserMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage InkjetMenuOptionClick()
        {
            WaitForElementToExistByCssSelector(InkJetMenuOpt);
            MoveToElement(InkjetMenuOption);
            InkjetMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage PortableMenuOptionClick()
        {
            WaitForElementToExistByCssSelector(PortableMenuOpt);
            MoveToElement(PortableMenuOption);
            PortableMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage WorkgroupMenuOptionClick()
        {
            WaitForElementToExistByCssSelector(WorkgroupMenuOpt);
            MoveToElement(WorkgroupMenuOption);
            WorkgroupMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage AllPrintersMenuOptionClick()
        {
            WaitForElementToExistByCssSelector(AllPrintersMenuOpt);    
            MoveToElement(AllPrintersMenuOption);
            AllPrintersMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewColourLaserRange()
        {
            WaitForElementToExistByCssSelector(ViewColourLaserRangeBtn);
            MoveToElement(ViewColourLaserRangeButton);
            ViewColourLaserRangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewMonoLaserRange()
        {
            WaitForElementToExistByCssSelector(MonoLaserRangeBtn);
            MoveToElement(ViewMonoLaserRangeButton);
            ViewMonoLaserRangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewInkjetRange()
        {
            WaitForElementToExistByCssSelector(ViewInkjetRangeBtn);    
            MoveToElement(ViewInkjetRangeButton);
            ViewInkjetRangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewPortableRange()
        {
            WaitForElementToExistByCssSelector(ViewPortableRangeBtn);
            MoveToElement(ViewPortableRangeButton);
            ViewPortableRangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewAllColourLasers()
        {
            WaitForElementToExistByClassName(AllProductsOrangeButton);
            MoveToElement(ViewAllProductsOrangeButton);
            ViewAllProductsOrangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewAllMonoLasers()
        {
            WaitForElementToExistByClassName(AllProductsOrangeButton);
            MoveToElement(ViewAllProductsOrangeButton);
            ViewAllProductsOrangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewAllInkjetPrinters()
        {
            WaitForElementToExistByClassName(AllProductsOrangeButton);
            MoveToElement(ViewAllProductsOrangeButton);
            ViewAllProductsOrangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewAllPortablePrinters()
        {
            WaitForElementToExistByClassName(AllProductsOrangeButton);
            MoveToElement(ViewAllProductsOrangeButton);
            ViewAllProductsOrangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewAllScanners()
        {
            WaitForElementToExistByClassName("button-orange");
            MoveToElement(ViewAllProductsOrangeButton);
            ViewAllProductsOrangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewPortableScanners()
        {
            WaitForElementToExistByCssSelector(PortableScannersLink);
            MoveToElement(ViewPortableScannersLink);
            ViewPortableScannersLink.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewCompactScanners()
        {
            WaitForElementToExistByCssSelector(CompactScannersLink);
            MoveToElement(ViewCompactScannersLink);
            ViewPortableScannersLink.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewDesktopScanners()
        {
            WaitForElementToExistByCssSelector(DesktopScannersLink);
            MoveToElement(ViewDesktopScannersLink);
            ViewDesktopScannersLink.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewTheWorkgroupPrinter()
        {
            WaitForElementToExistByCssSelector(ViewWorkgroupPrinterBtn);
            MoveToElement(ViewWorkgroupPrinterButton);
            ViewWorkgroupPrinterButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewTheFullPrinterRange()
        {
            WaitForElementToExistByCssSelector(ViewFullPrinterRangeBtn);
            MoveToElement(ViewFullPrinterRangeButton);
            ViewFullPrinterRangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public void HasAllColourLasersPageLoaded()
        {
            WaitForElementToExistById(BuyOnlineBtn, 5);
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("All colour lasers page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasAllMonoLasersPageLoaded()
        {
            WaitForElementToExistById(BuyOnlineBtn, 5);
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("All mono lasers page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasAllInkjetPrintersPageLoaded()
        {
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("All inkjet printers page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasAllPortablePrintersPageLoaded()
        {
            WaitForElementToExistById(BuyOnlineBtn, 5);
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("All portable printers page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasAllWorkgroupPrintersPageLoaded()
        {
            WaitForElementToExistById("lhnchatimg", 5);
            ScrollTo(RequestSampleButton);
            if (RequestSampleButton == null)
            {
                throw new NullReferenceException("Workgroup printer page not loaded");
            }
            AssertElementPresent(RequestSampleButton, "Request sample button");
        }

        public void HasAllPrinterRangePageLoaded()
        {
            WaitForElementToExistById(BuyOnlineBtn, 5);
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("All printers range page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasAllScannersPageLoaded()
        {
            WaitForElementToExistById(BuyOnlineBtn, 5);
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("All scanners page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasPortableScannersPageLoaded()
        {
            WaitForElementToExistById(BuyOnlineBtn, 5);
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("Portable scanners page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasCompactScannersPageLoaded()
        {
            WaitForElementToExistById(BuyOnlineBtn, 5);
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("Compact scanners page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }
        public void HasDesktopScannersPageLoaded()
        {
            WaitForElementToExistByCssSelector(ViewDetails);
            if (ViewDetailsLink == null)
            {
                throw new NullReferenceException("Desktop scanners page has not loaded");
            }
            AssertElementPresent(ViewDetailsLink, "View details link");
        }

        public void ClickCreativeCentre()
        {
            CreativeCentreLink.Click();
        }

        public void AddSupplyCode(string code)
        {
            SearchTextBox.SendKeys(code);
            WebDriver.Wait(DurationType.Second, 3);
           
        }

        public void SearchResultsDisplayed()
        {
            TestCheck.AssertIsEqual(true,SearchResults.Displayed, "Is search results displayed");
        }
       
        public void DoPageTileExist()
        {
            TestCheck.AssertIsNotNullOrEmpty(Driver.Title, "Tile of the Page.");
        }

        public void AreSlidesDisplayed()
        {
            if (SlidesOnHomePage == null)
            {
                throw new NullReferenceException("Unable to locate ribbon on page");
            }
            AssertElementPresent(SlidesOnHomePage, "The Slides on the Home Page.");
        }

        public void DoFooterExistsOnHomePage()
        {
            if (PageFooter == null)
            {
                throw new NullReferenceException("Unable to locate ribbon on page");
            }
            AssertElementPresent(PageFooter, "Footer of the Page.");
        }
    }
}
