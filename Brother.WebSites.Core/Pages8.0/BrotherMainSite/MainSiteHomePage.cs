using System;
using System.Runtime.InteropServices;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories;
using Brother.WebSites.Core.Pages.BrotherMainSite.SuppliesAndAccessories.Printers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace Brother.WebSites.Core.Pages8._0.BrotherMainSite
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
        
        private const string CarouselItems = ".feature-carousel-items";

        private const string ProductsTopMenu = "TopNavigationControl_rptPrimaryLevelNav_aSectionLink_0";

        private const string Printers = "#TopNavigationControl_rptPrimaryLevelNav_liPrimaryNavItem_0 > ul > li:nth-child(1) > a:nth-child(1)";
        
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
            MoveToElement(SuppliesLink);
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
            AssertElementPresent(ProductsTopMenuButton, "Printers Link");
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
            AssertElementPresent(RequestSampleButton, "Printers Link");
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

        public void HasPrintersPageLoaded()
        {
            if (ViewColourLaserRangeButton == null)
            {
                throw new NullReferenceException("Printers page has not loaded");
            }
            AssertElementPresent(ViewColourLaserRangeButton, "Colour laser button");
        }
        public void HoverBusinessSolutionsMenu(IWebDriver driver)
        {
            var builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.Id(ProductsTopMenu))).Build().Perform();
        }
        public void HasBusinessSolutionsPageLoaded()
        {
            WaitForElementToExistById("lhnchatimg", 3);
            ScrollTo(RequestSampleButton);    
            if (RequestSampleButton == null)
            {
                throw new NullReferenceException("Products page not loaded");
            }
            AssertElementPresent(RequestSampleButton, "Printers Link");
        }
    }
    }
