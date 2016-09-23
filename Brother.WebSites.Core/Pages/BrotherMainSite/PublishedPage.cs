using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

        [FindsBy(How = How.CssSelector, Using = ".common-global-header")]
        public IWebElement PageHeader;

        [FindsBy(How = How.CssSelector, Using = ".col-xs-12.col-md-6.product-detail--container-title")]
        public IWebElement PageTitle;

        [FindsBy(How = How.CssSelector, Using = ".common-results-list--article")]
        public IWebElement PageArticle;

        [FindsBy(How = How.CssSelector, Using = ".col-xs-12.tab.glossary-listing")] 
        public IWebElement GlossarySection;

        [FindsBy(How = How.CssSelector, Using = ".product-results-header.clearfix.component")]
        public IWebElement FilterSection;

        [FindsBy(How = How.CssSelector, Using = ".btn-info")]
        public IWebElement FindOutMoreButton;

        [FindsBy(How = How.CssSelector, Using = ".col-xs-12.col-md-6.product-detail--container-title")]
        public IWebElement AccessoryProductTitle;

        [FindsBy(How = How.CssSelector, Using = "body > header > div > div > a.common-global-header--toggle.active")]
        public IWebElement SearchIcon;

        [FindsBy(How = How.CssSelector, Using = ".common-global-nav--list.common-global-nav--list--secondary")]
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

        [FindsBy(How = How.CssSelector, Using = ".common-global-nav")]
        public IWebElement HeaderBar;

        [FindsBy(How = How.CssSelector, Using = ".common-richtext")]
        public IWebElement FullInfoTile;

        [FindsBy(How = How.CssSelector, Using = "body > div.container.container--grid > div > div.col-xs-12.grid-cell > header.common-hero")]
        public IWebElement Hero;

        [FindsBy(How = How.CssSelector, Using = ".common-secondary-hero--container.common--wysiwyg-block")]
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

        [FindsBy(How = How.CssSelector, Using = ".common-video-bar")]
        public IWebElement VidTileBar;

        [FindsBy(How = How.CssSelector, Using = ".ytp-thumbnail-overlay.ytp-cued-thumbnail-overlay")]
        public IWebElement VidOnTileBar;

        [FindsBy(How = How.CssSelector, Using = ".common-secondary-hero--container")]
        public IWebElement FullWidthHero;

        [FindsBy(How = How.CssSelector, Using = ".common--special-full-info-tile.component")]
        public IWebElement SpecFullInfo;

        [FindsBy(How = How.CssSelector, Using = ".common--conversion-bar.component")]
        public IWebElement ConvBar;

        [FindsBy(How = How.CssSelector, Using = ".common--wizard.common--wizard__alt.component>picture>img")]
        public IWebElement Wizard;

        [FindsBy(How = How.CssSelector, Using = ".common-special-feature.common-special-feature__first")]
        public IWebElement SpecFeature;

        [FindsBy(How = How.CssSelector, Using = ".common--steps-tiles")]
        public IWebElement StepsBar;

        [FindsBy(How = How.CssSelector, Using = ".common-hero--text.common--wysiwyg-block")]
        public IWebElement HeroCarousel;

        [FindsBy(How = How.CssSelector, Using = ".omnijoin-wizard-step--step-number--status")]
        public IWebElement WizardStep;

        [FindsBy(How = How.CssSelector, Using = ".common-richtext.component")]
        public IWebElement RichTextMod;

        [FindsBy(How = How.CssSelector, Using = ".common-link-list.component")]
        public IWebElement LinkListItem;

        [FindsBy(How = How.CssSelector, Using = "")]
        public IWebElement Wffm;

        [FindsBy(How = How.CssSelector, Using = "#txtForename")]
        public IWebElement FirstNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtSurname")]
        public IWebElement LastNameTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtEmail")]
        public IWebElement EmailAddressTextBox;

        [FindsBy(How = How.CssSelector, Using = "#txtTelephone")]
        public IWebElement PhoneNumberTextBox;

        [FindsBy(How = How.CssSelector, Using = "#btnSubmit")]
        public IWebElement SubmitButton;

        [FindsBy(How = How.XPath, Using = ".//*[@for='chkTerms']")]
        public IWebElement AgreeToTermsAndConditions;

        public void GetPublishedPage(string url)
        {
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
            WaitForElementToExistByCssSelector(".common-global-header");
           //WaitForElementToExistByCssSelector(".common-global-header--title");
              if (PageHeader == null)
                 {
                   throw new NullReferenceException("Unable to locate page header");
                 }
            AssertElementPresent(PageHeader, "Page Header", 30);            
        }

        public void IsSupplyDescriptionDisplayed()
        {
            WaitForElementToExistByCssSelector(".product-detail--section.product-detail--product-description");
        }

        public void IsPageTitleDisplayed()
        {
            WaitForElementToExistByCssSelector(".product-detail--links.row");
            
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
            WaitForElementToExistByCssSelector(".col-xs-12.tab.glossary-listing");
            if (GlossarySection == null)
            {
                throw new NullReferenceException("Unable to locate page header");
            }
           
        }

        public void IsPageArticleDisplayed()
        {
            WaitForElementToExistByCssSelector(".common-results-list");
           // if (PageArticle == null)
            //{
             //   throw new NullReferenceException("Unable to locate page header");
            //}
            //AssertElementPresent(PageArticle, "Page Article", 30);
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
            WaitForElementToExistByCssSelector(".common-global-nav--list.common-global-nav--list--secondary");
            if (TopNavi == null)
            {
                throw new NullReferenceException("Unable to locate top navigation component");
            }
            AssertElementPresent(TopNavi, "Secondary nav icon basket", 30);
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
            WaitForElementToExistByCssSelector(".common-global-nav");
            if (HeaderBar == null)
            {
                throw new NullReferenceException("Unable to locate header bar component");
            }
        }

        public void IsFullInfoTileDisplayed()
        {
            WaitForElementToExistByCssSelector(".common-richtext");
            if (FullInfoTile == null)
            {
                throw new NullReferenceException("Unable to locate full info tile component");
            }
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
            WaitForElementToExistByCssSelector(".common-secondary-hero--container.common--wysiwyg-block");
            if (SecondaryHero == null)
            {
                throw new NullReferenceException("Unable to locate secondary hero component");
            }
           
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
            WaitForElementToExistByCssSelector(".common-video-bar");
            if (VidTileBar == null)
            {
                throw new NullReferenceException("Unable to locate video tile bar component");
            }
            }


        public void IsFullWidthHeroDisplayed()
        {
            WaitForElementToExistByCssSelector(".common-secondary-hero--container");
            if (FullWidthHero == null)
            {
                throw new NullReferenceException("Unable to locate full width hero component");
            }
        }

        public void IsSpecialFullInfoDisplayed()
        {
            WaitForElementToExistByCssSelector(".common--special-full-info-tile.component");
            if (SpecFullInfo == null)
            {
                throw new NullReferenceException("Unable to locate special full info component");
            }
        }

        public void IsConversionBarDisplayed()
        {
            WaitForElementToExistByCssSelector(".common--conversion-bar.component");
            if (ConvBar == null)
            {
                throw new NullReferenceException("Unable to locate conversion bar component");
            }
           
        }

        public void IsWizardDisplayed()
        {
            WaitForElementToExistByCssSelector(".common--wizard.common--wizard__alt.component>picture>img");
            if (Wizard == null)
            {
                throw new NullReferenceException("Unable to locate wizard component");
            }
            AssertElementPresent(Wizard, "Wizard ", 10);
        }

        public void IsSpecialFeatureDisplayed()
        {
            WaitForElementToExistByCssSelector(".common-special-feature.common-special-feature__first");
            if (SpecFeature == null)
            {
                throw new NullReferenceException("Unable to locate special feature component");
            }
           
        }

        public void IsStepsBarDisplayed()
        {
            WaitForElementToExistByCssSelector(".common--steps-tiles");
            if (StepsBar == null)
            {
                throw new NullReferenceException("Unable to locate step bar component");
            }
            
        }

        public void IsHeroCarouselDisplayed()
        {
            WaitForElementToExistByCssSelector(".common-hero--text.common--wysiwyg-block");
            if (HeroCarousel == null)
            {
                throw new NullReferenceException("Unable to hero carousel component");
            }
            AssertElementPresent(HeroCarousel, "Hero", 10);
        }

        public void IsWizardStepDisplayed()
        {
            WaitForElementToExistByCssSelector(".omnijoin-wizard-step--step-number--status");
            if (WizardStep == null)
            {
                throw new NullReferenceException("Unable to locate wizard step");
            }
            
        }

        public void IsRichTextModuleDisplayed()
        {
            WaitForElementToExistByCssSelector(".common-richtext.component");
            if (RichTextMod == null)
            {
                throw new NullReferenceException("Unable to locate rich text module");
            }
            
        }

        public void IsListItemIsDisplayed()
        {
            WaitForElementToExistByCssSelector(".common-link-list.component");
            if (LinkListItem == null)
            {
                throw new NullReferenceException("Unable to locate link list item");
            }
            
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
        public void PopulateFirstNameTextBox(string firstName)
        {
            FirstNameTextBox.SendKeys(firstName);

        }
        public void PopulateLastNameTextBox(string lastName)
        {
            LastNameTextBox.SendKeys(lastName);
        }
        public void PopulateEmailAddressTextBox(string emailAddress)
        {
            if (emailAddress.Equals(string.Empty))
            {
                emailAddress = Email.GenerateUniqueEmailAddress();
            }
            EmailAddressTextBox.Clear();
            EmailAddressTextBox.SendKeys(emailAddress);
         }
        public void PopulatePhoneNumberTextBox(string phoneNumber)
        {
            PhoneNumberTextBox.SendKeys(phoneNumber);
        }
        public void CheckTermsAndConditions()
        {
            ScrollTo(AgreeToTermsAndConditions);
            AgreeToTermsAndConditions.Click();
           
        }
        public DownloadPage ClickSubmitButton(string country)
        {
            MsgOutput(string.Format("Before identifying the button waiting for 20 Secconds."));
            Thread.Sleep(TimeSpan.FromSeconds(20));
            ScrollTo(SubmitButton);
            MsgOutput(string.Format("After identifying the button."));
            AssertElementPresent(SubmitButton,"Submit Button On Free Trial OJ Page.");
            SubmitButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(20));
            MsgOutput(string.Format("After clicking the button waiting for 20 Secconds."));
            return GetInstance<DownloadPage>(Driver);
        }
       
    }
}
