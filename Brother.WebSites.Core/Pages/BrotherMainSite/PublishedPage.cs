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

        [FindsBy(How = How.CssSelector, Using = "body > header > div > h1")]
        public IWebElement PageHeader;

        [FindsBy(How = How.CssSelector, Using = ".col-xs-12.col-md-6.product-detail--container-title")]
        public IWebElement PageTitle;

        [FindsBy(How = How.CssSelector, Using = ".common-results-list--article")]
        public IWebElement PageArticle;

        [FindsBy(How = How.CssSelector, Using = ".row.glossary-listing_tab-item")] 
        public IWebElement GlossarySection;

        [FindsBy(How = How.CssSelector, Using = ".product-results-header.clearfix.component")]
        public IWebElement FilterSection;

        [FindsBy(How = How.CssSelector, Using = ".btn-info")]
        public IWebElement FindOutMoreButton;

        [FindsBy(How = How.CssSelector, Using = ".col-xs-12.col-md-6.product-detail--container-title")]
        public IWebElement AccessoryProductTitle;

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div > a.common-global-header--toggle.active")]
        public IWebElement SearchIcon;

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(5) > nav > div")]
        public IWebElement TopNavi;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common-accordion > div:nth-child(1) > div.collapsed.common-accordion--item--header > div")]
        public IWebElement Accordion;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common--features-carousel > ul")]
        public IWebElement FeaturesCarousel;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common--features-carousel > ul > li:nth-child(1) > a > img")]
        public IWebElement FeaturesCarouselTile;

        [FindsBy(How = How.CssSelector, Using = ".common--banner-bar.component")]
        public IWebElement BannerBar;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(4) > div.common--banner-bar--items > div:nth-child(1) > img")]
        public IWebElement BannerBarTile;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid.scEnabledChrome > div > div.col-xs-12.grid-cell > div:nth-child(13) > article > div.common-info-image__content.common--wysiwyg-block")]
        public IWebElement ImageTextModule;

        [FindsBy(How = How.CssSelector, Using = ".common-subheader")]
        public IWebElement SecondaryNav;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > ol")]
        public IWebElement Breadcrumb;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common-case-study > div.col-xs-12.col-sm-6.col-md-8.common-case-study--content.common--wysiwyg-block")]
        public IWebElement OjCaseStudy;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common--contact-bar")]
        public IWebElement ContactBar;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common--benefits-tiles")]
        public IWebElement BenefitBar;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common--benefits-tiles > div.common--benefits-tiles--body-container > div > img")]
        public IWebElement BenefitBarTile;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common--latest-news > div:nth-child(1) > h2")]
        public IWebElement LatestNews;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(13)")]
        public IWebElement HeaderBar;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(13)")]
        public IWebElement FullInfoTile;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > header.common-hero")]
        public IWebElement Hero;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(15) > picture")]
        public IWebElement SecondaryHero;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(16) > div")]
        public IWebElement FeatureModLeft;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common-feature-module.common-feature-module__text-left > div")]
        public IWebElement FeatureModRight;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common--banner-bar.common--banner-bar__features > div.common--banner-bar--items > div:nth-child(1)")]
        public IWebElement FeatureBar;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div:nth-child(1) > section.common--banner-bar.common--banner-bar__features > div.common--banner-bar--items > div:nth-child(1)")]
        public IWebElement FeatureTile;

        [FindsBy(How = How.CssSelector, Using = "#superCarousel > div")]
        public IWebElement SuperCarousel;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(20)")]
        public IWebElement VidListMod;

        [FindsBy(How = How.CssSelector, Using = "#player_uid_949430660_1 > div.ytp-thumbnail-overlay.ytp-cued-thumbnail-overlay > button")]
        public IWebElement VidOnListMod;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(21)")]
        public IWebElement VidTileBar;

        [FindsBy(How = How.CssSelector, Using = "#player_uid_152450143_1 > div.ytp-thumbnail-overlay.ytp-cued-thumbnail-overlay")]
        public IWebElement VidOnTileBar;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(22) > div")]
        public IWebElement FullWidthHero;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common--special-full-info-tile")]
        public IWebElement SpecFullInfo;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common--conversion-bar.component")]
        public IWebElement ConvBar;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > header.common--wizard.common--wizard__alt")]
        public IWebElement Wizard;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common-special-feature.common-special-feature__first")]
        public IWebElement SpecFeature;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.omnijoin-wizard-step > div")]
        public IWebElement StepsBar;

        [FindsBy(How = How.CssSelector, Using = "#heroCarousel > div > div > div")]
        public IWebElement HeroCarousel;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.omnijoin-wizard-step > div")]
        public IWebElement WizardStep;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(31)")]
        public IWebElement RichTextMod;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > nav")]
        public IWebElement LinkListItem;

        [FindsBy(How = How.CssSelector, Using = "")]
        public IWebElement Wffm;


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
           WaitForElementToExistByCssSelector("body > header > div > h1");
           //WaitForElementToExistByCssSelector(".common-global-header--title");
              if (PageHeader == null)
                 {
                   throw new NullReferenceException("Unable to locate page header");
                 }
            AssertElementPresent(PageHeader, "Page Header", 30);            
        }

        public void IsPageTitleDisplayed()
        {
            WaitForElementToExistByCssSelector(".col-xs-12.col-md-6.product-detail--container-title>h1");
            if (PageTitle == null)
            {
                throw new NullReferenceException("Unable to locate page header");
            }
            AssertElementPresent(PageTitle, "Page Title", 30);
        }

        public void IsFilterSectionDisplayed()
        {
            WaitForElementToExistByCssSelector(".product-results-header.clearfix.component");
            if (FilterSection == null)
            {
                throw new NullReferenceException("Unable to locate page header");
            }
            AssertElementPresent(FilterSection, "Is filter section present", 30);
        }

        public void IsFindOutMoreButtonDisplayed()
        {
            WaitForElementToExistByCssSelector(".btn-info");
            if (FindOutMoreButton == null)
            {
                throw new NullReferenceException("Unable to locate page header");
            }
            AssertElementPresent(FindOutMoreButton, "Find out More", 30);
        }
        public void IsAccessoryProductTitleDisplayed()
        {
            WaitForElementToExistByCssSelector(".col-xs-12.col-md-6.product-detail--container-title");
            if (AccessoryProductTitle == null)
            {
                throw new NullReferenceException("Unable to locate page header");
            }
            AssertElementPresent(AccessoryProductTitle, "Accessory Product Title", 30);
        }
        
        public void IsGlossarySectionDisplayed()
        {
            WaitForElementToExistByCssSelector(".row.glossary-listing_tab-item");
            if (GlossarySection == null)
            {
                throw new NullReferenceException("Unable to locate page header");
            }
            AssertElementPresent(GlossarySection, "Glossary Section", 30);
        }

        public void IsPageArticleDisplayed()
        {
            WaitForElementToExistByCssSelector(".common-results-list--article");
            if (PageArticle == null)
            {
                throw new NullReferenceException("Unable to locate page header");
            }
            AssertElementPresent(PageArticle, "Page Article", 30);
        }

        public void IsSearchIconDisplayed()
        {
            WaitForElementToExistByCssSelector("body > header > div > div > a.common-global-header--toggle.active");
            if (SearchIcon == null)
            {
                throw new NullReferenceException("Unable to locate search icon");
            }
            AssertElementPresent(SearchIcon, "Search Icon", 30);
        }

        public void IsTopNavDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div:nth-child(5) > nav > div");
            if (TopNavi == null)
            {
                throw new NullReferenceException("Unable to locate top navigation component");
            }
            AssertElementPresent(TopNavi, "Top Navigation", 30);
        }

        public void IsAccordionDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common-accordion > div:nth-child(1) > div.collapsed.common-accordion--item--header > div");
            if (Accordion == null)
            {
                throw new NullReferenceException("Unable to locate accordion component");
            }
            AssertElementPresent(Accordion, "Accordion Component", 30);
        }

        public void IsFeaturesCarouselDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common--features-carousel > ul");
            if (FeaturesCarousel == null)
            {
                throw new NullReferenceException("Unable to locate features carousel component");
            }
            AssertElementPresent(FeaturesCarousel, "Features Carousel", 30);
        }

        public void IsFeaturesCarouselTileDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common--features-carousel > ul > li:nth-child(1) > a > img");
            if (FeaturesCarouselTile == null)
            {
                throw new NullReferenceException("Unable to locate features carousel tile component");
            }
            AssertElementPresent(FeaturesCarouselTile, "Features Carousel Tile", 30);
        }

        public void IsBannerBarDisplayedDisplayed()
        {
            WaitForElementToExistByCssSelector(".common--banner-bar.component");
            if (BannerBar == null)
            {
                throw new NullReferenceException("Unable to locate banner bar component");
            }
            AssertElementPresent(BannerBar, "BannerBar", 30);
        }

        public void IsBannerBarTileDisplayed()
        {
            WaitForElementToExistByCssSelector(".common--banner-bar.component");
            if (BannerBarTile == null)
            {
                throw new NullReferenceException("Unable to locate banner bar tile component");
            }
            AssertElementPresent(BannerBarTile, "Banner Bar Tile", 30);
        }

        public void IsImageTextModuleDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid.scEnabledChrome > div > div.col-xs-12.grid-cell > div:nth-child(13) > article > div.common-info-image__content.common--wysiwyg-block");
            if (ImageTextModule == null)
            {
                throw new NullReferenceException("Unable to locate image text module component");
            }
            AssertElementPresent(ImageTextModule, "Image Text Module", 30);
        }

        public void IsSecondaryNavigationDisplayed()
        {
            //WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(5) > nav");
            WaitForElementToExistByCssSelector(".common-subheader"); 
            if (SecondaryNav == null)
            {
                throw new NullReferenceException("Unable to locate secondary navigation component");
            }
            AssertElementPresent(SecondaryNav, "Secondary Navigation", 30);
        }

        public void IsBreadcrumbsDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > ol");
            if (Breadcrumb == null)
            {
                throw new NullReferenceException("Unable to locate breadcrumb component");
            }
            AssertElementPresent(Breadcrumb, "Breadcrumb", 30);
        }

        public void IsCaseStudyDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common-case-study > div.col-xs-12.col-sm-6.col-md-8.common-case-study--content.common--wysiwyg-block");
            if (OjCaseStudy == null)
            {
                throw new NullReferenceException("Unable to locate OJ case study component");
            }
            AssertElementPresent(OjCaseStudy, "OJ Case Study", 30);
        }

        public void IsContactBarDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common--contact-bar");
            if (ContactBar == null)
            {
                throw new NullReferenceException("Unable to locate contact bar component");
            }
            AssertElementPresent(ContactBar, "Contact Bar", 30);
        }

        public void IsBenefitBarDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common--benefits-tiles");
            if (BenefitBar == null)
            {
                throw new NullReferenceException("Unable to locate benefit bar component");
            }
            AssertElementPresent(BenefitBar, "Benefit Bar", 30);
        }

        public void IsBenefitBarTileDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common--benefits-tiles > div.common--benefits-tiles--body-container > div > img");
            if (BenefitBarTile == null)
            {
                throw new NullReferenceException("Unable to locate benefit bar tile component");
            }
            AssertElementPresent(BenefitBarTile, "Benefit Bar Tile", 30);
        }

        public void IsLatestNewsDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common--latest-news > div:nth-child(1) > h2");
            if (LatestNews == null)
            {
                throw new NullReferenceException("Unable to locate latest news component");
            }
            AssertElementPresent(LatestNews, "Latest News", 30);
        }

        public void IsHeaderBarDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(13)");
            if (HeaderBar == null)
            {
                throw new NullReferenceException("Unable to locate header bar component");
            }
            AssertElementPresent(HeaderBar, "Header Bar", 30);
        }

        public void IsFullInfoTileDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(13)");
            if (FullInfoTile == null)
            {
                throw new NullReferenceException("Unable to locate full info tile component");
            }
            AssertElementPresent(FullInfoTile, "Full Info Tile", 30);
        }

        public void IsHeroDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > header.common-hero");
            if (Hero == null)
            {
                throw new NullReferenceException("Unable to locate hero component");
            }
            AssertElementPresent(Hero, "Hero", 30);
        }

        public void IsSecondaryHeroDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(15) > picture");
            if (SecondaryHero == null)
            {
                throw new NullReferenceException("Unable to locate secondary hero component");
            }
            AssertElementPresent(SecondaryHero, "Secondary Hero", 30);
        }

        public void IsFeatureModuleLeftDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(16) > div");
            if (FeatureModLeft == null)
            {
                throw new NullReferenceException("Unable to locate feature module left component");
            }
            AssertElementPresent(FeatureModLeft, "Feature Module Left", 30);
        }

        public void IsFeatureModuleRightDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common-feature-module.common-feature-module__text-left > div");
            if (FeatureModRight == null)
            {
                throw new NullReferenceException("Unable to locate feature module right component");
            }
            AssertElementPresent(FeatureModRight, "Feature Module Right", 30);
        }

        public void IsFeatureBarComponentDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common--banner-bar.common--banner-bar__features");
            if (FeatureBar == null)
            {
                throw new NullReferenceException("Unable to locate feature bar component");
            }
            AssertElementPresent(FeatureBar, "Feature Bar Component", 30);
        }

        public void IsFeatureBarTileDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common--banner-bar.common--banner-bar__features > div.common--banner-bar--items > div:nth-child(1)");
            if (FeatureBar == null)
            {
                throw new NullReferenceException("Unable to locate feature bar tile");
            }
            AssertElementPresent(FeatureTile, "Feature Bar Tile", 30);
        }

        public void IsSuperCarouselDisplayed()
        {
            WaitForElementToExistByCssSelector("#superCarousel > div");
            if (SuperCarousel == null)
            {
                throw new NullReferenceException("Unable to locate super carousel component");
            }
            AssertElementPresent(SuperCarousel, "Super Carousel", 30);
        }


        public void IsVideoListModuleDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(20)");
            if (VidListMod == null)
            {
                throw new NullReferenceException("Unable to locate video list module component");
            }
            AssertElementPresent(VidListMod, "Video List Module", 30);
        }
        
        public void IsVideoTileBarModuleDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(21)");
            if (VidTileBar == null)
            {
                throw new NullReferenceException("Unable to locate video tile bar component");
            }
            AssertElementPresent(VidTileBar, "Video Tile Bar", 30);
        }


        public void IsFullWidthHeroDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(22) > div");
            if (FullWidthHero == null)
            {
                throw new NullReferenceException("Unable to locate full width hero component");
            }
            AssertElementPresent(FullWidthHero, "Full Width Hero", 30);
        }

        public void IsSpecialFullInfoDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common--special-full-info-tile");
            if (SpecFullInfo == null)
            {
                throw new NullReferenceException("Unable to locate special full info component");
            }
            AssertElementPresent(SpecFullInfo, "Special Full Info", 30);
        }

        public void IsConversionBarDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.common--conversion-bar.component");
            if (ConvBar == null)
            {
                throw new NullReferenceException("Unable to locate conversion bar component");
            }
            AssertElementPresent(ConvBar, "Conversion Bar", 30);
        }

        public void IsWizardDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > header.common--wizard.common--wizard__alt");
            if (Wizard == null)
            {
                throw new NullReferenceException("Unable to locate wizard component");
            }
            AssertElementPresent(Wizard, "Wizard", 30);
        }

        public void IsSpecialFeatureDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section.common-special-feature.common-special-feature__first");
            if (SpecFeature == null)
            {
                throw new NullReferenceException("Unable to locate special feature component");
            }
            AssertElementPresent(SpecFeature, "Special Feature", 30);
        }

        public void IsStepsBarDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.omnijoin-wizard-step > div");
            if (StepsBar == null)
            {
                throw new NullReferenceException("Unable to locate step bar component");
            }
            AssertElementPresent(StepsBar, "Steps Bar", 30);
        }

        public void IsHeroCarouselDisplayed()
        {
            WaitForElementToExistByCssSelector("#heroCarousel > div > div > div");
            if (HeroCarousel == null)
            {
                throw new NullReferenceException("Unable to hero carousel component");
            }
            AssertElementPresent(HeroCarousel, "Hero Carousel", 30);
        }

        public void IsWizardStepDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > div.omnijoin-wizard-step > div");
            if (WizardStep == null)
            {
                throw new NullReferenceException("Unable to locate wizard step");
            }
            AssertElementPresent(WizardStep, "Wizard Step; ", 30);
        }

        public void IsRichTextModuleDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > section:nth-child(31)");
            if (RichTextMod == null)
            {
                throw new NullReferenceException("Unable to locate rich text module");
            }
            AssertElementPresent(RichTextMod, "Rich Text Module", 30);
        }

        public void IsListItemIsDisplayed()
        {
            WaitForElementToExistByCssSelector("body > div.container.container--grid > div > div.col-xs-12.grid-cell > nav > div:nth-child(1) > a");
            if (LinkListItem == null)
            {
                throw new NullReferenceException("Unable to locate link list item");
            }
            AssertElementPresent(LinkListItem, "Link List Item", 30);
        }

        public void IsWffmDisplayed()
        {
            WaitForElementToExistByCssSelector("");
            if (Wffm == null)
            {
                throw new NullReferenceException("Unable to locate web forms for marketing component");
            }
            AssertElementPresent(Wffm, "Web Forms For Marketing", 30);
        }
        

    }
}
