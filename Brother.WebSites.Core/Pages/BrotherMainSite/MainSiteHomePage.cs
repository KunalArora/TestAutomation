using System;
using System.Runtime.InteropServices;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories.Printers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
    public class MainSiteHomePage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        //[FindsBy(How = How.CssSelector, Using = "#main > div > div.feature-carousel > div > ul.feature-carousel-items > li:nth-child(2) > div > a")]
        //public IWebElement SuppliesLink;

        [FindsBy(How = How.CssSelector, Using = "[href='/supplies']")]
        public IWebElement SuppliesLink;

        [FindsBy(How = How.CssSelector, Using = ".prev")]
        public IWebElement PreviousArrow;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div.feature-carousel > div > ul.feature-carousel-items > li:nth-child(1) > div > a")]
        public IWebElement PrintersLink;

        [FindsBy(How = How.Id, Using = "TopNavigationControl_rptPrimaryLevelNav_aSectionLink_0")]
        public IWebElement ProductsTopMenuButton;

        [FindsBy(How = How.Id, Using = "lhnchatimg")]
        public IWebElement RequestSampleButton;

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

        //[FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > div > p:nth-child(5) > a")]
        [FindsBy(How = How.ClassName, Using = "button-orange")]
        public IWebElement ViewAllProductsOrangeButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(5) > div.left-content > p:nth-child(4) > a")]
        public IWebElement ViewWorkgroupPrinterButton;

        [FindsBy(How = How.CssSelector, Using = "#main > div > div > div:nth-child(3) > div > ul.slides.cf > li:nth-child(6) > div.left-content > p:nth-child(4) > a")]
        public IWebElement ViewFullPrinterRangeButton;

        [FindsBy(How = How.Id, Using = "buybutton")]
        public IWebElement BuyOnlineButton;
        
        private const string CarouselItems = ".feature-carousel-items";

        private const string ProductsTopMenu = "TopNavigationControl_rptPrimaryLevelNav_aSectionLink_0";

        private const string Printers = "#TopNavigationControl_rptPrimaryLevelNav_liPrimaryNavItem_0 > ul > li:nth-child(1) > a:nth-child(1)";

        private const string Scanners = "#TopNavigationControl_rptPrimaryLevelNav_liPrimaryNavItem_0 > ul > li:nth-child(1) > a:nth-child(2)";
        
        public void IsSuppliesLinkAvailable()
        {
            SuppliesLink = Driver.FindElement(By.CssSelector(".feature-carousel-items [href='/supplies']"));
            if (!SuppliesLink.Displayed)
            {
                while (!SuppliesLink.Displayed)
                {
                    WaitForElementToExistByCssSelector(".feature-carousel-items [href='/supplies']", 1, 5);
                    PreviousArrow.Click();
                    SuppliesLink = Driver.FindElement(By.CssSelector(".feature-carousel-items [href='/supplies']"));
                }
            }
            AssertElementPresent(SuppliesLink, "Supplies Link");
        }

        public SuppliesPage ClickSuppliesLink()
        {
            //MoveToElement(SuppliesLink);
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
            MoveToElement(ProductsTopMenuButton);
            ProductsTopMenuButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public void HasProductsPageLoaded()
        {
            WaitForElementToExistById("lhnchatimg", 3);
            ScrollTo(RequestSampleButton);    
            if (RequestSampleButton == null)
            {
                throw new NullReferenceException("Products page not loaded");
            }
            AssertElementPresent(RequestSampleButton, "Request sample button");
        }

        public void HoverProductsMenu(IWebDriver driver)
        {
            var builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.Id(ProductsTopMenu))).Build().Perform();
        }

        public void HoverAndClickPrinters(IWebDriver driver)
        {          
            var builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.CssSelector(Printers))).Click().Build().Perform(); 
        }

        public void HoverAndClickScanners(IWebDriver driver)
        {
            var builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.CssSelector(Scanners))).Click().Build().Perform();
        }

        public void HasPrintersPageLoaded()
        {
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

        public MainSiteHomePage ColourLaserMenuOptionClick()
        {
            MoveToElement(ColourLaserMenuOption);
            ColourLaserMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage MonoLaserMenuOptionClick()
        {
            MoveToElement(MonoLaserMenuOption);
            MonoLaserMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage InkjetMenuOptionClick()
        {
            MoveToElement(InkjetMenuOption);
            InkjetMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage PortableMenuOptionClick()
        {
            MoveToElement(PortableMenuOption);
            PortableMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage WorkgroupMenuOptionClick()
        {
            MoveToElement(WorkgroupMenuOption);
            WorkgroupMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage AllPrintersMenuOptionClick()
        {
            MoveToElement(AllPrintersMenuOption);
            AllPrintersMenuOption.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewColourLaserRange()
        {
            MoveToElement(ViewColourLaserRangeButton);
            ViewColourLaserRangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewMonoLaserRange()
        {
            MoveToElement(ViewMonoLaserRangeButton);
            ViewMonoLaserRangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewInkjetRange()
        {
            MoveToElement(ViewInkjetRangeButton);
            ViewInkjetRangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewPortableRange()
        {
            MoveToElement(ViewPortableRangeButton);
            ViewPortableRangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewAllColourLasers()
        {
            MoveToElement(ViewAllProductsOrangeButton);
            ViewAllProductsOrangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewAllMonoLasers()
        {
            MoveToElement(ViewAllProductsOrangeButton);
            ViewAllProductsOrangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewAllInkjetPrinters()
        {
            MoveToElement(ViewAllProductsOrangeButton);
            ViewAllProductsOrangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewAllPortablePrinters()
        {
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
            WaitForElementToExistByCssSelector("#content_0_ctl01_headercontent_1_li > article > h2");
            MoveToElement(ViewPortableScannersLink);
            ViewPortableScannersLink.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewCompactScanners()
        {
            WaitForElementToExistByCssSelector("#content_0_ctl01_headercontent_2_li > article > h2");
            MoveToElement(ViewCompactScannersLink);
            ViewPortableScannersLink.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewTheWorkgroupPrinter()
        {
            MoveToElement(ViewWorkgroupPrinterButton);
            ViewWorkgroupPrinterButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public MainSiteHomePage ViewTheFullPrinterRange()
        {
            MoveToElement(ViewFullPrinterRangeButton);
            ViewFullPrinterRangeButton.Click();
            return GetInstance<MainSiteHomePage>(Driver);
        }

        public void HasAllColourLasersPageLoaded()
        {
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("All colour lasers page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasAllMonoLasersPageLoaded()
        {
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
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("All portable printers page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasAllWorkgroupPrintersPageLoaded()
        {
            WaitForElementToExistById("lhnchatimg", 3);
            ScrollTo(RequestSampleButton);
            if (RequestSampleButton == null)
            {
                throw new NullReferenceException("Workgroup printer page not loaded");
            }
            AssertElementPresent(RequestSampleButton, "Request sample button");
        }

        public void HasAllPrinterRangePageLoaded()
        {
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("All printers range page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasAllScannersPageLoaded()
        {
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("All scanners page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasPortableScannersPageLoaded()
        {
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("Portable scanners page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }

        public void HasCompactScannersPageLoaded()
        {
            if (BuyOnlineButton == null)
            {
                throw new NullReferenceException("Compact scanners page has not loaded");
            }
            AssertElementPresent(BuyOnlineButton, "Buy online button");
        }
    }
}
