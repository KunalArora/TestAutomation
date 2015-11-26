using Brother.Tests.Selenium.Lib.Support.HelperClasses;
using Brother.WebSites.Core.Pages.Base;
using Brother.WebSites.Core.Pages.BrotherMainSite;
using Brother.WebSites.Core.Pages.BrotherOnline.AccountManagement;
using TechTalk.SpecFlow;
using MainSiteHomePage = Brother.WebSites.Core.Pages8._0.BrotherMainSite.MainSiteHomePage;


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
        [Given(@"The following site ""(.*)"" to validate I should receive an Ok response back\ton mainsite login")]
        public void GivenTheFollowingSiteToValidateIShouldReceiveAnOkResponseBackOnMainsiteLogin(string url)
        {
            CurrentPage = BasePage.LoadBrotherMainSiteLoginPage(CurrentDriver, url);
            CurrentPage.As<LoginPage>().GetLoginpage(url);
        }
      
        [Given(@"I enter password containing ""(.*)""")]
        public void GivenIEnterPasswordContaining(string password)
        {
            CurrentPage.As<LoginPage>().PopulatePasswordTextBox(password);
        }
        [When(@"I press login button")]
        public void WhenIPressLoginButton(string country)
        {
            //NextPage = CurrentPage.As<LoginPage>().ClickOnLoginButton();
            CurrentPage.As<LoginPage>().ClickOnLoginButton();
        }
        [Then(@"I should be able to see the experience editor page")]
        public void ThenIShouldBeAbleToSeeTheExperienceEditorPage(string country)
        {
            //CurrentPage = BasePage.LoadExperienceEditorPage(CurrentDriver, url);
            //NextPage = CurrentPage.As<LoginPage>().NavigateToExperienceEditorPage(country);
           // CurrentPage.As<ExperienceEditorPage>().IsContentEditorLinkAvailable();
        }



    }
}
