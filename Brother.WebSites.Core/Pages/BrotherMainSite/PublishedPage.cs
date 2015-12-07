using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Brother.WebSites.Core.Pages.BrotherMainSite
{
    public class PublishedPage : BasePage
    {
        public static string Url = "/";

        public override string DefaultTitle
        {
            get { return string.Empty; }
        }

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div > a:nth-child(1)")]
        public IWebElement PageHeader;

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div > a.common-global-header--toggle.active")]
        public IWebElement SearchIcon;

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(3) > nav > div > ul.common-global-nav--list.common-global-nav--list--primary > li:nth-child(1) > a")]
        public IWebElement TopNavi;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div:nth-child(1) > div > div > div.common-accordion--item--header > div > h1")]
        public IWebElement Accordion;

        [FindsBy(How = How.CssSelector, Using = "	body > div.container.container--grid > div > div:nth-child(1) > section.common--features-carousel > ul")]
        public IWebElement FeaturesCarousel;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div:nth-child(1) > section.common--features-carousel > ul > li:nth-child(1) > a > img")]
        public IWebElement FeaturesCarouselTile;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div:nth-child(1) > section.common--banner-bar > div.col-xs-12 > h1")]
        public IWebElement BannerBar;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div:nth-child(1) > section.common--banner-bar > div.common--banner-bar--items > div:nth-child(1) > p")]
        public IWebElement BannerBarTile;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div:nth-child(1) > article > picture > img")]
        public IWebElement ImageTextModule;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div:nth-child(1) > section.common-header-bar > nav")]
        public IWebElement SecondaryNav;

        

        public void GetPublishedPage(string url)
        {
            TestCheck.AssertIsEqual(HttpStatusCode.OK, GetWebPageResponse(url), "Incorrect Http Status Code returned");

            WebDriver.SetPageLoadTimeout(TimeSpan.FromSeconds(120));

            WebSites.Core.Pages.General.SiteAccess.ValidateSiteUrl(url);
            WebDriver.SetPageLoadTimeout(WebDriver.DefaultTimeout);
        }

        private HttpStatusCode GetWebPageResponse(string webSite)
        {
            var responseTimer = new System.Diagnostics.Stopwatch();
            responseTimer.Start();
            // get response from WebSite
            var responseCode = Utils.GetPageResponse(webSite, WebRequestMethods.Http.Get);
            responseTimer.Stop();
            var responseTime = responseTimer.Elapsed;
            Helper.MsgOutput(string.Format("Response time from website [{0}] was [{1}ms]", webSite, responseTime.Milliseconds));

            return responseCode;
        }

        public void IsPageHeaderDisplayed()
        {
            WaitForElementToExistByCssSelector("body > header > div > div > a:nth-child(1)");
              if (PageHeader == null)
                 {
                   throw new NullReferenceException("Unable to locate page header");
                 }
            AssertElementPresent(PageHeader, "Page Header", 30);            
        }

        public void IsSearchIconDisplayed()
        {
            WaitForElementToExistByCssSelector("body > header > div > div > a:nth-child(1)");
            if (SearchIcon == null)
            {
                throw new NullReferenceException("Unable to locate search icon");
            }
            AssertElementPresent(SearchIcon, "Search Icon", 30);
        }

        public void IsTopNavDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div:nth-child(3) > nav > div > ul.common-global-nav--list.common-global-nav--list--primary > li:nth-child(1) > a");
            if (TopNavi == null)
            {
                throw new NullReferenceException("Unable to locate top navigation component");
            }
            AssertElementPresent(TopNavi, "Top Navigation", 30);
        }

        public void IsAccordionDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div:nth-child(1) > div > div > div.common-accordion--item--header > div > h1");
            if (Accordion == null)
            {
                throw new NullReferenceException("Unable to locate accordion component");
            }
            AssertElementPresent(Accordion, "Accordion Component", 30);
        }

        public void IsFeaturesCarouselDisplayed()
        {
            WaitForElementToExistByCssSelector("	body > div.container.container--grid > div > div:nth-child(1) > section.common--features-carousel > ul");
            if (FeaturesCarousel == null)
            {
                throw new NullReferenceException("Unable to locate features carousel component");
            }
            AssertElementPresent(FeaturesCarousel, "Features Carousel", 30);
        }

        public void IsFeaturesCarouselTileDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div:nth-child(1) > section.common--features-carousel > ul > li:nth-child(1) > a > img");
            if (FeaturesCarouselTile == null)
            {
                throw new NullReferenceException("Unable to locate features carousel tile component");
            }
            AssertElementPresent(FeaturesCarouselTile, "Features Carousel Tile", 30);
        }

        public void IsBannerBarDisplayedDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div:nth-child(1) > section.common--banner-bar > div.col-xs-12 > h1");
            if (BannerBar == null)
            {
                throw new NullReferenceException("Unable to locate banner bar component");
            }
            AssertElementPresent(BannerBar, "BannerBar", 30);
        }

        public void IsBannerBarTileDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div:nth-child(1) > section.common--banner-bar > div.common--banner-bar--items > div:nth-child(1) > p");
            if (BannerBarTile == null)
            {
                throw new NullReferenceException("Unable to locate banner bar tile component");
            }
            AssertElementPresent(BannerBarTile, "Banner Bar Tile", 30);
        }

        public void IsImageTextModuleDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div:nth-child(1) > div > div > div.common-accordion--item--header > div > h1");
            if (ImageTextModule == null)
            {
                throw new NullReferenceException("Unable to locate image text module component");
            }
            AssertElementPresent(ImageTextModule, "Image Text Module", 30);
        }

        public void IsSecondaryNavigationDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div:nth-child(1) > section.common-header-bar > nav");
            if (SecondaryNav == null)
            {
                throw new NullReferenceException("Unable to locate secondary navigation component");
            }
            AssertElementPresent(SecondaryNav, "Secondary Navigation", 30);
        }

        

    }
}
