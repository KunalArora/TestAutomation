using System;
using System.Linq;
using System.Security.Policy;
using Brother.Tests.Selenium.Lib.Support;
using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
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

        [Given(@"I have navigated to the ""(.*)"" Brother Main Site")]
        public void GivenIHaveNavigatedToTheBrotherMainSite(string country)
        {
            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadBrotherMainSiteHomePage(CurrentDriver, BasePage.BaseUrl);
        }

        [Then(@"I shold see the tilte of the page is displayed")]
        public void ThenISholdSeeTheTilteOfThePageIsDisplayed()
        {
            CurrentPage.As<MainSiteHomePage>().DoPageTileExist();
        }

        [Then(@"the slides on the home page are displayed properly")]
        public void ThenTheSlidesOnTheHomePageAreDisplayedProperly()
        {
            CurrentPage.As<MainSiteHomePage>().AreSlidesDisplayed();
        }

        [Then(@"the footer of the home page is displayed properly")]
        public void ThenTheFooterOfTheHomePageIsDisplayedProperly()
        {
            CurrentPage.As<MainSiteHomePage>().DoFooterExistsOnHomePage();
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
            CurrentPage = GlobalNavigationModule.NavigateToLaserPrintersonBrotherSite(CurrentDriver, url);
        }

        [Given(@"I navigated to the ""(.*)"" all printers page ""(.*)""")]
        public void GivenINavigatedToTheAllPrintersPage(string country, string pageUrl)
        {
            Helper.SetCountry(country);
            CurrentPage = GlobalNavigationModule.NavigateToAllPrintersPage(CurrentDriver, pageUrl);
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
        [Given(@"I navigate from Mainsite Page to Login page")]
        public void GivenINavigateFromMainsitePageToLoginPage()
        {
            CurrentPage.As<MainSiteHomePage>();
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
        [Given(@"I enter an username containing ""(.*)""")]
        public void GivenIEnterAnUsernameContaining(string username)
        {
            CurrentPage.As<LoginPage>().PopulateUserNameTextBox(username);
        }

        [Given(@"That I navigate to ""(.*)"" Brother SiteCore CMS site URL for ""(.*)"" to validate")]
        public void GivenThatINavigateToBrotherSiteCoreCMSSiteURLForToValidate(string url, string country)
        {
            Helper.SetCountry(country);
            CurrentPage = BasePage.LoadBrotherMainSiteLoginPage(CurrentDriver, url);
            CurrentPage.As<LoginPage>().GetLoginpage(url);
        }

        [Given(@"I navigate to ""(.*)"" and check page")]
        public void GivenINavigateToAndCheckPage(string website)
        {
            TestController.CurrentDriver.Navigate().GoToUrl(website);
        }

        [Then(@"I navigate to ""(.*)"" and check page")]
        public void ThenINavigateToAndCheckPage(string webSite)
        {
            TestController.CurrentDriver.Navigate().GoToUrl(webSite);
        }
        [Given(@"I enter password containing ""(.*)""")]
        public void GivenIEnterPasswordContaining(string password)
        {
            CurrentPage.As<LoginPage>().PopulatePasswordTextBox(password);
        }
        [Given(@"I press login button ""(.*)""")]
        public void WhenIPressLoginButton(string country)
        {
            //CurrentPage.As<LoginPage>().ClickOnLoginButton(country);
            NextPage = CurrentPage.As<LoginPage>().ClickOnLoginButton(country);
        }
        [Then(@"I should be able to see the experience editor page ""(.*)""")]
        public void ThenIShouldBeAbleToSeeTheExperienceEditorPage(string country)
        {
            //CurrentPage = BasePage.LoadExperienceEditorPage(CurrentDriver, country);
            CurrentPage.As<ExperienceEditorPage>().IsContentEditorLinkAvailable();
        }
        [Then(@"I can verify that the page header is displayed on the experience editor ""(.*)""")]
        public void ThenICanVerifyThatThePageHeaderIsDisplayedOnTheExperienceEditor(string country)
        {
            //CurrentPage = BasePage.LoadExperienceEditorPage(CurrentDriver, country);
            CurrentPage.As<ExperienceEditorPage>().IsPageHeaderDisplayed();
        }

       [Then(@"I click on the Content Editor option ""(.*)""")]
        public void ThenIClickOnTheContentEditorOption(string country)
        {
            //CurrentPage.As<ExperienceEditorPage>().ClickOnContentEditor(country);
            NextPage = CurrentPage.As<ExperienceEditorPage>().ClickOnContentEditor(country);

        }
       [Then(@"I should be able to see the content editor page ""(.*)""")]
       public void ThenIShouldBeAbleToSeeTheContentEditorPage(string country)
       {
           //CurrentPage = BasePage.LoadContentEditorPage(CurrentDriver, country);
           CurrentPage.As<ContentEditorPage>().IsRibbonBarExist();
           //CurrentPage.As<ContentEditorPage>().IsRibbonBarExist();
       }
       [Then(@"I navigate to the url ""(.*)""")]
       public void ThenINavigateToTheUrl(string p0)
       {
           CurrentDriver.Navigate().GoToUrl(p0);
       }
       [Given(@"I navigate to the url ""(.*)""")]
       public void GivenINavigateToTheUrl(string p0)
       {
           CurrentDriver.Navigate().GoToUrl(p0);
       }
       [Given(@"I click on the Main Header placeholder ""(.*)""")]
       public void GivenIClickOnTheMainHeaderPlaceholder(string country)
       {
          CurrentPage.As<LoginPage>().ClickOnMainHeader(country);
       }
       [Given(@"I click on the add here option ""(.*)""")]
       public void GivenIClickOnTheAddHereOption(string country)
       {
           CurrentPage.As<LoginPage>().ClickOnAddHere(country);
       }
       [Given(@"I click on the Select a Rendering ""(.*)""")]
       public void GivenIClickOnTheSelectARendering(string country)
       {
          CurrentPage.As<LoginPage>().ClickOnSelectRenderingWindow(country);
       }
       [Then(@"I should be able to add grid from the grid option ""(.*)""")]
       public void ThenIShouldBeAbleToAddGridFromTheGridOption(string country)
       {
           CurrentPage.As<LoginPage>().ClickOnGrid(country);
       }

       [Given(@"I have clicked on Supplies option")]
       public void GivenIHaveClickedOnSuppliesOption()
       {
           CurrentPage.As<MainSiteHomePage>().IsSuppliesLinkAvailable();
           NextPage = CurrentPage.As<MainSiteHomePage>().ClickSuppliesLink();
       }
    }
}
